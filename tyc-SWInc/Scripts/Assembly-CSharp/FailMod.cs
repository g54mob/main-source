using Steamworks;

public class FailMod : IWorkshopItem
{
	public string Type;

	public string Path;

	public string Error;

	public FailMod(string type, string path, string itemTitle, string error, PublishedFileId_t? steamID = null)
	{
		Type = type;
		Path = path;
		Error = error;
		InitMod(Path, 0f);
		SetName(itemTitle, false);
		UpdateSteam(steamID, false);
	}

	public FailMod(string type, string path, string error, PublishedFileId_t? steamID = null)
	{
		Type = type;
		Path = path;
		Error = error;
		InitMod(Path, 0f);
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

	public override string GetExtraInfo()
	{
		return Error;
	}
}
