using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetector : MonoBehaviour
{
    private Vector2 m_TouchDownPos;
    private Vector2 m_TouchUpPos;
    private Vector2 m_SwipeDir;
    private BoomerangScript m_Boomerang;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        Debug.Log("Swipe Direction: " + m_SwipeDir);
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0)) {
            m_TouchDownPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0)) {
            m_TouchUpPos = Input.mousePosition;

            m_SwipeDir = m_TouchUpPos - m_TouchDownPos;
        }
    }
}
