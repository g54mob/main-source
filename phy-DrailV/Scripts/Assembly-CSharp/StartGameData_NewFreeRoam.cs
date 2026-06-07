using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DV;
using DV.Common;
using DV.Scenarios.Common;
using DV.ThingTypes;
using DV.UserManagement;
using DV.Util;
using DV.Utils;
using DV.WeatherSystem;
using UnityEngine;

public class StartGameData_NewFreeRoam : AStartGameData
{
	private const int PLAYER_SPAWN_X_OFFSET = 2;

	private const int WEATHER_OVERRIDE_UNUSED_VALUE = -1;

	private const int WEATHER_OVERRIDE_INFINITE_VALUE = int.MaxValue;

	private const double STARTING_WEATHER_FADEOUT_DURATION_IN_DAYS = 1.0 / 12.0;

	public IGameSession session;

	public IDifficulty difficultyParams;

	public IScenario scenario;

	public float startingMoney = 10000f;

	public bool carsOrientationAlongTrack = true;

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
				string text2 = "Sandbox fallback " + text;
				Debug.LogError("Session is null, starting new fallback session '" + text2 + "'");
				session = SingletonBehaviour<UserManager>.Instance.CurrentUser.StartSession("FreeRoam", "World1");
				session.Name = text2;
			}
			Debug.Log("=== Initializing " + GetType().Name + " === [" + session.Name + " / " + session.Owner.Name + "]");
			SingletonBehaviour<UserManager>.Instance.CurrentUser.Save(UserSavingMode.CurrentSession);
			saveGameData = SaveGameManager.MakeEmptySave();
			saveGameData.SetString("Game_mode", session.GameMode);
			saveGameData.SetString("World", session.World);
			saveGameData.SetDouble("Starting_time_and_date", ((scenario != null) ? (AStartGameData.BaseTimeAndDate.Date + TimeSpan.FromMinutes(scenario.TimeOfDay)) : AStartGameData.BaseTimeAndDate).ToOADate());
			saveGameData.SetBool("Derail_Popup_Shown", value: true);
			saveGameData.SetBool("Damage_Popup_Shown", value: true);
			saveGameData.SetStringArray("Licenses_General", LicenseManager.GetAllAvailableForGameMode(Globals.G.Types.generalLicenses, "FreeRoam").ToArray());
			saveGameData.SetStringArray("Licenses_Jobs", LicenseManager.GetAllAvailableForGameMode(Globals.G.Types.jobLicenses, "FreeRoam").ToArray());
			saveGameData.SetStringArray("Garages", LicenseManager.GetAllAvailableForGameMode(Globals.G.Types.garages, "FreeRoam").ToArray());
			saveGameData.SetFloat("Player_money", startingMoney);
			saveGameData.SetBool("Tutorial_01_completed", value: true);
			saveGameData.SetBool("Tutorial_02_completed", value: true);
			GameParams gameParams = Globals.G.GameParams;
			if (difficultyParams != null)
			{
				base.DifficultyToUse = difficultyParams;
				DifficultyParamsSetter.SetDifficultyParams(difficultyParams);
			}
			else
			{
				base.DifficultyToUse = DifficultyParamsSetter.Standard;
				Debug.LogError("Unexpected state: difficulty params are null for new free roam session. Using default values in attempt to recover.");
			}
			session.PerformGameplayEntryDifficultyCheck(base.DifficultyToUse);
			GameParams.StartingItemsType startingItems = gameParams.StartingItems;
			switch (startingItems)
			{
			case GameParams.StartingItemsType.Basic:
				saveGameData.SetInt("Starting_items", 0);
				break;
			case GameParams.StartingItemsType.Expanded:
			case GameParams.StartingItemsType.Auto:
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
			Debug.Log("Unlocked general licenses: " + string.Join(", ", SingletonBehaviour<UnlockablesManager>.Instance.UnlockedGeneralLicenses));
			Debug.Log("Unlocked job licenses: " + string.Join(", ", SingletonBehaviour<UnlockablesManager>.Instance.UnlockedJobLicenses));
			Debug.Log("Unlocked garages: " + string.Join(", ", SingletonBehaviour<UnlockablesManager>.Instance.UnlockedGarages));
			Debug.Log("Unlocked items: " + string.Join(", ", SingletonBehaviour<UnlockablesManager>.Instance.UnlockedItems));
		}
	}

	public override SaveGameData GetSaveGameData()
	{
		Initialize();
		return saveGameData;
	}

	public override string GetPostLoadMessage()
	{
		return null;
	}

	public override IEnumerator DoLoad(Transform playerContainer)
	{
		SingletonBehaviour<LicenseManager>.Instance.LoadData(saveGameData);
		if (scenario == null || scenario.PlayerPosition == default(Vector3))
		{
			playerContainer.transform.position = LevelInfo.DefaultSpawnPosition;
			playerContainer.transform.rotation = Quaternion.Euler(LevelInfo.DefaultSpawnRotation);
			Debug.LogError(string.Format("Scenario player position wasn't valid, using default player position from {0}: {1}", "LevelInfo", LevelInfo.DefaultSpawnPosition));
		}
		else
		{
			playerContainer.position = scenario.PlayerPosition;
			playerContainer.rotation = Quaternion.Euler(new Vector3(0f, scenario.PlayerRotationY, 0f));
		}
		List<TrainCar> list = SpawnFreeRoamTrain(scenario);
		if (list.Count != 0)
		{
			Transform transform = list[0].transform;
			playerContainer.position = transform.position + transform.right * 2f;
			playerContainer.rotation = transform.rotation;
		}
		else
		{
			Debug.LogError("No cars were spawned for free roam. Player will not be moved");
		}
		WeatherPresetManager manager = SingletonBehaviour<WeatherDriver>.Instance.manager;
		DateTime baseTimeAndDate = AStartGameData.BaseTimeAndDate;
		int num = Mathf.Clamp(scenario?.TimeOfDay ?? 720, 0, 1439);
		manager.todSky.Cycle.RealDateTime = new DateTime(baseTimeAndDate.Year, baseTimeAndDate.Month, baseTimeAndDate.Day, num / 60, num % 60, 0);
		if (scenario != null && scenario.StartingWeatherDuration != -1)
		{
			Vector2 startingWeatherPoint = new Vector2((float)scenario.FogPercentage / 100f, (float)scenario.CloudsPercentage / 100f);
			float startingWeatherRain = (float)scenario.RainPercentage / 100f;
			float startingWeatherThunder = (float)scenario.LightningPercentage / 100f;
			float startingWeatherWetness = (float)scenario.WetnessPercentage / 100f;
			DateTime startingWeatherExpiration = ((scenario.StartingWeatherDuration == int.MaxValue) ? DateTime.MaxValue : (manager.todSky.Cycle.DateTime + TimeSpan.FromDays((float)scenario.StartingWeatherDuration / 100f)));
			SingletonBehaviour<WeatherDriver>.Instance.SetStartingWeather(startingWeatherExpiration, TimeSpan.FromDays(1.0 / 12.0), startingWeatherPoint, startingWeatherRain, startingWeatherThunder, startingWeatherWetness);
		}
		StartCoroutine(LoadingNonBlockingCoro());
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

	public override bool ShouldCreateSaveGameAfterLoad()
	{
		return true;
	}

	public List<TrainCar> SpawnFreeRoamTrain(IScenario scenario)
	{
		if (scenario == null)
		{
			Debug.LogError("Unexpected state: scenario is not null! Free roam cars will not be spawned!");
			return new List<TrainCar>();
		}
		ObservableCollectionExt<ICar> observableCollectionExt = scenario.Train?.Cars;
		if (observableCollectionExt == null || observableCollectionExt.Count == 0)
		{
			Debug.LogError("Unexpected state: carsData is not initialized properly! Free roam cars will not be spawned!");
			return new List<TrainCar>();
		}
		RailTrack item = StationController.GetStationAndTrackByTrackID(scenario.StartingTrackID).track;
		if (item == null)
		{
			Debug.LogError("Unexpected state: Track '" + scenario.StartingTrackID + "' can't be found! Free roam cars will not be spawned!");
			return new List<TrainCar>();
		}
		List<(string, string, TrainCarLivery, CargoType_v2)> source = observableCollectionExt.Select((ICar c) => (carID: c.Name, cargoID: c.CargoType, carTypeV2: Globals.G.Types.Liveries.FirstOrDefault((TrainCarLivery t) => t.id == c.Name), cargoTypeV2: Globals.G.Types.cargos.FirstOrDefault((CargoType_v2 t) => t.id == c.CargoType))).ToList();
		List<string> list = (from ct in source
			where ct.carTypeV2 == null
			select ct.carID).ToList();
		if (list.Count != 0)
		{
			Debug.LogError(string.Format("Unexpected state: {0} of the requested cars to spawn were invalid ({1})! Free roam cars will not be spawned!", list.Count, string.Join(", ", list)));
			return new List<TrainCar>();
		}
		List<string> list2 = (from ct in source
			where ct.carTypeV2.prefab == null
			select ct.carID).ToList();
		if (list2.Count != 0)
		{
			Debug.LogError(string.Format("Unexpected state: {0} of the requested cars don't have prefabs ({1})! Free roam cars will not be spawned!", list2.Count, string.Join(", ", list2)));
			return new List<TrainCar>();
		}
		List<string> list3 = (from ct in source
			where !string.IsNullOrWhiteSpace(ct.cargoID) && ct.cargoTypeV2 == null
			select ct.cargoID).ToList();
		if (list3.Count != 0)
		{
			Debug.LogError(string.Format("Unexpected state: {0} of the requested cargos were invalid ({1})! Free roam cars will not be spawned!", list3.Count, string.Join(", ", list3)));
			return new List<TrainCar>();
		}
		List<TrainCarLivery> list4 = source.Select<(string, string, TrainCarLivery, CargoType_v2), TrainCarLivery>(((string carID, string cargoID, TrainCarLivery carTypeV2, CargoType_v2 cargoTypeV2) ct) => ct.carTypeV2).ToList();
		List<CargoType> list5 = source.Select<(string, string, TrainCarLivery, CargoType_v2), CargoType>(((string carID, string cargoID, TrainCarLivery carTypeV2, CargoType_v2 cargoTypeV2) ct) => (!string.IsNullOrWhiteSpace(ct.cargoID)) ? ct.cargoTypeV2.v1 : CargoType.None).ToList();
		List<bool> list6 = observableCollectionExt.Select((ICar c) => c.Reversed).ToList();
		int count = list4.Count;
		List<TrainCar> list7 = SingletonBehaviour<CarSpawner>.Instance.SpawnCarTypesOnTrack(list4, list6, item, preventAutoCoupleOnLastCars: true, applyHandbrakeOnLastCars: true, 0.0, !carsOrientationAlongTrack, playerSpawnedCars: true);
		while (list7 == null || list7.Count == 0)
		{
			if (list4.Count == 1)
			{
				Debug.LogError($"Unexpected state: Couldn't spawn single free roam car on track '{item.LogicTrack().ID}'. Something is not right");
				return null;
			}
			Debug.LogWarning($"Couldn't spawn all {count} free roam cars, attempting spawn with first {list4.Count - 1} cars");
			list4.RemoveAt(list4.Count - 1);
			list5.RemoveAt(list5.Count - 1);
			list6.RemoveAt(list6.Count - 1);
			list7 = SingletonBehaviour<CarSpawner>.Instance.SpawnCarTypesOnTrack(list4, list6, item, preventAutoCoupleOnLastCars: true, applyHandbrakeOnLastCars: true, 0.0, !carsOrientationAlongTrack, playerSpawnedCars: true);
		}
		if (list7 != null && list7.Count > 0)
		{
			int count2 = list7.Count;
			for (int num = 0; num < count2; num++)
			{
				CargoType cargoType = list5[num];
				if (cargoType != CargoType.None)
				{
					list7[num].logicCar.LoadCargo(list7[num].logicCar.capacity, cargoType);
				}
			}
		}
		return list7;
	}

	public override void MakeCurrent()
	{
		session.MakeCurrent();
	}
}
