using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BolaController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 minhaVelocidade;
    public float velocidade = 5f;
    public float limiteHorizontal = 11f;
    public AudioClip boing;
    public new Transform camera;
    public float delayInicio = 2f;
    public bool jogoIniciado = false;
    public string GameOver;

    void Update()
    {
        delayInicio -= Time.deltaTime;

        if (VerificaInicioDeJogo())
        {
            jogoIniciado = true;
            int direcao = Random.Range(0, 4);
            minhaVelocidade = IniciaMovimentaBola(direcao);
            rb.velocity = minhaVelocidade;
        }

        if (transform.position.x > limiteHorizontal || transform.position.x < -limiteHorizontal)
        {
            SceneManager.LoadScene(GameOver);
        }
    }

    public bool VerificaInicioDeJogo()
    {
        return delayInicio <= 0 && !jogoIniciado;
    }

    public Vector2 IniciaMovimentaBola(int direcao)
    {
        switch (direcao)
        {
            case 0:
                return new Vector2(velocidade, velocidade);
            case 1:
                return new Vector2(-velocidade, velocidade);
            case 2:
                return new Vector2(velocidade, -velocidade);
            default:
                return new Vector2(-velocidade, -velocidade);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(boing, camera.position);
    }
}
