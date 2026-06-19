#define LOG_LEVEL_VERBOSE
using System;
using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using Rewired;
using Steamworks;
using TH20.ExtContent;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[DontSave]
	public class PreferencesScreen : MonoBehaviour
	{
		private enum Tab
		{
			Video = 0,
			Audio = 1,
			Controls = 2,
			Game = 3,
			Language = 4
		}

		[SerializeField]
		private Button _closeButton;

		[SerializeField]
		private Button _creditsButton;

		[SerializeField]
		private GameObject _creditsScreenPrefab;

		[Header("Video")]
		[SerializeField]
		private GameObject _reloadingTexturesScreen;

		[SerializeField]
		private int _secondsToWaitForResolutionChangeConfirmation = 15;

		[SerializeField]
		private Transform _acceptResolutionChangesScreen;

		[SerializeField]
		private Button _applyResolutionChangesButton;

		[SerializeField]
		private Button _acceptResolutionChangesButton;

		[SerializeField]
		private Button _undoResolutionChangesButton;

		[SerializeField]
		private TextMeshProUGUI _resolutionChangesTimeoutText;

		[SerializeField]
		private TMP_Dropdown _resolutionDropdown;

		[SerializeField]
		private Toggle _fullScreenToggle;

		[SerializeField]
		private TMP_Dropdown _vSyncDropdown;

		[SerializeField]
		private TMP_Dropdown _qualitySettingDropdown;

		[SerializeField]
		private TMP_Dropdown _textureQualityDropdown;

		[SerializeField]
		private TMP_Dropdown _anisoTexturesDropdown;

		[SerializeField]
		private TMP_Dropdown _shadowQualityDropdown;

		[SerializeField]
		private TMP_Dropdown _shadowResolutionDropdown;

		[SerializeField]
		private TMP_Dropdown _shadowFadeDistanceDropdown;

		[SerializeField]
		private TMP_Dropdown _lightFadeDistanceDropdown;

		[SerializeField]
		private TMP_Dropdown _hospitalLightingQualityDropdown;

		[SerializeField]
		private TMP_Dropdown _particlesQualityDropdown;

		[SerializeField]
		private Toggle _ambientOcclusionToggle;

		[SerializeField]
		private Toggle _bloomToggle;

		[SerializeField]
		private Toggle _depthOfFieldToggle;

		[SerializeField]
		private Toggle _antialiasingToggle;

		[SerializeField]
		private Slider _maximumFPSSlider;

		[SerializeField]
		private TMP_Text _maximumFPSValueLabel;

		[SerializeField]
		private Slider _lodBiasSlider;

		[SerializeField]
		private TMP_Text _lodBiasValueLabel;

		[SerializeField]
		private Slider _characterDrawDistanceSlider;

		[SerializeField]
		private TMP_Text _characterDrawDistanceValueLabel;

		[SerializeField]
		private Button _resetVideoToDefaultButton;

		[Header("Audio")]
		[SerializeField]
		private Slider _masterVolumeSlider;

		[SerializeField]
		private Slider _musicVolumeSlider;

		[SerializeField]
		private Slider _sfxVolumeSlider;

		[SerializeField]
		private Slider _tannoyVolumeSlider;

		[SerializeField]
		private Slider _djVolumeSlider;

		[SerializeField]
		private DynamicButton _editPlaylistButton;

		[SerializeField]
		private DynamicButton _togglePlaybackModeButton;

		[SerializeField]
		private TMP_Text _playbackModeButtonText;

		[SerializeField]
		private DynamicButton _resetToDefaultsButton;

		[SerializeField]
		private GameObject _audioTabContentsPanel;

		[SerializeField]
		private GameObject _audioTabPlaylistPanel;

		[SerializeField]
		private GameObject _audioTabPlaylistPanelPrefab;

		[SerializeField]
		private Button _playlistBackButton;

		[SerializeField]
		private Button _playlistDefaultsButton;

		[Header("Game")]
		[SerializeField]
		private TMP_Dropdown _levelAutoSaveFrequencyDropdown;

		[SerializeField]
		private TMP_Dropdown _careerAutoSaveFrequencyDropdown;

		[SerializeField]
		private GameObject _numberOfAutoSavesLayoutElement;

		[SerializeField]
		private TMP_Dropdown _numberOfAutoSavesDropdown;

		[SerializeField]
		private Toggle _rollManualSavesToggle;

		[SerializeField]
		private Toggle _autoSaveOnLevelChangeToggle;

		[SerializeField]
		private GameObject _onlineLayoutElement;

		[SerializeField]
		private Toggle _onlineVisibilityToggle;

		[SerializeField]
		private TMP_Dropdown _advisorFilterDropdown;

		[SerializeField]
		private TMP_Dropdown _logLevelDropdown;

		[SerializeField]
		private DynamicButton _workshopWikiButton;

		[Header("Login With Amazon")]
		[SerializeField]
		private GameObject _lwaElement;

		[SerializeField]
		private DynamicButton _lwaButton;

		[SerializeField]
		private ButtonAnimator _lwaButtonAnim;

		[SerializeField]
		private GameObject _lwaInstructions;

		[SerializeField]
		private DynamicButton _lwaHyperlink;

		[SerializeField]
		private TMP_Text _lwaLinkText;

		[SerializeField]
		private TMP_Text _lwaCodeText;

		[SerializeField]
		private DynamicButton _lwaCopyButton;

		[SerializeField]
		private ButtonAnimator _lwaCopyButtonAnim;

		[SerializeField]
		private DynamicButton _lwaOKButton;

		[SerializeField]
		private GameObject _lwaConfirmation;

		[SerializeField]
		private DynamicButton _lwaRestartButton;

		[SerializeField]
		private DynamicButton _lwaCancelButton;

		[SerializeField]
		private GameObject _lwaError;

		[SerializeField]
		private DynamicButton _lwaDismissButtton;

		[Header("Controls")]
		[SerializeField]
		private Toggle _mouseDirectionRotateItemToggle;

		[SerializeField]
		private Toggle _useRoomItemSnapToggle;

		[SerializeField]
		private Toggle _useWallMagnetismToggle;

		[SerializeField]
		private Toggle _enableEdgeScrollingToggle;

		[Header("Keyboard Bindings")]
		[SerializeField]
		private GameObject _bindingScreen;

		[SerializeField]
		private GameObject _keyboardBindingConflictWarning;

		[SerializeField]
		private GameObject _keyboardBindingRowPrefab;

		[SerializeField]
		private Table _keyboardBindingsTable;

		[SerializeField]
		private DynamicButton _resetKeyboardBindingsButton;

		[SerializeField]
		private LocalisedString _bindingActionString;

		[SerializeField]
		private TMP_Text _bindingActionText;

		[Header("Language")]
		[SerializeField]
		private TMP_Dropdown _languageDropdown;

		[SerializeField]
		private TMP_Dropdown _languageAudioDropdown;

		[Header("Tab Buttons")]
		[SerializeField]
		private DynamicButton _videoTabButton;

		[SerializeField]
		private DynamicButton _audioTabButton;

		[SerializeField]
		private DynamicButton _controlsTabButton;

		[SerializeField]
		private DynamicButton _gameTabButton;

		[SerializeField]
		private DynamicButton _languageTabButton;

		[Header("Tab Button Animators")]
		[SerializeField]
		private ButtonAnimator _videoTabButtonAnimator;

		[SerializeField]
		private ButtonAnimator _audioTabButtonAnimator;

		[SerializeField]
		private ButtonAnimator _controlsTabButtonAnimator;

		[SerializeField]
		private ButtonAnimator _gameTabButtonAnimator;

		[SerializeField]
		private ButtonAnimator _languageTabButtonAnimator;

		[Header("Tab Folder Background")]
		[SerializeField]
		private Transform _videoTabFolderBackground;

		[SerializeField]
		private Transform _audioTabFolderBackground;

		[SerializeField]
		private Transform _controlsTabFolderBackground;

		[SerializeField]
		private Transform _gameTabFolderBackground;

		[SerializeField]
		private Transform _languageTabFolderBackground;

		[Header("Tab Transforms")]
		[SerializeField]
		private Transform _initialTab;

		[SerializeField]
		private Transform _videoTab;

		[SerializeField]
		private Transform _audioTab;

		[SerializeField]
		private Transform _controlsTab;

		[SerializeField]
		private Transform _gameTab;

		[SerializeField]
		private Transform _languageTab;

		[SerializeField]
		private Transform _videoTabContents;

		[SerializeField]
		private Transform _audioTabContents;

		[SerializeField]
		private Transform _controlsTabContents;

		[SerializeField]
		private Transform _gameTabContents;

		[SerializeField]
		private Transform _languageTabContents;

		private Preferences _preferences;

		private LocalPreferences _localPreferences;

		private ControlBindingsLocalisationParamsManager _controlBindingsLocalisationParamsManager;

		private ExtContentManager _extContentManager;

		private App _app;

		private DynamicPlaylistManager _dynamicPlaylistManager;

		private GameItemCreditsScreen _extContentGameItemCreditsScreen;

		private DynamicPlaylistUI _playlistEditModeUI;

		private MessageBox _messageBox;

		private CloudDataManager _cloudDataManager;

		private PrimeGaming _primeGaming;

		private MonoBehaviour _behaviourToRunCoroutinesOn;

		private List<InputAction> _visibleInputAcions = new List<InputAction>(128);

		private InputAction _pollingInputAction;

		private int _pollingMapNumber;

		private bool _bPlaylistEditModeOn;

		private GameObject _playlistEditModePanelGameObject;

		private Resolution[] _validResolutions;

		private CreditsScreen _creditsScreen;

		private bool _creditsPlaying;

		private Tab _activeTab;

		private Resolution _resolutionBeforeChange;

		private bool _wasFullScreenBeforeChange;

		private Coroutine _waitForResolutionChangeConfirmationCoroutine;

		public void Setup(Preferences preferences, LocalPreferences localPreferences, ControlBindingsLocalisationParamsManager controlBindingsLocalisationParamsManager)
		{
			_preferences = preferences;
			_localPreferences = localPreferences;
			Setup(null, controlBindingsLocalisationParamsManager, null);
		}

		public void Setup(App app, ControlBindingsLocalisationParamsManager controlBindingsLocalisationParamsManager, MonoBehaviour behaviourToRunCoroutinesOn)
		{
			_controlBindingsLocalisationParamsManager = controlBindingsLocalisationParamsManager;
			_behaviourToRunCoroutinesOn = behaviourToRunCoroutinesOn;
			if (app != null)
			{
				_app = app;
				_preferences = _app.UserPreferences;
				_localPreferences = _app.LocalPreferences;
				_cloudDataManager = _app.CloudDataManager;
				_extContentManager = _app.ExtContentManager;
				_dynamicPlaylistManager = _app.DynamicPlaylistManager;
				_messageBox = _app.MessageBox;
				_primeGaming = _app.PrimeGaming;
			}
			base.gameObject.SetActive(value: false);
			_closeButton.onClick.AddListener(CloseAndSavePreferences);
			_creditsButton.onClick.AddListener(CreditsButtonClicked);
			_videoTabButton.onPrimaryDown.AddListener(delegate
			{
				SetTabActive(Tab.Video);
			});
			_audioTabButton.onPrimaryDown.AddListener(delegate
			{
				SetTabActive(Tab.Audio);
			});
			_controlsTabButton.onPrimaryDown.AddListener(delegate
			{
				SetTabActive(Tab.Controls);
			});
			_gameTabButton.onPrimaryDown.AddListener(delegate
			{
				SetTabActive(Tab.Game);
			});
			_languageTabButton.onPrimaryDown.AddListener(delegate
			{
				SetTabActive(Tab.Language);
			});
			_initialTab.SetAsLastSibling();
			SetTabActive(Tab.Video);
			SetupVideoTab();
			SetupAudioTab();
			SetupGameTab();
			SetupControlsTab();
			SetupLanguageTab();
			Refresh(_preferences, _localPreferences);
		}

		public void Refresh(Preferences preferences, LocalPreferences localPreferences)
		{
			_preferences = preferences;
			_localPreferences = localPreferences;
			SetupAudioTab();
			SetupGameTab();
			SetupControlsTab();
			SetupLanguageTab();
		}

		private void SetTabActive(Tab tab)
		{
			GameObjectUtils.SetActive(_videoTabContents.gameObject, tab == Tab.Video);
			GameObjectUtils.SetActive(_audioTabContents.gameObject, tab == Tab.Audio);
			GameObjectUtils.SetActive(_controlsTabContents.gameObject, tab == Tab.Controls);
			GameObjectUtils.SetActive(_gameTabContents.gameObject, tab == Tab.Game);
			GameObjectUtils.SetActive(_languageTabContents.gameObject, tab == Tab.Language);
			GameObjectUtils.SetActive(_videoTabFolderBackground.gameObject, tab == Tab.Video);
			GameObjectUtils.SetActive(_audioTabFolderBackground.gameObject, tab == Tab.Audio);
			GameObjectUtils.SetActive(_controlsTabFolderBackground.gameObject, tab == Tab.Controls);
			GameObjectUtils.SetActive(_gameTabFolderBackground.gameObject, tab == Tab.Game);
			GameObjectUtils.SetActive(_languageTabFolderBackground.gameObject, tab == Tab.Language);
			_videoTabButtonAnimator.CurrentState = ((tab == Tab.Video) ? ButtonAnimator.State.Selected : ButtonAnimator.State.Selectable);
			_audioTabButtonAnimator.CurrentState = ((tab == Tab.Audio) ? ButtonAnimator.State.Selected : ButtonAnimator.State.Selectable);
			_controlsTabButtonAnimator.CurrentState = ((tab == Tab.Controls) ? ButtonAnimator.State.Selected : ButtonAnimator.State.Selectable);
			_gameTabButtonAnimator.CurrentState = ((tab == Tab.Game) ? ButtonAnimator.State.Selected : ButtonAnimator.State.Selectable);
			_languageTabButtonAnimator.CurrentState = ((tab == Tab.Language) ? ButtonAnimator.State.Selected : ButtonAnimator.State.Selectable);
			switch (tab)
			{
			case Tab.Video:
				_videoTab.SetAsLastSibling();
				break;
			case Tab.Audio:
				_audioTab.SetAsLastSibling();
				break;
			case Tab.Controls:
				_controlsTab.SetAsLastSibling();
				break;
			case Tab.Game:
				_gameTab.SetAsLastSibling();
				break;
			case Tab.Language:
				_languageTab.SetAsLastSibling();
				break;
			}
			_activeTab = tab;
			RefreshAudioTabContentPanels();
		}

		private void RefreshResolutionOptions()
		{
			List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
			Resolution[] resolutions = Screen.resolutions;
			_validResolutions = ResolutionUtils.SortAndFilterResolutions(resolutions);
			if (_validResolutions != null)
			{
				for (int i = 0; i < _validResolutions.Length; i++)
				{
					Resolution resolution = _validResolutions[i];
					KeyValuePair<int, int> keyValuePair = ResolutionUtils.AspectRatioOfResolution(resolution.width, resolution.height);
					if (keyValuePair.Key != resolution.width)
					{
						list.Add(new TMP_Dropdown.OptionData($"{resolution.width} x {resolution.height} ({keyValuePair.Key}:{keyValuePair.Value})"));
					}
					else
					{
						list.Add(new TMP_Dropdown.OptionData($"{resolution.width} x {resolution.height}"));
					}
				}
			}
			_resolutionDropdown.options = list;
		}

		private void SetupVideoTab()
		{
			List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
			for (int i = 0; i < QualitySettings.names.Length; i++)
			{
				list.Add(new TMP_Dropdown.OptionData("Menu/Preferences/Video/QualitySetting_" + QualitySettings.names[i]));
			}
			_qualitySettingDropdown.options = list;
			_qualitySettingDropdown.gameObject.GetOrAddComponent<LocalizeDropdown>();
			RefreshResolutionOptions();
			_applyResolutionChangesButton.onClick.AddListener(OnResolutionChangeApplyButtonClicked);
			_acceptResolutionChangesButton.onClick.AddListener(OnResolutionChangeAcceptButtonClicked);
			_undoResolutionChangesButton.onClick.AddListener(OnResolutionChangeUndoButtonClicked);
			List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>
			{
				new TMP_Dropdown.OptionData("Menu/Preferences/Video/VSync_Off_CS"),
				new TMP_Dropdown.OptionData("Menu/Preferences/Video/VSync_On_CS")
			};
			_vSyncDropdown.options = options;
			_vSyncDropdown.gameObject.GetOrAddComponent<LocalizeDropdown>();
			List<TMP_Dropdown.OptionData> options2 = new List<TMP_Dropdown.OptionData>
			{
				new TMP_Dropdown.OptionData("Menu/Preferences/Video/TextureQuality_Full_CS"),
				new TMP_Dropdown.OptionData("Menu/Preferences/Video/TextureQuality_Half_CS"),
				new TMP_Dropdown.OptionData("Menu/Preferences/Video/TextureQuality_Quarter_CS"),
				new TMP_Dropdown.OptionData("Menu/Preferences/Video/TextureQuality_Eigth_CS")
			};
			_textureQualityDropdown.options = options2;
			_textureQualityDropdown.gameObject.GetOrAddComponent<LocalizeDropdown>();
			List<TMP_Dropdown.OptionData> options3 = new List<TMP_Dropdown.OptionData>
			{
				new TMP_Dropdown.OptionData("Menu/Preferences/Video/AnisotropicFiltering_" + AnisotropicFiltering.Disable.ToString() + "_CS"),
				new TMP_Dropdown.OptionData("Menu/Preferences/Video/AnisotropicFiltering_" + AnisotropicFiltering.Enable.ToString() + "_CS"),
				new TMP_Dropdown.OptionData("Menu/Preferences/Video/AnisotropicFiltering_" + AnisotropicFiltering.ForceEnable.ToString() + "_CS")
			};
			_anisoTexturesDropdown.options = options3;
			_anisoTexturesDropdown.gameObject.GetOrAddComponent<LocalizeDropdown>();
			List<TMP_Dropdown.OptionData> options4 = new List<TMP_Dropdown.OptionData>
			{
				new TMP_Dropdown.OptionData("Menu/Preferences/Video/ShadowQuality_" + ShadowQuality.Disable.ToString() + "_CS"),
				new TMP_Dropdown.OptionData("Menu/Preferences/Video/ShadowQuality_" + ShadowQuality.HardOnly.ToString() + "_CS"),
				new TMP_Dropdown.OptionData("Menu/Preferences/Video/ShadowQuality_" + ShadowQuality.All.ToString() + "_CS")
			};
			_shadowQualityDropdown.options = options4;
			_shadowQualityDropdown.gameObject.GetOrAddComponent<LocalizeDropdown>();
			List<TMP_Dropdown.OptionData> options5 = new List<TMP_Dropdown.OptionData>
			{
				new TMP_Dropdown.OptionData("Menu/Preferences/Video/ShadowResolution_" + ShadowResolution.Low.ToString() + "_CS"),
				new TMP_Dropdown.OptionData("Menu/Preferences/Video/ShadowResolution_" + ShadowResolution.Medium.ToString() + "_CS"),
				new TMP_Dropdown.OptionData("Menu/Preferences/Video/ShadowResolution_" + ShadowResolution.High.ToString() + "_CS"),
				new TMP_Dropdown.OptionData("Menu/Preferences/Video/ShadowResolution_" + ShadowResolution.VeryHigh.ToString() + "_CS")
			};
			_shadowResolutionDropdown.options = options5;
			_shadowResolutionDropdown.gameObject.GetOrAddComponent<LocalizeDropdown>();
			List<TMP_Dropdown.OptionData> options6 = new List<TMP_Dropdown.OptionData>
			{
				new TMP_Dropdown.OptionData("Menu/Preferences/Video/HospitalLightingQuality_" + LocalPreferences.VideoPreferences.HospitalLightingQualityMode.Low),
				new TMP_Dropdown.OptionData("Menu/Preferences/Video/HospitalLightingQuality_" + LocalPreferences.VideoPreferences.HospitalLightingQualityMode.Medium),
				new TMP_Dropdown.OptionData("Menu/Preferences/Video/HospitalLightingQuality_" + LocalPreferences.VideoPreferences.HospitalLightingQualityMode.High)
			};
			_hospitalLightingQualityDropdown.options = options6;
			_hospitalLightingQualityDropdown.gameObject.GetOrAddComponent<LocalizeDropdown>();
			List<TMP_Dropdown.OptionData> options7 = new List<TMP_Dropdown.OptionData>
			{
				new TMP_Dropdown.OptionData("Menu/Preferences/Video/ShadowFadeDistance_" + LocalPreferences.VideoPreferences.ShadowFadeDistanceMode.Near),
				new TMP_Dropdown.OptionData("Menu/Preferences/Video/ShadowFadeDistance_" + LocalPreferences.VideoPreferences.ShadowFadeDistanceMode.Medium),
				new TMP_Dropdown.OptionData("Menu/Preferences/Video/ShadowFadeDistance_" + LocalPreferences.VideoPreferences.ShadowFadeDistanceMode.Far)
			};
			_shadowFadeDistanceDropdown.options = options7;
			_shadowFadeDistanceDropdown.gameObject.GetOrAddComponent<LocalizeDropdown>();
			List<TMP_Dropdown.OptionData> options8 = new List<TMP_Dropdown.OptionData>
			{
				new TMP_Dropdown.OptionData("Menu/Preferences/Video/LightFadeDistance_" + LocalPreferences.VideoPreferences.LightFadeDistanceMode.Near),
				new TMP_Dropdown.OptionData("Menu/Preferences/Video/LightFadeDistance_" + LocalPreferences.VideoPreferences.LightFadeDistanceMode.Medium),
				new TMP_Dropdown.OptionData("Menu/Preferences/Video/LightFadeDistance_" + LocalPreferences.VideoPreferences.LightFadeDistanceMode.Far)
			};
			_lightFadeDistanceDropdown.options = options8;
			_lightFadeDistanceDropdown.gameObject.GetOrAddComponent<LocalizeDropdown>();
			List<TMP_Dropdown.OptionData> options9 = new List<TMP_Dropdown.OptionData>
			{
				new TMP_Dropdown.OptionData("Menu/Preferences/Video/ParticlesQuality_" + LocalPreferences.VideoPreferences.ParticleQualityMode.Low),
				new TMP_Dropdown.OptionData("Menu/Preferences/Video/ParticlesQuality_" + LocalPreferences.VideoPreferences.ParticleQualityMode.High)
			};
			_particlesQualityDropdown.options = options9;
			_particlesQualityDropdown.gameObject.GetOrAddComponent<LocalizeDropdown>();
			_maximumFPSSlider.minValue = LocalPreferences.VideoPreferences.MinimumMaximumFPS;
			_maximumFPSSlider.maxValue = LocalPreferences.VideoPreferences.MaximumMaximumFPS;
			_lodBiasSlider.minValue = 0f;
			_lodBiasSlider.maxValue = 1f;
			_characterDrawDistanceSlider.minValue = 0f;
			_characterDrawDistanceSlider.maxValue = 1f;
			_resetVideoToDefaultButton.onClick.AddListener(ResetVideoToDefaultClicked);
		}

		private void SetupAudioTab()
		{
			_musicVolumeSlider.onValueChanged.AddListener(delegate(float v)
			{
				_localPreferences.Audio.MusicVolume = v * _localPreferences.Audio.MaxMusicVolume;
			});
			_masterVolumeSlider.onValueChanged.AddListener(delegate(float v)
			{
				_localPreferences.Audio.MasterVolume = v * _localPreferences.Audio.MaxMasterVolume;
			});
			_sfxVolumeSlider.onValueChanged.AddListener(delegate(float v)
			{
				_localPreferences.Audio.SFXVolume = v * _localPreferences.Audio.MaxSFXVolume;
			});
			_tannoyVolumeSlider.onValueChanged.AddListener(delegate(float v)
			{
				_localPreferences.Audio.TannoyVolume = v * _localPreferences.Audio.MaxTannoyVolume;
			});
			_djVolumeSlider.onValueChanged.AddListener(delegate(float v)
			{
				_localPreferences.Audio.DJVolume = v * _localPreferences.Audio.MaxDJVolume;
			});
			_masterVolumeSlider.value = _localPreferences.Audio.MasterVolume / _localPreferences.Audio.MaxMasterVolume;
			_musicVolumeSlider.value = _localPreferences.Audio.MusicVolume / _localPreferences.Audio.MaxMusicVolume;
			_sfxVolumeSlider.value = _localPreferences.Audio.SFXVolume / _localPreferences.Audio.MaxSFXVolume;
			_tannoyVolumeSlider.value = _localPreferences.Audio.TannoyVolume / _localPreferences.Audio.MaxTannoyVolume;
			_djVolumeSlider.value = _localPreferences.Audio.DJVolume / _localPreferences.Audio.MaxDJVolume;
			_resetToDefaultsButton.onPrimaryDown.AddListener(delegate
			{
				_localPreferences.Audio.ResetToDefaultValues();
				ResetAudioToDefault();
			});
			_editPlaylistButton.onPrimaryDown.RemoveAllListeners();
			_togglePlaybackModeButton.onPrimaryDown.RemoveAllListeners();
			_playlistBackButton.onClick.RemoveAllListeners();
			_playlistDefaultsButton.onClick.RemoveAllListeners();
			_editPlaylistButton.onPrimaryDown.AddListener(OnAudioEditPlaylistButton);
			_togglePlaybackModeButton.onPrimaryDown.AddListener(OnAudioTogglePlaybackModeButton);
			_playlistBackButton.onClick.AddListener(OnAudioPlaylistBackButton);
			_playlistDefaultsButton.onClick.AddListener(OnAudioPlaylistDefaultsButton);
			RefreshPlaybackModeButtonText();
			RefreshAudioTabContentPanels();
		}

		private void SetupGameTab()
		{
			List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
			for (int i = 0; i < 5; i++)
			{
				Preferences.GamePreferences.LevelAutoSaveFrequencyOption levelAutoSaveFrequencyOption = (Preferences.GamePreferences.LevelAutoSaveFrequencyOption)i;
				list.Add(new TMP_Dropdown.OptionData("Menu/Preferences/Game/LevelAutoSaveFrequency_" + levelAutoSaveFrequencyOption));
			}
			_levelAutoSaveFrequencyDropdown.options = list;
			_levelAutoSaveFrequencyDropdown.gameObject.GetOrAddComponent<LocalizeDropdown>();
			_levelAutoSaveFrequencyDropdown.value = (int)_preferences.Game.LevelAutoSaveFrequency;
			_levelAutoSaveFrequencyDropdown.onValueChanged.AddListener(delegate(int value)
			{
				_preferences.Game.LevelAutoSaveFrequency = (Preferences.GamePreferences.LevelAutoSaveFrequencyOption)value;
			});
			List<TMP_Dropdown.OptionData> list2 = new List<TMP_Dropdown.OptionData>();
			for (int num = 0; num < 4; num++)
			{
				Preferences.GamePreferences.CareerAutoSaveFrequencyOption careerAutoSaveFrequencyOption = (Preferences.GamePreferences.CareerAutoSaveFrequencyOption)num;
				list2.Add(new TMP_Dropdown.OptionData("Menu/Preferences/Game/CareerAutoSaveFrequency_" + careerAutoSaveFrequencyOption));
			}
			_careerAutoSaveFrequencyDropdown.options = list2;
			_careerAutoSaveFrequencyDropdown.gameObject.GetOrAddComponent<LocalizeDropdown>();
			_careerAutoSaveFrequencyDropdown.value = (int)_preferences.Game.CareerAutoSaveFrequency;
			_careerAutoSaveFrequencyDropdown.onValueChanged.AddListener(delegate(int value)
			{
				_preferences.Game.CareerAutoSaveFrequency = (Preferences.GamePreferences.CareerAutoSaveFrequencyOption)value;
			});
			List<TMP_Dropdown.OptionData> list3 = new List<TMP_Dropdown.OptionData>();
			for (int num2 = 0; num2 < Preferences.GamePreferences.NumberOfRollingSavesOptions.Length; num2++)
			{
				list3.Add(new TMP_Dropdown.OptionData(Preferences.GamePreferences.NumberOfRollingSavesOptions[num2].ToString()));
			}
			_numberOfAutoSavesDropdown.options = list3;
			_numberOfAutoSavesDropdown.value = _preferences.Game.NumberOfRollingSavesToKeepIndex;
			_numberOfAutoSavesDropdown.onValueChanged.AddListener(delegate(int value)
			{
				_preferences.Game.NumberOfRollingSavesToKeepIndex = value;
			});
			GameObjectUtils.SetActive(_numberOfAutoSavesLayoutElement, PlatformFileManager.UsesVariableBackupSaveAmount);
			_autoSaveOnLevelChangeToggle.isOn = _preferences.Game.AutoSaveOnLevelChange;
			_autoSaveOnLevelChangeToggle.onValueChanged.AddListener(delegate(bool value)
			{
				_preferences.Game.AutoSaveOnLevelChange = value;
			});
			_onlineVisibilityToggle.interactable = OnlineManager.IsInitializedAndLoggedOn();
			_onlineVisibilityToggle.isOn = _preferences.Game.OnlineVisibility && _onlineVisibilityToggle.interactable;
			_onlineVisibilityToggle.onValueChanged.AddListener(delegate(bool value)
			{
				_preferences.Game.OnlineVisibility = value;
			});
			GameObjectUtils.SetActive(_onlineLayoutElement, PlatformFeatureSupport.IsFeatureSupported(PlatformFeatureSupport.FeatureType.CollaborativeProject));
			List<TMP_Dropdown.OptionData> list4 = new List<TMP_Dropdown.OptionData>();
			list4.Add(new TMP_Dropdown.OptionData("Menu/Preferences/GUI/Advisor/Show_Everything"));
			list4.Add(new TMP_Dropdown.OptionData("Menu/Preferences/GUI/Advisor/No_Low_Priority"));
			list4.Add(new TMP_Dropdown.OptionData("Menu/Preferences/GUI/Advisor/High_Priority"));
			list4.Add(new TMP_Dropdown.OptionData("Menu/Preferences/GUI/Advisor/Very_High_Priority"));
			list4.Add(new TMP_Dropdown.OptionData("Menu/Preferences/GUI/Advisor/None"));
			_advisorFilterDropdown.options = list4;
			_advisorFilterDropdown.gameObject.GetOrAddComponent<LocalizeDropdown>();
			_advisorFilterDropdown.onValueChanged.RemoveAllListeners();
			_advisorFilterDropdown.value = (int)_preferences.Game.AdvisorFilter;
			_advisorFilterDropdown.onValueChanged.AddListener(delegate(int value)
			{
				_preferences.Game.AdvisorFilter = (Preferences.GamePreferences.AdvisorFilterOption)value;
			});
			List<TMP_Dropdown.OptionData> list5 = new List<TMP_Dropdown.OptionData>();
			for (int num3 = 0; num3 < 6; num3++)
			{
				if (LogLevelHelpers.IsLogLevelCompiledIn((LogLevel)num3) && num3 != 5)
				{
					LogLevel logLevel = (LogLevel)num3;
					list5.Add(new TMP_Dropdown.OptionData("Menu/Preferences/Game/LogLevel_Value_" + logLevel));
				}
			}
			_logLevelDropdown.options = list5;
			_logLevelDropdown.gameObject.GetOrAddComponent<LocalizeDropdown>();
			_logLevelDropdown.onValueChanged.RemoveAllListeners();
			_logLevelDropdown.value = _preferences.Game.LogLevel - LogLevelHelpers.LowestLogLevelCompiledIn;
			_logLevelDropdown.onValueChanged.AddListener(LogLevelDropdownChanged);
			_lwaElement.SetActive(value: false);
			_lwaInstructions.SetActive(value: false);
			_lwaConfirmation.SetActive(value: false);
			_lwaError.SetActive(value: false);
			_workshopWikiButton.onPrimaryDown.RemoveAllListeners();
			_workshopWikiButton.onPrimaryDown.AddListener(OnWorkshopWikiButton);
		}

		private void LogLevelDropdownChanged(int value)
		{
			_preferences.Game.LogLevel = value + LogLevelHelpers.LowestLogLevelCompiledIn;
		}

		private void SetupLoginWithPrime()
		{
			CloudData downloadedCloudData = _cloudDataManager.DownloadedCloudData;
			if (downloadedCloudData != null && downloadedCloudData.PrimePromotionAvailableForSignUp)
			{
				_lwaElement.SetActive(value: true);
				_lwaButtonAnim.CurrentState = (_primeGaming.LoggedInWithPrime ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
				_lwaButton.onPrimaryDown.RemoveAllListeners();
				_lwaButton.onPrimaryDown.AddListener(OnLoginWithPrime);
				_lwaOKButton.onPrimaryDown.RemoveAllListeners();
				_lwaOKButton.onPrimaryDown.AddListener(OnCancelLoginWithPrime);
				_lwaCopyButton.onPrimaryDown.RemoveAllListeners();
				_lwaCopyButton.onPrimaryDown.AddListener(OnCopyCodeWithPrime);
				_lwaHyperlink.onPrimaryDown.RemoveAllListeners();
				_lwaHyperlink.onPrimaryDown.AddListener(OnFollowLinkWithPrime);
				_lwaRestartButton.onPrimaryDown.RemoveAllListeners();
				_lwaRestartButton.onPrimaryDown.AddListener(OnRestartWithPrime);
				_lwaCancelButton.onPrimaryDown.RemoveAllListeners();
				_lwaCancelButton.onPrimaryDown.AddListener(OnCancelRestartWithPrime);
				_lwaDismissButtton.onPrimaryDown.RemoveAllListeners();
				_lwaDismissButtton.onPrimaryDown.AddListener(OnDismissErrorWithPrime);
			}
		}

		private void OnLoginWithPrime()
		{
			_lwaInstructions.SetActive(value: true);
			_primeGaming.LoginWithPrime(_lwaLinkText, _lwaCodeText, delegate
			{
				_lwaConfirmation.SetActive(value: true);
				_lwaInstructions.SetActive(value: false);
			}, delegate
			{
				_lwaError.SetActive(value: true);
				_lwaInstructions.SetActive(value: false);
				_lwaConfirmation.SetActive(value: false);
			});
		}

		private void OnCancelLoginWithPrime()
		{
			_lwaInstructions.SetActive(value: false);
			_primeGaming.CancelAllRequests();
		}

		private void OnRestartWithPrime()
		{
			_lwaConfirmation.SetActive(value: false);
			_primeGaming.RestartGame();
		}

		private void OnCancelRestartWithPrime()
		{
			_lwaConfirmation.SetActive(value: false);
		}

		private void OnDismissErrorWithPrime()
		{
			_lwaError.SetActive(value: false);
			_primeGaming.CancelAllRequests();
		}

		private void OnCopyCodeWithPrime()
		{
			if (_lwaCodeText.text.Length > 0)
			{
				GUIUtility.systemCopyBuffer = _lwaCodeText.text;
			}
		}

		private void OnFollowLinkWithPrime()
		{
			if (_lwaLinkText.text.Length > 0)
			{
				Application.OpenURL(_lwaLinkText.text);
			}
		}

		private void OnWorkshopWikiButton()
		{
			string text = "https://wiki.twopointstudios.com/Main_Page";
			if (OnlineManager.IsInitialized() && SteamUtils.IsOverlayEnabled())
			{
				SteamFriends.ActivateGameOverlayToWebPage(text);
			}
			else
			{
				Application.OpenURL(text);
			}
		}

		private void SetupControlsTab()
		{
			_bindingScreen.SetActive(value: false);
			_mouseDirectionRotateItemToggle.isOn = _preferences.Control.MouseDirectionItemRotation;
			_mouseDirectionRotateItemToggle.onValueChanged.AddListener(delegate(bool value)
			{
				_preferences.Control.MouseDirectionItemRotation = value;
			});
			_useRoomItemSnapToggle.isOn = _preferences.Control.UseRoomItemSnap;
			_useRoomItemSnapToggle.onValueChanged.AddListener(delegate(bool value)
			{
				_preferences.Control.UseRoomItemSnap = value;
			});
			_useWallMagnetismToggle.isOn = _preferences.Control.UseWallMagnetism;
			_useWallMagnetismToggle.onValueChanged.AddListener(delegate(bool value)
			{
				_preferences.Control.UseWallMagnetism = value;
			});
			_enableEdgeScrollingToggle.isOn = _preferences.Control.EnableEdgeScrolling;
			_enableEdgeScrollingToggle.onValueChanged.AddListener(delegate(bool value)
			{
				_preferences.Control.EnableEdgeScrolling = value;
			});
			_resetKeyboardBindingsButton.onPrimaryDown.AddListener(delegate
			{
				ReInput.players.GetPlayer(0).controllers.maps.LoadDefaultMaps(ControllerType.Keyboard);
				_preferences.Control.RewiredKeyboardMapXML = null;
				_preferences.Control.LocaliseMappings(_controlBindingsLocalisationParamsManager);
				RebuildKeyboardBindingsTable();
			});
			RebuildKeyboardBindingsTable();
		}

		private void SetupLanguageTab()
		{
			List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
			for (int i = 0; i < 11; i++)
			{
				list.Add(new TMP_Dropdown.OptionData("Menu/Preferences/Language/" + Preferences.LanguagePreferences.LanguageCode[i]));
			}
			_languageDropdown.options = list;
			_languageDropdown.gameObject.GetOrAddComponent<LocalizeDropdown>();
			List<TMP_Dropdown.OptionData> list2 = new List<TMP_Dropdown.OptionData>();
			for (int j = 0; j < 3; j++)
			{
				list2.Add(new TMP_Dropdown.OptionData("Menu/Preferences/Language/" + Preferences.LanguagePreferences.AudioLanguageCode[j]));
			}
			_languageAudioDropdown.options = list2;
			_languageAudioDropdown.gameObject.GetOrAddComponent<LocalizeDropdown>();
		}

		private void RebuildKeyboardBindingsTable()
		{
			foreach (RectTransform row in _keyboardBindingsTable.Rows)
			{
				UnityEngine.Object.Destroy(row.gameObject);
			}
			IList<ControllerMap> maps = ReInput.players.GetPlayer(0).controllers.maps.GetMaps(ControllerType.Keyboard, 0);
			ControllerMap keyboardMap = ((maps.Count > 0) ? maps[0] : null);
			_visibleInputAcions.Clear();
			_visibleInputAcions.AddRange(ReInput.mapping.ActionsInCategory("Camera", sort: true));
			_visibleInputAcions.AddRange(ReInput.mapping.ActionsInCategory("Default", sort: true));
			_visibleInputAcions.AddRange(ReInput.mapping.ActionsInCategory("Build Room", sort: true));
			_visibleInputAcions.AddRange(ReInput.mapping.ActionsInCategory("HUD", sort: true));
			_visibleInputAcions.RemoveAll((InputAction a) => !IsActionMappableByUser(a));
			bool flag = false;
			foreach (InputAction inputAction in _visibleInputAcions)
			{
				KeyboardBindingsRow component = _keyboardBindingsTable.InstantiateAsRow(_keyboardBindingRowPrefab).GetComponent<KeyboardBindingsRow>();
				component.Setup(inputAction, keyboardMap, _visibleInputAcions);
				component.KeyboardBindingButton0.onPrimaryDown.AddListener(delegate
				{
					PollKeyboard(inputAction, 0);
				});
				component.KeyboardBindingButton1.onPrimaryDown.AddListener(delegate
				{
					PollKeyboard(inputAction, 1);
				});
				flag = flag || component.HasConflicts;
			}
			_keyboardBindingConflictWarning.SetActive(flag);
		}

		private bool IsActionMappableByUser(InputAction inputAction)
		{
			if (inputAction.userAssignable)
			{
				return inputAction.type == InputActionType.Button;
			}
			return false;
		}

		protected void Update()
		{
			if (_pollingInputAction != null)
			{
				Player player = ReInput.players.GetPlayer(0);
				Keyboard keyboard = player.controllers.Keyboard;
				IList<ControllerMap> maps = player.controllers.maps.GetMaps(ControllerType.Keyboard, 0);
				if (maps.Count == 0)
				{
					return;
				}
				ControllerMap controllerMap = maps[0];
				ControllerPollingInfo pollingInfo = keyboard.PollForFirstButtonDown();
				if (pollingInfo.success && pollingInfo.keyboardKey != KeyCode.Print && pollingInfo.keyboardKey != KeyCode.LeftCommand && pollingInfo.keyboardKey != KeyCode.RightCommand && pollingInfo.keyboardKey != KeyCode.LeftWindows && pollingInfo.keyboardKey != KeyCode.LeftWindows)
				{
					ActionElementMap[] elementMapsWithAction = controllerMap.GetElementMapsWithAction(_pollingInputAction.id);
					if (pollingInfo.keyboardKey == KeyCode.Escape)
					{
						Logging.Info(LogChannels.Preferences, "Escape pressed; clearing mapping");
						if (elementMapsWithAction != null && _pollingMapNumber < elementMapsWithAction.Length && !controllerMap.DeleteElementMap(elementMapsWithAction[_pollingMapNumber].id))
						{
							Logging.Warning(LogChannels.Preferences, "Failed to delete ActionElementMap from controller map, whilst clearing assignment");
						}
					}
					else
					{
						Logging.Info(LogChannels.Preferences, "User pressed key; attempting to assign {0} to action {1} ({2})", pollingInfo.keyboardKey, _pollingInputAction.id, _pollingInputAction.descriptiveName);
						List<ActionElementMap> list = new List<ActionElementMap>(8);
						controllerMap.GetButtonMapMatches((ActionElementMap map) => _visibleInputAcions.Find((InputAction a) => a.id == map.actionId) != null && map.keyCode == pollingInfo.keyboardKey, list);
						foreach (ActionElementMap item in list)
						{
							Logging.Info(LogChannels.Preferences, "Removing conflicting mapping to action {0} ({1})", item.actionId, item.actionDescriptiveName);
							if (!controllerMap.DeleteElementMap(item.id))
							{
								Logging.Warning(LogChannels.Preferences, "Failed to delete ActionElementMap from controller map, whilst clearing conflicting maps");
							}
						}
						int elementMapId = -1;
						if (elementMapsWithAction != null && _pollingMapNumber < elementMapsWithAction.Length)
						{
							elementMapId = elementMapsWithAction[_pollingMapNumber].id;
						}
						ElementAssignment elementAssignment = new ElementAssignment(ControllerType.Keyboard, ControllerElementType.Button, pollingInfo.elementIdentifierId, AxisRange.Full, pollingInfo.keyboardKey, ModifierKeyFlags.None, _pollingInputAction.id, Pole.Positive, invert: false, elementMapId);
						if (!controllerMap.ReplaceOrCreateElementMap(elementAssignment))
						{
							Logging.Warning(LogChannels.Preferences, "Failed to replace or create ActionElementMap whilst assigning new key");
						}
					}
					Logging.Info(LogChannels.Preferences, "Setting new ReWired XML string in Preferences");
					_preferences.Control.RewiredKeyboardMapXML = controllerMap.ToXmlString();
					_preferences.Control.UpdateBindingLocalisation(_controlBindingsLocalisationParamsManager);
					_pollingInputAction = null;
					RebuildKeyboardBindingsTable();
					_bindingScreen.SetActive(value: false);
				}
			}
			if (_lwaInstructions.activeSelf)
			{
				if (_lwaCodeText.text.Length > 0 && GUIUtility.systemCopyBuffer == _lwaCodeText.text)
				{
					_lwaCopyButtonAnim.CurrentState = ButtonAnimator.State.Unselectable;
				}
				else
				{
					_lwaCopyButtonAnim.CurrentState = ButtonAnimator.State.Selectable;
				}
			}
		}

		private void PollKeyboard(InputAction inputAction, int mapNumber)
		{
			_pollingInputAction = inputAction;
			_pollingMapNumber = mapNumber;
			_bindingScreen.SetActive(value: true);
			string translation = LocalizationManager.GetTranslation(inputAction.descriptiveName, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters: true);
			_bindingActionText.text = _bindingActionString.Translation.Replace("\\n", "\n").Replace("{[ACTION]}", translation);
		}

		private IEnumerator DelayedSettingsChange(Action delayedAction)
		{
			_reloadingTexturesScreen.SetActive(value: true);
			yield return null;
			delayedAction();
			_reloadingTexturesScreen.SetActive(value: false);
		}

		private void QualityDropdownChanged(int value)
		{
			_behaviourToRunCoroutinesOn.StartCoroutine(DelayedSettingsChange(delegate
			{
				_localPreferences.Video.QualitySettingsIndex = value;
				SetVideoCustomSettingControlValuesToCurrent();
			}));
		}

		private void ResolutionDropdownChanged(int value)
		{
			_applyResolutionChangesButton.interactable = true;
		}

		private void FullScreenToggleChanged(bool isOn)
		{
			_applyResolutionChangesButton.interactable = true;
		}

		private void AmbientOcclusionToggleChanged(bool isOn)
		{
			_localPreferences.Video.AmbientOcclusion = isOn;
		}

		private void BloomToggleChanged(bool isOn)
		{
			_localPreferences.Video.Bloom = isOn;
		}

		private void DepthOfFieldToggleChanged(bool isOn)
		{
			_localPreferences.Video.DepthOfField = isOn;
		}

		private void AntialiasingToggleChanged(bool isOn)
		{
			_localPreferences.Video.Antialiasing = isOn;
		}

		private void MaximumFPSSliderChanged(float value)
		{
			_localPreferences.Video.MaximumFPS = (int)value;
			_maximumFPSValueLabel.text = ((int)value).ToString();
		}

		private void LodBiasSliderChanged(float value)
		{
			_localPreferences.Video.CustomLODBias = LocalPreferences.VideoPreferences.LODBiasFrom0To1(value);
			_lodBiasValueLabel.text = ((int)(value * 100f)).ToString();
		}

		private void CharacterDrawDistanceSliderChanged(float value)
		{
			_localPreferences.Video.CharacterDrawDistance = value;
			_characterDrawDistanceValueLabel.text = ((int)(value * 100f)).ToString();
		}

		private void OnResolutionChangeApplyButtonClicked()
		{
			_resolutionBeforeChange = new Resolution
			{
				width = Screen.width,
				height = Screen.height,
				refreshRate = Screen.currentResolution.refreshRate
			};
			_wasFullScreenBeforeChange = Screen.fullScreen;
			Logging.Info(LogChannels.Preferences, "Resolution change requested, from {0}x{1}@{2}Hz ({3}) to {4}x{5}@{6}Hz ({7})", _resolutionBeforeChange.width, _resolutionBeforeChange.height, _resolutionBeforeChange.refreshRate, _wasFullScreenBeforeChange ? "Fullscreen" : "Windowed", _validResolutions[_resolutionDropdown.value].width, _validResolutions[_resolutionDropdown.value].height, _validResolutions[_resolutionDropdown.value].refreshRate, _fullScreenToggle.isOn ? "Fullscreen" : "Windowed");
			Screen.SetResolution(_validResolutions[_resolutionDropdown.value].width, _validResolutions[_resolutionDropdown.value].height, _fullScreenToggle.isOn, _validResolutions[_resolutionDropdown.value].refreshRate);
			_applyResolutionChangesButton.interactable = false;
			_acceptResolutionChangesScreen.gameObject.SetActive(value: true);
			_waitForResolutionChangeConfirmationCoroutine = StartCoroutine(WaitForResolutionChangeConfirmation());
		}

		private void OnResolutionChangeAcceptButtonClicked()
		{
			Logging.Info(LogChannels.Preferences, "User accepted resolution change");
			StopCoroutine(_waitForResolutionChangeConfirmationCoroutine);
			_waitForResolutionChangeConfirmationCoroutine = null;
			_acceptResolutionChangesScreen.gameObject.SetActive(value: false);
		}

		private void OnResolutionChangeUndoButtonClicked()
		{
			Logging.Info(LogChannels.Preferences, "User clicked 'undo'");
			UndoResolutionChange();
			StopCoroutine(_waitForResolutionChangeConfirmationCoroutine);
			_waitForResolutionChangeConfirmationCoroutine = null;
			_acceptResolutionChangesScreen.gameObject.SetActive(value: false);
		}

		private void UndoResolutionChange()
		{
			Logging.Info(LogChannels.Preferences, "Undoing resolution change");
			Screen.SetResolution(_resolutionBeforeChange.width, _resolutionBeforeChange.height, _wasFullScreenBeforeChange, _resolutionBeforeChange.refreshRate);
			_resolutionDropdown.onValueChanged.RemoveListener(ResolutionDropdownChanged);
			_resolutionDropdown.value = ResolutionUtils.CurrentOrClosestResolutionIndex(_validResolutions, _resolutionBeforeChange);
			_resolutionDropdown.onValueChanged.AddListener(ResolutionDropdownChanged);
			_fullScreenToggle.onValueChanged.RemoveListener(FullScreenToggleChanged);
			_fullScreenToggle.isOn = _wasFullScreenBeforeChange;
			_fullScreenToggle.onValueChanged.AddListener(FullScreenToggleChanged);
		}

		private IEnumerator WaitForResolutionChangeConfirmation()
		{
			int i = _secondsToWaitForResolutionChangeConfirmation;
			while (i >= 0)
			{
				_resolutionChangesTimeoutText.text = ScriptLocalization.Menu_Preferences_Video.ResolutionChanged_Timeout_CS.Replace("[{0}]", i.ToString());
				yield return new WaitForSecondsRealtime(1f);
				int num = i - 1;
				i = num;
			}
			Logging.Info(LogChannels.Preferences, "Resolution change timed out; undoing");
			UndoResolutionChange();
			_waitForResolutionChangeConfirmationCoroutine = null;
			_acceptResolutionChangesScreen.gameObject.SetActive(value: false);
		}

		private void VSyncDropdownChanged(int value)
		{
			_localPreferences.Video.CustomVSyncCount = value;
		}

		private void AnisoDropdownChanged(int value)
		{
			_localPreferences.Video.CustomAnisotropicFiltering = (AnisotropicFiltering)value;
		}

		private void ShadowQualityDropdownChanged(int value)
		{
			_localPreferences.Video.CustomShadowQuality = (ShadowQuality)value;
		}

		private void ShadowResolutionDropdownChanged(int value)
		{
			_localPreferences.Video.CustomShadowResolution = (ShadowResolution)value;
		}

		private void HospitalLightingQualityChanged(int value)
		{
			_localPreferences.Video.HospitalLightingQuality = (LocalPreferences.VideoPreferences.HospitalLightingQualityMode)value;
		}

		private void ParticlesQualityChanged(int value)
		{
			_localPreferences.Video.Particles = (LocalPreferences.VideoPreferences.ParticleQualityMode)value;
		}

		private void TextureQualityDropdownChanged(int value)
		{
			_behaviourToRunCoroutinesOn.StartCoroutine(DelayedSettingsChange(delegate
			{
				_localPreferences.Video.CustomMasterTextureLimit = value;
			}));
		}

		private void ShadowFadeDistanceDropdownChanged(int value)
		{
			_localPreferences.Video.ShadowFadeDistance = (LocalPreferences.VideoPreferences.ShadowFadeDistanceMode)value;
		}

		private void LightFadeDistanceDropdownChanged(int value)
		{
			_localPreferences.Video.LightFadeDistance = (LocalPreferences.VideoPreferences.LightFadeDistanceMode)value;
		}

		private void ResetVideoToDefaultClicked()
		{
			_localPreferences.Video.ResetToBaseQualityLevel();
			SetVideoCustomSettingControlValuesToCurrent();
		}

		private void LanguageDropdownChanged(int value)
		{
			_preferences.Language.SelectedLanguage = (Preferences.LanguagePreferences.Language)value;
			_languageAudioDropdown.value = (int)Preferences.LanguagePreferences.AudioLanguageFromLanguage((Preferences.LanguagePreferences.Language)value);
		}

		private void AudioLanguageDropdownChanged(int value)
		{
			_preferences.Language.SelectedAudioLanguage = (Preferences.LanguagePreferences.AudioLanguage)value;
		}

		private bool ShouldShowTooltip()
		{
			return !_creditsPlaying;
		}

		public void Show()
		{
			base.gameObject.SetActive(value: true);
			TooltipManager.Instance.PushGUIRoot(base.transform);
			TooltipSpawner[] componentsInChildren = GetComponentsInChildren<TooltipSpawner>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].SetShouldShowFunc(ShouldShowTooltip);
			}
			_qualitySettingDropdown.onValueChanged.RemoveListener(QualityDropdownChanged);
			_qualitySettingDropdown.value = _localPreferences.Video.QualitySettingsIndex;
			_qualitySettingDropdown.onValueChanged.AddListener(QualityDropdownChanged);
			_resolutionDropdown.onValueChanged.RemoveListener(ResolutionDropdownChanged);
			_resolutionDropdown.value = ResolutionUtils.CurrentOrClosestResolutionIndex(_validResolutions);
			_resolutionDropdown.onValueChanged.AddListener(ResolutionDropdownChanged);
			_fullScreenToggle.onValueChanged.RemoveListener(FullScreenToggleChanged);
			_fullScreenToggle.isOn = Screen.fullScreen;
			_fullScreenToggle.onValueChanged.AddListener(FullScreenToggleChanged);
			_applyResolutionChangesButton.interactable = false;
			RefreshResolutionOptions();
			SetVideoCustomSettingControlValuesToCurrent();
			SetupLoginWithPrime();
			_languageDropdown.onValueChanged.RemoveListener(LanguageDropdownChanged);
			_languageDropdown.value = (int)_preferences.Language.SelectedLanguage;
			_languageDropdown.onValueChanged.AddListener(LanguageDropdownChanged);
			_languageAudioDropdown.onValueChanged.RemoveListener(AudioLanguageDropdownChanged);
			_languageAudioDropdown.value = (int)_preferences.Language.SelectedAudioLanguage;
			_languageAudioDropdown.onValueChanged.AddListener(AudioLanguageDropdownChanged);
			LocalizationManager.OnLocalizeEvent += OnLocalize;
			_playlistEditModeUI?.SetVisible(_activeTab == Tab.Audio && _bPlaylistEditModeOn);
		}

		private void SetVideoCustomSettingControlValuesToCurrent()
		{
			_vSyncDropdown.onValueChanged.RemoveListener(VSyncDropdownChanged);
			_vSyncDropdown.value = QualitySettings.vSyncCount;
			_vSyncDropdown.onValueChanged.AddListener(VSyncDropdownChanged);
			_anisoTexturesDropdown.onValueChanged.RemoveListener(AnisoDropdownChanged);
			_anisoTexturesDropdown.value = (int)QualitySettings.anisotropicFiltering;
			_anisoTexturesDropdown.onValueChanged.AddListener(AnisoDropdownChanged);
			_shadowQualityDropdown.onValueChanged.RemoveListener(ShadowQualityDropdownChanged);
			_shadowQualityDropdown.value = (int)QualitySettings.shadows;
			_shadowQualityDropdown.onValueChanged.AddListener(ShadowQualityDropdownChanged);
			_shadowResolutionDropdown.onValueChanged.RemoveListener(ShadowResolutionDropdownChanged);
			_shadowResolutionDropdown.value = (int)QualitySettings.shadowResolution;
			_shadowResolutionDropdown.onValueChanged.AddListener(ShadowResolutionDropdownChanged);
			_shadowFadeDistanceDropdown.onValueChanged.RemoveListener(ShadowFadeDistanceDropdownChanged);
			_shadowFadeDistanceDropdown.value = (int)_localPreferences.Video.ShadowFadeDistance;
			_shadowFadeDistanceDropdown.onValueChanged.AddListener(ShadowFadeDistanceDropdownChanged);
			_lightFadeDistanceDropdown.onValueChanged.RemoveListener(LightFadeDistanceDropdownChanged);
			_lightFadeDistanceDropdown.value = (int)_localPreferences.Video.LightFadeDistance;
			_lightFadeDistanceDropdown.onValueChanged.AddListener(LightFadeDistanceDropdownChanged);
			_hospitalLightingQualityDropdown.onValueChanged.RemoveListener(HospitalLightingQualityChanged);
			_hospitalLightingQualityDropdown.value = (int)_localPreferences.Video.HospitalLightingQuality;
			_hospitalLightingQualityDropdown.onValueChanged.AddListener(HospitalLightingQualityChanged);
			_particlesQualityDropdown.onValueChanged.RemoveListener(ParticlesQualityChanged);
			_particlesQualityDropdown.value = (int)_localPreferences.Video.Particles;
			_particlesQualityDropdown.onValueChanged.AddListener(ParticlesQualityChanged);
			_textureQualityDropdown.onValueChanged.RemoveListener(TextureQualityDropdownChanged);
			_textureQualityDropdown.value = QualitySettings.masterTextureLimit;
			_textureQualityDropdown.onValueChanged.AddListener(TextureQualityDropdownChanged);
			_ambientOcclusionToggle.onValueChanged.RemoveListener(AmbientOcclusionToggleChanged);
			_ambientOcclusionToggle.isOn = _localPreferences.Video.AmbientOcclusion;
			_ambientOcclusionToggle.onValueChanged.AddListener(AmbientOcclusionToggleChanged);
			_bloomToggle.onValueChanged.RemoveListener(BloomToggleChanged);
			_bloomToggle.isOn = _localPreferences.Video.Bloom;
			_bloomToggle.onValueChanged.AddListener(BloomToggleChanged);
			_depthOfFieldToggle.onValueChanged.RemoveListener(DepthOfFieldToggleChanged);
			_depthOfFieldToggle.isOn = _localPreferences.Video.DepthOfField;
			_depthOfFieldToggle.onValueChanged.AddListener(DepthOfFieldToggleChanged);
			_antialiasingToggle.onValueChanged.RemoveListener(AntialiasingToggleChanged);
			_antialiasingToggle.isOn = _localPreferences.Video.Antialiasing;
			_antialiasingToggle.onValueChanged.AddListener(AntialiasingToggleChanged);
			_maximumFPSSlider.onValueChanged.RemoveListener(MaximumFPSSliderChanged);
			_maximumFPSSlider.value = _localPreferences.Video.MaximumFPS;
			_maximumFPSValueLabel.text = _localPreferences.Video.MaximumFPS.ToString();
			_maximumFPSSlider.onValueChanged.AddListener(MaximumFPSSliderChanged);
			_lodBiasSlider.onValueChanged.RemoveListener(LodBiasSliderChanged);
			_lodBiasSlider.value = LocalPreferences.VideoPreferences.LODBiasAs0To1(_localPreferences.Video.ActiveLODBias);
			_lodBiasValueLabel.text = ((int)(LocalPreferences.VideoPreferences.LODBiasAs0To1(_localPreferences.Video.ActiveLODBias) * 100f)).ToString();
			_lodBiasSlider.onValueChanged.AddListener(LodBiasSliderChanged);
			_characterDrawDistanceSlider.onValueChanged.RemoveListener(CharacterDrawDistanceSliderChanged);
			_characterDrawDistanceSlider.value = _localPreferences.Video.CharacterDrawDistance;
			_characterDrawDistanceValueLabel.text = ((int)(_localPreferences.Video.CharacterDrawDistance * 100f)).ToString();
			_characterDrawDistanceSlider.onValueChanged.AddListener(CharacterDrawDistanceSliderChanged);
		}

		public void CloseMenu()
		{
			TooltipManager.Instance.PopGUIRoot(base.transform);
			_bPlaylistEditModeOn = false;
			_playlistEditModeUI?.SetVisible(bVisible: false);
			SetTabActive(Tab.Video);
			base.gameObject.SetActive(value: false);
			LocalizationManager.OnLocalizeEvent -= OnLocalize;
		}

		public void CloseAndSavePreferences()
		{
			Logging.Info(LogChannels.Preferences, "Closing and saving preferences screen");
			_preferences.SaveToFile();
			_localPreferences.SaveToFile();
			CloseMenu();
		}

		private void CreditsButtonClicked()
		{
			GameObject original = _creditsScreenPrefab;
			_extContentGameItemCreditsScreen = null;
			if (_extContentManager != null)
			{
				_extContentGameItemCreditsScreen = _extContentManager.GetMostRecentCreditsScreenGameItem();
				if (_extContentGameItemCreditsScreen != null)
				{
					original = _extContentManager.GetCreditsScreenPrefabOverride(_extContentGameItemCreditsScreen, _creditsScreenPrefab);
				}
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(original, base.transform, worldPositionStays: false);
			_creditsScreen = gameObject.GetComponent<CreditsScreen>();
			if (_creditsScreen != null)
			{
				CreditsScreen creditsScreen = _creditsScreen;
				creditsScreen.OnCreditsStatusChange = (Action<bool>)Delegate.Combine(creditsScreen.OnCreditsStatusChange, new Action<bool>(OnCreditsStatusChange));
			}
		}

		private void OnCreditsStatusChange(bool bIsPlaying)
		{
			_creditsPlaying = bIsPlaying;
			if (!bIsPlaying)
			{
				_extContentGameItemCreditsScreen?.UnloadDataAssetBundle();
				_extContentGameItemCreditsScreen = null;
				if (_creditsScreen != null)
				{
					CreditsScreen creditsScreen = _creditsScreen;
					creditsScreen.OnCreditsStatusChange = (Action<bool>)Delegate.Remove(creditsScreen.OnCreditsStatusChange, new Action<bool>(OnCreditsStatusChange));
				}
			}
			_playlistEditModeUI?.SetVisible(!bIsPlaying && _activeTab == Tab.Audio && _bPlaylistEditModeOn);
		}

		private void OnAudioEditPlaylistButton()
		{
			_bPlaylistEditModeOn = !_bPlaylistEditModeOn;
			if (_bPlaylistEditModeOn && _playlistEditModePanelGameObject == null && _audioTabPlaylistPanelPrefab != null && _audioTabPlaylistPanel != null)
			{
				_playlistEditModePanelGameObject = UnityEngine.Object.Instantiate(_audioTabPlaylistPanelPrefab, _audioTabPlaylistPanel.transform);
				if (_playlistEditModePanelGameObject != null)
				{
					_playlistEditModeUI = _playlistEditModePanelGameObject.GetComponent<DynamicPlaylistUI>();
					_playlistEditModeUI.Init(_dynamicPlaylistManager, base.gameObject, _messageBox);
				}
			}
			RefreshAudioTabContentPanels();
		}

		private void OnAudioTogglePlaybackModeButton()
		{
			_dynamicPlaylistManager.PlaybackMode = ((_dynamicPlaylistManager.PlaybackMode == DynamicPlaylistManager.EPlaybackMode.Sequential) ? DynamicPlaylistManager.EPlaybackMode.Shuffle : DynamicPlaylistManager.EPlaybackMode.Sequential);
			_dynamicPlaylistManager.SetSaveToFilePending();
			RefreshPlaybackModeButtonText();
		}

		private void OnAudioPlaylistBackButton()
		{
			OnAudioEditPlaylistButton();
		}

		private void OnAudioPlaylistDefaultsButton()
		{
			if (!(_messageBox == null))
			{
				if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
				{
					_messageBox.SetUseNonFrostedPanelData(bUseNonFrostedPanelData: true);
					_messageBox.ShowAsYesNo(ExtContentMessages.GetMessageString(EMessageType.DynamicPlaylistResetMessageTitle), ExtContentMessages.GetMessageString(EMessageType.DynamicPlaylistResetMessageBody), ScriptLocalization.Menu_Messages.Yes_Button_CS, ScriptLocalization.Menu_Messages.No_Button_CS, ResetDefaultEnabledStatusAll);
				}
				else
				{
					_messageBox.SetUseNonFrostedPanelData(bUseNonFrostedPanelData: true);
					_messageBox.ShowAsYesNo(ExtContentMessages.GetMessageString(EMessageType.DynamicPlaylistResetMessageTitle), ExtContentMessages.GetMessageString(EMessageType.DynamicPlaylistResetMessageBody), ScriptLocalization.Menu_Messages.Yes_Button_CS, ScriptLocalization.Menu_Messages.No_Button_CS, ResetDefaultEnabledStatus);
				}
			}
		}

		private void ResetDefaultEnabledStatusAll()
		{
			_dynamicPlaylistManager.ResetDefaultEnabledStatus(bFullReset: true);
		}

		private void ResetDefaultEnabledStatus()
		{
			_dynamicPlaylistManager.ResetDefaultEnabledStatus();
		}

		private void RefreshAudioTabContentPanels()
		{
			if (_audioTabContentsPanel != null)
			{
				_audioTabContentsPanel.SetActive(_activeTab == Tab.Audio && !_bPlaylistEditModeOn);
			}
			if (_audioTabPlaylistPanel != null)
			{
				_audioTabPlaylistPanel.SetActive(_activeTab == Tab.Audio && _bPlaylistEditModeOn);
			}
			_playlistEditModeUI?.SetVisible(_activeTab == Tab.Audio && _bPlaylistEditModeOn);
		}

		private void RefreshPlaybackModeButtonText()
		{
			_playbackModeButtonText.text = DynamicPlaylistManager.GetPlaybackModeStringLoc(_dynamicPlaylistManager.PlaybackMode);
		}

		private void OnLocalize()
		{
			RefreshPlaybackModeButtonText();
		}

		private void ResetAudioToDefault()
		{
			_localPreferences.Audio.ResetToDefaultValues();
			_masterVolumeSlider.value = _localPreferences.Audio.MasterVolume / _localPreferences.Audio.MaxMasterVolume;
			_musicVolumeSlider.value = _localPreferences.Audio.MusicVolume / _localPreferences.Audio.MaxMusicVolume;
			_sfxVolumeSlider.value = _localPreferences.Audio.SFXVolume / _localPreferences.Audio.MaxSFXVolume;
			_tannoyVolumeSlider.value = _localPreferences.Audio.TannoyVolume / _localPreferences.Audio.MaxTannoyVolume;
			_djVolumeSlider.value = _localPreferences.Audio.DJVolume / _localPreferences.Audio.MaxDJVolume;
		}
	}
}
