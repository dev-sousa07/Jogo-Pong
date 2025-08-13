using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raquete : MonoBehaviour
{
    // Start is called before the first frame update
    // Vector 3
    private Vector3 minhaposicao;
    private float posicaoRaqueteY;
    public float velocidade = 5f;
    public float meuLimite = 3.4f;

    //identificiando o player 1
    public bool player1;

    //Variável para controlar pela IA
    public bool iaControl = false;

    // Posiçao da bola
    public Transform transformBola; 
    void Start()
    {
        //Posição inicial da raquete
        minhaposicao.x = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        // Passando o meu y para o eixo y da minhaPoiação
        minhaposicao.y = posicaoRaqueteY;

        //----------------------------------------------------------------------

        //Modificar a posiçao da raquete
        //transform = individual
        //Transform = Classe, tipo

        transform.position = minhaposicao;

        //----------------------------------------------------------------------

        //Pegando as teclas do teclado
        //Se eu pressionar a tecla para cima ele vai subir ou se eu pressionar a tecla para baixo ele vai descer
        //Player automatico
        if (!iaControl)
        {
            //Controloando o Player 1
            if (player1)
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    //Checar o espaço de movimento
                    posicaoRaqueteY += velocidade * Time.deltaTime;
                    Debug.Log("Subindo");

                }
                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    posicaoRaqueteY -= velocidade * Time.deltaTime;
                    Debug.Log("Descendo");
                }
            }//Controloando o Player 2
            else
            {   //Subindo
                if (Input.GetKey(KeyCode.W))
                {
                    if (posicaoRaqueteY < meuLimite)
                    {
                        posicaoRaqueteY = posicaoRaqueteY + velocidade * Time.deltaTime;
                    }
                    //Descendo
                }
                if (Input.GetKey(KeyCode.S))
                {
                    posicaoRaqueteY = posicaoRaqueteY - velocidade * Time.deltaTime;
                }
            }

           
        }
        // Se a raquete estiver no modo IA
        else
        {
            // Função Math para tranformar o valor em outro lentamente
          posicaoRaqueteY = Mathf.Lerp(posicaoRaqueteY, transformBola.position.y, 0.02f);
        }

        //impedindo que saia por baixo da tela
        if (posicaoRaqueteY < -meuLimite)
        {
            posicaoRaqueteY = -meuLimite;
        }

        //impedindo que saia por cima da tela
        if (posicaoRaqueteY > meuLimite)
        {
            posicaoRaqueteY = meuLimite;
        }
    }
}
