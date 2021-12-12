using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuActions : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SetArms()
    {
        VolleyBallController.infiniteArms = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
