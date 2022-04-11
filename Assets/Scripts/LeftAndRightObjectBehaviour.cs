using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftAndRightObjectBehaviour : MonoBehaviour
{

  public float frequency = 1.0f;
  public float amplitude = 1.0f;

  // make 2d gameobject move left and right using cossine function
  void Update()
  {
    transform.position += Vector3.left * Mathf.Cos(Time.time * frequency) * amplitude * Time.deltaTime;
  }
}
