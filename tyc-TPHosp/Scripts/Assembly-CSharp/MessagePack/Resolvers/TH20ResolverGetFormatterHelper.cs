using System;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using MessagePack.Formatters;
using MessagePack.Formatters.TH20;
using TH20;

namespace MessagePack.Resolvers
{
	internal static class TH20ResolverGetFormatterHelper
	{
		private static readonly Dictionary<Type, int> lookup;

		static TH20ResolverGetFormatterHelper()
		{
			lookup = new Dictionary<Type, int>(45)
			{
				{
					typeof(HashSet<CollaborativeNode.VictoryNodeType>),
					0
				},
				{
					typeof(List<string>),
					1
				},
				{
					typeof(List<string>[]),
					2
				},
				{
					typeof(List<uint>),
					3
				},
				{
					typeof(List<int>),
					4
				},
				{
					typeof(List<SuperBugOnlineInfo.RewardInfo>),
					5
				},
				{
					typeof(List<SuperBugOnlineInfo.NodeInfo>),
					6
				},
				{
					typeof(List<OnlineChallengeEvent>),
					7
				},
				{
					typeof(List<OnlineChallengeEventScore>),
					8
				},
				{
					typeof(List<OnlinePlayerID>),
					9
				},
				{
					typeof(Dictionary<ulong, byte[]>),
					10
				},
				{
					typeof(ulong[][]),
					11
				},
				{
					typeof(List<TaskStatus>),
					12
				},
				{
					typeof(CharacterBehaviorTree.ConditionalReevaluateWithTaskIDs[]),
					13
				},
				{
					typeof(Dictionary<ulong, CharacterBehaviorTree.ConditionalReevaluateWithTaskIDs>),
					14
				},
				{
					typeof(CollaborativeNode.VictoryNodeType),
					15
				},
				{
					typeof(OnlineChallengeEvent.Event),
					16
				},
				{
					typeof(ChallengeData),
					17
				},
				{
					typeof(OnlineManager.IOnlineSerializable),
					18
				},
				{
					typeof(SuperBugReward),
					19
				},
				{
					typeof(VersionNumber),
					20
				},
				{
					typeof(RoomTemplatesSaveHeader),
					21
				},
				{
					typeof(SuperBugRewardRecord),
					22
				},
				{
					typeof(SuperBugRewardRecord.Item),
					23
				},
				{
					typeof(UserProfileData),
					24
				},
				{
					typeof(SaveFileHeader),
					25
				},
				{
					typeof(OnlinePlayerID),
					26
				},
				{
					typeof(OnlineChallengeEvent),
					27
				},
				{
					typeof(OnlineChallengeEventScore),
					28
				},
				{
					typeof(OnlineChallengeEventFloat),
					29
				},
				{
					typeof(OnlineChallengeEventString),
					30
				},
				{
					typeof(OnlineChallengeEventInt),
					31
				},
				{
					typeof(OnlineChallengeEventHospitalStatus),
					32
				},
				{
					typeof(MetagameSaveHeader),
					33
				},
				{
					typeof(SuperBugRewardKudosh),
					34
				},
				{
					typeof(SuperBugRewardRoomItem),
					35
				},
				{
					typeof(SuperBugRewardDeveloperPromise),
					36
				},
				{
					typeof(SuperBugOnlineInfo.RewardInfo),
					37
				},
				{
					typeof(SuperBugOnlineInfo.NodeInfo),
					38
				},
				{
					typeof(SuperBugOnlineInfo),
					39
				},
				{
					typeof(AIChallengeData),
					40
				},
				{
					typeof(OnlineChallengeData),
					41
				},
				{
					typeof(CharacterBehaviorTree.ConditionalReevaluateWithTaskIDs),
					42
				},
				{
					typeof(CharacterBehaviorTree.InternalBTSavedState),
					43
				},
				{
					typeof(CloudData),
					44
				}
			};
		}

		internal static object GetFormatter(Type t)
		{
			if (!lookup.TryGetValue(t, out var value))
			{
				return null;
			}
			return value switch
			{
				0 => new HashSetFormatter<CollaborativeNode.VictoryNodeType>(), 
				1 => new ListFormatter<string>(), 
				2 => new ArrayFormatter<List<string>>(), 
				3 => new ListFormatter<uint>(), 
				4 => new ListFormatter<int>(), 
				5 => new ListFormatter<SuperBugOnlineInfo.RewardInfo>(), 
				6 => new ListFormatter<SuperBugOnlineInfo.NodeInfo>(), 
				7 => new ListFormatter<OnlineChallengeEvent>(), 
				8 => new ListFormatter<OnlineChallengeEventScore>(), 
				9 => new ListFormatter<OnlinePlayerID>(), 
				10 => new DictionaryFormatter<ulong, byte[]>(), 
				11 => new ArrayFormatter<ulong[]>(), 
				12 => new ListFormatter<TaskStatus>(), 
				13 => new ArrayFormatter<CharacterBehaviorTree.ConditionalReevaluateWithTaskIDs>(), 
				14 => new DictionaryFormatter<ulong, CharacterBehaviorTree.ConditionalReevaluateWithTaskIDs>(), 
				15 => new VictoryNodeTypeFormatter(), 
				16 => new EventFormatter(), 
				17 => new ChallengeDataFormatter(), 
				18 => new IOnlineSerializableFormatter(), 
				19 => new SuperBugRewardFormatter(), 
				20 => new VersionNumberFormatter(), 
				21 => new RoomTemplatesSaveHeaderFormatter(), 
				22 => new SuperBugRewardRecordFormatter(), 
				23 => new SuperBugRewardRecord_ItemFormatter(), 
				24 => new UserProfileDataFormatter(), 
				25 => new SaveFileHeaderFormatter(), 
				26 => new OnlinePlayerIDFormatter(), 
				27 => new MessagePack.Formatters.TH20.OnlineChallengeEventFormatter(), 
				28 => new OnlineChallengeEventScoreFormatter(), 
				29 => new OnlineChallengeEventFloatFormatter(), 
				30 => new OnlineChallengeEventStringFormatter(), 
				31 => new OnlineChallengeEventIntFormatter(), 
				32 => new OnlineChallengeEventHospitalStatusFormatter(), 
				33 => new MetagameSaveHeaderFormatter(), 
				34 => new SuperBugRewardKudoshFormatter(), 
				35 => new SuperBugRewardRoomItemFormatter(), 
				36 => new SuperBugRewardDeveloperPromiseFormatter(), 
				37 => new SuperBugOnlineInfo_RewardInfoFormatter(), 
				38 => new SuperBugOnlineInfo_NodeInfoFormatter(), 
				39 => new SuperBugOnlineInfoFormatter(), 
				40 => new AIChallengeDataFormatter(), 
				41 => new OnlineChallengeDataFormatter(), 
				42 => new CharacterBehaviorTree_ConditionalReevaluateWithTaskIDsFormatter(), 
				43 => new CharacterBehaviorTree_InternalBTSavedStateFormatter(), 
				44 => new CloudDataFormatter(), 
				_ => null, 
			};
		}
	}
}
