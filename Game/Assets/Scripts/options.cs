using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class options : MonoBehaviour
{
    public static bool giveInfinite = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (giveInfinite)
        {
            setArms();
        }
    }

    static public void setArms()
    {
        VolleyBallController.infiniteArms = true;
    }
}
