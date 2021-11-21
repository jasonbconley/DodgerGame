using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float sens = 100f;
    float xRotation = 0;

    // Using code from https://www.youtube.com/watch?v=_QajrabyTJc

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sens;
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sens;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 45f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
        
    }
}
