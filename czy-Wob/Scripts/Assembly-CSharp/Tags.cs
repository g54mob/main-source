using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public static class Tags
{
	public static string ALL = "all";

	public static string FOOD = "food";

	public static string DOG = "dog";

	public static string DRAGGABLE = "draggable";

	public static string EGG = "egg";

	public static string PIPE = "Pipe";

	public static string CAPSULE = "capsule";

	public static string TOY = "toy";

	public static string PLANT = "plant";

	public static string COCOON = "cocoon";

	public static string CLICKABLE_OBJECT = "ClickableObject";

	public static string PUDDLE = "puddle";

	public static string POOP = "poop";

	public static string FOOD_DISPENSOR = "FoodDispensor";

	public static string PHYSICS_PLANT = "PhysicsPlant";

	public static string DOG_DEN = "DogDen";

	public static string HOLE = "Hole";

	public static string DIRT_CLUMP = "DirtClump";

	public static string DOG_CORE = "DogCore";

	public static string SEED_PACKET = "SeedPacket";

	public static string DEN_UPGRADE = "DenUpgrade";

	public static string TV = "TV";

	public static string FAN = "Fan";

	public static string DOG_STACK = "DogStack";

	public static string DOG_MEMORIAL = "DogMemorial";

	public static string BOPPER = "Bopper";

	public static string MUSIC_PLAYER = "MusicPlayer";

	public static string STORAGE_CHEST = "StorageChest";

	public static string VACUUM = "Vacuum";

	public static string SNOWBALL = "Snowball";

	public static string GIFT = "Gift";

	public static string SNOWGLOBE = "Snowglobe";

	public static string PRICKLYPEAR = "PricklyPear";

	public static string SAMPLESTABLE = "SamplesTable";

	private static List<string> liquidSpreadableObjects = new List<string>
	{
		FOOD, DOG, DRAGGABLE, EGG, POOP, CAPSULE, TOY, COCOON, DIRT_CLUMP, DOG_CORE,
		SEED_PACKET, DEN_UPGRADE, SNOWBALL
	};

	public static List<string> GetLiquidSpreadableObjects()
	{
		return liquidSpreadableObjects;
	}

	public static string GetTagFromTagsEnum(TagsEnum enumVal)
	{
		if (enumVal == TagsEnum.ALL)
		{
			DebugUtil.Print("TagsEnum.ALL should not be piped through this function. Fix this please!");
			return ALL;
		}
		BindingFlags bindingAttr = BindingFlags.Static | BindingFlags.Public;
		string name = Enum.GetName(typeof(TagsEnum), enumVal);
		List<object> list = (from field in typeof(Tags).GetFields(bindingAttr)
			select field.GetValue(typeof(Tags))).ToList();
		List<string> list2 = (from field in typeof(Tags).GetFields(bindingAttr)
			select field.Name).ToList();
		for (int num = 0; num < list2.Count; num++)
		{
			if (list2[num] != null && list2[num] == name)
			{
				return (string)list[num];
			}
		}
		DebugUtil.Print("No appropriate Tag found for " + enumVal);
		return "";
	}

	public static TagsEnum GetTagsEnumFromTag(string tagVal)
	{
		BindingFlags bindingAttr = BindingFlags.Static | BindingFlags.Public;
		List<object> list = (from field in typeof(Tags).GetFields(bindingAttr)
			select field.GetValue(typeof(Tags))).ToList();
		List<string> list2 = (from field in typeof(Tags).GetFields(bindingAttr)
			select field.Name).ToList();
		for (int num = 0; num < list.Count; num++)
		{
			if (list[num] != null && (string)list[num] == tagVal)
			{
				return (TagsEnum)Enum.Parse(typeof(TagsEnum), list2[num]);
			}
		}
		DebugUtil.Print("No appropriate Tag found for " + tagVal);
		return TagsEnum.ALL;
	}
}
