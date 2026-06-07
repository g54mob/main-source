using System;
using System.Collections;
using DV.Common;
using DV.Scenarios;
using DV.Scenarios.Common;
using DV.UI.PresetEditors;
using DV.UserManagement;
using DV.UserManagement.Data;
using DV.Utils;
using UnityEngine;

public abstract class AStartGameData : MonoBehaviour
{
	public static readonly DateTime BaseTimeAndDate = new DateTime(2016, 7, 21, 12, 0, 0);

	public static bool carsAndJobsLoadingFinished = false;

	public IDifficulty DifficultyToUse { get; protected set; }

	public abstract bool IsStartingNewSession { get; }

	public static void DestroyAllInstances()
	{
		AStartGameData[] array = UnityEngine.Object.FindObjectsOfType<AStartGameData>();
		foreach (AStartGameData aStartGameData in array)
		{
			Debug.Log($"Destroying {aStartGameData.GetType().Name} '{aStartGameData}'");
			UnityEngine.Object.Destroy(aStartGameData.gameObject);
		}
	}

	public static T CreateNew<T>() where T : AStartGameData
	{
		DestroyAllInstances();
		GameObject obj = new GameObject("[start game data]");
		UnityEngine.Object.DontDestroyOnLoad(obj);
		carsAndJobsLoadingFinished = false;
		return obj.AddComponent<T>();
	}

	public static AStartGameData StartEmptySave()
	{
		return CreateNew<StartGameData_EmptySave>();
	}

	public static AStartGameData StartNewCareer(IGameSession session, IDifficulty difficulty, bool skipTutorial)
	{
		StartGameData_NewCareer startGameData_NewCareer = CreateNew<StartGameData_NewCareer>();
		startGameData_NewCareer.session = session;
		startGameData_NewCareer.difficultyParams = difficulty;
		startGameData_NewCareer.skipTutorial = skipTutorial;
		return startGameData_NewCareer;
	}

	public static AStartGameData StartNewFreeRoam(IGameSession session, IDifficulty difficulty, IScenario scenario)
	{
		StartGameData_NewFreeRoam startGameData_NewFreeRoam = CreateNew<StartGameData_NewFreeRoam>();
		startGameData_NewFreeRoam.session = session;
		startGameData_NewFreeRoam.difficultyParams = difficulty;
		startGameData_NewFreeRoam.scenario = scenario;
		return startGameData_NewFreeRoam;
	}

	public static AStartGameData Continue(ISaveGame save, bool useSessionDifficulty)
	{
		SaveGameSnapshot saveGameSnapshot = save as SaveGameSnapshot;
		if (save != null && saveGameSnapshot == null)
		{
			Debug.LogError("Got savegame instance of " + save.GetType().Name + " but only SaveGameSnapshot savegames are supported, will start new career now");
			return FallbackNewCareer();
		}
		StartGameData_FromSaveGame startGameData_FromSaveGame = CreateNew<StartGameData_FromSaveGame>();
		startGameData_FromSaveGame.snapshot = saveGameSnapshot;
		if (useSessionDifficulty)
		{
			startGameData_FromSaveGame.difficultyParamsOverride = save.ParentSession.GetDifficulty();
		}
		return startGameData_FromSaveGame;
	}

	public static AStartGameData FallbackNewCareer()
	{
		return FromUIData(null);
	}

	public static UIStartGameData GetFallbackData(string sessionName, bool isCareer)
	{
		IScenario scenario = DifficultyParamsSetter.DefaultEmptyTrain(new Scenario());
		IDifficulty comfort = DifficultyParamsSetter.Comfort;
		GameSession gameSession = SingletonBehaviour<UserManager>.Instance.CurrentUser.StartSession(isCareer ? "Career" : "FreeRoam", "World1");
		gameSession.Name = sessionName;
		return new UIStartGameData(gameSession, comfort, scenario, skipTutorial: false);
	}

	public static AStartGameData FromUIData(UIStartGameData data)
	{
		string text = DateTime.Now.ToString("yyyy-MM-dd HH\\:mm\\:ss");
		if (data?.session == null)
		{
			Debug.LogError("Got null UIStartGameData instance, will start new career now");
			data = GetFallbackData("Career fallback " + text, isCareer: true);
			return StartNewCareer(data.session, data.difficulty, data.skipTutorial);
		}
		if (data.session.GameMode != "Career" && data.session.GameMode != "FreeRoam")
		{
			Debug.LogError("Got UIStartGameData with unsupported game mode " + data.session.GameMode + ", will start new career now");
			data = GetFallbackData("Career fallback " + text, isCareer: true);
			return StartNewCareer(data.session, data.difficulty, data.skipTutorial);
		}
		if (data.session.GameMode == "Career")
		{
			return StartNewCareer(data.session, data.difficulty, data.skipTutorial);
		}
		if (data.session.GameMode == "FreeRoam")
		{
			return StartNewFreeRoam(data.session, data.difficulty, data.scenario);
		}
		throw new ArgumentException("Didn't expect to get here");
	}

	protected abstract void Initialize();

	public abstract SaveGameData GetSaveGameData();

	public abstract IEnumerator DoLoad(Transform playerContainer);

	public abstract string GetPostLoadMessage();

	public abstract bool ShouldCreateSaveGameAfterLoad();

	public abstract void MakeCurrent();
}
