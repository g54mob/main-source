using System;
using System.Collections.Generic;

[Serializable]
public class Beards
{
	public List<Beard> beards;

	public List<int> activeBeards;

	public int capBeards;

	public int energyBeardCount;

	public int magicBeardCount;

	public bool disabled;

	public bool transferredBankedLevels;

	public int beardSize()
	{
		return 7;
	}

	public Beards()
	{
		beards = new List<Beard>();
		while (beards.Count < beardSize())
		{
			beards.Add(new Beard());
		}
		activeBeards = new List<int>();
		capBeards = 1;
		energyBeardCount = 0;
		magicBeardCount = 0;
		disabled = false;
		transferredBankedLevels = true;
	}

	public void checkBeards()
	{
		while (beards.Count < beardSize())
		{
			beards.Add(new Beard());
		}
	}
}
