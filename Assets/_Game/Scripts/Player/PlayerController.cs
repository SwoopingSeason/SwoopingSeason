using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public GameObject boomerangPrefab;

    private bool holdingBoomerang; 


	// Use this for initialization
	void Start () {
        holdingBoomerang = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0)) {
            if (holdingBoomerang == true) {
                Debug.Log("Throw Boomerang");
            }            
        }
	}
}
