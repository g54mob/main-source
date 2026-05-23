using System.Collections.Generic;
using Data.Operator;
using Logic.Factory.Blueprint;
using UnityEngine;

namespace Data.FactoryFloor.PlacementValidators
{
	[CreateAssetMenu(menuName = "Factory/Validators/CannotOverrideAnything", fileName = "CannotOverrideAnything", order = 0)]
	public class CannotOverrideAnythingValidator : FactoryObjectPlacementValidator
	{
		[SerializeField]
		private List<FactoryObjectData> _overridableExceptions;

		public override bool IsValidPosition(FactoryObjectData factoryObjectData, Vector3Int blueprintPosition, Vector3Int position, int rotation, FactoryLayer placementLayer, FactoryLayer terrainLayer, int createdId, Blueprint blueprint, bool isBeingMoved = false, BlueprintElement element = null)
		{
			return placementLayer.CanPlaceObjectAt(position, _overridableExceptions);
		}
	}
}
