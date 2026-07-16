using System;
using UnityEngine;

[Serializable]
public class UnlockOption
{
	public string name;

	[SerializeField]
	private bool unlocked;

	[SerializeField]
	private int unlockLevel;

	public bool IsUnlocked()
	{
		return unlocked;
	}

	public int GetUnlockLevel()
	{
		return unlockLevel;
	}

	public void Unlock(int level)
	{
		unlocked = true;
		unlockLevel = level;
	}

	public void Reset()
	{
		unlocked = false;
	}
}
