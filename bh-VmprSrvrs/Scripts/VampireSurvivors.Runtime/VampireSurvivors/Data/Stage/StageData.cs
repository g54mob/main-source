using System;
using System.Collections.Generic;
using Poncle.Schema.Attributes.Attributes;
using VampireSurvivors.App.Data;
using VampireSurvivors.App.Objects;

namespace VampireSurvivors.Data.Stage
{
	[Serializable]
	public class StageData
	{
		[Title("Order")]
		public int order { get; set; }

		[Title("Tileset Stage Type")]
		public StageType? tilesetStageType { get; set; }

		[Title("Name")]
		public string stageName { get; set; }

		[Title("Description")]
		public string description { get; set; }

		[Title("UI Texture")]
		public string uiTexture { get; set; }

		[Title("UI Frame")]
		public string uiFrame { get; set; }

		[Title("Texture")]
		public string texture { get; set; }

		[Title("Bestiary BG")]
		public string bestiaryBG { get; set; }

		[Title("Stage Number")]
		public string stageNumber { get; set; }

		[Title("Frame Name")]
		public string frameName { get; set; }

		[Title("Frame Name Unlock")]
		public string frameNameUnlock { get; set; }

		[Title("Unlocked")]
		public bool unlocked { get; set; }

		public BgmType BGM { get; set; }

		[Title("Side BGM")]
		public BgmType? sideBBGM { get; set; }

		[Title("Legacy BGM")]
		public string legacyBGM { get; set; }

		[Title("Tips")]
		public string tips { get; set; }

		[Title("Hyper Tips")]
		public string hyperTips { get; set; }

		[Title("Valid for Character Data")]
		public bool validForCharcaterData { get; set; }

		[Title("Hidden")]
		public bool hidden { get; set; }

		[Title("Always Hidden")]
		public bool alwaysHidden { get; set; }

		[Title("Mods")]
		public StageModifiers mods { get; set; }

		[Title("Hyper")]
		public StageModifiers hyper { get; set; }

		[Title("Inverse")]
		public StageModifiers inverse { get; set; }

		[Title("Tileset")]
		public Tileset tileset { get; set; }

		[Title("Background")]
		public Background background { get; set; }

		[Title("Pools Mapping")]
		public List<PoolsMapping> poolsMapping { get; set; }

		[Title("Spawn Type")]
		public string spawnType { get; set; }

		[Title("Starting Spawns")]
		public int startingSpawns { get; set; }

		[Title("Minute")]
		[Required]
		public int minute { get; set; }

		[Title("Random Minutes")]
		public bool randomMinutes { get; set; }

		[Title("Destructible Type")]
		public string destructibleType { get; set; }

		[Title("Destructible Frequency")]
		public float destructibleFreq { get; set; }

		[Title("Destructible Chance")]
		public float destructibleChance { get; set; }

		[Title("Destructible Chance Max")]
		public float destructibleChanceMax { get; set; }

		[Title("Max Destructibles")]
		public int maxDestructibles { get; set; }

		[Title("BG Texture Name")]
		public string BGTextureName { get; set; }

		[Title("Extra Texture")]
		public string Extra_Texture { get; set; }

		[Title("Extra Audio")]
		public BgmType Extra_Audio { get; set; }

		[Title("Is Merchant Banned")]
		public bool isMerchantBanned { get; set; }

		[Title("Is Speed Up Banned")]
		public bool isSpeedupBanned { get; set; }

		[Title("Has Lights")]
		public bool hasLights { get; set; }

		[Title("Disable Global Light")]
		public bool disableGlobalLight { get; set; }

		[Title("Has Character Spotlight")]
		public bool hasCharacterSpotlight { get; set; }

		[Title("Day Night")]
		public bool dayNight { get; set; }

		[Title("Day Color")]
		public uint DayColor { get; set; }

		[Title("Night Color")]
		public uint NightColor { get; set; }

		[Title("Inverse Day Color")]
		public uint InverseDayColor { get; set; }

		[Title("Inverse Night Color")]
		public uint InverseNightColor { get; set; }

		public TilemapTiledJSON tilemapTiledJSON { get; set; }

		public TilemapTiledIMG tilemapTiledIMG { get; set; }

		public TilemapPos tilemapPos { get; set; }

		[Title("Minimum")]
		public int minimum { get; set; }

		[Title("Frequency")]
		public float frequency { get; set; }

		[Title("Zoom")]
		public float? zoom { get; set; }

		[Title("Enemies")]
		[Required]
		public List<EnemyType?> enemies { get; set; }

		[Title("Bosses")]
		public List<EnemyType?> bosses { get; set; }

		public Treasure treasure { get; set; }

		[Title("Arcana Holder")]
		public EnemyType? arcanaHolder { get; set; }

		[Title("Arcana Treasure")]
		public Treasure arcanaTreasure { get; set; }

		[Title("Events")]
		public List<Event> events { get; set; }

		[Title("Pizza Events")]
		public List<Event> pizzaEvents { get; set; }

		[Title("CFF")]
		public CharacterType? cff { get; set; }

		[Title("Loot Table")]
		public List<ItemType> LootTable { get; set; }

		[Title("Relics")]
		public List<ItemType> relics { get; set; }

		[Title("Relics 2")]
		public List<ItemType> relics2 { get; set; }

		[Title("Yellow Relics")]
		public List<ItemType> yellowRelics { get; set; }

		[Title("Preload")]
		public PreloadData preload { get; set; }

		[Title("Adventure Merchants")]
		public List<CustomMerchantData> adventureMerchants { get; set; }

		[Title("Default Followers")]
		public List<FollowerData> defaultFollowers { get; set; }

		[Title("Adventure Price Markup")]
		public float? adventurePriceMarkup { get; set; }

		[Title("Is Racing Stage")]
		public bool isRacingStage { get; set; }

		[Title("Skip Visual Inversion")]
		public bool skipVisualInversion { get; set; }

		[Title("Allow Visual Inversion")]
		public bool allowVisualInversion { get; set; }

		[Title("Biome")]
		public string biome { get; set; }

		[Title("Biomes")]
		public List<string> biomes { get; set; }

		public string GetLocalizedName(StageType sType)
		{
			return null;
		}

		public string GetLocalizedTips(StageType sType)
		{
			return null;
		}

		public string GetLocalizedHyperTips(StageType sType)
		{
			return null;
		}

		public string GetLocalizedDescription(StageType sType)
		{
			return null;
		}

		private string GetPrefix(StageType sType)
		{
			return null;
		}
	}
}
