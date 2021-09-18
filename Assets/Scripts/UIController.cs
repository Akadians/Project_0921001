using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public float Timer = -60;
    public Slider TimeSlider;
    public TextMeshProUGUI[] TextAtualScore;
    public TextMeshProUGUI[] TextBestScore;
    public int ScoreAtual = 0;
    public List<int> BestScore;
    public SoundController SoundMix;

    // Start is called before the first frame update
    void Start()
    {
        Implements();
    }

    // Update is called once per frame
    void Update()
    {
        TimeCounter();
        EndGame();
        ScoreUpdate();
    }

    public float TimeCounter()
    {
        TimeSlider.value = Timer;
        return (Timer += Time.deltaTime);
    }
    private void EndGame()
    {
        if (Timer >= 0)
        {
            GameController.instance.EndGame();
        }
        return;
    }
    public void ScoreAdd(int score = 10)
    {
        ScoreAtual += score;
        Timer -= 5;
        SoundMix.RightDelivery();
        return;
    }
    public void ScoreLess()
    {
        Timer += 5;
        SoundMix.WrongDelivery();
        return;
    }
    public void ScoreUpdate()
    {
        TextAtualScore[0].text = ScoreAtual.ToString();
        TextAtualScore[1].text = ScoreAtual.ToString();
        TextBestScore[0].text = BestScore[0].ToString();

        if (BestScore[0] < ScoreAtual)
        {
            TextBestScore[0].text = ScoreAtual.ToString();
        }

        LeaderBoard();
    }
    private void Implements()
    {
        BestScore[0] = PlayerPrefs.GetInt("primeiroLugar");
        BestScore[1] = PlayerPrefs.GetInt("segundoLugar");
        BestScore[2] = PlayerPrefs.GetInt("terceiroLugar");
    }
    private void LeaderBoard()
    {
        if (ScoreAtual > BestScore[0])
        {
            BestScore[0] = ScoreAtual;
            PlayerPrefs.SetInt("primeiroLugar", ScoreAtual);
            return;
        }
        else if (BestScore[0] >= ScoreAtual && ScoreAtual > BestScore[1] && ScoreAtual < BestScore[0])
        {
            BestScore[2] = BestScore[1];
            BestScore[1] = ScoreAtual;
            PlayerPrefs.SetInt("segundoLugar", ScoreAtual);
            return;
        }
        else if (BestScore[1] >= ScoreAtual && ScoreAtual > BestScore[2] && ScoreAtual < BestScore[1])
        {
            BestScore[2] = ScoreAtual;
            PlayerPrefs.SetInt("terceiroLugar", ScoreAtual);
        }

        TextBestScore[1].text = BestScore[0].ToString();
        TextBestScore[2].text = BestScore[1].ToString();
        TextBestScore[3].text = BestScore[2].ToString();

    }

    public void BackMenu()
    {
        SceneManager.LoadScene("Title");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("PlayableGame");
    }
}
