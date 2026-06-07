using System;
using System.Collections.Generic;

[Serializable]
public class NotificationData : IDisposable
{
	private static Queue<NotificationData> _instancePool = new Queue<NotificationData>();

	public NotificationProperties Properties { get; private set; }

	public INotificationObjectOfInterest ObjectOfInterest { get; private set; }

	public float Timestamp { get; private set; }

	public static List<NotificationData> Notifications { get; private set; } = new List<NotificationData>();

	private NotificationData()
	{
	}

	public static NotificationData Get(NotificationProperties notificationProperties, INotificationObjectOfInterest objectOfInterest, float timestamp)
	{
		if (!_instancePool.TryDequeue(out var result))
		{
			result = new NotificationData();
		}
		result.Properties = notificationProperties;
		result.ObjectOfInterest = objectOfInterest;
		result.Timestamp = timestamp;
		Notifications.Add(result);
		return result;
	}

	public static void Clear()
	{
		for (int num = Notifications.Count - 1; num >= 0; num--)
		{
			Notifications[num].Dispose();
		}
	}

	public void Dispose()
	{
		Notifications.Remove(this);
		_instancePool.Enqueue(this);
	}

	public override string ToString()
	{
		if (ObjectOfInterest != null)
		{
			return ObjectOfInterest.NotificationReplaceVariables(Properties.LocalizedDescription);
		}
		return Properties.LocalizedDescription;
	}
}
