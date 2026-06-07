using I2.Loc;
using UnityEngine;

[CreateAssetMenu(fileName = "PetUpgradeInfo", menuName = "Bouncer/PetUpgradeInfo")]
public class PetUpgradeInfo : UpgradeInfo
{
	[Header("Pet Upgrade!")]
	public PetUpgradeType Type;

	public override void GenerateSlug()
	{
	}

	public override void ExportLoc(LanguageSourceAsset loc)
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

	public override PetUpgradeInfo ToPetUpgrade()
	{
		return null;
	}
}
