using Data.Notifications;
using UnityEngine;

namespace Events.UI.Notifications
{
	[CreateAssetMenu(menuName = "Events/UI/NotificationEvent", fileName = "NotificationEvent", order = 0)]
	public class NotificationEvent : BaseEvent<AbstractNotificationData>
	{
	}
}
