using Steamworks;

public class DummyWorkshopItem : IWorkshopItem
{
	public string Type;

	public string Path;

	public DummyWorkshopItem(string type, string path, string itemTitle, PublishedFileId_t? steamID)
	{
		Type = type;
		Path = path;
		InitMod(Path, 0f);
		SetName(itemTitle, false);
		UpdateSteam(steamID, false);
	}

	public override string GetWorkshopType()
	{
		return Type;
	}

	public override string[] GetValidExts()
	{
		return new string[0];
	}

	public override string[] ExtraTags()
	{
		return new string[0];
	}

	public override string GetActualString()
	{
		return base.ItemTitle;
	}
}
