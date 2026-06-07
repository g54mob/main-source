using System.Collections.Generic;
using Data.Operator;
using Data.Quests.QuestData;
using Data.Quests.QuestViews;
using Data.Variables;
using Logic.Factory.Blueprint;
using UnityEngine;

namespace Data.FactoryFloor.PlacementValidators
{
	[CreateAssetMenu(menuName = "Factory/Validators/CanOnlyBePlacedOnTopOfHologramValidator", fileName = "CanOnlyBePlacedOnTopOfHologramValidator", order = 0)]
	public class CanOnlyBePlacedOnTopOfHologramValidator : FactoryObjectPlacementValidator
	{
		[SerializeField]
		private HologramsQuestData _hologramsQuestData;

		[SerializeField]
		private BoolVariableSO _placementLockedToHolograms;

		public override bool IsValidPosition(FactoryObjectData factoryObjectData, Vector3Int blueprintPosition, Vector3Int position, int rotation, FactoryLayer placementLayer, FactoryLayer terrainLayer, int createdId, Blueprint blueprint, bool isBeingMoved = false, BlueprintElement element = null)
		{
			if (_hologramsQuestData == null || !_placementLockedToHolograms.Value)
			{
				return true;
			}
			foreach (KeyValuePair<HologramPlacementData, OnboardingHologramView> spawnedHologram in _hologramsQuestData.SpawnedHolograms)
			{
				if (spawnedHologram.Key.OnboardingHologramView.FactoryObjectData == factoryObjectData && spawnedHologram.Key.Position == blueprintPosition && (!spawnedHologram.Key.RotationRequired || spawnedHologram.Key.Rotation == rotation))
				{
					return true;
				}
			}
			return false;
		}
	}
}
