using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDie : MonoBehaviour
{
    public GameObject dieEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        
        GameObject newDieEffect = Instantiate(dieEffect, gameObject.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Destroy(newDieEffect);
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);

    }
}
