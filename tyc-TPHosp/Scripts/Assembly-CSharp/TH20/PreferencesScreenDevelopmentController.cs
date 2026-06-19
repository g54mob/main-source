using System.Collections.Generic;
using System.Text;
using FullInspector.Generated.SharedInstance;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TH20
{
	public class PreferencesScreenDevelopmentController : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _frameRateText;

		[SerializeField]
		private Button _showPreferencesButton;

		[SerializeField]
		private Button _showCreditsButton;

		[SerializeField]
		private GameObject _creditsScreenPrefab;

		[SerializeField]
		private PreferencesScreen _preferencesScreen;

		[SerializeField]
		private SharedInstance_TH20TH20_InputManager_Config _inputManagerConfig;

		[SerializeField]
		private EventSystem _eventSystem;

		[SerializeField]
		private GraphicRaycaster _graphicRaycaster;

		[SerializeField]
		private TextMeshProUGUI _widthText;

		[SerializeField]
		private TextMeshProUGUI _heightText;

		[SerializeField]
		private TextMeshProUGUI _fullscreenModeText;

		[SerializeField]
		private TextMeshProUGUI _currentResolutionText;

		[SerializeField]
		private TextMeshProUGUI _resolutionsText;

		private InputManager _inputManager;

		private Preferences _preferences;

		private LocalPreferences _localPreferences;

		private ControlBindingsLocalisationParamsManager _controlBindingsLocalisationParamsManager;

		private void Awake()
		{
			ThreadingUtils.Initialise();
			Directories.Initialise();
			_inputManager = new InputManager(_inputManagerConfig.Instance, _eventSystem);
			_inputManager.AddGraphicRayCaster(_graphicRaycaster);
			_controlBindingsLocalisationParamsManager = new ControlBindingsLocalisationParamsManager();
			_preferences = Preferences.LoadOrCreateNew(null, _controlBindingsLocalisationParamsManager);
			_localPreferences = LocalPreferences.LoadOrCreateNew();
			TooltipManager.CreateInstance(_inputManager);
			TooltipManager.Instance.PushGUIRoot(_graphicRaycaster.transform);
			_preferencesScreen.Setup(_preferences, _localPreferences, _controlBindingsLocalisationParamsManager);
			_preferencesScreen.gameObject.SetActive(value: false);
			_showPreferencesButton.onClick.AddListener(ShowPreferencesScreen);
			_showCreditsButton.onClick.AddListener(ShowCreditsScreen);
		}

		private void ShowPreferencesScreen()
		{
			_preferencesScreen.Show();
		}

		private void ShowCreditsScreen()
		{
			Object.Instantiate(_creditsScreenPrefab, _graphicRaycaster.transform, worldPositionStays: false);
		}

		private void Update()
		{
			float unscaledDeltaTime = Time.unscaledDeltaTime;
			_frameRateText.text = ((unscaledDeltaTime == 0f) ? "" : (1f / unscaledDeltaTime).ToString());
			_widthText.text = "Screen.width: " + Screen.width;
			_heightText.text = "Screen.height: " + Screen.height;
			_fullscreenModeText.text = "Screen.fullScreenMode: " + Screen.fullScreenMode;
			_currentResolutionText.text = "Screen.currentResolution: " + Screen.currentResolution.ToString();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Supported resolutions:");
			Resolution[] resolutions = Screen.resolutions;
			for (int i = 0; i < resolutions.Length; i++)
			{
				Resolution resolution = resolutions[i];
				KeyValuePair<int, int> keyValuePair = ResolutionUtils.AspectRatioOfResolution(resolution.width, resolution.height);
				stringBuilder.AppendFormat("{0} x {1} ({2}:{3}) @ {4}Hz\n", resolution.width, resolution.height, keyValuePair.Key, keyValuePair.Value, resolution.refreshRate);
			}
			_resolutionsText.text = stringBuilder.ToString();
			_inputManager.Update();
			TooltipManager.Instance.Update();
		}
	}
}
