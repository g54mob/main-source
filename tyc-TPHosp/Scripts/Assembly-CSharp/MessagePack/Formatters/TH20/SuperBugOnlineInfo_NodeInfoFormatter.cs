using System;
using System.Collections.Generic;
using MessagePack.Internal;
using TH20;

namespace MessagePack.Formatters.TH20
{
	public sealed class SuperBugOnlineInfo_NodeInfoFormatter : IMessagePackFormatter<SuperBugOnlineInfo.NodeInfo>, IMessagePackFormatter
	{
		private readonly AutomataDictionary ____keyMapping;

		private readonly byte[][] ____stringByteKeys;

		public SuperBugOnlineInfo_NodeInfoFormatter()
		{
			____keyMapping = new AutomataDictionary
			{
				{ "NodeID", 0 },
				{ "Children", 1 },
				{ "PosX", 2 },
				{ "PosY", 3 },
				{ "IconID", 4 },
				{ "ObjectiveDefinitionID", 5 },
				{ "VictoryTypeID", 6 },
				{ "CompletionsRequired", 7 },
				{ "CommunityContribution", 8 },
				{ "Rewards", 9 },
				{ "RewardInfoID", 10 }
			};
			____stringByteKeys = new byte[11][]
			{
				MessagePackBinary.GetEncodedStringBytes("NodeID"),
				MessagePackBinary.GetEncodedStringBytes("Children"),
				MessagePackBinary.GetEncodedStringBytes("PosX"),
				MessagePackBinary.GetEncodedStringBytes("PosY"),
				MessagePackBinary.GetEncodedStringBytes("IconID"),
				MessagePackBinary.GetEncodedStringBytes("ObjectiveDefinitionID"),
				MessagePackBinary.GetEncodedStringBytes("VictoryTypeID"),
				MessagePackBinary.GetEncodedStringBytes("CompletionsRequired"),
				MessagePackBinary.GetEncodedStringBytes("CommunityContribution"),
				MessagePackBinary.GetEncodedStringBytes("Rewards"),
				MessagePackBinary.GetEncodedStringBytes("RewardInfoID")
			};
		}

		public int Serialize(ref byte[] bytes, int offset, SuperBugOnlineInfo.NodeInfo value, IFormatterResolver formatterResolver)
		{
			if (value == null)
			{
				return MessagePackBinary.WriteNil(ref bytes, offset);
			}
			int num = offset;
			offset += MessagePackBinary.WriteFixedMapHeaderUnsafe(ref bytes, offset, 11);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[0]);
			offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.NodeID);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[1]);
			offset += formatterResolver.GetFormatterWithVerify<List<int>>().Serialize(ref bytes, offset, value.Children, formatterResolver);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[2]);
			offset += MessagePackBinary.WriteSingle(ref bytes, offset, value.PosX);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[3]);
			offset += MessagePackBinary.WriteSingle(ref bytes, offset, value.PosY);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[4]);
			offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.IconID);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[5]);
			offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.ObjectiveDefinitionID);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[6]);
			offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.VictoryTypeID);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[7]);
			offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.CompletionsRequired);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[8]);
			offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.CommunityContribution);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[9]);
			offset += formatterResolver.GetFormatterWithVerify<List<SuperBugOnlineInfo.RewardInfo>>().Serialize(ref bytes, offset, value.Rewards, formatterResolver);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[10]);
			offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.RewardInfoID);
			return offset - num;
		}

		public SuperBugOnlineInfo.NodeInfo Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			if (MessagePackBinary.IsNil(bytes, offset))
			{
				readSize = 1;
				return null;
			}
			int num = offset;
			int num2 = MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
			offset += readSize;
			int nodeID = 0;
			List<int> children = null;
			float posX = 0f;
			float posY = 0f;
			int iconID = 0;
			int objectiveDefinitionID = 0;
			int victoryTypeID = 0;
			int completionsRequired = 0;
			int communityContribution = 0;
			List<SuperBugOnlineInfo.RewardInfo> rewards = null;
			int rewardInfoID = 0;
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
						nodeID = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
						break;
					case 1:
						children = formatterResolver.GetFormatterWithVerify<List<int>>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					case 2:
						posX = MessagePackBinary.ReadSingle(bytes, offset, out readSize);
						break;
					case 3:
						posY = MessagePackBinary.ReadSingle(bytes, offset, out readSize);
						break;
					case 4:
						iconID = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
						break;
					case 5:
						objectiveDefinitionID = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
						break;
					case 6:
						victoryTypeID = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
						break;
					case 7:
						completionsRequired = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
						break;
					case 8:
						communityContribution = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
						break;
					case 9:
						rewards = formatterResolver.GetFormatterWithVerify<List<SuperBugOnlineInfo.RewardInfo>>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					case 10:
						rewardInfoID = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
						break;
					default:
						readSize = MessagePackBinary.ReadNextBlock(bytes, offset);
						break;
					}
				}
				offset += readSize;
			}
			readSize = offset - num;
			return new SuperBugOnlineInfo.NodeInfo
			{
				NodeID = nodeID,
				Children = children,
				PosX = posX,
				PosY = posY,
				IconID = iconID,
				ObjectiveDefinitionID = objectiveDefinitionID,
				VictoryTypeID = victoryTypeID,
				CompletionsRequired = completionsRequired,
				CommunityContribution = communityContribution,
				Rewards = rewards,
				RewardInfoID = rewardInfoID
			};
		}
	}
}
