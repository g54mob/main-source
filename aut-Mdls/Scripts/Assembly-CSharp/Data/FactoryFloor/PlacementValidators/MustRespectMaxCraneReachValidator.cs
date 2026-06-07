using Data.Operator;
using Data.Variables;
using Logic.Factory.Blueprint;
using UnityEngine;

namespace Data.FactoryFloor.PlacementValidators
{
	[CreateAssetMenu(menuName = "Factory/Validators/MustRespectMaxCraneReachValidator", fileName = "MustRespectMaxCraneReachValidator", order = 0)]
	public class MustRespectMaxCraneReachValidator : FactoryObjectPlacementValidator
	{
		[SerializeField]
		private IntVariableSO _maxCraneReach;

		public override bool IsValidPosition(FactoryObjectData factoryObjectData, Vector3Int blueprintPosition, Vector3Int position, int rotation, FactoryLayer placementLayer, FactoryLayer terrainLayer, int createdId, Blueprint blueprint = null, bool isBeingMoved = false, BlueprintElement element = null)
		{
			return (blueprintPosition - position).magnitude <= (float)_maxCraneReach.Value;
		}
	}
}
