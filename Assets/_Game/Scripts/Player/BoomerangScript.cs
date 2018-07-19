using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangScript : MonoBehaviour {
    public float rotateSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Rotate the object around its local z axis
        transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f) * Time.deltaTime * rotateSpeed);
	}
}
