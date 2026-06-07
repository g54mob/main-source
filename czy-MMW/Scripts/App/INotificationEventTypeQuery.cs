using System;

public interface INotificationEventTypeQuery
{
	string QueryName { get; }

	bool Matches(INotificationEventType eventType, DateTime onDate);
}
