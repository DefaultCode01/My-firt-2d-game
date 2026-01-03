using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float speed;
    private float inicialSpeed;
    private int index;
    private Animator anim;
    public List<Transform> paths = new List<Transform>();



    void Start()
    {
        inicialSpeed = speed;

        anim = GetComponent<Animator>();
    }


    void Update()
    {  if (DialogueControl.instance.isShowing)
        {
            speed = 0f;
            anim.SetBool("isWalking", false);
        }
        else
        {
            speed = inicialSpeed;
             anim.SetBool("isWalking", true);
        }
            transform.position = Vector2.MoveTowards(transform.position, paths[index].position, speed * Time.deltaTime);    // retorna um vector2 x e y para uma determinada direção
            if (Vector2.Distance(transform.position, paths[index].position) <= 0.1) // subtração da posição do objeto(NPC) menos a posição do alvo (Path)
            {
            if (index < paths.Count - 1)
            {
                //index++; vai sempre pro proximo
                index = Random.Range(0, paths.Count-1);
                }
            else
            {
                index = 0;
            }
            }


            Vector2 direction = paths[index].position - transform.position;
            if (direction.x > 0)
            {
                transform.eulerAngles = new Vector2(0, 0); // euLerAngles e de rotação, se for pra direita a rotação é 0
            }
            if (direction.x < 0)
            {
                transform.eulerAngles = new Vector2(0, 180);  // euLerAngles e de rotação, se for para a esquerda a rotação é 180
            }
            
            

    

            }
}
