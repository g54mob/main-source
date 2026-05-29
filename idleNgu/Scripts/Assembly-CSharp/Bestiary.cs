using System;
using System.Collections.Generic;

[Serializable]
public class Bestiary
{
	public List<BestiaryInfo> enemies = new List<BestiaryInfo>();

	public int bestiaryLength()
	{
		return 379;
	}

	public Bestiary()
	{
		while (enemies.Count < bestiaryLength())
		{
			enemies.Add(new BestiaryInfo());
		}
	}

	public void updateBestiary()
	{
		while (enemies.Count < bestiaryLength())
		{
			enemies.Add(new BestiaryInfo());
		}
	}
}
