using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Coherence.Cloud;
using Cpp2ILInjected;
using Steamworks;
using Steamworks.Data;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.DLC;
using VampireSurvivors.Framework.Platforms.Saves;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Framework.Platforms.SteamworksIntegration;

public class SteamworksAccount : IBaseAccount
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<byte, string> _003C_003E9__22_0;

		public static Action<Exception> _003C_003E9__26_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal unsafe string _003CGetAuthToken_003Eb__22_0(byte b)
		{
			//IL_004d: Expected O, but got Ref
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A29A6]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if ("X2" != null)
			{
			}
			object obj = default(object);
			return System.Number.FormatInt32(b, (ReadOnlySpan<char>)(&obj), null);
		}

		internal void _003CInitBasicSteamCallbacks_003Eb__26_0(Exception exception)
		{
			string text = exception?.ToString();
			string message = "[Steamworks.NET] - Exception in Steamworks: " + text;
			Debug.LogError(message);
		}
	}

	private sealed class _003C_003Ec__DisplayClass24_0
	{
		public SteamworksAccount _003C_003E4__this;

		public Action<LoginOperation> onComplete;

		internal unsafe void _003CLoginWithCoherence_003Eb__0(PlatformAuthToken token)
		{
			//IL_0041: Expected O, but got I4
			//IL_0041: Expected O, but got Ref
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18997FE13]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if (token._003CToken_003Ek__BackingField != null)
			{
				/*Error: End of method reached without returning.*/;
			}
			object obj = default(object);
			LoginOperation loginOperation = CoherenceCloud.Login((Coherence.Cloud.LoginInfo)(&obj), (CancellationToken)0);
			LoginOperation loginOperation2 = loginOperation.ContinueWith(onComplete);
		}

		internal void _003CLoginWithCoherence_003Eb__1(string error)
		{
			Action<LoginOperation> action = onComplete;
			if (onComplete != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v0 @ rax_v1 (System.Action`1<Coherence.Cloud.LoginOperation>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	private IPlatformSaveUtils m_Storage;

	private IPlatformAchievementsManager m_AchievementsManager;

	private AuthTicket _sessionTicket;

	private PlatformAuthToken _authToken;

	private string _steamID;

	private bool m_IsInitialised;

	public override string LocalID => m_Name;

	public override string OnlineID => m_Name;

	public override string UniqueAccountID => _steamID;

	public override IPlatformSaveUtils Storage => m_Storage;

	public override IPlatformAchievementsManager AchievementsManager => m_AchievementsManager;

	public static uint GetAppID()
	{
		return 1794680u;
	}

	public bool IsSteamInitialised()
	{
		return m_IsInitialised;
	}

	public SteamworksAccount(int rewiredPlayerId = 0)
	{
		//IL_007d: Expected I, but got O
		//IL_009f: Expected I, but got O
		base._002Ector(rewiredPlayerId);
		SteamworksCloudStorage steamworksCloudStorage = new SteamworksCloudStorage();
		nint num = (nint)typeof(ErroInfo);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rax_v6 (Il2CppClass<VampireSurvivors.Framework.Platforms.ErroInfo>)+B8]");
		nint num2 = 0;
		steamworksCloudStorage.m_LastError = ErroInfo.NonError;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v7 (Il2CppStaticFields<VampireSurvivors.Framework.Platforms.ErroInfo>)+10]");
		_ = 0;
		m_Storage = steamworksCloudStorage;
		SteamworksAchievementsManager steamworksAchievementsManager = new SteamworksAchievementsManager();
		nint num3 = (nint)typeof(ErroInfo);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ rax_v14 (Il2CppClass<VampireSurvivors.Framework.Platforms.ErroInfo>)+B8]");
		nint num4 = 0;
		steamworksAchievementsManager.m_LastError = ErroInfo.NonError;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v260 @ rax_v15 (Il2CppStaticFields<VampireSurvivors.Framework.Platforms.ErroInfo>)+10]");
		_ = 0;
		m_AchievementsManager = steamworksAchievementsManager;
		SystemPlatform.OnQuit += OnDestroy;
		SystemPlatform.OnUpdate += OnUpdate;
	}

	private unsafe void OnDestroy()
	{
		//IL_009a: Expected O, but got I
		//IL_00bd: Expected O, but got I4
		//IL_00e2: Expected O, but got Ref
		if (!m_IsInitialised)
		{
			return;
		}
		Action value = OnDestroy;
		SystemPlatform.OnQuit -= value;
		Action value2 = OnUpdate;
		SystemPlatform.OnUpdate -= value2;
		m_IsInitialised = false;
		if (SteamClient.initialized)
		{
			SteamClient.Cleanup();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189981028]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189981028]");
			bool flag = (nint)0 != 0;
			object obj2 = 0;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02E50");
				object obj3 = default(object);
				obj2 = (object)(&obj3);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v240 @ rax_v18 (should have been resolved before IL gen)");
		}
	}

	private void OnUpdate()
	{
		if (m_IsInitialised)
		{
			if ((object)Dispatch._003CClientPipe_003Ek__BackingField != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182D808E0");
				Steamworks.Data.HSteamPipe pipe = default(Steamworks.Data.HSteamPipe);
				Dispatch.Frame(pipe);
			}
			SteamServer.RunCallbacks();
		}
	}

	public void CleanAuthToken()
	{
		_sessionTicket.Cancel();
	}

	public unsafe override void GetAuthToken(Action<PlatformAuthToken> onSuccess, Action<string> onError, Action<TokenAbortReason> onAbort, string url = "https://playfabapi.com/")
	{
		//IL_0024: Expected O, but got I
		//IL_0069: Expected O, but got Ref
		if (_authToken == null)
		{
			Debug.Log("[Steamworks.NET] - Fetching new Steam session ticket");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189983738]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189983738]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02E50");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v162 @ rax_v18 (should have been resolved before IL gen)");
			object obj2 = default(object);
			AuthTicket authSessionTicket = SteamUser.GetAuthSessionTicket((NetIdentity)(&obj2));
			_sessionTicket = authSessionTicket;
			AuthTicket sessionTicket = _sessionTicket;
			PlatformAuthToken platformAuthToken = new PlatformAuthToken();
			Func<byte, string> selector = _003C_003Ec._003C_003E9__22_0;
			if (_003C_003Ec._003C_003E9__22_0 == null)
			{
				selector = (_003C_003Ec._003C_003E9__22_0 = delegate(byte b)
				{
					//IL_004d: Expected O, but got Ref
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A29A6]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					if ("X2" != null)
					{
					}
					object obj3 = default(object);
					return System.Number.FormatInt32(b, (ReadOnlySpan<char>)(&obj3), null);
				});
			}
			IEnumerable<string> enumerable = Enumerable.Select(sessionTicket.Data, selector);
			string text = string.Concat(enumerable);
			platformAuthToken._003CToken_003Ek__BackingField = text;
			_authToken = platformAuthToken;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [onSuccess @ rdx (System.Action`1<VampireSurvivors.Framework.Platforms.PlatformAuthToken>)+18] (should have been resolved before IL gen)");
		}
		else
		{
			Debug.Log("[Steamworks.NET] - Reusing the Steam session ticket");
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [onSuccess @ rdx (System.Action`1<VampireSurvivors.Framework.Platforms.PlatformAuthToken>)+18] (should have been resolved before IL gen)");
		}
	}

	public override void LoginAsync(LoginOptions options, Action<LoginResult> onComplete)
	{
		//IL_0029: Expected O, but got I4
		//IL_0064: Expected O, but got I
		//IL_004f: Expected O, but got I4
		//IL_00c9: Expected O, but got I
		//IL_0128: Expected O, but got I
		//IL_01ac: Expected O, but got I
		Debug.Log("[Steamworks.NET] - Calling Steamworks LoginAsync");
		bool flag = !m_IsInitialised;
		object obj = 0;
		if (!flag)
		{
			Debug.LogError("[Steamworks.NET] - Tried to initialize the SteamAPI twice in one session!");
			obj = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189981038]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189981038]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02E50");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v168 @ rax_v7 (should have been resolved before IL gen)");
		object obj3 = default(object);
		if (obj3 == null)
		{
			m_IsInitialised = true;
			Steamworks.ISteamNetworking steamNetworking = SteamNetworking.Internal;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189982220]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189982220]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02E50");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v313 @ rax_v17 (should have been resolved before IL gen)");
			Steamworks.ISteamNetworkingUtils steamNetworkingUtils = SteamNetworkingUtils.Internal;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189982438]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189982438]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02E50");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v482 @ rax_v24 (should have been resolved before IL gen)");
			SteamId steamId = SteamClient.SteamId;
			ulong num = default(ulong);
			string steamID = num.ToString();
			_steamID = steamID;
			Steamworks.ISteamFriends steamFriends = SteamFriends.Internal;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189981408]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189981408]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02E50");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v591 @ rax_v32 (should have been resolved before IL gen)");
			Steamworks.Utf8StringPointer utf8StringPointer = default(Steamworks.Utf8StringPointer);
			string name = utf8StringPointer;
			m_Name = name;
			if (m_LoginState != LoginState.OnlineLoggedIn)
			{
				m_LoginState = LoginState.OnlineLoggedIn;
			}
			InitBasicSteamCallbacks();
			Action<LoginResult> action = default(Action<LoginResult>);
			if (action != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v225 @ r8_v3 (System.Action`1<VampireSurvivors.Framework.Platforms.LoginResult>)+18] (should have been resolved before IL gen)");
			}
		}
		else
		{
			Application.Quit();
		}
	}

	public unsafe override void LoginWithCoherence(Action<LoginOperation> onComplete)
	{
		_003C_003Ec__DisplayClass24_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass24_0();
		CS_0024_003C_003E8__locals5._003C_003E4__this = this;
		CS_0024_003C_003E8__locals5.onComplete = onComplete;
		Action<PlatformAuthToken> onSuccess = delegate(PlatformAuthToken token)
		{
			//IL_0041: Expected O, but got I4
			//IL_0041: Expected O, but got Ref
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18997FE13]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if (token._003CToken_003Ek__BackingField != null)
			{
				/*Error: End of method reached without returning.*/;
			}
			object obj = default(object);
			LoginOperation loginOperation = CoherenceCloud.Login((Coherence.Cloud.LoginInfo)(&obj), (CancellationToken)0);
			LoginOperation loginOperation2 = loginOperation.ContinueWith(CS_0024_003C_003E8__locals5.onComplete);
		};
		Action<string> onError = delegate
		{
			Action<LoginOperation> onComplete2 = CS_0024_003C_003E8__locals5.onComplete;
			if (CS_0024_003C_003E8__locals5.onComplete != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v0 @ rax_v1 (System.Action`1<Coherence.Cloud.LoginOperation>)+18] (should have been resolved before IL gen)");
			}
		};
		GetAuthToken(onSuccess, onError, null, null);
	}

	private unsafe void OnAuthTokenSuccess(PlatformAuthToken token, Action<LoginOperation> onComplete)
	{
		//IL_0041: Expected O, but got I4
		//IL_0041: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18997FE13]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (token._003CToken_003Ek__BackingField != null)
		{
			/*Error: End of method reached without returning.*/;
		}
		object obj = default(object);
		LoginOperation loginOperation = CoherenceCloud.Login((Coherence.Cloud.LoginInfo)(&obj), (CancellationToken)0);
		LoginOperation loginOperation2 = loginOperation.ContinueWith(onComplete);
	}

	private void InitBasicSteamCallbacks()
	{
		//IL_0190: Expected I4, but got O
		//IL_000e: Expected O, but got I4
		//IL_0050: Expected I, but got O
		//IL_0066: Expected O, but got I
		Action<bool> action = null;
		((SteamworksAccount)(object)action).OnSteamOverlayActivated((byte)(int)this != 0);
		Delegate obj = SteamFriends.OnGameOverlayActivated;
		object obj4 = default(object);
		bool flag3;
		do
		{
			Delegate obj2 = Delegate.Combine(obj, action);
			object obj3;
			if ((object)obj2 == null)
			{
				obj3 = 0;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				bool flag = obj4 == null;
				obj3 = obj4;
				if (flag)
				{
					throw new InvalidCastException();
				}
			}
			nint num = (nint)typeof(SteamFriends);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rcx_v13 (Il2CppClass<Steamworks.SteamFriends>)+B8]");
			object obj5 = (nint)0 + (nint)40;
			bool flag2 = obj == obj5;
			Delegate obj6;
			if (obj == obj5)
			{
				obj5 = obj3;
				obj6 = obj;
			}
			else
			{
				obj6 = (Delegate)obj5;
			}
			Delegate obj7 = obj;
			if (!flag2)
			{
				obj7 = obj6;
			}
			flag3 = (object)obj7 != obj;
			obj = obj7;
		}
		while (flag3);
		Delegate b = _003C_003Ec._003C_003E9__26_0;
		if (_003C_003Ec._003C_003E9__26_0 == null)
		{
			b = (_003C_003Ec._003C_003E9__26_0 = delegate(Exception exception)
			{
				string text = exception?.ToString();
				string message = "[Steamworks.NET] - Exception in Steamworks: " + text;
				Debug.LogError(message);
			});
		}
		Delegate obj8 = Delegate.Combine(Dispatch.OnException, b);
		if ((object)obj8 == null)
		{
			Dispatch.OnException = (Action<Exception>)obj8;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		Action<Exception> action2 = default(Action<Exception>);
		if (action2 != null)
		{
			Dispatch.OnException = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj9 = default(object);
			if (obj9 != null)
			{
				return;
			}
			throw new InvalidCastException();
		}
		throw new InvalidCastException();
	}

	private void OnSteamOverlayActivated(bool wasOverlayActivated)
	{
		if (!wasOverlayActivated)
		{
			return;
		}
		GameManager core = GM.Core;
		if ((object)GM.Core != null && ((UnityEngine.Object)core).m_CachedPtr != (IntPtr)0)
		{
			Debug.Log("[Steamworks.NET] - Steam overlay has been activated");
			GameManager core2 = GM.Core;
			if (!core2._multiplayer.IsOnlineMultiplayer)
			{
				GameManager core3 = GM.Core;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99300");
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C080");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C080");
			OnlineStageManager onlineStageManager = default(OnlineStageManager);
			PlayerInfo myPlayerInfo = onlineStageManager.GetMyPlayerInfo();
			VampireSurvivors.Objects.Characters.CharacterController characterController = myPlayerInfo.CharacterController;
			OnlineStageManager onlineStageManager2 = default(OnlineStageManager);
			onlineStageManager2.SendPauseRequest(characterController);
		}
	}

	public unsafe override void GetAvailableDlc(Action<List<DlcType>> onComplete)
	{
		//IL_0269: Expected I4, but got I8
		//IL_000d: Expected O, but got Ref
		//IL_031d: Expected I, but got O
		//IL_0325: Expected O, but got Ref
		//IL_00a0: Expected O, but got I
		//IL_00a9: Expected O, but got I4
		//IL_01c7: Expected O, but got I
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Expected O, but got Unknown
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected O, but got Unknown
		//IL_012f: Expected O, but got Ref
		//IL_016b: Expected I, but got O
		//IL_019f: Expected I, but got O
		List<DlcType> list = new List<DlcType>();
		SteamApps._003CDlcInformation_003Ed__29 obj = null;
		obj._003C_003E1__state = -2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E7CF00");
		int num = default(int);
		obj._003C_003El__initialThreadId = num;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj3 = default(object);
		object obj2 = (object)(&obj3);
		DlcCatalog dlcCatalog = null;
		object obj4 = default(object);
		object obj14 = default(object);
		object obj15 = default(object);
		uint num3 = default(uint);
		DlcCatalog dlcCatalog2 = default(DlcCatalog);
		while (true)
		{
			object obj13;
			if (obj3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				if (obj4 != null)
				{
					bool flag = obj3 == null;
					dlcCatalog = null;
					if (!flag)
					{
						object obj5 = obj3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ r10_v4+12E]");
						if ((nint)0 >= (nint)0)
						{
							goto IL_00e0;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ r10_v4+B0]");
						object obj6 = 0;
						object obj7 = 0;
						while (true)
						{
							object obj8 = obj7 + obj7;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v364 @ r8_v17+v367 @ rax_v37*8]");
							if (0 == (nint)typeof(IEnumerator<DlcInformation>))
							{
								break;
							}
							obj7++;
							object obj9 = obj7;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ r10_v4+12E]");
							if ((nint)obj9 < 0)
							{
								continue;
							}
							goto IL_00e0;
						}
						object obj10 = obj7 + obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v364 @ r8_v17+8+v429 @ rcx_v28*8]");
						object obj11 = (nint)0 << 4;
						object obj12 = obj11 + 312;
						obj13 = obj12 + obj5;
						goto IL_02ee;
					}
					throw new NullReferenceException();
				}
				if (obj2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				break;
			}
			throw new NullReferenceException();
			IL_00e0:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			obj13 = obj14;
			goto IL_02ee;
			IL_02ee:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v434 @ r8_v10] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rax_v21+10]");
			bool flag2 = (nint)0 == 0;
			nint num2 = (nint)typeof(IEnumerator<DlcInformation>);
			dlcCatalog = (DlcCatalog)(&obj15);
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186B58C00");
				string appId = num3.ToString();
				bool flag3 = (object)dlcCatalog2 == null;
				dlcCatalog = (DlcCatalog)(&num3);
				if (flag3)
				{
					throw new NullReferenceException();
				}
				DlcType? dlcType_SteamAppId = dlcCatalog2.GetDlcType_SteamAppId(appId);
				bool flag4 = (object)dlcType_SteamAppId == null;
				num2 = (nint)typeof(IEnumerator<DlcInformation>);
				if (!flag4)
				{
					object obj16 = (object?)dlcType_SteamAppId >> 32;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A993B0");
					num2 = (nint)typeof(IEnumerator<DlcInformation>);
				}
			}
		}
		if (onComplete != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [onComplete @ rdx (System.Action`1<System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>>)+18] (should have been resolved before IL gen)");
		}
	}

	public unsafe override void GetLicensedDlc(Action<List<DlcType>> onComplete)
	{
		//IL_0028: Expected O, but got I4
		//IL_0040: Expected O, but got I4
		//IL_0048: Expected O, but got Ref
		List<DlcType> list = new List<DlcType>();
		DlcCatalog dlcCatalog = DlcSystem._dlcCatalog;
		object obj = 2;
		Dictionary<DlcType, DlcData>.Enumerator enumerator = default(Dictionary<DlcType, DlcData>.Enumerator);
		if (enumerator.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			object obj2 = 0;
			Dictionary<DlcType, DlcData>.Enumerator enumerator2 = (Dictionary<DlcType, DlcData>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		if (onComplete != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [onComplete @ rdx (System.Action`1<System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>>)+18] (should have been resolved before IL gen)");
		}
	}

	public override void UpdateInstalledDlc(Action onComplete)
	{
		if (onComplete != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: onComplete.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public unsafe override void MountDlc(DlcType dlcType, Action<string> onComplete)
	{
		//IL_0b4c: Expected O, but got Ref
		//IL_0062: Expected O, but got I4
		//IL_00ee: Expected O, but got I
		//IL_0107: Expected O, but got I
		//IL_011c: Expected O, but got I
		//IL_0b03: Expected O, but got I
		//IL_0dd6: Expected O, but got Ref
		//IL_0cd5: Expected O, but got I
		//IL_01ca: Expected O, but got I
		//IL_01fc: Expected O, but got I4
		//IL_0ac9: Expected O, but got I
		//IL_0ad9: Expected O, but got I
		//IL_09b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_09bb: Expected I, but got Unknown
		//IL_09db: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e0: Expected I, but got Unknown
		//IL_09ed: Expected O, but got I
		//IL_0a69: Expected O, but got I4
		//IL_0a16: Expected O, but got I
		//IL_08f6: Expected O, but got I
		//IL_08c5: Expected O, but got I4
		//IL_0e3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e44: Expected O, but got Unknown
		//IL_0e51: Expected I, but got O
		//IL_0e6b: Expected O, but got I
		//IL_06ab: Expected O, but got I
		//IL_02b3: Expected O, but got I4
		//IL_02c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c5: Expected I4, but got Unknown
		//IL_07ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d3: Expected I, but got Unknown
		//IL_07f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f8: Expected I, but got Unknown
		//IL_0805: Expected O, but got I
		//IL_0306: Unknown result type (might be due to invalid IL or missing references)
		//IL_030b: Expected I, but got Unknown
		//IL_032b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0330: Expected I, but got Unknown
		//IL_033d: Expected O, but got I
		//IL_0881: Expected O, but got I4
		//IL_082e: Expected O, but got I
		//IL_03be: Expected O, but got I4
		//IL_0366: Expected O, but got I
		//IL_0589: Unknown result type (might be due to invalid IL or missing references)
		//IL_058e: Expected I, but got Unknown
		//IL_05ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b3: Expected I, but got Unknown
		//IL_05c0: Expected O, but got I
		//IL_03f2: Expected O, but got I4
		//IL_03fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0400: Expected O, but got Unknown
		//IL_040d: Expected I, but got O
		//IL_042e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0433: Expected I, but got Unknown
		//IL_0440: Expected O, but got I
		//IL_0641: Expected O, but got I4
		//IL_05e9: Expected O, but got I
		//IL_04da: Expected O, but got I
		//IL_0469: Expected O, but got I
		//IL_0682: Expected O, but got I4
		//IL_068c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0691: Expected I, but got Unknown
		DlcCatalog dlcCatalog = DlcSystem._dlcCatalog;
		int num = ((Dictionary<System.Int32Enum, object>)(object)dlcCatalog._DlcData).FindEntry((System.Int32Enum)dlcType);
		object obj = default(object);
		object message;
		string pchFolder;
		string text4;
		string directorySeparatorStr;
		string text5;
		string text6;
		string text7;
		int stringLength2;
		string text8;
		string text10;
		string text3;
		if (num < 0)
		{
			string text = ((Enum)(&obj)).ToString();
			string text2 = "[Steamworks.NET] - DLC (" + text + ") is missing from the DlcCatalog";
			text3 = null;
			message = text2;
		}
		else
		{
			Steamworks.ISteamApps steamApps = SteamApps.Internal;
			if (steamApps.GetAppInstallDir((AppId)1794680, out pchFolder) != 0 && pchFolder != null && pchFolder._stringLength > 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186B58C00");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rax_v100+18]");
				object obj2 = ((Dictionary<System.Int32Enum, object>)0).get_Item((System.Int32Enum)dlcType);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rax_v101 (System.Object)+58]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rsi_v17+10]");
				text4 = (string)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rsi_v17+10]");
				if ((nint)0 != 0)
				{
					if (pchFolder._stringLength != 0)
					{
						if (text4._stringLength != 0)
						{
							int num2 = pchFolder.IndexOfAny(Path.InvalidPathChars, 0, pchFolder._stringLength);
							if (num2 == -1)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rsi_v17+10]");
								int num3 = ((string)0).IndexOfAny(Path.InvalidPathChars, 0, text4._stringLength);
								if (num3 == -1)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rsi_v17+10]");
									if (Path.IsPathRooted((string)0))
									{
										goto IL_0af3;
									}
									int stringLength = pchFolder._stringLength;
									object obj4 = pchFolder._stringLength - 1;
									if ((nint)obj4 < pchFolder._stringLength)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ stack_-48_v18 (System.String)+12+v188 @ rdx_v57 (System.Int32)*2]");
										if ((nint)0 != (int)Path.DirectorySeparatorChar)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ stack_-48_v18 (System.String)+12+v188 @ rdx_v57 (System.Int32)*2]");
											if ((nint)0 != (int)Path.AltDirectorySeparatorChar)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ stack_-48_v18 (System.String)+12+v188 @ rdx_v57 (System.Int32)*2]");
												if ((nint)0 != (int)Path.VolumeSeparatorChar)
												{
													directorySeparatorStr = Path.DirectorySeparatorStr;
													if (pchFolder._stringLength > 0)
													{
														if (Path.DirectorySeparatorStr != null && directorySeparatorStr._stringLength > 0)
														{
															if (text4._stringLength > 0)
															{
																object obj5 = pchFolder._stringLength + directorySeparatorStr._stringLength;
																int length = obj5 + text4._stringLength;
																text5 = string.FastAllocateString(length);
																if (pchFolder._stringLength <= text5._stringLength)
																{
																	byte* ptr = (byte*)(nint)(text5 + 20);
																	int num4 = pchFolder._stringLength + pchFolder._stringLength;
																	byte* ptr2 = (byte*)(nint)(pchFolder + 20);
																	object obj6 = (object)(ptr - (nuint)ptr2);
																	if ((nint)obj6 >= num4)
																	{
																		obj6 = (object)(ptr2 - (nuint)ptr);
																		if ((nint)obj6 >= num4)
																		{
																			Buffer.Memcpy(ptr, ptr2, num4);
																			goto IL_03a7;
																		}
																	}
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
																	goto IL_03a7;
																}
																IndexOutOfRangeException ex = new IndexOutOfRangeException();
																throw ex;
															}
															if (pchFolder._stringLength <= 0)
															{
																if (directorySeparatorStr._stringLength <= 0)
																{
																	goto IL_0ab9;
																}
																text6 = Path.DirectorySeparatorStr;
																goto IL_0dcd;
															}
															if (directorySeparatorStr._stringLength > 0)
															{
																int length2 = directorySeparatorStr._stringLength + pchFolder._stringLength;
																text7 = string.FastAllocateString(length2);
																if (pchFolder._stringLength <= text7._stringLength)
																{
																	byte* ptr3 = (byte*)(nint)(text7 + 20);
																	int num5 = pchFolder._stringLength + pchFolder._stringLength;
																	byte* ptr4 = (byte*)(nint)(pchFolder + 20);
																	object obj7 = (object)(ptr3 - (nuint)ptr4);
																	if ((nint)obj7 >= num5)
																	{
																		obj7 = (object)(ptr4 - (nuint)ptr3);
																		if ((nint)obj7 >= num5)
																		{
																			Buffer.Memcpy(ptr3, ptr4, num5);
																			goto IL_062a;
																		}
																	}
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
																	goto IL_062a;
																}
																IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
																throw ex2;
															}
														}
														else
														{
															if (pchFolder._stringLength <= 0)
															{
																goto IL_0a97;
															}
															if (text4._stringLength > 0)
															{
																stringLength2 = pchFolder._stringLength;
																int length3 = text4._stringLength + pchFolder._stringLength;
																text8 = string.FastAllocateString(length3);
																if (pchFolder._stringLength <= text8._stringLength)
																{
																	byte* ptr5 = (byte*)(nint)(text8 + 20);
																	int num6 = pchFolder._stringLength + pchFolder._stringLength;
																	byte* ptr6 = (byte*)(nint)(pchFolder + 20);
																	object obj8 = (object)(ptr5 - (nuint)ptr6);
																	if ((nint)obj8 >= num6)
																	{
																		obj8 = (object)(ptr6 - (nuint)ptr5);
																		if ((nint)obj8 >= num6)
																		{
																			Buffer.Memcpy(ptr5, ptr6, num6);
																			goto IL_086f;
																		}
																	}
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
																	goto IL_086f;
																}
																IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
																throw ex3;
															}
														}
														goto IL_0ae6;
													}
													string directorySeparatorStr2 = Path.DirectorySeparatorStr;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rsi_v17+10]");
													string text9 = directorySeparatorStr2 + (string)0;
													text6 = text9;
													goto IL_0dcd;
												}
											}
										}
										if (pchFolder._stringLength <= 0)
										{
											goto IL_0a97;
										}
										if (text4._stringLength > 0)
										{
											stringLength2 = pchFolder._stringLength;
											int length4 = text4._stringLength + pchFolder._stringLength;
											text10 = string.FastAllocateString(length4);
											if (pchFolder._stringLength <= text10._stringLength)
											{
												byte* ptr7 = (byte*)(nint)(text10 + 20);
												int num7 = pchFolder._stringLength + pchFolder._stringLength;
												byte* ptr8 = (byte*)(nint)(pchFolder + 20);
												object obj9 = (object)(ptr7 - (nuint)ptr8);
												if ((nint)obj9 >= num7)
												{
													obj9 = (object)(ptr8 - (nuint)ptr7);
													if ((nint)obj9 >= num7)
													{
														Buffer.Memcpy(ptr7, ptr8, num7);
														goto IL_0a57;
													}
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
												goto IL_0a57;
											}
											IndexOutOfRangeException ex4 = new IndexOutOfRangeException();
											throw ex4;
										}
										goto IL_0ae6;
									}
									System.ThrowHelper.ThrowIndexOutOfRangeException();
								}
								object obj10 = new ArgumentException();
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184DE73A0");
								throw obj10;
							}
							object obj11 = new ArgumentException();
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184DE73A0");
							throw obj11;
						}
						goto IL_0ae6;
					}
					goto IL_0af3;
				}
				ArgumentNullException ex5 = new ArgumentNullException("path2");
				ex5._002Ector("path2");
				throw ex5;
			}
			text3 = null;
			message = "[Steamworks.NET] - Unable to get game install path";
		}
		Debug.Log(message);
		string text11 = null;
		goto IL_0ea5;
		IL_0dcd:
		string text12 = ((Enum)(&obj)).ToString();
		string message2 = "[Steamworks.NET] - DLC (" + text12 + ") mounted at path: " + text6;
		Debug.Log(message2);
		text3 = text6;
		text11 = text6;
		goto IL_0ea5;
		IL_0a57:
		object obj12 = text10._stringLength - stringLength2;
		if (text4._stringLength <= (nint)obj12)
		{
			text6 = text10;
			goto IL_08aa;
		}
		IndexOutOfRangeException ex6 = new IndexOutOfRangeException();
		throw ex6;
		IL_0ab9:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1078 @ rax_v132+B8]");
		object obj14 = 0;
		text6 = (string)obj14;
		goto IL_0dcd;
		IL_0a97:
		if (text4._stringLength <= 0)
		{
			goto IL_0ab9;
		}
		goto IL_0af3;
		IL_0e36:
		object obj16;
		object obj15 = obj16 * 2;
		byte* ptr9 = (byte*)(nint)(text6 + obj15);
		int stringLength3;
		int num8 = stringLength3 + stringLength3;
		byte* ptr10;
		object obj17 = (object)(ptr9 - (nuint)ptr10);
		if ((nint)obj17 >= num8)
		{
			obj17 = (object)(ptr10 - (nuint)ptr9);
			if ((nint)obj17 >= num8)
			{
				Buffer.Memcpy(ptr9, ptr10, num8);
				goto IL_0dcd;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
		goto IL_0dcd;
		IL_062a:
		object obj18 = text7._stringLength - pchFolder._stringLength;
		if (directorySeparatorStr._stringLength <= (nint)obj18)
		{
			stringLength3 = directorySeparatorStr._stringLength;
			obj16 = pchFolder._stringLength + 10;
			ptr10 = (byte*)(nint)(Path.DirectorySeparatorStr + 20);
			text6 = text7;
			goto IL_0e36;
		}
		IndexOutOfRangeException ex7 = new IndexOutOfRangeException();
		throw ex7;
		IL_0af3:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rsi_v17+10]");
		text6 = (string)0;
		goto IL_0dcd;
		IL_086f:
		object obj19 = text8._stringLength - stringLength2;
		bool flag = text4._stringLength > (nint)obj19;
		text6 = text8;
		if (!flag)
		{
			goto IL_08aa;
		}
		IndexOutOfRangeException ex8 = new IndexOutOfRangeException();
		throw ex8;
		IL_0ae6:
		text6 = pchFolder;
		goto IL_0dcd;
		IL_0ea5:
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [onComplete @ r8 (System.Action`1<System.String>)+18] (should have been resolved before IL gen)");
		return;
		IL_03a7:
		object obj20 = text5._stringLength - pchFolder._stringLength;
		if (directorySeparatorStr._stringLength <= (nint)obj20)
		{
			object obj21 = pchFolder._stringLength + 10;
			object obj22 = obj21 * 2;
			byte* ptr11 = (byte*)(nint)(text5 + obj22);
			int num9 = directorySeparatorStr._stringLength + directorySeparatorStr._stringLength;
			byte* ptr12 = (byte*)(nint)(Path.DirectorySeparatorStr + 20);
			object obj23 = (object)(ptr11 - (nuint)ptr12);
			if ((nint)obj23 >= num9)
			{
				obj23 = (object)(ptr12 - (nuint)ptr11);
				if ((nint)obj23 >= num9)
				{
					Buffer.Memcpy(ptr11, ptr12, num9);
					goto IL_04aa;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
			goto IL_04aa;
		}
		IndexOutOfRangeException ex9 = new IndexOutOfRangeException();
		throw ex9;
		IL_08aa:
		stringLength3 = text4._stringLength;
		obj16 = stringLength2 + 10;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rsi_v17+10]");
		ptr10 = (byte*)((nuint)0u + (nuint)20u);
		goto IL_0e36;
		IL_04aa:
		int destPos = pchFolder._stringLength + directorySeparatorStr._stringLength;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rsi_v17+10]");
		string.FillStringChecked(text5, destPos, (string)0);
		text6 = text5;
		goto IL_0dcd;
	}

	public override void UnmountDlc(DlcType dlcType, Action onComplete)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: onComplete.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
	}

	private bool IsSteamRunningAndOnSteamDeck()
	{
		if (m_IsInitialised)
		{
			return SteamUtils.IsRunningOnSteamDeck;
		}
		return false;
	}

	public override void DisplayOnscreenKeyboard()
	{
		//IL_0054: Expected O, but got I
		if (m_IsInitialised && SteamUtils.IsRunningOnSteamDeck)
		{
			Steamworks.ISteamUtils steamUtils = SteamUtils.Internal;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189983018]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189983018]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02E50");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v248 @ rax_v12 (should have been resolved before IL gen)");
		}
	}

	public override bool DoesSupportWindowModes()
	{
		if (m_IsInitialised)
		{
			bool isRunningOnSteamDeck = SteamUtils.IsRunningOnSteamDeck;
			return (byte)((isRunningOnSteamDeck ? 1u : 0u) ^ 1u) != 0;
		}
		return true;
	}

	public override bool DoesSupportVSync()
	{
		return true;
	}

	public override bool DoesPlayer1NeedController()
	{
		if (m_IsInitialised)
		{
			return SteamUtils.IsRunningOnSteamDeck;
		}
		return false;
	}

	public unsafe override string GetDefaultLanguage()
	{
		//IL_0045: Expected O, but got I
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected O, but got Unknown
		//IL_00c2: Expected O, but got I8
		//IL_00cb: Expected O, but got I4
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected O, but got Unknown
		//IL_0c2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c34: Expected Ref, but got Unknown
		//IL_0c4b: Expected I8, but got I4
		//IL_0c55: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c5a: Expected Ref, but got Unknown
		//IL_0d55: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d5a: Expected Ref, but got Unknown
		//IL_0d71: Expected I8, but got I4
		//IL_0d7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d80: Expected Ref, but got Unknown
		//IL_0a40: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a45: Expected Ref, but got Unknown
		//IL_0a5c: Expected I8, but got I4
		//IL_0a65: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a6a: Expected Ref, but got Unknown
		//IL_0641: Unknown result type (might be due to invalid IL or missing references)
		//IL_0646: Expected Ref, but got Unknown
		//IL_065d: Expected I8, but got I4
		//IL_0667: Unknown result type (might be due to invalid IL or missing references)
		//IL_066c: Expected Ref, but got Unknown
		//IL_0546: Unknown result type (might be due to invalid IL or missing references)
		//IL_054b: Expected Ref, but got Unknown
		//IL_0562: Expected I8, but got I4
		//IL_056b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0570: Expected Ref, but got Unknown
		//IL_0b37: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b3c: Expected Ref, but got Unknown
		//IL_0b53: Expected I8, but got I4
		//IL_0b5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b62: Expected Ref, but got Unknown
		//IL_0879: Unknown result type (might be due to invalid IL or missing references)
		//IL_087e: Expected Ref, but got Unknown
		//IL_0895: Expected I8, but got I4
		//IL_089f: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a4: Expected Ref, but got Unknown
		//IL_073d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0742: Expected Ref, but got Unknown
		//IL_0759: Expected I8, but got I4
		//IL_0763: Unknown result type (might be due to invalid IL or missing references)
		//IL_0768: Expected Ref, but got Unknown
		//IL_0975: Unknown result type (might be due to invalid IL or missing references)
		//IL_097a: Expected Ref, but got Unknown
		//IL_0991: Expected I8, but got I4
		//IL_099b: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a0: Expected Ref, but got Unknown
		//IL_0463: Unknown result type (might be due to invalid IL or missing references)
		//IL_0468: Expected Ref, but got Unknown
		//IL_047f: Expected I8, but got I4
		//IL_0489: Unknown result type (might be due to invalid IL or missing references)
		//IL_048e: Expected Ref, but got Unknown
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_023e: Expected Ref, but got Unknown
		//IL_0255: Expected I8, but got I4
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Expected Ref, but got Unknown
		//IL_0335: Unknown result type (might be due to invalid IL or missing references)
		//IL_033a: Expected Ref, but got Unknown
		//IL_0351: Expected I8, but got I4
		//IL_035b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0360: Expected Ref, but got Unknown
		string text;
		object obj8;
		object obj14;
		if (m_IsInitialised)
		{
			Steamworks.ISteamUtils steamUtils = SteamUtils.Internal;
			if (steamUtils != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189982FB0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189982FB0]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02E50");
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v451 @ rax_v10 (should have been resolved before IL gen)");
				Steamworks.Utf8StringPointer utf8StringPointer = default(Steamworks.Utf8StringPointer);
				text = utf8StringPointer;
				string message = "[Steamworks.NET] - Steam language is " + text;
				Debug.Log(message);
				if (text != null)
				{
					object obj2 = text + 20;
					object obj3 = 2166136261L;
					object obj4 = 0;
					while ((nint)obj4 < text._stringLength)
					{
						if ((nint)obj4 < text._stringLength)
						{
							obj4++;
							object obj5 = obj2 ^ obj3;
							obj3 = obj5 * 16777619;
							obj2 += 2;
							continue;
						}
						goto IL_0dc3;
					}
					if ((long)obj3 > 2499415067L)
					{
						if ((long)obj3 > 3210859552L)
						{
							if ((long)obj3 > 3405445907L)
							{
								if ((long)obj3 == 3719199419L)
								{
									object obj6 = "spanish";
									if ((object)text == "spanish")
									{
										goto IL_0292;
									}
									if ("spanish" != null)
									{
										int stringLength = text._stringLength;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v520 @ rdx_v45+10]");
										if ((nint)stringLength == 0)
										{
											ref byte first = ref *(byte*)(text + 20);
											ulong length = (ulong)(text._stringLength + text._stringLength);
											if (System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("spanish" + 20), length))
											{
												goto IL_0292;
											}
										}
									}
								}
								else if ((long)obj3 == 3739448251L)
								{
									object obj7 = "turkish";
									if ((object)text == "turkish")
									{
										goto IL_038e;
									}
									if ("turkish" != null)
									{
										int stringLength2 = text._stringLength;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v522 @ rdx_v42+10]");
										if ((nint)stringLength2 == 0)
										{
											ref byte first2 = ref *(byte*)(text + 20);
											ulong length2 = (ulong)(text._stringLength + text._stringLength);
											if (System.SpanHelpers.SequenceEqual(ref first2, ref *(byte*)("turkish" + 20), length2))
											{
												goto IL_038e;
											}
										}
									}
								}
							}
							else
							{
								if ((long)obj3 == 3264533134L)
								{
									obj8 = "tchinese";
									goto IL_0e52;
								}
								if ((long)obj3 == 3405445907L)
								{
									object obj9 = "german";
									if ((object)text == "german")
									{
										goto IL_04bc;
									}
									if ("german" != null)
									{
										int stringLength3 = text._stringLength;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v524 @ rdx_v38+10]");
										if ((nint)stringLength3 == 0)
										{
											ref byte first3 = ref *(byte*)(text + 20);
											ulong length3 = (ulong)(text._stringLength + text._stringLength);
											if (System.SpanHelpers.SequenceEqual(ref first3, ref *(byte*)("german" + 20), length3))
											{
												goto IL_04bc;
											}
										}
									}
								}
							}
						}
						else
						{
							if ((long)obj3 == 2805355685L)
							{
								obj8 = "schinese";
								goto IL_0e52;
							}
							if ((long)obj3 == 3180870988L)
							{
								object obj10 = "polish";
								if ((object)text == "polish")
								{
									goto IL_069a;
								}
								if ("polish" != null)
								{
									int stringLength4 = text._stringLength;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v528 @ rdx_v34+10]");
									if ((nint)stringLength4 == 0)
									{
										ref byte first4 = ref *(byte*)(text + 20);
										ulong length4 = (ulong)(text._stringLength + text._stringLength);
										if (System.SpanHelpers.SequenceEqual(ref first4, ref *(byte*)("polish" + 20), length4))
										{
											goto IL_069a;
										}
									}
								}
							}
							else if ((long)obj3 == 3210859552L)
							{
								object obj11 = "koreana";
								if ((object)text == "koreana")
								{
									goto IL_0796;
								}
								if ("koreana" != null)
								{
									int stringLength5 = text._stringLength;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v530 @ rdx_v31+10]");
									if ((nint)stringLength5 == 0)
									{
										ref byte first5 = ref *(byte*)(text + 20);
										ulong length5 = (ulong)(text._stringLength + text._stringLength);
										if (System.SpanHelpers.SequenceEqual(ref first5, ref *(byte*)("koreana" + 20), length5))
										{
											goto IL_0796;
										}
									}
								}
							}
						}
					}
					else if ((nint)obj3 > 599131013)
					{
						if ((nint)obj3 > 1901528810)
						{
							if ((long)obj3 == 2471602315L)
							{
								object obj12 = "italian";
								if ((object)text == "italian")
								{
									goto IL_08d2;
								}
								if ("italian" != null)
								{
									int stringLength6 = text._stringLength;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v532 @ rdx_v25+10]");
									if ((nint)stringLength6 == 0)
									{
										ref byte first6 = ref *(byte*)(text + 20);
										ulong length6 = (ulong)(text._stringLength + text._stringLength);
										if (System.SpanHelpers.SequenceEqual(ref first6, ref *(byte*)("italian" + 20), length6))
										{
											goto IL_08d2;
										}
									}
								}
							}
							else if ((long)obj3 == 2499415067L)
							{
								object obj13 = "english";
								if ((object)text != "english" && "english" != null)
								{
									int stringLength7 = text._stringLength;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v534 @ rdx_v23+10]");
									if ((nint)stringLength7 == 0)
									{
										ref byte first7 = ref *(byte*)(text + 20);
										ulong length7 = (ulong)(text._stringLength + text._stringLength);
										bool flag = System.SpanHelpers.SequenceEqual(ref first7, ref *(byte*)("english" + 20), length7);
									}
								}
							}
						}
						else
						{
							if ((nint)obj3 == 1580935484)
							{
								obj14 = "portuguese";
								goto IL_0e6e;
							}
							if ((nint)obj3 == 1901528810)
							{
								object obj15 = "japanese";
								if ((object)text == "japanese")
								{
									goto IL_0b90;
								}
								if ("japanese" != null)
								{
									int stringLength8 = text._stringLength;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v537 @ rdx_v19+10]");
									if ((nint)stringLength8 == 0)
									{
										ref byte first8 = ref *(byte*)(text + 20);
										ulong length8 = (ulong)(text._stringLength + text._stringLength);
										if (System.SpanHelpers.SequenceEqual(ref first8, ref *(byte*)("japanese" + 20), length8))
										{
											goto IL_0b90;
										}
									}
								}
							}
						}
					}
					else if ((nint)obj3 == 380651494)
					{
						object obj16 = "russian";
						if ((object)text == "russian")
						{
							goto IL_0c88;
						}
						if ("russian" != null)
						{
							int stringLength9 = text._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v539 @ rdx_v16+10]");
							if ((nint)stringLength9 == 0)
							{
								ref byte first9 = ref *(byte*)(text + 20);
								ulong length9 = (ulong)(text._stringLength + text._stringLength);
								if (System.SpanHelpers.SequenceEqual(ref first9, ref *(byte*)("russian" + 20), length9))
								{
									goto IL_0c88;
								}
							}
						}
					}
					else
					{
						if ((nint)obj3 == 505713757)
						{
							obj14 = "brazilian";
							goto IL_0e6e;
						}
						if ((nint)obj3 == 599131013)
						{
							object obj17 = "french";
							if ((object)text == "french")
							{
								goto IL_0dae;
							}
							if ("french" != null)
							{
								int stringLength10 = text._stringLength;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v541 @ rdx_v12+10]");
								if ((nint)stringLength10 == 0)
								{
									ref byte first10 = ref *(byte*)(text + 20);
									ulong length10 = (ulong)(text._stringLength + text._stringLength);
									if (System.SpanHelpers.SequenceEqual(ref first10, ref *(byte*)("french" + 20), length10))
									{
										goto IL_0dae;
									}
								}
							}
						}
					}
				}
				goto IL_09ba;
			}
			goto IL_0df2;
		}
		return base.GetDefaultLanguage();
		IL_038e:
		return "tr";
		IL_0dae:
		return "fr";
		IL_0e52:
		if (text == obj8)
		{
			goto IL_059e;
		}
		if (obj8 != null)
		{
			int stringLength11 = text._stringLength;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v526 @ rdx_v28+10]");
			if ((nint)stringLength11 == 0)
			{
				ref byte first11 = ref *(byte*)(text + 20);
				ulong length11 = (ulong)(text._stringLength + text._stringLength);
				if (System.SpanHelpers.SequenceEqual(ref first11, ref *(byte*)(obj8 + 20), length11))
				{
					goto IL_059e;
				}
			}
		}
		goto IL_09ba;
		IL_069a:
		return "pl";
		IL_0a98:
		return "pt-BR";
		IL_059e:
		return "zh-CN";
		IL_0c88:
		return "ru";
		IL_08d2:
		return "it";
		IL_0796:
		return "ko";
		IL_04bc:
		return "de";
		IL_0dc3:
		System.ThrowHelper.ThrowIndexOutOfRangeException();
		goto IL_0df2;
		IL_0b90:
		return "ja";
		IL_0e6e:
		if (text != obj14)
		{
			if (obj14 != null)
			{
				int stringLength12 = text._stringLength;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v535 @ rdx_v9+10]");
				if ((nint)stringLength12 == 0)
				{
					ref byte first12 = ref *(byte*)(text + 20);
					ulong length12 = (ulong)(text._stringLength + text._stringLength);
					if (System.SpanHelpers.SequenceEqual(ref first12, ref *(byte*)(obj14 + 20), length12))
					{
						goto IL_0a98;
					}
				}
			}
			goto IL_09ba;
		}
		goto IL_0a98;
		IL_0292:
		return "es";
		IL_0df2:
		return (string)(object)new NullReferenceException();
		IL_09ba:
		return "en";
	}
}
