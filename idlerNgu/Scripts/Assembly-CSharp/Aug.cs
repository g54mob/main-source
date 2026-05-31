using System;
using UnityEngine;

[Serializable]
public class Aug
{
	public long augLevel;

	public float augProgress;

	public long upgradeLevel;

	public float upgradeProgress;

	public long augEnergy;

	public long upgradeEnergy;

	public long augmentTarget;

	public long upgradeTarget;

	[NonSerialized]
	public float augInstallTime;

	[NonSerialized]
	public float augGoldCost;

	[NonSerialized]
	public float upgradeInstallTime;

	[NonSerialized]
	public float upgradeGoldCost;

	[NonSerialized]
	public float speed;

	[NonSerialized]
	public long target;

	[NonSerialized]
	public long attackFactor;

	[NonSerialized]
	public long defenseFactor;

	[NonSerialized]
	public int augBoss;

	[NonSerialized]
	public int upBoss;

	[NonSerialized]
	public string name;

	[NonSerialized]
	public string desc;

	[NonSerialized]
	public string upDesc;

	public Aug(float installtime, float augGold, float upInstallTime, float upGold, long attack, long defense, int boss, int uboss, string sname, string sdesc, string supdesc)
	{
		augLevel = 0L;
		augProgress = 0f;
		upgradeLevel = 0L;
		upgradeProgress = 0f;
		augEnergy = 0L;
		upgradeEnergy = 0L;
		augmentTarget = 0L;
		upgradeTarget = 0L;
		augInstallTime = installtime;
		augGoldCost = augGold;
		upgradeInstallTime = upInstallTime;
		upgradeGoldCost = upGold;
		speed = 0f;
		target = 0L;
		attackFactor = attack;
		defenseFactor = defense;
		augBoss = boss;
		upBoss = uboss;
		name = sname;
		desc = sdesc;
		upDesc = supdesc;
	}

	public float getAugCost()
	{
		return augGoldCost * (float)(augLevel + 1);
	}

	public float getUpgradeCost()
	{
		return upgradeGoldCost * Mathf.Pow(1 + upgradeLevel, 2f);
	}

	public void addEnergyAug(long energy)
	{
		augEnergy += energy;
	}

	public void addEnergyUpgrade(long energy)
	{
		upgradeEnergy += energy;
	}

	public long removeEnergyAug(long target)
	{
		if (target >= augEnergy)
		{
			target = augEnergy;
			augEnergy = 0L;
			return target;
		}
		augEnergy -= target;
		return target;
	}

	public long removeEnergyUpgrade(long target)
	{
		if (target >= upgradeEnergy)
		{
			target = upgradeEnergy;
			upgradeEnergy = 0L;
			return target;
		}
		upgradeEnergy -= target;
		return target;
	}

	public void advanceAugProgress(float speed)
	{
		float num = (float)augEnergy / 50000f * speed / (augInstallTime * (float)(augLevel + 1));
		augProgress += num;
	}

	public void levelAug()
	{
		augLevel++;
		augProgress = 0f;
	}

	public void levelUpgrade()
	{
		upgradeLevel++;
		upgradeProgress = 0f;
	}

	public double bonus()
	{
		if (augLevel == 0L)
		{
			return 0.0;
		}
		return (float)augLevel * (1f + Mathf.Pow(upgradeLevel, 2f)) * (float)attackFactor;
	}

	public double perLevelBonus()
	{
		return (1.0 + Math.Pow(upgradeLevel, 2.0)) * (double)attackFactor;
	}

	public string augNameDesc()
	{
		return name + "\n" + desc;
	}

	public void reset()
	{
		augLevel = 0L;
		augEnergy = 0L;
		upgradeLevel = 0L;
		upgradeEnergy = 0L;
		augProgress = 0f;
		upgradeProgress = 0f;
		name = "";
		desc = "";
		upDesc = "";
	}

	public void updateBaseStats(float atime, float aCost, float utime, float ucost, long atk, long def, int aboss, int uboss, string aname, string adesc, string udesc)
	{
		augInstallTime = atime;
		augGoldCost = aCost;
		upgradeInstallTime = utime;
		upgradeGoldCost = ucost;
		attackFactor = atk;
		defenseFactor = def;
		augBoss = aboss;
		upBoss = uboss;
		name = aname;
		desc = adesc;
		upDesc = udesc;
	}
}
