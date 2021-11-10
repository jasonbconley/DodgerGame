using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Vector2 inputVector;
    public float speed;
    private Rigidbody rb;

    Camera mainCamera;
    public Camera twoDCamera;
    private Vector3 movePos = new Vector3(0,0,0);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
        mainCamera.enabled = false;
        twoDCamera.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && (twoDCamera.enabled))
        {
            mainCamera.enabled = true;
            twoDCamera.enabled = false;
        }
        else if (Input.GetMouseButtonDown(1) && (mainCamera.enabled)) 
        {
            mainCamera.enabled = false;
            twoDCamera.enabled = true;
        }

        if (twoDCamera.enabled && Input.GetMouseButton(0)) // https://gamedevbeginner.com/how-to-convert-the-mouse-position-to-world-space-in-unity-2d-3d/#screen_to_world_2d
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = twoDCamera.nearClipPlane;
            movePos = twoDCamera.ScreenToWorldPoint(mousePos);
        }

    }

    private void FixedUpdate() {

            float horizontalMove = movePos.x;
            float verticalMove = movePos.y;

            Vector3 movement = new Vector3(horizontalMove, 0, verticalMove);
            rb.AddForce(movement * speed);
    }
}
