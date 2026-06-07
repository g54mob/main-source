using I2.Loc;
using UnityEngine;

[CreateAssetMenu(fileName = "PetInfo", menuName = "Bouncer/PetInfo")]
public class PetInfo : UpgradeInfo
{
	[Header("Pet!")]
	public PetType Type;

	public Sprite IconSmall;

	public PetObj Prefab;

	public string EggDisplayName;

	public Sprite EggPortrait;

	public float IncubationTime;

	public float FusionTime;

	public Cost IncubationCost;

	public string[] DefaultNames;

	public PetUpgradeInfo[] Upgrades;

	public override void GenerateSlug()
	{
	}

	public override int GetIdx()
	{
		return 0;
	}

	public override UpgradeType GetUpgradeType()
	{
		return default(UpgradeType);
	}

	public string GetEggNameSlug()
	{
		return null;
	}

	public override void ExportLoc(LanguageSourceAsset loc)
	{
	}

	public void ApplyDesc(Localize loc, LocalizationParamsManager prmMgr, int lvl)
	{
	}
}
