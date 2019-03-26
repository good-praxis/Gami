using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//IMPORTANT: Note that we are moving only the GFX (the model) and not the player so
//           it doesnt interfere with the WASD movement, making it absolute not relative.

public class LookAtMouse : MonoBehaviour
{

    Vector3 mousePos;
    public float turnSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        //Gets position from the green circle itself.
        mousePos = GameObject.FindGameObjectWithTag("Mouse Position").transform.position;

        //Make character look straight
        mousePos.y = 1;


        Vector3 direction = mousePos - transform.position;
        Quaternion toRotation = Quaternion.FromToRotation(transform.forward, direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, turnSpeed * Time.deltaTime);


    }
}
