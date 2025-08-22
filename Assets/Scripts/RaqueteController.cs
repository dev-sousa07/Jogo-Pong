using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaqueteController : MonoBehaviour
{
    public Transform bolaTransform;   // Atribua a bola no Inspector
    public bool automatico = false;   // Ativa IA automaticamente
    public bool player1 = false;      // Identifica o Player 1
    public float velocidade = 5f;     // Velocidade de movimento da raquete
    public float meuLimite = 3.5f;    // Limite vertical da raquete

    public Vector3 minhapos;
    public float meuEixoy;

    void Start()
    {
        minhapos = transform.position;
        meuEixoy = minhapos.y;
        // Ativa IA automaticamente para Player 2
        if (!player1) automatico = true;
    }

    void Update()
    {
        float deltaVelocidade = velocidade * Time.deltaTime;

        if (!automatico)
            ProcessarEntradaManual(deltaVelocidade);
        else
            ProcessarEntradaAutomatica();

        AplicarLimite();
        AtualizarPosicao();
    }

    private void ProcessarEntradaManual(float delta)
    {
        if (player1)
            EntradaPlayer1(delta);
        else
            EntradaPlayer2(delta);
    }

    private void EntradaPlayer1(float delta)
    {
        if (Input.GetKey(KeyCode.W))
            meuEixoy += delta;
        if (Input.GetKey(KeyCode.S))
            meuEixoy -= delta;
    }

    private void EntradaPlayer2(float delta)
    {
        // Alterna manual/automático com Enter
        if (Input.GetKeyDown(KeyCode.Return))
            automatico = !automatico;

        if (Input.GetKey(KeyCode.UpArrow))
            meuEixoy += delta;
        if (Input.GetKey(KeyCode.DownArrow))
            meuEixoy -= delta;
    }

    public void ProcessarEntradaAutomatica()
    {
        if (bolaTransform == null) return;

        // Se o jogador usar as setas, desliga IA
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            automatico = false;
            return;
        }

        // Move suavemente a raquete em direção à bola
        meuEixoy = Mathf.Lerp(meuEixoy, bolaTransform.position.y, 0.12f);
    }

    public void AplicarLimite()
    {
        meuEixoy = Mathf.Clamp(meuEixoy, -meuLimite, meuLimite);
    }

    public void AtualizarPosicao()
    {
        minhapos.y = meuEixoy;
        transform.position = minhapos;
    }
}
