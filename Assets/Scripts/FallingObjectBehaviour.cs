using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectBehaviour : MonoBehaviour
{
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
    Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();

    yield return new WaitForSeconds(time);
    rb.isKinematic = false;

    yield return new WaitForSeconds(5);
	Destroy(gameObject);

  }
}
