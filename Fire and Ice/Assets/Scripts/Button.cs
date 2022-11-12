using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Button : MonoBehaviour
{
    [SerializeField] SpriteRenderer sr;
    [SerializeField] GameManager gameManager;
    private int countOfGuests;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Obstacle"))
        {
            countOfGuests += 1;
            if (countOfGuests == 1)
            {
                gameObject.GetComponent<Rigidbody2D>().MovePosition(new Vector2(transform.position.x, transform.position.y - 0.04f));
                sr.sprite = Resources.Load<Sprite>("door_opened");
                gameManager.ChangeDoorStatus(true);
            }
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Obstacle"))
        {
            countOfGuests -= 1;
            if (countOfGuests == 0)
            {
                gameObject.GetComponent<Rigidbody2D>().MovePosition(new Vector2(transform.position.x, transform.position.y + 0.04f));
                sr.sprite = Resources.Load<Sprite>("door_closed");
                gameManager.ChangeDoorStatus(false);
            }
        }
    }
    // Далее была идея "свернуть" код выше, но в итоге код станет менее читабельным.
    //private void changeState(Collider2D collision, bool exit) // exit: true - yes, false - no
    //{
    //    if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Obstacle"))
    //    {
    //        if (exit) countOfGuests -= 1;
    //        else countOfGuests += 1;
    //        if (countOfGuests == 1)
    //        {
    //            gameObject.GetComponent<Rigidbody2D>().MovePosition(new Vector2(transform.position.x, transform.position.y - 0.04f));
    //            sr.sprite = Resources.Load<Sprite>("door_opened");
    //            gameManager.ChangeDoorStatus(true);
    //        }
    //        else if (countOfGuests == 0)
    //        {
    //            gameObject.GetComponent<Rigidbody2D>().MovePosition(new Vector2(transform.position.x, transform.position.y + 0.04f));
    //            sr.sprite = Resources.Load<Sprite>("door_closed");
    //            gameManager.ChangeDoorStatus(false);
    //        }
    //    }
    //}
}
