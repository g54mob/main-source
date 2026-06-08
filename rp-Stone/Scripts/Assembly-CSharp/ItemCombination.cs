using System;

public class ItemCombination
{
	public string itemA;

	public string itemB;

	public string result;

	public DateTime releaseDate;

	public bool IsEnabled()
	{
		return DateTime.Now >= releaseDate;
	}

	public static ItemCombination FromString(string sjson)
	{
		ItemCombination itemCombination = new ItemCombination();
		itemCombination.itemA = SlimJson.Parse(sjson, "itemA");
		itemCombination.itemB = SlimJson.Parse(sjson, "itemB");
		itemCombination.result = SlimJson.Parse(sjson, "result");
		if (SlimJson.HasKey(sjson, "releaseDate"))
		{
			itemCombination.releaseDate = SlimJson.ParseDateTime(sjson, "releaseDate");
		}
		else
		{
			itemCombination.releaseDate = new DateTime(2019, 8, 8);
		}
		return itemCombination;
	}

	public override string ToString()
	{
		SlimJson.BeginSerialization();
		SlimJson.AddProperty("itemA", itemA);
		SlimJson.AddProperty("itemB", itemB);
		SlimJson.AddProperty("result", result);
		return SlimJson.EndSerialization();
	}
}
