using UnityEngine;

namespace Events.FactoryFloor.Islands
{
	[CreateAssetMenu(menuName = "Events/FactoryFloor/Islands/UpdateIslandIdEvent", fileName = "UpdateIslandIdEvent", order = 0)]
	public class UpdateIslandIdEvent : BaseEvent<IdPair>
	{
	}
}
