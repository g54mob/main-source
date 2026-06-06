using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class GameManager : MonoSingleton<GameManager>
{
	[SerializeField]
	private Player _player;

	[SerializeField]
	private CameraController _cameraController;

	[SerializeField]
	private AnimalPrefabController _animalPrefabController;

	[SerializeField]
	private UIManager _uiManager;

	[SerializeField]
	private LoadingScreen _loadingScreen;

	[SerializeField]
	private MicGuideScreen _micGuideScreen;

	private bool _loadCompleted;

	private bool _isSaving;

	[SerializeField]
	private AreaManager _areaManager;

	public CameraController CameraController => _cameraController;

	protected override async void Awake()
	{
		base.Awake();
		Application.runInBackground = true;
		QualitySettings.vSyncCount = 1;
		Application.targetFrameRate = -1;
		_micGuideScreen.Show();
		MonoSingleton<AnimalPickController>.Instance.Init();
		MonoSingleton<CampManager>.Instance.Init();
		MonoSingleton<SoundManager>.Instance.Init();
		DataManager.Instance.Init();
		AnimalManager.Instance.Init();
		_cameraController.Init(_player);
		_animalPrefabController.Init();
		_uiManager.Init();
		MonoSingleton<SoundManager>.Instance.MuteBGM(mute: true);
		MonoSingleton<SoundManager>.Instance.MuteSFX(mute: true);
		_player.MoveLock();
		Wallet.Instance.OnGoldChanged += _uiManager.WalletView.UpdateGoldText;
		Wallet.Instance.OnGoldChanged += _uiManager.CollectionView.DetailPanel.UpdateDetailPanel;
		Wallet.Instance.OnGoldChanged += _uiManager.AreaShopUI.UpdateUI;
		Wallet.Instance.OnGoldChanged += _uiManager.CampShopUI.UpdateCampCells;
		AnimalManager.Instance.OnAddIncomePerSecond += _uiManager.WalletView.PlayIncomeFX;
		AnimalManager.Instance.OnCollectAnimal += _animalPrefabController.SpawnAnimalPrefab;
		AnimalManager.Instance.OnCollectAnimal += _uiManager.CollectionView.CellsPanel.UpdateCellByCollectAnimal;
		AnimalManager.Instance.OnCollectAnimal += _uiManager.CollectionView.DetailPanel.UpdateDetailPanel;
		AnimalManager.Instance.OnProcessStartAdoptEdit += _animalPrefabController.PreviewCameraFocus_ToAnimalSpawnPos;
		AnimalManager.Instance.OnProcessStartAdoptEdit += _animalPrefabController.SetMute_AllAnimalPrefabs;
		AnimalManager.Instance.OnProcessStartAdoptEdit += _player.MoveLock;
		AnimalManager.Instance.OnProcessStartAdoptEdit += _uiManager.CollectionView.SetIsAdoptEditProcessing_Start;
		AnimalManager.Instance.OnProcessEndAdoptEdit += _animalPrefabController.SetUnmute_AllAnimalPrefabs;
		AnimalManager.Instance.OnProcessEndAdoptEdit += _cameraController.GuideToAnimalPos;
		AnimalManager.Instance.OnProcessEndAdoptEdit += _player.MoveUnlock;
		AnimalManager.Instance.OnProcessEndAdoptEdit += _uiManager.CollectionView.SetIsAdoptEditProcessing_End;
		AnimalManager.Instance.OnAdoptAnimal += _uiManager.ShowUnlockView;
		AnimalManager.Instance.OnEditAnimal += _uiManager.ShowAdoptView;
		_cameraController.OnGetAnimalPrefab += _animalPrefabController.GetAnimalPrefab;
		_cameraController.OnStartFocusOnAnimal += _uiManager.CollectionView.Hide;
		_cameraController.OnStartFocusOnAnimal += _uiManager.ShowAllUIBlock;
		_cameraController.OnEndFocusOnAnimal += _uiManager.HideAllUIBlock;
		_cameraController.OnStartFocusOnArea += _uiManager.ShowAllUIBlock;
		_cameraController.OnEndFocusOnArea += _uiManager.HideAllUIBlock;
		_cameraController.OnStartFocusOnCamp += _uiManager.ShowAllUIBlock;
		_cameraController.OnEndFocusOnCamp += _uiManager.HideAllUIBlock;
		_uiManager.FocusView.OnShowFocusView += _cameraController.FocusOnAnimal;
		_uiManager.FocusView.OnShowFocusView += _uiManager.HideBottomButtons;
		_uiManager.FocusView.OnHideFocusView += _cameraController.FocusOnPlayer;
		_uiManager.FocusView.OnHideFocusView += _uiManager.ShowBottomButtons;
		MonoSingleton<TutorialManager>.Instance.OnStartTutorial += _player.MoveLock;
		MonoSingleton<TutorialManager>.Instance.OnStartTutorial += _uiManager.HideBottomButtons;
		MonoSingleton<TutorialManager>.Instance.OnEndDialogue += _player.MoveUnlock;
		MonoSingleton<TutorialManager>.Instance.OnEndDialogue += _uiManager.UnlockCollectionButton;
		MonoSingleton<TutorialManager>.Instance.OnEndTutorial += _uiManager.UnlockFocusButton;
		MonoSingleton<AnimalPickController>.Instance.OnPickStartAnimalSpawnPos += _uiManager.SetFalseUIInteractable;
		MonoSingleton<AnimalPickController>.Instance.OnPickEndAnimalSpawnPos += _uiManager.SetTrueUIInteractable;
		_loadCompleted = await LoadGame();
		if (_loadCompleted)
		{
			MonoSingleton<SoundManager>.Instance.MuteBGM(mute: true);
			MonoSingleton<SoundManager>.Instance.MuteSFX(mute: true);
			_micGuideScreen.PlayShowAnim();
			await Task.WhenAny(_micGuideScreen.WaitForEndMicGuideScreen(), Task.Delay(5000));
			_loadingScreen.Show();
			await Task.Delay(3000);
			_loadingScreen.PlayFadeOut();
			await Task.Delay(500);
			MonoSingleton<SoundManager>.Instance.MuteBGM(mute: false);
			MonoSingleton<SoundManager>.Instance.MuteSFX(mute: false);
			_player.MoveUnlock();
			MonoSingleton<SoundManager>.Instance.PlayBGM(BGMType.BGM_Main);
			MonoSingleton<TutorialManager>.Instance.TryStartTutorial();
			StartCoroutine(AutoSaveLoop());
		}
	}

	private IEnumerator AutoSaveLoop()
	{
		WaitForSecondsRealtime wait = new WaitForSecondsRealtime(10f);
		while (true)
		{
			yield return wait;
			SaveGame();
		}
	}

	private void OnApplicationFocus(bool focus)
	{
		if (!focus)
		{
			SaveGame();
		}
	}

	public void SaveGame(bool lightweight = true)
	{
		if (_isSaving || !_loadCompleted)
		{
			return;
		}
		_isSaving = true;
		try
		{
			long currentGold = Wallet.Instance.CurrentGold;
			Dictionary<int, AnimalSaveData> dictionary = new Dictionary<int, AnimalSaveData>();
			foreach (KeyValuePair<int, Animal> item in AnimalManager.Instance.AnimalDict)
			{
				int key = item.Key;
				Animal value = item.Value;
				dictionary.Add(key, new AnimalSaveData(key, value.IsCollected, value.Name));
			}
			SettingSaveData settingSaveData = new SettingSaveData(MonoSingleton<SoundManager>.Instance.CurrentBGMVolume, MonoSingleton<SoundManager>.Instance.CurrentSFXVolume, Screen.fullScreen, Screen.width, Screen.height, LocalizationSettings.SelectedLocale.Identifier.Code, Screen.fullScreenMode);
			bool isTutorialCompleted = MonoSingleton<TutorialManager>.Instance.IsTutorialCompleted;
			Dictionary<int, AnimalPosSaveData> dictionary2 = new Dictionary<int, AnimalPosSaveData>();
			foreach (KeyValuePair<int, AnimalPos> item2 in _animalPrefabController.GetAnimalPosDict())
			{
				int key2 = item2.Key;
				AnimalPos value2 = item2.Value;
				dictionary2.Add(key2, new AnimalPosSaveData(key2, value2.transform.position, value2.GetCurrentSortingOrder()));
			}
			AreaSaveData areaSaveData = new AreaSaveData(MonoSingleton<AreaManager>.Instance.IsUnlock_WindIsland, MonoSingleton<AreaManager>.Instance.IsUnlock_DeepCave);
			bool campState = MonoSingleton<CampManager>.Instance.GetCampState(CampType.Forest);
			bool campState2 = MonoSingleton<CampManager>.Instance.GetCampState(CampType.Snow);
			bool campState3 = MonoSingleton<CampManager>.Instance.GetCampState(CampType.Jungle);
			bool campState4 = MonoSingleton<CampManager>.Instance.GetCampState(CampType.Savannah);
			CampSaveData campSaveData = new CampSaveData(campState, campState2, campState3, campState4);
			CostumeSaveData costumeSaveData = new CostumeSaveData(MonoSingleton<CostumeManager>.Instance.CostumeBuyStateDict, MonoSingleton<CostumeManager>.Instance.EquippedCostumeID);
			SaveLoadSystem.SaveGame(new GameSaveData(dictionary, currentGold, settingSaveData, isTutorialCompleted, dictionary2, areaSaveData, campSaveData, costumeSaveData));
			if (!lightweight)
			{
				foreach (KeyValuePair<int, Animal> item3 in AnimalManager.Instance.AnimalDict)
				{
					Animal value3 = item3.Value;
					AudioClip voice = value3.Voice;
					if (voice != null && value3.IsVoiceDirty)
					{
						string filePath = Path.Combine(Application.persistentDataPath, value3.AnimalData.VoiceFileName);
						WavSaveLoadManager.Save(voice, filePath);
						value3.ClearVoiceDirty();
					}
				}
			}
			Debug.Log("Saved game data!");
		}
		catch (Exception arg)
		{
			Debug.LogError($"Save failed: {arg}");
		}
		finally
		{
			_isSaving = false;
		}
	}

	public async Task<bool> LoadGame()
	{
		GameSaveData gameSaveData = SaveLoadSystem.LoadGame();
		if (gameSaveData != null)
		{
			await LoadGameCoroutine(gameSaveData);
		}
		else
		{
			Debug.Log("Game data not found! Set Init Game!");
			await SetInitData();
		}
		return true;
	}

	private async Task LoadGameCoroutine(GameSaveData gameSaveData)
	{
		Wallet.Instance.Init(gameSaveData.CurrentGold);
		foreach (AnimalSaveData animalSaveData in gameSaveData.AnimalSaveDataDict.Values)
		{
			AnimalManager.Instance.AnimalCollectStateChange(animalSaveData.ID, animalSaveData.IsCollected);
			AnimalManager.Instance.SetAnimalName(animalSaveData.ID, animalSaveData.Name);
			string path = Path.Combine(Application.persistentDataPath, DataManager.Instance.GetAnimalVoiceFileName(animalSaveData.ID));
			if (!File.Exists(path))
			{
				continue;
			}
			try
			{
				Task<AudioClip> loadTask = WavSaveLoadManager.Load(path);
				await Task.WhenAny(loadTask, Task.Delay(2000));
				if (loadTask.IsCompletedSuccessfully && loadTask.Result != null)
				{
					AnimalManager.Instance.SetAnimalVoice(animalSaveData.ID, loadTask.Result);
				}
				else
				{
					Debug.LogWarning("[VoiceLoad] Timeout or invalid clip skipped: " + path);
				}
			}
			catch (Exception ex)
			{
				Debug.LogError("[VoiceLoad] Load failed: " + ex.Message);
			}
		}
		if (gameSaveData.AnimalPosSaveDataDict != null)
		{
			foreach (AnimalPosSaveData value in gameSaveData.AnimalPosSaveDataDict.Values)
			{
				AnimalPos animalPos = _animalPrefabController.GetAnimalPos(value.ID);
				if (animalPos != null)
				{
					animalPos.transform.position = value.GetVector3();
					animalPos.SetCurrentSortingOrder(value.SortingOrder);
				}
			}
		}
		SettingSaveData settingSaveData = gameSaveData.SettingSaveData;
		int num = settingSaveData.ResolutionScreenWidth;
		int num2 = settingSaveData.ResolutionScreenHeight;
		if (num < 400 || num2 < 300)
		{
			num = Display.main.systemWidth;
			num2 = Display.main.systemHeight;
		}
		FullScreenMode fullScreenMode = settingSaveData.FullScreenModeValue;
		if (fullScreenMode == FullScreenMode.ExclusiveFullScreen)
		{
			fullScreenMode = (settingSaveData.IsFullScreen ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed);
		}
		if (fullScreenMode == FullScreenMode.ExclusiveFullScreen)
		{
			fullScreenMode = FullScreenMode.FullScreenWindow;
		}
		Screen.fullScreenMode = fullScreenMode;
		Screen.SetResolution(num, num2, Screen.fullScreenMode);
		Task<LocalizationSettings> localizationTask = LocalizationSettings.InitializationOperation.Task;
		await Task.WhenAny(localizationTask, Task.Delay(3000));
		if (!localizationTask.IsCompleted)
		{
			Debug.LogWarning("[Localization] Initialization timed out. Continuing with default locale.");
		}
		else
		{
			Debug.Log("[Localization] Initialization completed.");
		}
		Locale locale = LocalizationSettings.AvailableLocales.GetLocale(settingSaveData.LanguageCode);
		if (locale != null)
		{
			LocalizationSettings.SelectedLocale = locale;
		}
		else
		{
			Debug.LogWarning("Locale not found for code: " + settingSaveData.LanguageCode + ". Using default.");
			LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.GetLocale("en");
		}
		MonoSingleton<SoundManager>.Instance.SetBGMVolume(settingSaveData.BGMVolume);
		MonoSingleton<SoundManager>.Instance.SetSFXVolume(settingSaveData.SFXVolume);
		MonoSingleton<TutorialManager>.Instance.SetIsTutorialCompleted(gameSaveData.IsTutorialCompleted);
		if (gameSaveData.AreaSaveData == null)
		{
			gameSaveData.AreaSaveData = new AreaSaveData(isUnlock_WindIsland: false, isUnlock_DeepCave: false);
		}
		MonoSingleton<AreaManager>.Instance.Init(gameSaveData.AreaSaveData.IsUnlock_WindIsland, gameSaveData.AreaSaveData.IsUnlock_DeepCave);
		if (gameSaveData.CampSaveData == null)
		{
			gameSaveData.CampSaveData = new CampSaveData(isBuy_Forest: false, isBuy_Snow: false, isBuy_Jungle: false, isBuy_Savannah: false);
		}
		MonoSingleton<CampManager>.Instance.Init(gameSaveData.CampSaveData);
		if (gameSaveData.CostumeSaveData == null)
		{
			Dictionary<CostumeID, bool> dictionary = new Dictionary<CostumeID, bool>();
			dictionary.Add(CostumeID.Default, value: true);
			dictionary.Add(CostumeID.Duck, value: false);
			dictionary.Add(CostumeID.Reindeer, value: false);
			dictionary.Add(CostumeID.Frog, value: false);
			dictionary.Add(CostumeID.Cat, value: false);
			CostumeID equippedCostumeID = CostumeID.Default;
			gameSaveData.CostumeSaveData = new CostumeSaveData(dictionary, equippedCostumeID);
		}
		MonoSingleton<CostumeManager>.Instance.Init(gameSaveData.CostumeSaveData);
	}

	private async Task SetInitData()
	{
		await Task.Delay(2000);
		Wallet.Instance.Init(10L);
		int systemWidth = Display.main.systemWidth;
		int systemHeight = Display.main.systemHeight;
		Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
		Screen.SetResolution(systemWidth, systemHeight, Screen.fullScreenMode);
		Task<LocalizationSettings> localizationTask = LocalizationSettings.InitializationOperation.Task;
		await Task.WhenAny(localizationTask, Task.Delay(3000));
		if (!localizationTask.IsCompleted)
		{
			Debug.LogWarning("[Localization] Initialization timed out. Continuing with default locale.");
		}
		else
		{
			Debug.Log("[Localization] Localization initialized successfully.");
		}
		string text = Application.systemLanguage switch
		{
			SystemLanguage.English => "en", 
			SystemLanguage.Korean => "ko", 
			SystemLanguage.ChineseSimplified => "zh-Hans", 
			SystemLanguage.ChineseTraditional => "zh-Hant", 
			SystemLanguage.Japanese => "ja", 
			SystemLanguage.Russian => "ru", 
			SystemLanguage.German => "de", 
			SystemLanguage.French => "fr", 
			SystemLanguage.Italian => "it", 
			SystemLanguage.Spanish => "es-ES", 
			SystemLanguage.Portuguese => "pt-PT", 
			SystemLanguage.Thai => "th", 
			SystemLanguage.Indonesian => "id", 
			_ => "en", 
		};
		Locale locale = LocalizationSettings.AvailableLocales.GetLocale(text);
		if (locale == null)
		{
			if (text == "pt-PT")
			{
				locale = LocalizationSettings.AvailableLocales.GetLocale("pt-BR");
			}
			else if (text == "es-ES")
			{
				locale = LocalizationSettings.AvailableLocales.GetLocale("es-MX");
			}
		}
		LocalizationSettings.SelectedLocale = locale ?? LocalizationSettings.AvailableLocales.GetLocale("en");
		MonoSingleton<SoundManager>.Instance.SetBGMVolume(0.5f);
		MonoSingleton<SoundManager>.Instance.SetSFXVolume(0.5f);
		MonoSingleton<TutorialManager>.Instance.SetIsTutorialCompleted(isTutorialCompleted: false);
		MonoSingleton<AreaManager>.Instance.Init(isUnlock_WindIsland: false, isUnlock_DeepCave: false);
		MonoSingleton<CampManager>.Instance.Init(new CampSaveData(isBuy_Forest: false, isBuy_Snow: false, isBuy_Jungle: false, isBuy_Savannah: false));
		Dictionary<CostumeID, bool> dictionary = new Dictionary<CostumeID, bool>();
		dictionary.Add(CostumeID.Default, value: true);
		dictionary.Add(CostumeID.Duck, value: false);
		dictionary.Add(CostumeID.Reindeer, value: false);
		dictionary.Add(CostumeID.Frog, value: false);
		dictionary.Add(CostumeID.Cat, value: false);
		CostumeID equippedCostumeID = CostumeID.Default;
		MonoSingleton<CostumeManager>.Instance.Init(new CostumeSaveData(dictionary, equippedCostumeID));
	}
}
