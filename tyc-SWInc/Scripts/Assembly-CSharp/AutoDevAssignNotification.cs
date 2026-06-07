using System;

[Serializable]
public class AutoDevAssignNotification : NotificationWithList<AutoDevWorkItem>
{
	public AutoDevAssignNotification()
	{
	}

	public AutoDevAssignNotification(params AutoDevWorkItem[] items)
		: base("ProjectManagementProjectWarning".Loc(), "Automation", SDateTime.Now(), NotificationManager.NotificationType.Issue, items)
	{
	}

	public override void Goto(int idx = -1)
	{
		HUD.Instance.AutoDevWindow.Show(Items.GetAt(idx));
	}

	public override bool IsAggregate()
	{
		return true;
	}

	public override bool HasRefresh()
	{
		return true;
	}

	public override bool Refresh()
	{
		return Items.Count == 0;
	}
}
