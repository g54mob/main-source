using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoadManager
{
	public delegate void SaveFinishedCallback(bool result);

	[HideInInspector]
	public static string homeSceneName = "01_home";

	private static string saveGameFilename = "/wobbledogsData_";

	private static string backupFilePre = "/backup_";

	private static string saveControlsFilename = "/controlsData.dat";

	private static string fileTypeName = ".dat";

	private static string backupTypeName = ".bak";

	private static string copyExtension = "_tempCopy";

	private static string backupExtension = "_backup";

	private static List<string> backedUpFiles = new List<string>();

	private SaveFile loadedFile;

	private PlayerData loadedPlayerData;

	private SavedControlsFile loadedControls;

	private bool hasInitializedControls;

	private bool dogsLoaded;

	private bool goalsLoaded;

	private bool cocoonsLoaded;

	private bool dogDensLoaded;

	private bool tutorialLoaded;

	private bool gameModeLoaded;

	private bool dateTimeLoaded;

	private bool researchLoaded;

	private bool inventoryLoaded;

	private bool buildablesLoaded;

	private bool worldObjectsLoaded;

	private bool floraUnlocksLoaded;

	private bool ghostManagerLoaded;

	private bool constructionLoaded;

	private bool gameplaySettingsLoaded;

	private bool nonDependantDataLoaded;

	private int numFileReadTries = 20;

	private ObjectRegistration regRef;

	private ActiveSaveFile activeSaveFileHolder;

	public SaveLoadManager()
	{
		regRef = ObjectRegistration.GetRegistrationScript();
		activeSaveFileHolder = regRef.GetGlobalComponent<ActiveSaveFile>(GlobalObject.SAVE_FILE_HOLDER);
	}

	public static string GetFirstFileName()
	{
		string result = saveGameFilename;
		int num = -1;
		List<string> allSaveFilePaths = GetAllSaveFilePaths();
		for (int i = 0; i < allSaveFilePaths.Count; i++)
		{
			int length = allSaveFilePaths[i].IndexOf('.') - saveGameFilename.Length;
			int.TryParse(allSaveFilePaths[i].Substring(saveGameFilename.Length, length), out var result2);
			if (num < 0 || result2 < num)
			{
				num = result2;
				result = allSaveFilePaths[i];
			}
		}
		return result;
	}

	public static string GetNewFileName()
	{
		string text = saveGameFilename;
		int num = -1;
		List<string> allSaveFilePaths = GetAllSaveFilePaths();
		for (int i = 0; i < allSaveFilePaths.Count; i++)
		{
			int length = allSaveFilePaths[i].IndexOf('.') - saveGameFilename.Length;
			int.TryParse(allSaveFilePaths[i].Substring(saveGameFilename.Length, length), out var result);
			if (result > num)
			{
				num = result;
			}
		}
		return text + (num + 1) + fileTypeName;
	}

	public static string CreateNewFile(string newPlayerName)
	{
		string newFileName = GetNewFileName();
		using (FileStream fileStream = File.Create(Application.persistentDataPath + newFileName))
		{
			SaveFile saveFile = new SaveFile();
			saveFile.fileName = newPlayerName;
			new BinaryFormatter().Serialize(fileStream, saveFile);
			fileStream.Flush();
			fileStream.Close();
			return newFileName;
		}
	}

	public void DeleteSaveFile(string fileName)
	{
		string path = Application.persistentDataPath + fileName;
		if (!File.Exists(path))
		{
			Debug.LogError("No file found for: " + fileName);
			return;
		}
		File.Delete(path);
		try
		{
			List<string> allBackupsForSaveFilePath = GetAllBackupsForSaveFilePath(fileName);
			for (int i = 0; i < allBackupsForSaveFilePath.Count; i++)
			{
				File.Delete(Application.persistentDataPath + allBackupsForSaveFilePath[i]);
			}
			if (backedUpFiles.Contains(fileName))
			{
				backedUpFiles.Remove(fileName);
			}
		}
		catch (Exception message)
		{
			Debug.LogError(message);
			Debug.Log("Failed to delete backsups for save.");
		}
	}

	public IEnumerator SaveEverything(SaveFinishedCallback callback)
	{
		yield return SaveData(buildables: true, inventory: true, dateTime: true, worldObjects: true, dogs: true, tutorial: true, gameMode: true, research: true, floraUnlocks: true, dogDenManager: true, goals: true, callback);
	}

	public bool CreateBackupFile(string fullPath, string fullPathDatless)
	{
		if (regRef == null || loadedFile == null)
		{
			Debug.LogError("Could not open FileStream. Missing references.");
			return false;
		}
		try
		{
			if (File.Exists(fullPathDatless + copyExtension + fileTypeName))
			{
				File.Delete(fullPathDatless + copyExtension + fileTypeName);
			}
			File.Copy(fullPath, fullPathDatless + copyExtension + fileTypeName);
		}
		catch (Exception e)
		{
			Debug.LogError("Error creating backup file. Aborting.");
			HandleSaveFlowException(e, fullPath, fullPathDatless);
			return false;
		}
		return true;
	}

	public void HandleSaveFlowException(Exception e, string fullPath, string fullPathDatless)
	{
		Debug.LogError(e);
		Debug.LogError("Something went wrong during saving.");
		if (File.Exists(fullPathDatless + copyExtension + fileTypeName))
		{
			File.Replace(fullPathDatless + copyExtension + fileTypeName, fullPath, fullPathDatless + copyExtension + backupExtension + backupTypeName);
			File.Delete(fullPathDatless + copyExtension + fileTypeName);
		}
	}

	public void OnSaveFlowSuccess(string fullPathDatless)
	{
		if (File.Exists(fullPathDatless + copyExtension + fileTypeName))
		{
			File.Delete(fullPathDatless + copyExtension + fileTypeName);
		}
		MonoBehaviour.print("Save complete");
		MonoBehaviour.print(fullPathDatless);
	}

	private IEnumerator SerializeSaveFileSafely(SaveFile newSave, string fullPath, string fullPathDatless, SaveFinishedCallback callback, string callingFunctionName)
	{
		WaitForSecondsRealtime fileWait = new WaitForSecondsRealtime(0.05f);
		Exception e = null;
		bool success = false;
		for (int i = 0; i < numFileReadTries; i++)
		{
			try
			{
				using (FileStream fileStream = File.Open(fullPath, FileMode.Truncate))
				{
					new BinaryFormatter().Serialize(fileStream, newSave);
					fileStream.Flush();
					fileStream.Close();
					success = true;
				}
				if (success)
				{
					break;
				}
			}
			catch (IOException ex)
			{
				e = ex;
				Debug.LogWarning("IO Exception during " + callingFunctionName + ". Retrying.");
			}
			yield return fileWait;
		}
		if (!success)
		{
			Debug.LogError("Exception during " + callingFunctionName);
			HandleSaveFlowException(e, fullPath, fullPathDatless);
			callback?.Invoke(result: false);
			yield break;
		}
		e = null;
		success = false;
		for (int i = 0; i < numFileReadTries; i++)
		{
			try
			{
				using (FileStream fileStream2 = File.Open(fullPath, FileMode.Open))
				{
					_ = (SaveFile)new BinaryFormatter().Deserialize(fileStream2);
					fileStream2.Flush();
					fileStream2.Close();
					success = true;
				}
				if (success)
				{
					break;
				}
			}
			catch (IOException ex2)
			{
				e = ex2;
				Debug.LogWarning("IO Exception while reading serialized file during " + callingFunctionName + ". Retrying.");
			}
			yield return fileWait;
		}
		if (!success)
		{
			Debug.LogError("Exception while reading serialized file during " + callingFunctionName);
			HandleSaveFlowException(e, fullPath, fullPathDatless);
			callback?.Invoke(result: false);
		}
		else
		{
			loadedFile = newSave;
			OnSaveFlowSuccess(fullPathDatless);
			callback?.Invoke(result: true);
		}
	}

	public IEnumerator SaveControlMapping(ControlMapping mappingToSave, ulong? steamID)
	{
		string fullPath = Application.persistentDataPath + saveControlsFilename;
		string fullPathDatless = fullPath.Replace(".dat", "");
		if (!CreateBackupFile(fullPath, fullPathDatless))
		{
			yield break;
		}
		SavedControlsFile savedControlsFile = loadedControls;
		if (!steamID.HasValue)
		{
			savedControlsFile.defaultUserMapping = mappingToSave;
		}
		else
		{
			Dictionary<ulong, ControlMapping> dictionary;
			if (savedControlsFile.steamUserIDToControlMappingDict == null)
			{
				dictionary = new Dictionary<ulong, ControlMapping>();
			}
			else
			{
				dictionary = new Dictionary<ulong, ControlMapping>();
				savedControlsFile.steamUserIDToControlMappingDict.Load(dictionary);
			}
			dictionary[steamID.Value] = mappingToSave;
			savedControlsFile.steamUserIDToControlMappingDict = new SerializableDictionary<ulong, ControlMapping>(dictionary);
		}
		WaitForSecondsRealtime fileWait = new WaitForSecondsRealtime(0.05f);
		SavedControlsFile newSave = savedControlsFile;
		Exception e = null;
		bool success = false;
		for (int i = 0; i < numFileReadTries; i++)
		{
			try
			{
				using (FileStream fileStream = File.Open(fullPath, FileMode.Open))
				{
					new BinaryFormatter().Serialize(fileStream, newSave);
					fileStream.Flush();
					fileStream.Close();
					loadedControls = newSave;
					success = true;
				}
				if (success)
				{
					break;
				}
			}
			catch (IOException ex)
			{
				e = ex;
				Debug.LogWarning("IO Exception during SaveControlMapping(). Retrying.");
			}
			yield return fileWait;
		}
		if (!success)
		{
			Debug.LogError("Exception during SaveData()");
			HandleSaveFlowException(e, fullPath, fullPathDatless);
		}
		else
		{
			OnSaveFlowSuccess(fullPathDatless);
		}
	}

	public IEnumerator SaveData(bool buildables, bool inventory, bool dateTime, bool worldObjects, bool dogs, bool tutorial, bool gameMode, bool research, bool floraUnlocks, bool dogDenManager, bool goals, SaveFinishedCallback callback)
	{
		yield return new WaitForEndOfFrame();
		string text = Application.persistentDataPath + activeSaveFileHolder.GetActiveSaveFile();
		string fullPathDatless = text.Replace(".dat", "");
		if (!CreateBackupFile(text, fullPathDatless))
		{
			callback?.Invoke(result: false);
			yield break;
		}
		PlayerData mainData = loadedFile.mainData;
		mainData.newSave = false;
		mainData.hasGeneratedCorePortraits = true;
		mainData.passiveModeDataEverSaved = true;
		mainData.passiveModeEnabled = GameSettings.IsPassiveModeEnabled();
		mainData.passive_autoPupate = GameSettings.PassiveModeAutoPupate();
		mainData.passive_autoHatch = GameSettings.PassiveModeAutoHatch();
		mainData.passive_autoCleanPoop = GameSettings.PassiveModeAutoCleanPoop();
		mainData.passive_autoClearHole = GameSettings.PassiveModeAutoClearHole();
		mainData.passive_autoCleanPuddles = GameSettings.PassiveModeAutoCleanPuddles();
		mainData.passive_autoCleanEmptyCocoons = GameSettings.PassiveModeAutoCleanEmptyCocoons();
		mainData.passive_autoCleanHalfEatenFood = GameSettings.PassiveModeAutoCleanHalfEatenFood();
		mainData.passive_autoCleanBabyTeeth = GameSettings.PassiveModeAutoCleanBabyTeeth();
		mainData.passive_autoCleanDirt = GameSettings.PassiveModeAutoCleanDirt();
		mainData.passive_autoCleanSnow = GameSettings.PassiveModeAutoCleanSnow();
		mainData.passive_autoCollectSeeds = GameSettings.PassiveModeAutoCollectSeeds();
		mainData.passive_autoCollectUpgrades = GameSettings.PassiveModeAutoCollectUpgrades();
		mainData.passive_autoUnwrapGifts = GameSettings.PassiveModeAutoUnwrapGifts();
		mainData.passive_autoCapsuleOpen = GameSettings.PassiveModeAutoCapsuleOpen();
		mainData.passive_autoCollectCores = GameSettings.PassiveModeAutoCollectCores();
		mainData.passive_autoEggCollection = GameSettings.PassiveModeAutoEggCollect();
		mainData.passive_autoEggHatch = GameSettings.PassiveModeAutoEggHatch();
		mainData.passive_autoHideGUI = GameSettings.PassiveModeAutoHideGUI();
		mainData.passive_autoHideCursor = GameSettings.PassiveModeAutoHideCursor();
		mainData.passive_DeathNotifications = GameSettings.PassiveModeDeathNotificationOption();
		mainData.passive_EggNotifications = GameSettings.PassiveModeEggNotificationOption();
		mainData.passive_MutationNotifications = GameSettings.PassiveModeMutationNotificationOption();
		mainData.passive_autoBreedingOption = GameSettings.PassiveModeAutoBreedingOption();
		mainData.passive_autoBreedingRelationshipRequirement = GameSettings.PassiveModeAutoBreedingRelationshipRequirement();
		mainData.passive_eggMutationRate = GameSettings.PassiveEggMutationRate();
		mainData.passive_pupationMutationRate = GameSettings.PassivePupationMutationRate();
		mainData.passive_floraMutationEffects = GameSettings.PassiveFloraMutationEffects();
		mainData.passive_cam_randomPenFocus = GameSettings.PassiveModeRandomPenFocus();
		mainData.passive_cam_randomDogFocus = GameSettings.PassiveModeRandomDogFocus();
		mainData.passive_cam_randomPenFocusRotation = GameSettings.PassiveModeRandomPenFocusRotation();
		mainData.passive_cam_focusOnDyingDogs = GameSettings.PassiveModeFocusOnDyingDogs();
		mainData.passive_cam_focusOnHatchingCocoons = GameSettings.PassiveModeFocusOnHatchingCocoons();
		mainData.passive_cam_focusOnHatchingEggs = GameSettings.PassiveModeFocusOnHatchingEggs();
		mainData.passive_deathByStarvation = GameSettings.PassiveModeDeathByStarvation();
		GameMode gameMode2 = regRef.GetGlobalComponent<SceneManagerBase>(GlobalObject.SCENE_MANAGER).GetGameMode();
		if (buildables)
		{
			SaveableDogHome savedDogHome = regRef.GetGlobalComponent<DogHome>(GlobalObject.DOG_HOME).GetSavedDogHome();
			if (gameMode2 == GameMode.HOME && !CheatEngine.cheatRef.saveModeBreedingOverride)
			{
				mainData.dogPenHome = savedDogHome;
			}
			else if (gameMode2 == GameMode.BREEDING || CheatEngine.cheatRef.saveModeBreedingOverride)
			{
				mainData.dogPenBreedingCenter = savedDogHome;
			}
		}
		if (inventory)
		{
			mainData.inventory = regRef.GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER).playerInventory.GetSavedInventory();
		}
		if (research)
		{
			mainData.research = regRef.GetGlobalComponent<ResearchManager>(GlobalObject.RESEARCH_MANAGER).GetSaveableResearch();
		}
		if (goals)
		{
			mainData.goals = GoalsController.GetSaveableGoals();
		}
		if (floraUnlocks)
		{
			mainData.floraUnlocks = regRef.GetGlobalComponent<FloraManager>(GlobalObject.FLORA_MANAGER).GetSaveableFloraUnlocks();
		}
		if (dateTime)
		{
			mainData.dateTime = regRef.GetGlobalComponent<GlobalClock>(GlobalObject.GLOBAL_CLOCK).GetSavedDateTime();
		}
		if (worldObjects)
		{
			regRef.SaveIDCounter(mainData);
			if (gameMode2 == GameMode.HOME)
			{
				mainData.worldTaggedObjectsHome = regRef.GetSavedTaggedObjects();
			}
		}
		if (dogs)
		{
			mainData.dogs = regRef.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION).GetSavedDogs();
		}
		if (dogDenManager)
		{
			mainData.dogDenManager = DogDenManager.GetSaveableDogDenManager();
		}
		if (tutorial)
		{
			mainData.tutorialState = TutorialController.GetCurrentState();
			mainData.initialEggCollected = TutorialController.HasInitialEggBeenCollected();
		}
		new SaveFile();
		SaveFile saveFile = loadedFile;
		saveFile.mainData = mainData;
		loadedPlayerData = saveFile.mainData;
		yield return SerializeSaveFileSafely(saveFile, text, fullPathDatless, callback, "SaveGame()");
	}

	public void SetActiveFile(string newActiveFile)
	{
		activeSaveFileHolder.SetActiveSaveFile(newActiveFile);
	}

	public void LoadData(SaveFinishedCallback callback, bool fromMainMenu = false)
	{
		if (!(regRef.GetGlobalObject(GlobalObject.DOG_REGISTRATION, nullAllowed: true) == null))
		{
			regRef.StartCoroutine(LoadGame(callback, fromMainMenu));
		}
	}

	public SavedControlsFile GetLoadedControlMappings()
	{
		return loadedControls;
	}

	public IEnumerator ClearBreedingDogs(SaveFinishedCallback callback)
	{
		if (loadedFile == null)
		{
			Debug.LogError("No active save file for: " + Application.persistentDataPath + activeSaveFileHolder.GetActiveSaveFile());
			callback?.Invoke(result: false);
			yield break;
		}
		string text = Application.persistentDataPath + activeSaveFileHolder.GetActiveSaveFile();
		string fullPathDatless = text.Replace(".dat", "");
		if (!CreateBackupFile(text, fullPathDatless))
		{
			callback?.Invoke(result: false);
			yield break;
		}
		SaveFile saveFile = loadedFile;
		saveFile.mainData.dogToBreedA = null;
		saveFile.mainData.dogToBreedB = null;
		loadedPlayerData = saveFile.mainData;
		yield return SerializeSaveFileSafely(saveFile, text, fullPathDatless, callback, "ClearBreedingDogs()");
	}

	public IEnumerator SaveDogsForBreeding(SaveableDog dogA, SaveableDog dogB, SaveFinishedCallback callback)
	{
		if (loadedFile == null)
		{
			Debug.LogError("No active save file for: " + Application.persistentDataPath + activeSaveFileHolder.GetActiveSaveFile());
			callback?.Invoke(result: false);
			yield break;
		}
		string text = Application.persistentDataPath + activeSaveFileHolder.GetActiveSaveFile();
		string fullPathDatless = text.Replace(".dat", "");
		if (!CreateBackupFile(text, fullPathDatless))
		{
			callback?.Invoke(result: false);
			yield break;
		}
		SaveFile saveFile = loadedFile;
		saveFile.mainData.dogToBreedA = dogA.GetCopy();
		saveFile.mainData.dogToBreedB = dogB.GetCopy();
		loadedPlayerData = saveFile.mainData;
		yield return SerializeSaveFileSafely(saveFile, text, fullPathDatless, callback, "SaveDogsForBreeding()");
	}

	public SaveableDog GetDogA()
	{
		if (loadedFile == null || loadedFile.mainData == null || loadedFile.mainData.dogToBreedA == null)
		{
			Debug.LogError("No valid save file for: " + Application.persistentDataPath + activeSaveFileHolder.GetActiveSaveFile());
			return null;
		}
		return loadedFile.mainData.dogToBreedA;
	}

	public SaveableDog GetDogB()
	{
		if (loadedFile == null || loadedFile.mainData == null || loadedFile.mainData.dogToBreedB == null)
		{
			Debug.LogError("No valid save file for: " + Application.persistentDataPath + activeSaveFileHolder.GetActiveSaveFile());
			return null;
		}
		return loadedFile.mainData.dogToBreedB;
	}

	public IEnumerator SaveGameplaySettings(SaveFinishedCallback callback)
	{
		if (loadedFile == null)
		{
			Debug.LogError("No active save file for: " + Application.persistentDataPath + activeSaveFileHolder.GetActiveSaveFile());
			callback?.Invoke(result: false);
			yield break;
		}
		string text = Application.persistentDataPath + activeSaveFileHolder.GetActiveSaveFile();
		string fullPathDatless = text.Replace(".dat", "");
		if (!CreateBackupFile(text, fullPathDatless))
		{
			callback?.Invoke(result: false);
			yield break;
		}
		SaveFile saveFile = loadedFile;
		saveFile.mainData.cappedGenetics = GameSettings.AreGeneticsCapped();
		saveFile.mainData.dogDeathEnabled = GameSettings.IsDogDeathEnabled();
		saveFile.mainData.ghostAutoSpawnDisabled = !GameSettings.IsGhostAutoSpawnEnabled();
		saveFile.mainData.customAverageAdultDogLifespan = GameSettings.IsCustomAverageAdultDogLifespanSet();
		saveFile.mainData.customAverageAdultDogLifespanInMinutes = GameSettings.GetAverageAdultDogLifespanInMinutes();
		loadedPlayerData = saveFile.mainData;
		yield return SerializeSaveFileSafely(saveFile, text, fullPathDatless, callback, "SaveGameplaySettings()");
	}

	public IEnumerator ClearCameraFocus(SaveFinishedCallback callback)
	{
		yield return new WaitForEndOfFrame();
		if (loadedFile == null)
		{
			Debug.LogError("No active save file for: " + Application.persistentDataPath + activeSaveFileHolder.GetActiveSaveFile());
			callback?.Invoke(result: false);
			yield break;
		}
		string text = Application.persistentDataPath + activeSaveFileHolder.GetActiveSaveFile();
		string fullPathDatless = text.Replace(".dat", "");
		if (!CreateBackupFile(text, fullPathDatless))
		{
			callback?.Invoke(result: false);
			yield break;
		}
		SaveFile saveFile = loadedFile;
		if (saveFile.mainData.dogPenHome != null)
		{
			saveFile.mainData.dogPenHome.lastFocusedRoomUID = 0uL;
		}
		loadedPlayerData = saveFile.mainData;
		yield return SerializeSaveFileSafely(saveFile, text, fullPathDatless, callback, "ClearCameraFocus()");
	}

	private IEnumerator LoadControls(SaveFinishedCallback callback)
	{
		yield return new WaitForEndOfFrame();
		if (!File.Exists(Application.persistentDataPath + saveControlsFilename))
		{
			using (FileStream fileStream = File.Create(Application.persistentDataPath + saveControlsFilename))
			{
				SavedControlsFile graph = (loadedControls = new SavedControlsFile());
				new BinaryFormatter().Serialize(fileStream, graph);
				fileStream.Flush();
				fileStream.Close();
			}
			callback?.Invoke(result: false);
			yield break;
		}
		Exception e = null;
		bool success = false;
		WaitForSecondsRealtime fileWait = new WaitForSecondsRealtime(0.05f);
		for (int i = 0; i < numFileReadTries; i++)
		{
			try
			{
				using (FileStream fileStream2 = File.Open(Application.persistentDataPath + saveControlsFilename, FileMode.Open))
				{
					BinaryFormatter binaryFormatter = new BinaryFormatter();
					loadedControls = (SavedControlsFile)binaryFormatter.Deserialize(fileStream2);
					fileStream2.Flush();
					fileStream2.Close();
					success = true;
				}
				if (success)
				{
					break;
				}
			}
			catch (IOException ex)
			{
				e = ex;
				Debug.LogWarning("IO Exception during LoadControls(). Retrying.");
			}
			yield return fileWait;
		}
		if (!success)
		{
			Debug.LogError(e);
			Debug.LogError("Exception during LoadControls()");
			loadedControls = new SavedControlsFile();
		}
		callback?.Invoke(success);
	}

	private IEnumerator MakeBackupsIfNeeded()
	{
		string activeSaveFileName = activeSaveFileHolder.GetActiveSaveFile();
		if (backedUpFiles.Contains(activeSaveFileName))
		{
			yield break;
		}
		backedUpFiles.Add(activeSaveFileName);
		yield return new WaitForEndOfFrame();
		try
		{
			List<string> allBackupsForSaveFilePath = GetAllBackupsForSaveFilePath(activeSaveFileName);
			while (allBackupsForSaveFilePath.Count > 1)
			{
				string text = "";
				DateTime dateTime = DateTime.Now;
				for (int i = 0; i < allBackupsForSaveFilePath.Count; i++)
				{
					DateTime lastWriteTime = File.GetLastWriteTime(Application.persistentDataPath + allBackupsForSaveFilePath[i]);
					if (text.Length == 0 && lastWriteTime > DateTime.Now)
					{
						dateTime = lastWriteTime;
						text = allBackupsForSaveFilePath[i];
					}
					else if (lastWriteTime < dateTime)
					{
						dateTime = lastWriteTime;
						text = allBackupsForSaveFilePath[i];
					}
				}
				if (text.Length > 0)
				{
					allBackupsForSaveFilePath.Remove(text);
					File.Delete(Application.persistentDataPath + text);
				}
			}
			string text2 = backupFilePre + activeSaveFileName.Substring(1, activeSaveFileName.Length - fileTypeName.Length - 1) + "_0" + fileTypeName;
			if (allBackupsForSaveFilePath.Count > 0 && allBackupsForSaveFilePath[0][allBackupsForSaveFilePath[0].Length - fileTypeName.Length - 1] == '0')
			{
				text2 = backupFilePre + activeSaveFileName.Substring(1, activeSaveFileName.Length - fileTypeName.Length - 1) + "_1" + fileTypeName;
			}
			text2 = Application.persistentDataPath + text2;
			if (File.Exists(text2))
			{
				File.Delete(text2);
				Debug.LogError("Deleting a backup that shouldn't exist.");
			}
			File.Copy(Application.persistentDataPath + activeSaveFileName, text2);
			File.SetLastWriteTime(text2, DateTime.Now);
		}
		catch (Exception message)
		{
			Debug.LogError("Failed to make backups.");
			Debug.LogError(message);
		}
	}

	private IEnumerator LoadGame(SaveFinishedCallback callback, bool fromMainMenu = false)
	{
		yield return new WaitForEndOfFrame();
		TextAsset textAsset = null;
		if (CheatEngine.cheatRef != null)
		{
			textAsset = CheatEngine.cheatRef.debugSave;
		}
		if (textAsset == null && !File.Exists(Application.persistentDataPath + activeSaveFileHolder.GetActiveSaveFile()))
		{
			callback?.Invoke(result: false);
			yield break;
		}
		if (CheatEngine.cheatRef != null && CheatEngine.cheatRef.clearDataOnLoad)
		{
			callback?.Invoke(result: true);
			yield break;
		}
		if (textAsset == null)
		{
			if (!fromMainMenu)
			{
				yield return regRef.StartCoroutine(MakeBackupsIfNeeded());
			}
			Exception e = null;
			bool success = false;
			WaitForSecondsRealtime fileWait = new WaitForSecondsRealtime(0.05f);
			for (int i = 0; i < numFileReadTries; i++)
			{
				try
				{
					using (FileStream fileStream = File.Open(Application.persistentDataPath + activeSaveFileHolder.GetActiveSaveFile(), FileMode.Open))
					{
						BinaryFormatter binaryFormatter = new BinaryFormatter();
						loadedFile = (SaveFile)binaryFormatter.Deserialize(fileStream);
						fileStream.Flush();
						fileStream.Close();
						success = true;
					}
					if (success)
					{
						break;
					}
				}
				catch (IOException ex)
				{
					e = ex;
					Debug.LogWarning("IO Exception during LoadGame(). Retrying.");
				}
				catch (Exception ex2)
				{
					e = ex2;
					i = numFileReadTries;
					Debug.LogError(ex2);
				}
				yield return fileWait;
			}
			if (!success)
			{
				Debug.LogError(e);
				Debug.LogError("Exception during LoadGame()");
				callback?.Invoke(result: false);
				yield break;
			}
		}
		else
		{
			try
			{
				using (MemoryStream memoryStream = new MemoryStream(textAsset.bytes))
				{
					BinaryFormatter binaryFormatter2 = new BinaryFormatter();
					loadedFile = (SaveFile)binaryFormatter2.Deserialize(memoryStream);
					memoryStream.Flush();
					memoryStream.Close();
				}
				string text = "/HeyImTemporaryAndThereShouldOnlyBeOneOfMe.dat";
				File.Create(Application.persistentDataPath + text);
				SetActiveFile(text);
			}
			catch (Exception message)
			{
				Debug.LogError(message);
				Debug.LogError("Something went wrong while opening the save file.");
				callback?.Invoke(result: false);
				yield break;
			}
		}
		loadedPlayerData = loadedFile.mainData;
		callback?.Invoke(result: true);
	}

	public bool GetFileInfoForSaveFile(string filePath, ref string fileName, ref string numberOfDogs, ref string playTime)
	{
		try
		{
			using (FileStream fileStream = File.Open(Application.persistentDataPath + filePath, FileMode.Open))
			{
				SaveFile saveFile = (SaveFile)new BinaryFormatter().Deserialize(fileStream);
				fileStream.Flush();
				fileStream.Close();
				fileName = saveFile.fileName;
				if (saveFile.mainData.dateTime != null)
				{
					playTime = saveFile.mainData.dateTime.GetFormattedTime();
				}
				else
				{
					playTime = SaveableDateTime.GetFormattedTimeFromValues(0, 0);
				}
				if (saveFile.mainData.dogs != null)
				{
					numberOfDogs = saveFile.mainData.dogs.dogs.Count.ToString();
				}
				else
				{
					numberOfDogs = "0";
				}
			}
		}
		catch (Exception message)
		{
			Debug.LogError(message);
			Debug.LogError("Something went wrong while trying to grab save file info for: " + Application.persistentDataPath + filePath);
			fileName = "ERROR";
			numberOfDogs = "ERROR";
			playTime = "ERROR";
			return false;
		}
		return true;
	}

	public static List<string> GetAllSaveFilePaths()
	{
		List<string> list = new List<string>();
		DirectoryInfo directoryInfo = new DirectoryInfo(Application.persistentDataPath);
		string text = saveGameFilename + "*" + fileTypeName;
		text = text.Substring(1);
		FileInfo[] files = directoryInfo.GetFiles(text, SearchOption.TopDirectoryOnly);
		for (int i = 0; i < files.Length; i++)
		{
			list.Add("/" + files[i].Name);
		}
		return list;
	}

	public static List<string> GetAllBackupsForSaveFilePath(string existingFileName)
	{
		List<string> list = new List<string>();
		DirectoryInfo directoryInfo = new DirectoryInfo(Application.persistentDataPath);
		string text = backupFilePre + existingFileName.Substring(1, existingFileName.Length - fileTypeName.Length - 1) + "*" + fileTypeName;
		text = text.Substring(1);
		FileInfo[] files = directoryInfo.GetFiles(text, SearchOption.TopDirectoryOnly);
		for (int i = 0; i < files.Length; i++)
		{
			list.Add("/" + files[i].Name);
		}
		return list;
	}

	public static bool RestoreFileFromMostRecentValidBackup(string existingFileName)
	{
		List<string> allBackupsForSaveFilePath = GetAllBackupsForSaveFilePath(existingFileName);
		string text = "";
		string text2 = "";
		DateTime dateTime = DateTime.MinValue;
		for (int i = 0; i < allBackupsForSaveFilePath.Count; i++)
		{
			DateTime lastWriteTime = File.GetLastWriteTime(Application.persistentDataPath + allBackupsForSaveFilePath[i]);
			if (lastWriteTime > dateTime)
			{
				if (text2.Length > 0)
				{
					text = text2;
				}
				dateTime = lastWriteTime;
				text2 = allBackupsForSaveFilePath[i];
			}
			else if (text2.Length > 0)
			{
				text = allBackupsForSaveFilePath[i];
			}
		}
		if (text2.Length == 0)
		{
			return false;
		}
		try
		{
			File.Delete(Application.persistentDataPath + existingFileName);
			File.Copy(Application.persistentDataPath + text2, Application.persistentDataPath + existingFileName);
			if (!CanFileBeRead(Application.persistentDataPath + existingFileName))
			{
				if (text.Length <= 0)
				{
					Debug.LogError("Something went wrong while loading from newest backup. Unable to correctly copy over existing file.");
					return false;
				}
				File.Delete(Application.persistentDataPath + existingFileName);
				File.Copy(Application.persistentDataPath + text, Application.persistentDataPath + existingFileName);
				if (!CanFileBeRead(Application.persistentDataPath + existingFileName))
				{
					Debug.LogError("Something went wrong while loading from older backup. Unable to correctly copy over existing file.");
					return false;
				}
			}
		}
		catch (Exception message)
		{
			Debug.LogError(message);
			Debug.LogError("Something went wrong while loading from backup.");
			return false;
		}
		return true;
	}

	private static bool CanFileBeRead(string fullPath)
	{
		try
		{
			using (FileStream fileStream = File.Open(fullPath, FileMode.Open))
			{
				_ = (SaveFile)new BinaryFormatter().Deserialize(fileStream);
				fileStream.Flush();
				fileStream.Close();
			}
		}
		catch
		{
			return false;
		}
		return true;
	}

	public bool IsNewSave(string fileName)
	{
		PlayerData dataForFile = GetDataForFile(fileName);
		if (dataForFile == null || dataForFile.newSave)
		{
			return true;
		}
		return false;
	}

	public bool HasGeneratedPortraits()
	{
		try
		{
			if (loadedPlayerData != null)
			{
				if (loadedPlayerData.newSave || loadedPlayerData.hasGeneratedCorePortraits)
				{
					return true;
				}
			}
			else if (activeSaveFileHolder != null)
			{
				PlayerData dataForFile = GetDataForFile(activeSaveFileHolder.GetActiveSaveFile());
				if (dataForFile != null && (dataForFile.newSave || dataForFile.hasGeneratedCorePortraits))
				{
					return true;
				}
			}
		}
		catch (Exception message)
		{
			Debug.LogError(message);
			return true;
		}
		return false;
	}

	private PlayerData GetDataForFile(string fileName)
	{
		SaveFile saveFile = null;
		if (!File.Exists(Application.persistentDataPath + fileName))
		{
			return null;
		}
		try
		{
			using (FileStream fileStream = File.Open(Application.persistentDataPath + fileName, FileMode.Open))
			{
				saveFile = (SaveFile)new BinaryFormatter().Deserialize(fileStream);
				fileStream.Flush();
				fileStream.Close();
			}
		}
		catch (Exception message)
		{
			Debug.LogError(message);
			Debug.LogError("Something went wrong while trying to grab data for file: " + Application.persistentDataPath + fileName);
			return null;
		}
		return saveFile?.mainData;
	}

	public void LoadGameplaySettings()
	{
		gameplaySettingsLoaded = true;
		if (loadedPlayerData == null)
		{
			OnSingleDataLoaded();
			return;
		}
		GameSettings.SetCappedGenetics(loadedPlayerData.cappedGenetics);
		GameSettings.SetDogDeathEnabled(loadedPlayerData.dogDeathEnabled);
		GameSettings.SetGhostAutoSpawnEnabled(!loadedPlayerData.ghostAutoSpawnDisabled);
		if (loadedPlayerData.customAverageAdultDogLifespan)
		{
			GameSettings.SetAverageAdultDogLifespanInMinutes(loadedPlayerData.customAverageAdultDogLifespanInMinutes);
		}
		else
		{
			GameSettings.UseDefaultAdultDogLifespanInMinutes();
		}
		if (loadedPlayerData.passiveModeDataEverSaved)
		{
			GameSettings.SetPassiveModeEnabled(loadedPlayerData.passiveModeEnabled);
			GameSettings.SetPassiveModeAutoPupate(loadedPlayerData.passive_autoPupate);
			GameSettings.SetPassiveModeAutoHatch(loadedPlayerData.passive_autoHatch);
			GameSettings.SetPassiveModeAutoCleanPoop(loadedPlayerData.passive_autoCleanPoop);
			GameSettings.SetPassiveModeAutoClearHole(loadedPlayerData.passive_autoClearHole);
			GameSettings.SetPassiveModeAutoCleanPuddles(loadedPlayerData.passive_autoCleanPuddles);
			GameSettings.SetPassiveModeAutoCleanEmptyCocoons(loadedPlayerData.passive_autoCleanEmptyCocoons);
			GameSettings.SetPassiveModeAutoCleanHalfEatenFood(loadedPlayerData.passive_autoCleanHalfEatenFood);
			GameSettings.SetPassiveModeAutoCleanBabyTeeth(loadedPlayerData.passive_autoCleanBabyTeeth);
			GameSettings.SetPassiveModeAutoCleanDirt(loadedPlayerData.passive_autoCleanDirt);
			GameSettings.SetPassiveModeAutoCleanSnow(loadedPlayerData.passive_autoCleanSnow);
			GameSettings.SetPassiveModeAutoCollectSeeds(loadedPlayerData.passive_autoCollectSeeds);
			GameSettings.SetPassiveModeAutoCollectUpgrades(loadedPlayerData.passive_autoCollectUpgrades);
			GameSettings.SetPassiveModeAutoUnwrapGifts(loadedPlayerData.passive_autoUnwrapGifts);
			GameSettings.SetPassiveModeAutoCapsuleOpen(loadedPlayerData.passive_autoCapsuleOpen);
			GameSettings.SetPassiveModeAutoCollectCores(loadedPlayerData.passive_autoCollectCores);
			GameSettings.SetPassiveModeAutoEggCollection(loadedPlayerData.passive_autoEggCollection);
			GameSettings.SetPassiveModeAutoEggHatch(loadedPlayerData.passive_autoEggHatch);
			GameSettings.SetPassiveModeAutoHideGUI(loadedPlayerData.passive_autoHideGUI);
			GameSettings.SetPassiveModeAutoHideCursor(loadedPlayerData.passive_autoHideCursor);
			GameSettings.SetPassiveModeDeathNotificationOption(loadedPlayerData.passive_DeathNotifications);
			GameSettings.SetPassiveModeEggNotificationOption(loadedPlayerData.passive_EggNotifications);
			GameSettings.SetPassiveModeMutationNotificationOption(loadedPlayerData.passive_MutationNotifications);
			GameSettings.SetPassiveModeAutoBreedingOption(loadedPlayerData.passive_autoBreedingOption);
			GameSettings.SetPassiveModeAutoBreedingRelationshipRequirement(loadedPlayerData.passive_autoBreedingRelationshipRequirement);
			GameSettings.SetPassiveEggMutationRate(loadedPlayerData.passive_eggMutationRate);
			GameSettings.SetPassivePupationMutationRate(loadedPlayerData.passive_pupationMutationRate);
			GameSettings.SetPassiveFloraMutationEffects(loadedPlayerData.passive_floraMutationEffects);
			GameSettings.SetPassiveModeRandomPenFocus(loadedPlayerData.passive_cam_randomPenFocus);
			GameSettings.SetPassiveModeRandomDogFocus(loadedPlayerData.passive_cam_randomDogFocus);
			GameSettings.SetPassiveModeRandomPenFocusRotation(loadedPlayerData.passive_cam_randomPenFocusRotation);
			GameSettings.SetPassiveModeFocusOnDyingDogs(loadedPlayerData.passive_cam_focusOnDyingDogs);
			GameSettings.SetPassiveModeFocusOnHatchingCocoons(loadedPlayerData.passive_cam_focusOnHatchingCocoons);
			GameSettings.SetPassiveModeFocusOnHatchingEggs(loadedPlayerData.passive_cam_focusOnHatchingEggs);
			GameSettings.SetPassiveModeDeathByStarvation(loadedPlayerData.passive_deathByStarvation);
		}
		else
		{
			GameSettings.RestoreDefaultPassiveModeSettings();
		}
		OnSingleDataLoaded();
	}

	public void LoadGameMode()
	{
		gameModeLoaded = true;
		if (loadedPlayerData == null)
		{
			OnSingleDataLoaded();
			return;
		}
		regRef.GetGlobalComponent<SceneManagerBase>(GlobalObject.SCENE_MANAGER).SetGameMode();
		OnSingleDataLoaded();
	}

	public void LoadBuildables()
	{
		DenInteriorManager.ClearRefs();
		buildablesLoaded = true;
		if (loadedPlayerData == null)
		{
			OnSingleDataLoaded();
			return;
		}
		GameMode gameMode = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<SceneManagerBase>(GlobalObject.SCENE_MANAGER).GetGameMode();
		SaveableDogHome savedHome = null;
		switch (gameMode)
		{
		case GameMode.HOME:
			savedHome = loadedPlayerData.dogPenHome;
			break;
		case GameMode.BREEDING:
			savedHome = loadedPlayerData.dogPenBreedingCenter;
			break;
		}
		regRef.GetGlobalComponent<DogHome>(GlobalObject.DOG_HOME).LoadDogHome(savedHome);
		OnSingleDataLoaded();
	}

	public void LoadResearch()
	{
		researchLoaded = true;
		if (loadedPlayerData == null)
		{
			regRef.GetGlobalComponent<ResearchManager>(GlobalObject.RESEARCH_MANAGER).LoadSavedResearch(null);
			OnSingleDataLoaded();
		}
		else
		{
			regRef.GetGlobalComponent<ResearchManager>(GlobalObject.RESEARCH_MANAGER).LoadSavedResearch(loadedPlayerData.research);
			OnSingleDataLoaded();
		}
	}

	public void LoadFloraUnlocks()
	{
		floraUnlocksLoaded = true;
		if (loadedPlayerData == null)
		{
			regRef.GetGlobalComponent<FloraManager>(GlobalObject.FLORA_MANAGER).LoadSavedFloraUnlocks(null);
			OnSingleDataLoaded();
		}
		else
		{
			regRef.GetGlobalComponent<FloraManager>(GlobalObject.FLORA_MANAGER).LoadSavedFloraUnlocks(loadedPlayerData.floraUnlocks);
			OnSingleDataLoaded();
		}
	}

	public void LoadGhostManager()
	{
		ghostManagerLoaded = true;
		_ = loadedPlayerData;
		regRef.GetGlobalComponent<GhostManager>(GlobalObject.GHOST_MANAGER).LoadSavedGhostManager();
		OnSingleDataLoaded();
	}

	public void LoadInventory()
	{
		inventoryLoaded = true;
		if (loadedPlayerData == null)
		{
			regRef.GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER).LoadInventory(null);
			OnSingleDataLoaded();
		}
		else
		{
			regRef.GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER).LoadInventory(loadedPlayerData.inventory);
			OnSingleDataLoaded();
		}
	}

	public void LoadDateTime()
	{
		dateTimeLoaded = true;
		if (loadedPlayerData == null)
		{
			OnSingleDataLoaded();
			return;
		}
		regRef.GetGlobalComponent<GlobalClock>(GlobalObject.GLOBAL_CLOCK).LoadSavedDateTime(loadedPlayerData.dateTime);
		OnSingleDataLoaded();
	}

	public void LoadWorldObjects()
	{
		worldObjectsLoaded = true;
		if (loadedPlayerData == null)
		{
			OnSingleDataLoaded();
			return;
		}
		GameMode gameMode = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<SceneManagerBase>(GlobalObject.SCENE_MANAGER).GetGameMode();
		SaveableTaggedObjects objs = null;
		if (gameMode == GameMode.HOME)
		{
			objs = loadedPlayerData.worldTaggedObjectsHome;
		}
		regRef.LoadIDCounter(loadedPlayerData);
		regRef.LoadTaggedObjects(objs);
		OnSingleDataLoaded();
	}

	public void LoadCocoons()
	{
		cocoonsLoaded = true;
		if (loadedPlayerData == null)
		{
			OnSingleDataLoaded();
			return;
		}
		GameMode gameMode = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<SceneManagerBase>(GlobalObject.SCENE_MANAGER).GetGameMode();
		SaveableTaggedObjects objs = null;
		if (gameMode == GameMode.HOME)
		{
			objs = loadedPlayerData.worldTaggedObjectsHome;
		}
		regRef.LoadCocoons(objs);
		OnSingleDataLoaded();
	}

	public void LoadDogs()
	{
		if (loadedPlayerData == null)
		{
			regRef.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION).LoadSavedDogs(null);
			dogsLoaded = true;
			OnSingleDataLoaded();
		}
		else
		{
			bool spawnDogs = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<SceneManagerBase>(GlobalObject.SCENE_MANAGER).GetGameMode() == GameMode.HOME;
			regRef.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION).LoadSavedDogs(loadedPlayerData, spawnDogs);
			dogsLoaded = true;
			OnSingleDataLoaded();
		}
	}

	public void LoadDogDens()
	{
		if (loadedPlayerData == null)
		{
			dogDensLoaded = true;
			OnSingleDataLoaded();
			return;
		}
		if (ObjectRegistration.GetRegistrationScript().GetGlobalComponent<SceneManagerBase>(GlobalObject.SCENE_MANAGER).GetGameMode() == GameMode.HOME)
		{
			DogDenManager.LoadSavedDogDenManager(loadedPlayerData.dogDenManager);
		}
		dogDensLoaded = true;
		OnSingleDataLoaded();
	}

	public void LoadTutorial()
	{
		tutorialLoaded = true;
		if (loadedPlayerData == null)
		{
			TutorialController.ResetTutorial();
			TutorialController.SetCurrentState(TutorialState.WELCOME_CONVO);
			TutorialController.SetInitialEggCollected(status: false);
			OnSingleDataLoaded();
		}
		else
		{
			TutorialController.ResetTutorial();
			TutorialController.SetCurrentState(loadedPlayerData.tutorialState);
			TutorialController.SetInitialEggCollected(loadedPlayerData.initialEggCollected);
			OnSingleDataLoaded();
		}
	}

	public void InitializeLoadedControls()
	{
		if (!hasInitializedControls)
		{
			regRef.StartCoroutine(LoadControls(ControlsLoadedCallback));
		}
	}

	private void ControlsLoadedCallback(bool result)
	{
		hasInitializedControls = true;
		regRef.GetGlobalComponent<ControlManager>(GlobalObject.CONTROL_MANAGER).Initialize();
	}

	public void LoadConstruction()
	{
		constructionLoaded = true;
		if (loadedPlayerData == null)
		{
			OnSingleDataLoaded();
			return;
		}
		GameMode gameMode = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<SceneManagerBase>(GlobalObject.SCENE_MANAGER).GetGameMode();
		ConstructionManager globalComponent = regRef.GetGlobalComponent<ConstructionManager>(GlobalObject.CONSTRUCTION_MANAGER, nullAllowed: true);
		if (globalComponent != null)
		{
			globalComponent.InitializeConstructionManager();
		}
		else if (gameMode != GameMode.TITLE)
		{
			Debug.LogError("No ConstructionManager found while in Game Mode: " + gameMode);
		}
		OnSingleDataLoaded();
	}

	public void LoadGoals()
	{
		GoalsController.Initialize();
		goalsLoaded = true;
		if (loadedPlayerData == null)
		{
			OnSingleDataLoaded();
			return;
		}
		GoalsController.LoadSaveableGoals(loadedPlayerData.goals);
		OnSingleDataLoaded();
	}

	public void LoadNonDependentData(bool loadPenData)
	{
		LoadGameplaySettings();
		LoadGoals();
		LoadGameMode();
		LoadTutorial();
		LoadDateTime();
		LoadResearch();
		LoadInventory();
		LoadFloraUnlocks();
		LoadGhostManager();
		LoadConstruction();
		if (loadPenData)
		{
			LoadWorldObjects();
		}
		nonDependantDataLoaded = true;
		OnSingleDataLoaded();
	}

	private void OnSingleDataLoaded()
	{
		if (dogsLoaded && cocoonsLoaded && tutorialLoaded && dateTimeLoaded && inventoryLoaded && buildablesLoaded && worldObjectsLoaded && nonDependantDataLoaded && gameModeLoaded && researchLoaded && floraUnlocksLoaded && dogDensLoaded && gameplaySettingsLoaded && goalsLoaded && ghostManagerLoaded && constructionLoaded)
		{
			OnAllDataLoaded();
		}
	}

	private void OnAllDataLoaded()
	{
		TutorialController.RunCurrentState();
	}
}
