using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    private int direction = 1;
    private float moveSpeed = 3;
    private void Update()
    {
        Vector3 movement = new Vector3(0f,direction,0f);
        transform.Translate(movement * moveSpeed * Time.deltaTime);
        if (transform.position.y >= 1.5f || transform.position.y <= -1.5f)
        {
            direction *= -1;
        }
    }
}
