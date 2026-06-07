using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class RoomFireNotification : SelectableNotificationNoDrop<Room>
{
	public RoomFireNotification()
	{
	}

	public RoomFireNotification(params Room[] items)
		: base("FireWarning".Loc(), "Fire", SDateTime.Now(), NotificationManager.NotificationType.Issue, items)
	{
	}

	public override IEnumerable<Room> GetObjects()
	{
		return GameSettings.Instance.sRoomManager.Rooms;
	}

	public override bool HasRefresh()
	{
		return true;
	}

	public override bool IsAggregate()
	{
		return true;
	}

	public override bool Refresh()
	{
		List<Room> list = base.Items.ToList();
		for (int i = 0; i < list.Count; i++)
		{
			Room room = list[i];
			if (room == null || !room.IsOnFire)
			{
				RemoveItem(room);
			}
		}
		return base.Items.Count == 0;
	}
}
