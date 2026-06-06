using System;
using System.Collections.Generic;
using UnityEngine;

namespace Brewery.Quest
{
	[CreateAssetMenu(fileName = "NewQuestGiver", menuName = "Quest/Quest Giver Profile", order = 2)]
	public class QuestGiverProfile : ScriptableObject
	{
		[Header("NPC Identity")]
		[Tooltip("Maps to TradingNPCController.NPCId or SimpleNPCController.NpcId")]
		public string npcId;

		[Tooltip("Display name for UI (optional, can use NPC's own name)")]
		public string displayName;

		[Header("Localization")]
		[SerializeField]
		private string displayNameKey;

		[Tooltip("Portrait image shown in quest dialogue UI")]
		public Sprite portrait;

		[Header("Quest Chains")]
		[Tooltip("Quest chains available from this NPC")]
		public List<QuestChain> questChains;

		public string GetDisplayName()
		{
			return null;
		}

		public QuestChain GetFirstAvailableQuest(Func<string, bool> isQuestAccepted, Func<string, bool> isQuestCompleted)
		{
			return null;
		}

		public List<(QuestChain, QuestAvailability)> GetAllQuestsWithStatus(Func<string, bool> isQuestAccepted, Func<string, bool> isQuestCompleted)
		{
			return null;
		}

		public bool HasAvailableQuest(Func<string, bool> isQuestAccepted, Func<string, bool> isQuestCompleted)
		{
			return false;
		}

		public bool HasQuestReadyForTurnIn(Func<string, int> getQuestStepIndex)
		{
			return false;
		}
	}
}
