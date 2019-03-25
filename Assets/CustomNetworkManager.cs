using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using UnityEngine;

public class CustomNetworkManager : MonoBehaviour {

    private BinaryReader reader;
    private BinaryWriter writer;

    public CustomNetworkManager(string ip, int port) {
        var conn = new TcpClient(ip, port);
        var str = conn.GetStream();

        reader = new BinaryReader(str);
        writer = new BinaryWriter(str);
    }

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        var playerPos = GameObject.FindGameObjectWithTag("Player").
            transform.position.normalized;
        Debug.Log(playerPos);
    }
}
