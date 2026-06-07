using Data.FactoryFloor.Maps;
using Data.Operator;
using Data.SaveData.PersistentSOs;
using Logic.Factory.Blueprint;
using Presentation.Locators;
using UnityEngine;

namespace Data.FactoryFloor.PlacementValidators
{
	[CreateAssetMenu(menuName = "Factory/Validators/MustBePlacedOnUnlockedIslands", fileName = "MustBePlacedOnUnlockedIslands", order = 0)]
	public class MustBePlacedOnUnlockedIslands : FactoryObjectPlacementValidator
	{
		[SerializeField]
		private GridLocator _gridMapLocator;

		[SerializeField]
		private IslandLayer _islandLayer;

		[SerializeField]
		private UnlockedIslandsPersistentSO _unlockedIslandsPersistentSO;

		public override bool IsValidPosition(FactoryObjectData factoryObjectData, Vector3Int blueprintPosition, Vector3Int position, int rotation, FactoryLayer placementLayer, FactoryLayer terrainLayer, int createdId, Blueprint blueprint, bool isBeingMoved = false, BlueprintElement element = null)
		{
			if (_islandLayer.IsEmpty)
			{
				return true;
			}
			Vector3Int cellPosition = _gridMapLocator.GetCellPosition(position);
			if (!_islandLayer.TryGetIslandAtGridPosition(cellPosition, out var islandObject))
			{
				return false;
			}
			if (!_unlockedIslandsPersistentSO.IsIslandUnlocked(islandObject))
			{
				return false;
			}
			return islandObject.IsPositionOnIsland(position);
		}
	}
}
