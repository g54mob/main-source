using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Game;
using Game.Audio;
using Game.General;
using Game.Graphics;
using Game.Twitch;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameSettings : MonoBehaviour
{
	public static UnityEvent<GameSettingsConfig> OnLoadConfigFinished = new UnityEvent<GameSettingsConfig>();

	public static UnityEvent<GameSettingsConfig> OnUpdateConfig = new UnityEvent<GameSettingsConfig>();

	private GameSettingsConfig activeConfig;

	private string folderPath = Application.dataPath + "/Config/";

	private const string fileName = "configSettings.txt";

	private static GameSettings instance;

	private List<SettingsComponent> settingsComponents = new List<SettingsComponent>();

	public void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Object.Destroy(this);
		}
		Object.DontDestroyOnLoad(instance);
	}

	private void Start()
	{
		AllSettingDependenciesValidated();
	}

	private void AllSettingDependenciesValidated()
	{
		if (TwitchCommandList.IsValidated())
		{
			Init();
		}
		else
		{
			StartCoroutine(WaitForValidation());
		}
	}

	private IEnumerator WaitForValidation()
	{
		yield return new WaitUntil(TwitchCommandList.IsValidated);
		Init();
	}

	private void Init()
	{
		activeConfig = LoadConfig();
		OnUpdateConfig.AddListener(delegate
		{
			UpdateSettingComponents();
		});
		InitSettings(activeConfig);
		SceneManager.activeSceneChanged += delegate
		{
			InitSettings(activeConfig);
		};
	}

	private void InitSettings(GameSettingsConfig config)
	{
		OnLoadConfigFinished.Invoke(activeConfig);
		settingsComponents = settingsComponents.Where((SettingsComponent x) => x != null).ToList();
		LoadSettingComponents();
		OnUpdateConfig.Invoke(instance.activeConfig);
	}

	public static bool IsValid()
	{
		return instance != null;
	}

	public static GameSettingsConfig GetActiveConfig()
	{
		return instance.activeConfig;
	}

	private void LoadSettingComponents()
	{
		foreach (SettingsComponent settingsComponent in settingsComponents)
		{
			settingsComponent.LoadConfig(activeConfig);
		}
	}

	private void UpdateSettingComponents()
	{
		foreach (SettingsComponent settingsComponent in settingsComponents)
		{
			settingsComponent.ReloadSettings(activeConfig);
		}
	}

	public static void RegisterSettingsComponent(SettingsComponent settings)
	{
		if (!instance.settingsComponents.Contains(settings))
		{
			instance.settingsComponents.Add(settings);
		}
	}

	public static void UnregisterSettingsComponent(SettingsComponent settings)
	{
		if (instance.settingsComponents.Contains(settings))
		{
			instance.settingsComponents.Remove(settings);
		}
	}

	public static void SetGeneralSettings(GeneralSettingsContainer generalSettings)
	{
		instance.activeConfig.generalSettings = generalSettings;
		SaveConfig();
	}

	public static void SetGraphicsSettings(GraphicsContainer graphics)
	{
		instance.activeConfig.graphics = graphics;
		SaveConfig();
	}

	public static void SetAudioSettings(AudioSettingsContainer audioSettings)
	{
		instance.activeConfig.audioSettings = audioSettings;
		SaveConfig();
	}

	public static void SetTwitchSettings(TwitchSettingsContainer twitchSettings)
	{
		instance.activeConfig.twitchSettings = twitchSettings;
		SaveConfig();
	}

	public static void UpdateGeneralSettings(GeneralSettingsContainer generalSettings)
	{
		instance.activeConfig.generalSettings = generalSettings;
		SaveConfig();
		OnUpdateConfig.Invoke(instance.activeConfig);
	}

	public static void UpdateGraphicsSettings(GraphicsContainer graphics)
	{
		instance.activeConfig.graphics = graphics;
		SaveConfig();
		OnUpdateConfig.Invoke(instance.activeConfig);
	}

	public static void UpdateAudioSettings(AudioSettingsContainer audioSettings)
	{
		instance.activeConfig.audioSettings = audioSettings;
		SaveConfig();
		OnUpdateConfig.Invoke(instance.activeConfig);
	}

	public static void UpdateTwitchSettings(TwitchSettingsContainer twitchSettings)
	{
		instance.activeConfig.twitchSettings = twitchSettings;
		SaveConfig();
		OnUpdateConfig.Invoke(instance.activeConfig);
	}

	[ContextMenu("Save Current Config")]
	public static void SaveConfig()
	{
		string contents = JsonUtility.ToJson(instance.activeConfig);
		if (File.Exists(instance.folderPath))
		{
			File.WriteAllText(instance.folderPath + "configSettings.txt", contents);
			return;
		}
		Directory.CreateDirectory(instance.folderPath);
		File.WriteAllText(instance.folderPath + "configSettings.txt", contents);
	}

	private GameSettingsConfig LoadConfig()
	{
		GameSettingsConfig result = new GameSettingsConfig();
		if (File.Exists(instance.folderPath + "configSettings.txt"))
		{
			result = JsonUtility.FromJson<GameSettingsConfig>(File.ReadAllText(instance.folderPath + "configSettings.txt"));
		}
		else
		{
			activeConfig = result;
			SaveConfig();
		}
		return result;
	}

	public static void UpdateSettings()
	{
		OnUpdateConfig.Invoke(GetActiveConfig());
	}
}
