using System;
using UnityEngine;

[Serializable]
public class Ritual
{
	public float progress;

	public long magic;

	public long level;

	[NonSerialized]
	public float baseBuildTime;

	[NonSerialized]
	public long baseRebirthBoost;

	[NonSerialized]
	public bool paid;

	[NonSerialized]
	public float baseCost;

	[NonSerialized]
	public string name;

	[NonSerialized]
	public string desc;

	[NonSerialized]
	public int boss;

	public Ritual()
	{
		progress = 0f;
		magic = 0L;
		level = 0L;
		baseBuildTime = 1f;
		baseRebirthBoost = 1L;
		paid = false;
		baseCost = 1f;
		name = "";
		desc = "";
	}

	public Ritual(float time, float cost, long boost)
	{
		progress = 0f;
		magic = 0L;
		level = 0L;
		baseBuildTime = time;
		baseRebirthBoost = boost;
		paid = false;
		baseCost = cost;
		name = "";
		desc = "";
	}

	public Ritual(float time, float cost, long boost, string sname, string sdesc, int rboss)
	{
		progress = 0f;
		magic = 0L;
		level = 0L;
		baseBuildTime = time;
		baseRebirthBoost = boost;
		paid = false;
		baseCost = cost;
		name = sname;
		desc = sdesc;
		boss = rboss;
	}

	public void updateBaseStats(float time, float cost, long boost, int rboss)
	{
		baseBuildTime = time;
		baseRebirthBoost = boost;
		baseCost = cost;
		boss = rboss;
	}

	public void advanceProgress(float magicPower)
	{
		if (magic != 0L)
		{
			progress += (float)magic * magicPower / 50000f / baseBuildTime;
		}
	}

	public long capValue(float magicPower)
	{
		return (long)Mathf.Ceil(50000f * baseBuildTime / magicPower);
	}

	public void reset()
	{
		progress = 0f;
		magic = 0L;
		level = 0L;
	}

	public double rebirthBoost()
	{
		return baseRebirthBoost * level;
	}

	public string timeLeft(float magicPower)
	{
		if (magic == 0L)
		{
			return "N/A";
		}
		float num = (1f - progress) * baseBuildTime / ((float)magic * magicPower / 1000f);
		float num2 = 0f;
		float num3 = 0f;
		float num4 = 0f;
		num4 = Mathf.Floor(num / 86400f);
		num %= 86400f;
		num3 = Mathf.Floor(num / 3600f);
		num %= 3600f;
		num2 = Mathf.Floor(num / 60f);
		num %= 60f;
		return num4 + " days " + num3 + " : " + num2 + " : " + num.ToString("0.0");
	}

	public void updateBaseStats(float btime, float bcost, long bBoost)
	{
		baseBuildTime = btime;
		baseCost = bcost;
		baseRebirthBoost = bBoost;
	}
}
