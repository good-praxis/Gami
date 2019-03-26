using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector3 mousePos;
    float moveSpeed = 3f;
    // STILL UNUSED float turnSpeed = 50f;

    // Start is called before the first frame update
    void Start()
    {
        transform.SetPositionAndRotation(new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 1));
    }


    // Update is called once per frame
    void Update()
    {
        WASD();
        LookAtMouse();
    }

    void WASD()
    {
        float forwardMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float sideMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        transform.Translate(Vector3.forward * forwardMovement);
        transform.Translate(Vector3.right * sideMovement);

    }

    void LookAtMouse()
    {

        mousePos = GameObject.FindGameObjectWithTag("Mouse Position").transform.position;


        Quaternion rotation = Quaternion.LookRotation(mousePos);

        transform.rotation = rotation;
    }
}
