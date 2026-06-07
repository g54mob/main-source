using Data.FactoryFloor.Maps;
using UnityEngine;

namespace Events.Islands
{
	[CreateAssetMenu(menuName = "Events/Islands/IslandCullStateChangedEvent", fileName = "IslandCullStateChangedEvent", order = 0)]
	public class IslandCullStateChangedEventSO : BaseEvent<IslandObject>
	{
	}
}
