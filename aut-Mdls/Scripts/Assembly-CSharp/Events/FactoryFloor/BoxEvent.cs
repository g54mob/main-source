using UnityEngine;

namespace Events.FactoryFloor
{
	[CreateAssetMenu(menuName = "Events/BoxEvent", fileName = "BoxEvent", order = 0)]
	public class BoxEvent : BaseEvent<BoxSize>
	{
	}
}
