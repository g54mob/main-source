using Data.FactoryFloor;
using UnityEngine;

namespace Events.FactoryFloor.Tools
{
	[CreateAssetMenu(menuName = "Events/Tools/SelectFactoryObjectEvent", fileName = "SelectFactoryObjectEvent", order = 0)]
	public class SelectFactoryObjectEvent : BaseEvent<FactoryObject>
	{
	}
}
