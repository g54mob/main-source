using System.Collections.Generic;
using I2.Loc;
using Sirenix.OdinInspector;
using UnityEngine;

public class InfoDB : SerializedMonoBehaviour
{
	public static InfoDB I;

	[NamedArray(typeof(HeroType))]
	public HeroInfo[] Heroes;

	public List<HeroInfo> HeroOrder;

	public HeroInfo[] BaseHeroes;

	[NamedArray(typeof(PassiveType))]
	public PassiveInfo[] Passives;

	public List<PassiveInfo> PassiveOrder;

	[NamedArray(typeof(LevelType))]
	public List<UpgradeInfo>[] UnlocksByLevel;

	[NamedArray(typeof(BuildingType))]
	public BuildingInfo[] Buildings;

	public List<BuildingInfo>[] BuildingsByCat;

	public List<BuildingInfo>[][] BuildingsBySubCat;

	public List<BuildingInfo> BossDropBlueprints;

	public List<BuildingInfo> FuserDropBlueprints;

	public List<BuildingInfo>[] BlueprintsByLevel;

	[NamedArray(typeof(ResourceType))]
	public List<BuildingInfo>[] ResourceBuildings;

	[NamedArray(typeof(CharType))]
	public BuildingInfo[] CharHousing;

	[NamedArray(typeof(GridPieceType))]
	public GridPieceInfo[] GridPieces;

	[NamedArray(typeof(CharType))]
	public CharInfo[] Chars;

	[NamedArray(typeof(HarvestUpgradeType))]
	public HarvestUpgradeInfo[] HarvestUpgrades;

	[NamedArray(typeof(LevelType))]
	public LevelInfo[] Levels;

	[Header("Editor Refs")]
	public PoolMgr Pool;

	public FXMgr FX;

	public LanguageSourceAsset Loc;

	public bool FocusAfterCreate;

	public ShaderVariantCollection GameplayShaderCollection;

	public const int kNumUpgradeLvls = 4;

	public const int kMaxSoloLvl = 2;

	private const int kFreezeDmgPct = 25;

	private void Awake()
	{
	}

	private void InsertLvlBlueprint(int lvlIdx, int bpIdx, BuildingType buildingType)
	{
	}

	public void AddPostLaunchBlueprints()
	{
	}

	public void RemovePostLaunchBlueprints()
	{
	}
}
