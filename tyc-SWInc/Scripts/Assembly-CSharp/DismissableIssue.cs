using System;

[Serializable]
public class DismissableIssue : NotificationMessage
{
	public DismissableIssue()
	{
	}

	public DismissableIssue(string message, string icon)
		: base(message, icon, SDateTime.Now(), NotificationManager.NotificationType.Issue)
	{
	}

	public override bool IsDismissable()
	{
		return true;
	}
}
