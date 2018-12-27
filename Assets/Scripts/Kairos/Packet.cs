using System;
using System.Collections.Generic;

namespace Kairos {
    public class Packet {
        private enum PacketId {
            CS_LOGIN = 10001,


            SC_LOGGEDIN = 20001,
        }

        public Dictionary<int, Action<int, PacketReader>> Mapper;

        public Packet() {
            Mapper = new Dictionary<int, Action<int, PacketReader>>();
            MapPackets();
        }

        private void MapPackets() {
            Mapper[(int)PacketId.SC_LOGGEDIN] = ReceiveLogin;
        }

        // Writer Packet
        public byte[] SendLogin(string name) {
            PacketWriter writer = new PacketWriter((int)PacketId.CS_LOGIN);
            writer.WriteString(name);

            return writer.GetData();
        }

        // Read Packet
        private void ReceiveLogin(int packetId, PacketReader reader) {
            string name = reader.ReadString();

            UnityEngine.Debug.Log("Hello, " + name);
        }
    }
}

