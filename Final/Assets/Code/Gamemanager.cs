using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Mainmenue;
    public GameObject Paused;
    public GameObject gameUi;
    public GameObject gameoverpannel;
    public GameObject HelpPanel;


    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playbutton()
    {
        Time.timeScale = 1;
    }
    public void pausebutton()
    {
        Time.timeScale = 0;
        Paused.gameObject.SetActive(true);
        gameUi.gameObject.SetActive(false);
    }
    public void restartbutton()
    {
        SceneManager.LoadScene("0");
    }
    public void quitbutton()
    {
        
    }
    public void Resumebutton()
    {
        Time.timeScale = 1;
        Paused.gameObject.SetActive(false);
        gameUi.gameObject.SetActive(true);
    }
    public void gameover()
    {
        Time.timeScale = 0;
    }
    public void help()
    {

    }
}
