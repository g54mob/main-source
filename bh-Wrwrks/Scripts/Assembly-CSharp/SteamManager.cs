using System;
using System.IO;
using System.Text;
using AOT;
using Steamworks;
using UnityEngine;

[DisallowMultipleComponent]
public class SteamManager : MonoBehaviour
{
	protected static bool s_EverInitialized;

	protected static SteamManager s_instance;

	protected bool m_bInitialized;

	public static bool filterInit;

	protected SteamAPIWarningMessageHook_t m_SteamAPIWarningMessageHook;

	protected static SteamManager Instance
	{
		get
		{
			if (s_instance == null)
			{
				return new GameObject("SteamManager").AddComponent<SteamManager>();
			}
			return s_instance;
		}
	}

	public static bool Initialized => Instance.m_bInitialized;

	public static void InitTextFilter()
	{
		filterInit = SteamUtils.InitFilterText();
	}

	public static void Wishlist()
	{
		if (!Initialized)
		{
			Application.OpenURL("https://store.steampowered.com/app/4206270?utm_source=demo");
		}
		else
		{
			SteamFriends.ActivateGameOverlayToWebPage("https://store.steampowered.com/app/4206270?utm_source=demo");
		}
	}

	public static void Jilsen()
	{
		if (!Initialized)
		{
			Application.OpenURL("https://store.steampowered.com/developer/jilsen");
		}
		else
		{
			SteamFriends.ActivateGameOverlayToWebPage("https://store.steampowered.com/developer/jilsen");
		}
	}

	public static void ShowKeyboard(int type)
	{
		if (Initialized)
		{
			if (type == 0)
			{
				SteamUtils.ShowFloatingGamepadTextInput(EFloatingGamepadTextInputMode.k_EFloatingGamepadTextInputModeModeSingleLine, 90, 200, 260, 60);
			}
			if (type == 1)
			{
				SteamUtils.ShowFloatingGamepadTextInput(EFloatingGamepadTextInputMode.k_EFloatingGamepadTextInputModeModeSingleLine, 1020, 670, 220, 70);
			}
		}
	}

	public static uint GetAppID()
	{
		if (!Initialized)
		{
			return 0u;
		}
		return SteamUtils.GetAppID().m_AppId;
	}

	public static string GetID()
	{
		if (!Initialized)
		{
			return "0";
		}
		string text = SteamUser.GetSteamID().m_SteamID.ToString();
		File.WriteAllText(Application.dataPath + "/steamID.dat", text);
		return text;
	}

	public static ulong GetIDint()
	{
		if (!Initialized)
		{
			return 0uL;
		}
		return SteamUser.GetSteamID().m_SteamID;
	}

	public static string GetUsername()
	{
		if (!Initialized)
		{
			return "";
		}
		return SteamFriends.GetPersonaName();
	}

	public static void UnlockAchievement(SaveManager.Achievement ach)
	{
		if (Initialized && !Dungeon.Instance.demo && !CheckAchievement(ach))
		{
			SteamUserStats.SetAchievement(ach.ToString());
			SteamUserStats.StoreStats();
		}
	}

	public static bool CheckAchievement(SaveManager.Achievement ach)
	{
		if (!Initialized)
		{
			return false;
		}
		SteamUserStats.GetAchievement(ach.ToString(), out var pbAchieved);
		return pbAchieved;
	}

	public static bool OnSteamDeck()
	{
		if (!Initialized)
		{
			return false;
		}
		return SteamUtils.IsSteamRunningOnSteamDeck();
	}

	public static string FilterText(string s, ulong id)
	{
		if (!filterInit)
		{
			InitTextFilter();
		}
		CSteamID sourceSteamID = new CSteamID(id);
		SteamUtils.FilterText(ETextFilteringContext.k_ETextFilteringContextName, sourceSteamID, s, out var pchOutFilteredText, (uint)(s.Length + 1));
		return pchOutFilteredText;
	}

	[MonoPInvokeCallback(typeof(SteamAPIWarningMessageHook_t))]
	protected static void SteamAPIDebugTextHook(int nSeverity, StringBuilder pchDebugText)
	{
		Debug.LogWarning(pchDebugText);
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void InitOnPlayMode()
	{
		s_EverInitialized = false;
		s_instance = null;
	}

	protected virtual void Awake()
	{
		if (s_instance != null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		s_instance = this;
		if (s_EverInitialized)
		{
			throw new Exception("Tried to Initialize the SteamAPI twice in one session!");
		}
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		if (!Packsize.Test())
		{
			Debug.LogError("[Steamworks.NET] Packsize Test returned false, the wrong version of Steamworks.NET is being run in this platform.", this);
		}
		if (!DllCheck.Test())
		{
			Debug.LogError("[Steamworks.NET] DllCheck Test returned false, One or more of the Steamworks binaries seems to be the wrong version.", this);
		}
		try
		{
			if (SteamAPI.RestartAppIfNecessary(AppId_t.Invalid))
			{
				Application.Quit();
				return;
			}
		}
		catch (DllNotFoundException ex)
		{
			Debug.LogError("[Steamworks.NET] Could not load [lib]steam_api.dll/so/dylib. It's likely not in the correct location. Refer to the README for more details.\n" + ex, this);
			Application.Quit();
			return;
		}
		m_bInitialized = SteamAPI.Init();
		if (!m_bInitialized)
		{
			Debug.Log("[Steamworks.NET] SteamAPI_Init() failed. Refer to Valve's documentation or the comment above this line for more information.", this);
		}
		else
		{
			s_EverInitialized = true;
		}
	}

	protected virtual void OnEnable()
	{
		if (s_instance == null)
		{
			s_instance = this;
		}
		if (m_bInitialized && m_SteamAPIWarningMessageHook == null)
		{
			m_SteamAPIWarningMessageHook = SteamAPIDebugTextHook;
			SteamClient.SetWarningMessageHook(m_SteamAPIWarningMessageHook);
		}
	}

	protected virtual void OnDestroy()
	{
		if (!(s_instance != this))
		{
			s_instance = null;
			if (m_bInitialized)
			{
				SteamAPI.Shutdown();
			}
		}
	}

	protected virtual void Update()
	{
		if (m_bInitialized)
		{
			SteamAPI.RunCallbacks();
		}
	}
}
