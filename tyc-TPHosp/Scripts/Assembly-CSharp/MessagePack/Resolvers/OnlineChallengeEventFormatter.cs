using System;
using System.Collections.Generic;
using MessagePack.Formatters;
using MessagePack.Internal;
using TH20;

namespace MessagePack.Resolvers
{
	public sealed class OnlineChallengeEventFormatter : IMessagePackFormatter<OnlineChallengeEvent>, IMessagePackFormatter
	{
		private readonly Dictionary<RuntimeTypeHandle, KeyValuePair<int, int>> typeToKeyAndJumpMap;

		private readonly Dictionary<int, int> keyToJumpMap;

		private readonly byte[][] ____stringByteKeys;

		private readonly AutomataDictionary ____keyMapping;

		public OnlineChallengeEventFormatter()
		{
			typeToKeyAndJumpMap = new Dictionary<RuntimeTypeHandle, KeyValuePair<int, int>>(6, RuntimeTypeHandleEqualityComparer.Default)
			{
				{
					typeof(OnlineChallengeEvent).TypeHandle,
					new KeyValuePair<int, int>(0, 0)
				},
				{
					typeof(OnlineChallengeEventScore).TypeHandle,
					new KeyValuePair<int, int>(1, 1)
				},
				{
					typeof(OnlineChallengeEventInt).TypeHandle,
					new KeyValuePair<int, int>(2, 2)
				},
				{
					typeof(OnlineChallengeEventString).TypeHandle,
					new KeyValuePair<int, int>(3, 3)
				},
				{
					typeof(OnlineChallengeEventFloat).TypeHandle,
					new KeyValuePair<int, int>(4, 4)
				},
				{
					typeof(OnlineChallengeEventHospitalStatus).TypeHandle,
					new KeyValuePair<int, int>(5, 5)
				}
			};
			keyToJumpMap = new Dictionary<int, int>(6)
			{
				{ 0, 0 },
				{ 1, 1 },
				{ 2, 2 },
				{ 3, 3 },
				{ 4, 4 },
				{ 5, 5 }
			};
			____stringByteKeys = new byte[2][]
			{
				MessagePackBinary.GetEncodedStringBytes("Day"),
				MessagePackBinary.GetEncodedStringBytes("Type")
			};
			____keyMapping = new AutomataDictionary
			{
				{ "Day", 0 },
				{ "Type", 1 }
			};
		}

		public int Serialize(ref byte[] bytes, int offset, OnlineChallengeEvent value, IFormatterResolver formatterResolver)
		{
			if (value != null && typeToKeyAndJumpMap.TryGetValue(value.GetType().TypeHandle, out var value2))
			{
				int num = offset;
				offset += MessagePackBinary.WriteFixedArrayHeaderUnsafe(ref bytes, offset, 2);
				offset += MessagePackBinary.WriteInt32(ref bytes, offset, value2.Key);
				switch (value2.Value)
				{
				case 0:
					offset += MessagePackBinary.WriteFixedMapHeaderUnsafe(ref bytes, offset, 2);
					offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[0]);
					offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.Day);
					offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[1]);
					offset += formatterResolver.GetFormatterWithVerify<OnlineChallengeEvent.Event>().Serialize(ref bytes, offset, value.Type, formatterResolver);
					return offset - num;
				case 1:
					offset += formatterResolver.GetFormatterWithVerify<OnlineChallengeEventScore>().Serialize(ref bytes, offset, (OnlineChallengeEventScore)value, formatterResolver);
					break;
				case 2:
					offset += formatterResolver.GetFormatterWithVerify<OnlineChallengeEventInt>().Serialize(ref bytes, offset, (OnlineChallengeEventInt)value, formatterResolver);
					break;
				case 3:
					offset += formatterResolver.GetFormatterWithVerify<OnlineChallengeEventString>().Serialize(ref bytes, offset, (OnlineChallengeEventString)value, formatterResolver);
					break;
				case 4:
					offset += formatterResolver.GetFormatterWithVerify<OnlineChallengeEventFloat>().Serialize(ref bytes, offset, (OnlineChallengeEventFloat)value, formatterResolver);
					break;
				case 5:
					offset += formatterResolver.GetFormatterWithVerify<OnlineChallengeEventHospitalStatus>().Serialize(ref bytes, offset, (OnlineChallengeEventHospitalStatus)value, formatterResolver);
					break;
				}
				return offset - num;
			}
			return MessagePackBinary.WriteNil(ref bytes, offset);
		}

		public OnlineChallengeEvent Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			if (MessagePackBinary.IsNil(bytes, offset))
			{
				readSize = 1;
				return null;
			}
			int num = offset;
			if (MessagePackBinary.ReadArrayHeader(bytes, offset, out readSize) != 2)
			{
				throw new InvalidOperationException("Invalid Union data was detected. Type:global::TH20.OnlineChallengeEventBase");
			}
			offset += readSize;
			int value = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
			offset += readSize;
			if (!keyToJumpMap.TryGetValue(value, out value))
			{
				value = -1;
			}
			OnlineChallengeEvent result = null;
			switch (value)
			{
			case 0:
				result = DeserializeBaseType(bytes, offset, formatterResolver, out readSize);
				offset += readSize;
				break;
			case 1:
				result = formatterResolver.GetFormatterWithVerify<OnlineChallengeEventScore>().Deserialize(bytes, offset, formatterResolver, out readSize);
				offset += readSize;
				break;
			case 2:
				result = formatterResolver.GetFormatterWithVerify<OnlineChallengeEventInt>().Deserialize(bytes, offset, formatterResolver, out readSize);
				offset += readSize;
				break;
			case 3:
				result = formatterResolver.GetFormatterWithVerify<OnlineChallengeEventString>().Deserialize(bytes, offset, formatterResolver, out readSize);
				offset += readSize;
				break;
			case 4:
				result = formatterResolver.GetFormatterWithVerify<OnlineChallengeEventFloat>().Deserialize(bytes, offset, formatterResolver, out readSize);
				offset += readSize;
				break;
			case 5:
				result = formatterResolver.GetFormatterWithVerify<OnlineChallengeEventHospitalStatus>().Deserialize(bytes, offset, formatterResolver, out readSize);
				offset += readSize;
				break;
			default:
				offset += MessagePackBinary.ReadNextBlock(bytes, offset);
				break;
			}
			readSize = offset - num;
			return result;
		}

		public OnlineChallengeEvent DeserializeBaseType(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
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
