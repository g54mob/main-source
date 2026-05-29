using System;
using System.Collections.Generic;

[Serializable]
public class PlayerPortraits
{
	public List<bool> portraitUnlocked;

	public int curPortrait;

	public int maxPortraits()
	{
		return 69;
	}

	public PlayerPortraits()
	{
		portraitUnlocked = new List<bool>();
		while (portraitUnlocked.Count < maxPortraits())
		{
			portraitUnlocked.Add(item: false);
		}
		portraitUnlocked[0] = true;
		curPortrait = 0;
	}

	public void updatePortraits()
	{
		if (portraitUnlocked == null)
		{
			portraitUnlocked = new List<bool>();
		}
		while (portraitUnlocked.Count < maxPortraits())
		{
			portraitUnlocked.Add(item: false);
		}
		portraitUnlocked[0] = true;
	}
}
