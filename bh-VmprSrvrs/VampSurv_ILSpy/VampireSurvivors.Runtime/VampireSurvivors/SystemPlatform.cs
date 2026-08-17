using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Achievements;
using VampireSurvivors.App.Scripts.Framework.Platforms;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Platforms;
using VampireSurvivors.Framework.Platforms.SteamworksIntegration;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors;

public class SystemPlatform : IInitializable, IDisposable, ITickable
{
	private sealed class _003C_003Ec__DisplayClass23_0
	{
		public Action<string> onError;

		public SystemPlatform _003C_003E4__this;

		public Action<PlatformAuthToken> onSuccess;

		public Action<TokenAbortReason> onAbort;

		internal unsafe void _003CGetAuthToken_003Eb__0(LoginResult result)
		{
			//IL_0038: Expected I4, but got O
			//IL_005d: Expected O, but got Ref
			if (result == LoginResult.Canceled || result == LoginResult.Failed)
			{
				Action<string> action = onError;
				object obj = default(object);
				object arg = (LoginResult)obj;
				System.ParamsArray paramsArray = new System.ParamsArray(arg);
				object obj2 = default(object);
				string text = string.FormatHelper((IFormatProvider)null, "Failed to log in to platform, LoginResult={0}", (System.ParamsArray)(&obj2));
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v75 @ rsi_v4 (System.Action`1<System.String>)+18] (should have been resolved before IL gen)");
			}
			Debug.Log("Successfully logged into platform, fetching token...");
			SystemPlatform systemPlatform = _003C_003E4__this;
			systemPlatform.m_CurrentSystem.GetAuthToken(onSuccess, onError, onAbort, null);
		}
	}

	private IBaseAccount m_CurrentSystem;

	private static SystemPlatform sInstance;

	private static Action m_OnUpdate;

	private static Action m_OnQuit;

	public static SystemPlatformTypes Platform;

	private PlayerOptions _playerOptions;

	private DataManager _dataManager;

	public static IBaseAccount Account
	{
		get
		{
			SystemPlatform systemPlatform = sInstance;
			if (sInstance != null)
			{
				return systemPlatform.m_CurrentSystem;
			}
			return (IBaseAccount)(object)new NullReferenceException();
		}
	}

	public static SystemPlatform Instance => sInstance;

	public PlayerOptions PlayerOptions => _playerOptions;

	public DataManager DataManager => _dataManager;

	public static AchievementPlatform CurrentPlatform => AchievementPlatform.Steam;

	public static event Action OnUpdate
	{
		add
		{
			//IL_004f: Expected I, but got O
			//IL_0065: Expected O, but got I
			Delegate obj = SystemPlatform.m_OnUpdate;
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				bool flag = (object)obj2 == null;
				Delegate obj3 = null;
				if (!flag)
				{
					bool flag2 = (object)obj2.GetType() != typeof(Action);
					obj3 = null;
					if (!flag2)
					{
						obj3 = obj2;
					}
					if ((object)obj3 == null)
					{
						break;
					}
				}
				nint num = (nint)typeof(SystemPlatform);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v5 (Il2CppClass<VampireSurvivors.SystemPlatform>)+B8]");
				object obj4 = (nint)0 + (nint)8;
				bool flag3 = obj == obj4;
				Delegate obj5;
				if (obj == obj4)
				{
					obj4 = obj3;
					obj5 = obj;
				}
				else
				{
					obj5 = (Delegate)obj4;
				}
				Delegate obj6 = obj;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj;
				obj = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		remove
		{
			//IL_004f: Expected I, but got O
			//IL_0065: Expected O, but got I
			Delegate obj = SystemPlatform.m_OnUpdate;
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				bool flag = (object)obj2 == null;
				Delegate obj3 = null;
				if (!flag)
				{
					bool flag2 = (object)obj2.GetType() != typeof(Action);
					obj3 = null;
					if (!flag2)
					{
						obj3 = obj2;
					}
					if ((object)obj3 == null)
					{
						break;
					}
				}
				nint num = (nint)typeof(SystemPlatform);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v5 (Il2CppClass<VampireSurvivors.SystemPlatform>)+B8]");
				object obj4 = (nint)0 + (nint)8;
				bool flag3 = obj == obj4;
				Delegate obj5;
				if (obj == obj4)
				{
					obj4 = obj3;
					obj5 = obj;
				}
				else
				{
					obj5 = (Delegate)obj4;
				}
				Delegate obj6 = obj;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj;
				obj = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	public static event Action OnQuit
	{
		add
		{
			//IL_004f: Expected I, but got O
			//IL_0065: Expected O, but got I
			Delegate obj = SystemPlatform.m_OnQuit;
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				bool flag = (object)obj2 == null;
				Delegate obj3 = null;
				if (!flag)
				{
					bool flag2 = (object)obj2.GetType() != typeof(Action);
					obj3 = null;
					if (!flag2)
					{
						obj3 = obj2;
					}
					if ((object)obj3 == null)
					{
						break;
					}
				}
				nint num = (nint)typeof(SystemPlatform);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v5 (Il2CppClass<VampireSurvivors.SystemPlatform>)+B8]");
				object obj4 = (nint)0 + (nint)16;
				bool flag3 = obj == obj4;
				Delegate obj5;
				if (obj == obj4)
				{
					obj4 = obj3;
					obj5 = obj;
				}
				else
				{
					obj5 = (Delegate)obj4;
				}
				Delegate obj6 = obj;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj;
				obj = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		remove
		{
			//IL_004f: Expected I, but got O
			//IL_0065: Expected O, but got I
			Delegate obj = SystemPlatform.m_OnQuit;
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				bool flag = (object)obj2 == null;
				Delegate obj3 = null;
				if (!flag)
				{
					bool flag2 = (object)obj2.GetType() != typeof(Action);
					obj3 = null;
					if (!flag2)
					{
						obj3 = obj2;
					}
					if ((object)obj3 == null)
					{
						break;
					}
				}
				nint num = (nint)typeof(SystemPlatform);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v5 (Il2CppClass<VampireSurvivors.SystemPlatform>)+B8]");
				object obj4 = (nint)0 + (nint)16;
				bool flag3 = obj == obj4;
				Delegate obj5;
				if (obj == obj4)
				{
					obj4 = obj3;
					obj5 = obj;
				}
				else
				{
					obj5 = (Delegate)obj4;
				}
				Delegate obj6 = obj;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj;
				obj = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	private void Update()
	{
		if (SystemPlatform.m_OnUpdate != null)
		{
			Action onUpdate = SystemPlatform.m_OnUpdate;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v39.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public void Initialize()
	{
		sInstance = this;
		SteamworksAccount currentSystem = new SteamworksAccount();
		m_CurrentSystem = currentSystem;
		Platform = SystemPlatformTypes.STEAM;
	}

	public void Dispose()
	{
		if (sInstance == this)
		{
			if (SystemPlatform.m_OnQuit != null)
			{
				Action onQuit = SystemPlatform.m_OnQuit;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v93.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				SystemPlatform.m_OnQuit = null;
			}
			sInstance = null;
		}
	}

	public void Tick()
	{
		if (SystemPlatform.m_OnUpdate != null)
		{
			Action onUpdate = SystemPlatform.m_OnUpdate;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v39.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public unsafe void GetAuthToken(Action<PlatformAuthToken> onSuccess, Action<string> onError, Action<TokenAbortReason> onAbort)
	{
		_003C_003Ec__DisplayClass23_0 CS_0024_003C_003E8__locals13 = new _003C_003Ec__DisplayClass23_0();
		CS_0024_003C_003E8__locals13.onError = onError;
		CS_0024_003C_003E8__locals13._003C_003E4__this = this;
		CS_0024_003C_003E8__locals13.onSuccess = onSuccess;
		CS_0024_003C_003E8__locals13.onAbort = onAbort;
		if (sInstance != null)
		{
			IBaseAccount currentSystem = m_CurrentSystem;
			if (currentSystem.m_LoginState > LoginState.LoggingIn)
			{
				Debug.Log("Already logged in, fetching token...");
				m_CurrentSystem.GetAuthToken(CS_0024_003C_003E8__locals13.onSuccess, CS_0024_003C_003E8__locals13.onError, CS_0024_003C_003E8__locals13.onAbort, null);
				return;
			}
			Debug.Log("Not logged into platform, logging in...");
			Action<LoginResult> onComplete = delegate(LoginResult result)
			{
				//IL_0038: Expected I4, but got O
				//IL_005d: Expected O, but got Ref
				if (result == LoginResult.Canceled || result == LoginResult.Failed)
				{
					Action<string> onError3 = CS_0024_003C_003E8__locals13.onError;
					object obj = default(object);
					object arg = (LoginResult)obj;
					System.ParamsArray paramsArray = new System.ParamsArray(arg);
					object obj2 = default(object);
					string text = string.FormatHelper((IFormatProvider)null, "Failed to log in to platform, LoginResult={0}", (System.ParamsArray)(&obj2));
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v75 @ rsi_v4 (System.Action`1<System.String>)+18] (should have been resolved before IL gen)");
				}
				Debug.Log("Successfully logged into platform, fetching token...");
				SystemPlatform systemPlatform = CS_0024_003C_003E8__locals13._003C_003E4__this;
				systemPlatform.m_CurrentSystem.GetAuthToken(CS_0024_003C_003E8__locals13.onSuccess, CS_0024_003C_003E8__locals13.onError, CS_0024_003C_003E8__locals13.onAbort, null);
			};
			m_CurrentSystem.LoginAsync(LoginOptions.PlatformDefault, onComplete);
		}
		else
		{
			Action<string> onError2 = CS_0024_003C_003E8__locals13.onError;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v87 @ rax_v12 (System.Action`1<System.String>)+18] (should have been resolved before IL gen)");
		}
	}
}
