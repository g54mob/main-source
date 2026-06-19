using System.Collections.Generic;
using FullInspector;
using MessagePack;

namespace TH20
{
	[MessagePackObject(false)]
	public class SuperBugOnlineInfo
	{
		[MessagePackObject(false)]
		public class NodeInfo
		{
			[Key(0)]
			public int NodeID;

			[Key(1)]
			public List<int> Children = new List<int>();

			[Key(2)]
			public float PosX;

			[Key(3)]
			public float PosY;

			[Key(4)]
			public int IconID;

			[Key(5)]
			public int ObjectiveDefinitionID;

			[Key(6)]
			public int VictoryTypeID;

			[Key(7)]
			public int CompletionsRequired;

			[Key(8)]
			public int CommunityContribution;

			[Key(9)]
			public List<RewardInfo> Rewards = new List<RewardInfo>();

			[Key(10)]
			public int RewardInfoID;
		}

		[MessagePackObject(false)]
		public class RewardInfo
		{
			[Key(0)]
			public SuperBugReward Reward;
		}

		[Key(0)]
		public int Version;

		[Key(1)]
		public int SuperBugID;

		[Key(2)]
		public string NameTerm;

		[Key(3)]
		public string LeaderTerm;

		[Key(5)]
		public List<NodeInfo> Nodes = new List<NodeInfo>();

		[Key(6)]
		public uint ExpiryTimeStamp;

		[Key(7)]
		public string DescriptionTerm;

		[Key(8)]
		public string IntroLetterTerm;

		[Key(9)]
		public string CompletedLetterTerm;

		public static SuperBugOnlineInfo Create(SuperBugDefinition definition, App app)
		{
			SuperBugOnlineInfo superBugOnlineInfo = new SuperBugOnlineInfo();
			superBugOnlineInfo.NameTerm = definition.Name.Term;
			superBugOnlineInfo.LeaderTerm = definition.LeaderName.Term;
			superBugOnlineInfo.DescriptionTerm = definition.Description.Term;
			superBugOnlineInfo.IntroLetterTerm = definition.IntroLetterText.Term;
			superBugOnlineInfo.CompletedLetterTerm = definition.CompletedLetterText.Term;
			superBugOnlineInfo.SuperBugID = definition.SuperBugID;
			superBugOnlineInfo.Version = definition.Version;
			superBugOnlineInfo.ExpiryTimeStamp = definition.ExpiryTimeStamp;
			foreach (SuperBugNode item in definition.Network)
			{
				int assetID = 0;
				int assetID2 = 0;
				if (item.Definition != null && !GetAssetIDForObject(app.AssetIDs, item.Definition.Icon, out assetID))
				{
					assetID = 0;
				}
				if (item.Definition != null && !GetAssetIDForObject(app.AssetIDs, item.Definition.Objective, out assetID2))
				{
					assetID2 = 0;
				}
				NodeInfo nodeInfo = new NodeInfo();
				nodeInfo.NodeID = item.NodeID;
				nodeInfo.Children = new List<int>(item.Children);
				nodeInfo.PosX = item.Position.x;
				nodeInfo.PosY = item.Position.y;
				nodeInfo.CompletionsRequired = item.CompletionsRequired;
				nodeInfo.CommunityContribution = item.ProgressBoost;
				nodeInfo.IconID = assetID;
				nodeInfo.ObjectiveDefinitionID = assetID2;
				nodeInfo.VictoryTypeID = (int)item.VictoryType;
				nodeInfo.RewardInfoID = ((IObjectWithID)item.RewardInfo)?.ID ?? 0;
				List<RewardInfo> list = new List<RewardInfo>();
				if (item.Rewards != null)
				{
					foreach (IRewardMetagame reward in item.Rewards)
					{
						SuperBugReward superBugReward = null;
						if (reward is RewardRoomItemMetagame)
						{
							SharedInstance<RoomItemDefinition> definition2 = (reward as RewardRoomItemMetagame).Definition;
							superBugReward = new SuperBugRewardRoomItem
							{
								RoomItemID = definition2.GetID
							};
						}
						else if (reward is RewardSilver)
						{
							int amount = (reward as RewardSilver).Amount;
							superBugReward = new SuperBugRewardKudosh
							{
								KudoshAmount = amount
							};
						}
						else if (reward is RewardDeveloperPromise)
						{
							string promiseText = (reward as RewardDeveloperPromise).PromiseText;
							superBugReward = new SuperBugRewardDeveloperPromise
							{
								Promise = promiseText
							};
						}
						if (superBugReward != null)
						{
							list.Add(new RewardInfo
							{
								Reward = superBugReward
							});
						}
					}
				}
				if (list.Count > 0)
				{
					nodeInfo.Rewards = list;
				}
				else
				{
					nodeInfo.Rewards = null;
				}
				superBugOnlineInfo.Nodes.Add(nodeInfo);
			}
			return superBugOnlineInfo;
		}

		private static bool GetAssetIDForObject(BiDictionary<int, object> assetIdMapping, object obj, out int assetID)
		{
			if (obj == null)
			{
				assetID = 0;
				return true;
			}
			return assetIdMapping.SecondToFirst.TryGetValue(obj, out assetID);
		}
	}
}
