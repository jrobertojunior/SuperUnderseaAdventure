using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectDeath : MonoBehaviour
{
  UnityEvent deathEvent;
  public GameObject player;
  // Start is called before the first frame update
  void Start()
  {
    if (deathEvent == null)
      deathEvent = new UnityEvent();

    deathEvent.AddListener(Ping);
  }

  // Update is called once per frame
  void Update()
  {
    // print player position relative to this gameobject
    float difference = player.transform.position.y - transform.position.y;

    // if difference is greater than 4.33 or less than -4.33
    if (difference > 4.33 || difference < -4.33)
    {
      deathEvent.Invoke();
    }
  }

  void Ping()
  {
    Debug.Log("Died");
  }
}
