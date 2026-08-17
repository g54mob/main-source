using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using VampireSurvivors.App.Data;
using VampireSurvivors.App.Objects;

namespace VampireSurvivors.Data.Stage;

[Serializable]
public class StageData
{
	private int _003Corder_003Ek__BackingField;

	private StageType? _003CtilesetStageType_003Ek__BackingField;

	private string _003CstageName_003Ek__BackingField;

	private string _003Cdescription_003Ek__BackingField;

	private string _003CuiTexture_003Ek__BackingField;

	private string _003CuiFrame_003Ek__BackingField;

	private string _003Ctexture_003Ek__BackingField;

	private string _003CbestiaryBG_003Ek__BackingField;

	private string _003CstageNumber_003Ek__BackingField;

	private string _003CframeName_003Ek__BackingField;

	private string _003CframeNameUnlock_003Ek__BackingField;

	private bool _003Cunlocked_003Ek__BackingField;

	private BgmType _003CBGM_003Ek__BackingField;

	private BgmType? _003CsideBBGM_003Ek__BackingField;

	private string _003ClegacyBGM_003Ek__BackingField;

	private string _003Ctips_003Ek__BackingField;

	private string _003ChyperTips_003Ek__BackingField;

	private bool _003CvalidForCharcaterData_003Ek__BackingField;

	private bool _003Chidden_003Ek__BackingField;

	private bool _003CalwaysHidden_003Ek__BackingField;

	private StageModifiers _003Cmods_003Ek__BackingField;

	private StageModifiers _003Chyper_003Ek__BackingField;

	private StageModifiers _003Cinverse_003Ek__BackingField;

	private Tileset _003Ctileset_003Ek__BackingField;

	private Background _003Cbackground_003Ek__BackingField;

	private List<PoolsMapping> _003CpoolsMapping_003Ek__BackingField;

	private string _003CspawnType_003Ek__BackingField;

	private int _003CstartingSpawns_003Ek__BackingField;

	private int _003Cminute_003Ek__BackingField;

	private bool _003CrandomMinutes_003Ek__BackingField;

	private string _003CdestructibleType_003Ek__BackingField;

	private float _003CdestructibleFreq_003Ek__BackingField;

	private float _003CdestructibleChance_003Ek__BackingField;

	private float _003CdestructibleChanceMax_003Ek__BackingField;

	private int _003CmaxDestructibles_003Ek__BackingField;

	private string _003CBGTextureName_003Ek__BackingField;

	private string _003CExtra_Texture_003Ek__BackingField;

	private BgmType _003CExtra_Audio_003Ek__BackingField;

	private bool _003CisMerchantBanned_003Ek__BackingField;

	private bool _003CisSpeedupBanned_003Ek__BackingField;

	private bool _003ChasLights_003Ek__BackingField;

	private bool _003CdisableGlobalLight_003Ek__BackingField;

	private bool _003ChasCharacterSpotlight_003Ek__BackingField;

	private bool _003CdayNight_003Ek__BackingField;

	private uint _003CDayColor_003Ek__BackingField;

	private uint _003CNightColor_003Ek__BackingField;

	private uint _003CInverseDayColor_003Ek__BackingField;

	private uint _003CInverseNightColor_003Ek__BackingField;

	private TilemapTiledJSON _003CtilemapTiledJSON_003Ek__BackingField;

	private TilemapTiledIMG _003CtilemapTiledIMG_003Ek__BackingField;

	private TilemapPos _003CtilemapPos_003Ek__BackingField;

	private int _003Cminimum_003Ek__BackingField;

	private float _003Cfrequency_003Ek__BackingField;

	private float? _003Czoom_003Ek__BackingField;

	private List<EnemyType?> _003Cenemies_003Ek__BackingField;

	private List<EnemyType?> _003Cbosses_003Ek__BackingField;

	private Treasure _003Ctreasure_003Ek__BackingField;

	private EnemyType? _003CarcanaHolder_003Ek__BackingField;

	private Treasure _003CarcanaTreasure_003Ek__BackingField;

	private List<Event> _003Cevents_003Ek__BackingField;

	private List<Event> _003CpizzaEvents_003Ek__BackingField;

	private CharacterType? _003Ccff_003Ek__BackingField;

	private List<ItemType> _003CLootTable_003Ek__BackingField;

	private List<ItemType> _003Crelics_003Ek__BackingField;

	private List<ItemType> _003Crelics2_003Ek__BackingField;

	private List<ItemType> _003CyellowRelics_003Ek__BackingField;

	private PreloadData _003Cpreload_003Ek__BackingField;

