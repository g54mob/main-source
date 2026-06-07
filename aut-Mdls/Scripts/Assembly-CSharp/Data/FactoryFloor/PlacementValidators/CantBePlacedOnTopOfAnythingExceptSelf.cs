using Data.Operator;
using Logic.Factory.Blueprint;
using UnityEngine;

namespace Data.FactoryFloor.PlacementValidators
{
	[CreateAssetMenu(menuName = "Factory/Validators/CantBePlacedOnTopOfAnythingExceptSelf", fileName = "CantBePlacedOnTopOfAnythingExceptSelf", order = 0)]
	public class CantBePlacedOnTopOfAnythingExceptSelf : FactoryObjectPlacementValidator
	{
		public override bool IsValidPosition(FactoryObjectData factoryObjectData, Vector3Int blueprintPosition, Vector3Int position, int rotation, FactoryLayer placementLayer, FactoryLayer terrainLayer, int createdId, Blueprint blueprint, bool isBeingMoved = false, BlueprintElement element = null)
		{
			FactoryObject objectAt = placementLayer.GetObjectAt(position);
			if (objectAt == null)
			{
				return true;
			}
			return objectAt.CreatedId == createdId;
		}
	}
}
