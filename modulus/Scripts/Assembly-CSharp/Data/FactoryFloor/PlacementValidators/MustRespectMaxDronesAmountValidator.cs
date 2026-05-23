using Data.Operator;
using Data.Variables;
using Logic.Factory.Blueprint;
using UnityEngine;

namespace Data.FactoryFloor.PlacementValidators
{
	[CreateAssetMenu(menuName = "Factory/Validators/MustRespectMaxDronesAmountValidator", fileName = "MustRespectMaxXDronesAmount", order = 0)]
	public class MustRespectMaxDronesAmountValidator : FactoryObjectPlacementValidator
	{
		[SerializeField]
		private IntVariableSO _droneMaxAmountData;

		public override bool IsValidPosition(FactoryObjectData factoryObjectData, Vector3Int blueprintPosition, Vector3Int position, int rotation, FactoryLayer placementLayer, FactoryLayer terrainLayer, int createdId, Blueprint blueprint = null, bool isBeingMoved = false, BlueprintElement element = null)
		{
			if (element != null && element.IsSoftLinked && element.SoftLinkedToRelativePositions.Count > 0)
			{
				return element.SoftLinkedToRelativePositions.Count <= _droneMaxAmountData.Value;
			}
			return true;
		}
	}
}
