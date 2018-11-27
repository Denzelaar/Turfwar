using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    public int playerColor;
    public float playerSpeed;
    public float moveVelocityHorizontal, moveVelocityVertical, gridSize;
    public Transform spawn1, spawn2, spawn3, spawn4;
    Image playerImage;
    BoxCollider2D playerCollider;

    // Use this for initialization
    void Start () {
        playerImage = GetComponent<Image>();
        playerCollider = GetComponent<BoxCollider2D>();
        spawn1 = transform.parent.Find("SpawnLU");
        spawn2 = transform.parent.Find("SpawnRU");
        spawn3 = transform.parent.Find("SpawnLD");
        spawn4 = transform.parent.Find("SpawnRD");
    }

    void Init()
    {
        if(playerImage.enabled == false)
        {
            playerImage.enabled = true;
            playerCollider.enabled = true;
        }

        switch (playerColor)
        {
            case 0:
                transform.position = spawn1.position;
                return;
            case 1:
                transform.position = spawn2.position;
                return;
            case 2:
                transform.position = spawn3.position;
                return;
            case 3:
                transform.position = spawn4.position;
                return;
        }
    }
	
	// Update is called once per frame
	void Update () {

         moveVelocityHorizontal = moveVelocityHorizontal - (moveVelocityHorizontal * 0.1f);
         moveVelocityVertical = moveVelocityVertical - (moveVelocityVertical * 0.1f);

       /* if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.I))
        {
            float differencePlayerToNextBlock = (transform.position.y + 10) % 20;
            if (differencePlayerToNextBlock != 0)
            {
                iTween.MoveTo(gameObject, new Vector3(transform.position.x, transform.position.y - differencePlayerToNextBlock, transform.position.z), 2);
            }
        }
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.K))
        {
            float differencePlayerToNextBlock = (transform.position.y + 10) % 20;
            if (differencePlayerToNextBlock != 0)
            {
                iTween.MoveTo(gameObject, new Vector3(transform.position.x, transform.position.y - differencePlayerToNextBlock, transform.position.z), 2);
            }
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.J))
        {
            float differencePlayerToNextBlock = (transform.position.y + 10) % 20;
            if (differencePlayerToNextBlock != 0)
            {
                iTween.MoveTo(gameObject, new Vector3(transform.position.x, transform.position.y - differencePlayerToNextBlock, transform.position.z), 2);
            }
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.L))
        {
            float differencePlayerToNextBlock = (transform.position.y + 10) % 20;
            if (differencePlayerToNextBlock != 0)
            {
                iTween.MoveTo(gameObject, new Vector3(transform.position.x, transform.position.y - differencePlayerToNextBlock, transform.position.z), 2);
            }
        }*/
        if (playerColor == 1)
        {
            if (Input.GetKey(KeyCode.S))
            {
                moveVelocityHorizontal = -playerSpeed;             

            }

            if (Input.GetKey(KeyCode.W))
            {
                moveVelocityHorizontal = playerSpeed;
            }

            if (Input.GetKey(KeyCode.A))
            {
                moveVelocityVertical = -playerSpeed;

            }

            if (Input.GetKey(KeyCode.D))
            {
                moveVelocityVertical = playerSpeed;
            }
        }
        else if(playerColor == 2)
        {
            if (Input.GetKey(KeyCode.K))
            {
                moveVelocityHorizontal = -playerSpeed;
                //iTween.MoveBy(gameObject, new Vector3(0, -gridSize, 0), 1.0f);

            }

            if (Input.GetKey(KeyCode.I))
            {
                moveVelocityHorizontal = playerSpeed;
                //iTween.MoveBy(gameObject, new Vector3(0, gridSize, 0), 1.0f);

            }

            if (Input.GetKey(KeyCode.J))
            {
               moveVelocityVertical = -playerSpeed;
               // iTween.MoveBy(gameObject, new Vector3(-gridSize, 0, 0), 1.0f);

            }

            if (Input.GetKey(KeyCode.L))
            {
                moveVelocityVertical = playerSpeed;
                //iTween.MoveBy(gameObject, new Vector3(gridSize, 0, 0), .2f);

            }
        }


        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocityHorizontal, GetComponent<Rigidbody2D>().velocity.y);
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocityVertical, GetComponent<Rigidbody2D>().velocity.x);


    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if player hits player both explode
        if(collision.gameObject.tag == "Player")
        {
            //TODO: activate particle system

            playerImage.enabled = false;
            playerCollider.enabled = false;
            Init();
        }
    }


}
