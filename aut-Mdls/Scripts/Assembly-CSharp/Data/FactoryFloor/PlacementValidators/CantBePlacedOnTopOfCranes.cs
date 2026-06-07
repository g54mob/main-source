using Data.Operator;
using Data.Variables;
using Logic.Factory.Blueprint;
using UnityEngine;

namespace Data.FactoryFloor.PlacementValidators
{
	[CreateAssetMenu(menuName = "Factory/Validators/CantBePlacedOnTopOfCranes", fileName = "CantBePlacedOnTopOfCranes", order = 0)]
	public class CantBePlacedOnTopOfCranes : FactoryObjectPlacementValidator
	{
		[SerializeField]
		private CranesLibrarySO _cranesLibrarySO;

		[SerializeField]
		private bool _canBePlacedOnRails;

		public override bool IsValidPosition(FactoryObjectData factoryObjectData, Vector3Int blueprintPosition, Vector3Int position, int rotation, FactoryLayer placementLayer, FactoryLayer terrainLayer, int createdId, Blueprint blueprint = null, bool isBeingMoved = false, BlueprintElement element = null)
		{
			if (_canBePlacedOnRails && _cranesLibrarySO.TryGetRail(position))
			{
				return true;
			}
			return !_cranesLibrarySO.Cranes.ContainsKey(position);
		}
	}
}
