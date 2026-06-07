using System;

[Serializable]
public class SinkWarningNotification : NotificationMessage
{
	public bool Set = true;

	public SinkWarningNotification()
		: base("GermHint".Loc(), "Germ", NotificationManager.NotificationType.Issue)
	{
	}

	public override bool HasRefresh()
	{
		return true;
	}

	public override bool IsAggregate()
	{
		return true;
	}

	public override bool IsDismissable()
	{
		return true;
	}

	public override bool Refresh()
	{
		return !Set;
	}

	public override void RemoveItem(object item)
	{
		Set = false;
	}
}
