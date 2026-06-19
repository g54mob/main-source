using System;
using System.Collections.Generic;
using MessagePack.Internal;
using TH20;

namespace MessagePack.Formatters.TH20
{
	public sealed class SuperBugRewardRecord_ItemFormatter : IMessagePackFormatter<SuperBugRewardRecord.Item>, IMessagePackFormatter
	{
		private readonly AutomataDictionary ____keyMapping;

		private readonly byte[][] ____stringByteKeys;

		public SuperBugRewardRecord_ItemFormatter()
		{
			____keyMapping = new AutomataDictionary
			{
				{ "SuperBugID", 0 },
				{ "VictoryNodes", 1 }
			};
			____stringByteKeys = new byte[2][]
			{
				MessagePackBinary.GetEncodedStringBytes("SuperBugID"),
				MessagePackBinary.GetEncodedStringBytes("VictoryNodes")
			};
		}

		public int Serialize(ref byte[] bytes, int offset, SuperBugRewardRecord.Item value, IFormatterResolver formatterResolver)
		{
			if (value == null)
			{
				return MessagePackBinary.WriteNil(ref bytes, offset);
			}
			int num = offset;
			offset += MessagePackBinary.WriteFixedMapHeaderUnsafe(ref bytes, offset, 2);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[0]);
			offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.SuperBugID);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[1]);
			offset += formatterResolver.GetFormatterWithVerify<HashSet<CollaborativeNode.VictoryNodeType>>().Serialize(ref bytes, offset, value.VictoryNodes, formatterResolver);
			return offset - num;
		}

		public SuperBugRewardRecord.Item Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			if (MessagePackBinary.IsNil(bytes, offset))
			{
				readSize = 1;
				return null;
			}
			int num = offset;
			int num2 = MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
			offset += readSize;
			int superBugID = 0;
			HashSet<CollaborativeNode.VictoryNodeType> victoryNodes = null;
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
						superBugID = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
						break;
					case 1:
						victoryNodes = formatterResolver.GetFormatterWithVerify<HashSet<CollaborativeNode.VictoryNodeType>>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					default:
						readSize = MessagePackBinary.ReadNextBlock(bytes, offset);
						break;
					}
				}
				offset += readSize;
			}
			readSize = offset - num;
			return new SuperBugRewardRecord.Item
			{
				SuperBugID = superBugID,
				VictoryNodes = victoryNodes
			};
		}
	}
}
