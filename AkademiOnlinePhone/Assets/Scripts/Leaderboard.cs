using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public Text score;
    public PhpController php;

    void Start()
    {
        score.text = PlayerPrefs.GetFloat("Score").ToString();
        php.Score();
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }


}
