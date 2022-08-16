using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    
    public int totalScore;

    public Text textScore;

    public GameObject gameOver;

    public static GameController instance;

    // Criada uma variavel GameController chamada de instance, que no start recebe this, ou seja, o próprio script
    // Entao sendo chamada de outro script, pode ser acessado tudo dentro desse que não seja private
    void Start()
    {
        instance = this;
    }

    public void UpdateScoreText()
    {
        textScore.text = totalScore.ToString();
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
