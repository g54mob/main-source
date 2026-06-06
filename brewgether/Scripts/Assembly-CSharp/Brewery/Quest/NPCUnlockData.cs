using System;
using UnityEngine;

namespace Brewery.Quest
{
	[Serializable]
	public class NPCUnlockData
	{
		[Tooltip("NPC ID (must match TradingNPCController.NPCId)")]
		public string npcId;

		[Tooltip("NPC ID whose quests must ALL be completed to unlock this NPC (empty = always available)")]
		public string prerequisiteNpcId;

		[Tooltip("Display name for UI (optional, for readability in editor)")]
		public string displayName;

		public NPCUnlockData(string npcId, string prerequisiteNpcId, string displayName = "")
		{
		}
	}
}
