using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector3 mousePos;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {

        //Reset Player Position
        transform.SetPositionAndRotation(new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 1));
    }


    // Update is called once per frame
    void Update()
    {
        WASD();
    }

    void WASD()
    {

        float forwardMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float sideMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        //ClampMagnitude limits the total movement speed to moveSpeed.

        transform.Translate(Vector3.ClampMagnitude(Vector3.forward, moveSpeed) * forwardMovement);
        transform.Translate(Vector3.ClampMagnitude(Vector3.right, moveSpeed) * sideMovement);


    }

}
