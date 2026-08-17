using System;
using System.Threading.Tasks;
using Coherence.Cloud;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using VampireSurvivors.Objects;
using VampireSurvivors.UI;

namespace VampireSurvivors.Framework;

public static class OnlinePlatformSupport
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action<bool> _003C_003E9__23_2;

		public static Action<bool> _003C_003E9__23_1;

		public static Action<bool> _003C_003E9__23_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CTryJoinLobby_003Eb__23_0(bool hasInternetConnection)
		{
			//IL_00b0: Expected I4, but got O
			Debug.Log("CheckHasInternetConnection() called");
			if (!hasInternetConnection)
			{
				Debug.Log("CheckHasInternetConnection() returned false so clearing invites");
				onlineChecksInProgress = false;
				return;
			}
			Debug.Log("CheckHasInternetConnection() returned true");
			Action<bool> callback = _003C_003E9__23_1;
			if (_003C_003E9__23_1 == null)
			{
				Action<bool> action = null;
				((_003C_003Ec)(object)action)._003CTryJoinLobby_003Eb__23_1((byte)(int)_003C_003E9 != 0);
				_003C_003E9__23_1 = action;
				callback = action;
			}
			if (OnlinePlatformSupportInstance == null)
			{
				Setup();
			}
			OnlinePlatformSupportInstance.CheckAgeOk(callback);
		}

		internal void _003CTryJoinLobby_003Eb__23_1(bool ageOk)
		{
			//IL_00b0: Expected I4, but got O
			Debug.Log("CheckAgeOk() called");
			if (!ageOk)
			{
				Debug.Log("CheckAgeOk() returned false so clearing invites");
				onlineChecksInProgress = false;
				return;
			}
			Debug.Log("CheckAgeOk() returned true");
			Action<bool> callback = _003C_003E9__23_2;
			if (_003C_003E9__23_2 == null)
			{
				Action<bool> action = null;
				((_003C_003Ec)(object)action)._003CTryJoinLobby_003Eb__23_2((byte)(int)_003C_003E9 != 0);
				_003C_003E9__23_2 = action;
				callback = action;
			}
			if (OnlinePlatformSupportInstance == null)
			{
				Setup();
			}
			OnlinePlatformSupportInstance.CheckOnlineEntitlement(callback);
		}

		internal void _003CTryJoinLobby_003Eb__23_2(bool hasOnlineEntitlement)
		{
			Debug.Log("CheckOnlineEntitlement() called");
			if (!hasOnlineEntitlement)
			{
				Debug.Log("CheckOnlineEntitlement() returned false so clearing invites");
				onlineChecksInProgress = false;
				return;
			}
			Debug.Log("CheckOnlineEntitlement() returned true");
			onlineChecksInProgress = false;
			AppStateMachine appStateMachine = AppStateMachine._003CInstance_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A978D0");
		}
	}

	public static OnlinePlatformSupportBase OnlinePlatformSupportInstance;

	public const string CommunicatingPopupID = "OnlinePlatformSupportCommunicating";

	public const string HostStartingGamePopupID = "HostStartingGame";

	private static Task<bool> leaveLobbyTask;

	private static bool onlineChecksInProgress;

	public static bool WaitForServerResponseOnEnteringOnline
	{
		get
		{
			//IL_000d: Expected I, but got O
			OnlinePlatformSupportBase onlinePlatformSupportInstance = OnlinePlatformSupportInstance;
			if (OnlinePlatformSupportInstance != null)
			{
				nint num = (nint)onlinePlatformSupportInstance;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v40 @ rdx_v1 (Il2CppClass<VampireSurvivors.Framework.OnlinePlatformSupportBase>)+178] (should have been resolved before IL gen)");
			}
			return false;
		}
	}

	public static void Setup()
	{
		if (OnlinePlatformSupportInstance == null)
		{
			Debug.Log("<OnlinePlatformSupport.Setup> setup online platform support");
			OnlinePlatformSupportBase onlinePlatformSupportInstance = new OnlinePlatformSupportBase();
			OnlinePlatformSupportInstance = onlinePlatformSupportInstance;
			OnlinePlatformSupportInstance.Initialise();
			Action value = OnUpdate;
			SystemPlatform.OnUpdate += value;
		}
	}

	public static void AutoJoinLobby(string lobbyID)
	{
		if (OnlinePlatformSupportInstance == null)
		{
			Setup();
		}
		string message = "Try join lobby with ID " + lobbyID;
		Debug.Log(message);
	}

	public static void OnLobbyOpen(string lobbyID)
	{
		if (OnlinePlatformSupportInstance == null)
		{
			Setup();
		}
		OnlinePlatformSupportInstance.OnLobbyOpen(lobbyID);
	}

	public static void OnLobbyClosed(string lobbyID)
	{
		if (OnlinePlatformSupportInstance == null)
		{
			Setup();
		}
		OnlinePlatformSupportInstance.OnLobbyClosed(lobbyID);
	}

	public static void CheckAgeOk(Action<bool> callback)
	{
		if (OnlinePlatformSupportInstance == null)
		{
			Setup();
		}
		OnlinePlatformSupportInstance.CheckAgeOk(callback);
	}

	public static void CheckOnlineEntitlement(Action<bool> callback)
	{
		if (OnlinePlatformSupportInstance == null)
		{
			Setup();
		}
		OnlinePlatformSupportInstance.CheckOnlineEntitlement(callback);
	}

	public static void OnCreatedOnlineSession(string lobbyId, Action<bool> callback)
	{
		if (OnlinePlatformSupportInstance == null)
		{
			Setup();
		}
		OnlinePlatformSupportInstance.OnCreatedOnlineSession(lobbyId, callback);
	}

	public static void OnJoinedOnlineSession(string lobbyID, Action<bool> callback)
	{
		if (OnlinePlatformSupportInstance == null)
		{
			Setup();
		}
		OnlinePlatformSupportInstance.OnJoinedOnlineSession(lobbyID, callback);
	}

	public static void OnRemotePlayerJoinedRoom(string lobbyID, Action<bool> callback)
	{
		if (OnlinePlatformSupportInstance == null)
		{
			Setup();
		}
		OnlinePlatformSupportInstance.OnRemotePlayerJoinedRoom(lobbyID, callback);
	}

	public static void OnPlayerLeftOnlineSession(string lobbyID, Action<bool> callback)
	{
		if (OnlinePlatformSupportInstance == null)
		{
			Setup();
		}
		OnlinePlatformSupportInstance.OnPlayerLeftOnlineSession(lobbyID, callback);
	}

	public static void OnEndOnlineSession(string lobbyID, Action<bool> callback)
	{
		if (OnlinePlatformSupportInstance == null)
		{
			Setup();
		}
		OnlinePlatformSupportInstance.OnEndOnlineSession(lobbyID, callback);
	}

	public static void OnConnectionError()
	{
		if (OnlinePlatformSupportInstance != null)
		{
			OnlinePlatformSupportInstance.OnConnectionError();
		}
	}

	public static void CheckHasInternetConnection(Action<bool> callback)
	{
		if (OnlinePlatformSupportInstance == null)
		{
			Setup();
		}
		if (OnlinePlatformSupportInstance != null)
		{
			OnlinePlatformSupportInstance.CheckInternetConnectionState(callback);
		}
	}

	public static void OnUpdate()
	{
		if (OnlinePlatformSupportInstance == null)
		{
			Setup();
		}
		if (OnlinePlatformSupportInstance != null)
		{
			OnlinePlatformSupportInstance.OnUpdate();
		}
	}

	public static void ShowUsersProfile(string userId)
	{
		if (OnlinePlatformSupportInstance == null)
		{
			Setup();
		}
		OnlinePlatformSupportInstance.ShowUsersProfile(userId);
	}

	public static void InvitePlayers(string lobbyID)
	{
		if (OnlinePlatformSupportInstance == null)
		{
			Setup();
		}
		OnlinePlatformSupportInstance.InvitePlayers(lobbyID);
	}

	public static bool TryJoinLobby(bool havePendingInvite, string pendingInviteLobbyID)
	{
		//IL_0c89: Expected I4, but got O
		//IL_0b5a: Expected O, but got I
		//IL_0b92: Expected O, but got I4
		//IL_0b9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b9f: Expected O, but got Unknown
		//IL_0bf5: Expected I, but got O
		//IL_0c0b: Expected O, but got I
		//IL_0c22: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c27: Expected O, but got Unknown
		//IL_0c3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c43: Expected O, but got Unknown
		//IL_0c4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c51: Expected O, but got Unknown
		//IL_0c5e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c63: Expected O, but got Unknown
		//IL_0de7: Expected O, but got I4
		//IL_02a8: Expected O, but got I
		//IL_02db: Expected I, but got O
		//IL_02f3: Expected O, but got I
		//IL_0373: Expected O, but got I4
		//IL_0cfa: Expected O, but got I4
		//IL_032f: Expected O, but got I
		//IL_0388: Expected O, but got I
		//IL_0365: Expected O, but got I4
		//IL_039b: Expected I, but got O
		//IL_03b3: Expected O, but got I
		//IL_0427: Expected I, but got O
		//IL_0437: Expected O, but got I
		//IL_04ab: Expected I, but got O
		//IL_04bb: Expected O, but got I
		//IL_03ef: Expected O, but got I
		//IL_052f: Expected I, but got O
		//IL_053f: Expected O, but got I
		//IL_0473: Expected O, but got I
		//IL_05b3: Expected I, but got O
		//IL_05c3: Expected O, but got I
		//IL_04f7: Expected O, but got I
		//IL_0637: Expected I, but got O
		//IL_0647: Expected O, but got I
		//IL_057b: Expected O, but got I
		//IL_06bb: Expected I, but got O
		//IL_06cb: Expected O, but got I
		//IL_05ff: Expected O, but got I
		//IL_073f: Expected I, but got O
		//IL_074f: Expected O, but got I
		//IL_0683: Expected O, but got I
		//IL_07c3: Expected I, but got O
		//IL_07d3: Expected O, but got I
		//IL_0707: Expected O, but got I
		//IL_0847: Expected I, but got O
		//IL_0857: Expected O, but got I
		//IL_078b: Expected O, but got I
		//IL_0d45: Expected I4, but got O
		//IL_0912: Expected I, but got O
		//IL_0922: Expected O, but got I
		//IL_080f: Expected O, but got I
		//IL_0893: Expected O, but got I
		//IL_095e: Expected O, but got I
		//IL_09c0: Expected O, but got I
		//IL_0a8b: Expected O, but got I
		//IL_09f5: Expected O, but got I
		//IL_0aef: Expected O, but got I
		//IL_0a4e: Expected O, but got I
		Debug.Log("OnlinePlatformSupport.TryJoinLobby() called");
		object obj6;
		LobbiesManager lobbiesManager2;
		if (leaveLobbyTask == null)
		{
			GameManager core = GM.Core;
			if ((object)GM.Core == null || ((UnityEngine.Object)core).m_CachedPtr == (IntPtr)0)
			{
				AppStateMachine appStateMachine = AppStateMachine._003CInstance_003Ek__BackingField;
				if ((object)AppStateMachine._003CInstance_003Ek__BackingField != null && ((UnityEngine.Object)appStateMachine).m_CachedPtr != (IntPtr)0)
				{
					Debug.Log("AppStateMachine.Instance exists");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186B33340");
					object obj = default(object);
					if (obj == null)
					{
						goto IL_0c7b;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ rax_v48+40]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ rax_v48+40]");
					if ((nint)0 != 0)
					{
						nint num = (nint)typeof(AppStateMachineState);
						object obj3 = obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v915 @ rdx_v12 (Il2CppClass<VampireSurvivors.AppStateMachineState>)+130]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v575 @ r9_v4+130]");
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v915 @ rdx_v12 (Il2CppClass<VampireSurvivors.AppStateMachineState>)+130]");
						if (num2 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v575 @ r9_v4+C8]");
							object obj5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v935 @ rax_v120+FFFFFFF8+v916 @ rax_v49*8]");
							if (0 == (nint)typeof(AppStateMachineState))
							{
								obj6 = 1;
								goto IL_0ce2;
							}
						}
						obj6 = 0;
						goto IL_0ce2;
					}
				}
				goto IL_0211;
			}
			Debug.Log("GM core exists so returning to menu and leaving lobby");
			GameManager core2 = GM.Core;
			if ((object)GM.Core != null)
			{
				Stage stage = core2._stage;
				if ((object)core2._stage != null)
				{
					if (stage._lobbiesManager != null)
					{
						GameManager core3 = GM.Core;
						Stage stage2 = core3._stage;
						LobbiesManager lobbiesManager = stage2._lobbiesManager;
						if (lobbiesManager._activeLobby != null)
						{
							LobbySession activeLobby = lobbiesManager._activeLobby;
							if (!activeLobby._003CIsDisposed_003Ek__BackingField && leaveLobbyTask == null)
							{
								GameManager core4 = GM.Core;
								if ((object)GM.Core != null)
								{
									Stage stage3 = core4._stage;
									if ((object)core4._stage != null)
									{
										lobbiesManager2 = stage3._lobbiesManager;
										goto IL_0d5b;
									}
								}
								goto IL_0c7b;
							}
						}
					}
					GM.Core.ResetGameToMenu();
					return false;
				}
			}
		}
		else
		{
			Debug.Log("waiting on leave lobby task");
			Task<bool> task = leaveLobbyTask;
			if (leaveLobbyTask != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rbx_v2 (System.Threading.Tasks.Task`1<System.Boolean>)+38]");
				object obj7 = (nint)0 & (nint)0x1600000;
				bool flag = obj7 == null;
				bool flag2 = (nint)obj7 < 0;
				bool flag3 = !flag2;
				object obj8 = !flag3;
				object obj9 = obj8 | flag;
				if (obj9 == null)
				{
					Debug.Log("leave lobby task completed");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
					bool flag4 = (nint)0 == 0;
					leaveLobbyTask = null;
					if (!flag4)
					{
						nint num3 = (nint)typeof(OnlinePlatformSupport);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v768 @ rax_v15 (Il2CppClass<VampireSurvivors.Framework.OnlinePlatformSupport>)+B8]");
						object obj10 = (nint)0 + (nint)8;
						object obj11 = obj10 >> 12;
						object obj12 = obj11 & 0x1FFFFF;
						object obj13 = obj12 >> 6;
						object obj14 = obj12 & 0x3F;
						object obj15 = obj13 * 8;
						object obj16 = 6603864928L + obj15;
						do
						{
							object obj17 = 1 << (int)obj14;
							object obj18 = obj16 | obj17;
							if (obj16 == obj16)
							{
								obj16 = obj18;
							}
						}
						while (obj16 != obj16);
						return false;
					}
				}
				goto IL_0211;
			}
		}
		goto IL_0c7b;
		IL_08c0:
		if (!onlineChecksInProgress)
		{
			onlineChecksInProgress = true;
			Action<bool> callback = _003C_003Ec._003C_003E9__23_0;
			if (_003C_003Ec._003C_003E9__23_0 == null)
			{
				Action<bool> action = null;
				((_003C_003Ec)(object)action)._003CTryJoinLobby_003Eb__23_0((byte)(int)_003C_003Ec._003C_003E9 != 0);
				_003C_003Ec._003C_003E9__23_0 = action;
				callback = action;
			}
			CheckHasInternetConnection(callback);
			return false;
		}
		goto IL_0211;
		IL_0211:
		return false;
		IL_0c7b:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0ce2:
		bool flag5 = obj6 == null;
		object obj19 = 0;
		if (!flag5)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ rax_v48+40]");
			obj19 = 0;
		}
		if (obj19 != null)
		{
			nint num4 = (nint)typeof(AppCharacterSelectionState);
			object obj20 = obj19;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v994 @ r8_v10 (Il2CppClass<VampireSurvivors.AppCharacterSelectionState>)+130]");
			object obj21 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ r9_v5+130]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v994 @ r8_v10 (Il2CppClass<VampireSurvivors.AppCharacterSelectionState>)+130]");
			if (num5 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ r9_v5+C8]");
				object obj22 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1009 @ rax_v117+FFFFFFF8+v995 @ rax_v51*8]");
				if (0 == (nint)typeof(AppCharacterSelectionState))
				{
					goto IL_08c0;
				}
			}
			nint num6 = (nint)typeof(AppAchievementsState);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1032 @ r8_v14 (Il2CppClass<VampireSurvivors.AppAchievementsState>)+130]");
			object obj23 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ r9_v5+130]");
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1032 @ r8_v14 (Il2CppClass<VampireSurvivors.AppAchievementsState>)+130]");
			if (num7 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ r9_v5+C8]");
				object obj24 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1056 @ rax_v116+FFFFFFF8+v1033 @ rax_v69*8]");
				if (0 == (nint)typeof(AppAchievementsState))
				{
					goto IL_08c0;
				}
			}
			nint num8 = (nint)typeof(AppBestiaryState);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1047 @ r8_v15 (Il2CppClass<VampireSurvivors.AppBestiaryState>)+130]");
			object obj25 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ r9_v5+130]");
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1047 @ r8_v15 (Il2CppClass<VampireSurvivors.AppBestiaryState>)+130]");
			if (num9 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ r9_v5+C8]");
				object obj26 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1057 @ rax_v115+FFFFFFF8+v1195 @ rax_v71*8]");
				if (0 == (nint)typeof(AppBestiaryState))
				{
					goto IL_08c0;
				}
			}
			nint num10 = (nint)typeof(AppCollectionState);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1048 @ r8_v16 (Il2CppClass<VampireSurvivors.AppCollectionState>)+130]");
			object obj27 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ r9_v5+130]");
			nint num11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1048 @ r8_v16 (Il2CppClass<VampireSurvivors.AppCollectionState>)+130]");
			if (num11 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ r9_v5+C8]");
				object obj28 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1058 @ rax_v114+FFFFFFF8+v1231 @ rax_v73*8]");
				if (0 == (nint)typeof(AppCollectionState))
				{
					goto IL_08c0;
				}
			}
			nint num12 = (nint)typeof(AppCreditsState);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1049 @ r8_v17 (Il2CppClass<VampireSurvivors.AppCreditsState>)+130]");
			object obj29 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ r9_v5+130]");
			nint num13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1049 @ r8_v17 (Il2CppClass<VampireSurvivors.AppCreditsState>)+130]");
			if (num13 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ r9_v5+C8]");
				object obj30 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1059 @ rax_v113+FFFFFFF8+v1272 @ rax_v75*8]");
				if (0 == (nint)typeof(AppCreditsState))
				{
					goto IL_08c0;
				}
			}
			nint num14 = (nint)typeof(AppDLCStoreState);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1050 @ r8_v18 (Il2CppClass<VampireSurvivors.AppDLCStoreState>)+130]");
			object obj31 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ r9_v5+130]");
			nint num15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1050 @ r8_v18 (Il2CppClass<VampireSurvivors.AppDLCStoreState>)+130]");
			if (num15 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ r9_v5+C8]");
				object obj32 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1060 @ rax_v112+FFFFFFF8+v1318 @ rax_v77*8]");
				if (0 == (nint)typeof(AppDLCStoreState))
				{
					goto IL_08c0;
				}
			}
			nint num16 = (nint)typeof(AppMainMenuState);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1051 @ r8_v19 (Il2CppClass<VampireSurvivors.AppMainMenuState>)+130]");
			object obj33 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ r9_v5+130]");
			nint num17 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1051 @ r8_v19 (Il2CppClass<VampireSurvivors.AppMainMenuState>)+130]");
			if (num17 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ r9_v5+C8]");
				object obj34 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1061 @ rax_v111+FFFFFFF8+v1349 @ rax_v79*8]");
				if (0 == (nint)typeof(AppMainMenuState))
				{
					goto IL_08c0;
				}
			}
			nint num18 = (nint)typeof(AppOptionsState);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1052 @ r8_v20 (Il2CppClass<VampireSurvivors.AppOptionsState>)+130]");
			object obj35 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ r9_v5+130]");
			nint num19 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1052 @ r8_v20 (Il2CppClass<VampireSurvivors.AppOptionsState>)+130]");
			if (num19 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ r9_v5+C8]");
				object obj36 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1062 @ rax_v110+FFFFFFF8+v1375 @ rax_v81*8]");
				if (0 == (nint)typeof(AppOptionsState))
				{
					goto IL_08c0;
				}
			}
			nint num20 = (nint)typeof(AppPowerUpState);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1053 @ r8_v21 (Il2CppClass<VampireSurvivors.AppPowerUpState>)+130]");
			object obj37 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ r9_v5+130]");
			nint num21 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1053 @ r8_v21 (Il2CppClass<VampireSurvivors.AppPowerUpState>)+130]");
			if (num21 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ r9_v5+C8]");
				object obj38 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1063 @ rax_v109+FFFFFFF8+v1403 @ rax_v83*8]");
				if (0 == (nint)typeof(AppPowerUpState))
				{
					goto IL_08c0;
				}
			}
			nint num22 = (nint)typeof(AppSecretsState);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1046 @ r8_v22 (Il2CppClass<VampireSurvivors.AppSecretsState>)+130]");
			object obj39 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ r9_v5+130]");
			nint num23 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1046 @ r8_v22 (Il2CppClass<VampireSurvivors.AppSecretsState>)+130]");
			if (num23 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ r9_v5+C8]");
				object obj40 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1055 @ rax_v108+FFFFFFF8+v1427 @ rax_v85*8]");
				if (0 == (nint)typeof(AppSecretsState))
				{
					goto IL_08c0;
				}
			}
			nint num24 = (nint)typeof(AppOnlineState);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ r8_v23 (Il2CppClass<VampireSurvivors.AppOnlineState>)+130]");
			object obj41 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ r9_v5+130]");
			nint num25 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ r8_v23 (Il2CppClass<VampireSurvivors.AppOnlineState>)+130]");
			if (num25 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ r9_v5+C8]");
				object obj42 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v587 @ rax_v88+FFFFFFF8+v586 @ rax_v87*8]");
				if (0 == (nint)typeof(AppOnlineState))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rdx_v14+38]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rdx_v14+38]");
						object obj43 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1463 @ rax_v105+10]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1463 @ rax_v105+10]");
							object obj44 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1475 @ rax_v106+178]");
							if ((nint)0 == 0)
							{
								if (leaveLobbyTask != null)
								{
									goto IL_0211;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rdx_v14+38]");
								lobbiesManager2 = (LobbiesManager)0;
								goto IL_0d5b;
							}
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18695F8E0");
					bool flag6 = default(bool);
					if (flag6)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rax_v91 (System.Boolean)+E8]");
						object obj45 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ rax_v91 (System.Boolean)+E8]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rax_v92+28]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rax_v92+28]");
								((TMP_InputField)0).SetText(pendingInviteLobbyID, true);
								Action<bool> action2 = null;
								((RoomSelectionPage)(object)action2)._003CJoinRoom_003Eb__56_0(flag6);
								CheckHasInternetConnection(action2);
								Debug.Log("Consume the invite request");
								return true;
							}
						}
					}
					goto IL_0c7b;
				}
			}
		}
		goto IL_0211;
		IL_0d5b:
		if (lobbiesManager2 != null)
		{
			Task<bool> task2 = lobbiesManager2.LeaveLobby();
			leaveLobbyTask = task2;
			goto IL_0211;
		}
		goto IL_0c7b;
	}

	private static void ClearInvites()
	{
	}

	private static void CloseOnlineCommunicatingPopup()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2822]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		PopupManager.ClosePopup("OnlinePlatformSupportCommunicating");
	}
}
