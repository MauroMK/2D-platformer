using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{

    private Rigidbody2D rig;
    private Animator anim;

    public float speed;
    private float impactUpForce = 10f;
    private float transformSpeed = -1f;

    public Transform rightCol;
    public Transform leftCol;
    public Transform headPoint;

    private bool colliding;

    public LayerMask layer;

    public BoxCollider2D boxCollider2D;
    public CircleCollider2D circleCollider2D;
    // as duas variaveis a cima são declaradas, porém nao são referenciadas no start, 
    // pois é feito isso no próprio inspector na unity, apenas arrastando elas

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Ele ta passando que no X quer a speed, ou seja, movimentar esquerda e direita,
        // E no Y, ele quer o próprio Y do rig, ou seja, deixar como ta, porque nao quer que se movimente pra cima e pra baixo
        rig.velocity = new Vector2(speed, rig.velocity.y);


        // O Physics.Linecast cria um colisor invisivel em formato de linha em 2 posições na cena (essas sendo rightCol e leftCol)
        colliding = Physics2D.Linecast(rightCol.position, leftCol.position, layer);

        if(colliding)
        {
            // Poe pra ele mudar de posição quando bate na parede, alterando a direção ao deixar negativo
            transform.localScale = new Vector2(transform.localScale.x * transformSpeed, transform.localScale.y);
            speed *= transformSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            // Ta checando se o personagem ta batendo na cabeça do inimigo
            // Ta subtraindo o local que o personagem bateu (Ponto Y) e subtraindo pelo headpoint
            float height = collision.contacts[0].point.y - headPoint.position.y;

            if(height > 0)
            {
                // Da um empulso pro player ao acertar a cabeça do inimigo, o inimigo para a movimentação, ativa a animação,
                // Seta os colisores para falso (pra nao poder acertar ele) 
                //e transforma o tipo do rigidbody dele pra kinematic pra ele nao cair do mapa
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * impactUpForce, ForceMode2D.Impulse);
                speed = 0;
                anim.SetTrigger("hit");
                boxCollider2D.enabled = false;
                circleCollider2D.enabled = false;
                rig.bodyType = RigidbodyType2D.Kinematic;
                Destroy(gameObject, 0.33f);
            }
        }
    }
}
