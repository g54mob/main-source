using I2.Loc;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "PassiveInfo", menuName = "Bouncer/PassiveInfo")]
public class PassiveInfo : UpgradeInfo
{
	public PassiveType Type;

	[HideInInspector]
	public Color MainColor;

	public override void GenerateSlug()
	{
	}

	public override UpgradeType GetUpgradeType()
	{
		return default(UpgradeType);
	}

	public override int GetIdx()
	{
		return 0;
	}

	public override PassiveInfo ToPassive()
	{
		return null;
	}

	public override int GetPropertyByLvl(PropertyType pt, int lvl, int defaultVal = 0)
	{
		return 0;
	}

	public override void ApplyIcon(Image img)
	{
	}

	public string GetComboDescSlug()
	{
		return null;
	}

	public override void ExportLoc(LanguageSourceAsset loc)
	{
	}

	public override LevelType GetRequiredLevel()
	{
		return default(LevelType);
	}

	public override bool IncludeInGame()
	{
		return false;
	}

	public bool IsUnlocked()
	{
		return false;
	}

	public bool CanBeUsed()
	{
		return false;
	}

	public override bool ShouldAIPick()
	{
		return false;
	}

	public void DetermineMainColor()
	{
	}
}
