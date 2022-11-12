using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] GameManager gameManager;
    [SerializeField] Tilemap tl;
    private Vector2 movement;
    private BoxCollider2D door;
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            door = GameObject.Find("Door").GetComponent<BoxCollider2D>();
            if (rb.IsTouching(door) && gameManager.GetDoorStatus())
            {
                gameManager.NextLevel();
            }
        }
        // --------- This code allows to get the name of the clicked tile ---------
        //if (Input.GetKeyDown(KeyCode.Mouse0))
        //{
        //    Vector3Int tilemapPos = tl.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        //    Tile tile = tl.GetTile<Tile>(tilemapPos);
        //    if (tile.name == "Dungeon_Tileset_38")
        //    {
        //        Debug.Log("It is");
        //    }
        //    Debug.Log(tile);
        //}
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
