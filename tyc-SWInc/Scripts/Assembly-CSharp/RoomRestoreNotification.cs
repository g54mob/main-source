using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class RoomRestoreNotification : RoomNotification
{
	public RoomRestoreNotification()
	{
	}

	public RoomRestoreNotification(string msg, string hint, string icon, IEnumerable<Room> items)
		: base(msg, icon, SDateTime.Now(), NotificationManager.NotificationType.Issue, items)
	{
		Details = hint;
	}

	public override bool HasRefresh()
	{
		return true;
	}

	public override bool Refresh()
	{
		List<Room> list = base.Items.ToList();
		for (int i = 0; i < list.Count; i++)
		{
			Room room = list[i];
			if (room == null || !room.HasRestore())
			{
				RemoveItem(room);
			}
		}
		return base.Items.Count == 0;
	}
}
