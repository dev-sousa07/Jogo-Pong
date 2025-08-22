using NUnit.Framework;
using UnityEngine;

public class RaqueteControllerTests
{
    private GameObject go;
    private RaqueteController raquete;

    [SetUp]
    public void Setup()
    {
        // Cria GameObject e adiciona RaqueteController
        go = new GameObject();
        raquete = go.AddComponent<RaqueteController>();

        // Inicializa posição e limite
        raquete.minhapos = Vector3.zero;
        raquete.meuEixoy = 0f;
        raquete.meuLimite = 3.5f;
    }

    [TearDown]
    public void Teardown()
    {
        // Limpa após cada teste
        GameObject.DestroyImmediate(go);
    }

    [Test]
    public void AplicarLimite_DeveRespeitarValorMaximo()
    {
        raquete.meuEixoy = 10f;
        raquete.AplicarLimite();

        Assert.AreEqual(3.5f, raquete.meuEixoy);
    }

    [Test]
    public void AtualizarPosicao_DeveMoverTransformCorretamente()
    {
        raquete.meuEixoy = 2f;
        raquete.AtualizarPosicao();

        Assert.AreEqual(2f, raquete.transform.position.y);
    }

    [Test]
    public void ProcessarEntradaAutomatica_DeveAproximarDaBola()
    {
        var bola = new GameObject();
        raquete.bolaTransform = bola.transform;
        raquete.meuEixoy = 0f;
        raquete.automatico = true;

        bola.transform.position = new Vector3(0, 5f, 0);

        raquete.ProcessarEntradaAutomatica();

        // Deve se aproximar da posição da bola sem saltar direto
        Assert.Greater(raquete.meuEixoy, 0f);
        Assert.Less(raquete.meuEixoy, 5f);

        GameObject.DestroyImmediate(bola);
    }
}
