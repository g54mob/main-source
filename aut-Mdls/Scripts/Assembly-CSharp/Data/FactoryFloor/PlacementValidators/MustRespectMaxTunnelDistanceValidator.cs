using Data.Operator;
using Data.Variables;
using Logic.Factory.Blueprint;
using UnityEngine;

namespace Data.FactoryFloor.PlacementValidators
{
	[CreateAssetMenu(menuName = "Factory/Validators/MustRespectMaxTunnelDistanceValidator", fileName = "MustRespectMaxTunnelDistance", order = 0)]
	public class MustRespectMaxTunnelDistanceValidator : FactoryObjectPlacementValidator
	{
		[SerializeField]
		private IntVariableSO _tunnelMaxDistance;

		public override bool IsValidPosition(FactoryObjectData factoryObjectData, Vector3Int blueprintPosition, Vector3Int position, int rotation, FactoryLayer placementLayer, FactoryLayer terrainLayer, int createdId, Blueprint blueprint = null, bool isBeingMoved = false, BlueprintElement element = null)
		{
			if (element != null && element.IsHardLinked && element.HardLinkedToRelativePositions.Count > 0)
			{
				return (element.HardLinkedToRelativePositions[0] - element.RelativePositions[0]).magnitude <= (float)_tunnelMaxDistance.Value;
			}
			return true;
		}
	}
}
