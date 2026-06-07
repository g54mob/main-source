using Data.Operator;
using Events.FactoryFloor.BluePrint;
using Logic.Factory.Blueprint;
using UnityEngine;

namespace Data.FactoryFloor.PlacementValidators
{
	public abstract class FactoryObjectPlacementValidator : ScriptableObject
	{
		public struct ValidatorFailReason
		{
			public readonly string Reason;

			public readonly FactoryObjectPlacementValidator Validator;

			public ValidatorFailReason(FactoryObjectPlacementValidator validator, string reason)
			{
				Validator = validator;
				Reason = reason;
			}
		}

		[SerializeField]
		private ValidatorFailReasonEvent _failReasonEvent;

		public abstract bool IsValidPosition(FactoryObjectData factoryObjectData, Vector3Int blueprintPosition, Vector3Int position, int rotation, FactoryLayer placementLayer, FactoryLayer terrainLayer, int createdId, Blueprint blueprint = null, bool isBeingMoved = false, BlueprintElement element = null);

		protected void ThrowFailReasonEvent(FactoryObjectPlacementValidator validator, string reason)
		{
			_failReasonEvent.Fire(new ValidatorFailReason(validator, reason));
		}
	}
}
