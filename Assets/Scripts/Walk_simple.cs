using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk_simple : MonoBehaviour
{
    public float moveSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void Movement()
    {

        float moveForward = Input.GetAxis("Vertical") * Time.deltaTime;
        float moveSide = Input.GetAxis("Horizontal") * Time.deltaTime;

        transform.Translate(Vector3.forward * moveForward * moveSpeed);
        transform.Translate(Vector3.right * moveSide * moveSpeed);
    }
}
