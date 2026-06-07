using System.Collections.Generic;
using Data.Quests.QuestData;
using Data.Quests.QuestViews;
using UnityEngine;

namespace Data.Quests.SubQuestEvents
{
	[CreateAssetMenu(menuName = "Quests/Events/Hide Hologram", fileName = "HideHologram", order = 14)]
	public class HideHologramSubQuestEventSO : AbstractSubQuestEventSO
	{
		[SerializeField]
		private HologramsQuestData _hologramsQuestData;

		public override void Execute()
		{
			foreach (KeyValuePair<HologramPlacementData, OnboardingHologramView> spawnedHologram in _hologramsQuestData.SpawnedHolograms)
			{
				Object.Destroy(spawnedHologram.Value.gameObject);
			}
			_hologramsQuestData.SpawnedHolograms.Clear();
		}
	}
}
