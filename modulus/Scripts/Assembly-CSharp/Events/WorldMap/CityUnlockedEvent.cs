using UnityEngine;

namespace Events.WorldMap
{
	[CreateAssetMenu(menuName = "Events/WorldMap/CityUnlockedEvent", fileName = "CityUnlockedEvent", order = 0)]
	public class CityUnlockedEvent : BaseEvent<string>
	{
	}
}
