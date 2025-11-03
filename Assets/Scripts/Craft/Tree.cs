using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private float treeHealth;
    [SerializeField] public Animator anim;
    [SerializeField] private GameObject WoodPrefeb;
    [SerializeField] private int totalWood;




    public void onHit()
    {
         treeHealth--;

        anim.SetTrigger("isHit");

        if (treeHealth <= 0)
        {
            //cria o cotoco de arvore e instancia os drops
            for (int i = 0; i < totalWood; i++)
            {
                Instantiate(WoodPrefeb, transform.position + new Vector3(Random.Range(-0.5f, 0.5f), 0f, 0f), transform.rotation);
            }
            anim.SetTrigger("cut");
        }
    }

    private void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.CompareTag("Axe"))
        {
            onHit();
            Debug.Log("Objeto em rota de colisao");
        }
    }


}


