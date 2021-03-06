using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    float speed = 4f;
    Animator animator;
    Vector3 move;
    Rigidbody rb;
    float jump = 10;
    public static bool disable = false;

    // Using code from https://www.youtube.com/watch?v=_QajrabyTJc

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    public void Start()
    {

    }

    void Update()
    {
        if (disable)
        {
            this.gameObject.GetComponent<playerMovement>().enabled = false;
        }
    }
    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        move = transform.right * h + transform.forward * v;
        move = move.normalized * speed * Time.deltaTime;
        rb.MovePosition(transform.position + move);
        AnimPlayer(h, v);
    }

    void AnimPlayer(float h, float v)
    {
        bool walking = h != 0 || v != 0;
        animator.SetBool("IsWalking", walking);
    }

}
