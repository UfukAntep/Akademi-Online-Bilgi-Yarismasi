using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public float currentTime = 15;
    public GameObject[] questions, answers;
    public GameObject screenLock, answerTrue, answerFalse;
    float score;

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
                for (int i = 0; i < questions.Length; i++)
                {
                    if (questions[i].activeSelf == true && questions[questions.Length - 1].activeSelf != true)
                    {
                        screenLock.SetActive(true);
                        StartCoroutine(Coroutine(i));
                        break;
                    }

                    if (questions[questions.Length - 1].activeSelf == true)
                    {
                        Application.LoadLevel(3);
                        break;
                    }

                }
            }

        }
    }

    IEnumerator Coroutine(int i)
    {
        yield return new WaitForSeconds(3);
        screenLock.SetActive(false);
        answerFalse.SetActive(false);
        answerTrue.SetActive(false);
        questions[i].SetActive(false);
        questions[i + 1].SetActive(true);
        currentTime = 15;
    }
    public void Clicked(int answer)
    {
        screenLock.SetActive(true);

        if (answer == 0)
        {
            answerFalse.SetActive(true);
            answerTrue.SetActive(false);
        }
        else
        {
            answerFalse.SetActive(false);
            answerTrue.SetActive(true);
            score = score + (int.Parse(currentTime.ToString("f0")) * 15);
            PlayerPrefs.SetFloat("Score", score);
        }
    }

}