	private List<CustomMerchantData> _003CadventureMerchants_003Ek__BackingField;

	private List<FollowerData> _003CdefaultFollowers_003Ek__BackingField;

	private float? _003CadventurePriceMarkup_003Ek__BackingField;

	private bool _003CisRacingStage_003Ek__BackingField;

	private bool _003CskipVisualInversion_003Ek__BackingField;

	private bool _003CallowVisualInversion_003Ek__BackingField;

	private string _003Cbiome_003Ek__BackingField;

	private List<string> _003Cbiomes_003Ek__BackingField;

	public int order
	{
		get
		{
			return _003Corder_003Ek__BackingField;
		}
		set
		{
			_003Corder_003Ek__BackingField = value;
		}
	}

	public StageType? tilesetStageType
	{
		get
		{
			return _003CtilesetStageType_003Ek__BackingField;
		}
		set
		{
			_003CtilesetStageType_003Ek__BackingField = value;
		}
	}

	public string stageName
	{
		get
		{
			return _003CstageName_003Ek__BackingField;
		}
		set
		{
			_003CstageName_003Ek__BackingField = value;
		}
	}

	public string description
	{
		get
		{
			return _003Cdescription_003Ek__BackingField;
		}
		set
		{
			_003Cdescription_003Ek__BackingField = value;
		}
	}

	public string uiTexture
	{
		get
		{
			return _003CuiTexture_003Ek__BackingField;
		}
		set
		{
			_003CuiTexture_003Ek__BackingField = value;
		}
	}

	public string uiFrame
	{
		get
		{
			return _003CuiFrame_003Ek__BackingField;
		}
		set
		{
			_003CuiFrame_003Ek__BackingField = value;
		}
	}

	public string texture
	{
		get
		{
			return _003Ctexture_003Ek__BackingField;
		}
		set
		{
			_003Ctexture_003Ek__BackingField = value;
		}
	}

	public string bestiaryBG
	{
		get
		{
			return _003CbestiaryBG_003Ek__BackingField;
		}
		set
		{
			_003CbestiaryBG_003Ek__BackingField = value;
		}
	}

	public string stageNumber
	{
		get
		{
			return _003CstageNumber_003Ek__BackingField;
		}
		set
		{
			_003CstageNumber_003Ek__BackingField = value;
		}
	}

	public string frameName
	{
		get
		{
			return _003CframeName_003Ek__BackingField;
		}
		set
		{
			_003CframeName_003Ek__BackingField = value;
		}
	}

	public string frameNameUnlock
	{
		get
		{
			return _003CframeNameUnlock_003Ek__BackingField;
		}
		set
		{
			_003CframeNameUnlock_003Ek__BackingField = value;
		}
	}

	public bool unlocked
	{
		get
		{
			return _003Cunlocked_003Ek__BackingField;
		}
		set
		{
			_003Cunlocked_003Ek__BackingField = value;
		}
	}

	public BgmType BGM
	{
		get
		{
			return _003CBGM_003Ek__BackingField;
		}
		set
		{
			_003CBGM_003Ek__BackingField = value;
		}
	}

	public BgmType? sideBBGM
	{
		get
		{
			return _003CsideBBGM_003Ek__BackingField;
		}
		set
		{
			_003CsideBBGM_003Ek__BackingField = value;
		}
	}

	public string legacyBGM
	{
		get
		{
			return _003ClegacyBGM_003Ek__BackingField;
		}
		set
		{
			_003ClegacyBGM_003Ek__BackingField = value;
		}
	}

	public string tips
	{
		get
		{
			return _003Ctips_003Ek__BackingField;
		}
		set
		{
			_003Ctips_003Ek__BackingField = value;
		}
	}

	public string hyperTips
	{
		get
		{
			return _003ChyperTips_003Ek__BackingField;
		}
		set
		{
			_003ChyperTips_003Ek__BackingField = value;
		}
	}

	public bool validForCharcaterData
	{
		get
		{
			return _003CvalidForCharcaterData_003Ek__BackingField;
		}
		set
		{
			_003CvalidForCharcaterData_003Ek__BackingField = value;
		}
	}

	public bool hidden
	{
		get
		{
			return _003Chidden_003Ek__BackingField;
		}
		set
		{
			_003Chidden_003Ek__BackingField = value;
		}
	}

	public bool alwaysHidden
	{
		get
		{
			return _003CalwaysHidden_003Ek__BackingField;
		}
		set
		{
			_003CalwaysHidden_003Ek__BackingField = value;
		}
	}

	public StageModifiers mods
	{
		get
		{
			return _003Cmods_003Ek__BackingField;
		}
		set
		{
			_003Cmods_003Ek__BackingField = value;
		}
	}

