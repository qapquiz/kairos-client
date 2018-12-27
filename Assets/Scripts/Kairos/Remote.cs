using UnityEngine.Events;
using WebSocketSharp;

namespace Kairos {
    public class Remote {
        public UnityEvent OnConnected;
        public UnityEvent OnDisconnected;

        public Packet Packet;
        public WebSocket Socket;

        public Remote(WebSocket socket) {
            Packet = new Packet();
            Socket = socket;
            OnConnected = new UnityEvent();
            OnDisconnected = new UnityEvent();
        }

        ~Remote() {
            OnConnected.RemoveAllListeners();
            OnDisconnected.RemoveAllListeners();
        }

        public void Send(byte[] data) {
            if (Socket.IsAlive) {
                Socket.Send(data);
            }
        }

        public void SendLogin(string name) {
            Send(Packet.SendLogin(name));
        }
    }
}

