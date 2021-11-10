using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Two2DCam : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        //transform.position = player.transform.position + offset;
        transform.position = transform.position + player.transform.position;
    }
}
