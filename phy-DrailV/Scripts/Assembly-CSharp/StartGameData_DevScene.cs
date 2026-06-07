using System.Collections;
using DV.MultipleUnit;
using DV.Utils;
using UnityEngine;

public class StartGameData_DevScene : AStartGameData
{
	private bool initialized;

	private SaveGameData saveGameData;

	private int startingItems;

	private string gameMode;

	private string gameWorld;

	public override bool IsStartingNewSession => true;

	public void SetSaveParams(int startingItemsEntry, string gameModeEntry, string worldEntry)
	{
		startingItems = startingItemsEntry;
		gameMode = gameModeEntry;
		gameWorld = worldEntry;
	}

	protected override void Initialize()
	{
		if (!initialized)
		{
			initialized = true;
			Debug.Log("=== Initializing " + GetType().Name + " ===");
			saveGameData = SaveGameManager.MakeEmptySave();
			saveGameData.SetString("World", gameWorld);
			saveGameData.SetString("Game_mode", gameMode);
			saveGameData.SetInt("Starting_items", startingItems);
			base.DifficultyToUse = DifficultyParamsSetter.Standard;
			MultipleUnitModule.SetupAutoCoupling();
		}
	}

	public override SaveGameData GetSaveGameData()
	{
		Initialize();
		return saveGameData;
	}

	public override IEnumerator DoLoad(Transform playerContainer)
	{
		SingletonBehaviour<StartingItemsController>.Instance.AddStartingItems(saveGameData, firstTime: true);
		while (!SingletonBehaviour<StartingItemsController>.Instance.itemsLoaded)
		{
			yield return null;
		}
		AStartGameData.carsAndJobsLoadingFinished = true;
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
