#define LOG_LEVEL_VERBOSE
using System;
using System.Collections;
using System.Collections.Generic;
using FullInspector.Generated.SharedInstance;
using JetBrains.Annotations;
using Steamworks;
using TH20.Analytics;
using TH20.ExtContent;
using UnityConsole;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class OpeningScreen : MonoBehaviour
	{
		[Serializable]
		public class CameraSetting
		{
			public GameObject TransformGameObject;

			public PostProcessProfile PostProcessProfile;
		}

		public struct SaveSlotAnalyticsData
		{
			public int TotalFoundationValue;

			public int TotalSilver;

			public int TotalStars;

			public DateTime LastSaveTime;
		}

		private App _app;

		private InputManager _inputManager;

		[SerializeField]
		private GraphicRaycaster _graphicRaycaster;

		[SerializeField]
		private Canvas _rootCanvas;

		[SerializeField]
		private OpeningScreenMenu _openingScreenMenu;

		[SerializeField]
		private ExtraContentMenu _extraContentMenu;

		[SerializeField]
		private CampusPromotionMenu _campusPromotionMenu;

		[SerializeField]
		private PlayableDirector _directorPressStart;

		[SerializeField]
		private PlayableDirector _directorLoading;

		[SerializeField]
		private PlayableDirector _directorLoadingToPressStart;

		[SerializeField]
		private PlayableDirector _directorShowContent;

		[SerializeField]
		private PlayableDirector _directorShowContentImmediate;

		[SerializeField]
		private PlayableDirector _directorFadeOut;

		[SerializeField]
		private VideoReference _introVideoClip;

		[SerializeField]
		private SharedInstance_TH20VideoTH20_Video_SubtitlesDefinition _subtitles;

		[SerializeField]
		private Camera _camera;

		[SerializeField]
		private CameraSetting[] _cameraSettings;

		[SerializeField]
		private PostProcessVolume _postProcessVolume;

		[SerializeField]
		private PostProcessResources _postProcessResources;

		[SerializeField]
		private LayerMask _postProcessLayerMask;

		[SerializeField]
		private Image _masterFadeObject;

		[SerializeField]
		private float _splashFadeInTime = 0.5f;

		[SerializeField]
		private SaveSlotScreen _saveSlotScreen;

		[SerializeField]
		private CampusPromotionScreen _campusPromoScreen;

		[SerializeField]
		private Vector2 _cameraSwayAmplitute = new Vector2(1f, 1f);

		[SerializeField]
		private Vector2 _cameraSwayFrequency = new Vector2(1f, 1f);

		[SerializeField]
		private Transform _handsOnDemoWelcomeMessage;

		[SerializeField]
		private ContentCarouselMenu _contentCarouselMenu;

		[SerializeField]
		private DLCBuyButton[] _dlcButtons;

		[SerializeField]
		private SharedInstance_TH20TH20_DLCItemDefinition _campusDLCDefinition;

		[Tooltip("Transform containing the whole of the scene's content. This is what will be disabled to hide the screen.")]
		[SerializeField]
		private Transform _sceneContent;

		private bool _onPressAScreen;

		private bool _isLoading;

		private Coroutine _currentOperationCoroutine;

		private bool _skipPressed;

		private bool _debugSkipPressedThisFrame;

		private PostProcessLayer _postProcessLayer;

		private int _currentCameraSettingIndex;

		private CameraSetting _currentCameraSetting;

		private Vector3 _cachedCameraPosition;

		private float _cameraSwayTime;

		private MetagameMapScene _mapScene;

		private List<int> _corruptCareerSaves = new List<int>();

		private Callback<GameOverlayActivated_t> _gameOverlayCallback;

		public bool IsVisible => _sceneContent.gameObject.activeInHierarchy;

		private bool CanEnableCampusPromo()
		{
			bool num = _app.CloudDataManager.DownloadedCloudData != null && _app.CloudDataManager.DownloadedCloudData.ShowCampusPromotion;
			bool flag = PlatformFeatureSupport.IsFeatureSupported(PlatformFeatureSupport.FeatureType.CampusPreorderPromoItems) && !PlatformFeatureSupport.IsFeatureSupported(PlatformFeatureSupport.FeatureType.CampusPreorderPromoNoItems);
			bool flag2 = !DLCUtils.IsDLCOwned(_campusDLCDefinition.Instance);
			return num && flag && flag2;
		}

		private void Awake()
		{
			_sceneContent.gameObject.SetActive(value: false);
			_masterFadeObject.gameObject.SetActive(value: true);
			_masterFadeObject.color = Color.black;
			OpeningScreenMenu openingScreenMenu = _openingScreenMenu;
			openingScreenMenu.OnContinue = (Action)Delegate.Combine(openingScreenMenu.OnContinue, new Action(OnContinuePressed));
			OpeningScreenMenu openingScreenMenu2 = _openingScreenMenu;
			openingScreenMenu2.OnNewCareer = (Action)Delegate.Combine(openingScreenMenu2.OnNewCareer, new Action(OnNewCareerPressed));
			OpeningScreenMenu openingScreenMenu3 = _openingScreenMenu;
			openingScreenMenu3.OnSaveSlots = (Action)Delegate.Combine(openingScreenMenu3.OnSaveSlots, new Action(OnSaveSlotsPressed));
			OpeningScreenMenu openingScreenMenu4 = _openingScreenMenu;
			openingScreenMenu4.OnSandbox = (Action)Delegate.Combine(openingScreenMenu4.OnSandbox, new Action(OnSandboxPressed));
			OpeningScreenMenu openingScreenMenu5 = _openingScreenMenu;
			openingScreenMenu5.OnSettings = (Action)Delegate.Combine(openingScreenMenu5.OnSettings, new Action(OnSettingsPressed));
			OpeningScreenMenu openingScreenMenu6 = _openingScreenMenu;
			openingScreenMenu6.OnQuit = (Action)Delegate.Combine(openingScreenMenu6.OnQuit, new Action(OnQuitPressed));
			CampusPromotionMenu campusPromotionMenu = _campusPromotionMenu;
			campusPromotionMenu.OnOpenMenu = (Action)Delegate.Combine(campusPromotionMenu.OnOpenMenu, new Action(OnCampusPromoPressed));
			OSManager.OnDLCRefreshed = (Action)Delegate.Combine(OSManager.OnDLCRefreshed, new Action(RefreshDLCButtons));
			ConsoleCommandsDatabase.RegisterCommand("OpeningScreenContinueCareer", "Continues the career from the opening screen.", "StartMetagame", Debug_ContinueCareer);
			ConsoleCommandsDatabase.RegisterCommand("OpeningScreenNewCareer", "Starts a new career from the opening screen.", "StartMetagame", Debug_NewCareer);
			ConsoleCommandsDatabase.RegisterCommand("OpeningScreenChangeCamera", "Cycle camera index", "OpeningScreenChangeCamera", Debug_ChangeCamera);
			ConsoleCommandsDatabase.RegisterSimpleCommand("SkipOpeningVideo", "Skips the opening video after starting a new career", delegate
			{
				_debugSkipPressedThisFrame = true;
			});
			ConsoleCommandsDatabase.RegisterSimpleCommand("TriggerDLCRefresh", "Trigger a refresh of the DLC own state", RefreshDLCButtons);
		}

		private void OnDestroy()
		{
			if (_app != null)
			{
				SaveSystem saveSystem = _app.SaveSystem;
				saveSystem.OnRefreshCompleted = (Action)Delegate.Remove(saveSystem.OnRefreshCompleted, new Action(OnSaveSystemRefreshCompleted));
				SaveSystem.OnDiscoverCorruptMetagameSave = (Action<int>)Delegate.Remove(SaveSystem.OnDiscoverCorruptMetagameSave, new Action<int>(OnDiscoverCorruptSave));
				_inputManager.RemoveGraphicRayCaster(_graphicRaycaster);
				OpeningScreenMenu openingScreenMenu = _openingScreenMenu;
				openingScreenMenu.OnContinue = (Action)Delegate.Remove(openingScreenMenu.OnContinue, new Action(OnContinuePressed));
				OpeningScreenMenu openingScreenMenu2 = _openingScreenMenu;
				openingScreenMenu2.OnNewCareer = (Action)Delegate.Remove(openingScreenMenu2.OnNewCareer, new Action(OnNewCareerPressed));
				OpeningScreenMenu openingScreenMenu3 = _openingScreenMenu;
				openingScreenMenu3.OnSaveSlots = (Action)Delegate.Remove(openingScreenMenu3.OnSaveSlots, new Action(OnSaveSlotsPressed));
				OpeningScreenMenu openingScreenMenu4 = _openingScreenMenu;
				openingScreenMenu4.OnSandbox = (Action)Delegate.Remove(openingScreenMenu4.OnSandbox, new Action(OnSandboxPressed));
				OpeningScreenMenu openingScreenMenu5 = _openingScreenMenu;
				openingScreenMenu5.OnSettings = (Action)Delegate.Remove(openingScreenMenu5.OnSettings, new Action(OnSettingsPressed));
				OpeningScreenMenu openingScreenMenu6 = _openingScreenMenu;
				openingScreenMenu6.OnQuit = (Action)Delegate.Remove(openingScreenMenu6.OnQuit, new Action(OnQuitPressed));
				CampusPromotionMenu campusPromotionMenu = _campusPromotionMenu;
				campusPromotionMenu.OnOpenMenu = (Action)Delegate.Remove(campusPromotionMenu.OnOpenMenu, new Action(OnCampusPromoPressed));
				_app.LocalPreferences.Video.OnAmbientOcclusionChange -= OnAmbientOcclusionChange;
				_app.LocalPreferences.Video.OnBloomChange -= OnBloomChange;
				_app.LocalPreferences.Video.OnDepthOfFieldChange -= OnDepthOfFieldChange;
				_app.LocalPreferences.Video.OnAntialiasingChange -= OnAntialiasingChange;
				CloudDataManager cloudDataManager = _app.CloudDataManager;
				cloudDataManager.OnCloudDataFileReceived = (Action<CloudData>)Delegate.Remove(cloudDataManager.OnCloudDataFileReceived, new Action<CloudData>(OnCloudDataFileReceived));
			}
			OSManager.OnDLCRefreshed = (Action)Delegate.Remove(OSManager.OnDLCRefreshed, new Action(RefreshDLCButtons));
			ConsoleCommandsDatabase.UnRegisterCommand("OpeningScreenContinueCareer");
			ConsoleCommandsDatabase.UnRegisterCommand("OpeningScreenNewCareer");
			ConsoleCommandsDatabase.UnRegisterCommand("OpeningScreenChangeCamera");
			ConsoleCommandsDatabase.UnRegisterCommand("SkipOpeningVideo");
			ConsoleCommandsDatabase.UnRegisterCommand("TriggerDLCRefresh");
		}

		private void Update()
		{
			_skipPressed = Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || _debugSkipPressedThisFrame;
			_debugSkipPressedThisFrame = false;
			UpdateCameraMotion();
			if (IsVisible)
			{
				ExtContentUtils.CheckShowGameItemDevInfoPanelInput();
			}
			if (_onPressAScreen && !_app.MessageBox.IsVisible && _inputManager.GetButtonDown(74))
			{
				if (OnlineManager.RequiresLogOn())
				{
					ShowLoading();
				}
				else
				{
					ShowNormalContent(immediately: false);
				}
			}
		}

		public void Setup(App app, InputManager inputManager, MetagameMapScene mapScene)
		{
			Logging.Info(LogChannels.GameFlow, "OpeningScreen: Setup");
			_app = app;
			SaveSystem saveSystem = _app.SaveSystem;
			saveSystem.OnRefreshCompleted = (Action)Delegate.Combine(saveSystem.OnRefreshCompleted, new Action(OnSaveSystemRefreshCompleted));
			SaveSystem.OnDiscoverCorruptMetagameSave = (Action<int>)Delegate.Combine(SaveSystem.OnDiscoverCorruptMetagameSave, new Action<int>(OnDiscoverCorruptSave));
			_app.SaveSystem.RefreshMetagameSaveLists();
			_app.SaveSystem.CheckForCorruptMetagameSaves();
			_app.LocalPreferences.Video.OnAmbientOcclusionChange += OnAmbientOcclusionChange;
			_app.LocalPreferences.Video.OnBloomChange += OnBloomChange;
			_app.LocalPreferences.Video.OnDepthOfFieldChange += OnDepthOfFieldChange;
			_app.LocalPreferences.Video.OnAntialiasingChange += OnAntialiasingChange;
			CloudDataManager cloudDataManager = _app.CloudDataManager;
			cloudDataManager.OnCloudDataFileReceived = (Action<CloudData>)Delegate.Combine(cloudDataManager.OnCloudDataFileReceived, new Action<CloudData>(OnCloudDataFileReceived));
			if (_gameOverlayCallback == null && OnlineManager.IsInitialized())
			{
				_gameOverlayCallback = Callback<GameOverlayActivated_t>.Create(OnGameOverlayActivated);
			}
			_extraContentMenu.Initialise(app.DLCManager, app.AnalyticsManager, app.MessageBox);
			_contentCarouselMenu.Initialise(app.DLCManager, app.AnalyticsManager, app.MessageBox, app.CloudDataManager);
			DLCBuyButton[] dlcButtons = _dlcButtons;
			for (int i = 0; i < dlcButtons.Length; i++)
			{
				dlcButtons[i].Setup(_app.AnalyticsManager, _app.MessageBox);
			}
			InitialiseCameraPostProcessing();
			_currentCameraSettingIndex = RandomUtils.GlobalRandomInstance.Next(0, _cameraSettings.Length);
			_inputManager = inputManager;
			_inputManager.AddGraphicRayCaster(_graphicRaycaster);
			_mapScene = mapScene;
		}

		private void OnDiscoverCorruptSave(int slotIndex)
		{
			if (!_corruptCareerSaves.Contains(slotIndex))
			{
				_corruptCareerSaves.Add(slotIndex);
			}
		}

		public void Show()
		{
			Logging.Info(LogChannels.GameFlow, "OpeningScreen: Show");
			QualitySettings.shadowDistance = 1700f;
			if (!SceneManager.SetActiveScene(SceneManager.GetSceneByName("MetagameScene")))
			{
				Logging.Warning(LogChannels.GameFlow, "OpeningScreen: Failed to set MetagameScene as active; must have become unloaded");
			}
			GameObjectUtils.SetActive(_mapScene.RootObject, isActive: true);
			ShowContent();
			StartCoroutine(StartFadeIn());
		}

		private void ShowPressA()
		{
			ResetAnimations();
			if (_isLoading)
			{
				_isLoading = false;
				_directorLoadingToPressStart.Play();
			}
			else
			{
				_directorPressStart.Play();
			}
			_onPressAScreen = true;
		}

		private void ShowLoading()
		{
			ResetAnimations();
			OnlineManager.StartLogOn();
			_onPressAScreen = false;
			_isLoading = true;
			_directorLoading.Play();
			OSManager.OnUserChanged = (Action)Delegate.Combine(OSManager.OnUserChanged, new Action(HandleUserChanged));
		}

		private void HandleUserChanged()
		{
			OSManager.OnUserChanged = (Action)Delegate.Remove(OSManager.OnUserChanged, new Action(HandleUserChanged));
			if (OnlineManager.IsLoggedOn())
			{
				_app.ReloadSaves();
				RefreshDLCButtons();
				ShowNormalContent(immediately: false);
			}
			else
			{
				ShowPressA();
			}
		}

		private void ShowNormalContent(bool immediately)
		{
			_onPressAScreen = false;
			_isLoading = false;
			if (immediately)
			{
				_directorShowContentImmediate.Play();
			}
			else
			{
				_directorShowContent.Play();
			}
			if (_app?.PrimeGaming != null)
			{
				_app.PrimeGaming.RefreshEntitlements();
			}
			BackupSaveBox backupSave = _app.BackupSave;
			backupSave.OnBackupHandled = (Action)Delegate.Combine(backupSave.OnBackupHandled, new Action(HandleCorruptSaves));
			HandleCorruptSaves();
			_app.SaveSystem.LoadRoomTemplatesSaveData(_app.RoomTemplatesManager);
			_app.RoomTemplatesManager.RestoreFromSave(_app);
			OnlineManager.SetGameMode(_app.GameMode);
		}

		private void HandleCorruptSaves()
		{
			if (_corruptCareerSaves.Count == 0)
			{
				_app.SaveSystem.Refresh();
				BackupSaveBox backupSave = _app.BackupSave;
				backupSave.OnBackupHandled = (Action)Delegate.Remove(backupSave.OnBackupHandled, new Action(HandleCorruptSaves));
				return;
			}
			MetagameSaveHeader backupCareerHeader = null;
			if (_app.SaveSystem.TryGetBackupCareerSave(_corruptCareerSaves[0], out var saveData))
			{
				backupCareerHeader = saveData.MetagameSaveHeader;
			}
			_app.BackupSave.ShowCareerBackup(_corruptCareerSaves[0], backupCareerHeader);
			_corruptCareerSaves.RemoveAt(0);
		}

		private void ShowContent()
		{
			if (_app?.CloudDataManager != null)
			{
				_app.CloudDataManager.RefreshCloudData();
			}
			_sceneContent.gameObject.SetActive(value: true);
			_campusPromotionMenu.gameObject.SetActive(CanEnableCampusPromo());
			TooltipManager.Instance.PushGUIRoot(_rootCanvas.transform);
			_currentCameraSettingIndex = (_currentCameraSettingIndex + 1) % _cameraSettings.Length;
			_currentCameraSetting = _cameraSettings[_currentCameraSettingIndex];
			_camera.transform.position = _currentCameraSetting.TransformGameObject.transform.position;
			_camera.transform.rotation = _currentCameraSetting.TransformGameObject.transform.rotation;
			_cachedCameraPosition = _camera.transform.position;
			SetPostProcessProfile(_currentCameraSetting.PostProcessProfile);
			_masterFadeObject.gameObject.SetActive(value: true);
			_masterFadeObject.color = Color.white;
			ResetAnimations();
			_handsOnDemoWelcomeMessage.gameObject.SetActive(DebugVars.EnableHandsOnDemo.Value);
			SetupMenuButtonsForSave();
			if (OnlineManager.RequiresLogOn())
			{
				ShowPressA();
			}
			else
			{
				ShowNormalContent(immediately: true);
			}
		}

		private void ResetAnimations()
		{
			_directorFadeOut.time = 0.0;
			_directorFadeOut.Stop();
			_directorPressStart.time = 0.0;
			_directorPressStart.Stop();
			_directorLoading.time = 0.0;
			_directorLoading.Stop();
			_directorLoadingToPressStart.time = 0.0;
			_directorLoadingToPressStart.Stop();
			_directorShowContent.time = 0.0;
			_directorShowContent.Stop();
			_directorShowContentImmediate.time = 0.0;
			_directorShowContentImmediate.Stop();
		}

		private void OnContinuePressed()
		{
			if (_currentOperationCoroutine == null)
			{
				_currentOperationCoroutine = StartCoroutine(StartGame(ignoreSave: false, _app.SaveSystem.MostRecentMetagameSaveSlotIndex));
			}
		}

		private void OnNewCareerPressed()
		{
			if (_currentOperationCoroutine == null)
			{
				_currentOperationCoroutine = StartCoroutine(StartGame(ignoreSave: true, 0));
			}
		}

		private void OnSaveSlotsPressed()
		{
			if (_currentOperationCoroutine == null)
			{
				_saveSlotScreen.Show(_app.SaveSystem, _app.MessageBox, delegate(int saveSlotIndex)
				{
					_currentOperationCoroutine = StartCoroutine(StartGame(ignoreSave: false, saveSlotIndex));
				}, delegate(int saveSlotIndex)
				{
					_currentOperationCoroutine = StartCoroutine(StartGame(ignoreSave: true, saveSlotIndex));
				});
			}
		}

		public void HideSaveSlots()
		{
			_saveSlotScreen.Hide();
		}

		private void OnSandboxPressed()
		{
			if (_currentOperationCoroutine == null)
			{
				_currentOperationCoroutine = StartCoroutine(StartSandbox());
			}
		}

		private void OnSettingsPressed()
		{
			if (_currentOperationCoroutine == null)
			{
				_app.PreferencesScreen.Show();
			}
		}

		private void OnQuitPressed()
		{
			_app.QuitGame();
		}

		private void OnCampusPromoPressed()
		{
			if (_currentOperationCoroutine == null)
			{
				_campusPromoScreen.Show(_app.CloudDataManager);
			}
		}

		public void HideCampusPromo()
		{
			_campusPromoScreen.Hide();
		}

		private IEnumerator StartFadeIn()
		{
			Logging.Info(LogChannels.GameFlow, "OpeningScreen: Fade in starting.");
			float elapsedTime = 0f;
			float fadeInTime = (DebugVars.FastLoadingScreenAnimation.Value ? 0.1f : _splashFadeInTime);
			while (elapsedTime < fadeInTime)
			{
				elapsedTime += Time.unscaledDeltaTime;
				float num = Mathf.Clamp01(elapsedTime / fadeInTime);
				_masterFadeObject.color = new Color(1f, 1f, 1f, EasingsUtils.CubicEaseInOut(1f - num));
				yield return null;
			}
			_masterFadeObject.gameObject.SetActive(value: false);
			Logging.Info(LogChannels.GameFlow, "OpeningScreen: Fade in finished.");
		}

		private void OnSaveSystemRefreshCompleted()
		{
			SetupMenuButtonsForSave();
			SaveSlotAnalyticsData[] array = new SaveSlotAnalyticsData[3];
			int num = 0;
			for (int i = 0; i < 3; i++)
			{
				MetagameSaveHeader metagameSaveHeaderForSlot = _app.SaveSystem.GetMetagameSaveHeaderForSlot(i);
				if (metagameSaveHeaderForSlot != null)
				{
					num++;
					array[i].LastSaveTime = metagameSaveHeaderForSlot.Date;
					array[i].TotalFoundationValue = metagameSaveHeaderForSlot.TotalFoundationValue;
					array[i].TotalSilver = metagameSaveHeaderForSlot.TotalSilver;
					array[i].TotalStars = metagameSaveHeaderForSlot.TotalStars;
				}
				else
				{
					array[i].LastSaveTime = TimeUtils.MinDateTimeUTC;
					array[i].TotalFoundationValue = 0;
					array[i].TotalSilver = 0;
					array[i].TotalStars = 0;
				}
			}
			GameEvent gameEvent = new GameEvent(_app.AnalyticsManager.Config.CareerSavesInfo).AddParam("numSaveSlotsUsed", num).AddParam("slot1AccessDate", array[0].LastSaveTime.ToString("o")).AddParam("slot1FoundationValue", array[0].TotalFoundationValue)
				.AddParam("slot1TotalSilver", array[0].TotalSilver)
				.AddParam("slot1TotalStars", array[0].TotalStars)
				.AddParam("slot2AccessDate", array[1].LastSaveTime.ToString("o"))
				.AddParam("slot2FoundationValue", array[1].TotalFoundationValue)
				.AddParam("slot2TotalSilver", array[1].TotalSilver)
				.AddParam("slot2TotalStars", array[1].TotalStars)
				.AddParam("slot3AccessDate", array[2].LastSaveTime.ToString("o"))
				.AddParam("slot3FoundationValue", array[2].TotalFoundationValue)
				.AddParam("slot3TotalSilver", array[2].TotalSilver)
				.AddParam("slot3TotalStars", array[2].TotalStars);
			_app.AnalyticsManager.RecordEvent(gameEvent);
		}

		private void SetupMenuButtonsForSave()
		{
			if (_app.SaveSystem.MostRecentMetagameSaveSlotIndex != -1)
			{
				MetagameSaveHeader metagameSaveHeaderForSlot = _app.SaveSystem.GetMetagameSaveHeaderForSlot(_app.SaveSystem.MostRecentMetagameSaveSlotIndex);
				_openingScreenMenu.SetupButtonsForExistingSave(_app.UserProfile, metagameSaveHeaderForSlot);
			}
			else
			{
				_openingScreenMenu.SetupButtonsForNoSave(_app.UserProfile);
			}
		}

		private IEnumerator StartGame(bool ignoreSave, int saveSlotIndex, bool dontPlayVideo = false)
		{
			_directorFadeOut.Play();
			if (DebugVars.FastLoadingScreenAnimation.Value && _directorFadeOut.playableGraph.IsValid())
			{
				_directorFadeOut.playableGraph.GetRootPlayable(0).SetSpeed(5.0);
			}
			while (_directorFadeOut.time < _directorFadeOut.duration)
			{
				yield return null;
			}
			TooltipManager.Instance.PopGUIRoot(_rootCanvas.transform);
			_sceneContent.gameObject.SetActive(value: false);
			_app.SetGameMode<GameModeCareer>();
			if (ignoreSave)
			{
				if (!dontPlayVideo)
				{
					FullScreenVideoMenu.VideoContext next = new FullScreenVideoMenu.VideoContext
					{
						Clip = _introVideoClip.VideoClip,
						Subtitles = _subtitles.Instance,
						Volume = 0.15f,
						FadeIn = false,
						FadeOut = true
					};
					_app.FullScreenVideoMenu.PlayVideo(next, null, null);
					while (_app.FullScreenVideoMenu.IsPlaying)
					{
						if (_skipPressed)
						{
							_app.FullScreenVideoMenu.Skip();
						}
						yield return null;
					}
				}
				yield return _app.GameMode.RestartAsync(saveSlotIndex);
			}
			else
			{
				yield return _app.GameMode.LoadAsync(ignoreSave: false, saveSlotIndex);
			}
			_currentOperationCoroutine = null;
		}

		private IEnumerator StartSandbox()
		{
			_directorFadeOut.Play();
			if (DebugVars.FastLoadingScreenAnimation.Value && _directorFadeOut.playableGraph.IsValid())
			{
				_directorFadeOut.playableGraph.GetRootPlayable(0).SetSpeed(5.0);
			}
			while (_directorFadeOut.time < _directorFadeOut.duration)
			{
				yield return null;
			}
			TooltipManager.Instance.PopGUIRoot(_rootCanvas.transform);
			_sceneContent.gameObject.SetActive(value: false);
			_app.SetGameMode<GameModeSandbox>();
			yield return _app.GameMode.LoadAsync(ignoreSave: true, 0);
			_currentOperationCoroutine = null;
		}

		private void UpdateCameraMotion()
		{
			_cameraSwayTime += Time.unscaledDeltaTime;
			float num = Mathf.Sin(_cameraSwayTime * _cameraSwayFrequency.x) * _cameraSwayAmplitute.x;
			float num2 = Mathf.Sin(_cameraSwayTime * _cameraSwayFrequency.y) * _cameraSwayAmplitute.y;
			_camera.transform.position = _cachedCameraPosition + _camera.transform.right * num + _camera.transform.up * num2;
		}

		private void SetSceneCamera(int cameraIndex)
		{
			_currentCameraSetting = _cameraSettings[cameraIndex];
			_camera.transform.position = _currentCameraSetting.TransformGameObject.transform.position;
			_camera.transform.rotation = _currentCameraSetting.TransformGameObject.transform.rotation;
			_cachedCameraPosition = _camera.transform.position;
			SetPostProcessProfile(_currentCameraSetting.PostProcessProfile);
		}

		private void InitialiseCameraPostProcessing()
		{
			if (_postProcessLayer == null)
			{
				_postProcessLayer = _camera.gameObject.GetOrAddComponent<PostProcessLayer>();
				_postProcessLayer.volumeTrigger = _camera.gameObject.transform;
				_postProcessLayer.volumeLayer = _postProcessLayerMask;
				_postProcessLayer.Init(_postProcessResources);
				_postProcessLayer.temporalAntialiasing.jitterSpread = 0.424f;
				_postProcessLayer.temporalAntialiasing.stationaryBlending = 0.794f;
				_postProcessLayer.temporalAntialiasing.motionBlending = 0.7f;
				_postProcessLayer.temporalAntialiasing.sharpness = 0.05f;
				_postProcessLayer.antialiasingMode = (_app.LocalPreferences.Video.Antialiasing ? PostProcessLayer.Antialiasing.FastApproximateAntialiasing : PostProcessLayer.Antialiasing.None);
			}
			_postProcessVolume.isGlobal = true;
		}

		private void SetPostProcessProfile(PostProcessProfile profile)
		{
			if (profile.TryGetSettings<AmbientOcclusion>(out var outSetting))
			{
				outSetting.active = _app.LocalPreferences.Video.AmbientOcclusion;
			}
			if (profile.TryGetSettings<Bloom>(out var outSetting2))
			{
				outSetting2.active = _app.LocalPreferences.Video.Bloom;
			}
			if (profile.TryGetSettings<DepthOfField>(out var outSetting3))
			{
				outSetting3.active = _app.LocalPreferences.Video.DepthOfField;
			}
			_postProcessVolume.sharedProfile = profile;
		}

		private void OnAmbientOcclusionChange(bool active)
		{
			if (_postProcessVolume != null && _postProcessVolume.profile.TryGetSettings<AmbientOcclusion>(out var outSetting))
			{
				outSetting.active = active;
			}
		}

		private void OnBloomChange(bool active)
		{
			if (_postProcessVolume != null && _postProcessVolume.profile.TryGetSettings<Bloom>(out var outSetting))
			{
				outSetting.active = active;
			}
		}

		private void OnDepthOfFieldChange(bool active)
		{
			if (_postProcessVolume != null && _postProcessVolume.profile.TryGetSettings<DepthOfField>(out var outSetting))
			{
				outSetting.active = active;
			}
		}

		private void OnAntialiasingChange(bool active)
		{
			if (_postProcessLayer != null)
			{
				_postProcessLayer.antialiasingMode = (_app.LocalPreferences.Video.Antialiasing ? PostProcessLayer.Antialiasing.FastApproximateAntialiasing : PostProcessLayer.Antialiasing.None);
			}
		}

		private void OnCloudDataFileReceived(CloudData cloudData)
		{
			_campusPromotionMenu.gameObject.SetActive(CanEnableCampusPromo());
			_contentCarouselMenu.Initialise(_app.DLCManager, _app.AnalyticsManager, _app.MessageBox, _app.CloudDataManager);
		}

		private void OnGameOverlayActivated(GameOverlayActivated_t pCallback)
		{
			Logging.Info(LogChannels.Online, "OnSteamGameOverlayActivated - Active = {0}", pCallback.m_bActive);
			RefreshDLCButtons();
		}

		private void RefreshDLCButtons()
		{
			if (_app.DLCManager != null)
			{
				_app.DLCManager.RevalidatePurchasedDLC();
				DLCBuyButton[] dlcButtons = _dlcButtons;
				for (int i = 0; i < dlcButtons.Length; i++)
				{
					dlcButtons[i].Setup(_app.AnalyticsManager, _app.MessageBox);
				}
				_contentCarouselMenu.Initialise(_app.DLCManager, _app.AnalyticsManager, _app.MessageBox, _app.CloudDataManager);
			}
		}

		private ConsoleCommandResult Debug_ContinueCareer(string[] args)
		{
			if (_currentOperationCoroutine == null)
			{
				_currentOperationCoroutine = StartCoroutine(StartGame(ignoreSave: false, 0));
			}
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_NewCareer(string[] args)
		{
			if (_currentOperationCoroutine == null)
			{
				_currentOperationCoroutine = StartCoroutine(StartGame(ignoreSave: true, 0, dontPlayVideo: true));
			}
			return ConsoleCommandResult.Succeeded();
		}

		private ConsoleCommandResult Debug_ChangeCamera(string[] args)
		{
			_currentCameraSettingIndex = (_currentCameraSettingIndex + 1) % _cameraSettings.Length;
			SetSceneCamera(_currentCameraSettingIndex);
			return ConsoleCommandResult.Succeeded();
		}
	}
}
