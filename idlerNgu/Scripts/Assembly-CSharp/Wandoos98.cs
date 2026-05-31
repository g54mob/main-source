using System;
using UnityEngine;

[Serializable]
public class Wandoos98
{
	public float energyProgress;

	public float magicProgress;

	public float bootupProgress;

	public long wandoosEnergy;

	public long wandoosMagic;

	public long energyLevel;

	public long magicLevel;

	public float baseEnergyTime;

	public float baseMagicTime;

	public long OSlevel;

	public long pitOSLevels;

	public long XLLevels;

	public bool installed;

	public bool disabled;

	public PlayerTime bootupTime = new PlayerTime();

	public PlayerTime installTime = new PlayerTime();

	public OSType os;

	public void updateBaseStats()
	{
		if (installTime == null)
		{
			installTime = new PlayerTime();
		}
	}

	public Wandoos98()
	{
		bootupProgress = 0f;
		energyProgress = 0f;
		magicProgress = 0f;
		energyLevel = 0L;
		magicLevel = 0L;
		wandoosEnergy = 0L;
		wandoosMagic = 0L;
		installed = false;
		disabled = false;
		bootupTime = new PlayerTime();
		installTime = new PlayerTime();
		os = OSType.wandoos98;
	}

	public void reset()
	{
		bootupTime.reset();
		bootupProgress = 0f;
		energyProgress = 0f;
		magicProgress = 0f;
		energyLevel = 0L;
		magicLevel = 0L;
		wandoosEnergy = 0L;
		wandoosMagic = 0L;
	}

	public void changeOS(OSType newOS)
	{
		if (newOS != os)
		{
			energyProgress = 0f;
			magicProgress = 0f;
			energyLevel = 0L;
			magicLevel = 0L;
			os = newOS;
		}
	}

	public float timeFactor()
	{
		return Mathf.Min((float)(bootupTime.totalseconds / 3600.0), 1f);
	}

	public double wandoosEnergyBonus()
	{
		return 1f + (float)energyLevel / 100f;
	}

	public double wandoosMagicBonus()
	{
		return 1f + (float)magicLevel / 25f;
	}

	public void validateWandoos()
	{
		if (installed)
		{
			installTime.totalseconds = 86400.0;
		}
	}
}
