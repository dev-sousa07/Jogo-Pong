using NUnit.Framework;
using UnityEngine;

public class BolaControllerTests
{
    private BolaController bola;
    private GameObject go;

    [SetUp]
    public void Setup()
    {
        go = new GameObject();
        bola = go.AddComponent<BolaController>();
        bola.velocidade = 5f;
        bola.delayInicio = 0f;
        bola.jogoIniciado = false;

        // Adiciona Rigidbody2D para não dar erro ao setar rb.velocity
        bola.rb = go.AddComponent<Rigidbody2D>();
    }

    [TearDown]
    public void Teardown()
    {
        GameObject.DestroyImmediate(go);
    }

    [Test]
    public void VerificaInicioDeJogo_DeveRetornarTrue_QuandoDelayZeroEJogoNaoIniciado()
    {
        bool resultado = bola.VerificaInicioDeJogo();
        Assert.IsTrue(resultado);
    }

    [Test]
    public void IniciaMovimentaBola_Direcao0_DeveRetornarVelocidadePositiva()
    {
        Vector2 resultado = bola.IniciaMovimentaBola(0);
        Assert.AreEqual(new Vector2(5f, 5f), resultado);
    }

    [Test]
    public void IniciaMovimentaBola_Direcao1_DeveRetornarXNegativoYPositivo()
    {
        Vector2 resultado = bola.IniciaMovimentaBola(1);
        Assert.AreEqual(new Vector2(-5f, 5f), resultado);
    }

    [Test]
    public void IniciaMovimentaBola_Direcao2_DeveRetornarXPositivoYNegativo()
    {
        Vector2 resultado = bola.IniciaMovimentaBola(2);
        Assert.AreEqual(new Vector2(5f, -5f), resultado);
    }

    [Test]
    public void IniciaMovimentaBola_OutraDirecao_DeveRetornarVelocidadeNegativa()
    {
        Vector2 resultado = bola.IniciaMovimentaBola(999);
        Assert.AreEqual(new Vector2(-5f, -5f), resultado);
    }
}
