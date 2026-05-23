using System.Collections.Generic;
using Data.Operator;
using Logic.Factory.Blueprint;
using UnityEngine;

namespace Data.FactoryFloor.PlacementValidators
{
	[CreateAssetMenu(menuName = "Factory/Validators/CanOnlyBePlacedOnTopOfSpecificResources", fileName = "CanOnlyBePlacedOnTopOfSpecificResources", order = 0)]
	public class CanOnlyBePlacedOnTopOfSpecificResources : FactoryObjectPlacementValidator
	{
		[SerializeField]
		private List<FactoryObjectData> _resourcesCanBePlacedUpon;

		public override bool IsValidPosition(FactoryObjectData factoryObjectData, Vector3Int blueprintPosition, Vector3Int position, int rotation, FactoryLayer placementLayer, FactoryLayer terrainLayer, int createdId, Blueprint blueprint, bool isBeingMoved = false, BlueprintElement element = null)
		{
			FactoryObject objectAt = terrainLayer.GetObjectAt(position);
			if (objectAt != null)
			{
				return _resourcesCanBePlacedUpon.Contains(objectAt.FactoryObjectData);
			}
			return false;
		}
	}
}
