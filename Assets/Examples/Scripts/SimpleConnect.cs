using Kairos;
using UnityEngine;

public class SimpleConnect : MonoBehaviour {
    void Start() {
        WebSocketController ws = new WebSocketController("ws://127.0.0.1:3012");
        ws.Connect();
    }
}
