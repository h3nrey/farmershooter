using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBehaviour : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float velocity;
    Vector2 input;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        rb.velocity = transform.forward * input.y * 10 + transform.right * input.x * 10;
    }
}
