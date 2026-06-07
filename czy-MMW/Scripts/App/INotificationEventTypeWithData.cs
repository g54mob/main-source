using System.Collections.Generic;

public interface INotificationEventTypeWithData : INotificationEventType
{
	bool InitFromJson(JSON.Dictionary json);

	void ToJson(ref Dictionary<string, object> json);

	bool DataMatches(INotificationEventTypeWithData eventTypeWithData);
}
