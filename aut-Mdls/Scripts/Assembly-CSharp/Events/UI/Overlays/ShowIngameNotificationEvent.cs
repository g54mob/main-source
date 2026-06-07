using Logic.Threading.Events;
using Presentation.UI.Overlays.Notifications;
using UnityEngine;

namespace Events.UI.Overlays
{
	[CreateAssetMenu(menuName = "Events/UI/Overlays/Show Ingame Notification", fileName = "ShowIngameNotificationEvent", order = 0)]
	public class ShowIngameNotificationEvent : MainThreadEventSO<InGameNotificationDto>
	{
	}
}
