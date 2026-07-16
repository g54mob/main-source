using UnityEngine;

public class FixDifficultyStation : BrokenHubStation, ISaveable
{
	public void Save(SaveDataContext context)
	{
		if (!GameManager.Instance.isDemo)
		{
			MetaSavefile metaSave = context.MetaSave;
			metaSave.isDifficultyStationFixed = isFixed;
			metaSave.isDifficultyStationReadyToUnlock = canBeBought;
			Debug.Log("Saved Difficulty Station");
		}
	}

	public void Load(SaveDataContext context, bool isNewJourney)
	{
		if (!GameManager.Instance.isDemo)
		{
			MetaSavefile metaSave = context.MetaSave;
			isFixed = metaSave.isDifficultyStationFixed;
			canBeBought = metaSave.isDifficultyStationReadyToUnlock;
			if (GameManager.Instance.isDemo)
			{
				isFixed = false;
			}
			Debug.Log("Loaded Difficulty Station");
		}
	}
}
