using System;
using MessagePack.Internal;
using TH20;

namespace MessagePack.Formatters.TH20
{
	public sealed class SuperBugOnlineInfo_RewardInfoFormatter : IMessagePackFormatter<SuperBugOnlineInfo.RewardInfo>, IMessagePackFormatter
	{
		private readonly AutomataDictionary ____keyMapping;

		private readonly byte[][] ____stringByteKeys;

		public SuperBugOnlineInfo_RewardInfoFormatter()
		{
			____keyMapping = new AutomataDictionary { { "Reward", 0 } };
			____stringByteKeys = new byte[1][] { MessagePackBinary.GetEncodedStringBytes("Reward") };
		}

		public int Serialize(ref byte[] bytes, int offset, SuperBugOnlineInfo.RewardInfo value, IFormatterResolver formatterResolver)
		{
			if (value == null)
			{
				return MessagePackBinary.WriteNil(ref bytes, offset);
			}
			int num = offset;
			offset += MessagePackBinary.WriteFixedMapHeaderUnsafe(ref bytes, offset, 1);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[0]);
			offset += formatterResolver.GetFormatterWithVerify<SuperBugReward>().Serialize(ref bytes, offset, value.Reward, formatterResolver);
			return offset - num;
		}

		public SuperBugOnlineInfo.RewardInfo Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			if (MessagePackBinary.IsNil(bytes, offset))
			{
				readSize = 1;
				return null;
			}
			int num = offset;
			int num2 = MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
			offset += readSize;
			SuperBugReward reward = null;
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
					reward = formatterResolver.GetFormatterWithVerify<SuperBugReward>().Deserialize(bytes, offset, formatterResolver, out readSize);
				}
				else
				{
					readSize = MessagePackBinary.ReadNextBlock(bytes, offset);
				}
				offset += readSize;
			}
			readSize = offset - num;
			return new SuperBugOnlineInfo.RewardInfo
			{
				Reward = reward
			};
		}
	}
}
