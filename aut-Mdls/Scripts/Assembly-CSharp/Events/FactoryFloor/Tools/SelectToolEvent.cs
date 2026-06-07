using Logic.FactoryTools;
using UnityEngine;

namespace Events.FactoryFloor.Tools
{
	[CreateAssetMenu(menuName = "Events/Tools/SelectToolEvent", fileName = "SelectToolEvent", order = 0)]
	public class SelectToolEvent : BaseEvent<FactoryTool>
	{
	}
}
