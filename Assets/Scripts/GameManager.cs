using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
  public GameObject player;
  public GameObject camera;
  public float cameraVelocity = 1.4f;
  public float cameraVelocityIncrementor = 0.2f;
  private float initialTime = 0f;
  private float initialHeight;
  private float initialCameraVelocity;
  public GameObject menuUI;
  public GameObject gameoverUI;
  public GameObject pointsUI;
  private TextMeshProUGUI pointsText;
  private int points = 0;
  // menu, gaming, gameover
  private string state = "menu";

  private bool showingUi = true;
  private bool gameStarted = false;

  private Vector3 initialCameraPosition;
  private Vector3 initialPlayerPosition;

  void Start()
  {
    // show UI
    pointsText = pointsUI.GetComponent<TextMeshProUGUI>();
    initialHeight = camera.transform.position.y;

    initialCameraPosition = camera.transform.position;
    initialPlayerPosition = player.transform.position;
    initialCameraVelocity = cameraVelocity;

  }


  void Update()
  {
    switch (state)
    {
      case "menu":
        {
          // show menu
          if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
          {
            initialTime = Time.time;
            state = "gaming";
            gameStarted = true;
            handleUI(state);
          }
          break;
        }
      case "gaming":
        {
          // every 10 seconds, increment camera velocity (speed caps at 2.2)
          if (Time.time - initialTime >= 30 && cameraVelocity < 2.2f)
          {
            initialTime = initialTime + 30;
            cameraVelocity += cameraVelocityIncrementor;
                        print(cameraVelocity);
          }
          camera.transform.position += new Vector3(0, (-cameraVelocity - cameraVelocityIncrementor) * Time.deltaTime, 0);

          // increase points based on camera height
          points = (int)((initialHeight - camera.transform.position.y) * 10);

          // update points
          pointsText.text = "" + points;

          // print player position relative to this gameobject
          float difference = player.transform.position.y - camera.transform.position.y;

                    // if difference is greater than 4.33 or less than -4.33
        if (difference > 7 || difference < -6)
         {
            state = "gameover";
            handleUI(state);
        }
        if (camera.transform.position.y < -293) //checks if the player has won based on camera position
           {
           state = "win";
           handleUI("gameover");
            }
          break;
        }
      case "gameover":
        {
          gameoverUI.GetComponent<TextMeshProUGUI>().SetText("GAMEOVER\n\nSCORE: " + points + "\n\nPRESS R TO PLAY AGAIN");
          // show gameover
          if (Input.GetKeyDown(KeyCode.R))
          {
            state = "menu";
            gameStarted = false;
            cameraVelocity = initialCameraVelocity;
            camera.transform.position = initialCameraPosition;
            player.transform.position = initialPlayerPosition;
            handleUI(state);
          }
          break;
        }
      case "win":
       {
        gameoverUI.GetComponent<TextMeshProUGUI>().SetText("CONGRATULATIONS!\n\nSCORE: " + points + "\n\nPRESS R TO PLAY AGAIN");
         if (Input.GetKeyDown(KeyCode.R))
         {
             state = "menu";
             gameStarted = false;
             cameraVelocity = initialCameraVelocity;
             camera.transform.position = initialCameraPosition;
             player.transform.position = initialPlayerPosition;
             handleUI(state);
          }
          break;
          }
        }
  }

  void handleUI(string state)
  {
    switch (state)
    {
      case "menu":
        {
          menuUI.SetActive(true);
          gameoverUI.SetActive(false);
          pointsUI.SetActive(false);
          break;
        }
      case "gaming":
        {
          menuUI.SetActive(false);
          gameoverUI.SetActive(false);
          pointsUI.SetActive(true);
          break;
        }
      case "gameover":
        {
          menuUI.SetActive(false);
          gameoverUI.SetActive(true);
          pointsUI.SetActive(false);
          break;
        }
    }
  }
}
