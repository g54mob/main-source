using System;

[Serializable]
public class EmployeeGoneNotification : NotificationMessage
{
	public EmployeeTermination Termination;

	public EmployeeGoneNotification()
	{
	}

	public EmployeeGoneNotification(string msg, string icon, EmployeeTermination term)
		: base(msg, icon, SDateTime.Now(), NotificationManager.NotificationType.Warning)
	{
		Termination = term;
	}

	public override void Goto(int idx = -1)
	{
		HUD.Instance.insuranceWindow.Show(false);
		HUD.Instance.insuranceWindow.Terminations.Select(Termination);
	}

	public override int GetCount()
	{
		return 1;
	}

	public override bool HasGoto()
	{
		return true;
	}
}
