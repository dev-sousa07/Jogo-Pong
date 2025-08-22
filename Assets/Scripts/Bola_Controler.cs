using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bola_Controller : MonoBehaviour
{
    //Criando a vari�vel para saber quem � o rigdbody da bola
    public Rigidbody2D rb;

    private Vector2 minhaVelocidade;

    public float velocidade = 5f;
    public float limiteHorizontal = 11f;

    public AudioClip boing;

    public float delayInicio = 2f;
    public bool jogoIniciado = false;

    public string GameOver;

    void Start()
    {
        // reseta valores iniciais
    }

    void Update()
    {
        //Delay
        delayInicio -= Time.deltaTime;

        // verifica se pode iniciar o jogo
        {
            jogoIniciado = true;
            int direcao = Random.Range(0, 4);

            //Valor aleat�rio
            if (direcao == 0)
            {

                minhaVelocidade.x = velocidade;
                minhaVelocidade.y = velocidade;
            }
            else if (direcao == 1)
            {
                minhaVelocidade.x = -velocidade;
                minhaVelocidade.y = velocidade;
            }
            else if (direcao == 2)
            {
                minhaVelocidade.x = -velocidade;
                minhaVelocidade.y = -velocidade;
            }
            else
            {
                minhaVelocidade.x = velocidade;
                minhaVelocidade.y = -velocidade;
            }
            // Adicionando velocidade para a esquerda
            rb.velocity = minhaVelocidade;
        }
        // Verificando se o jogo j� foi iniciado
        if (transform.position.x > limiteHorizontal || transform.position.x < -limiteHorizontal)
        {
            SceneManager.LoadScene(GameOver);
        }
    }
         // Criando colis�o
        private void OnCollisionEnter2D(Collision2D collision)
        {
        
        AudioSource.PlayClipAtPoint(boing,camera.position );

    }
    
}

