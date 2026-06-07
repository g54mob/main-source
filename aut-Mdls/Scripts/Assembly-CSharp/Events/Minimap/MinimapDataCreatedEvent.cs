using Data.Minimap;
using UnityEngine;

namespace Events.Minimap
{
	[CreateAssetMenu(menuName = "Events/Minimap/MinimapDataCreatedEvent", fileName = "MinimapDataCreatedEvent", order = 0)]
	public class MinimapDataCreatedEvent : BaseEvent<MinimapData>
	{
	}
}
