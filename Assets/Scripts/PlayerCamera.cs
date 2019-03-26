using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private Vector3 offset = Vector3.zero;
    private float radius;
    private GameObject player;

    private Vector3 minOffset = new Vector3(-1000f, 3.3f, 0.1f);
    private Vector3 maxOffset = new Vector3(-2.2f, 1000f, 1000f);
    private float angle = 0f;

    public int zoomMultiplier = 2; // Used to increase the zoom speed 
    public int rotationMultiplier = 2; // Used to increase the speed of camera rotation

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position - player.transform.position;
        radius = Mathf.Abs(offset.x) + Mathf.Abs(offset.z);
    }

    void Update()
    {
        float zoom = Input.GetAxis("Mouse ScrollWheel");
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, zoom * zoomMultiplier);
        offset = ClampCameraOffset(transform.position - player.transform.position);
        transform.position = player.transform.position + offset;

        angle += Input.GetAxis("Horizontal") * rotationMultiplier * Time.deltaTime;
        Vector2 rotation = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * radius;
        transform.position = new Vector3(rotation.x, transform.position.y, rotation.y);
        transform.LookAt(player.transform);
    }

    Vector3 ClampCameraOffset(Vector3 pos)
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
