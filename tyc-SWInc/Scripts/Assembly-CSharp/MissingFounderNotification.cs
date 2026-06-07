public class MissingFounderNotification : NotificationMessage
{
	public MissingFounderNotification()
		: base("MissingFounderNotification".Loc(), "Employee", NotificationManager.NotificationType.Issue)
	{
	}

	public override bool HasRefresh()
	{
		return true;
	}

	public override bool Refresh()
	{
		return GameSettings.Instance.HasFounder;
	}
}
