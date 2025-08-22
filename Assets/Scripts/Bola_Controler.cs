using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bola_Controller : MonoBehaviour
{
    // Rigidbody da bola
    public Rigidbody2D rb;

    private Vector2 minhaVelocidade;

    public float velocidade = 5f;
    public float limiteHorizontal = 11f;

    public AudioClip boing;
    public new Transform camera;

    public float delayInicio = 2f;
    public bool jogoIniciado = false;

    public string GameOver;

    void Start()
    {
        // reseta valores iniciais
        minhaVelocidade = Vector2.zero;
    }

    void Update()
    {
        // Decrementa o delay antes do jogo começar
        delayInicio -= Time.deltaTime;

        // verifica se pode iniciar o jogo
        if (VerificaInicioDeJogo())
        {
            jogoIniciado = true;
            int direcao = Random.Range(0, 4);

            // inicia a movimentação da bola de acordo com a direção sorteada
            minhaVelocidade = IniciaMovimentaBola(direcao);
            rb.velocity = minhaVelocidade;
        }

        // Verifica se saiu da tela
        if (transform.position.x > limiteHorizontal || transform.position.x < -limiteHorizontal)
        {
            SceneManager.LoadScene(GameOver);
        }
    }

    // ----------------------------
    // Método que verifica se o jogo pode começar
    // ----------------------------
    public bool VerificaInicioDeJogo()
    {
        return delayInicio <= 0 && jogoIniciado == false;
    }

    // ----------------------------
    // Método que define a velocidade inicial da bola
    // ----------------------------
    public Vector2 IniciaMovimentaBola(int direcao)
    {
        switch (direcao)
        {
            case 0: return new Vector2(velocidade, velocidade);   // direita-cima
            case 1: return new Vector2(-velocidade, velocidade);  // esquerda-cima
            case 2: return new Vector2(velocidade, -velocidade);  // direita-baixo
            default: return new Vector2(-velocidade, -velocidade); // esquerda-baixo
        }
    }

    // ----------------------------
    // Efeito de colisão com som
    // ----------------------------
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(boing, camera.position);
    }
}
