using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class RoomAssignIssueNotification : SelectableNotification<Actor>
{
	public RoomAssignIssueNotification()
	{
	}

	public RoomAssignIssueNotification(params Actor[] items)
		: base("StaffRoomAssignError".Loc(), "Room", SDateTime.Now(), NotificationManager.NotificationType.Issue, items)
	{
	}

	public override IEnumerable<Actor> GetObjects()
	{
		return GameSettings.Instance.sActorManager.Staff;
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
		List<Actor> list = base.Items.ToList();
		for (int i = 0; i < list.Count; i++)
		{
			Actor actor = list[i];
			if (actor == null || !actor.AreRoomsAssignedEmpty())
			{
				RemoveItem(actor);
			}
		}
		return base.Items.Count == 0;
	}
}
