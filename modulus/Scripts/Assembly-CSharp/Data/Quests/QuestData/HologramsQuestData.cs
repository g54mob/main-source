using System.Collections.Generic;
using Data.Quests.QuestViews;
using UnityEngine;

namespace Data.Quests.QuestData
{
	[CreateAssetMenu(menuName = "Quests/Data/Hologram", fileName = "HologramQuestData")]
	public class HologramsQuestData : ScriptableObject
	{
		public Dictionary<HologramPlacementData, OnboardingHologramView> SpawnedHolograms = new Dictionary<HologramPlacementData, OnboardingHologramView>();

		public void Reset()
		{
			SpawnedHolograms.Clear();
		}
	}
}
