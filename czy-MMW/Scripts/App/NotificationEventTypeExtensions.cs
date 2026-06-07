public static class NotificationEventTypeExtensions
{
	public static bool Matches(this INotificationEventType eventA, INotificationEventType eventB)
	{
		if (eventA is INotificationEventTypeWithData notificationEventTypeWithData && eventB is INotificationEventTypeWithData eventTypeWithData)
		{
			return notificationEventTypeWithData.DataMatches(eventTypeWithData);
		}
		return eventA.GetType() == eventB.GetType();
	}
}
