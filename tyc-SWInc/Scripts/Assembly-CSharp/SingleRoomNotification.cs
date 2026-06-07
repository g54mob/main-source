using System;
using System.Collections.Generic;

[Serializable]
public class SingleRoomNotification : SingleSelectableNotification<Room>
{
	public SingleRoomNotification()
	{
	}

	public SingleRoomNotification(Room room, string msg, string icon, SDateTime date, NotificationManager.NotificationType type)
		: base(room, msg, icon, date, type)
	{
	}

	public SingleRoomNotification(Room room, string msg, string details, string icon, SDateTime date, NotificationManager.NotificationType type)
		: base(room, msg, details, icon, date, type)
	{
	}

	public override IEnumerable<Room> GetSelectables()
	{
		return GameSettings.Instance.sRoomManager.Rooms;
	}
}
