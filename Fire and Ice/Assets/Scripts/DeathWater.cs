using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWater : MonoBehaviour
{
    [SerializeField] float timeToDestroy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject, timeToDestroy);
        }
    }
}
