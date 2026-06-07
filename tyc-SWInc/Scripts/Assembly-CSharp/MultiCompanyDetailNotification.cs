using System;
using System.Collections.Generic;

[Serializable]
public class MultiCompanyDetailNotification : NotificationWithList<Company>
{
	public readonly uint AggID;

	public bool Distribution;

	public MultiCompanyDetailNotification()
	{
	}

	public MultiCompanyDetailNotification(string msg, string icon, NotificationManager.NotificationType type, uint aggregateID = 0u, params Company[] items)
		: base(msg, icon, SDateTime.Now(), type, items)
	{
		AggID = aggregateID;
	}

	public MultiCompanyDetailNotification(string msg, string icon, NotificationManager.NotificationType type, IList<Company> items, uint aggregateID = 0u)
		: base(msg, icon, SDateTime.Now(), type, Array.Empty<Company>())
	{
		Items.AddRange(items);
		AggID = aggregateID;
	}

	public override bool IsAggregate()
	{
		return AggID != 0;
	}

	public override uint AggregateID()
	{
		return AggID;
	}

	public override void Goto(int idx = -1)
	{
		Company at = Items.GetAt(idx);
		if (Distribution)
		{
			HUD.Instance.digitalDistributionWindow.Show(true);
			HUD.Instance.digitalDistributionWindow.DistDealList.Select(at);
		}
		else
		{
			HUD.Instance.companyWindow.ShowCompanyDetails(at);
		}
	}
}
