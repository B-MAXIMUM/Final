using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Gamemanager : MonoBehaviour
{
    // Start is called before the first frame update
    public static Gamemanager Instance;
    public GameObject Mainmenue;
    public GameObject Paused;
    public GameObject gameUi;
    public GameObject gameoverpannel;
    public GameObject HelpPanel;
    public GameObject winner;
    public Slider Health;
    [SerializeField] private int MaxHP;
    [SerializeField] private int CurrentHp;
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Time.timeScale = 0;
        Health.maxValue = MaxHP;
        
    }

    // Update is called once per frame
    void Update()
    {
        Health.value = CurrentHp;
    }
    public void playbutton()
    {
        Time.timeScale = 1;
        gameUi.gameObject.SetActive(true);
        Mainmenue.gameObject.SetActive(false);
        enemy.enemyS.activate();
    }
    public void pausebutton()
    {
        Time.timeScale = 0;
        Paused.gameObject.SetActive(true);
        gameUi.gameObject.SetActive(false);
    }
    public void restartbutton()
    {
        SceneManager.LoadScene(0);
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
        gameoverpannel.gameObject.SetActive(true);
        gameUi.gameObject.SetActive(false);
    }
    public void help()
    {
        Mainmenue.gameObject.SetActive(false);
        HelpPanel.gameObject.SetActive(true);
    }
    public void win()
    {
        Time.timeScale = 0;
        winner.gameObject.SetActive(true);
        gameUi.gameObject.SetActive(false);
    }
    public void looseHpOrDeath()
    {
        if(CurrentHp > 1)
        {
            CurrentHp = CurrentHp - 1;
        }
        else
        {
            gameover();
        }
    }
    public void GainHp()
    {
        if (CurrentHp < MaxHP)
        {
            CurrentHp = CurrentHp + 1;
        }
    }
}
