using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Green circle that indicates where (relative to the ground) the mouse is pointing.

public class MouseIndicator : MonoBehaviour
{
    Camera cam;
    Vector3 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        //Shoots a ray from the camera and reports the first thing it hits.
        //Can be set to ignore everything except the ground.

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            mousePos = hit.point;
            mousePos.y = 0;
        }

        transform.SetPositionAndRotation(mousePos, transform.rotation);
    }
}
