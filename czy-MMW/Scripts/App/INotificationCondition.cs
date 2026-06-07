using System;

public interface INotificationCondition
{
	bool Evaluate(DateTime onDate, INotificationEventSystem notificationEventSystem);
}
