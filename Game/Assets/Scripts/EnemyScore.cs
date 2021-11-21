using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScore : MonoBehaviour
{
    public Text score;
    public static bool collided = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (collided)
        {
            Scoring();
        }
    }

    void Scoring()
    {
        int currScore = int.Parse(score.text);
        currScore += 1;
        score.text = currScore.ToString();
        collided = false;
    }
}
