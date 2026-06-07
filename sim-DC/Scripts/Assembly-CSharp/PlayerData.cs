using System;
using System.Collections.Generic;

[Serializable]
public class PlayerData
{
	public List<int> activeObjectives;

	public float coins;

	public float xp;

	public float reputation;

	public float[] position;

	public PlayerData(Player playerClass)
	{
	}
}
