using System;

public class CraftEntry
{
	public string result;

	public string itemA;

	public string itemB;

	public string name_override;

	public bool element_result;

	public bool elementA;

	public bool elementB;

	public DateTime releaseDate;

	public bool IsEnabled()
	{
		return DateTime.Now >= releaseDate;
	}

	public static CraftEntry FromString(string sjson)
	{
		CraftEntry craftEntry = new CraftEntry();
		craftEntry.result = SlimJson.Parse(sjson, "result");
		craftEntry.itemA = SlimJson.Parse(sjson, "itemA");
		craftEntry.itemB = SlimJson.Parse(sjson, "itemB");
		craftEntry.name_override = SlimJson.Parse(sjson, "name_override");
		craftEntry.element_result = SlimJson.ParseBool(sjson, "element_result");
		craftEntry.elementA = SlimJson.ParseBool(sjson, "elementA");
		craftEntry.elementB = SlimJson.ParseBool(sjson, "elementB");
		if (SlimJson.HasKey(sjson, "releaseDate"))
		{
			craftEntry.releaseDate = SlimJson.ParseDateTime(sjson, "releaseDate");
		}
		else
		{
			craftEntry.releaseDate = new DateTime(2019, 8, 8);
		}
		return craftEntry;
	}

	public override string ToString()
	{
		SlimJson.BeginSerialization();
		bool identationEnabled = SlimJson.identationEnabled;
		SlimJson.identationEnabled = false;
		SlimJson.AddProperty("result", result);
		SlimJson.AddProperty("itemA", itemA);
		SlimJson.AddProperty("itemB", itemB);
		if (!string.IsNullOrEmpty(name_override))
		{
			SlimJson.AddProperty("name_override", name_override);
		}
		if (element_result)
		{
			SlimJson.AddProperty("element_result", element_result);
		}
		if (elementA)
		{
			SlimJson.AddProperty("elementA", elementA);
		}
		if (elementB)
		{
			SlimJson.AddProperty("elementB", elementB);
		}
		SlimJson.identationEnabled = identationEnabled;
		return SlimJson.EndSerialization();
	}
}