	public StageModifiers hyper
	{
		get
		{
			return _003Chyper_003Ek__BackingField;
		}
		set
		{
			_003Chyper_003Ek__BackingField = value;
		}
	}

	public StageModifiers inverse
	{
		get
		{
			return _003Cinverse_003Ek__BackingField;
		}
		set
		{
			_003Cinverse_003Ek__BackingField = value;
		}
	}

	public Tileset tileset
	{
		get
		{
			return _003Ctileset_003Ek__BackingField;
		}
		set
		{
			_003Ctileset_003Ek__BackingField = value;
		}
	}

	public Background background
	{
		get
		{
			return _003Cbackground_003Ek__BackingField;
		}
		set
		{
			_003Cbackground_003Ek__BackingField = value;
		}
	}

	public List<PoolsMapping> poolsMapping
	{
		get
		{
			return _003CpoolsMapping_003Ek__BackingField;
		}
		set
		{
			_003CpoolsMapping_003Ek__BackingField = value;
		}
	}

	public string spawnType
	{
		get
		{
			return _003CspawnType_003Ek__BackingField;
		}
		set
		{
			_003CspawnType_003Ek__BackingField = value;
		}
	}

	public int startingSpawns
	{
		get
		{
			return _003CstartingSpawns_003Ek__BackingField;
		}
		set
		{
			_003CstartingSpawns_003Ek__BackingField = value;
		}
	}

	public int minute
	{
		get
		{
			return _003Cminute_003Ek__BackingField;
		}
		set
		{
			_003Cminute_003Ek__BackingField = value;
		}
	}

	public bool randomMinutes
	{
		get
		{
			return _003CrandomMinutes_003Ek__BackingField;
		}
		set
		{
			_003CrandomMinutes_003Ek__BackingField = value;
		}
	}

	public string destructibleType
	{
		get
		{
			return _003CdestructibleType_003Ek__BackingField;
		}
		set
		{
			_003CdestructibleType_003Ek__BackingField = value;
		}
	}

	public float destructibleFreq
	{
		get
		{
			return _003CdestructibleFreq_003Ek__BackingField;
		}
		set
		{
			_003CdestructibleFreq_003Ek__BackingField = value;
		}
	}

	public float destructibleChance
	{
		get
		{
			return _003CdestructibleChance_003Ek__BackingField;
		}
		set
		{
			_003CdestructibleChance_003Ek__BackingField = value;
		}
	}

	public float destructibleChanceMax
	{
		get
		{
			return _003CdestructibleChanceMax_003Ek__BackingField;
		}
		set
		{
			_003CdestructibleChanceMax_003Ek__BackingField = value;
		}
	}

	public int maxDestructibles
	{
		get
		{
			return _003CmaxDestructibles_003Ek__BackingField;
		}
		set
		{
			_003CmaxDestructibles_003Ek__BackingField = value;
		}
	}

	public string BGTextureName
	{
		get
		{
			return _003CBGTextureName_003Ek__BackingField;
		}
		set
		{
			_003CBGTextureName_003Ek__BackingField = value;
		}
	}

	public string Extra_Texture
	{
		get
		{
			return _003CExtra_Texture_003Ek__BackingField;
		}
		set
		{
			_003CExtra_Texture_003Ek__BackingField = value;
		}
	}

	public BgmType Extra_Audio
	{
		get
		{
			return _003CExtra_Audio_003Ek__BackingField;
		}
		set
		{
			_003CExtra_Audio_003Ek__BackingField = value;
		}
	}

	public bool isMerchantBanned
	{
		get
		{
			return _003CisMerchantBanned_003Ek__BackingField;
		}
		set
		{
			_003CisMerchantBanned_003Ek__BackingField = value;
		}
	}

	public bool isSpeedupBanned
	{
		get
		{
			return _003CisSpeedupBanned_003Ek__BackingField;
		}
		set
		{
			_003CisSpeedupBanned_003Ek__BackingField = value;
		}
	}

	public bool hasLights
	{
		get
		{
			return _003ChasLights_003Ek__BackingField;
		}
		set
		{
			_003ChasLights_003Ek__BackingField = value;
		}
	}

	public bool disableGlobalLight
	{
		get
		{
			return _003CdisableGlobalLight_003Ek__BackingField;
		}
		set
		{
			_003CdisableGlobalLight_003Ek__BackingField = value;
		}
	}

	public bool hasCharacterSpotlight
	{
		get
		{
			return _003ChasCharacterSpotlight_003Ek__BackingField;
		}
		set
		{
			_003ChasCharacterSpotlight_003Ek__BackingField = value;
		}
	}

