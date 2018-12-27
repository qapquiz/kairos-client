using System.IO;
using System.Text;

namespace Kairos {
    public class PacketWriter {
        private MemoryStream _stream;
        private BinaryWriter _writer;

        public PacketWriter() {
            _stream = new MemoryStream();
            _writer = new BinaryWriter(_stream);
        }

        public PacketWriter(ushort packetId) {
            _stream = new MemoryStream();
            _writer = new BinaryWriter(_stream);

            this.WriteUInt16(packetId);
        }

        ~PacketWriter() {
            _writer.Dispose();
            _stream.Dispose();
        }

        public static void PrintByteArray(byte[] bytes) {
            var sb = new StringBuilder("new byte[] { ");
            foreach (var b in bytes) {
                sb.Append(b + ", ");
            }
            sb.Append("}");
            UnityEngine.Debug.Log(sb.ToString());
        }

        public byte[] GetData() {
            return _stream.ToArray();
        }

        public PacketWriter WriteUInt8(int value) {
            _writer.Write((byte)value);
            return this;
        }

        public PacketWriter WriteUInt16(ushort value) {
            _writer.Write(value);
            return this;
        }

        public PacketWriter WriteUInt32(uint value) {
            _writer.Write(value);
            return this;
        }

        public PacketWriter WriteUInt64(ulong value) {
            _writer.Write(value);
            return this;
        }

        public PacketWriter WriteInt8(int value) {
            _writer.Write((byte)value);
            return this;
        }

        public PacketWriter WriteInt16(ushort value) {
            _writer.Write(value);
            return this;
        }

        public PacketWriter WriteInt32(int value) {
            _writer.Write(value);
            return this;
        }

        public PacketWriter WriteInt64(long value) {
            _writer.Write(value);
            return this;
        }

        public PacketWriter WriteString(string value) {
            byte[] bytes = Encoding.UTF8.GetBytes(value);
            foreach (byte charCode in bytes)  {
                _writer.Write(charCode);
            }
            _writer.Write((byte)0);
            return this;
        }

        public PacketWriter WriteBoolean(bool value) {
            if (value) {
                _writer.Write((byte)1);
            } else {
                _writer.Write((byte)0);
            }
            return this;
        }
    }
}