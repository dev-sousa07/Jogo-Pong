using UnityEngine;
using UnityEngine.SceneManagement;

public class Jogar : MonoBehaviour
{
    public string nomeCena = "Jogo"; // Nome da cena que ser� carregada

    // Fun��o p�blica que ser� chamada pelo bot�o
    public void CarregarCena()
    {
        SceneManager.LoadScene(nomeCena);
    }
}
