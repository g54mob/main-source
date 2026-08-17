using System;
using Assets.Scripts.Steam;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using Steamworks;
using UnityEngine;

public class SteamManager : MonoBehaviour
{
	protected static bool initialized;

	protected static SteamManager Instance;

	public static AppId_t APP_ID;

	public static Action A_UpdateComponents;

	public static Action A_Initialized;

	public static ulong steamId;

	public static Action<ulong> A_PlayerInformationArrived;

	private static void InitOnPlayMode()
	{
		initialized = false;
		Instance = null;
	}

	public virtual void Load()
	{
		//IL_005b: Expected O, but got I4
		//IL_0087: Expected O, but got I4
		//IL_0236: Expected I8, but got O
		if (!(Instance == null))
		{
			GameObject obj = base.gameObject;
			UnityEngine.Object.Destroy(obj);
			return;
		}
		Instance = this;
		if (!initialized)
		{
			GameObject target = base.gameObject;
			UnityEngine.Object.DontDestroyOnLoad(target);
			bool flag = Packsize.Test();
			UnityEngine.Object obj2 = null;
			object obj3 = 0;
			if (!flag)
			{
				Debug.LogError("[Steamworks.NET] Packsize Test returned false, the wrong version of Steamworks.NET is being run in this platform.", this);
				obj2 = this;
				obj3 = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180383DB0");
			object obj4 = default(object);
			if (obj4 == null)
			{
				Debug.LogError("[Steamworks.NET] DllCheck Test returned false, One or more of the Steamworks binaries seems to be the wrong version.", this);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1805E63E0");
			object obj5 = default(object);
			if (obj5 == null)
			{
				bool flag2 = SteamAPI.Init();
				initialized = flag2;
				if (initialized)
				{
					SteamTimelineManager.Init();
					SteamStatsManager.Init();
					SteamAchievementsManager.Init();
					SteamRichPresenceManager.Init();
					SteamLeaderboardsManagerNew.Init();
					Callback<PersonaStateChange_t>.DispatchDelegate func = OnPersonaStateChange;
					Callback<PersonaStateChange_t> callback = Callback<PersonaStateChange_t>.Create(func);
					initialized = true;
					CSteamID steamID = SteamUser.GetSteamID();
					steamId = (ulong)(long)steamID;
					Action a_Initialized = A_Initialized;
					if (A_Initialized != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v538.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					}
					MyLogger.LogInBuild("Steam initialized");
				}
				else
				{
					Debug.LogError("[Steamworks.NET] SteamAPI_Init() failed. Refer to Valve's documentation or the comment above this line for more information.", this);
				}
			}
			else
			{
				Debug.LogError("[Steamworks.NET] Shutting down because RestartAppIfNecessary returned true. Steam will restart the application.");
			}
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
		Exception ex = new Exception("Tried to Initialize the SteamAPI twice in one session!");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
		throw ex;
	}

	protected virtual void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
			SteamTimelineManager.OnDestroy();
			SteamStatsManager.OnDestroy();
			SteamAchievementsManager.OnDestroy();
			SteamRichPresenceManager.OnDestroy();
			SteamLeaderboardsManagerNew.OnDestroy();
			if (initialized)
			{
				SteamAPI.Shutdown();
			}
		}
	}

	private void InitComponents()
	{
		SteamTimelineManager.Init();
		SteamStatsManager.Init();
		SteamAchievementsManager.Init();
		SteamRichPresenceManager.Init();
		SteamLeaderboardsManagerNew.Init();
		Callback<PersonaStateChange_t>.DispatchDelegate func = OnPersonaStateChange;
		Callback<PersonaStateChange_t> callback = Callback<PersonaStateChange_t>.Create(func);
	}

	private void DestroyComponents()
	{
		SteamTimelineManager.OnDestroy();
		SteamStatsManager.OnDestroy();
		SteamAchievementsManager.OnDestroy();
		SteamRichPresenceManager.OnDestroy();
		SteamLeaderboardsManagerNew.OnDestroy();
	}

	private void OnPersonaStateChange(PersonaStateChange_t param)
	{
		Action<ulong> a_PlayerInformationArrived = A_PlayerInformationArrived;
		if (A_PlayerInformationArrived != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v45 @ r9_v1 (System.Action`1<System.UInt64>)+18] (should have been resolved before IL gen)");
		}
	}

	protected virtual void Update()
	{
		if (initialized)
		{
			SteamAPI.RunCallbacks();
			Action a_UpdateComponents = A_UpdateComponents;
			if (A_UpdateComponents != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v54.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	public static bool IsInitialized()
	{
		return initialized;
	}

	static SteamManager()
	{
		//IL_0019: Expected O, but got I4
		//IL_0023: Expected I8, but got I4
		initialized = false;
		APP_ID = (AppId_t)3405340;
		steamId = 0uL;
	}
}
