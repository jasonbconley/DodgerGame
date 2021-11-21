using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolleyBallSpawner : MonoBehaviour
{

    public static Transform spawn;
    public Transform hidden;
    public GameObject ball;

    // Start is called before the first frame update
    void Awake()
    {
        spawn = GameObject.FindGameObjectWithTag("BallSpawn").transform;
        hidden = GameObject.FindGameObjectWithTag("hidden").transform;
        Instantiate(ball, hidden.position, hidden.rotation);
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
