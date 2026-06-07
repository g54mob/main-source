using UnityEngine;

public class PressSaveCreator : MonoBehaviour
{
	[SerializeField]
	private int money;

	[SerializeField]
	private bool completeBosses;

	[SerializeField]
	private LevelData[] levelsToComplete;

	private void Apply()
	{
		if (money > 0)
		{
			LTFunctionLibrary.GetPlayerUpgradesManager().AddMoney(money);
			SaveSystem.instance.SaveData();
		}
		if (levelsToComplete == null || levelsToComplete.Length == 0)
		{
			return;
		}
		LevelData[] array = levelsToComplete;
		foreach (LevelData levelData in array)
		{
			LTFunctionLibrary.GetLevelsProgressionManager().CompleteLevel(levelData.Id, expertMode: false);
			if (completeBosses)
			{
				LTFunctionLibrary.GetLevelsProgressionManager().CompleteBoss(levelData.Id, null, expertMode: false);
			}
		}
		SaveSystem.instance.SaveData();
	}
}
