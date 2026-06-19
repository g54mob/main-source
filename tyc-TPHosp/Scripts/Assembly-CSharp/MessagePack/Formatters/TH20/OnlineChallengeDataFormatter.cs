using System;
using System.Collections.Generic;
using MessagePack.Internal;
using TH20;

namespace MessagePack.Formatters.TH20
{
	public sealed class OnlineChallengeDataFormatter : IMessagePackFormatter<OnlineChallengeData>, IMessagePackFormatter
	{
		private readonly AutomataDictionary ____keyMapping;

		private readonly byte[][] ____stringByteKeys;

		public OnlineChallengeDataFormatter()
		{
			____keyMapping = new AutomataDictionary
			{
				{ "PlayerID", 0 },
				{ "EventStream", 1 },
				{ "ScoreStream", 2 },
				{ "ChallengeStartDay", 3 },
				{ "ChallengeLength", 4 },
				{ "LastUpdateTime", 5 },
				{ "PlayersList", 6 }
			};
			____stringByteKeys = new byte[7][]
			{
				MessagePackBinary.GetEncodedStringBytes("PlayerID"),
				MessagePackBinary.GetEncodedStringBytes("EventStream"),
				MessagePackBinary.GetEncodedStringBytes("ScoreStream"),
				MessagePackBinary.GetEncodedStringBytes("ChallengeStartDay"),
				MessagePackBinary.GetEncodedStringBytes("ChallengeLength"),
				MessagePackBinary.GetEncodedStringBytes("LastUpdateTime"),
				MessagePackBinary.GetEncodedStringBytes("PlayersList")
			};
		}

		public int Serialize(ref byte[] bytes, int offset, OnlineChallengeData value, IFormatterResolver formatterResolver)
		{
			if (value == null)
			{
				return MessagePackBinary.WriteNil(ref bytes, offset);
			}
			int num = offset;
			offset += MessagePackBinary.WriteFixedMapHeaderUnsafe(ref bytes, offset, 7);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[0]);
			offset += formatterResolver.GetFormatterWithVerify<OnlinePlayerID>().Serialize(ref bytes, offset, value.PlayerID, formatterResolver);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[1]);
			offset += formatterResolver.GetFormatterWithVerify<List<OnlineChallengeEvent>>().Serialize(ref bytes, offset, value.EventStream, formatterResolver);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[2]);
			offset += formatterResolver.GetFormatterWithVerify<List<OnlineChallengeEventScore>>().Serialize(ref bytes, offset, value.ScoreStream, formatterResolver);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[3]);
			offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.ChallengeStartDay);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[4]);
			offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.ChallengeLength);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[5]);
			offset += MessagePackBinary.WriteUInt32(ref bytes, offset, value.LastUpdateTime);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[6]);
			offset += formatterResolver.GetFormatterWithVerify<List<OnlinePlayerID>>().Serialize(ref bytes, offset, value.PlayersList, formatterResolver);
			return offset - num;
		}

		public OnlineChallengeData Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			if (MessagePackBinary.IsNil(bytes, offset))
			{
				readSize = 1;
				return null;
			}
			int num = offset;
			int num2 = MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
			offset += readSize;
			OnlinePlayerID playerID = default(OnlinePlayerID);
			List<OnlineChallengeEvent> eventStream = null;
			List<OnlineChallengeEventScore> scoreStream = null;
			int challengeStartDay = 0;
			int challengeLength = 0;
			uint lastUpdateTime = 0u;
			List<OnlinePlayerID> playersList = null;
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
						playerID = formatterResolver.GetFormatterWithVerify<OnlinePlayerID>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					case 1:
						eventStream = formatterResolver.GetFormatterWithVerify<List<OnlineChallengeEvent>>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					case 2:
						scoreStream = formatterResolver.GetFormatterWithVerify<List<OnlineChallengeEventScore>>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					case 3:
						challengeStartDay = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
						break;
					case 4:
						challengeLength = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
						break;
					case 5:
						lastUpdateTime = MessagePackBinary.ReadUInt32(bytes, offset, out readSize);
						break;
					case 6:
						playersList = formatterResolver.GetFormatterWithVerify<List<OnlinePlayerID>>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					default:
						readSize = MessagePackBinary.ReadNextBlock(bytes, offset);
						break;
					}
				}
				offset += readSize;
			}
			readSize = offset - num;
			return new OnlineChallengeData
			{
				PlayerID = playerID,
				EventStream = eventStream,
				ScoreStream = scoreStream,
				ChallengeStartDay = challengeStartDay,
				ChallengeLength = challengeLength,
				LastUpdateTime = lastUpdateTime,
				PlayersList = playersList
			};
		}
	}
}