	public bool dayNight
	{
		get
		{
			return _003CdayNight_003Ek__BackingField;
		}
		set
		{
			_003CdayNight_003Ek__BackingField = value;
		}
	}

	public uint DayColor
	{
		get
		{
			return _003CDayColor_003Ek__BackingField;
		}
		set
		{
			_003CDayColor_003Ek__BackingField = value;
		}
	}

	public uint NightColor
	{
		get
		{
			return _003CNightColor_003Ek__BackingField;
		}
		set
		{
			_003CNightColor_003Ek__BackingField = value;
		}
	}

	public uint InverseDayColor
	{
		get
		{
			return _003CInverseDayColor_003Ek__BackingField;
		}
		set
		{
			_003CInverseDayColor_003Ek__BackingField = value;
		}
	}

	public uint InverseNightColor
	{
		get
		{
			return _003CInverseNightColor_003Ek__BackingField;
		}
		set
		{
			_003CInverseNightColor_003Ek__BackingField = value;
		}
	}

	public TilemapTiledJSON tilemapTiledJSON
	{
		get
		{
			return _003CtilemapTiledJSON_003Ek__BackingField;
		}
		set
		{
			_003CtilemapTiledJSON_003Ek__BackingField = value;
		}
	}

	public TilemapTiledIMG tilemapTiledIMG
	{
		get
		{
			return _003CtilemapTiledIMG_003Ek__BackingField;
		}
		set
		{
			_003CtilemapTiledIMG_003Ek__BackingField = value;
		}
	}

	public TilemapPos tilemapPos
	{
		get
		{
			return _003CtilemapPos_003Ek__BackingField;
		}
		set
		{
			_003CtilemapPos_003Ek__BackingField = value;
		}
	}

	public int minimum
	{
		get
		{
			return _003Cminimum_003Ek__BackingField;
		}
		set
		{
			_003Cminimum_003Ek__BackingField = value;
		}
	}

	public float frequency
	{
		get
		{
			return _003Cfrequency_003Ek__BackingField;
		}
		set
		{
			_003Cfrequency_003Ek__BackingField = value;
		}
	}

	public float? zoom
	{
		get
		{
			return _003Czoom_003Ek__BackingField;
		}
		set
		{
			_003Czoom_003Ek__BackingField = value;
		}
	}

	public List<EnemyType?> enemies
	{
		get
		{
			return _003Cenemies_003Ek__BackingField;
		}
		set
		{
			_003Cenemies_003Ek__BackingField = value;
		}
	}

	public List<EnemyType?> bosses
	{
		get
		{
			return _003Cbosses_003Ek__BackingField;
		}
		set
		{
			_003Cbosses_003Ek__BackingField = value;
		}
	}

	public Treasure treasure
	{
		get
		{
			return _003Ctreasure_003Ek__BackingField;
		}
		set
		{
			_003Ctreasure_003Ek__BackingField = value;
		}
	}

	public EnemyType? arcanaHolder
	{
		get
		{
			return _003CarcanaHolder_003Ek__BackingField;
		}
		set
		{
			_003CarcanaHolder_003Ek__BackingField = value;
		}
	}

	public Treasure arcanaTreasure
	{
		get
		{
			return _003CarcanaTreasure_003Ek__BackingField;
		}
		set
		{
			_003CarcanaTreasure_003Ek__BackingField = value;
		}
	}

	public List<Event> events
	{
		get
		{
			return _003Cevents_003Ek__BackingField;
		}
		set
		{
			_003Cevents_003Ek__BackingField = value;
		}
	}

	public List<Event> pizzaEvents
	{
		get
		{
			return _003CpizzaEvents_003Ek__BackingField;
		}
		set
		{
			_003CpizzaEvents_003Ek__BackingField = value;
		}
	}

	public CharacterType? cff
	{
		get
		{
			return _003Ccff_003Ek__BackingField;
		}
		set
		{
			_003Ccff_003Ek__BackingField = value;
		}
	}

	public List<ItemType> LootTable
	{
		get
		{
			return _003CLootTable_003Ek__BackingField;
		}
		set
		{
			_003CLootTable_003Ek__BackingField = value;
		}
	}

	public List<ItemType> relics
	{
		get
		{
			return _003Crelics_003Ek__BackingField;
		}
		set
		{
			_003Crelics_003Ek__BackingField = value;
		}
	}

	public List<ItemType> relics2
	{
		get
		{
			return _003Crelics2_003Ek__BackingField;
		}
		set
		{
			_003Crelics2_003Ek__BackingField = value;
		}
	}

