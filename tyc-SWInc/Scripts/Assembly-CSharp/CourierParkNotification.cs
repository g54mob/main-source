using System;

[Serializable]
public class CourierParkNotification : NotificationMessage
{
	public bool Set = true;

	public CourierParkNotification()
	{
	}

	public CourierParkNotification(SDateTime time)
		: base("CourierParkError".Loc(), "Parking", time, NotificationManager.NotificationType.Issue)
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

	public override bool Refresh()
	{
		if (Set)
		{
			return GameSettings.Instance.sActorManager.Staff.None((Actor x) => x.AItype == AI.AIType.Courier);
		}
		return true;
	}

	public override void RemoveItem(object item)
	{
		Set = false;
	}
}
