using Data.FactoryFloor;
using UnityEngine;

namespace Events.FactoryFloor
{
	[CreateAssetMenu(menuName = "Events/FactoryObjectDeletedEvent", fileName = "FactoryObjectDeletedEvent", order = 0)]
	public class FactoryObjectDeletedEvent : BaseEvent<(FactoryObject factoryObject, FactoryLayer factoryLayer)>
	{
	}
}