	public List<ItemType> yellowRelics
	{
		get
		{
			return _003CyellowRelics_003Ek__BackingField;
		}
		set
		{
			_003CyellowRelics_003Ek__BackingField = value;
		}
	}

	public PreloadData preload
	{
		get
		{
			return _003Cpreload_003Ek__BackingField;
		}
		set
		{
			_003Cpreload_003Ek__BackingField = value;
		}
	}

	public List<CustomMerchantData> adventureMerchants
	{
		get
		{
			return _003CadventureMerchants_003Ek__BackingField;
		}
		set
		{
			_003CadventureMerchants_003Ek__BackingField = value;
		}
	}

	public List<FollowerData> defaultFollowers
	{
		get
		{
			return _003CdefaultFollowers_003Ek__BackingField;
		}
		set
		{
			_003CdefaultFollowers_003Ek__BackingField = value;
		}
	}

	public float? adventurePriceMarkup
	{
		get
		{
			return _003CadventurePriceMarkup_003Ek__BackingField;
		}
		set
		{
			_003CadventurePriceMarkup_003Ek__BackingField = value;
		}
	}

	public bool isRacingStage
	{
		get
		{
			return _003CisRacingStage_003Ek__BackingField;
		}
		set
		{
			_003CisRacingStage_003Ek__BackingField = value;
		}
	}

	public bool skipVisualInversion
	{
		get
		{
			return _003CskipVisualInversion_003Ek__BackingField;
		}
		set
		{
			_003CskipVisualInversion_003Ek__BackingField = value;
		}
	}

	public bool allowVisualInversion
	{
		get
		{
			return _003CallowVisualInversion_003Ek__BackingField;
		}
		set
		{
			_003CallowVisualInversion_003Ek__BackingField = value;
		}
	}

	public string biome
	{
		get
		{
			return _003Cbiome_003Ek__BackingField;
		}
		set
		{
			_003Cbiome_003Ek__BackingField = value;
		}
	}

	public List<string> biomes
	{
		get
		{
			return _003Cbiomes_003Ek__BackingField;
		}
		set
		{
			_003Cbiomes_003Ek__BackingField = value;
		}
	}

	public string GetLocalizedName(StageType sType)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C74]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string prefix = GetPrefix(sType);
		return prefix + "stageName";
	}

	public string GetLocalizedTips(StageType sType)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C75]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string prefix = GetPrefix(sType);
		return prefix + "tips";
	}

	public string GetLocalizedHyperTips(StageType sType)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C76]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string prefix = GetPrefix(sType);
		return prefix + "hyperTips";
	}

	public string GetLocalizedDescription(StageType sType)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2C77]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string prefix = GetPrefix(sType);
		return prefix + "description";
	}

	private unsafe string GetPrefix(StageType sType)
	{
		//IL_000e: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		return "stageLang/{" + text + "}";
	}

	public unsafe StageData()
	{
		//IL_000e: Expected O, but got Ref
		List<PoolsMapping> list = new List<PoolsMapping>();
		_003CpoolsMapping_003Ek__BackingField = list;
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		_003CspawnType_003Ek__BackingField = text;
		_003CDayColor_003Ek__BackingField = 16777215u;
		_003CNightColor_003Ek__BackingField = 4474094u;
		_003CInverseDayColor_003Ek__BackingField = 16764108u;
		_003CInverseNightColor_003Ek__BackingField = 15615044u;
		List<EnemyType?> list2 = new List<EnemyType?>();
		_003Cenemies_003Ek__BackingField = list2;
		List<EnemyType?> list3 = new List<EnemyType?>();
		_003Cbosses_003Ek__BackingField = list3;
		List<Event> list4 = new List<Event>();
		_003Cevents_003Ek__BackingField = list4;
		List<Event> list5 = new List<Event>();
		_003CpizzaEvents_003Ek__BackingField = list5;
		List<ItemType> list6 = new List<ItemType>();
		_003Crelics_003Ek__BackingField = list6;
		List<ItemType> list7 = new List<ItemType>();
		_003Crelics2_003Ek__BackingField = list7;
		List<ItemType> list8 = new List<ItemType>();
		_003CyellowRelics_003Ek__BackingField = list8;
		List<CustomMerchantData> list9 = new List<CustomMerchantData>();
		_003CadventureMerchants_003Ek__BackingField = list9;
		List<FollowerData> list10 = new List<FollowerData>();
		_003CdefaultFollowers_003Ek__BackingField = list10;
		_003CallowVisualInversion_003Ek__BackingField = true;
		List<string> list11 = new List<string>();
		_003Cbiomes_003Ek__BackingField = list11;
	}
}
