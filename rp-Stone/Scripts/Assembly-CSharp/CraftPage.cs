using System.Collections.Generic;

public class CraftPage
{
	public List<CraftEntry> entries;

	public static CraftPage FromString(string sjson)
	{
		CraftPage craftPage = new CraftPage();
		CraftEntry[] collection = SlimJson.ParseArray(sjson, "entries", CraftEntry.FromString);
		craftPage.entries = new List<CraftEntry>(collection);
		return craftPage;
	}

	public override string ToString()
	{
		SlimJson.BeginSerialization();
		SlimJson.AddProperty("entries", entries.ToArray());
		return SlimJson.EndSerialization();
	}
}
