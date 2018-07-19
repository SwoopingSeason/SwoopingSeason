using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Transform boomerang;

    private bool holdingBoomerang; 
    
	// Use this for initialization
	void Start () {
        holdingBoomerang = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0)) {

            Vector3 mousePos = Input.mousePosition;

            if (holdingBoomerang == true) {
                //Debug.Log("Throw Boomerang");
                Debug.Log(mousePos);

                Vector3 startPos = mousePos;

                // Start Pos in between x -0.9 to 0.9
                // and y between -3.2 to -2.6

                ThrowBoomerang(startPos);
            }            
        }
	}

    void ThrowBoomerang(Vector3 startPos)
    {
        Instantiate(boomerang, new Vector3(0.0f, 1.0f, 0.0f), Quaternion.identity);
    }
}
