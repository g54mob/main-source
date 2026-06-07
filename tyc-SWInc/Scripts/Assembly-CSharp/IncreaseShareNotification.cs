using System;
using System.IO;
using System.Linq;

[Serializable]
public class IncreaseShareNotification : MultiCompanyDetailNotification
{
	public IncreaseShareNotification()
	{
	}

	public IncreaseShareNotification(Company company)
		: base("IncreaseShare".Loc(), "Money", NotificationManager.NotificationType.Neutral, 1u, company)
	{
	}

	public override int GetTypeID()
	{
		return 3;
	}

	public override bool WriteDerivedData(Stream st)
	{
		st.WriteUInt(Items.Last().ID);
		return false;
	}
}
