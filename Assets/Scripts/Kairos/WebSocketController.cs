using WebSocketSharp;

namespace Kairos {
    public class WebSocketController {

        public WebSocket Socket;
        public Packet Packet;
        public Remote Remote;

        public WebSocketController(string url) {
            Socket = new WebSocket(url);
            Remote = new Remote(Socket);

            Socket.OnOpen += (sender, e) => {
                UnityEngine.Debug.Log($"sender: {sender.ToString()}, e: {e.ToString()}");
                Remote.OnConnected.Invoke();
            };

            Socket.OnMessage += (sender, e) => {
                PacketReader reader = new PacketReader(e.RawData);
                int packetId = reader.GetPacketId();

                Remote.Packet.Mapper[packetId](packetId, reader);
            };

            Socket.OnClose += (sender, e) => {
                UnityEngine.Debug.Log($"OnClose => sender: {sender.ToString()}, e: {e.Reason}");
                Remote.OnDisconnected.Invoke();
            };

            Socket.OnError += (sender, e) => {
                UnityEngine.Debug.LogError($"OnError => sender: {sender.ToString()}, e: {e.Message}");
                Remote.OnDisconnected.Invoke();
            };
        }

        ~WebSocketController() {
            Socket.Close(CloseStatusCode.Away);
        }

        public void Connect() {
            Socket.Connect();
        }

        public void Close() {
            Socket.Close();
        }
    }
}
