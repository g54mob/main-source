using System;

[Serializable]
public class SingleEmployeeNotification : NotificationMessage
{
	public Employee Employee;

	public SingleEmployeeNotification()
	{
	}

	public SingleEmployeeNotification(string msg, string icon, NotificationManager.NotificationType type, Employee emp)
		: base(msg, icon, type)
	{
		Employee = emp;
	}

	public override int GetCount()
	{
		return 1;
	}

	public override void Goto(int idx = -1)
	{
		if (Employee.MyActor != null)
		{
			HUD.Instance.DetailWindow.Show(Employee.MyActor);
		}
	}

	public override bool HasGoto()
	{
		return true;
	}
}
