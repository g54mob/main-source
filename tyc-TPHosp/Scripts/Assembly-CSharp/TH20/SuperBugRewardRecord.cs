#define LOG_LEVEL_VERBOSE
using System.Collections.Generic;
using FullSerializer;
using MessagePack;
using UnityEngine;

namespace TH20
{
	[MessagePackObject(false)]
	public class SuperBugRewardRecord
	{
		[MessagePackObject(false)]
		public class Item
		{
			[Key(0)]
			[fsProperty("sid")]
			public int SuperBugID;

			[Key(1)]
			[fsProperty("svn")]
			public HashSet<CollaborativeNode.VictoryNodeType> VictoryNodes = new HashSet<CollaborativeNode.VictoryNodeType>();
		}

		[Key(0)]
		[SerializeField]
		[fsProperty("rr")]
		private Dictionary<int, Item> _rewardRecords = new Dictionary<int, Item>();

		public SuperBugRewardRecord()
		{
		}

		public SuperBugRewardRecord(SuperBugRewardRecord other)
		{
			foreach (KeyValuePair<int, Item> rewardRecord in other._rewardRecords)
			{
				Item item = new Item();
				foreach (CollaborativeNode.VictoryNodeType victoryNode in rewardRecord.Value.VictoryNodes)
				{
					item.VictoryNodes.Add(victoryNode);
				}
				item.SuperBugID = rewardRecord.Value.SuperBugID;
				_rewardRecords[rewardRecord.Key] = item;
			}
		}

		public bool SetReward(int superBugId, CollaborativeNode.VictoryNodeType victoryType)
		{
			Item value = null;
			_rewardRecords.TryGetValue(superBugId, out value);
			if (value == null)
			{
				value = new Item
				{
					SuperBugID = superBugId
				};
				_rewardRecords.Add(superBugId, value);
			}
			if (!value.VictoryNodes.Contains(victoryType))
			{
				value.VictoryNodes.Add(victoryType);
				Logging.Info(LogChannels.Online, "Super Bug Reward Collected: {0} {1}", superBugId, victoryType);
				return true;
			}
			return false;
		}

		public bool HasReward(int superBugId, CollaborativeNode.VictoryNodeType victoryType)
		{
			Item value = null;
			_rewardRecords.TryGetValue(superBugId, out value);
			return value?.VictoryNodes.Contains(victoryType) ?? false;
		}
	}
}
