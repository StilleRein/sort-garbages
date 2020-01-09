using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSceneController : MonoBehaviour
{
    GameObject countdownPanel, gameOverPanel;
    Text countdownTxt, finalScoreTxt;
    public static bool isGamePlaying;
    public GameObject[] trashBins;
    bool isNewGame;
    public int level = 0;


    // Start is called before the first frame update
    void Start()
    {
        countdownTxt = GameObject.Find("Text Countdown").GetComponent<Text>();
        countdownPanel = GameObject.Find("Panel Countdown");

        finalScoreTxt = GameObject.Find("Text Final Score").GetComponent<Text>();
        gameOverPanel = GameObject.Find("Panel Game Over");
        gameOverPanel.SetActive(false);

        StartCoroutine(GameCountdown(3));
    }

    // Update is called once per frame
    void Update()
    {
        //check if player already lost 3 hearth, gameover
        if(Data.countHit == 3)
        {
            isGamePlaying = false;
            gameOver();
        }

        //timer to increase speed of GarbageMovement
        Data.gameTimer += Time.deltaTime;
    }

    IEnumerator GameCountdown(int seconds)
    {
        int time = seconds;

        //display 3, 2, 1 count down
        while (time > 0)
        {
            countdownTxt.text = Mathf.Round(time) + "";

            yield return new WaitForSeconds(1);
            time--;
        }

        //display Start text
        while (time > -1)
        {
            countdownTxt.text = "Let's Sort!";

            yield return new WaitForSeconds(1);
            time--;
        }

        //hide countdown panel and start the game
        while (time > -2)
        {
            countdownPanel.SetActive(false);
            isGamePlaying = true;
            yield return new WaitForSeconds(1);
            time--;
        }
    }

    void gameOver()
    {
        finalScoreTxt.text = "Score: " + Data.score;
        gameOverPanel.SetActive(true);
    }

    public void gameOverAction(Button button)
    {
        Data.score = 0;
        Data.countHit = 0;
        Data.gameTimer = 0f;
        Data.speed = 3f;

        if (button.name.Equals("Button Home"))
        {
            SceneManager.LoadScene("MainScene");
        }

        else if (button.name.Equals("Button Replay"))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
