using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectDeath : MonoBehaviour
{
  public GameObject player;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    // print player position relative to this gameobject
    float difference = player.transform.position.y - transform.position.y;

    // if difference is greater than 4.33 or less than -4.33
    if (difference > 4.33 || difference < -4.33)
    {
      // player dies
      print("Player dies");
    }
  }
}
