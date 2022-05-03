using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
  public GameObject player;
  public GameObject camera;
  public float initialCameraVelocity = 0.001f;
  private float initialHeight;
  public GameObject menuUI;
  public GameObject gameoverUI;
  public GameObject pointsUI;
  private TextMeshProUGUI pointsText;
  private int points = 0;
  // menu, gaming, gameover
  private string state = "menu";

  private bool showingUi = true;
  private bool gameStarted = false;

  void Start()
  {
    // show UI
    pointsText = pointsUI.GetComponent<TextMeshProUGUI>();
    initialHeight = camera.transform.position.y;
  }


  void FixedUpdate()
  {
    switch (state)
    {
      case "menu":
        {
          // show menu
          if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
          {
            state = "gaming";
            gameStarted = true;
            handleUI(state);
          }
          break;
        }
      case "gaming":
        {
          camera.transform.position += new Vector3(0, -initialCameraVelocity * Time.deltaTime, 0);

          // increase points based on camera height
          points = (int)((initialHeight - camera.transform.position.y) * 10);

          // update points
          pointsText.text = "" + points;

          // print player position relative to this gameobject
          float difference = player.transform.position.y - camera.transform.position.y;

          // if difference is greater than 4.33 or less than -4.33
          if (difference > 6 || difference < -6)
          {
            state = "gameover";
            handleUI(state);
          }
          break;
        }
      case "gameover":
        {
          gameoverUI.GetComponent<TextMeshProUGUI>().SetText("GAMEOVER\n\nSCORE: " + points);
          // show gameover
          if (Input.GetKeyDown(KeyCode.Space))
          {
            state = "menu";
            gameStarted = false;
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
