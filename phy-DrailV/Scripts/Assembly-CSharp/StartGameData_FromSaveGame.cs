using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DV;
using DV.CabControls;
using DV.Common;
using DV.Customization;
using DV.Customization.Paint;
using DV.JObjectExtstensions;
using DV.LocoRestoration;
using DV.Logic.Job;
using DV.OriginShift;
using DV.PointSet;
using DV.Scenarios.Common;
using DV.ServicePenalty;
using DV.Shops;
using DV.Simulation.Cars;
using DV.Teleporters;
using DV.TerrainSystem;
using DV.ThingTypes;
using DV.ThingTypes.TransitionHelpers;
using DV.UserManagement;
using DV.UserManagement.Data;
using DV.Utils;
using DV.WeatherSystem;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class StartGameData_FromSaveGame : AStartGameData
{
	public SaveGameSnapshot snapshot;

	public IDifficulty difficultyParamsOverride;

	private bool initialized;

	private bool carsAndJobsProperlyLoaded;

	private bool tutorialInitialSave;

	private SaveGameData saveGameData;

	public override bool IsStartingNewSession => tutorialInitialSave;

	protected override void Initialize()
	{
		if (initialized)
		{
			return;
		}
		initialized = true;
		Debug.Log("=== Initializing " + GetType().Name + " === [" + snapshot.Name + " @ " + snapshot.ParentSession.Name + " / " + snapshot.ParentSession.Owner.Name + "]");
		SaveGameManager.MakeSaveBackup(snapshot, "lastLoaded_");
		snapshot.LoadData();
		saveGameData = SaveGameData.LoadFromJson(snapshot.Data, snapshot.CustomChunkData);
		SingletonBehaviour<UserManager>.Instance.CurrentUser.SelectSession(snapshot.ParentSession);
		SingletonBehaviour<UserManager>.Instance.CurrentUser.Save(UserSavingMode.CurrentSession);
		tutorialInitialSave = saveGameData.GetBool("Tutorial_just_finished") ?? false;
		if (tutorialInitialSave)
		{
			saveGameData.RemoveData("Tutorial_just_finished");
		}
		if (difficultyParamsOverride != null)
		{
			Debug.Log("Overriding saved difficulty parameters via difficultyParamsOverride: " + difficultyParamsOverride.Name);
			base.DifficultyToUse = difficultyParamsOverride;
			return;
		}
		IDifficulty difficulty = null;
		try
		{
			byte[] customChunkData = saveGameData.GetCustomChunkData(SaveGameManager.CHUNK_DIFFICULTY);
			if (customChunkData != null)
			{
				difficulty = DifficultyDataUtils.GetDifficultyFromJSON(JObject.Parse(UserManager.ENCODING.GetString(customChunkData)), autoFill: false);
			}
		}
		catch (Exception ex)
		{
			Debug.LogError("Error loading/parsing difficulty data from save game: " + ex.Message);
			Debug.LogException(ex);
		}
		if (difficulty != null)
		{
			Debug.Log("Difficulty parameters loaded from save data: " + difficulty.Name);
			base.DifficultyToUse = difficulty;
		}
		else
		{
			Debug.LogError("Unexpected state: savedDifficultyParams are null for loaded game session. Using default difficulty values in attempt to recover.");
			base.DifficultyToUse = DifficultyParamsSetter.Standard;
		}
	}

	public override SaveGameData GetSaveGameData()
	{
		Initialize();
		return saveGameData;
	}

	public override string GetPostLoadMessage()
	{
		if (!carsAndJobsProperlyLoaded && TutorialEnabler.GetTutorialCompletionStates().completedTutorialAll && !tutorialInitialSave)
		{
			return "tutorial/trains_were_reset";
		}
		return null;
	}

	public override bool ShouldCreateSaveGameAfterLoad()
	{
		return false;
	}

	public override IEnumerator DoLoad(Transform playerContainer)
	{
		if (snapshot != null && snapshot.ParentSession != null)
		{
			snapshot.ParentSession.MakeCurrent();
			snapshot.ParentSession.PerformGameplayEntryDifficultyCheck(base.DifficultyToUse);
			Debug.Log("Verified unchanged difficulty: " + snapshot.ParentSession.VerifyUnchangedDifficulty());
		}
		_ = saveGameData.GetString("Game_mode") == "FreeRoam";
		DifficultyParamsSetter.SetDifficultyParams(base.DifficultyToUse);
		JObject jObject = saveGameData.GetJObject("Time_and_date");
		if (jObject != null)
		{
			SingletonBehaviour<WeatherDriver>.Instance.LoadSaveData(jObject, Globals.G.GameParams.WeatherEditorAlwaysAllowed);
			Debug.Log($"Loaded time and date {SingletonBehaviour<WeatherDriver>.Instance.manager.DateTime}");
		}
		else if (!tutorialInitialSave)
		{
			Debug.LogError("Unexpected state: Time and date not found in savegame");
		}
		SingletonBehaviour<BedSleepingController>.Instance.LoadFrom(saveGameData);
		SingletonBehaviour<UnlockablesManager>.Instance.ReadFromSaveGame(saveGameData);
		Debug.Log("Unlocked general licenses: " + string.Join(", ", SingletonBehaviour<UnlockablesManager>.Instance.UnlockedGeneralLicenses));
		Debug.Log("Unlocked job licenses: " + string.Join(", ", SingletonBehaviour<UnlockablesManager>.Instance.UnlockedJobLicenses));
		Debug.Log("Unlocked garages: " + string.Join(", ", SingletonBehaviour<UnlockablesManager>.Instance.UnlockedGarages));
		Debug.Log("Unlocked items: " + string.Join(", ", SingletonBehaviour<UnlockablesManager>.Instance.UnlockedItems));
		Vector3? vector = saveGameData.GetVector3("Player_position");
		Vector3? vector2 = saveGameData.GetVector3("Player_rotation");
		if (vector.HasValue && vector2.HasValue)
		{
			if (PlayerManager.IsPlayerPositionValid(vector.Value))
			{
				playerContainer.transform.position = vector.Value;
				Vector3 normalized = Vector3.ProjectOnPlane(Quaternion.Euler(vector2.Value) * Vector3.forward, Vector3.up).normalized;
				if (normalized != Vector3.zero)
				{
					playerContainer.transform.rotation = Quaternion.LookRotation(normalized);
				}
			}
			else
			{
				playerContainer.transform.position = LevelInfo.DefaultSpawnPosition;
				playerContainer.transform.rotation = Quaternion.Euler(LevelInfo.DefaultSpawnRotation);
				Debug.Log(string.Format("Saved player position {0} is not valid, using default from {1}: {2}", vector.Value, "LevelInfo", playerContainer.transform.position));
			}
			Debug.Log($"Loaded player position: {playerContainer.transform.position}");
		}
		else
		{
			playerContainer.transform.position = LevelInfo.DefaultSpawnPosition;
			playerContainer.transform.rotation = Quaternion.Euler(LevelInfo.DefaultSpawnRotation);
			Debug.Log(string.Format("No player position found in savegame, using default from {0}: {1}", "LevelInfo", playerContainer.transform.position));
		}
		StartCoroutine(LoadingNonBlockingCoro());
		yield break;
	}

	private IEnumerator LoadingNonBlockingCoro()
	{
		AStartGameData.carsAndJobsLoadingFinished = false;
		yield return null;
		SingletonBehaviour<LicenseManager>.Instance.LoadData(saveGameData);
		SingletonBehaviour<LicenseManager>.Instance.GrabAllGameModeSpecificUnlockables(saveGameData.GetString("Game_mode"));
		int maxIterations = 30;
		int iterationCount = 0;
		while (!SingletonBehaviour<LogicController>.Instance.initialized && iterationCount < maxIterations)
		{
			iterationCount++;
			yield return null;
		}
		if (!SingletonBehaviour<LogicController>.Instance.initialized)
		{
			Debug.LogError("LogicController has no tracks assigned. Jobs might not load properly.");
		}
		bool carsLoadedSuccessfully = false;
		try
		{
			JObject jObject = saveGameData.GetJObject(SaveGameKeys.Cars);
			if (jObject != null)
			{
				carsLoadedSuccessfully = CarsSaveManager.Load(jObject);
				if (!carsLoadedSuccessfully)
				{
					Debug.LogError("Cars not loaded successfully!");
				}
			}
			else
			{
				Debug.LogWarning("Cars save not found!");
			}
		}
		catch (Exception message)
		{
			CarsSaveManager.DeleteAllExistingCars();
			saveGameData.RemoveData(SaveGameKeys.Cars);
			saveGameData.RemoveData(SaveGameKeys.Jobs);
			Debug.LogError("Exception occurred while trying to load cars. Deleting all cars/jobs so game state is clean!");
			Debug.LogError(message);
		}
		if (!tutorialInitialSave)
		{
			try
			{
				JObject jObject2 = saveGameData.GetJObject("Customizers");
				SingletonCustomization<WorldCustomization>.I.Deserialize(jObject2);
			}
			catch (Exception message2)
			{
				Debug.LogError("Exception occurred while trying to load world customization. Not critical, just the data won't be loaded");
				Debug.LogError(message2);
			}
		}
		try
		{
			JObject jObject3 = saveGameData.GetJObject("Unique_cars");
			if (jObject3 != null)
			{
				SingletonBehaviour<CarSpawner>.Instance.LoadDeletedUniqueCarData(jObject3);
			}
			else if (!tutorialInitialSave)
			{
				Debug.LogError("Unique cars data not found!");
			}
		}
		catch (Exception message3)
		{
			Debug.LogError("Exception occurred while trying to load unique car data. Not critical, just the data won't be loaded");
			Debug.LogError(message3);
		}
		if (SingletonBehaviour<UserManager>.Instance?.CurrentUser?.CurrentSession?.GameMode == "Career")
		{
			try
			{
				List<TrainCar> allCars = SingletonBehaviour<CarSpawner>.Instance.AllCars;
				if (allCars != null && allCars.Count > 0)
				{
					foreach (TrainCar item in allCars)
					{
						if (item.uniqueCar && GarageCarSpawner.Spawners.TryGetValue(item.carLivery, out var value) && SingletonBehaviour<LicenseManager>.Instance.IsGarageUnlocked(value.garageType))
						{
							value.OverrideSpawnedCarReference(item);
						}
					}
				}
			}
			catch (Exception message4)
			{
				Debug.LogError("Exception occurred while trying to connect garage cars.");
				Debug.LogError(message4);
			}
			try
			{
				JObject jObject4 = saveGameData.GetJObject("Restoration_Locos");
				if (jObject4 != null)
				{
					foreach (LocoRestorationController allLocoRestorationController in LocoRestorationController.allLocoRestorationControllers)
					{
						JObject jObject5 = jObject4.GetJObject(allLocoRestorationController.SaveID);
						if (jObject5 != null)
						{
							allLocoRestorationController.LoadData(jObject5);
						}
						else
						{
							Debug.LogError("Unexpected state: LocoRestorationController for " + allLocoRestorationController.locoLivery.id + " is not present!");
						}
					}
				}
				else if (!tutorialInitialSave)
				{
					Debug.LogError("Unexpected state: LocoRestorationController data is missing!");
				}
			}
			catch (Exception message5)
			{
				Debug.LogError("Exception occurred while trying to load loco restoration data.");
				Debug.LogError(message5);
			}
		}
		TrainCar restoredCaboose = null;
		CarsSaveManager.CarDataToLoad caboosePrevSessionData = null;
		try
		{
			if (!carsLoadedSuccessfully && SingletonBehaviour<LicenseManager>.Instance.IsGarageUnlocked(Garage.Caboose.ToV2()))
			{
				string text = saveGameData.GetString("Last_Tracks_Hash");
				if (text != null)
				{
					Debug.Log("Restoring Caboose data from previous tracks hash " + text + " (current " + SingletonBehaviour<RailTrackRegistryBase>.Instance.TracksHash + ")");
					string carsSaveKeyForDesiredTracksHash = SaveGameKeys.GetCarsSaveKeyForDesiredTracksHash(text);
					JObject jObject6 = saveGameData.GetJObject(carsSaveKeyForDesiredTracksHash);
					if (jObject6 != null)
					{
						caboosePrevSessionData = CarsSaveManager.GetFirstCarDataForCarTypeFromSavegame(jObject6, TrainCarType.CabooseRed);
						if (caboosePrevSessionData != null)
						{
							GameObject carPrefab = TrainCar.GetCarPrefab(caboosePrevSessionData.carType);
							if (carPrefab != null)
							{
								Bounds bounds = carPrefab.GetComponent<TrainCar>().Bounds;
								restoredCaboose = SingletonBehaviour<CarSpawner>.Instance.SpawnLoadedCarAtNearestAvailableSpace(carPrefab, bounds, caboosePrevSessionData.id, caboosePrevSessionData.carGuid, caboosePrevSessionData.playerSpawnedCar, caboosePrevSessionData.uniqueCar, caboosePrevSessionData.worldPos + WorldMover.currentMove, 16000f);
								if (restoredCaboose != null)
								{
									restoredCaboose.brakeSystem.ForceCylinderPressure();
									restoredCaboose.brakeSystem.SetControlReservoirPressure();
									GarageCarSpawner garageCarSpawner = UnityEngine.Object.FindObjectsOfType<GarageCarSpawner>().FirstOrDefault((GarageCarSpawner garage) => garage.GarageCarLiveries.Contains(restoredCaboose.carLivery));
									if (garageCarSpawner != null)
									{
										garageCarSpawner.OverrideSpawnedCarReference(restoredCaboose);
									}
									if ((bool)restoredCaboose.CargoModelController)
									{
										restoredCaboose.CargoModelController.currentCargoModelIndex = caboosePrevSessionData.loadedCargoModel;
									}
									if (caboosePrevSessionData.loadedCargoType != CargoType.None)
									{
										restoredCaboose.logicCar.LoadCargo(restoredCaboose.cargoCapacity, caboosePrevSessionData.loadedCargoType);
									}
									if (caboosePrevSessionData.useExplodedModel)
									{
										TrainCarExplosion.UpdateModelToExploded(restoredCaboose);
									}
									if (!string.IsNullOrEmpty(caboosePrevSessionData.paintThemeExterior) && restoredCaboose.PaintExterior != null && PaintTheme.TryLoad(caboosePrevSessionData.paintThemeExterior, out var theme))
									{
										restoredCaboose.PaintExterior.CurrentTheme = theme;
									}
									if (!string.IsNullOrEmpty(caboosePrevSessionData.paintThemeInterior) && restoredCaboose.PaintInterior != null && PaintTheme.TryLoad(caboosePrevSessionData.paintThemeInterior, out var theme2))
									{
										restoredCaboose.PaintInterior.CurrentTheme = theme2;
									}
									if (caboosePrevSessionData.carState != null)
									{
										restoredCaboose.GetComponent<CarStateSave>()?.SetCarStateSaveData(caboosePrevSessionData.carState);
									}
									if (caboosePrevSessionData.simCarState != null)
									{
										restoredCaboose.GetComponent<SimCarStateSave>()?.SetStateSaveData(caboosePrevSessionData.simCarState);
									}
									if (caboosePrevSessionData.modCarState != null)
									{
										restoredCaboose.GetComponent<TrainCarCustomization>()?.Deserialize(caboosePrevSessionData.modCarState);
									}
									Debug.Log("Spawned caboose (extracted from previous track data) on closest available point on track.");
									Debug.Log($"Previous Caboose position: {caboosePrevSessionData.worldPos}\nPosition after restore: {restoredCaboose.transform.AbsolutePosition()}");
								}
								else
								{
									Debug.LogError("Unexpected state: Couldn't spawn a car for some reason! Ignoring Caboose recovering.");
								}
							}
							else
							{
								Debug.LogError("Unexpected state: carPrefab doesn't exist! Ignoring Caboose recovering.");
							}
						}
					}
					else
					{
						Debug.LogError("Couldn't extract data with prevTracksHash: " + text + ". Ignoring Caboose recovering.");
					}
				}
				else
				{
					Debug.LogError("No data for Last_Tracks_Hash available. Ignoring Caboose recovering.");
				}
			}
		}
		catch (Exception message6)
		{
			Debug.LogError("Exception occurred while trying to recover caboose car. Ignoring caboose recovering!");
			Debug.LogError(message6);
		}
		while (!WorldStreamingInit.IsStreamingDone)
		{
			yield return null;
		}
		SingletonBehaviour<StartingItemsController>.Instance.AddStartingItems(saveGameData, tutorialInitialSave);
		int itemLoadSafety = 50;
		while (!SingletonBehaviour<StartingItemsController>.Instance.itemsLoaded)
		{
			int num = itemLoadSafety - 1;
			itemLoadSafety = num;
			if (num < 0)
			{
				break;
			}
			yield return null;
		}
		if (!SingletonBehaviour<StartingItemsController>.Instance.itemsLoaded)
		{
			Debug.LogError("Items are not loaded correctly. Jobs might not load properly.");
		}
		if (caboosePrevSessionData != null && restoredCaboose != null)
		{
			GameObject gameObject = new GameObject();
			gameObject.transform.SetPositionAndRotation(caboosePrevSessionData.worldPos + WorldMover.currentMove, Quaternion.Euler(caboosePrevSessionData.worldRotEuler));
			InventoryItemSpec[] componentsInChildren = restoredCaboose.interior.GetComponentsInChildren<InventoryItemSpec>(includeInactive: true);
			foreach (InventoryItemSpec inventoryItemSpec in componentsInChildren)
			{
				Vector3 vector = gameObject.transform.InverseTransformPoint(inventoryItemSpec.transform.position);
				Quaternion localRotation = Quaternion.Inverse(gameObject.transform.rotation) * inventoryItemSpec.transform.rotation;
				inventoryItemSpec.transform.localPosition = vector + new Vector3(0f, 0.05f, 0f);
				inventoryItemSpec.transform.localRotation = localRotation;
			}
			UnityEngine.Object.Destroy(gameObject);
		}
		try
		{
			if (carsLoadedSuccessfully)
			{
				JobsSaveGameData jobsSaveGameData = saveGameData.GetObject<JobsSaveGameData>(SaveGameKeys.Jobs, JobSaveManager.serializeSettings);
				if (jobsSaveGameData != null)
				{
					SingletonBehaviour<JobSaveManager>.Instance.LoadJobSaveGameData(jobsSaveGameData);
					carsAndJobsProperlyLoaded = true;
				}
				else
				{
					Debug.LogWarning("Jobs save not found!");
				}
				SingletonBehaviour<JobSaveManager>.Instance.MarkAllNonJobCarsAsUnused();
			}
		}
		catch (Exception message7)
		{
			SingletonBehaviour<JobsManager>.Instance.AbandonAllJobs();
			SingletonBehaviour<JobSaveManager>.Instance.DeleteAllNonActiveJobChains();
			CarsSaveManager.DeleteAllExistingCars();
			saveGameData.RemoveData(SaveGameKeys.Cars);
			saveGameData.RemoveData(SaveGameKeys.Jobs);
			Debug.LogError("Exception occurred while trying to load jobs. Deleting all cars/jobs so game state is clean!");
			Debug.LogError(message7);
		}
		if (!carsAndJobsProperlyLoaded)
		{
			List<JobBooklet> list = (from jbi in SingletonBehaviour<StorageController>.Instance.GetAllStorageItems()
				where jbi.GetComponent<JobBooklet>() != null
				select jbi.GetComponent<JobBooklet>()).ToList();
			if (list.Count > 0)
			{
				Debug.LogWarning(string.Format("Deleting {0} {1}s due to cars and jobs not loaded properly!", list.Count, "JobBooklet"));
				foreach (JobBooklet item2 in list)
				{
					item2.DestroyJobBooklet();
				}
			}
		}
		JObject[] jObjectArray = saveGameData.GetJObjectArray("Debt_existing_locos");
		if (jObjectArray != null)
		{
			SingletonBehaviour<LocoDebtController>.Instance.LoadExistingLocosDebtsSaveData(jObjectArray);
			Debug.Log("Loaded existing locos debt");
		}
		JObject[] jObjectArray2 = saveGameData.GetJObjectArray("Debt_deleted_locos");
		if (jObjectArray2 != null)
		{
			SingletonBehaviour<LocoDebtController>.Instance.LoadDestroyedLocosDebtsSaveData(jObjectArray2);
			Debug.Log("Loaded destroyed locos debt");
		}
		JObject[] jObjectArray3 = saveGameData.GetJObjectArray("Debt_existing_jobs");
		if (jObjectArray3 != null)
		{
			SingletonBehaviour<JobDebtController>.Instance.LoadExistingJobsDebtsSaveData(jObjectArray3);
			Debug.Log("Loaded existing jobs debt");
		}
		JObject[] jObjectArray4 = saveGameData.GetJObjectArray("Debt_staged_jobs");
		if (jObjectArray4 != null)
		{
			SingletonBehaviour<JobDebtController>.Instance.LoadStagedJobsDebtsSaveData(jObjectArray4);
			Debug.Log("Loaded staged jobs debt");
		}
		JObject jObject7 = saveGameData.GetJObject("Debt_existing_jobless_cars");
		if (jObject7 != null)
		{
			SingletonBehaviour<JobDebtController>.Instance.LoadExistingJoblessCarsDebtsSaveData(jObject7);
			Debug.Log("Loaded existing jobless cars debt");
		}
		JObject jObject8 = saveGameData.GetJObject("Debt_deleted_jobless_cars");
		if (jObject8 != null)
		{
			SingletonBehaviour<JobDebtController>.Instance.LoadDeletedJoblessCarDebtsSaveData(jObject8);
			Debug.Log("Loaded deleted jobless cars debt");
		}
		JObject jObject9 = saveGameData.GetJObject("Debt_insurance");
		if (jObject9 != null)
		{
			SingletonBehaviour<CareerManagerDebtController>.Instance.feeQuota.LoadSaveData(jObject9);
			Debug.Log("Loaded insurance fee data");
		}
		JObject[] jObjectArray5 = saveGameData.GetJObjectArray("Debt_deleted_owned_cars");
		if (jObjectArray5 != null)
		{
			SingletonBehaviour<OwnedCarsStateController>.Instance.LoadDestroyedOwnedCarsSaveData(jObjectArray5);
			Debug.Log("Loaded deleted owned cars state");
		}
		List<Car> cars = (from tc in SingletonBehaviour<UnusedTrainCarDeleter>.Instance.GetUnusedTrainCarsList()
			where tc != null && !CarTypes.IsAnyLocomotiveOrTender(tc.carLivery) && !tc.playerSpawnedCar
			select tc.logicCar).ToList();
		SingletonBehaviour<JobDebtController>.Instance.RegisterJoblessCars(cars);
		while (PlayerManager.PlayerTransform == null)
		{
			yield return null;
		}
		if (carsAndJobsProperlyLoaded || tutorialInitialSave)
		{
			string text2 = saveGameData.GetString("Player_car_guid");
			if (!string.IsNullOrEmpty(text2))
			{
				TrainCar trainCarByCarGuid = SingletonBehaviour<TrainCarRegistry>.Instance.GetTrainCarByCarGuid(text2);
				if (trainCarByCarGuid == null)
				{
					Debug.LogError("Player parent car with guid '" + text2 + "' not found. Player will not be attached to any car.", this);
				}
				else
				{
					Transform interior = trainCarByCarGuid.interior;
					PlayerManager.TeleportPlayer(PlayerManager.PlayerTransform.position, PlayerManager.PlayerTransform.rotation, interior, useRotation: false);
					Debug.Log(string.Format("{0} - Player teleported to car: {1}", Time.frameCount, (interior != null) ? interior.name : "null"), interior);
				}
			}
		}
		else if (TutorialEnabler.GetTutorialCompletionStates().completedTutorialAll)
		{
			StationFastTravelDestination closestStationTeleporter = StationFastTravelDestination.GetClosestStationTeleporterWithPlayerLicensedLoco(PlayerManager.PlayerTransform.position);
			if (closestStationTeleporter != null)
			{
				Transform teleportAnchor = closestStationTeleporter.playerTeleportAnchor;
				PlayerManager.TeleportPlayer(teleportAnchor.position, teleportAnchor.rotation, null, useRotation: true);
				Streamer[] source = UnityEngine.Object.FindObjectsOfType<Streamer>();
				Streamer nearScenesStreamer = source.FirstOrDefault((Streamer streamer) => streamer.name.ToLower().Contains("near"));
				Streamer farScenesStreamer = source.FirstOrDefault((Streamer streamer) => streamer.name.ToLower().Contains("far"));
				TerrainGrid terrainGrid = SingletonBehaviour<TerrainGrid>.Instance;
				while ((terrainGrid != null && !terrainGrid.IsInLoadedRegion(teleportAnchor.position)) || (nearScenesStreamer != null && !nearScenesStreamer.IsSceneLoaded(teleportAnchor.position)) || (farScenesStreamer != null && !farScenesStreamer.IsSceneLoaded(teleportAnchor.position)))
				{
					yield return WaitFor.Seconds(0.5f);
					Debug.LogWarning("Waiting terrains and streamers to finish loading");
				}
				PlayerManager.TeleportPlayer(teleportAnchor.position, teleportAnchor.rotation, null, useRotation: true);
				Debug.LogWarning($"{Time.frameCount} - Player moved to closest station {closestStationTeleporter.StationController.stationInfo.Name} due to tracks update.");
				bool num2 = saveGameData.GetBool("Caboose_In_Range") ?? false;
				bool flag = SingletonBehaviour<LicenseManager>.Instance.IsGarageUnlocked(Garage.Caboose.ToV2());
				if (num2 && flag)
				{
					SingletonBehaviour<CoroutineManager>.Instance.Run(BringCabooseToClosestStationAfterJobsGenerate(closestStationTeleporter));
				}
			}
			else
			{
				Debug.LogError("Unexpected state: Can't move player to closest station, no station teleporters in scene!");
			}
		}
		try
		{
			if ((bool)SingletonBehaviour<HazmatTileManager>.Instance)
			{
				byte[] customChunkData = saveGameData.GetCustomChunkData(SaveGameManager.CHUNK_HAZMAT);
				if (customChunkData != null)
				{
					SingletonBehaviour<HazmatTileManager>.Instance.Deserialize(customChunkData);
					Debug.Log("Hazmat data loaded");
				}
			}
		}
		catch (Exception ex)
		{
			Debug.LogError("Something broke while loading hazmat: " + ex.Message);
			Debug.LogException(ex);
		}
		AStartGameData.carsAndJobsLoadingFinished = true;
		Debug.Log(string.Format("{0} - {1}", Time.frameCount, "carsAndJobsLoadingFinished"));
		GlobalShopController.UpdateItemStocksOnGameLoad();
	}

	private IEnumerator BringCabooseToClosestStationAfterJobsGenerate(StationFastTravelDestination closestStationFastTravelDestination)
	{
		StationController stationController = closestStationFastTravelDestination.StationController;
		GarageCarSpawner cabooseGarageSpawner = UnityEngine.Object.FindObjectsOfType<GarageCarSpawner>().FirstOrDefault((GarageCarSpawner garage) => garage.garageType.v1 == Garage.Caboose);
		GameObject caboosePrefab = TrainCar.GetCarPrefab(TrainCarType.CabooseRed);
		if (caboosePrefab != null && cabooseGarageSpawner != null && stationController != null)
		{
			StationProceduralJobsController stationJobController = stationController.ProceduralJobsController;
			if (stationJobController != null)
			{
				int safety = 5;
				while (!stationJobController.IsJobGenerationActive && safety > 0)
				{
					yield return null;
					safety--;
				}
				if (stationJobController.IsJobGenerationActive)
				{
					Debug.LogWarning($"{Time.frameCount} - Waiting for station to finish job generation");
				}
				while (stationJobController.IsJobGenerationActive)
				{
					yield return null;
				}
			}
			else
			{
				Debug.LogError("Unexpected state: stationJobController is null! Won't wait for job generation finish.");
			}
			Bounds bounds = caboosePrefab.GetComponent<TrainCar>().Bounds;
			(RailTrack, EquiPointSet.Point)? pointOnClosestAvailableTrackForCar = CarSpawner.GetPointOnClosestAvailableTrackForCar(closestStationFastTravelDestination.playerTeleportAnchor.position, bounds.extents, SingletonBehaviour<RailTrackRegistryBase>.Instance.AllTracks, 1f, 5f, 2000f);
			if (pointOnClosestAvailableTrackForCar.HasValue)
			{
				RailTrack item = pointOnClosestAvailableTrackForCar.Value.Item1;
				EquiPointSet.Point item2 = pointOnClosestAvailableTrackForCar.Value.Item2;
				Vector3 forward = item2.forward;
				Vector3 vector = (Vector3)item2.position + WorldMover.currentMove;
				TrainCar trainCar = cabooseGarageSpawner.garageCars[0];
				if (trainCar != null)
				{
					if (trainCar.derailed)
					{
						Debug.LogError("Unexpected state: Caboose shouldn't be derailed! Trying to recover by rerailing it on destination position.");
						trainCar.Rerail(item, vector, forward);
					}
					else
					{
						trainCar.MoveToTrackWithCarUncouple(item, vector, forward);
					}
				}
				else
				{
					Debug.LogError("Unexpected state: caboose should have been already loaded! Trying to recover by spawning new Caboose.");
					TrainCar trainCar2 = SingletonBehaviour<CarSpawner>.Instance.SpawnCar(caboosePrefab, item, vector, forward, playerSpawnedCar: true);
					if (trainCar2 != null)
					{
						cabooseGarageSpawner.OverrideSpawnedCarReference(trainCar2);
					}
					else
					{
						Debug.LogError("Unexpected state: Couldn't spawn caboose for some reason!");
					}
				}
				Debug.LogWarning($"{Time.frameCount} - Teleported caboose to closest station due to tracks update.");
			}
			else
			{
				Debug.LogError("Couldn't find place for caboose in 2000m radius!");
			}
		}
		else
		{
			Debug.LogError("Unexpected state: caboosePrefab or cabooseGarageSpawner or closestStationFastTravelDestinationdon't exist! Ignoring Caboose teleport to nearest station");
		}
	}

	public override void MakeCurrent()
	{
		snapshot.ParentSession.MakeCurrent();
	}
}
