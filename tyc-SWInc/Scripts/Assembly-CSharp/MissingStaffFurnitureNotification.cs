using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class MissingStaffFurnitureNotification : SelectableNotificationNoDrop<Actor>
{
	public readonly string FurnType;

	public MissingStaffFurnitureNotification()
	{
	}

	public MissingStaffFurnitureNotification(string msg, string hint, string icon, string type, params Actor[] items)
		: base(msg, icon, SDateTime.Now(), NotificationManager.NotificationType.Issue, items)
	{
		FurnType = type;
		Details = hint;
	}

	public override NotificationManager.DropType GetDropType()
	{
		return NotificationManager.DropType.Simple;
	}

	public override IEnumerable<Actor> GetObjects()
	{
		return GameSettings.Instance.sActorManager.Staff;
	}

	public override uint AggregateID()
	{
		return FurnType.GetUHash();
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
			if (actor == null || !actor.enabled || (actor.UsingPoint != null && actor.UsingPoint.Parent.Type.Equals(FurnType)))
			{
				RemoveItem(actor);
			}
		}
		return base.Items.Count == 0;
	}
}
