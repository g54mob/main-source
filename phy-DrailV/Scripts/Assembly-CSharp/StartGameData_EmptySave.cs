using System.Collections;
using DV.Utils;
using UnityEngine;

public class StartGameData_EmptySave : AStartGameData
{
	private bool initialized;

	private SaveGameData saveGameData;

	public override bool IsStartingNewSession => true;

	protected override void Initialize()
	{
		if (!initialized)
		{
			initialized = true;
			Debug.Log("=== Initializing " + GetType().Name + " ===");
			saveGameData = SaveGameManager.MakeEmptySave();
			saveGameData.SetString("World", "World1");
			saveGameData.SetString("Game_mode", "Career");
			base.DifficultyToUse = DifficultyParamsSetter.Standard;
		}
	}

	public override SaveGameData GetSaveGameData()
	{
		Initialize();
		return saveGameData;
	}

	public override IEnumerator DoLoad(Transform playerContainer)
	{
		AStartGameData.carsAndJobsLoadingFinished = true;
		SingletonBehaviour<StartingItemsController>.Instance.AddStartingItems(saveGameData, firstTime: true);
		yield break;
	}

	public override string GetPostLoadMessage()
	{
		return null;
	}

	public override bool ShouldCreateSaveGameAfterLoad()
	{
		return false;
	}

	public override void MakeCurrent()
	{
	}
}
