#define ENABLE_DEBUG_ERRORS
using Data.FactoryFloor.Maps;
using Data.Operator;
using Logic.Factory.Blueprint;
using SaveData.FactoryFloor.SaveStates;
using UnityEngine;
using Utils;

namespace Data.FactoryFloor.PlacementValidators
{
	[CreateAssetMenu(menuName = "Factory/Validators/CanOnlyBeMovedOnOwnIsland", fileName = "CanOnlyBeMovedOnOwnIslandValidator", order = 0)]
	public class CanOnlyBeMovedOnOwnIslandValidator : FactoryObjectPlacementValidator
	{
		[SerializeField]
		private IslandLayer _islandLayer;

		[Header("Tooltip")]
		[SerializeField]
		[LocaKey]
		protected string _tooltipLocalizationKey;

		public override bool IsValidPosition(FactoryObjectData factoryObjectData, Vector3Int blueprintPosition, Vector3Int position, int rotation, FactoryLayer placementLayer, FactoryLayer terrainLayer, int createdId, Blueprint blueprint, bool isBeingMoved = false, BlueprintElement element = null)
		{
			if (!isBeingMoved)
			{
				return true;
			}
			if (!_islandLayer.TryGetIslandAtWorldPosition(position, out var islandObject))
			{
				return false;
			}
			if (blueprint == null)
			{
				this.LogError($"Needs a blueprint that isn't null to confirm the origin island! {factoryObjectData}", "IsValidPosition", 37);
				return false;
			}
			foreach (BlueprintElement element2 in blueprint.Elements)
			{
				if (element2.CreatedId != createdId)
				{
					continue;
				}
				foreach (BehaviourSaveStateDto saveState in element2.SaveStates)
				{
					if (saveState is ICanOnlyBeMovedOnOwnIslandSaveState canOnlyBeMovedOnOwnIslandSaveState)
					{
						bool num = canOnlyBeMovedOnOwnIslandSaveState.GetIslandId() == islandObject.CreatedId;
						if (!num)
						{
							string reason = string.Format(LocalizationUtility.GetLocalizedText(_tooltipLocalizationKey), LocalizationUtility.GetLocalizedText(factoryObjectData.NameLocKey));
							ThrowFailReasonEvent(this, reason);
						}
						return num;
					}
				}
			}
			return false;
		}
	}
}
