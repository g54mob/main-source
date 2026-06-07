using Data.FactoryFloor.PlacementValidators;
using UnityEngine;

namespace Events.FactoryFloor.BluePrint
{
	[CreateAssetMenu(menuName = "Events/ValidatorFailReasonEvent", fileName = "ValidatorFailReasonEvent", order = 0)]
	public class ValidatorFailReasonEvent : BaseEvent<FactoryObjectPlacementValidator.ValidatorFailReason>
	{
	}
}
