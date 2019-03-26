using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private Vector3 offset = Vector3.zero;
    private GameObject player;

    private Vector3 minOffset = new Vector3(-1000f, 3.3f, 0.1f);
    private Vector3 maxOffset = new Vector3(-2.2f, 1000f, 1000f);


    public int zoomMultiplier = 2; // Used to increase the zoom speed 

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position - player.transform.position;
    }

    void Update()
    {
        float zoom = Input.GetAxis("Mouse ScrollWheel");
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, zoom * zoomMultiplier);
        offset = clampCameraOffset(transform.position - player.transform.position);
        transform.position = player.transform.position + offset;
    }

    Vector3 clampCameraOffset(Vector3 pos)
    {
        return new Vector3(
                Mathf.Clamp(pos.x, minOffset.x, maxOffset.x),
                Mathf.Clamp(pos.y, minOffset.y, maxOffset.y),
                Mathf.Clamp(pos.z, minOffset.z, maxOffset.z)
            );
    }

    void LateUpdate()
    {
        
    }
}
