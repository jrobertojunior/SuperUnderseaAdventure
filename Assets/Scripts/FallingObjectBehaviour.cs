using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectBehaviour : MonoBehaviour
{
  public Rigidbody2D rb;
  public float time = 0.5f;
  void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.tag == "Player")
    {
      StartCoroutine("FallDown");
    }
  }

  IEnumerator FallDown()
  {
    yield return new WaitForSeconds(time);
    rb.isKinematic = false;
  }
}
