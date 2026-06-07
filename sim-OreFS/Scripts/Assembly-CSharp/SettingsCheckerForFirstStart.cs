using System.Collections;
using GameCreator.Runtime.Variables;
using I2.Loc;
using Kamgam.SettingsGenerator;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SettingsCheckerForFirstStart : MonoBehaviour
{
	public static SettingsCheckerForFirstStart Instance;

	public float variablesWaitTime = 1f;

	[Header("References")]
	public SettingsInitializer settingsInitializer;

	public GlobalNameVariables settingsVariables;

	public InputActionReference lookAction;

	[Header("Variable Keys")]
	public string cameraSensivityKey = "ST-Camera-Sensivity";

	public string headbobIntensityKey = "ST-Camera-Bob";

	public string cameraShakeKey = "ST-Camera-Shake";

	public string showControlsKey = "ST-Show-Controls";

	public void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Object.Destroy(base.gameObject);
		}
	}

	private void Start()
	{
		SetAllLanguagesSettings();
	}

	public void OnEnable()
	{
		Detect();
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	public void OnDisable()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		Detect();
	}

	public void Detect()
	{
		StartCoroutine(DetectMouseInvertXY());
		StartCoroutine(DetectCameraSensivity());
		StartCoroutine(DetectHeadbobIntensity());
		StartCoroutine(DetectShowControls());
		StartCoroutine(DetectCameraShake());
	}

	public void SetSettingsVariables(string key, object value)
	{
		settingsVariables.Set(key, value);
	}

	public void SetAllLanguagesSettings()
	{
		LanguageConnection._I2values = LocalizationManager.GetAllLanguages();
		LanguageConnection.currentLanguage = LocalizationManager.CurrentLanguage;
		settingsInitializer.enabled = true;
		if (!PlayerPrefs.HasKey("GameLanguage"))
		{
			string text = (LocalizationManager.CurrentLanguage = GetDefaultLanguage(Application.systemLanguage));
			PlayerPrefs.SetString("GameLanguage", text);
			PlayerPrefs.Save();
			Debug.Log("GameLanguage set to: " + text);
		}
	}

	private string GetDefaultLanguage(SystemLanguage systemLanguage)
	{
		return systemLanguage switch
		{
			SystemLanguage.Turkish => "Turkish", 
			SystemLanguage.English => "English", 
			SystemLanguage.French => "French", 
			SystemLanguage.Italian => "Italian", 
			SystemLanguage.German => "German", 
			SystemLanguage.Spanish => "Spanish", 
			SystemLanguage.Japanese => "Japanese", 
			SystemLanguage.Korean => "Korean", 
			SystemLanguage.Polish => "Polish", 
			SystemLanguage.Portuguese => "Portuguese", 
			SystemLanguage.Russian => "Russian", 
			SystemLanguage.ChineseSimplified => "Chinese (Simplified)", 
			SystemLanguage.ChineseTraditional => "Chinese", 
			_ => "English", 
		};
	}

	private IEnumerator DetectCameraSensivity()
	{
		yield return new WaitForSeconds(variablesWaitTime);
		Vector3 currentValue = CameraSensivityConnection.CurrentValue;
		SetSettingsVariables(cameraSensivityKey, currentValue);
	}

	private IEnumerator DetectHeadbobIntensity()
	{
		yield return new WaitForSeconds(variablesWaitTime);
		float currentValue = HeadbobIntensityConnection.CurrentValue;
		SetSettingsVariables(headbobIntensityKey, currentValue);
	}

	private IEnumerator DetectShowControls()
	{
		yield return new WaitForSeconds(variablesWaitTime);
		bool currentValue = ShowControlsConnection.CurrentValue;
		SetSettingsVariables(showControlsKey, currentValue);
	}

	private IEnumerator DetectCameraShake()
	{
		yield return new WaitForSeconds(variablesWaitTime);
		bool currentValue = CameraShakeConnection.CurrentValue;
		SetSettingsVariables(cameraShakeKey, currentValue);
	}

	private IEnumerator DetectMouseInvertXY()
	{
		yield return new WaitForSeconds(variablesWaitTime);
		bool currentValue = MouseInvertXConnection.CurrentValue;
		bool currentValue2 = MouseInvertYConnection.CurrentValue;
		SetInvert(currentValue, currentValue2);
	}

	public void SetInvert(bool invertX, bool invertY)
	{
		for (int i = 0; i < lookAction.action.bindings.Count; i++)
		{
			InputBinding inputBinding = lookAction.action.bindings[i];
			if (!string.IsNullOrEmpty(inputBinding.processors) && inputBinding.processors.Contains("InvertVector2"))
			{
				string overrideProcessors = "InvertVector2(invertX=" + (invertX ? "true" : "false") + ",invertY=" + (invertY ? "false" : "true") + ")";
				lookAction.action.ApplyBindingOverride(i, new InputBinding
				{
					overrideProcessors = overrideProcessors
				});
			}
		}
	}
}
