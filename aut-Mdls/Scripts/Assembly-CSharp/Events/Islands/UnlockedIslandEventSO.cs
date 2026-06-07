using Data.FactoryFloor.Maps;
using UnityEngine;

namespace Events.Islands
{
	[CreateAssetMenu(menuName = "Events/Islands/UnlockIslandEvent", fileName = "UnlockIslandEvent", order = 0)]
	public class UnlockedIslandEventSO : BaseEvent<IslandObject>
	{
	}
}
