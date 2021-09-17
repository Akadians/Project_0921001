using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class UIController : MonoBehaviour
{
    public float Timer = -60;
    public Slider TimeSlider;
    public TextMeshProUGUI TextAtualScore;
    public TextMeshProUGUI TextBestScore;    
    public int ScoreAtual = 0;
    public List<int> BestScore;
    public SoundController SoundMix;

    public AudioClip RightDelivery;
    
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

    public float TimeCounter ()
    {
        TimeSlider.value = Timer;        
        return (Timer += Time.deltaTime);
    }
    private void EndGame ()
    {
        if(Timer >= 0)
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
        return;
    }
    public void ScoreUpdate ()
    {
        TextAtualScore.text = ScoreAtual.ToString();
        TextBestScore.text = BestScore[0].ToString();
        
        if(BestScore[0] < ScoreAtual)
        {
            TextBestScore.text = ScoreAtual.ToString();
        }
    }
    private void Implements ()
    {               
        BestScore[0] = PlayerPrefs.GetInt("primeiroLugar");
        BestScore[1] = PlayerPrefs.GetInt("segundoLugar");
        BestScore[2] = PlayerPrefs.GetInt("terceiroLugar");        
    }
    private void LeaderBoard ()
    {
        if(ScoreAtual > BestScore[0])
        {
            BestScore[0] = ScoreAtual;
            PlayerPrefs.SetInt("primeiroLugar", ScoreAtual);
            return;
        }
        else if(ScoreAtual <= BestScore[0] && ScoreAtual > BestScore[1])
        {
            BestScore[2] = BestScore[1];
            BestScore[1] = ScoreAtual;
            PlayerPrefs.SetInt("segundoLugar", ScoreAtual);
            return;
        }
        else if(ScoreAtual <= BestScore[1] && ScoreAtual > BestScore[2])
        {
            BestScore[2] = ScoreAtual;
            PlayerPrefs.SetInt("terceiroLugar", ScoreAtual);
        }
    }
}
