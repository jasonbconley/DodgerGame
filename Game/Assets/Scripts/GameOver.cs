using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    public static bool playerWon = false;
    public static bool enemyWon = false;
    public GameObject playerOver;
    public GameObject enemyOver;
    public GameObject enemyScore;
    public GameObject playerScore;
    // Start is called before the first frame update
    void Start()
    {
        playerOver.SetActive(false);
        enemyOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerWon)
        {
            playerOver.SetActive(true);
            runGameOver();
        }
        else if (enemyWon)
        {
            enemyOver.SetActive(true);
            runGameOver();
        }
    }

    void runGameOver()
    {
        playerMovement.disable = true;
        EnemyAI.disable = true;
        VolleyBallController.disable = true;
        enemyScore.SetActive(false);
        playerScore.SetActive(false);
    }
}
