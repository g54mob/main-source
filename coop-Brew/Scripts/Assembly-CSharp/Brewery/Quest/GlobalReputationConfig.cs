using System.Collections.Generic;
using UnityEngine;

namespace Brewery.Quest
{
	[CreateAssetMenu(fileName = "GlobalReputationConfig", menuName = "Quest/Global Reputation Config", order = 0)]
	public class GlobalReputationConfig : ScriptableObject
	{
		[Header("NPC Unlock Chain")]
		[Tooltip("Defines the linear chain of NPC quest unlocks. Each NPC's quests unlock when all quests from the prerequisite NPC are completed.")]
		public List<NPCUnlockData> npcUnlockChain;

		public string GetPrerequisiteNpcId(string npcId)
		{
			return null;
		}

		public bool IsNPCUnlocked(string npcId)
		{
			return false;
		}

		private bool AreAllNPCQuestsCompleted(string npcId)
		{
			return false;
		}

		public string GetPrerequisiteNpcDisplayName(string npcId)
		{
			return null;
		}
	}
}
