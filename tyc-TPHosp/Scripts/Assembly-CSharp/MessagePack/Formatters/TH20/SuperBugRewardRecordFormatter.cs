using System;
using MessagePack.Internal;
using TH20;

namespace MessagePack.Formatters.TH20
{
	public sealed class SuperBugRewardRecordFormatter : IMessagePackFormatter<SuperBugRewardRecord>, IMessagePackFormatter
	{
		private readonly AutomataDictionary ____keyMapping;

		private readonly byte[][] ____stringByteKeys;

		public SuperBugRewardRecordFormatter()
		{
			____keyMapping = new AutomataDictionary();
			____stringByteKeys = new byte[0][];
		}

		public int Serialize(ref byte[] bytes, int offset, SuperBugRewardRecord value, IFormatterResolver formatterResolver)
		{
			if (value == null)
			{
				return MessagePackBinary.WriteNil(ref bytes, offset);
			}
			int num = offset;
			offset += MessagePackBinary.WriteFixedMapHeaderUnsafe(ref bytes, offset, 0);
			return offset - num;
		}

		public SuperBugRewardRecord Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			if (MessagePackBinary.IsNil(bytes, offset))
			{
				readSize = 1;
				return null;
			}
			int num = offset;
			int num2 = MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
			offset += readSize;
			for (int i = 0; i < num2; i++)
			{
				ArraySegment<byte> key = MessagePackBinary.ReadStringSegment(bytes, offset, out readSize);
				offset += readSize;
				if (!____keyMapping.TryGetValueSafe(key, out var _))
				{
					readSize = MessagePackBinary.ReadNextBlock(bytes, offset);
				}
				else
				{
					readSize = MessagePackBinary.ReadNextBlock(bytes, offset);
				}
				offset += readSize;
			}
			readSize = offset - num;
			return new SuperBugRewardRecord();
		}
	}
}
