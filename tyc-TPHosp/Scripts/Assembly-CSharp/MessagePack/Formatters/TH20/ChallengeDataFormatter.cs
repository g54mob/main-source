using System;
using System.Collections.Generic;
using MessagePack.Internal;
using TH20;

namespace MessagePack.Formatters.TH20
{
	public sealed class ChallengeDataFormatter : IMessagePackFormatter<ChallengeData>, IMessagePackFormatter
	{
		private readonly Dictionary<RuntimeTypeHandle, KeyValuePair<int, int>> typeToKeyAndJumpMap;

		private readonly Dictionary<int, int> keyToJumpMap;

		public ChallengeDataFormatter()
		{
			typeToKeyAndJumpMap = new Dictionary<RuntimeTypeHandle, KeyValuePair<int, int>>(2, RuntimeTypeHandleEqualityComparer.Default)
			{
				{
					typeof(OnlineChallengeData).TypeHandle,
					new KeyValuePair<int, int>(0, 0)
				},
				{
					typeof(AIChallengeData).TypeHandle,
					new KeyValuePair<int, int>(1, 1)
				}
			};
			keyToJumpMap = new Dictionary<int, int>(2)
			{
				{ 0, 0 },
				{ 1, 1 }
			};
		}

		public int Serialize(ref byte[] bytes, int offset, ChallengeData value, IFormatterResolver formatterResolver)
		{
			if (value != null && typeToKeyAndJumpMap.TryGetValue(value.GetType().TypeHandle, out var value2))
			{
				int num = offset;
				offset += MessagePackBinary.WriteFixedArrayHeaderUnsafe(ref bytes, offset, 2);
				offset += MessagePackBinary.WriteInt32(ref bytes, offset, value2.Key);
				switch (value2.Value)
				{
				case 0:
					offset += formatterResolver.GetFormatterWithVerify<OnlineChallengeData>().Serialize(ref bytes, offset, (OnlineChallengeData)value, formatterResolver);
					break;
				case 1:
					offset += formatterResolver.GetFormatterWithVerify<AIChallengeData>().Serialize(ref bytes, offset, (AIChallengeData)value, formatterResolver);
					break;
				}
				return offset - num;
			}
			return MessagePackBinary.WriteNil(ref bytes, offset);
		}

		public ChallengeData Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			if (MessagePackBinary.IsNil(bytes, offset))
			{
				readSize = 1;
				return null;
			}
			int num = offset;
			if (MessagePackBinary.ReadArrayHeader(bytes, offset, out readSize) != 2)
			{
				throw new InvalidOperationException("Invalid Union data was detected. Type:global::TH20.ChallengeData");
			}
			offset += readSize;
			int value = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
			offset += readSize;
			if (!keyToJumpMap.TryGetValue(value, out value))
			{
				value = -1;
			}
			ChallengeData result = null;
			switch (value)
			{
			case 0:
				result = formatterResolver.GetFormatterWithVerify<OnlineChallengeData>().Deserialize(bytes, offset, formatterResolver, out readSize);
				offset += readSize;
				break;
			case 1:
				result = formatterResolver.GetFormatterWithVerify<AIChallengeData>().Deserialize(bytes, offset, formatterResolver, out readSize);
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
