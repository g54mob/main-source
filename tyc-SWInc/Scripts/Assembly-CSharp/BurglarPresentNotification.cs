using System;
using System.Collections.Generic;

[Serializable]
public class BurglarPresentNotification : SelectableNotificationNoDrop<Actor>
{
	public BurglarPresentNotification()
	{
	}

	public BurglarPresentNotification(params Actor[] items)
		: base("BurglarWarning".Loc(), "Burglar", SDateTime.Now(), NotificationManager.NotificationType.Issue, items)
	{
	}

	public override IEnumerable<Actor> GetObjects()
	{
		return GameSettings.Instance.sActorManager.Others["Burglars"];
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
		return base.Items.Count == 0;
	}
}
