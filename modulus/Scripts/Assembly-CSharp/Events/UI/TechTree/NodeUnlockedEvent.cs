using UnityEngine;

namespace Events.UI.TechTree
{
	[CreateAssetMenu(menuName = "Events/UI/TechTree/NodeUnlockedEvent", fileName = "NodeUnlockedEvent", order = 10)]
	public class NodeUnlockedEvent : BaseEvent<TechTreeNodeSO>
	{
	}
}
