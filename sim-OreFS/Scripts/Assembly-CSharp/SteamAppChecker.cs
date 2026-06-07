using GameCreator.Runtime.Common;
using GameCreator.Runtime.Variables;
using Heathen.SteamworksIntegration;
using Steamworks;
using UnityEngine;

public class SteamAppChecker : MonoBehaviour
{
	public const uint FULL_GAME_APPID = 4210580u;

	public const uint DEMO_APPID = 4396420u;

	public const uint PROLOGUE_APPID = 0u;

	[Header("Debug - Force Version")]
	[Tooltip("Aktifken oyunu Demo olarak zorlar (Editor/Build)")]
	[SerializeField]
	private bool forceDemo;

	[Tooltip("Aktifken oyunu Prologue olarak zorlar (Editor/Build)")]
	[SerializeField]
	private bool forcePrologue;

	[Header("GlobalNameVariables")]
	[SerializeField]
	private GlobalNameVariables gameVersionVariables;

	private uint? _cachedAppId;

	private GameVersion? _cachedVersion;

	public static SteamAppChecker Instance { get; private set; }

	public uint CurrentAppId
	{
		get
		{
			if (_cachedAppId.HasValue)
			{
				return _cachedAppId.Value;
			}
			if (SteamSettings.current == null)
			{
				Debug.LogWarning("[SteamAppChecker] Steam henüz başlatılmamış!");
				return 0u;
			}
			_cachedAppId = SteamUtils.GetAppID().m_AppId;
			return _cachedAppId.Value;
		}
	}

	public GameVersion CurrentGameVersion
	{
		get
		{
			if (forceDemo)
			{
				return GameVersion.Demo;
			}
			if (forcePrologue)
			{
				return GameVersion.Prologue;
			}
			if (_cachedVersion.HasValue)
			{
				return _cachedVersion.Value;
			}
			_cachedVersion = GetVersionFromAppId(CurrentAppId);
			return _cachedVersion.Value;
		}
	}

	public bool IsFullGame => CurrentGameVersion == GameVersion.FullGame;

	public bool IsDemo => CurrentGameVersion == GameVersion.Demo;

	public bool IsPrologue => CurrentGameVersion == GameVersion.Prologue;

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		Instance = this;
		Object.DontDestroyOnLoad(base.gameObject);
	}

	private void Start()
	{
		CheckAndFireEvents();
	}

	private void CheckAndFireEvents()
	{
		Debug.Log($"[SteamAppChecker] AppID: {CurrentAppId} | Version: {CurrentGameVersion}");
		if (gameVersionVariables != null && Singleton<GlobalNameVariablesManager>.Instance != null)
		{
			bool flag = CurrentGameVersion == GameVersion.Demo;
			bool flag2 = CurrentGameVersion == GameVersion.Prologue;
			Singleton<GlobalNameVariablesManager>.Instance.Set(gameVersionVariables, "isDemo", flag);
			Singleton<GlobalNameVariablesManager>.Instance.Set(gameVersionVariables, "isPrologue", flag2);
			Debug.Log($"[SteamAppChecker] GlobalNameVariables set: isDemo={flag}, isPrologue={flag2}");
		}
	}

	private GameVersion GetVersionFromAppId(uint appId)
	{
		return appId switch
		{
			4210580u => GameVersion.FullGame, 
			4396420u => GameVersion.Demo, 
			_ => GameVersion.Unknown, 
		};
	}

	public bool RequireFullGame(string featureName = null)
	{
		if (IsFullGame)
		{
			return true;
		}
		string arg = (string.IsNullOrEmpty(featureName) ? "Bu özellik" : featureName);
		Debug.LogWarning($"[SteamAppChecker] {arg} sadece Full Game'de kullanılabilir. Mevcut: {CurrentGameVersion}");
		return false;
	}
}
