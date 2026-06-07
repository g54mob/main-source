using System;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class EmployeeNotification : NotificationMessage
{
	public HashSet<Employee> Employees = new HashSet<Employee>();

	public EmployeeNotification()
	{
	}

	public EmployeeNotification(string msg, string icon, SDateTime date, NotificationManager.NotificationType type, IEnumerable<Employee> emps)
		: base(msg, icon, date, type)
	{
		Employees.AddRange(emps);
	}

	public override bool AddItem(object item)
	{
		if (Employees.Add((Employee)item))
		{
			UIItem.Refresh();
			UIItem.RefreshCount();
			return true;
		}
		return false;
	}

	public override int GetCount()
	{
		return Employees.Count;
	}

	public override NotificationManager.DropType GetDropType()
	{
		return NotificationManager.DropType.None;
	}

	public override bool IsAggregate()
	{
		return true;
	}

	public override void Goto(int idx = -1)
	{
		if (Employees.Count == 1)
		{
			Employee employee = Employees.First();
			if (employee.MyActor != null)
			{
				if (employee.MyActor.isActiveAndEnabled)
				{
					CameraScript.Instance.MoveTo(employee.MyActor.GetFlatPos(), employee.MyActor.GetFloor());
				}
				SelectorController.Instance.SetSelection(employee.MyActor);
			}
		}
		else if (Employees.Count > 0)
		{
			HintController.Show(HintController.Hints.HintJumpToSelection);
			HUD.Instance.employeeWindow.Show(Employees.SelectNotNull((Employee x) => x.MyActor));
		}
	}

	public override bool HasGoto()
	{
		return true;
	}

	public override void RemoveItem(object item)
	{
		if (Employees.Remove((Employee)item))
		{
			UIItem.Refresh();
			UIItem.RefreshCount();
		}
	}
}
