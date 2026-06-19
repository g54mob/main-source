using System;
using System.Collections.Generic;
using MessagePack.Internal;
using TH20;

namespace MessagePack.Formatters.TH20
{
	public sealed class SuperBugOnlineInfoFormatter : IMessagePackFormatter<SuperBugOnlineInfo>, IMessagePackFormatter
	{
		private readonly AutomataDictionary ____keyMapping;

		private readonly byte[][] ____stringByteKeys;

		public SuperBugOnlineInfoFormatter()
		{
			____keyMapping = new AutomataDictionary
			{
				{ "Version", 0 },
				{ "SuperBugID", 1 },
				{ "NameTerm", 2 },
				{ "LeaderTerm", 3 },
				{ "Nodes", 4 },
				{ "ExpiryTimeStamp", 5 },
				{ "DescriptionTerm", 6 },
				{ "IntroLetterTerm", 7 },
				{ "CompletedLetterTerm", 8 }
			};
			____stringByteKeys = new byte[9][]
			{
				MessagePackBinary.GetEncodedStringBytes("Version"),
				MessagePackBinary.GetEncodedStringBytes("SuperBugID"),
				MessagePackBinary.GetEncodedStringBytes("NameTerm"),
				MessagePackBinary.GetEncodedStringBytes("LeaderTerm"),
				MessagePackBinary.GetEncodedStringBytes("Nodes"),
				MessagePackBinary.GetEncodedStringBytes("ExpiryTimeStamp"),
				MessagePackBinary.GetEncodedStringBytes("DescriptionTerm"),
				MessagePackBinary.GetEncodedStringBytes("IntroLetterTerm"),
				MessagePackBinary.GetEncodedStringBytes("CompletedLetterTerm")
			};
		}

		public int Serialize(ref byte[] bytes, int offset, SuperBugOnlineInfo value, IFormatterResolver formatterResolver)
		{
			if (value == null)
			{
				return MessagePackBinary.WriteNil(ref bytes, offset);
			}
			int num = offset;
			offset += MessagePackBinary.WriteFixedMapHeaderUnsafe(ref bytes, offset, 9);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[0]);
			offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.Version);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[1]);
			offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.SuperBugID);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[2]);
			offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.NameTerm, formatterResolver);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[3]);
			offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.LeaderTerm, formatterResolver);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[4]);
			offset += formatterResolver.GetFormatterWithVerify<List<SuperBugOnlineInfo.NodeInfo>>().Serialize(ref bytes, offset, value.Nodes, formatterResolver);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[5]);
			offset += MessagePackBinary.WriteUInt32(ref bytes, offset, value.ExpiryTimeStamp);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[6]);
			offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.DescriptionTerm, formatterResolver);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[7]);
			offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.IntroLetterTerm, formatterResolver);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[8]);
			offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.CompletedLetterTerm, formatterResolver);
			return offset - num;
		}

		public SuperBugOnlineInfo Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			if (MessagePackBinary.IsNil(bytes, offset))
			{
				readSize = 1;
				return null;
			}
			int num = offset;
			int num2 = MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
			offset += readSize;
			int version = 0;
			int superBugID = 0;
			string nameTerm = null;
			string leaderTerm = null;
			List<SuperBugOnlineInfo.NodeInfo> nodes = null;
			uint expiryTimeStamp = 0u;
			string descriptionTerm = null;
			string introLetterTerm = null;
			string completedLetterTerm = null;
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
						version = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
						break;
					case 1:
						superBugID = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
						break;
					case 2:
						nameTerm = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					case 3:
						leaderTerm = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					case 4:
						nodes = formatterResolver.GetFormatterWithVerify<List<SuperBugOnlineInfo.NodeInfo>>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					case 5:
						expiryTimeStamp = MessagePackBinary.ReadUInt32(bytes, offset, out readSize);
						break;
					case 6:
						descriptionTerm = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					case 7:
						introLetterTerm = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					case 8:
						completedLetterTerm = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					default:
						readSize = MessagePackBinary.ReadNextBlock(bytes, offset);
						break;
					}
				}
				offset += readSize;
			}
			readSize = offset - num;
			return new SuperBugOnlineInfo
			{
				Version = version,
				SuperBugID = superBugID,
				NameTerm = nameTerm,
				LeaderTerm = leaderTerm,
				Nodes = nodes,
				ExpiryTimeStamp = expiryTimeStamp,
				DescriptionTerm = descriptionTerm,
				IntroLetterTerm = introLetterTerm,
				CompletedLetterTerm = completedLetterTerm
			};
		}
	}
}
