using UnityEngine;

namespace Events.WorldMap
{
	[CreateAssetMenu(menuName = "Events/WorldMap/PlayerFameChangedEvent", fileName = "PlayerFameChangedEvent", order = 0)]
	public class PlayerFameChangedEvent : BaseEvent<int>
	{
	}
}
