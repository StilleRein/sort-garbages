using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainSceneController : MonoBehaviour
{
    GameObject exitPanel;
    // Start is called before the first frame update
    void Start()
    {
        exitPanel = GameObject.Find("Panel Exit");
        exitPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ExitGame()
    {
        exitPanel.SetActive(true);
    }

    public void ExitGameConfirmation(Button button)
    {
        if (button.name.Equals("Button Yes"))
        {
            Application.Quit();
        }

        else if(button.name.Equals("Button No"))
        {
            exitPanel.SetActive(false);
        }
    }
}
