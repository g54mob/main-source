using System;
using System.Text;
using AOT;
using NSEipix;
using NSEipix.Base;
using Steamworks;
using UnityEngine;

[DisallowMultipleComponent]
public class SteamSdkManager : MonoSingleton<SteamSdkManager>
{
	protected static bool steamEverInitialized;

	private bool canCheckForReinitInUpdate = true;

	private bool steamApiInitialized;

	private SteamAPIWarningMessageHook_t m_SteamAPIWarningMessageHook;

	public static bool IsSteamInitialised => MonoSingleton<SteamSdkManager>.Instance.steamApiInitialized;

	[RuntimeInitializeOnLoadMethod]
	public static void OnDomainReloadSelf()
	{
		steamEverInitialized = false;
	}

	[MonoPInvokeCallback(typeof(SteamAPIWarningMessageHook_t))]
	protected static void SteamAPIDebugTextHook(int nSeverity, StringBuilder pchDebugText)
	{
		Debug.LogWarning(pchDebugText);
	}

	protected override void Awake()
	{
		base.Awake();
		if (steamEverInitialized)
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
				Debug.Log("[Steamworks.NET] Shutting down because RestartAppIfNecessary returned true. Steam will restart the application.");
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
		steamApiInitialized = SteamAPI.Init();
		if (!steamApiInitialized)
		{
			Debug.LogError("[Steamworks.NET] SteamAPI_Init() failed. Refer to Valve's documentation or the comment above this line for more information.", this);
			return;
		}
		Debug.Log(string.Format("Steam API (SDK: {0}) initialized! Is steam running: {1}", "1.63", SteamAPI.IsSteamRunning()));
		steamEverInitialized = true;
	}

	private void OnEnable()
	{
		if (MonoSingleton<SteamSdkManager>.IsInstantiated() && steamApiInitialized && m_SteamAPIWarningMessageHook == null)
		{
			m_SteamAPIWarningMessageHook = SteamAPIDebugTextHook;
			SteamClient.SetWarningMessageHook(m_SteamAPIWarningMessageHook);
		}
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		if (steamApiInitialized && MonoSingleton<SteamSdkManager>.IsInstantiated())
		{
			Debug.Log("[Steamworks.NET] Shutting down.");
			SteamAPI.Shutdown();
		}
	}

	private void Update()
	{
		if (!MonoSingleton<SteamSdkManager>.IsInstantiated())
		{
			return;
		}
		if (!SteamAPI.IsSteamRunning())
		{
			steamApiInitialized = false;
			if (canCheckForReinitInUpdate)
			{
				canCheckForReinitInUpdate = false;
				Debug.Log("Steam: Looks like the steam app is closed. Trying to re-init.");
				MonoSingleton<TaskController>.Instance.WaitForUnscaled(0.1f).Then(TryInit);
			}
		}
		else if (steamApiInitialized)
		{
			try
			{
				SteamAPI.RunCallbacks();
			}
			catch (InvalidOperationException ex)
			{
				Debug.LogError("[Steamworks.NET] Callback dispatcher not initialized: " + ex.Message);
				steamApiInitialized = false;
			}
		}
	}

	private void TryInit()
	{
		SteamAPI.Shutdown();
		MonoSingleton<TaskController>.Instance.WaitForUnscaled(0.5f).Then(delegate
		{
			steamApiInitialized = SteamAPI.Init();
			if (!steamApiInitialized)
			{
				MonoSingleton<TaskController>.Instance.WaitForUnscaled(0.5f).Then(TryInit);
			}
			else
			{
				Debug.Log("Steam: The steam app is open again. Re-initialized successfully.");
				canCheckForReinitInUpdate = true;
			}
		});
	}
}
