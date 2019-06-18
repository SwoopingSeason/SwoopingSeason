using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangScript : MonoBehaviour {
    public float moveSpeed;
    public float rotateSpeed;
    public float maxDistance;
    public float maxReturnSpeed;
    public float initialForce;
    public float returnForce;
    public float swipeForce;
    public float colliderActiveDistance;
    public GameObject player;
    public Vector3 direction;

    private bool m_Returning;
    private PolygonCollider2D m_TriggerCollider;
    private PlayerController m_PlayerScript;
    private Rigidbody2D m_RigidBody;
    private Vector2 m_TouchDownPos;
    private Vector2 m_TouchUpPos;
    private Vector2 m_SwipeDir;

    // Use this for initialization
    void Start () {
        m_TriggerCollider = GetComponent<PolygonCollider2D>();
        m_PlayerScript = player.GetComponent<PlayerController>();
        m_RigidBody = GetComponent<Rigidbody2D>();

        m_TriggerCollider.enabled = false;

        m_RigidBody.AddForce(direction * initialForce);
        m_Returning = false;
    }

    void FixedUpdate()
    {
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

    // Update is called once per frame
    void Update ()
    {
        // Get the distance from the player
        var heading = player.transform.position - transform.position;
        var distance = heading.magnitude;

        // Check if boomerang has reached max distance to player. 
        // start applying return force to boomerang in direction of player    
        if (distance >= maxDistance) {
            m_Returning = true;
            
            if (m_RigidBody.velocity.magnitude <= maxReturnSpeed) {
                m_RigidBody.AddForce(-direction * returnForce);
            }
        }

        // Calculate return direction and add force
       /* if (m_Returning) {
            direction = player.transform.position - transform.position;

            if (m_RigidBody.velocity.magnitude <= maxReturnSpeed) {
                m_RigidBody.AddForce(direction * returnForce);
            }
        }*/

        // Enable Colliders
        if (distance > colliderActiveDistance) {
            m_TriggerCollider.enabled = true;
        }                

        //MoveBoomerang();
    }

    /*private void MoveBoomerang()
    {
        // Rotate the object around its local z axis
        transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f) * Time.deltaTime * rotateSpeed);

        // Translate forward 
        transform.Translate(direction * Time.deltaTime * moveSpeed);

        // Get the distance from the player
        var heading = player.transform.position - transform.position;
        var distance = heading.magnitude;

        // Enable Colliders
        if (distance > colliderActiveDistance) {
            m_TriggerCollider.enabled = true;
        }

        // Once reach maxDistance from originPos
        // Reverse the direction 
        if (distance > maxDistance) {
            direction = -direction;
        }
    }*/
}
