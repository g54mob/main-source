using I2.Loc;
using UnityEngine;

[CreateAssetMenu(fileName = "HarvestUpgradeInfo", menuName = "Bouncer/HarvestUpgradeInfo")]
public class HarvestUpgradeInfo : ScriptableObject
{
	[HideInInspector]
	public HarvestUpgradeType Type;

	public Sprite Icon;

	public string Name;

	[HideInInspector]
	public string Slug;

	public bool IsInGame;

	[TextArea]
	public string Desc;

	public void GenerateSlug()
	{
	}

	public string GetNameSlug()
	{
		return null;
	}

	public string GetDescSlug()
	{
		return null;
	}

	public void ExportLoc(LanguageSourceAsset loc)
	{
	}

	public void ApplyDesc(Localize loc, LocalizationParamsManager prms, int lvl)
	{
	}

	public int GetBonusAmt(int lvl)
	{
		return 0;
	}
}
