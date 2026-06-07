using System;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine.UI;

[Serializable]
public class UpgradeInst<T> where T : UpgradeInfo
{
	public int Lvl;

	public List<HeroType> CombinedHeroes;

	public const int kMaxSoloLvl = 2;

	public virtual T GetInfo()
	{
		return null;
	}

	public virtual int GetProperty(PropertyType pt, int lvl = -1)
	{
		return 0;
	}

	public virtual int GetProperty(HeroType tgtHero, PropertyType pt, int lvl = -1)
	{
		return 0;
	}

	public virtual int GetRangeProperty(PropertyType ptMin, ThreadSafeRandom rnd)
	{
		return 0;
	}

	public virtual int GetRangeProperty(HeroType tgtHero, PropertyType ptMin, ThreadSafeRandom rnd)
	{
		return 0;
	}

	public virtual bool ContainsComponent(UpgradeInfo upgInf)
	{
		return false;
	}

	public virtual bool ContainsComponentRecursive(UpgradeInfo upgInf)
	{
		return false;
	}

	public virtual bool CanUpgrade()
	{
		return false;
	}

	public virtual void ApplyIcon(Image img)
	{
	}

	public bool IsAtMaxSolo()
	{
		return false;
	}

	public bool IsSolo()
	{
		return false;
	}

	public bool IsCombo()
	{
		return false;
	}

	public void ApplyUpgradeParams(int lvl, LocalizationParamsManager loc, int comboIdx, bool colorize = false)
	{
	}
}
