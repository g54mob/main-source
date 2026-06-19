using System;
using MessagePack.Internal;
using TH20;

namespace MessagePack.Formatters.TH20
{
	public sealed class OnlinePlayerIDFormatter : IMessagePackFormatter<OnlinePlayerID>, IMessagePackFormatter
	{
		private readonly AutomataDictionary ____keyMapping;

		private readonly byte[][] ____stringByteKeys;

		public OnlinePlayerIDFormatter()
		{
			____keyMapping = new AutomataDictionary { { "m_OnlinePlayerID", 0 } };
			____stringByteKeys = new byte[1][] { MessagePackBinary.GetEncodedStringBytes("m_OnlinePlayerID") };
		}

		public int Serialize(ref byte[] bytes, int offset, OnlinePlayerID value, IFormatterResolver formatterResolver)
		{
			int num = offset;
			offset += MessagePackBinary.WriteFixedMapHeaderUnsafe(ref bytes, offset, 1);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[0]);
			offset += MessagePackBinary.WriteUInt64(ref bytes, offset, value.m_OnlinePlayerID);
			return offset - num;
		}

		public OnlinePlayerID Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			if (MessagePackBinary.IsNil(bytes, offset))
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			int num = offset;
			int num2 = MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
			offset += readSize;
			ulong onlinePlayerID = 0uL;
			for (int i = 0; i < num2; i++)
			{
				ArraySegment<byte> key = MessagePackBinary.ReadStringSegment(bytes, offset, out readSize);
				offset += readSize;
				if (!____keyMapping.TryGetValueSafe(key, out var value))
				{
					readSize = MessagePackBinary.ReadNextBlock(bytes, offset);
				}
				else if (value == 0)
				{
					onlinePlayerID = MessagePackBinary.ReadUInt64(bytes, offset, out readSize);
				}
				else
				{
					readSize = MessagePackBinary.ReadNextBlock(bytes, offset);
				}
				offset += readSize;
			}
			readSize = offset - num;
			return new OnlinePlayerID
			{
				m_OnlinePlayerID = onlinePlayerID
			};
		}
	}
}
