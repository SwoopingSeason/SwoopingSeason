﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public GameObject boomerang;

    private bool m_HoldingBoomerang;
    private Camera m_Camera;
    private Vector2 m_TouchDownPos;
    private Vector2 m_TouchUpPos;
    private Vector2 m_SwipeDir;

    // Use this for initialization
    void Start () {
        m_HoldingBoomerang = true;
        m_Camera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0)) {

            Vector2 mousePos = m_Camera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 startPos = this.transform.position;

            if (m_HoldingBoomerang == true) {
                m_HoldingBoomerang = false;

                var heading = mousePos - startPos;
                var direction = heading.normalized;

                // Start Pos in between x -0.9 to 0.9
                // and y between -3.2 to -2.6

                ThrowBoomerang(direction);
            } 
            
            if (!m_HoldingBoomerang) {
                var heading = player.transform.position - transform.position;
                var distance = heading.magnitude;

                if (Input.GetMouseButtonDown(0)) {
                    m_TouchDownPos = Input.mousePosition;
                }

                if (Input.GetMouseButtonUp(0)) {
                    m_TouchUpPos = Input.mousePosition;

                    m_SwipeDir = m_TouchUpPos - m_TouchDownPos;
                    m_SwipeDir.Normalize();

                    if (distance > colliderActiveDistance)
                        m_RigidBody.AddForce(m_SwipeDir * swipeForce);
                }
            }
        }        
    }

    void ThrowBoomerang(Vector3 direction)
    {
        GameObject zBoomerang = Instantiate(boomerang, this.transform.position, Quaternion.identity) as GameObject;
        BoomerangScript boomerangScript = zBoomerang.GetComponent<BoomerangScript>();
        boomerangScript.direction = direction;
    }

    public void CatchBoomerang(){
        m_HoldingBoomerang = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Boomerang"){
            CatchBoomerang();
            Destroy(collision.gameObject);
        }
    }
}
