using UnityEngine;

namespace Events.UI.TechTree
{
	[CreateAssetMenu(menuName = "Events/UI/TechTree/NodeRevealedEvent", fileName = "NodeRevealedEvent", order = 11)]
	public class NodeRevealedEvent : BaseEvent<NodeRevealedData>
	{
	}
}
