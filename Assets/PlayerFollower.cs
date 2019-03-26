using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{

    Vector3 playerPos;
    public Vector3 camOffset;
    Vector3 camPos;

    // Start is called before the first frame update
    void Start()
    {
        camOffset = new Vector3(0, 10, -4);
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;

        camPos = playerPos + camOffset;

        Debug.Log("Cam: " + camPos);

        transform.SetPositionAndRotation(camPos, transform.rotation);
    }
}
