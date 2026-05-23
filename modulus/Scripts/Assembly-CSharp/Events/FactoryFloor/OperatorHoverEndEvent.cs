using UnityEngine;

namespace Events.FactoryFloor
{
	[CreateAssetMenu(menuName = "Events/UI/OperatorHover/OperatorHoverEndEvent", fileName = "OperatorHoverEndEvent", order = 0)]
	public class OperatorHoverEndEvent : BaseEvent<OperatorHoverDto>
	{
	}
}
