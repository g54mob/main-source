using I2.Loc;
using TMPro;
using UnityEngine;

public class LevelUpStatRow : MonoBehaviour
{
	public Localize LocLabel;

	public TextMeshProUGUI TxtOldStat;

	public GameObject UpgradeSymbol;

	public TextMeshProUGUI TxtNewStat;

	private void InitInternal()
	{
	}

	public void SetProperty(string label, UpgradeInfo inf, int lvl, PropertyType pt, PropertyType pt2 = PropertyType.kNum)
	{
	}

	public void SetProperty(string label, HeroInst inst, int lvl, PropertyType pt, PropertyType pt2 = PropertyType.kNum)
	{
	}

	public void SetProperty(string label, PassiveInst inst, int lvl, PropertyType pt, PropertyType pt2 = PropertyType.kNum)
	{
	}

	public void SetDamage(HeroInst h, int lvl)
	{
	}
}
