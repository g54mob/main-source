using System;
using MessagePack.Internal;
using TH20;

namespace MessagePack.Formatters.TH20
{
	public sealed class SuperBugRewardKudoshFormatter : IMessagePackFormatter<SuperBugRewardKudosh>, IMessagePackFormatter
	{
		private readonly AutomataDictionary ____keyMapping;

		private readonly byte[][] ____stringByteKeys;

		public SuperBugRewardKudoshFormatter()
		{
			____keyMapping = new AutomataDictionary { { "KudoshAmount", 0 } };
			____stringByteKeys = new byte[1][] { MessagePackBinary.GetEncodedStringBytes("KudoshAmount") };
		}

		public int Serialize(ref byte[] bytes, int offset, SuperBugRewardKudosh value, IFormatterResolver formatterResolver)
		{
			if (value == null)
			{
				return MessagePackBinary.WriteNil(ref bytes, offset);
			}
			int num = offset;
			offset += MessagePackBinary.WriteFixedMapHeaderUnsafe(ref bytes, offset, 1);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[0]);
			offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.KudoshAmount);
			return offset - num;
		}

		public SuperBugRewardKudosh Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			if (MessagePackBinary.IsNil(bytes, offset))
			{
				readSize = 1;
				return null;
			}
			int num = offset;
			int num2 = MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
			offset += readSize;
			int kudoshAmount = 0;
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
					kudoshAmount = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
				}
				else
				{
					readSize = MessagePackBinary.ReadNextBlock(bytes, offset);
				}
				offset += readSize;
			}
			readSize = offset - num;
			return new SuperBugRewardKudosh
			{
				KudoshAmount = kudoshAmount
			};
		}
	}
}
