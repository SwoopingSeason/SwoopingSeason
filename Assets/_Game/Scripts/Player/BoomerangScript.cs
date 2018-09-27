using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangScript : MonoBehaviour {
    public float moveSpeed;
    public float rotateSpeed;
    public float maxDistance;
    public float colliderActiveDistance;
    public GameObject player;
    public Vector3 direction;

    private PolygonCollider2D m_TriggerCollider;
    private PlayerController m_PlayerScript;

	// Use this for initialization
	void Start () {
        m_TriggerCollider = GetComponent<PolygonCollider2D>();
        m_PlayerScript = player.GetComponent<PlayerController>();

        m_TriggerCollider.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        // Rotate the object around its local z axis
        //transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f) * Time.deltaTime * rotateSpeed);

        // Translate forward 
        transform.Translate(direction * Time.deltaTime * moveSpeed);

        // Get the distance from the player
        var heading = player.transform.position - transform.position;
        var distance = heading.magnitude;

        // Enable Colliders
        if(distance > colliderActiveDistance) {
            m_TriggerCollider.enabled = true;
        }

        // Once reach maxDistance from originPos
        // Reverse the direction 
        if (distance > maxDistance) {
            direction = -direction;
        }
    }
}
