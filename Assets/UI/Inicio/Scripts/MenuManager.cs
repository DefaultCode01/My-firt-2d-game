using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // INICIAR JOGO
    public void IniciarJogo()
    {
        SceneManager.LoadScene("GameScene");
    }  

   public void CreditosDoJogo()
    {
        SceneManager.LoadScene("Creditos");
    }  
    // SAIR DO JOGO
    public void SairJogo()
    {
        Application.Quit();

    }
}
