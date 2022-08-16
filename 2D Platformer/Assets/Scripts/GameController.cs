using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    
    public int totalScore;

    public Text textScore;

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

}
