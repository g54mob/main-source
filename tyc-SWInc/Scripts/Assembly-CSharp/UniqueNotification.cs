using System;

[Serializable]
public class UniqueNotification : NotificationMessage
{
	public enum MessageID
	{
		None = 0,
		BusFull = 1,
		SoftwareSupportWaning = 2,
		CallCops = 3
	}

	public MessageID ID;

	public UniqueNotification()
	{
	}

	public UniqueNotification(string msg, string icon, MessageID id, NotificationManager.NotificationType type)
		: base(msg, icon, type)
	{
		ID = id;
	}

	public UniqueNotification(string msg, string icon, MessageID id, SDateTime date, NotificationManager.NotificationType type)
		: base(msg, icon, date, type)
	{
		ID = id;
	}

	public UniqueNotification(string msg, string details, string icon, MessageID id, SDateTime date, NotificationManager.NotificationType type)
		: base(msg, details, icon, date, type)
	{
		ID = id;
	}

	public override uint AggregateID()
	{
		return (uint)ID;
	}

	public override bool IsAggregate()
	{
		return true;
	}

	public static bool CheckForPresence(MessageID id)
	{
		return NotificationManager.CheckAggregate<UniqueNotification>(null, (uint)id);
	}
}
