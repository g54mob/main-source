using System;
using System.Collections.Generic;
using System.Text;
using I2.Loc;
using M4.Session;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Settings
{
	public const string FILENAME = "PlayerSettings.json";

	public static readonly Encoding ENCODING = Encoding.UTF8;

	private static UnityEvent OnInitialized;

	public bool HasMigratedSaves;

	public AudioPlayerData AudioPlayerData;

	public GameplayPlayerData GameplayPlayerData;

	public GraphicsPlayerData GraphicsPlayerData;

	private static Settings s_instance;

	private IUser _user;

	public static Settings Instance
	{
		get
		{
			return s_instance;
		}
		private set
		{
			if (s_instance == null)
			{
				s_instance = value;
				if (OnInitialized != null)
				{
					OnInitialized.Invoke();
					OnInitialized.RemoveAllListeners();
				}
			}
		}
	}

	public static bool IsInitialized => s_instance != null;

	public static bool IsWaitingForApply { get; private set; }

	private Settings()
	{
	}

	public void ResetToDefaults()
	{
		AudioPlayerData.ResetSettings(GameSettings.Instance.MasterVolume);
		GameplayPlayerData.ResetSettings();
		GraphicsPlayerData.ResetSettings();
		Save();
	}

	private void i_Apply()
	{
		if (FMODManager.IsInitialized)
		{
			FMODManager.ApplyAudioPlayerData(AudioPlayerData);
			List<string> allLanguages = LocalizationManager.GetAllLanguages();
			if (GameplayPlayerData.SelectedLanguageIndex >= allLanguages.Count)
			{
				Debug.LogWarning("Player language index exceeded languages count. A language may have been removed.");
				GameplayPlayerData.SelectedLanguageIndex = 0;
			}
			LocalizationManager.CurrentLanguage = allLanguages[GameplayPlayerData.SelectedLanguageIndex];
			IsWaitingForApply = false;
		}
		else
		{
			IsWaitingForApply = true;
		}
	}

	public void Save()
	{
		if (_user == null)
		{
			Session.Platform.SaveSettings(this);
		}
		else
		{
			_user.SaveFile("PlayerSettings.json", ENCODING.GetBytes(JsonUtility.ToJson(this)), OnSaveResult);
		}
		Apply();
	}

	private static void OnSaveResult(StorageActionResult result)
	{
	}

	public static void SetInstance(Settings instance)
	{
		Instance = instance;
	}

	public static void CreateInstance()
	{
		if (Instance == null)
		{
			Instance = new Settings
			{
				AudioPlayerData = new AudioPlayerData(fmod: true),
				GameplayPlayerData = new GameplayPlayerData(),
				GraphicsPlayerData = new GraphicsPlayerData()
			};
			Instance.ResetToDefaults();
		}
	}

	public static void Load(IUser user, UnityAction callback)
	{
		user.LoadFile("PlayerSettings.json", delegate(StorageActionResult result)
		{
			if (result.Succes)
			{
				try
				{
					Instance = JsonUtility.FromJson<Settings>(ENCODING.GetString(result.Data));
				}
				catch (Exception ex)
				{
					Debug.LogWarning("Unable to load PlayerData: " + ex.Message);
				}
			}
			if (s_instance == null)
			{
				CreateInstance();
			}
			Instance._user = user;
			callback?.Invoke();
		});
	}

	public static void Apply()
	{
		Instance?.i_Apply();
	}

	public static void InvokeOnInitialized(UnityAction callback)
	{
		if (IsInitialized)
		{
			callback();
			return;
		}
		if (OnInitialized == null)
		{
			OnInitialized = new UnityEvent();
		}
		OnInitialized.AddListener(callback);
	}
}
