using System;
using MessagePack.Internal;
using TH20;

namespace MessagePack.Formatters.TH20
{
	public sealed class OnlineChallengeEventFormatter : IMessagePackFormatter<OnlineChallengeEvent>, IMessagePackFormatter
	{
		private readonly AutomataDictionary ____keyMapping;

		private readonly byte[][] ____stringByteKeys;

		public OnlineChallengeEventFormatter()
		{
			____keyMapping = new AutomataDictionary
			{
				{ "Day", 0 },
				{ "Type", 1 }
			};
			____stringByteKeys = new byte[2][]
			{
				MessagePackBinary.GetEncodedStringBytes("Day"),
				MessagePackBinary.GetEncodedStringBytes("Type")
			};
		}

		public int Serialize(ref byte[] bytes, int offset, OnlineChallengeEvent value, IFormatterResolver formatterResolver)
		{
			if (value == null)
			{
				return MessagePackBinary.WriteNil(ref bytes, offset);
			}
			int num = offset;
			offset += MessagePackBinary.WriteFixedMapHeaderUnsafe(ref bytes, offset, 2);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[0]);
			offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.Day);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[1]);
			offset += formatterResolver.GetFormatterWithVerify<OnlineChallengeEvent.Event>().Serialize(ref bytes, offset, value.Type, formatterResolver);
			return offset - num;
		}

		public OnlineChallengeEvent Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			if (MessagePackBinary.IsNil(bytes, offset))
			{
				readSize = 1;
				return null;
			}
			int num = offset;
			int num2 = MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
			offset += readSize;
			int day = 0;
			OnlineChallengeEvent.Event type = OnlineChallengeEvent.Event.Score;
			for (int i = 0; i < num2; i++)
			{
				ArraySegment<byte> key = MessagePackBinary.ReadStringSegment(bytes, offset, out readSize);
				offset += readSize;
				if (!____keyMapping.TryGetValueSafe(key, out var value))
				{
					readSize = MessagePackBinary.ReadNextBlock(bytes, offset);
				}
				else
				{
					switch (value)
					{
					case 0:
						day = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
						break;
					case 1:
						type = formatterResolver.GetFormatterWithVerify<OnlineChallengeEvent.Event>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					default:
						readSize = MessagePackBinary.ReadNextBlock(bytes, offset);
						break;
					}
				}
				offset += readSize;
			}
			readSize = offset - num;
			return new OnlineChallengeEvent
			{
				Day = day,
				Type = type
			};
		}
	}
}
