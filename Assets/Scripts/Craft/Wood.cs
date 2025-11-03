using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float timeMove;

    private float timeCount;
    // Start is called before the first frame update
    void Start()
    {
        timeCount += Time.deltaTime;
        if(timeCount < timeMove)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.CompareTag("Player"))
        {
            collison.GetComponent<PlayerItens>().Totalwood++;
            Destroy(gameObject);
        }
    }
}
