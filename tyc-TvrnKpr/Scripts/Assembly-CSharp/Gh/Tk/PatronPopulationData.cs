using System;
using System.Collections.Generic;
using System.Text;

namespace Gh.Tk
{
	[GhTypeHintingAlias("Gh.Tk.SpawnPatron+PatronPopulationData")]
	public class PatronPopulationData : IPersistable, ICloneable
	{
		public int hourToSpawn;

		public string patronType;

		public string race;

		public int tier;

		public List<PatronNeedData> needs;

		public List<string> traits;

		public List<string> conversationThemes;

		public string label;

		public bool disableImpromptuOptionalNeeds;

		internal bool historicPawn;

		public bool visitedTavern;

		internal float spawnTimestamp;

		internal string chosenPrefab;

		public int revealDifficulty;

		public bool isFakePawn;

		public int createdByEventId;

		public string createdByStoryNodeId;

		public bool hideInChart;

		public bool isStoryPawn;

		public int groupId;

		public int groupSize;

		public bool isGroupRequest;

		public bool isRandomGroupRequest;

		public int startGroupSpawnHour;

		public int groupSpawnHourRange;

		public string groupDescription;

		public bool isVip;

		public bool isGroupConfirmed;

		public int goldBonus;

		[PersistenceObjectReference]
		internal PatronData TargetPatron { get; set; }

		[PersistenceObjectReference]
		public TooltipData ArchivedTooltip { get; private set; }

		[PersistenceObjectReference]
		public TooltipData ArchivedTooltipUnknown { get; private set; }

		public IEnumerable<PatronNeedData> GetGameEnabledNeeds()
		{
			return null;
		}

		public bool IsKnowledgeClear()
		{
			return false;
		}

		public bool IsPlayerVisible()
		{
			return false;
		}

		public TooltipData GenerateTooltipData(bool forArchivalPurposes = false, bool forceClearKnowledge = false)
		{
			return null;
		}

		public string GenerateGroupTooltipInfo()
		{
			return null;
		}

		private void GenerateTooltipInfo(StringBuilder sb)
		{
		}

		internal void FreezeTooltipData()
		{
		}

		public object Clone()
		{
			return null;
		}

		internal PatronNeedData GetDrinkNeed()
		{
			return null;
		}
	}
}
