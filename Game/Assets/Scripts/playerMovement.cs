using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed;

    public void Start()
    {
    }

    public void Update()
    {
        Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        this.transform.position += Movement * speed * Time.deltaTime;
    }

}
