using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
   
    private SpriteRenderer sr;
    private CircleCollider2D circle;

    public GameObject collected;

    public int score;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
    }

    // On trigger enter, pq no collider da cherrie ta com a opção IS TRIGGER, se nao seria On collision
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            // Desativa a cherrie da tela, ativa o efeito de coletado, adiciona pontos ao score e destrói a cherrie
            sr.enabled = false;
            circle.enabled = false;
            collected.SetActive(true);

            // Variável vinda do script GameController
            GameController.instance.totalScore += score;
            GameController.instance.UpdateScoreText();
            
            Destroy(gameObject, 0.4f);
        }
    }
}
