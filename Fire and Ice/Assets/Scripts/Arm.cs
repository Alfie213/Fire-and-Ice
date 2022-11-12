using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Arm : MonoBehaviour
{
    private Transform left;
    private Transform right;
    private bool incline; // false - incline right, true - incline left
    void Start()
    {
        left = gameObject.GetComponentsInChildren<Transform>()[1];
        right = gameObject.GetComponentsInChildren<Transform>()[2];
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!incline & (Vector3.Distance(collision.transform.position, left.position) > Vector3.Distance(collision.transform.position, right.position)))
            {
                gameObject.GetComponent<Rigidbody2D>().MovePosition(gameObject.transform.position - new Vector3(0.15f, 0, 0));
                gameObject.GetComponent<Rigidbody2D>().MoveRotation(45f);
                incline = !incline;
                // Ну и тут по необходимости добавить логику толкания стен
            }
            else if (incline & (Vector3.Distance(collision.transform.position, left.position) < Vector3.Distance(collision.transform.position, right.position)))
            {
                gameObject.GetComponent<Rigidbody2D>().MovePosition(gameObject.transform.position + new Vector3(0.15f, 0, 0));
                gameObject.GetComponent<Rigidbody2D>().MoveRotation(-45f);
                incline = !incline;
            }
        }
    }
}
