using UnityEngine;

namespace Events.FactoryFloor
{
	[CreateAssetMenu(menuName = "Events/BluePrintEvent", fileName = "BluePrintEvent", order = 0)]
	public class BluePrintEvent : BaseEvent<BlueprintViewEventDto>
	{
	}
}
