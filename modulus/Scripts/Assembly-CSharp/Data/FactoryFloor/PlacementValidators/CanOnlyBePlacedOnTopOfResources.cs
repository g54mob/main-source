using Data.FactoryFloor.FactoryObjectBehaviours;
using Data.Operator;
using Logic.Factory.Blueprint;
using UnityEngine;

namespace Data.FactoryFloor.PlacementValidators
{
	[CreateAssetMenu(menuName = "Factory/Validators/CanOnlyBePlacedOnTopOfResources", fileName = "CanOnlyBePlacedOnTopOfResources", order = 0)]
	public class CanOnlyBePlacedOnTopOfResources : FactoryObjectPlacementValidator
	{
		public override bool IsValidPosition(FactoryObjectData factoryObjectData, Vector3Int blueprintPosition, Vector3Int position, int rotation, FactoryLayer placementLayer, FactoryLayer terrainLayer, int createdId, Blueprint blueprint, bool isBeingMoved = false, BlueprintElement element = null)
		{
			FactoryObject objectAt = terrainLayer.GetObjectAt(position);
			if (objectAt != null && objectAt.HasFactoryObjectBehaviour(out ResourceBehaviour _))
			{
				return true;
			}
			return false;
		}
	}
}
