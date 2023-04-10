using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PhpController : MonoBehaviour
{
    public string url;
    string data; 
    public InputField gameID, gamePassword, userName;

    public Text userListText;
    public string userList, userReadyList;
    public GameObject lobby, loading, lockMenu, lockLobby;

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            lockMenu.SetActive(false);
        }
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            lockLobby.SetActive(false);
        }
        InvokeRepeating("isStartedController", 0f, 1f);
    }

    void Update()
    {
    }
    public void isStartedController()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            print("isStarted Kontrol ediliyor");
            StartCoroutine(isStartedCR());
        }
    }
    IEnumerator isStartedCR()
    {
        data = "read";
        WWWForm form1 = new WWWForm();
        print(PlayerPrefs.GetString("GameID"));
        form1.AddField("GameID", PlayerPrefs.GetString("GameID"));
        form1.AddField("Game", data);
        WWW connector = new WWW(url, form1);
        yield return connector;
        Debug.Log("Log " + connector.text);
        if (connector.text == "1")
        {
            SceneManager.LoadScene(2);
        }
    }
    public void Login()
    {
        lockMenu.SetActive(true);
        PlayerPrefs.SetString("GameID",gameID.text);
        PlayerPrefs.SetString("GamePassword", gamePassword.text);
        StartCoroutine(LoginGame());
    }

    IEnumerator LoginGame()
    {
        data = "read";
        WWWForm form1 = new WWWForm();
        form1.AddField("GameID", gameID.text);
        form1.AddField("Login", data);
        WWW connector = new WWW(url, form1);
        yield return connector;
        Debug.Log("Log " + connector.text);
        if (connector.text == gamePassword.text)
        {
            Application.LoadLevel(1);
        }
        else
        {
            print("sifre yanlış");
        }
    }

    public void UserSave()
    {
        StartCoroutine(UserSaveDB());
    }

    IEnumerator UserSaveDB()
    {
        data = "read";
        WWWForm form1 = new WWWForm();
        form1.AddField("GameID", PlayerPrefs.GetString("GameID"));
        form1.AddField("UserSave", data);
        WWW connector = new WWW(url, form1);
        yield return connector;
        Debug.Log("Log " + connector.text);
        
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
        if (userList == "")
        {
            userList = userName.text;
        }
        else
        {
            userList = userList + "," + userName.text;
        }

        string[] names = userList.Split(',');
        int myIndex = Array.IndexOf(names, userName.text);
        print("Ben kaçıncıyım " +myIndex);
        PlayerPrefs.SetInt("MyIndex",myIndex);

        PlayerPrefs.SetString("MyUserName", userName.text);
        StartCoroutine(UsernameUpdate());
    }
    IEnumerator UsernameUpdate()
    {
        data = "write";
        WWWForm form1 = new WWWForm();
        form1.AddField("GameID", PlayerPrefs.GetString("GameID"));
        form1.AddField("UserNames", userList);
        form1.AddField("Users", data);
        WWW connector = new WWW(url, form1);
        yield return connector;
        Debug.Log("Log " + connector.text);
        loading.SetActive(true);
        lobby.SetActive(false);
        //StartCoroutine(UserReady());
    }
    public void Score()
    {
        StartCoroutine(ScoreUpdate());
    }

    IEnumerator ScoreUpdate()
    {
        string userScore = PlayerPrefs.GetFloat("Score").ToString();
        data = "write";
        WWWForm form1 = new WWWForm();
        form1.AddField("GameID", PlayerPrefs.GetString("GameID"));

        switch (PlayerPrefs.GetInt("MyIndex"))
        {
            case 0:
                form1.AddField("UserScore", userScore);
                form1.AddField("Score1", data); 
                break;
            case 1:
                form1.AddField("User2Score", userScore);
                form1.AddField("Score2", data);
                yield return new WaitForSeconds(0.1f);
                break;
            case 2:
                form1.AddField("User3Score", userScore);
                form1.AddField("Score3", data);
                yield return new WaitForSeconds(0.2f);
                break;
            case 3:
                form1.AddField("User4Score", userScore);
                form1.AddField("Score4", data);
                yield return new WaitForSeconds(0.3f);
                break;
            default:
                Console.WriteLine("Error");
                break;
        }
        WWW connector = new WWW(url, form1);
        yield return connector;
        Debug.Log("Log " + connector.text);
    }

    public void GoToMenu()
    {
        Application.LoadLevel(0);
    }



}
