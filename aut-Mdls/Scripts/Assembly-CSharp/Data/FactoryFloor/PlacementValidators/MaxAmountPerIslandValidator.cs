using System.Collections.Generic;
using Data.FactoryFloor.Maps;
using Data.Operator;
using Data.Variables;
using Logic.Factory.Blueprint;
using NaughtyAttributes;
using UnityEngine;

namespace Data.FactoryFloor.PlacementValidators
{
	[CreateAssetMenu(menuName = "Factory/Validators/MaxAmountPerIslandValidator", fileName = "MaxAmountPerIslandValidator")]
	public class MaxAmountPerIslandValidator : FactoryObjectPlacementValidator
	{
		[SerializeField]
		[InfoBox("The combined amount of these data's needs to be less than the max", EInfoBoxType.Normal)]
		private List<FactoryObjectData> _factoryObjectDatas;

		[SerializeField]
		private IntVariableSO _maxAmountPerIsland;

		[SerializeField]
		private IslandLayer _islandLayer;

		[SerializeField]
		[LocaKey]
		private string _maxPerIslandLimitExceededLocaKey;

		public override bool IsValidPosition(FactoryObjectData factoryObjectData, Vector3Int blueprintPosition, Vector3Int position, int rotation, FactoryLayer placementLayer, FactoryLayer terrainLayer, int createdId, Blueprint blueprint = null, bool isBeingMoved = false, BlueprintElement element = null)
		{
			if (!_islandLayer.TryGetIslandAtWorldPosition(position, out var islandObject))
			{
				return false;
			}
			int currentAmountsOnIsland = GetCurrentAmountsOnIsland(placementLayer, islandObject);
			int amountToBeAdded = GetAmountToBeAdded(blueprint, islandObject, position, element);
			bool num = currentAmountsOnIsland + amountToBeAdded <= _maxAmountPerIsland.Value;
			if (!num && !string.IsNullOrEmpty(_maxPerIslandLimitExceededLocaKey))
			{
				ThrowFailReasonEvent(this, LocalizationUtility.GetLocalizedText(_maxPerIslandLimitExceededLocaKey));
			}
			return num;
		}

		private int GetAmountToBeAdded(Blueprint blueprint, IslandObject islandObject, Vector3Int position, BlueprintElement element)
		{
			int num = 0;
			foreach (BlueprintElement element2 in blueprint.Elements)
			{
				if (_factoryObjectDatas.Contains(element2.ObjectData) && islandObject.IsPositionOnIsland(position - element.RelativePositions[0] + element2.RelativePositions[0]))
				{
					num++;
				}
			}
			return num;
		}

		private int GetCurrentAmountsOnIsland(FactoryLayer placementLayer, IslandObject islandObject)
		{
			int num = 0;
			foreach (FactoryObjectData factoryObjectData in _factoryObjectDatas)
			{
				if (islandObject.TryGetObjectsFromData(placementLayer, factoryObjectData, out var factoryObjects))
				{
					num += factoryObjects.Count;
				}
			}
			return num;
		}
	}
}
