using UnityEngine;
using UnityEngine.SceneManagement;

public class Jogar : MonoBehaviour
{
    public string nomeCena = "Jogo"; // Nome da cena que será carregada

    // Função pública que será chamada pelo botão
    public void CarregarCena()
    {
        SceneManager.LoadScene(nomeCena);
    }
}
