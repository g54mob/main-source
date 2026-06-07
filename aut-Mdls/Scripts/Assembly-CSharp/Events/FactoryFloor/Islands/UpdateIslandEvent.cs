using UnityEngine;

namespace Events.FactoryFloor.Islands
{
	[CreateAssetMenu(menuName = "Events/FactoryFloor/Islands/UpdateIslandEvent", fileName = "UpdateIslandEvent", order = 0)]
	public class UpdateIslandEvent : BaseEvent<UpdateIslandDto>
	{
	}
}
