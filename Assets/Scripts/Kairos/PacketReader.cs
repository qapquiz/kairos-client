using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Kairos {
    public class PacketReader {
        private MemoryStream _stream;
        private BinaryReader _reader;

        public PacketReader(byte[] data) {
            _stream = new MemoryStream(data);
            _reader = new BinaryReader(_stream);
        }

        ~PacketReader() {
            _reader.Dispose();
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

        public int GetPacketId() {
            return (int)_reader.ReadUInt16();
        }

        public int ReadUInt8() {
            return (int)_reader.ReadByte();
        }

        public ushort ReadUInt16() {
            return _reader.ReadUInt16();
        }

        public uint ReadUInt32() {
            return _reader.ReadUInt32();
        }

        public ulong ReadUInt64() {
            return _reader.ReadUInt64();
        }

        public int ReadInt8() {
            return (int)_reader.ReadByte();
        }

        public short ReadInt16() {
            return _reader.ReadInt16();
        }

        public int ReadInt32() {
            return _reader.ReadInt32();
        }

        public long ReadInt64() {
            return _reader.ReadInt64();
        }

        public string ReadString() {
            List<byte> bytes = new List<byte>();

            while (true) {
                var charCode = _reader.ReadByte();

                bytes.Add(charCode);

                if (charCode == 0b_0000_0000) {
                    break;
                }
            }

            return Encoding.UTF8.GetString(bytes.ToArray());
        }

        public bool ReadBoolean() {
            return (int)_reader.ReadByte() == 1;
        }
    }
}