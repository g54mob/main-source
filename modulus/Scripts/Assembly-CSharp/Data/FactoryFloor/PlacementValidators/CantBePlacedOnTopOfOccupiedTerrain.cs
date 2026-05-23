using Data.Operator;
using Logic.Factory.Blueprint;
using UnityEngine;

namespace Data.FactoryFloor.PlacementValidators
{
	[CreateAssetMenu(menuName = "Factory/Validators/CantBePlacedOnTopOfOccupiedTerrain", fileName = "CantBePlacedOnTopOfOccupiedTerrain", order = 0)]
	public class CantBePlacedOnTopOfOccupiedTerrain : FactoryObjectPlacementValidator
	{
		public override bool IsValidPosition(FactoryObjectData factoryObjectData, Vector3Int blueprintPosition, Vector3Int position, int rotation, FactoryLayer placementLayer, FactoryLayer terrainLayer, int createdId, Blueprint blueprint, bool isBeingMoved = false, BlueprintElement element = null)
		{
			return terrainLayer.CanPlaceObjectAt(position);
		}
	}
}
