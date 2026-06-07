using System;
using System.Collections.Generic;

[Serializable]
public class RoomNotification : SelectableNotificationNoDrop<Room>
{
	public RoomNotification()
	{
	}

	public RoomNotification(string msg, string icon, SDateTime date, NotificationManager.NotificationType type, IEnumerable<Room> items)
		: base(msg, icon, date, type, Array.Empty<Room>())
	{
		foreach (Room item in items)
		{
			_items.Add(item);
			_serializedItems.Add(GetID(item));
		}
		_deserialized = true;
	}

	public override IEnumerable<Room> GetObjects()
	{
		return GameSettings.Instance.sRoomManager.Rooms;
	}
}
