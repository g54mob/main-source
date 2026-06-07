using System;

[Serializable]
public class HeroStatData
{
	public float ObtainTime;

	public int NumLaunches;

	public int BounceDmgDealt;

	public int StatusEffectDmgDealt;

	public int AltDmgDealt;

	public int AOEDmgDealt;

	public int ExtraStatInt;

	public int NumKills;

	public HeroStatData()
	{
	}

	public HeroStatData(HeroStatData toCopy)
	{
	}

	public string DumpStats(string typeStr)
	{
		return null;
	}

	public void MarkAOEDmgDealt(int dmg, GridPieceInst p)
	{
	}

	public void MarkAOEDmgDealt(int dmg)
	{
	}
}
