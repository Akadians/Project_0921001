using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject PausedPanel;
    public GameObject EndPanel;
    public GameObject StartPanel;

    public AudioSource BGM;
    public SoundController AudioMix;
    // Start is called before the first frame update
    void Start()
    {
        Implements();
    }

    // Update is called once per frame
    void Update()
    {
        PauseGame();        
    }

    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1)
        {
            Time.timeScale = 0;
            PausedPanel.SetActive(true);
            return;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0)
        {
            Time.timeScale = 1;
            PausedPanel.SetActive(false);
            return;
        }
    }
    public void EndGame ()
    {
        Time.timeScale = 0;
        BGM.Stop();
        EndPanel.SetActive(true); 
    }
    public void UnpauseGame()
    {
        Time.timeScale = 1;
        PausedPanel.SetActive(false);
        return;
    }
    public void StartGame()
    {
        StartPanel.SetActive(false);
        Time.timeScale = 1;
        BGM.Play();
    }
    private void Implements ()
    {
        instance = this;
        Time.timeScale = 0;
    }
}
