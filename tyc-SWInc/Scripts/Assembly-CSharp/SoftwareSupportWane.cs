using System;
using System.IO;

[Serializable]
public class SoftwareSupportWane : NotificationMessage
{
	public SoftwareCategory Category;

	public SoftwareSupportWane()
	{
	}

	public SoftwareSupportWane(SoftwareCategory cat)
		: base("SoftwareSupportWaning".LocColor(cat.Parent.Name.LocSWFull(cat.Name)), "Software", NotificationManager.NotificationType.Warning)
	{
		Category = cat;
	}

	public override bool WriteDerivedData(Stream st)
	{
		st.WriteUInt(Category.Parent.ID);
		st.WriteUInt(Category.ID);
		return false;
	}

	public override uint AggregateID()
	{
		return Category.ID + Category.Parent.ID * 100;
	}

	public override bool IsAggregate()
	{
		return true;
	}

	public override int GetTypeID()
	{
		return 2;
	}
}
