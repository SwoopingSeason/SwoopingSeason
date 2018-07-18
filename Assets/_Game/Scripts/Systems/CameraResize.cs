using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResize : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        ResizeCamera();
	}

    private void Update()
    {
        ResizeCamera();
    }

    void ResizeCamera()
    {
        // set the desired aspect ratio
        float targetAspect = 16.0f / 9.0f;

        // determine the game window's current aspect ratio
        float windowAspect = (float)Screen.width / (float)Screen.height;

        // current viewport height should be scaled by this amount
        float scaleHeight = windowAspect / targetAspect;

        // obtain camera component so we can modify its viewport
        Camera myCamera = GetComponent<Camera>();

        // if scaled height is less than current height, add letterbox
        if (scaleHeight < 1.0f) {
            Rect rect = myCamera.rect;

            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;

            myCamera.rect = rect;
        } else // add pillarbox
          {
            float scaleWidth = 1.0f / scaleHeight;

            Rect rect = myCamera.rect;

            rect.width = scaleWidth;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;

            myCamera.rect = rect;
        }
    }
}
