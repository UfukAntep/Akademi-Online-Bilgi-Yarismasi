using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Leaderboard : MonoBehaviour
{
    public PhpController phpController;
    public string[] userNames, userScores, namesAndScores;

    void Start()
    {
        for (int i=0; i < 10; i++)
        {
            userNames[i] = PlayerPrefs.GetString("userNames" + i);
        }
        phpController.ScoreRead();
        StartCoroutine(Coroutine());
    }
    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(3); 
        
        foreach (string nameAndScore in namesAndScores)
        {
            if (nameAndScore != null)
            {
                phpController.leaderboard.text += nameAndScore + "\n";
            }
        }
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }


}
