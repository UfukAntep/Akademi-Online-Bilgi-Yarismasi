using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    private float currentTime = 15;
    public Text countdownText;
    public GameObject[] questions;
    public Image[] answers;
    public GameObject tickSound;
    public loadingtext loadingtext;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                print("süre bitti");
                for (int i=0; i<questions.Length; i++)
                {
                    if (questions[i].activeSelf == true && questions[questions.Length-1].activeSelf != true)
                    {
                        answers[i].enabled = true;
                        loadingtext.enabled = false;
                        StartCoroutine(Coroutine(i));
                        break;
                    }
                    if (questions[questions.Length-1].activeSelf == true)
                    {
                        Application.LoadLevel(3);
                    }
                }
            }

            if (currentTime <= 5)
            {
                tickSound.SetActive(true);
            }
            else
            {
                tickSound.SetActive(false);
            }

            UpdateCountdownText();
        }
        
    }

    IEnumerator Coroutine(int i)
    {
        yield return new WaitForSeconds(3);
        questions[i].SetActive(false);
        questions[i + 1].SetActive(true);
        currentTime = 15;
        loadingtext.enabled = true;
    }

    void UpdateCountdownText()
    {
        countdownText.text = "" + Mathf.RoundToInt(currentTime);
    }
}
