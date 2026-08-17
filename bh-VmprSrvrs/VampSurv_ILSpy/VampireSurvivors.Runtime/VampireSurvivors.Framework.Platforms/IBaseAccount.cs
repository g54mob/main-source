using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using Coherence.Cloud;
using Cpp2ILInjected;
using Rewired;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.DLC;
using VampireSurvivors.Framework.Platforms.Saves;

namespace VampireSurvivors.Framework.Platforms;

public abstract class IBaseAccount : ILastErrorProvider
{
	private Action m_UserPresenceChangedListener;

	protected ErroInfo m_LastError;

	protected LoginState m_LoginState;

	public readonly int m_RewiredPlayerId;

	protected Rewired.Player m_Player;

	protected string m_Name;

	private string m_SystemLanguage;

	public string UserName => m_Name;

	public LoginState State => m_LoginState;

	public Rewired.Player InputPlayer => m_Player;

	public unsafe ErroInfo LastError
	{
		get
		{
			//IL_000f: Expected I4, but got O
			//IL_000a: Expected native int or pointer, but got O
			//IL_0024: Expected O, but got I
			//IL_001f: Expected native int or pointer, but got O
			ErroInfo erroInfo = default(ErroInfo);
			((ErroInfo*)(nint)erroInfo)->NativeErrorCode = (int)m_LastError;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (VampireSurvivors.Framework.Platforms.IBaseAccount)+28]");
			System.Runtime.CompilerServices.Unsafe.Write(&((ErroInfo*)(nint)erroInfo)->Message, (string)0);
			return erroInfo;
		}
	}

	public abstract string UniqueAccountID { get; }

	public abstract string LocalID { get; }

	public abstract string OnlineID { get; }

	public abstract IPlatformSaveUtils Storage { get; }

	public abstract IPlatformAchievementsManager AchievementsManager { get; }

	public bool IsLoggedIn
	{
		get
		{
			//IL_0010: Expected O, but got I4
			//IL_0020: Expected O, but got I4
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Expected O, but got Unknown
			object obj = m_LoginState - 1;
			object obj2 = m_LoginState ^ LoginState.LoggingIn;
			object obj3 = m_LoginState ^ obj;
			object obj4 = obj2 & obj3;
			bool flag = (nint)obj4 < 0;
			bool flag2 = (nint)obj < 0;
			bool flag3 = obj == null;
			bool flag4 = flag2 == flag;
			bool flag5 = !flag3;
			return flag5 & flag4;
		}
	}

	public bool IsOnlineLoggedIn
	{
		get
		{
			//IL_0010: Expected O, but got I4
			object obj = m_LoginState - 4;
			return obj == null;
		}
	}

	public event Action UserPresenceChangedListener
	{
		add
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 16;
			Delegate obj2 = this.m_UserPresenceChangedListener;
			while (true)
			{
				Delegate obj3 = Delegate.Combine(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(Action);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		remove
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			object obj = this + 16;
			Delegate obj2 = this.m_UserPresenceChangedListener;
			while (true)
			{
				Delegate obj3 = Delegate.Remove(obj2, value);
				bool flag = (object)obj3 == null;
				Delegate obj4 = null;
				if (!flag)
				{
					bool flag2 = (object)obj3.GetType() != typeof(Action);
					obj4 = null;
					if (!flag2)
					{
						obj4 = obj3;
					}
					if ((object)obj4 == null)
					{
						break;
					}
				}
				bool flag3 = obj2 == obj;
				Delegate obj5;
				if (obj2 == obj)
				{
					obj = obj4;
					obj5 = obj2;
				}
				else
				{
					obj5 = (Delegate)obj;
				}
				Delegate obj6 = obj2;
				if (!flag3)
				{
					obj6 = obj5;
				}
				bool flag4 = (object)obj6 != obj2;
				obj2 = obj6;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	public static void NAME()
	{
	}

	public IBaseAccount(int rewiredPlayerId)
	{
		m_RewiredPlayerId = rewiredPlayerId;
		ReInput.PlayerHelper players = ReInput.players;
		Rewired.Player player = players.GetPlayer(m_RewiredPlayerId);
		m_Player = player;
	}

	public virtual void Close()
	{
		IPlatformSaveUtils storage = Storage;
		if (storage != null)
		{
			IPlatformSaveUtils storage2 = Storage;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj = default(object);
			if (obj != null)
			{
				IPlatformSaveUtils storage3 = Storage;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
			}
		}
		IPlatformAchievementsManager achievementsManager = AchievementsManager;
		if (achievementsManager != null)
		{
			IPlatformAchievementsManager achievementsManager2 = AchievementsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
		}
		m_LoginState = LoginState.LoggedOut;
	}

	protected void SetState(LoginState newState)
	{
		if (newState != m_LoginState)
		{
			m_LoginState = newState;
			if (newState == LoginState.LoggedOut)
			{
				Close();
			}
		}
	}

	public abstract void LoginAsync(LoginOptions options, Action<LoginResult> onComplete);

	public unsafe virtual void LoginWithCoherence(Action<LoginOperation> coherenceLoginOperation)
	{
		//IL_0060: Expected O, but got I4
		//IL_0060: Expected O, but got Ref
		Guid guid = default(Guid);
		global::Interop.GetRandomBytes((byte*)(&guid), 16);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998A4E4]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Guid guid2 = default(Guid);
		string text = guid2.ToString("D", null);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18997FCFE]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (text != null)
		{
		}
		LoginOperation loginOperation = CoherenceCloud.LoginAsGuest((LoginAsGuestOptions)(&guid), (CancellationToken)0);
		LoginOperation loginOperation2 = loginOperation.ContinueWith(coherenceLoginOperation);
	}

	protected void TriggerUserPresenceChanged()
	{
		if (this.m_UserPresenceChangedListener != null)
		{
			Action userPresenceChangedListener = this.m_UserPresenceChangedListener;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public abstract void GetAvailableDlc(Action<List<DlcType>> onComplete);

	public abstract void GetLicensedDlc(Action<List<DlcType>> onComplete);

	public abstract void UpdateInstalledDlc(Action onComplete);

	public abstract void MountDlc(DlcType dlcType, Action<string> onComplete);

	public abstract void UnmountDlc(DlcType dlcType, Action onComplete);

	public virtual AssetBundle GetAssetBundle(string path, string bundleName)
	{
		string bundlePath = Path.Combine(path, bundleName);
		return ManifestLoader.LoadAssetBundleFromPath(bundlePath);
	}

	public virtual void DisplayOnscreenKeyboard()
	{
	}

	public virtual bool DoesSupportWindowModes()
	{
		return false;
	}

	public virtual bool DoesSupportVSync()
	{
		return false;
	}

	public virtual bool DoesPlayer1NeedController()
	{
		return true;
	}

	public virtual void GetAuthToken(Action<PlatformAuthToken> onSuccess, Action<string> onError, Action<TokenAbortReason> onAbort, string url = "https://playfabapi.com/")
	{
		NotImplementedException ex = new NotImplementedException();
		throw ex;
	}

	public unsafe virtual string GetDefaultLanguage()
	{
		//IL_0208: Expected O, but got I4
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_0240: Expected O, but got I4
		//IL_0249: Expected I4, but got O
		//IL_026f: Expected O, but got Ref
		//IL_00c3: Expected O, but got I8
		//IL_00dd: Expected O, but got I8
		string systemLanguage;
		if (m_SystemLanguage == null)
		{
			object obj = Application.systemLanguage;
			if ((nint)obj > 15)
			{
				if ((nint)obj > 34)
				{
					if ((nint)obj == 37)
					{
						systemLanguage = "tr";
					}
					else
					{
						if ((nint)obj != 41)
						{
							goto IL_01b7;
						}
						systemLanguage = "zh-TW";
					}
				}
				else
				{
					object obj2 = obj + -21;
					if ((nint)obj2 <= 9)
					{
						object obj3 = 6442450944L;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ r8_v4+6B3E718+v275 @ rax_v30*4]");
						object obj4 = 0 + 6442450944L;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v153 @ rcx_v18 (should have been resolved before IL gen)");
					}
					if ((nint)obj != 34)
					{
						goto IL_01b7;
					}
					systemLanguage = "es";
				}
			}
			else if ((nint)obj > 10)
			{
				if ((nint)obj == 14)
				{
					systemLanguage = "fr";
				}
				else
				{
					if ((nint)obj != 15)
					{
						goto IL_01b7;
					}
					systemLanguage = "de";
				}
			}
			else
			{
				bool flag = (nint)obj == 6;
				systemLanguage = "zh-CN";
				if (!flag)
				{
					goto IL_01b7;
				}
			}
			goto IL_0228;
		}
		goto IL_0278;
		IL_01b7:
		systemLanguage = "en";
		goto IL_0228;
		IL_0278:
		return m_SystemLanguage;
		IL_0228:
		m_SystemLanguage = systemLanguage;
		object obj5 = Application.systemLanguage;
		object obj6 = default(object);
		object arg = (SystemLanguage)obj6;
		System.ParamsArray paramsArray = new System.ParamsArray(arg, m_SystemLanguage);
		object obj7 = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "[GetDefaultLanguage] Application.systemLanguage: {0} - {1}", (System.ParamsArray)(&obj7));
		Debug.Log(message);
		goto IL_0278;
	}
}
