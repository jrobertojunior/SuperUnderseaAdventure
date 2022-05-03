using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public GameObject player;
  public GameObject camera;
  public float initialCameraVelocity = 0.001f;

  // menu, gaming, gameover
  private string state = "menu";

  private bool showingUi = true;
  private bool gameStarted = false;

  void Start()
  {
    // show UI
  }


  void FixedUpdate()
  {
    print(state);
    switch (state)
    {
      case "menu":
        {
          // show menu
          if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
          {
            state = "gaming";
            gameStarted = true;
          }
          break;
        }
      case "gaming":
        {
          camera.transform.position += new Vector3(0, -initialCameraVelocity * Time.deltaTime, 0);

          // print player position relative to this gameobject
          float difference = player.transform.position.y - camera.transform.position.y;

          // if difference is greater than 4.33 or less than -4.33
          if (difference > 4.33 || difference < -4.33)
          {
            state = "gameover";
          }
          break;
        }
      case "gameover":
        {
          // show gameover
          if (Input.GetKeyDown(KeyCode.Space))
          {
            state = "menu";
            gameStarted = false;
          }
          break;
        }
    }
  }
}
