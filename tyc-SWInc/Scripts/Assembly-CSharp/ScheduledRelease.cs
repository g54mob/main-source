using System;

[Serializable]
public class ScheduledRelease : ICalenderItem
{
	public string Name;

	public uint ID;

	public SDateTime? ReleaseDate;

	public SoftwareProduct SequelTo;

	public SoftwareCategory Category;

	public Company DevCompany;

	public ScheduledRelease(string name, uint id, SoftwareCategory cat, SDateTime? releaseDate, SoftwareProduct sequelTo, Company devCompany)
	{
		Name = name;
		Category = cat;
		ID = id;
		ReleaseDate = releaseDate;
		SequelTo = sequelTo;
		DevCompany = devCompany;
	}

	public ScheduledRelease()
	{
	}

	public string GetTitle()
	{
		return Name;
	}

	public string GetDescription()
	{
		return Category.GetActualString() + "\n" + DevCompany.Name;
	}

	public SDateTime? GetTime()
	{
		return ReleaseDate;
	}

	public ComingReleaseWindow.EventType GetEventType()
	{
		if (!DevCompany.LocalPlayer)
		{
			return ComingReleaseWindow.EventType.AIRelease;
		}
		return ComingReleaseWindow.EventType.PlayerRelease;
	}

	public bool MatchSWFilter(SoftwareType t, SoftwareCategory c)
	{
		if (t == null || (c != null && t == c.Parent))
		{
			if (c != null)
			{
				return c == Category;
			}
			return true;
		}
		return false;
	}

	public override string ToString()
	{
		return Name + ": " + (ReleaseDate.HasValue ? ReleaseDate.Value.ToCompactString() : "Not scheduled");
	}
}
