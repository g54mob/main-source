using UnityEngine;

public interface INotificationObjectOfInterest
{
	GameObject GameObjectOfInterest { get; }

	ObjectType ObjectOfInterestType { get; }

	string NotificationReplaceVariables(string str);

	void NotificationLeftClick();

	bool IsMatch(INotificationObjectOfInterest notificationObjectOfInterest);
}
