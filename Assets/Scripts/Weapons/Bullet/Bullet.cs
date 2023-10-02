using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Update()
    {
        this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up;
    }
}
