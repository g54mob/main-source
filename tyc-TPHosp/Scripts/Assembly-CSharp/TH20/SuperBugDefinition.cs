using System.Collections.Generic;
using FullInspector.Generated.SharedInstance;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SuperBugDefinition
	{
		public int Version;

		public int SuperBugID;

		public LocalisedString Name;

		public LocalisedString LeaderName;

		public LocalisedString Description;

		public LocalisedString IntroLetterText;

		public LocalisedString CompletedLetterText;

		public uint ExpiryTimeStamp;

		public List<SuperBugNode> Network;

		public static SuperBugDefinition Create(SuperBugOnlineInfo info, App app)
		{
			SuperBugDefinition superBugDefinition = new SuperBugDefinition();
			superBugDefinition.Name = new LocalisedString(info.NameTerm);
			superBugDefinition.LeaderName = new LocalisedString(info.LeaderTerm);
			superBugDefinition.Description = new LocalisedString(info.DescriptionTerm);
			superBugDefinition.IntroLetterText = new LocalisedString(info.IntroLetterTerm);
			superBugDefinition.CompletedLetterText = new LocalisedString(info.CompletedLetterTerm);
			superBugDefinition.Version = info.Version;
			superBugDefinition.SuperBugID = info.SuperBugID;
			superBugDefinition.ExpiryTimeStamp = info.ExpiryTimeStamp;
			superBugDefinition.Network = new List<SuperBugNode>();
			foreach (SuperBugOnlineInfo.NodeInfo node in info.Nodes)
			{
				Sprite objectFromAssetID = GetObjectFromAssetID<Sprite>(node.IconID, app.AssetIDs);
				SuperBugObjectiveDefinition objectFromAssetID2 = GetObjectFromAssetID<SuperBugObjectiveDefinition>(node.ObjectiveDefinitionID, app.AssetIDs);
				SuperBugNodeRewardInfo objectFromAssetID3 = GetObjectFromAssetID<SuperBugNodeRewardInfo>(node.RewardInfoID, app.AssetIDs);
				ResearchNodeDefinition researchNodeDefinition = new ResearchNodeDefinition();
				researchNodeDefinition.Icon = objectFromAssetID;
				researchNodeDefinition.CompletionsRequired = node.CompletionsRequired;
				researchNodeDefinition.Objective = objectFromAssetID2;
				SuperBugNode superBugNode = new SuperBugNode();
				superBugNode.SetDefinition(researchNodeDefinition);
				superBugNode.SetIsVictoryNode((CollaborativeNode.VictoryNodeType)node.VictoryTypeID);
				superBugNode.NodeID = node.NodeID;
				superBugNode.Children = new List<int>(node.Children);
				superBugNode.Position = new Vector2(node.PosX, node.PosY);
				superBugNode.ProgressBoost = node.CommunityContribution;
				superBugNode.RewardInfo = objectFromAssetID3;
				List<IRewardMetagame> list = new List<IRewardMetagame>();
				if (node.Rewards != null)
				{
					foreach (SuperBugOnlineInfo.RewardInfo reward in node.Rewards)
					{
						IRewardMetagame rewardMetagame = null;
						if (reward.Reward is SuperBugRewardRoomItem)
						{
							rewardMetagame = RewardRoomItemMetagame.Create(GetObjectFromAssetID<SharedInstance_TH20TH20_RoomItemDefinition>((reward.Reward as SuperBugRewardRoomItem).RoomItemID, app.AssetIDs));
						}
						else if (reward.Reward is SuperBugRewardDeveloperPromise)
						{
							rewardMetagame = RewardDeveloperPromise.Create((reward.Reward as SuperBugRewardDeveloperPromise).Promise);
						}
						else if (reward.Reward is SuperBugRewardKudosh)
						{
							rewardMetagame = RewardSilver.Create((reward.Reward as SuperBugRewardKudosh).KudoshAmount);
						}
						if (rewardMetagame != null)
						{
							list.Add(rewardMetagame);
						}
					}
				}
				if (list.Count > 0)
				{
					superBugNode.Rewards = list;
				}
				else
				{
					superBugNode.Rewards = null;
				}
				superBugDefinition.Network.Add(superBugNode);
			}
			return superBugDefinition;
		}

		private static T GetObjectFromAssetID<T>(int assetID, BiDictionary<int, object> assetIdMapping)
		{
			assetIdMapping.TryGetValue(assetID, out var value);
			return (T)value;
		}

		public List<SuperBugNode> GatherVictoryNodes()
		{
			List<SuperBugNode> list = new List<SuperBugNode>();
			for (int i = 0; i < Network.Count; i++)
			{
				SuperBugNode superBugNode = Network[i];
				if (superBugNode.IsVictoryNode)
				{
					list.Add(superBugNode);
				}
			}
			return list;
		}
	}
}
