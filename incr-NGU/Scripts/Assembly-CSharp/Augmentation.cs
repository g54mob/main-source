using System;

[Serializable]
public class Augmentation
{
	public Aug[] augs = new Aug[7];

	public bool advanceEnergy = true;

	public Augmentation()
	{
		augs[0] = new Aug(150f, 10000f, 100f, 1E+09f, 1L, 1L, 13, 33, "", "", "");
		augs[1] = new Aug(1500f, 100000f, 800f, 8E+09f, 12L, 12L, 14, 36, "", "", "");
		augs[2] = new Aug(3000f, 400000f, 3000f, 3E+10f, 50L, 50L, 16, 40, "", "", "");
		augs[3] = new Aug(10000f, 1200000f, 10000f, 1E+11f, 200L, 200L, 20, 42, "", "", "");
		augs[4] = new Aug(40000f, 20000000f, 40000f, 3E+11f, 1000L, 1000L, 24, 44, "", "", "");
		augs[5] = new Aug(1600000f, 800000000f, 1600000f, 1.3E+13f, 50000L, 50000L, 30, 52, "", "", "");
		augs[6] = new Aug(30000000f, 1.3E+10f, 30000000f, 2E+14f, 1000000L, 1000000L, 40, 60, "", "", "");
		advanceEnergy = false;
	}

	public double totalBonus()
	{
		double num = 0.0;
		for (int i = 0; i < augs.Length; i++)
		{
			if (augs[i] != null)
			{
				num += augs[i].bonus();
			}
		}
		return num;
	}

	public void resetAugs()
	{
		for (int i = 0; i < augs.Length; i++)
		{
			if (augs[i] != null)
			{
				augs[i].reset();
			}
		}
	}

	public void resetLast5Augs()
	{
		for (int i = 2; i < augs.Length; i++)
		{
			if (augs[i] != null)
			{
				augs[i].augLevel = 0L;
				augs[i].upgradeLevel = 0L;
			}
		}
	}

	public long totalLevels()
	{
		long num = 1L;
		for (int i = 0; i < augs.Length; i++)
		{
			num += augs[i].augLevel + augs[i].upgradeLevel;
		}
		return num;
	}
}
