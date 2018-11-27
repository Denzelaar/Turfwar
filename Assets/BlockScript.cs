using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BlockScript : MonoBehaviour {

    public int currentColor;

    Color player1Color = Color.blue;
    Color player2Color = Color.red;
    Color player3Color = Color.green;
    Color player4Color = Color.yellow;

    Image playerImage;
    BoxCollider2D bx2d;

	// Use this for initialization
	void Start () {
        playerImage = GetComponent<Image>();
        bx2d = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update () {
		
	}

    public void ColorChangeOnCollision(PlayerScript player)
    {
        if(currentColor != player.playerColor)
        {
            currentColor = player.playerColor;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            int playerCollisionColor = other.gameObject.GetComponent<PlayerScript>().playerColor;

            if (playerCollisionColor != currentColor)
            {
                ChangeColor(playerCollisionColor);
                currentColor = playerCollisionColor;

            }
        }
    }

    void ChangeColor(int color)
    {
        switch (color)
        {
            case 1:
                playerImage.color = player1Color;
                return;
            case 2:
                playerImage.color = player2Color;
                return;
            case 3:
                playerImage.color = player3Color;
                return;
            case 4:
                playerImage.color = player4Color;
                return;
        }
    }
}
