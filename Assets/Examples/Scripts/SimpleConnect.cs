using Kairos;
using UnityEngine;

public class SimpleConnect : MonoBehaviour {
    void Start() {
        WebSocketController ws = new WebSocketController("ws://127.0.0.1:8000/ws");
        ws.Connect();

        Remote remote = ws.GetRemote();
        remote.SendLogin("armariya");
    }
}
