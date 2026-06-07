using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using DV;
using DV.CashRegister;
using DV.Common;
using DV.Customization;
using DV.InventorySystem;
using DV.LocoRestoration;
using DV.Mods;
using DV.OriginShift;
using DV.Scenarios.Common;
using DV.ServicePenalty;
using DV.UserManagement;
using DV.UserManagement.Data;
using DV.UserManagement.Storage;
using DV.Utils;
using DV.WeatherSystem;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class SaveGameManager : SingletonBehaviour<SaveGameManager>
{
	public static int CHUNK_HAZMAT = 10;

	public static int CHUNK_DIFFICULTY = 11;

	public const string WORLD1 = "World1";

	public const string CAREER = "Career";

	public const string FREE_ROAM = "FreeRoam";

	public static readonly SaveType[] SaveTypes = (SaveType[])Enum.GetValues(typeof(SaveType));

	private const string SUPER_SECRET = "WeDidntSecureThisVeryWell!!1";

	private const int SCREENSHOT_WIDTH = 512;

	private const int SCREENSHOT_HEIGHT = 288;

	public SaveGameData data;

	public bool disableAutosave = true;

	public const int CURRENT_SAVEGAME_VERSION = 8;

	private RenderTexture screenshotTarget;

	private Texture2D screenshotTexture;

	private Material screenshotBlitMaterial;

	private const string SCREENSHOT_BLIT_SHADER = "Hidden/BlitCopyFullAlpha";

	private const int SAVED_PROGRESS_GRACE_FRAMES = 5;

	private int savedProgressGrace = 5;

	private double startingMoney;

	private bool savedOnQuit;

	private bool isQuitting;

	private static string CurrentGameVersion => BuildInfo.BUILD_VERSION_STR + " - " + BuildInfo.BUILD_DESTINATION;

	public IDifficulty Difficulty { get; private set; }

	public bool HasUnsavedProgress => savedProgressGrace <= 0;

	public bool IsNewSession { get; private set; }

	public bool HasStashedScreenshot => screenshotTarget != null;

	private bool IsPhotoModeEnabled
	{
		get
		{
			if (SingletonBehaviour<PlayerCameraSwitcher>.Instance != null && SingletonBehaviour<PlayerCameraSwitcher>.Instance.externalCamera != null)
			{
				return SingletonBehaviour<PlayerCameraSwitcher>.Instance.externalCamera.PhotoMode;
			}
			return false;
		}
	}

	public event Action<SaveGameData> OnInternalDataUpdate;

	public static event Action<SaveType> AboutToSave;

	public new static string AllowAutoCreate()
	{
		return "[SaveGameManager]";
	}

	private void Start()
	{
		screenshotBlitMaterial = new Material(Shader.Find("Hidden/BlitCopyFullAlpha"));
		StartCoroutine(AutoSaveCoro());
		SetupUnityListeners(on: true);
		SetupListeners(on: true);
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		SetupUnityListeners(on: false);
		if (!UnloadWatcher.isUnloading)
		{
			SetupListeners(on: false);
		}
	}

	private void SetupListeners(bool on)
	{
		if (on)
		{
			SingletonBehaviour<AppUtil>.Instance.GamePauseRequested += OnGamePausing;
			SingletonBehaviour<AppUtil>.Instance.AfterGameUnpaused += OnGameResuming;
		}
		else
		{
			SingletonBehaviour<AppUtil>.Instance.GamePauseRequested -= OnGamePausing;
			SingletonBehaviour<AppUtil>.Instance.AfterGameUnpaused -= OnGameResuming;
		}
	}

	private void SetupUnityListeners(bool on)
	{
		if (on)
		{
			Application.wantsToQuit += OnApplicationWantsToQuit;
			Application.focusChanged += OnApplicationFocusChanged;
			Application.quitting += OnApplicationQuitting;
		}
		else
		{
			Application.wantsToQuit -= OnApplicationWantsToQuit;
			Application.focusChanged -= OnApplicationFocusChanged;
			Application.quitting -= OnApplicationQuitting;
		}
	}

	private void OnApplicationQuitting()
	{
		isQuitting = true;
	}

	private void OnApplicationFocusChanged(bool focus)
	{
		if (!focus && !savedOnQuit && !isQuitting && Globals.G.GameParams.SingleSaveMode && HasUnsavedProgress)
		{
			Save(SaveType.Auto);
		}
	}

	private bool OnApplicationWantsToQuit()
	{
		if (!savedOnQuit && Globals.G.GameParams.SingleSaveMode && HasUnsavedProgress)
		{
			Save(SaveType.Auto);
			savedOnQuit = true;
			StartCoroutine(ExitOnNextFrame());
			return false;
		}
		return true;
	}

	private IEnumerator ExitOnNextFrame()
	{
		yield return null;
		Application.Quit();
	}

	private void Update()
	{
		if (!SingletonBehaviour<AppUtil>.Instance.IsTimePaused && !IsPhotoModeEnabled && !UnloadWatcher.isUnloading && savedProgressGrace > 0)
		{
			savedProgressGrace--;
		}
	}

	private void OnGamePausing()
	{
		StashScreenshot();
		if (Globals.G.GameParams.SingleSaveMode)
		{
			Save(SaveType.Auto);
		}
	}

	private void OnGameResuming()
	{
		ClearStashedScreenshot();
	}

	public bool SaveAllowed()
	{
		if (data == null)
		{
			return false;
		}
		bool? flag = data.GetBool("Tutorial_01_completed");
		if (flag.HasValue && flag == true && PlayerManager.PlayerTransform != null && SingletonBehaviour<Inventory>.Instance != null)
		{
			return WorldStreamingInit.IsLoaded;
		}
		return false;
	}

	private IEnumerator AutoSaveCoro()
	{
		while (true)
		{
			yield return WaitFor.Seconds(GamePreferences.Get<int>(Preferences.AutosaveInterval) * 60);
			if (HasUnsavedProgress && !savedOnQuit && !UnloadWatcher.isUnloading && !IsPhotoModeEnabled)
			{
				AutoSave();
			}
		}
	}

	private void AutoSave()
	{
		if (!disableAutosave)
		{
			Debug.Log("Autosaving");
			Save(SaveType.Auto);
		}
	}

	public ISaveGame Save(SaveType type, ISaveGame saveToOverwrite = null, bool updateInternalData = true)
	{
		if (!SaveAllowed())
		{
			Debug.Log("Save requested but conditions weren't met, not saving");
			return null;
		}
		if (updateInternalData)
		{
			UpdateInternalData();
		}
		try
		{
			SaveGameManager.AboutToSave?.Invoke(type);
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
		return DoSaveIO(data, type, saveToOverwrite);
	}

	public void SaveCurrentDataEncrypted(string path)
	{
		UpdateInternalData();
		SaveGameData.SaveToFile(data, path, "WeDidntSecureThisVeryWell!!1");
	}

	private void UpdateInternalData()
	{
		data.SetInt("Version", 8);
		data.SetString("Game_version_latest", CurrentGameVersion);
		data.SetVector3("Player_position", PlayerManager.PlayerTransform.AbsolutePosition());
		data.SetVector3("Player_rotation", PlayerManager.PlayerTransform.rotation.eulerAngles);
		data.SetString("Player_car_guid", (PlayerManager.Car == null) ? string.Empty : PlayerManager.Car.CarGUID);
		float num = (float)SingletonBehaviour<Inventory>.Instance.PlayerMoney;
		foreach (CashRegisterBase allCashRegister in CashRegisterBase.allCashRegisters)
		{
			num += (float)allCashRegister.DepositedCash;
		}
		data.SetFloat("Player_money", num);
		SingletonBehaviour<LicenseManager>.Instance.SaveData(data);
		SingletonBehaviour<StorageController>.Instance.StorageInventory.SaveStorage(data);
		SingletonBehaviour<StorageController>.Instance.StorageWorld.SaveStorage(data);
		SingletonBehaviour<StorageController>.Instance.StorageLostAndFound.SaveStorage(data);
		SingletonBehaviour<StorageController>.Instance.StorageInstalledGadgets.SaveStorage(data);
		SingletonBehaviour<StorageController>.Instance.StorageItemContainers.SaveStorage(data);
		data.SetJObject("Turntables", TurntableController.GetSaveData());
		data.SetJObject(SaveGameKeys.Junctions, JunctionsSaveManager.GetJunctionsSaveData());
		data.SetJObject(SaveGameKeys.Cars, CarsSaveManager.GetCarsSaveData());
		data.SetJObject("Unique_cars", SingletonBehaviour<CarSpawner>.Instance.GetDeletedUniqueCarData());
		data.SetJObject("Restoration_Locos", LocoRestorationController.GetSaveData());
		data.SetJObject("Customizers", SingletonCustomization<WorldCustomization>.I.Serialize());
		data.SetBool("Caboose_In_Range", CabooseController.PlayerCloseToAnyCaboose());
		data.SetObject(SaveGameKeys.Jobs, SingletonBehaviour<JobSaveManager>.Instance.GetJobsSaveGameData(), JobSaveManager.serializeSettings);
		data.SetString("Last_Tracks_Hash", SingletonBehaviour<RailTrackRegistryBase>.Instance.TracksHash);
		data.SetJObjectArray("Debt_existing_locos", SingletonBehaviour<LocoDebtController>.Instance.GetExistingLocosDebtsSaveData());
		data.SetJObjectArray("Debt_deleted_locos", SingletonBehaviour<LocoDebtController>.Instance.GetDestroyedLocosDebtsSaveData());
		data.SetJObjectArray("Debt_existing_jobs", SingletonBehaviour<JobDebtController>.Instance.GetExistingJobsDebtsSaveData());
		data.SetJObjectArray("Debt_staged_jobs", SingletonBehaviour<JobDebtController>.Instance.GetStagedJobsDebtsSaveData());
		data.SetJObject("Debt_existing_jobless_cars", SingletonBehaviour<JobDebtController>.Instance.GetExistingJoblessCarsDebtsSaveData());
		data.SetJObject("Debt_deleted_jobless_cars", SingletonBehaviour<JobDebtController>.Instance.GetDeletedJoblessCarDebtsSaveData());
		data.SetJObject("Debt_insurance", SingletonBehaviour<CareerManagerDebtController>.Instance.feeQuota.GetSaveData());
		data.SetJObjectArray("Debt_deleted_owned_cars", SingletonBehaviour<OwnedCarsStateController>.Instance.GetDestroyedOwnedCarsSaveData());
		SingletonBehaviour<CareerManagerDebtController>.Instance.RefreshExistingDebtsState();
		data.SetFloat("Debt_total", SingletonBehaviour<CareerManagerDebtController>.Instance.GetAllDebtsPrice());
		data.SetJObject("Time_and_date", SingletonBehaviour<WeatherDriver>.Instance.GetSaveData(Globals.G.GameParams.WeatherEditorAlwaysAllowed));
		SingletonBehaviour<BedSleepingController>.Instance.SaveTo(data);
		if ((bool)SingletonBehaviour<HazmatTileManager>.Instance)
		{
			byte[] chunkData = SingletonBehaviour<HazmatTileManager>.Instance.Serialize();
			data.SetCustomChunkData(CHUNK_HAZMAT, chunkData);
		}
		if (Difficulty != null)
		{
			JObject jObject = new JObject();
			DifficultyDataUtils.SetDifficultyToJSON(jObject, Difficulty);
			byte[] bytes = UserManager.ENCODING.GetBytes(jObject.ToString(Formatting.None));
			data.SetCustomChunkData(CHUNK_DIFFICULTY, bytes);
		}
		if (this.OnInternalDataUpdate == null)
		{
			return;
		}
		Delegate[] invocationList = this.OnInternalDataUpdate.GetInvocationList();
		foreach (Delegate obj in invocationList)
		{
			try
			{
				obj.DynamicInvoke(data);
			}
			catch (Exception ex)
			{
				Debug.LogError("Error invoking OnInternalDataUpdate handler: " + ex.Message);
				Debug.LogException(ex);
			}
		}
	}

	public static bool MakeSaveBackup(ISaveGame saveGame, string namePrefix)
	{
		try
		{
			IStorageProvider storage = (saveGame as SaveGameSnapshot).ParentManager.Storage;
			List<string> files = saveGame.GetFiles(new List<string>());
			string directoryName = storage.GetDirectoryName(files[0]);
			for (int i = 0; i < files.Count; i++)
			{
				storage.CopyFile(files[i], Path.Combine(directoryName, namePrefix + i + ".bak"));
			}
			return true;
		}
		catch (Exception ex)
		{
			Debug.LogError("Making backup failed: " + ex.Message);
			Debug.LogException(ex);
			return false;
		}
	}

	private ISaveGame DoSaveIO(SaveGameData data, SaveType type, ISaveGame saveToOverwrite)
	{
		if (!IsGameOrDevScene())
		{
			return null;
		}
		try
		{
			string text = data.GetString("Game_mode");
			if (string.IsNullOrEmpty(text))
			{
				text = "Career";
			}
			string text2 = data.GetString("World");
			if (string.IsNullOrEmpty(text2))
			{
				text2 = "World1";
			}
			User currentUser = SingletonBehaviour<UserManager>.Instance.CurrentUser;
			if (currentUser.CurrentSession == null)
			{
				if (currentUser.Sessions[text].Count > 0)
				{
					currentUser.SelectSession(currentUser.Sessions[text][0]);
				}
				else
				{
					currentUser.StartSession(text, text2);
				}
			}
			ISaveGame latestSave = currentUser.CurrentSession.LatestSave;
			bool flag = false;
			double? num = data.GetDouble("Player_money");
			if (num.HasValue)
			{
				if (startingMoney > 0.0 && num.Value <= 0.0)
				{
					Debug.LogWarning("Money went from non-zero to zero in this play session!");
					if (latestSave != null)
					{
						flag = true;
						MakeSaveBackup(latestSave, "zeroMoney_before_");
					}
					try
					{
						string directoryName = Path.GetDirectoryName(SingletonBehaviour<UserManager>.Instance.Storage.GetFilesystemPath(currentUser.CurrentSession.LatestSave.BasePath));
						string text3 = Path.Combine(Application.persistentDataPath, "Player.log");
						if (File.Exists(text3))
						{
							File.Copy(text3, Path.Combine(directoryName, "zeroMoney_log.log"), overwrite: true);
						}
						text3 = Path.Combine(Application.persistentDataPath, "Player-prev.log");
						if (File.Exists(text3))
						{
							File.Copy(text3, Path.Combine(directoryName, "zeroMoney_log_prev.log"), overwrite: true);
						}
					}
					catch (Exception ex)
					{
						Debug.LogError("Failed to make a backup copy of Player.log: " + ex.Message);
						Debug.LogException(ex);
					}
				}
				startingMoney = num.Value;
			}
			else
			{
				Debug.LogError("Saving save with no money value, this shouldn't happen!");
			}
			ISaveGame saveGame = currentUser.CurrentSession.SaveGame(type, data.GetJsonObject(), GetThumbnail(), data.CustomChunks, saveToOverwrite);
			currentUser.CurrentSession.Save();
			if (flag)
			{
				MakeSaveBackup(saveGame, "zeroMoney_after_");
			}
			if (Globals.G.GameParams.SingleSaveMode && saveToOverwrite == null && latestSave != null)
			{
				List<string> files = latestSave.GetFiles(null);
				for (int i = 0; i < files.Count; i++)
				{
					string filesystemPath = SingletonBehaviour<UserManager>.Instance.Storage.GetFilesystemPath(files[i]);
					string destFileName = Path.GetDirectoryName(filesystemPath) + Path.DirectorySeparatorChar.ToString() + "previous_" + i + ".bak";
					try
					{
						File.Copy(filesystemPath, destFileName, overwrite: true);
					}
					catch (Exception ex2)
					{
						Debug.LogError("Error backing up previous save file '" + filesystemPath + "': " + ex2.Message);
						Debug.LogException(ex2);
					}
				}
				latestSave.ParentSession.DeleteSaveGame(latestSave);
			}
			savedProgressGrace = 5;
			Debug.Log(string.Format("Wrote save game to {0} (type {1}, {2}, session {3})", saveGame.GetFiles(new List<string>())[0], type, (saveToOverwrite != null) ? "overwrite" : "new save", saveGame.ParentSession.Name));
			return saveGame;
		}
		catch (Exception exception)
		{
			Debug.LogWarning("Savegame writing failed due to the following error");
			Debug.LogException(exception);
			return null;
		}
	}

	public void StashScreenshot()
	{
		CaptureScreenshot(withUI: false);
	}

	public void ClearStashedScreenshot()
	{
		if ((bool)screenshotTarget)
		{
			RenderTexture.ReleaseTemporary(screenshotTarget);
		}
		screenshotTarget = null;
		screenshotTexture = null;
	}

	private void CaptureScreenshot(bool withUI)
	{
		RenderTexture temporary = RenderTexture.GetTemporary(Screen.width, Screen.height, 24, RenderTextureFormat.ARGB32);
		if (screenshotTarget != null && (screenshotTarget.width != Screen.width || screenshotTarget.height != Screen.height))
		{
			RenderTexture.ReleaseTemporary(screenshotTarget);
			screenshotTarget = null;
		}
		if (screenshotTarget == null)
		{
			screenshotTarget = RenderTexture.GetTemporary(Screen.width, Screen.height, 24, RenderTextureFormat.ARGB32);
		}
		if (withUI)
		{
			ScreenCapture.CaptureScreenshotIntoRenderTexture(temporary);
		}
		else
		{
			ScreenshotTaker.TakeScreenshotWithoutUI(temporary);
		}
		Graphics.Blit(temporary, screenshotTarget, screenshotBlitMaterial);
		RenderTexture.ReleaseTemporary(temporary);
	}

	private Texture2D GetThumbnail()
	{
		bool flag = false;
		if (!HasStashedScreenshot)
		{
			flag = true;
			CaptureScreenshot(withUI: true);
		}
		RenderTexture temporary = RenderTexture.GetTemporary(512, 288, 0, RenderTextureFormat.ARGB32);
		float num = (float)screenshotTarget.width / (float)screenshotTarget.height;
		float num2 = (float)temporary.width / (float)temporary.height;
		float num3 = ((num > num2) ? (num2 / num) : 1f);
		float num4 = ((num > num2) ? 1f : (num / num2));
		float x = (1f - num3) * 0.5f;
		float num5 = (1f - num4) * 0.5f;
		if (SystemInfo.graphicsUVStartsAtTop && flag)
		{
			num4 *= -1f;
			num5 -= num4;
		}
		Graphics.Blit(screenshotTarget, temporary, new Vector2(num3, num4), new Vector2(x, num5));
		if (!screenshotTexture)
		{
			screenshotTexture = new Texture2D(temporary.width, temporary.height, TextureFormat.RGB24, mipChain: false);
		}
		RenderTexture active = RenderTexture.active;
		RenderTexture.active = temporary;
		screenshotTexture.ReadPixels(new Rect(0f, 0f, temporary.width, temporary.height), 0, 0);
		screenshotTexture.Apply();
		RenderTexture.active = active;
		RenderTexture.ReleaseTemporary(temporary);
		if (flag)
		{
			RenderTexture.ReleaseTemporary(screenshotTarget);
			screenshotTarget = null;
		}
		return screenshotTexture;
	}

	public RenderTexture GetFullStashedScreenshot()
	{
		if (!HasStashedScreenshot)
		{
			return null;
		}
		return screenshotTarget;
	}

	public static SaveGameData MakeEmptySave()
	{
		SaveGameData saveGameData = new SaveGameData();
		saveGameData.SetInt("Version", 8);
		saveGameData.SetInt("Version_initial", 8);
		saveGameData.SetString("Game_version_initial", CurrentGameVersion);
		saveGameData.SetString("Game_version_latest", CurrentGameVersion);
		return saveGameData;
	}

	public AStartGameData FindStartGameData()
	{
		if (!IsGameOrDevScene())
		{
			Debug.LogError("Current scene is not a game scene or a dev scene, FindStartGameData should not be called. Aborting", this);
			return null;
		}
		AStartGameData aStartGameData;
		try
		{
			aStartGameData = UnityEngine.Object.FindObjectOfType<AStartGameData>();
			if (aStartGameData == null)
			{
				Debug.Log("SaveGameManager couldn't find AStartGameData (probably skipped main menu), will try to find current session");
				User user = ((SingletonBehaviour<UserManager>.Instance != null) ? SingletonBehaviour<UserManager>.Instance.CurrentUser : null);
				ISaveGame saveGame = user?.CurrentSession?.LatestSave;
				if (saveGame == null)
				{
					if (user == null)
					{
						Debug.Log("SaveGameManager couldn't find current user");
					}
					else if (user.CurrentSession == null)
					{
						Debug.Log("SaveGameManager user '" + user.Name + "' doesn't have a current session, trying to find any session for game mode 'Career'");
						if (user.Sessions.TryGetValue("Career", out var value) && value.Count > 0)
						{
							IGameSession gameSession = value[0];
							Debug.Log(string.Format("{0} found session '{1}'", "SaveGameManager", gameSession));
							user.SelectSession(gameSession);
							saveGame = gameSession.LatestSave;
						}
						else
						{
							Debug.Log("SaveGameManager found no sessions");
						}
					}
				}
				if (saveGame == null)
				{
					Debug.Log("SaveGameManager found no session, starting new career session");
					aStartGameData = AStartGameData.FallbackNewCareer();
				}
				else
				{
					Debug.Log("SaveGameManager will load snapshot from found session");
					aStartGameData = AStartGameData.Continue(saveGame, useSessionDifficulty: true);
				}
			}
			else
			{
				Debug.Log("SaveGameManager found " + aStartGameData.GetType().Name);
				Difficulty = aStartGameData.DifficultyToUse;
			}
		}
		catch (Exception exception)
		{
			Debug.LogWarning("SaveGameManager savegame loading failed due to the following error");
			Debug.LogException(exception);
			Debug.Log("SaveGameManager creating empty save game");
			aStartGameData = AStartGameData.StartEmptySave();
		}
		data = aStartGameData.GetSaveGameData();
		IsNewSession = aStartGameData.IsStartingNewSession;
		double? num = data.GetDouble("Player_money");
		startingMoney = (num.HasValue ? num.Value : (-1.0));
		if (!num.HasValue)
		{
			Debug.LogError("Loading save with no money value, this shouldn't happen!");
		}
		ModManagerInfo.UpdateSaveGameData(data);
		return aStartGameData;
	}

	private bool IsGameOrDevScene()
	{
		return true;
	}
}
