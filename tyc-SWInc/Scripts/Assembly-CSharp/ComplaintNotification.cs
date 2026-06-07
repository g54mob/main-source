using System;

[Serializable]
public class ComplaintNotification : NotificationMessage
{
	public ComplaintNotification()
	{
	}

	public ComplaintNotification(SDateTime t)
		: base("NewComplaintWarning".Loc(), "Sad", t, NotificationManager.NotificationType.Warning)
	{
	}

	public override int GetCount()
	{
		return 1;
	}

	public override void Goto(int idx = -1)
	{
		HUD.Instance.complaintWindow.Show();
	}

	public override bool HasGoto()
	{
		return true;
	}

	public override bool IsAggregate()
	{
		return true;
	}
}
