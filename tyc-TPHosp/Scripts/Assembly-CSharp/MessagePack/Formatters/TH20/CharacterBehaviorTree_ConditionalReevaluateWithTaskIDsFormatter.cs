using System;
using BehaviorDesigner.Runtime.Tasks;
using MessagePack.Internal;
using TH20;

namespace MessagePack.Formatters.TH20
{
	public sealed class CharacterBehaviorTree_ConditionalReevaluateWithTaskIDsFormatter : IMessagePackFormatter<CharacterBehaviorTree.ConditionalReevaluateWithTaskIDs>, IMessagePackFormatter
	{
		private readonly AutomataDictionary ____keyMapping;

		private readonly byte[][] ____stringByteKeys;

		public CharacterBehaviorTree_ConditionalReevaluateWithTaskIDsFormatter()
		{
			____keyMapping = new AutomataDictionary
			{
				{ "ID", 0 },
				{ "taskStatus", 1 },
				{ "compositeID", 2 },
				{ "stackIndex", 3 }
			};
			____stringByteKeys = new byte[4][]
			{
				MessagePackBinary.GetEncodedStringBytes("ID"),
				MessagePackBinary.GetEncodedStringBytes("taskStatus"),
				MessagePackBinary.GetEncodedStringBytes("compositeID"),
				MessagePackBinary.GetEncodedStringBytes("stackIndex")
			};
		}

		public int Serialize(ref byte[] bytes, int offset, CharacterBehaviorTree.ConditionalReevaluateWithTaskIDs value, IFormatterResolver formatterResolver)
		{
			int num = offset;
			offset += MessagePackBinary.WriteFixedMapHeaderUnsafe(ref bytes, offset, 4);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[0]);
			offset += MessagePackBinary.WriteUInt64(ref bytes, offset, value.ID);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[1]);
			offset += formatterResolver.GetFormatterWithVerify<TaskStatus>().Serialize(ref bytes, offset, value.taskStatus, formatterResolver);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[2]);
			offset += MessagePackBinary.WriteUInt64(ref bytes, offset, value.compositeID);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[3]);
			offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.stackIndex);
			return offset - num;
		}

		public CharacterBehaviorTree.ConditionalReevaluateWithTaskIDs Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			if (MessagePackBinary.IsNil(bytes, offset))
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			int num = offset;
			int num2 = MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
			offset += readSize;
			ulong iD = 0uL;
			TaskStatus taskStatus = TaskStatus.Inactive;
			ulong compositeID = 0uL;
			int stackIndex = 0;
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
						iD = MessagePackBinary.ReadUInt64(bytes, offset, out readSize);
						break;
					case 1:
						taskStatus = formatterResolver.GetFormatterWithVerify<TaskStatus>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					case 2:
						compositeID = MessagePackBinary.ReadUInt64(bytes, offset, out readSize);
						break;
					case 3:
						stackIndex = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
						break;
					default:
						readSize = MessagePackBinary.ReadNextBlock(bytes, offset);
						break;
					}
				}
				offset += readSize;
			}
			readSize = offset - num;
			return new CharacterBehaviorTree.ConditionalReevaluateWithTaskIDs
			{
				ID = iD,
				taskStatus = taskStatus,
				compositeID = compositeID,
				stackIndex = stackIndex
			};
		}
	}
}
