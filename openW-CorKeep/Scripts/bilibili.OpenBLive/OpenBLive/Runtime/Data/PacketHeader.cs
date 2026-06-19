using System;
using System.Buffers.Binary;

namespace OpenBLive.Runtime.Data
{
	public struct PacketHeader
	{
		public const int KPacketHeaderLength = 16;

		public int PacketLength;

		public short HeaderLength;

		public ProtocolVersion ProtocolVersion;

		public Operation Operation;

		public int SequenceId;

		public int BodyLength => PacketLength - HeaderLength;

		public PacketHeader(ReadOnlySpan<byte> bytes)
		{
			if (bytes.Length < 16)
			{
				throw new ArgumentException("No Supported Protocol Header");
			}
			ReadOnlySpan<byte> readOnlySpan = bytes;
			ReadOnlySpan<byte> readOnlySpan2 = readOnlySpan;
			PacketLength = BinaryPrimitives.ReadInt32BigEndian(readOnlySpan2.Slice(0, 4));
			readOnlySpan2 = readOnlySpan;
			HeaderLength = BinaryPrimitives.ReadInt16BigEndian(readOnlySpan2.Slice(4, 2));
			readOnlySpan2 = readOnlySpan;
			ProtocolVersion = (ProtocolVersion)BinaryPrimitives.ReadInt16BigEndian(readOnlySpan2.Slice(6, 2));
			readOnlySpan2 = readOnlySpan;
			Operation = (Operation)BinaryPrimitives.ReadInt32BigEndian(readOnlySpan2.Slice(8, 4));
			readOnlySpan2 = readOnlySpan;
			SequenceId = BinaryPrimitives.ReadInt32BigEndian(readOnlySpan2.Slice(12, 4));
		}

		public static explicit operator ReadOnlySpan<byte>(PacketHeader header)
		{
			return GetBytes(header.PacketLength, header.HeaderLength, header.ProtocolVersion, header.Operation, header.SequenceId);
		}

		public static byte[] GetBytes(int packetLength, short headerLength, ProtocolVersion protocolVersion, Operation operation, int sequenceId = 1)
		{
			Span<byte> span = new byte[16].AsSpan();
			Span<byte> span2 = span;
			BinaryPrimitives.WriteInt32BigEndian(span2.Slice(0, 4), packetLength);
			span2 = span;
			BinaryPrimitives.WriteInt16BigEndian(span2.Slice(4, 2), headerLength);
			span2 = span;
			BinaryPrimitives.WriteInt16BigEndian(span2.Slice(6, 2), (short)protocolVersion);
			span2 = span;
			BinaryPrimitives.WriteInt32BigEndian(span2.Slice(8, 4), (int)operation);
			span2 = span;
			BinaryPrimitives.WriteInt32BigEndian(span2.Slice(12, 4), sequenceId);
			return span.ToArray();
		}
	}
}
