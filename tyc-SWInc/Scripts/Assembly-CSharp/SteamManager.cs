using System;
using System.Diagnostics;
using System.Text;
using Steamworks;
using UnityEngine;

[DisallowMultipleComponent]
public class SteamManager : MonoBehaviour
{
	private static SteamManager s_instance;

	private static bool s_EverInialized;

	private bool m_bInitialized;

	private SteamAPIWarningMessageHook_t m_SteamAPIWarningMessageHook;

	private static SteamManager Instance
	{
		get
		{
			return s_instance;
		}
	}

	public static bool Initialized
	{
		get
		{
			if (Instance != null)
			{
				return Instance.m_bInitialized;
			}
			return false;
		}
	}

	private static void SteamAPIDebugTextHook(int nSeverity, StringBuilder pchDebugText)
	{
		UnityEngine.Debug.LogWarning(pchDebugText);
	}

	private void Awake()
	{
		if (s_instance != null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		s_instance = this;
		if (s_EverInialized)
		{
			throw new Exception("Tried to Initialize the SteamAPI twice in one session!");
		}
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		if (!Packsize.Test())
		{
			UnityEngine.Debug.LogError("[Steamworks.NET] Packsize Test returned false, the wrong version of Steamworks.NET is being run in this platform.", this);
		}
		if (!DllCheck.Test())
		{
			UnityEngine.Debug.LogError("[Steamworks.NET] DllCheck Test returned false, One or more of the Steamworks binaries seems to be the wrong version.", this);
		}
		try
		{
			if (SteamAPI.RestartAppIfNecessary((AppId_t)362620u))
			{
				UnityEngine.Debug.Log("Restarting app due to Steam DRM");
				Process.GetCurrentProcess().Kill();
				return;
			}
		}
		catch (DllNotFoundException ex)
		{
			UnityEngine.Debug.LogError("[Steamworks.NET] Could not load [lib]steam_api.dll/so/dylib. It's likely not in the correct location. Refer to the README for more details.\n" + ex, this);
			Process.GetCurrentProcess().Kill();
			return;
		}
		try
		{
			m_bInitialized = SteamAPI.Init();
		}
		catch (Exception exception)
		{
			m_bInitialized = false;
			UnityEngine.Debug.LogException(exception);
		}
		if (!m_bInitialized)
		{
			UnityEngine.Debug.LogError("[Steamworks.NET] SteamAPI_Init() failed. Refer to Valve's documentation or the comment above this line for more information.", this);
			return;
		}
		try
		{
			SteamUtils.InitFilterText();
		}
		catch (Exception ex2)
		{
			UnityEngine.Debug.Log(ex2.ToString());
		}
		UnityEngine.Debug.Log("Steamworks successfully initialized");
		s_EverInialized = true;
	}

	private void OnEnable()
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

	private void OnDestroy()
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

	public static void Shutdown()
	{
		if (Initialized)
		{
			SteamAPI.Shutdown();
			Instance.m_bInitialized = false;
		}
	}

	private void Update()
	{
		if (m_bInitialized)
		{
			SteamAPI.RunCallbacks();
		}
	}
}
