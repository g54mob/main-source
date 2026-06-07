using System;
using System.Collections.Generic;

[Serializable]
public class GoldDiggers
{
	public List<GoldDigger> diggers = new List<GoldDigger>();

	public List<int> activeDiggers = new List<int>();

	public List<int> loadoutDiggers = new List<int>();

	public int diggersCount()
	{
		return 12;
	}

	public GoldDiggers()
	{
		diggers = new List<GoldDigger>();
		activeDiggers = new List<int>();
		loadoutDiggers = new List<int>();
		validateDiggers();
	}

	public void validateDiggers()
	{
		while (diggers.Count < diggersCount())
		{
			diggers.Add(new GoldDigger());
		}
	}
}
