using UnityEngine;

public class Unlockable : IProgression
{
	[SerializeField]
	private int unlockLevel;

	private bool unlocked;

	public IProgression progressionInterface;

	public void Init()
	{
		unlocked = false;
		progressionInterface = this;
		progressionInterface.OnRegister();
	}

	public int GetUnlockLevel()
	{
		return unlockLevel;
	}

	public bool Unlock(int level)
	{
		Debug.Log("UNLOCK");
		if (unlocked)
		{
			return false;
		}
		if (unlockLevel != level)
		{
			return false;
		}
		progressionInterface.OnUnlock(level);
		unlocked = true;
		return true;
	}
}
