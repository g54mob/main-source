using UnityEngine;

namespace Events.FactoryFloor.Buildings
{
	[CreateAssetMenu(menuName = "Events/FactoryFloor/Buildings/BuildingReceivedModuleEvent", fileName = "BuildingReceivedModuleEvent", order = 0)]
	public class BuildingReceivedResourceEvent : BaseEvent<BuildingReceivedResourceData>
	{
	}
}
