using System;
using System.Collections.Generic;
using MessagePack.Internal;
using TH20;

namespace MessagePack.Formatters.TH20
{
	public sealed class SuperBugRewardFormatter : IMessagePackFormatter<SuperBugReward>, IMessagePackFormatter
	{
		private readonly Dictionary<RuntimeTypeHandle, KeyValuePair<int, int>> typeToKeyAndJumpMap;

		private readonly Dictionary<int, int> keyToJumpMap;

		public SuperBugRewardFormatter()
		{
			typeToKeyAndJumpMap = new Dictionary<RuntimeTypeHandle, KeyValuePair<int, int>>(3, RuntimeTypeHandleEqualityComparer.Default)
			{
				{
					typeof(SuperBugRewardKudosh).TypeHandle,
					new KeyValuePair<int, int>(0, 0)
				},
				{
					typeof(SuperBugRewardRoomItem).TypeHandle,
					new KeyValuePair<int, int>(1, 1)
				},
				{
					typeof(SuperBugRewardDeveloperPromise).TypeHandle,
					new KeyValuePair<int, int>(2, 2)
				}
			};
			keyToJumpMap = new Dictionary<int, int>(3)
			{
				{ 0, 0 },
				{ 1, 1 },
				{ 2, 2 }
			};
		}

		public int Serialize(ref byte[] bytes, int offset, SuperBugReward value, IFormatterResolver formatterResolver)
		{
			if (value != null && typeToKeyAndJumpMap.TryGetValue(value.GetType().TypeHandle, out var value2))
			{
				int num = offset;
				offset += MessagePackBinary.WriteFixedArrayHeaderUnsafe(ref bytes, offset, 2);
				offset += MessagePackBinary.WriteInt32(ref bytes, offset, value2.Key);
				switch (value2.Value)
				{
				case 0:
					offset += formatterResolver.GetFormatterWithVerify<SuperBugRewardKudosh>().Serialize(ref bytes, offset, (SuperBugRewardKudosh)value, formatterResolver);
					break;
				case 1:
					offset += formatterResolver.GetFormatterWithVerify<SuperBugRewardRoomItem>().Serialize(ref bytes, offset, (SuperBugRewardRoomItem)value, formatterResolver);
					break;
				case 2:
					offset += formatterResolver.GetFormatterWithVerify<SuperBugRewardDeveloperPromise>().Serialize(ref bytes, offset, (SuperBugRewardDeveloperPromise)value, formatterResolver);
					break;
				}
				return offset - num;
			}
			return MessagePackBinary.WriteNil(ref bytes, offset);
		}

		public SuperBugReward Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			if (MessagePackBinary.IsNil(bytes, offset))
			{
				readSize = 1;
				return null;
			}
			int num = offset;
			if (MessagePackBinary.ReadArrayHeader(bytes, offset, out readSize) != 2)
			{
				throw new InvalidOperationException("Invalid Union data was detected. Type:global::TH20.SuperBugReward");
			}
			offset += readSize;
			int value = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
			offset += readSize;
			if (!keyToJumpMap.TryGetValue(value, out value))
			{
				value = -1;
			}
			SuperBugReward result = null;
			switch (value)
			{
			case 0:
				result = formatterResolver.GetFormatterWithVerify<SuperBugRewardKudosh>().Deserialize(bytes, offset, formatterResolver, out readSize);
				offset += readSize;
				break;
			case 1:
				result = formatterResolver.GetFormatterWithVerify<SuperBugRewardRoomItem>().Deserialize(bytes, offset, formatterResolver, out readSize);
				offset += readSize;
				break;
			case 2:
				result = formatterResolver.GetFormatterWithVerify<SuperBugRewardDeveloperPromise>().Deserialize(bytes, offset, formatterResolver, out readSize);
				offset += readSize;
				break;
			default:
				offset += MessagePackBinary.ReadNextBlock(bytes, offset);
				break;
			}
			readSize = offset - num;
			return result;
		}
	}
}
