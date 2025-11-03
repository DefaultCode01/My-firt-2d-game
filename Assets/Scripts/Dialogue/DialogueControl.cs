using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{   [System.Serializable]
    public enum idiom
    {
        pt,
        eng,
        span
    }
    public  idiom language;




    [Header("Components")]
    public GameObject dialogueObj;// janela do dialogo
    public Image profileSprit;// sprite do perfil   
    public Text speechText;// texto da fala
    public Text actorNameText; //nome do npc
    [Header("Settings")]
    public float typingSpeed;//velocidade da fala


    //variaveis de controle
    [HideInInspector] public bool isShowing; // Se a janela esta visivel
    private int index; // rodar durante laço de repetição{usar pra contar quantas palavras vai ter em cada texto ou sentença}
    private String[] sentences;
    public static DialogueControl instance; // permite acessar qualquer variavel ou metodo publico nessa classe
    //awake e chamado antes de todos os starts() na hierarquia de execução dde scripts
    private void Awake()
    {
        instance = this;
    }


    //chamado ao inicializar
    void Start()
    {
        
    }
       

    void Update()
    {

    }

    IEnumerator TypeSentence()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    //proxima frase
    public void NextSentence()
    {
        if (speechText.text == sentences[index])
        {
            if (index < sentences.Length - 1)
            {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else// quando terminar os textos
            {
                speechText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
                sentences = null;
                 isShowing = false;
            }
        }
    }
    //chamar a fala do npc  
    public void Speech(string[] text)
    {
        if (!isShowing)
        {
            dialogueObj.SetActive(true);
            sentences = text;
        }
        StartCoroutine(TypeSentence());
        isShowing = true;
    
    }

}
