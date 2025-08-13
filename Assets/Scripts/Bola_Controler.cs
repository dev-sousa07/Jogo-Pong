using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola_Controller : MonoBehaviour
{
    //Criando a variável para saber quem é o rigdbody da bola
    public Rigidbody2D rb;
    private Vector2 minhaVelocidade;
    public float velocidade = 5f;
    public float direcao;
    // Start is called before the first frame update
    void Start()
    {
        minhaVelocidade.x = velocidade;
        minhaVelocidade.y = velocidade;
        int direcao = Random.Range(0,4);

        //Valor aleatório
        if (direcao == 0) 
        {
        
            minhaVelocidade.x = velocidade;
            minhaVelocidade.y = velocidade;
        }
        else if (direcao == 1)
        {
            minhaVelocidade.x = -velocidade;
            minhaVelocidade.y =  velocidade;
        }
        else if(direcao == 2)
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
