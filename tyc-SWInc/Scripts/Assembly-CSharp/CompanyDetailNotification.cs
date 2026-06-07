using System;

[Serializable]
public class CompanyDetailNotification : NotificationMessage
{
	public Company Company;

	public CompanyDetailNotification()
	{
	}

	public CompanyDetailNotification(Company c, string msg, string icon, SDateTime date, NotificationManager.NotificationType type)
		: base(msg, icon, date, type)
	{
		Company = c;
	}

	public override uint AggregateID()
	{
		return Company.ID;
	}

	public override void Goto(int idx = -1)
	{
		HUD.Instance.companyWindow.ShowCompanyDetails(Company);
	}

	public override int GetCount()
	{
		return 1;
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
