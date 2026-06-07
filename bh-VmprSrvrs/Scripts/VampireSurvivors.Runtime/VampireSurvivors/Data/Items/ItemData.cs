using System;
using Poncle.Schema.Attributes.Attributes;

namespace VampireSurvivors.Data.Items
{
	[Serializable]
	[Title("Item")]
	public class ItemData
	{
		[Title("Name")]
		public string name { get; set; }

		[Title("Description")]
		public string description { get; set; }

		[Title("Achievement Tips")]
		public string achievementTips { get; set; }

		[Title("Tips")]
		public string tips { get; set; }

		[Title("Texture")]
		public string texture { get; set; }

		[Title("Frame Name")]
		public string frameName { get; set; }

		[Title("Picked Up Amount")]
		public int pickedupAmount { get; set; }

		[Title("Rarity")]
		public float rarity { get; set; }

		[Title("Unlocks At")]
		public int unlocksAt { get; set; }

		[Title("Value")]
		public float value { get; set; }

		[Title("In Treasures")]
		public bool inTreasures { get; set; }

		[Title("Seen")]
		public bool seen { get; set; }

		[Title("Is Rare")]
		public bool isRare { get; set; }

		[Title("Is Relic")]
		public bool isRelic { get; set; }

		[Title("Is Unlocked")]
		public bool isUnlocked { get; set; }

		[Title("Hidden")]
		public bool hidden { get; set; }

		[Title("Always Hidden")]
		public bool alwaysHidden { get; set; }

		[Title("Fever MS")]
		public int feverMS { get; set; }

		[Title("Is Special Option")]
		public bool isSpecialOption { get; set; }

		[Title("Sealable")]
		public bool sealable { get; set; }

		[Title("Requires DLC")]
		public DlcType? requiresDLC { get; set; }

		[Title("Requires Item")]
		public ItemType? requiresItem { get; set; }

		[Title("Requires Arcana")]
		public ArcanaType? requiresArcana { get; set; }

		[Title("Collection Frame")]
		public string collectionFrame { get; set; }

		[Title("Show Above All")]
		public bool showAboveAll { get; set; }

		[Title("Exclude From Default Loot Table")]
		public bool excludeFromDefaultLootTable { get; set; }

		public bool ignoreForcedMovement { get; set; }

		[Title("Content Group")]
		public ContentGroupType contentGroup { get; set; }

		public string GetLocalizedDescription(ItemType type)
		{
			return null;
		}

		public string GetLocalizedTips(ItemType type)
		{
			return null;
		}

		public string GetLocalizedName(ItemType type)
		{
			return null;
		}

		public string GetLocalizedAchievementTips(ItemType type)
		{
			return null;
		}

		public string GetLocalPrefix(ItemType t)
		{
			return null;
		}
	}
}
