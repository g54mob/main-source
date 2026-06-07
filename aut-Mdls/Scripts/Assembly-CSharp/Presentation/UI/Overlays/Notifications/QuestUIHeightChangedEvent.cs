using Events;
using UnityEngine;

namespace Presentation.UI.Overlays.Notifications
{
	[CreateAssetMenu(menuName = "Events/UI/QuestUIHeightChangedEvent", fileName = "QuestUIHeightChangedEvent", order = 0)]
	public class QuestUIHeightChangedEvent : BaseEvent<float>
	{
	}
}
