using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New GameNotificationDatabase", menuName = "Motorways/Notifications/Game Notification Database", order = 2)]
public class NotificationDescriptorDatabase : ScriptableObject
{
	[NonReorderable]
	public List<NotificationDescriptor> gameNotifications = new List<NotificationDescriptor>();
}
