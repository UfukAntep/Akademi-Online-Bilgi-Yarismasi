using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PhpController : MonoBehaviour
{
    public GameController gameController;
    public string url;
    string data; 
    public InputField gamePassword;
    public Text gameID;

    public Text userListText;
    public string userList;
    public int userCount=0;

    private float currentTime=20;
    public Text countdownText;
    public GameObject countdownObject, menuLock;
    int user1Score, user2Score, user3Score, user4Score;

    public Text leaderboard;
    public Leaderboard leaderboardScript;
    int lastControll;

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            PlayerPrefs.SetInt("gameStart", 0);
            System.Random rnd = new System.Random();

            for (int i = 0; i < 8; i++)
            {
                gameID.text += rnd.Next(0, 8).ToString();
            }

            // Oluşturulan rasgele sayıyı konsola yazdırın
            Debug.Log("8 haneli rasgele sayı: " + gameID);

            for (int i=0; i<10; i++)
            {
                PlayerPrefs.SetString("userNames" + i,"");
            }
        }
        
       
    }

    void Update()
    {
        if (userCount >= 2)
        {
            gameController.lobby.SetActive(false);
            countdownObject.SetActive(true);
            currentTime -= Time.deltaTime;

            if (currentTime < 10 && lastControll == 0)
            {
                lastControll = 1;
                UserUpdate();
            }

            if (currentTime <= 0)
            {
                PlayerPrefs.SetInt("gameStart",1);
                StartCoroutine(GameStart());
            }

            UpdateCountdownText();
        }   
    }

    IEnumerator GameStart()
    {
        data = "write";
        WWWForm form1 = new WWWForm();
        form1.AddField("GameID", PlayerPrefs.GetString("GameID"));
        form1.AddField("isStarted", "1");
        form1.AddField("Game", data);
        WWW connector = new WWW(url, form1);
        yield return connector;
        Debug.Log("Log " + connector.text);
        SceneManager.LoadScene(2);
    }
    void UpdateCountdownText()
    {
        countdownText.text = "" + Mathf.RoundToInt(currentTime);
    }

    public void NewGame()
    {
        menuLock.SetActive(true);
        PlayerPrefs.SetString("GameID",gameID.text);
        PlayerPrefs.SetString("GamePassword", gamePassword.text);
        StartCoroutine(AddNewGame());
    }

    IEnumerator AddNewGame()
    {
        data = "write";
        WWWForm form1 = new WWWForm();
        form1.AddField("GameID", gameID.text);
        form1.AddField("GamePassword", gamePassword.text);
        form1.AddField("NewGame", data);
        WWW connector = new WWW(url, form1);
        yield return connector;
        Debug.Log("Log " + connector.text);
        Application.LoadLevel(1);
    }
    public void UserUpdate()
    {
        StartCoroutine(Users());
    }
    IEnumerator Users()
    {
        data = "read";
        WWWForm form1 = new WWWForm();
        form1.AddField("GameID", PlayerPrefs.GetString("GameID"));
        form1.AddField("Users", data);
        WWW connector = new WWW(url, form1);
        yield return connector;
        Debug.Log("Log " + connector.text);
        userList = connector.text;
        if (userList != "")
        {
            string[] words = userList.Split(',');
            userCount = words.Length;
            string result = string.Join("\n", words);
            print(result);
            userListText.text = result;

            string[] userNames = new string[userCount];
            for (int i = 0; i < userCount; i++)
            {
                userNames[i] = words[i];
                PlayerPrefs.SetString("userNames"+i,userNames[i]);
                print(userNames[i]);
            }
        }

        print("wordCount " + userCount);
    }

    public void ScoreRead()
    {
        StartCoroutine(ScoreAll());
        /*StartCoroutine(Score1());
        StartCoroutine(Score2());
        StartCoroutine(Score3());
        StartCoroutine(Score4());*/
    }
    IEnumerator ScoreAll()
    {
        data = "read";
        WWWForm form1 = new WWWForm();
        form1.AddField("GameID", PlayerPrefs.GetString("GameID"));
        form1.AddField("ScoreAll", data);
        WWW connector = new WWW(url, form1);
        yield return connector;
        Debug.Log("Log " + connector.text);

        leaderboardScript.userScores = connector.text.Split(',');
        int[] userScores = new int[leaderboardScript.userScores.Length];
        for (int i = 0; i < leaderboardScript.userScores.Length; i++)
        {
            int.TryParse(leaderboardScript.userScores[i], out userScores[i]);
        }

        leaderboardScript.namesAndScores = new string[leaderboardScript.userScores.Length];
        for (int i = 0; i < leaderboardScript.userScores.Length; i++)
        {
            if (leaderboardScript.userNames[i] != "")
            {
                leaderboardScript.namesAndScores[i] = leaderboardScript.userNames[i] + ":" + leaderboardScript.userScores[i];
            }
        }

        Array.Sort(leaderboardScript.namesAndScores, (x, y) => int.Parse(y.Split(':')[1]).CompareTo(int.Parse(x.Split(':')[1])));
        
        
    }

   

}
