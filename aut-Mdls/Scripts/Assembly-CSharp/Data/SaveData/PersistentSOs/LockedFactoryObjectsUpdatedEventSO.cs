using Data.Operator;
using Events;
using UnityEngine;

namespace Data.SaveData.PersistentSOs
{
	[CreateAssetMenu(menuName = "Events/Locked FactoryObjects Updated", fileName = "LockedFactoryObjectsUpdatedEvent", order = 0)]
	public class LockedFactoryObjectsUpdatedEventSO : BaseEvent<FactoryObjectData>
	{
	}
}
