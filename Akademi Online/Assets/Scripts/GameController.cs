using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject lobby;
    public Text gameID, gamePassword;
    public PhpController phpController;

    void Start()
    {
        gameID.text = "Oda ID: " + PlayerPrefs.GetString("GameID");
        gamePassword.text = "Oda Şifresi: " + PlayerPrefs.GetString("GamePassword");
        InvokeRepeating("UserUpdate", 0f, 3f);
    } 

    void Update()
    {

    }

    public void UserUpdate()
    {
        print("a");
        if (lobby.activeSelf == true)
        {
            phpController.UserUpdate();
        }
    }
   
}
