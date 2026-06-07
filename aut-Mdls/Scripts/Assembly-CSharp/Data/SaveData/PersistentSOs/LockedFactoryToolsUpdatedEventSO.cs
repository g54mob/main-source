using Events;
using Logic.FactoryTools;
using UnityEngine;

namespace Data.SaveData.PersistentSOs
{
	[CreateAssetMenu(menuName = "Events/Locked FactoryTools Updated", fileName = "LockedFactoryToolsUpdatedEvent", order = 0)]
	public class LockedFactoryToolsUpdatedEventSO : BaseEvent<FactoryTool>
	{
	}
}
