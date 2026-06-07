using I2.Loc;
using UnityEngine;
using UnityEngine.UI;

public class HarvestDisplayItem : MonoBehaviour
{
	public Image ImgIcon;

	public Localize LocName;

	public Localize LocDesc;

	public LocalizationParamsManager ParamsDesc;

	private HarvestUpgradeType _tgtType;

	public void Init(HarvestUpgradeInst inst)
	{
	}

	public void Init(HarvestUpgradeType ht, int lvl)
	{
	}
}
