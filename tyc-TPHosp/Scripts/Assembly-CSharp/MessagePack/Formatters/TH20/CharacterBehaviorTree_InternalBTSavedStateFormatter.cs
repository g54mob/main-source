using System;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using MessagePack.Internal;
using TH20;

namespace MessagePack.Formatters.TH20
{
	public sealed class CharacterBehaviorTree_InternalBTSavedStateFormatter : IMessagePackFormatter<CharacterBehaviorTree.InternalBTSavedState>, IMessagePackFormatter
	{
		private readonly AutomataDictionary ____keyMapping;

		private readonly byte[][] ____stringByteKeys;

		public CharacterBehaviorTree_InternalBTSavedStateFormatter()
		{
			____keyMapping = new AutomataDictionary
			{
				{ "tasks", 0 },
				{ "activeStack", 1 },
				{ "nonInstantTaskStatus", 2 },
				{ "interruptionIndex", 3 },
				{ "conditionalReevaluate", 4 },
				{ "conditionalReevaluateMap", 5 },
				{ "parentReevaluate", 6 },
				{ "behaviourName", 7 }
			};
			____stringByteKeys = new byte[8][]
			{
				MessagePackBinary.GetEncodedStringBytes("tasks"),
				MessagePackBinary.GetEncodedStringBytes("activeStack"),
				MessagePackBinary.GetEncodedStringBytes("nonInstantTaskStatus"),
				MessagePackBinary.GetEncodedStringBytes("interruptionIndex"),
				MessagePackBinary.GetEncodedStringBytes("conditionalReevaluate"),
				MessagePackBinary.GetEncodedStringBytes("conditionalReevaluateMap"),
				MessagePackBinary.GetEncodedStringBytes("parentReevaluate"),
				MessagePackBinary.GetEncodedStringBytes("behaviourName")
			};
		}

		public int Serialize(ref byte[] bytes, int offset, CharacterBehaviorTree.InternalBTSavedState value, IFormatterResolver formatterResolver)
		{
			if (value == null)
			{
				return MessagePackBinary.WriteNil(ref bytes, offset);
			}
			int num = offset;
			offset += MessagePackBinary.WriteFixedMapHeaderUnsafe(ref bytes, offset, 8);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[0]);
			offset += formatterResolver.GetFormatterWithVerify<Dictionary<ulong, byte[]>>().Serialize(ref bytes, offset, value.tasks, formatterResolver);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[1]);
			offset += formatterResolver.GetFormatterWithVerify<ulong[][]>().Serialize(ref bytes, offset, value.activeStack, formatterResolver);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[2]);
			offset += formatterResolver.GetFormatterWithVerify<List<TaskStatus>>().Serialize(ref bytes, offset, value.nonInstantTaskStatus, formatterResolver);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[3]);
			offset += formatterResolver.GetFormatterWithVerify<ulong[]>().Serialize(ref bytes, offset, value.interruptionIndex, formatterResolver);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[4]);
			offset += formatterResolver.GetFormatterWithVerify<CharacterBehaviorTree.ConditionalReevaluateWithTaskIDs[]>().Serialize(ref bytes, offset, value.conditionalReevaluate, formatterResolver);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[5]);
			offset += formatterResolver.GetFormatterWithVerify<Dictionary<ulong, CharacterBehaviorTree.ConditionalReevaluateWithTaskIDs>>().Serialize(ref bytes, offset, value.conditionalReevaluateMap, formatterResolver);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[6]);
			offset += formatterResolver.GetFormatterWithVerify<ulong[]>().Serialize(ref bytes, offset, value.parentReevaluate, formatterResolver);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[7]);
			offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.behaviourName, formatterResolver);
			return offset - num;
		}

		public CharacterBehaviorTree.InternalBTSavedState Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			if (MessagePackBinary.IsNil(bytes, offset))
			{
				readSize = 1;
				return null;
			}
			int num = offset;
			int num2 = MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
			offset += readSize;
			Dictionary<ulong, byte[]> tasks = null;
			ulong[][] activeStack = null;
			List<TaskStatus> nonInstantTaskStatus = null;
			ulong[] interruptionIndex = null;
			CharacterBehaviorTree.ConditionalReevaluateWithTaskIDs[] conditionalReevaluate = null;
			Dictionary<ulong, CharacterBehaviorTree.ConditionalReevaluateWithTaskIDs> conditionalReevaluateMap = null;
			ulong[] parentReevaluate = null;
			string behaviourName = null;
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
						tasks = formatterResolver.GetFormatterWithVerify<Dictionary<ulong, byte[]>>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					case 1:
						activeStack = formatterResolver.GetFormatterWithVerify<ulong[][]>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					case 2:
						nonInstantTaskStatus = formatterResolver.GetFormatterWithVerify<List<TaskStatus>>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					case 3:
						interruptionIndex = formatterResolver.GetFormatterWithVerify<ulong[]>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					case 4:
						conditionalReevaluate = formatterResolver.GetFormatterWithVerify<CharacterBehaviorTree.ConditionalReevaluateWithTaskIDs[]>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					case 5:
						conditionalReevaluateMap = formatterResolver.GetFormatterWithVerify<Dictionary<ulong, CharacterBehaviorTree.ConditionalReevaluateWithTaskIDs>>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					case 6:
						parentReevaluate = formatterResolver.GetFormatterWithVerify<ulong[]>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					case 7:
						behaviourName = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					default:
						readSize = MessagePackBinary.ReadNextBlock(bytes, offset);
						break;
					}
				}
				offset += readSize;
			}
			readSize = offset - num;
			return new CharacterBehaviorTree.InternalBTSavedState
			{
				tasks = tasks,
				activeStack = activeStack,
				nonInstantTaskStatus = nonInstantTaskStatus,
				interruptionIndex = interruptionIndex,
				conditionalReevaluate = conditionalReevaluate,
				conditionalReevaluateMap = conditionalReevaluateMap,
				parentReevaluate = parentReevaluate,
				behaviourName = behaviourName
			};
		}
	}
}
