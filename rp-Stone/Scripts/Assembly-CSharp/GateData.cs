using System;

[Serializable]
public class GateData
{
	[Serializable]
	public class Shop
	{
		public string name;

		public string id;

		public string iconId;

		public static Shop FromString(string sjson)
		{
			return new Shop
			{
				name = SlimJson.Parse(sjson, "name"),
				id = SlimJson.Parse(sjson, "id"),
				iconId = SlimJson.Parse(sjson, "iconId")
			};
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			SlimJson.AddProperty("name", name);
			SlimJson.AddProperty("id", id);
			SlimJson.AddProperty("iconId", iconId);
			return SlimJson.EndSerialization();
		}
	}

	[Serializable]
	public class Area
	{
		public string name;

		public string id;

		public string[] questIds;

		public Shop shop;

		public static Area FromString(string sjson)
		{
			return new Area
			{
				name = SlimJson.Parse(sjson, "name"),
				id = SlimJson.Parse(sjson, "id"),
				questIds = SlimJson.ParseArray(sjson, "questIds"),
				shop = SlimJson.Parse(sjson, "shop", Shop.FromString)
			};
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			SlimJson.AddProperty("name", name);
			SlimJson.AddProperty("id", id);
			SlimJson.AddProperty("questIds", questIds);
			SlimJson.AddProperty("shop", shop.ToString());
			return SlimJson.EndSerialization();
		}
	}

	[Serializable]
	public class Item
	{
		public int count;

		public int cost;

		public int dropIncidence;

		public int shopIncidence;

		public string itemId;

		public Data.Resource resource;

		public string iconId;

		public string pickupId;

		public static Item FromString(string sjson)
		{
			return new Item
			{
				count = SlimJson.ParseInt(sjson, "count"),
				cost = SlimJson.ParseInt(sjson, "cost"),
				dropIncidence = SlimJson.ParseInt(sjson, "dropIncidence"),
				shopIncidence = SlimJson.ParseInt(sjson, "shopIncidence"),
				itemId = SlimJson.Parse(sjson, "itemId"),
				resource = SlimJson.ParseEnum<Data.Resource>(sjson, "resource"),
				iconId = SlimJson.Parse(sjson, "iconId"),
				pickupId = SlimJson.Parse(sjson, "pickupId")
			};
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			SlimJson.AddProperty("count", count);
			SlimJson.AddProperty("cost", cost);
			SlimJson.AddProperty("dropIncidence", dropIncidence);
			SlimJson.AddProperty("shopIncidence", shopIncidence);
			SlimJson.AddProperty("itemId", itemId);
			SlimJson.AddProperty("resource", resource.ToString());
			SlimJson.AddProperty("iconId", iconId);
			SlimJson.AddProperty("pickupId", pickupId);
			return SlimJson.EndSerialization();
		}
	}

	[Serializable]
	public class Result
	{
		public int enemiesKilled;

		public int moneyLeft;

		public int consumablePoints;

		public int totalScore;

		public static Result FromString(string sjson)
		{
			return new Result
			{
				enemiesKilled = SlimJson.ParseInt(sjson, "enemiesKilled"),
				moneyLeft = SlimJson.ParseInt(sjson, "moneyLeft"),
				consumablePoints = SlimJson.ParseInt(sjson, "consumablePoints"),
				totalScore = SlimJson.ParseInt(sjson, "totalScore")
			};
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			SlimJson.AddProperty("enemiesKilled", enemiesKilled);
			SlimJson.AddProperty("moneyLeft", moneyLeft);
			SlimJson.AddProperty("consumablePoints", consumablePoints);
			SlimJson.AddProperty("totalScore", totalScore);
			return SlimJson.EndSerialization();
		}
	}

	public string name;

	public string id;

	public string background;

	public int lockX;

	public int lockY;

	public string lockedSfx;

	public Data.StoryBit lockedDialog;

	public string[] unlockRequires;

	public string finalBoss;

	public Area[] areas;

	public Item[] items;

	public Data.Quest[] quests;

	public Data.Quest GetQuestById(string questId)
	{
		for (int i = 0; i < quests.Length; i++)
		{
			if (quests[i].id == questId)
			{
				return quests[i];
			}
		}
		return null;
	}

	public static GateData FromString(string sjson)
	{
		return new GateData
		{
			name = SlimJson.Parse(sjson, "name"),
			id = SlimJson.Parse(sjson, "id"),
			background = SlimJson.Parse(sjson, "background"),
			lockX = SlimJson.ParseInt(sjson, "lockX"),
			lockY = SlimJson.ParseInt(sjson, "lockY"),
			lockedSfx = SlimJson.Parse(sjson, "lockedSfx"),
			lockedDialog = SlimJson.Parse(sjson, "lockedDialog", Data.StoryBit.FromString),
			unlockRequires = SlimJson.ParseArray(sjson, "unlockRequires"),
			finalBoss = SlimJson.Parse(sjson, "finalBoss"),
			areas = SlimJson.ParseArray(sjson, "areas", Area.FromString),
			items = SlimJson.ParseArray(sjson, "items", Item.FromString),
			quests = SlimJson.ParseArray(sjson, "quests", Data.Quest.FromString)
		};
	}

	public override string ToString()
	{
		SlimJson.BeginSerialization();
		SlimJson.AddProperty("name", name);
		SlimJson.AddProperty("id", id);
		SlimJson.AddProperty("background", background);
		SlimJson.AddProperty("lockX", lockX);
		SlimJson.AddProperty("lockY", lockY);
		SlimJson.AddProperty("lockedSfx", lockedSfx);
		SlimJson.AddProperty("lockedDialog", lockedDialog.ToString());
		SlimJson.AddProperty("unlockRequires", unlockRequires);
		SlimJson.AddProperty("finalBoss", finalBoss);
		SlimJson.AddProperty("areas", areas);
		SlimJson.AddProperty("items", items);
		SlimJson.AddProperty("quests", quests);
		return SlimJson.EndSerialization();
	}
}
