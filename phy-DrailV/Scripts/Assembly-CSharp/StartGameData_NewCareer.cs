using System;
using System.Collections;
using DV;
using DV.Common;
using DV.JObjectExtstensions;
using DV.Scenarios.Common;
using DV.ThingTypes;
using DV.ThingTypes.TransitionHelpers;
using DV.UserManagement;
using DV.Utils;
using DV.WeatherSystem;
using UnityEngine;

public class StartGameData_NewCareer : AStartGameData
{
	public IGameSession session;

	public IDifficulty difficultyParams;

	public const float StartingMoney = 2000f;

	public bool skipTutorial;

	private bool initialized;

	private SaveGameData saveGameData;

	public override bool IsStartingNewSession => true;

	protected override void Initialize()
	{
		if (!initialized)
		{
			initialized = true;
			if (session != null)
			{
				SingletonBehaviour<UserManager>.Instance.CurrentUser.SelectSession(session);
			}
			else
			{
				string text = DateTime.Now.ToString("yyyy-MM-dd HH\\:mm\\:ss");
				string text2 = "Career fallback " + text;
				Debug.LogError("Session is null, starting new fallback session '" + text2 + "'");
				session = SingletonBehaviour<UserManager>.Instance.CurrentUser.StartSession("Career", "World1");
				session.Name = text2;
			}
			Debug.Log("=== Initializing " + GetType().Name + " === [" + session.Name + " / " + session.Owner.Name + "]");
			SingletonBehaviour<UserManager>.Instance.CurrentUser.Save(UserSavingMode.CurrentSession);
			PrepareNewSaveData(ref saveGameData, out var DifficultyToUse, session, difficultyParams, skipTutorial);
			base.DifficultyToUse = DifficultyToUse;
			Debug.Log("Unlocked general licenses: " + string.Join(", ", SingletonBehaviour<UnlockablesManager>.Instance.UnlockedGeneralLicenses));
			Debug.Log("Unlocked job licenses: " + string.Join(", ", SingletonBehaviour<UnlockablesManager>.Instance.UnlockedJobLicenses));
			Debug.Log("Unlocked garages: " + string.Join(", ", SingletonBehaviour<UnlockablesManager>.Instance.UnlockedGarages));
			Debug.Log("Unlocked items: " + string.Join(", ", SingletonBehaviour<UnlockablesManager>.Instance.UnlockedItems));
		}
	}

	public static void PrepareNewSaveData(ref SaveGameData saveGameData, out IDifficulty DifficultyToUse, IGameSession session, IDifficulty difficultyParams, bool skipTutorial)
	{
		if (saveGameData == null)
		{
			saveGameData = SaveGameManager.MakeEmptySave();
		}
		else
		{
			saveGameData.Clear();
		}
		saveGameData.SetString("Game_mode", session.GameMode);
		saveGameData.SetString("World", session.World);
		saveGameData.SetDouble("Starting_time_and_date", AStartGameData.BaseTimeAndDate.ToOADate());
		if (difficultyParams != null)
		{
			DifficultyToUse = difficultyParams;
			DifficultyParamsSetter.SetDifficultyParams(difficultyParams);
		}
		else
		{
			DifficultyToUse = DifficultyParamsSetter.Standard;
			Debug.LogError("Unexpected state: difficultyParams are null for new career session. Using default values in attempt to recover.");
		}
		session.PerformGameplayEntryDifficultyCheck(DifficultyToUse);
		if (skipTutorial)
		{
			foreach (GeneralLicenseType_v2 tutorialGeneralLicense in LicenseManager.TutorialGeneralLicenses)
			{
				SingletonBehaviour<UnlockablesManager>.Instance.UnlockThing(tutorialGeneralLicense);
				saveGameData.AddToStringArray("Licenses_General", tutorialGeneralLicense.id, enforceUnique: true);
			}
			SingletonBehaviour<UnlockablesManager>.Instance.UnlockThing(JobLicenses.FreightHaul.ToV2());
			saveGameData.AddToStringArray("Licenses_Jobs", JobLicenses.FreightHaul.ToV2().id, enforceUnique: true);
			saveGameData.SetFloat("Player_money", 2000f);
			saveGameData.SetBool("Tutorial_01_completed", value: true);
			saveGameData.SetBool("Tutorial_02_completed", value: true);
			saveGameData.SetBool("Tutorial_03_completed", value: true);
			GameParams.StartingItemsType startingItems = Globals.G.GameParams.StartingItems;
			switch (startingItems)
			{
			case GameParams.StartingItemsType.Basic:
			case GameParams.StartingItemsType.Auto:
				saveGameData.SetInt("Starting_items", 0);
				break;
			case GameParams.StartingItemsType.Expanded:
				saveGameData.SetInt("Starting_items", 1);
				break;
			case GameParams.StartingItemsType.Engineer:
				saveGameData.SetInt("Starting_items", 2);
				break;
			default:
				Debug.LogError($"Unexpected state: Unhandled entry {startingItems}. Using basic starting items");
				saveGameData.SetInt("Starting_items", 0);
				break;
			}
			session.GameData.SetBool("Difficulty_picked", value: true);
		}
		else
		{
			saveGameData.SetBool("Tutorial_01_completed", value: false);
			saveGameData.SetBool("Tutorial_02_completed", value: false);
			saveGameData.SetBool("Tutorial_03_completed", value: false);
			session.GameData.SetBool("Difficulty_picked", value: false);
			saveGameData.SetFloat("Player_money", 0f);
		}
	}

	public override SaveGameData GetSaveGameData()
	{
		Initialize();
		return saveGameData;
	}

	public override IEnumerator DoLoad(Transform playerContainer)
	{
		SingletonBehaviour<WeatherDriver>.Instance.manager.todSky.Cycle.RealDateTime = AStartGameData.BaseTimeAndDate;
		if (skipTutorial)
		{
			SingletonBehaviour<LicenseManager>.Instance.LoadData(saveGameData);
			playerContainer.transform.position = LevelInfo.NewCareerSpawnPosition;
			playerContainer.transform.rotation = Quaternion.Euler(LevelInfo.NewCareerSpawnRotation);
			if ((bool)SingletonBehaviour<LevelInfo>.Instance)
			{
				Debug.Log(string.Format("Using player position from {0}: {1}", "LevelInfo", LevelInfo.NewCareerSpawnPosition));
			}
			else
			{
				Debug.LogError("LevelInfo couldn't be found, player position will be wrong (0,0,0)");
			}
			StartCoroutine(LoadingNonBlockingCoro());
		}
		else
		{
			playerContainer.transform.position = LevelInfo.DefaultSpawnPosition;
			playerContainer.transform.rotation = Quaternion.Euler(LevelInfo.DefaultSpawnRotation);
			if ((bool)SingletonBehaviour<LevelInfo>.Instance)
			{
				Debug.Log(string.Format("Using player position from {0}: {1}", "LevelInfo", LevelInfo.DefaultSpawnPosition));
			}
			else
			{
				Debug.LogError("LevelInfo couldn't be found, player position will be wrong (0,0,0)");
			}
			SingletonBehaviour<StartingItemsController>.Instance.itemsLoaded = true;
			AStartGameData.carsAndJobsLoadingFinished = true;
		}
		yield break;
	}

	private IEnumerator LoadingNonBlockingCoro()
	{
		while (PlayerManager.PlayerTransform == null)
		{
			yield return null;
		}
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
		return skipTutorial;
	}

	public override void MakeCurrent()
	{
		session.MakeCurrent();
	}
}
