using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{

    public float dialogueRange;
    public LayerMask playerLayer;
    public DialogueSettings dialogue;
    bool playerHit;
    private List<string> Sentences = new List<string>();



    // Start is called before the first frame update
    public void Start()
    {
         GetNPCInfo();
    }

    void Update()
    {
        if (Input.GetKeyDown("e") && playerHit)
        {
            DialogueControl.instance.Speech(Sentences.ToArray());
        }
        else 
        {
            
        }
    }

    void GetNPCInfo()
    {
     for (int i = 0; i < dialogue.dialogues.Count; i++)

     {
        switch (DialogueControl.instance.language)
        {

            case DialogueControl.idiom.pt:
                Sentences.Add(dialogue.dialogues[i].sentence.portuguese);
                break;

                case DialogueControl.idiom.eng:
                    Sentences.Add(dialogue.dialogues[i].sentence.english);
                    break;
                    
                        case DialogueControl.idiom.span:
                        Sentences.Add(dialogue.dialogues[i].sentence.espanish);
                        break;
                    
        }
     }   
    }

    // será usado pela fisica
    void FixedUpdate()
    {
        ShowDialogue();
    }


    void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);
        if (hit != null)
        {
            Debug.Log("Player na area de colisao");
            playerHit = true;

        }
        else
        {
            playerHit = false;
        }

    }
    private void OnDrawGizmosSelected()

    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }



}
