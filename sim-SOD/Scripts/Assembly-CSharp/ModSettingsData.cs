using System;
using System.Collections.Generic;
using ModIO;

[Serializable]
public class ModSettingsData
{
	public enum ModSource
	{
		local = 0,
		modIO = 1,
		steamWorkshop = 2
	}

	public string name;

	public string version;

	public int loadOrderValue;

	public string creator;

	public string summary;

	public bool enabled;

	public ModSource modSource;

	public string workshopPath;

	public string workshopID;

	public List<string> workshopTags;

	[NonSerialized]
	public UserInstalledMod modData;

	[NonSerialized]
	public string directory;

	public string GetContentDirectory()
	{
		return null;
	}

	public void SaveSettings()
	{
	}
}
