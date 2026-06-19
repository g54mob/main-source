using System;
using System.Text;

namespace OpenBLive.Runtime.Data
{
	public struct Packet
	{
		private static readonly Packet s_NoBodyHeartBeatPacket = new Packet
		{
			Header = new PacketHeader
			{
				HeaderLength = 16,
				SequenceId = 1,
				ProtocolVersion = ProtocolVersion.HeartBeat,
				Operation = Operation.HeartBeat
			}
		};

		public PacketHeader Header;

		public byte[] PacketBody;

		public int Length => Header.PacketLength;

		public byte[] ToBytes
		{
			get
			{
				if (PacketBody != null)
				{
					Header.PacketLength = Header.HeaderLength + PacketBody.Length;
				}
				else
				{
					Header.PacketLength = Header.HeaderLength;
				}
				byte[] array = new byte[Header.PacketLength];
				Array.Copy(((ReadOnlySpan<byte>)Header).ToArray(), array, Header.HeaderLength);
				if (PacketBody != null)
				{
					Array.Copy(PacketBody, 0, array, Header.HeaderLength, PacketBody.Length);
				}
				return array;
			}
		}

		public Packet(ReadOnlySpan<byte> bytes)
		{
			ReadOnlySpan<byte> readOnlySpan = bytes;
			ReadOnlySpan<byte> bytes2 = readOnlySpan.Slice(0, 16);
			Header = new PacketHeader(bytes2);
			readOnlySpan = bytes;
			int headerLength = Header.HeaderLength;
			PacketBody = readOnlySpan.Slice(headerLength, Header.PacketLength - headerLength).ToArray();
		}

		public Packet(Operation operation, byte[] body = null)
		{
			Header = new PacketHeader
			{
				Operation = operation,
				ProtocolVersion = ProtocolVersion.UnCompressed,
				PacketLength = 16 + ((body != null) ? body.Length : 0)
			};
			PacketBody = body;
		}

		public static Packet HeartBeat(string msg)
		{
			return HeartBeat(Encoding.UTF8.GetBytes(msg));
		}

		public static Packet HeartBeat(byte[] msg = null)
		{
			if (msg == null)
			{
				return s_NoBodyHeartBeatPacket;
			}
			return new Packet
			{
				Header = new PacketHeader
				{
					PacketLength = 16 + msg.Length,
					ProtocolVersion = ProtocolVersion.HeartBeat,
					Operation = Operation.HeartBeat,
					SequenceId = 1,
					HeaderLength = 16
				},
				PacketBody = msg
			};
		}

		public static Packet Authority(string token, ProtocolVersion protocolVersion = ProtocolVersion.Brotli)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(token);
			return new Packet
			{
				Header = new PacketHeader
				{
					Operation = Operation.Authority,
					ProtocolVersion = ProtocolVersion.HeartBeat,
					SequenceId = 1,
					HeaderLength = 16,
					PacketLength = 16 + bytes.Length
				},
				PacketBody = bytes
			};
		}
	}
}
