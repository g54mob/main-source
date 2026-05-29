using System;
using System.Collections.Generic;

[Serializable]
public class Yggdrasil
{
	public Fruit goldFruit;

	public Fruit adventureFruit;

	public Fruit luckFruit;

	public Fruit statFruit;

	public Fruit knowledgeFruit;

	public Fruit pomegranate;

	public List<Fruit> fruits = new List<Fruit>();

	public float resetFactor;

	public float statBonus;

	public long seeds;

	public long totalLuck;

	public long totalPermStatBonus;

	public bool permBonusOn;

	public long totalPermStatBonus2;

	public long totalPermNumberBonus;

	public bool permNumberBonusOn;

	public bool usePoop;

	public void reset()
	{
		if (resetFactor > 1f)
		{
			resetFactor = 0f;
		}
		goldFruit.reset(resetFactor);
		adventureFruit.reset(resetFactor);
		luckFruit.reset(resetFactor);
		statFruit.reset(resetFactor);
		knowledgeFruit.reset(resetFactor);
		pomegranate.reset(resetFactor);
		statBonus = 0f;
		permBonusOn = false;
		permNumberBonusOn = false;
		for (int i = 0; i < 20; i++)
		{
			fruits[i].reset(resetFactor);
		}
	}

	public double totalStatBonus()
	{
		return Math.Pow(fruits[1].totalLevels, 1.5);
	}

	public Yggdrasil()
	{
		goldFruit = new Fruit();
		adventureFruit = new Fruit();
		luckFruit = new Fruit();
		statFruit = new Fruit();
		knowledgeFruit = new Fruit();
		pomegranate = new Fruit();
		seeds = 0L;
		resetFactor = 0f;
		totalLuck = 0L;
		totalPermStatBonus = 0L;
		permBonusOn = false;
		for (int i = 0; i < 21; i++)
		{
			fruits.Add(new Fruit());
		}
		usePoop = false;
	}

	public void checkYggdrasil()
	{
		if (fruits == null)
		{
			fruits = new List<Fruit>();
		}
		while (fruits.Count < 21)
		{
			fruits.Add(new Fruit());
		}
	}

	public void transferData()
	{
		fruits[0].totalLevels = goldFruit.totalLevels;
		fruits[0].seconds = goldFruit.seconds;
		fruits[0].activated = goldFruit.activated;
		fruits[0].maxTier = goldFruit.maxTier;
		fruits[1].totalLevels = statFruit.totalLevels;
		fruits[1].seconds = statFruit.seconds;
		fruits[1].activated = statFruit.activated;
		fruits[1].maxTier = statFruit.maxTier;
		fruits[2].totalLevels = adventureFruit.totalLevels;
		fruits[2].seconds = adventureFruit.seconds;
		fruits[2].activated = adventureFruit.activated;
		fruits[2].maxTier = adventureFruit.maxTier;
		fruits[3].totalLevels = knowledgeFruit.totalLevels;
		fruits[3].seconds = knowledgeFruit.seconds;
		fruits[3].activated = knowledgeFruit.activated;
		fruits[3].maxTier = knowledgeFruit.maxTier;
		fruits[4].totalLevels = pomegranate.totalLevels;
		fruits[4].seconds = pomegranate.seconds;
		fruits[4].activated = pomegranate.activated;
		fruits[4].maxTier = pomegranate.maxTier;
	}
}
