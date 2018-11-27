using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillScript : MonoBehaviour {

    public GameObject block;
    public int gridSize;
    public string objectName = "new Object";
	// Use this for initialization
	void Start () {
		for(int i = 0; i < gridSize; i++)
        {
            GameObject newBlock = Instantiate(block, transform);
            newBlock.name = (objectName + i);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
