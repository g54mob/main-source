using System;
using System.Collections.Generic;
using MessagePack.Internal;
using TH20;

namespace MessagePack.Formatters.TH20
{
	public sealed class IOnlineSerializableFormatter : IMessagePackFormatter<OnlineManager.IOnlineSerializable>, IMessagePackFormatter
	{
		private readonly Dictionary<RuntimeTypeHandle, KeyValuePair<int, int>> typeToKeyAndJumpMap;

		private readonly Dictionary<int, int> keyToJumpMap;

		public IOnlineSerializableFormatter()
		{
			typeToKeyAndJumpMap = new Dictionary<RuntimeTypeHandle, KeyValuePair<int, int>>(1, RuntimeTypeHandleEqualityComparer.Default) { 
			{
				typeof(OnlineChallengeData).TypeHandle,
				new KeyValuePair<int, int>(0, 0)
			} };
			keyToJumpMap = new Dictionary<int, int>(1) { { 0, 0 } };
		}

		public int Serialize(ref byte[] bytes, int offset, OnlineManager.IOnlineSerializable value, IFormatterResolver formatterResolver)
		{
			if (value != null && typeToKeyAndJumpMap.TryGetValue(value.GetType().TypeHandle, out var value2))
			{
				int num = offset;
				offset += MessagePackBinary.WriteFixedArrayHeaderUnsafe(ref bytes, offset, 2);
				offset += MessagePackBinary.WriteInt32(ref bytes, offset, value2.Key);
				if (value2.Value == 0)
				{
					offset += formatterResolver.GetFormatterWithVerify<OnlineChallengeData>().Serialize(ref bytes, offset, (OnlineChallengeData)value, formatterResolver);
				}
				return offset - num;
			}
			return MessagePackBinary.WriteNil(ref bytes, offset);
		}

		public OnlineManager.IOnlineSerializable Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			if (MessagePackBinary.IsNil(bytes, offset))
			{
				readSize = 1;
				return null;
			}
			int num = offset;
			if (MessagePackBinary.ReadArrayHeader(bytes, offset, out readSize) != 2)
			{
				throw new InvalidOperationException("Invalid Union data was detected. Type:global::TH20.OnlineManager.IOnlineSerializable");
			}
			offset += readSize;
			int value = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
			offset += readSize;
			if (!keyToJumpMap.TryGetValue(value, out value))
			{
				value = -1;
			}
			OnlineManager.IOnlineSerializable result = null;
			if (value == 0)
			{
				result = formatterResolver.GetFormatterWithVerify<OnlineChallengeData>().Deserialize(bytes, offset, formatterResolver, out readSize);
				offset += readSize;
			}
			else
			{
				offset += MessagePackBinary.ReadNextBlock(bytes, offset);
			}
			readSize = offset - num;
			return result;
		}
	}
}
