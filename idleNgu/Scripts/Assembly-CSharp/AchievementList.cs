using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AchievementList
{
	public List<bool> achievementComplete = new List<bool>();

	public int totalAchieves;

	public int achievementsSize()
	{
		return 153;
	}

	public AchievementList()
	{
		for (int i = 0; i < achievementsSize(); i++)
		{
			achievementComplete.Add(item: false);
		}
		totalAchieves = 0;
	}

	public void validate()
	{
		if (achievementComplete == null)
		{
			achievementComplete = new List<bool>();
		}
		while (achievementComplete.Count < achievementsSize())
		{
			achievementComplete.Add(item: false);
		}
	}

	public void debugList()
	{
		for (int i = 0; i < achievementComplete.Count; i++)
		{
			Debug.Log(i + " id dropped is " + achievementComplete[i].ToString());
		}
	}

	public void debugList(int i)
	{
		Debug.Log(i + " id dropped is " + achievementComplete[i].ToString());
	}
}
