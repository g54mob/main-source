using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

[Serializable]
public class SubsidaryLeadNotification : NotificationWithList<SimulatedCompany>
{
	public SubsidaryLeadNotification()
	{
	}

	public SubsidaryLeadNotification(SimulatedCompany company)
		: base("SubsidiaryLeadWarning".Loc(), "Employee", SDateTime.Now(), NotificationManager.NotificationType.Issue, new SimulatedCompany[1] { company })
	{
	}

	public override void Goto(int idx = -1)
	{
		SimulatedCompany at = Items.GetAt(idx);
		if (at != null)
		{
			HUD.Instance.companyWindow.ShowCompanyDetails(at);
		}
	}

	public override object AggregateObject()
	{
		return Items.Last();
	}

	public override bool WriteDerivedData(Stream st)
	{
		st.WriteUInt(Items.Last().ID);
		return false;
	}

	public override int GetTypeID()
	{
		return 1;
	}

	public override bool HasGoto()
	{
		return true;
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
		List<SimulatedCompany> list = Items.ToList();
		for (int i = 0; i < list.Count; i++)
		{
			SimulatedCompany simulatedCompany = list[i];
			if (simulatedCompany == null || simulatedCompany.LeadDesigner != null || !simulatedCompany.Autonomous || simulatedCompany.Bankrupt)
			{
				RemoveItem(list[i]);
			}
		}
		return Items.Count == 0;
	}
}
