using NUnit.Framework;
using UnityEngine;

public class RaqueteTests
{
    private GameObject go;
    private RaqueteController raquete;
    private GameObject bola;

    [SetUp]
    public void Setup()
    {
        go = new GameObject();
        raquete = go.AddComponent<RaqueteController>();
    }

    [Test]
    public void AplicarLimite_DeveRespeitarValorMaximo()
    {
        raquete.meuLimite = 3.5f;
        raquete.meuEixoy = 10f;

        raquete.AplicarLimite();

        Assert.AreEqual(3.5f, raquete.meuEixoy);
    }

    [Test]
    public void AtualizarPosicao()
    {
        raquete.meuEixoy = 2.5f;
        raquete.minhapos = new Vector3(0, 0, 0);

        raquete.AtualizarPosicao();

        Assert.AreEqual(2.5f, raquete.transform.position.y);
    }

    [Test]
    public void ProcessarEntradaAutomatica()
    {
        raquete.bolaTransform = bola.transform;

        raquete.meuEixoy = 0f;
        raquete.automatico = true;

        // Simula a posição da bola
        bola.transform.position = new Vector3(0, 5f, 0);

        // Executa o método da IA
        raquete.ProcessarEntradaAutomatica();
        Assert.IsTrue(raquete.automatico);

        // Verifica se a raquete se aproximou da bola
        Assert.Greater(raquete.meuEixoy, 0f);
        Assert.Less(raquete.meuEixoy, 5f); // não deve saltar direto


    }


    [TearDown]
    public void Teardown()
    {
        GameObject.DestroyImmediate(go);
        GameObject.DestroyImmediate(bola);
    }
}
