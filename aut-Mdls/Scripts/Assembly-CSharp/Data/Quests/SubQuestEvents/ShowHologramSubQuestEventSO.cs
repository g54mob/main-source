#define ENABLE_DEBUG_ERRORS
using System.Collections.Generic;
using Data.Quests.QuestData;
using Data.Quests.QuestViews;
using UnityEngine;
using Utils;

namespace Data.Quests.SubQuestEvents
{
	[CreateAssetMenu(menuName = "Quests/Events/Show Hologram", fileName = "ShowHologram", order = 13)]
	public class ShowHologramSubQuestEventSO : AbstractSubQuestEventSO
	{
		[SerializeField]
		private List<HologramPlacementData> _hologramPlacementDatas;

		[SerializeField]
		private HologramsQuestData _hologramsQuestData;

		private static Vector3 POSITION_OFFSET = new Vector3(0.5f, 0f, 0.5f);

		public List<HologramPlacementData> HologramPlacementDatas => _hologramPlacementDatas;

		public override void Execute()
		{
			foreach (HologramPlacementData hologramPlacementData in _hologramPlacementDatas)
			{
				if (hologramPlacementData.Rotation % 90 != 0)
				{
					this.LogError($"The rotation in ShowHologramEvent isn't set in 90degree increments: {hologramPlacementData.Rotation}", "Execute", 22);
				}
				if (_hologramsQuestData.SpawnedHolograms.ContainsKey(hologramPlacementData))
				{
					this.LogError("Tried to add the same hologram twice. Something is wrong!", "Execute", 26);
					continue;
				}
				OnboardingHologramView value = Object.Instantiate(hologramPlacementData.OnboardingHologramView, hologramPlacementData.Position + POSITION_OFFSET, Quaternion.Euler(0f, hologramPlacementData.Rotation, 0f));
				_hologramsQuestData.SpawnedHolograms.Add(hologramPlacementData, value);
			}
		}
	}
}
