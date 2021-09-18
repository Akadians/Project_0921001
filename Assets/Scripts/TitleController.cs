using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{    
    public AudioClip Click;
    public List<int> BestScore;
    public TextMeshProUGUI[] Board;

    // Start is called before the first frame update
    void Start()
    {
        Implements();
        BoardData();
    }
    private void Implements()
    {
        BestScore[0] = PlayerPrefs.GetInt("primeiroLugar");
        BestScore[1] = PlayerPrefs.GetInt("segundoLugar");
        BestScore[2] = PlayerPrefs.GetInt("terceiroLugar");
    }
    private void BoardData ()
    {
        Board[0].text = BestScore[0].ToString();
        Board[1].text = BestScore[1].ToString();
        Board[2].text = BestScore[2].ToString();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("PlayableGame");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void ClickButton()
    {
        SoundController.instance.PlayOneShot(Click);
    }
}
