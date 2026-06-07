using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class GuardIssueNotification : SelectableNotificationNoDrop<Actor>
{
	public GuardIssueNotification()
	{
	}

	public GuardIssueNotification(params Actor[] items)
		: base("SecurityEntranceMissing".Loc(), "Door", SDateTime.Now(), NotificationManager.NotificationType.Issue, items)
	{
		Details = "SecurityEntranceMissingHint".Loc();
	}

	public override NotificationManager.DropType GetDropType()
	{
		return NotificationManager.DropType.Simple;
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
			if (actor == null || !actor.enabled || actor.Guarding != null || (actor.UsingPoint != null && actor.UsingPoint.Parent.Type.Equals("SecurityDesk")))
			{
				RemoveItem(actor);
			}
		}
		return base.Items.Count == 0;
	}
}
