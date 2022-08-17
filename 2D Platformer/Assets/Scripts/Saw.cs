using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    
    public float speed;
    public float moveTime;
    private float timer;

    private bool dirRight = true;
    
    void Update()
    {
        if(dirRight)
        {
            // Se verdadeiro -> direita
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            //Se falso -> esquerda
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        timer += Time.deltaTime;
        if(timer >= moveTime)
        {
            dirRight = !dirRight;
            timer = 0f;
        }
    }
}
