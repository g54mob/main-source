using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coherence.Cloud;
using Rewired;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Platforms.Saves;

namespace VampireSurvivors.Framework.Platforms
{
	public abstract class IBaseAccount : ILastErrorProvider
	{
		protected ErroInfo m_LastError;

		protected LoginState m_LoginState;

		public readonly int m_RewiredPlayerId;

		protected Rewired.Player m_Player;

		protected string m_Name;

		private string m_SystemLanguage;

		public string UserName => null;

		public LoginState State => default(LoginState);

		public Rewired.Player InputPlayer => null;

		public ErroInfo LastError => default(ErroInfo);

		public abstract string UniqueAccountID { get; }

		public abstract string LocalID { get; }

		public abstract string OnlineID { get; }

		public abstract IPlatformSaveUtils Storage { get; }

		public abstract IPlatformAchievementsManager AchievementsManager { get; }

		public bool IsLoggedIn => false;

		public bool IsOnlineLoggedIn => false;

		public event Action UserPresenceChangedListener
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static void NAME()
		{
		}

		public IBaseAccount(int rewiredPlayerId)
		{
		}

		public virtual void Close()
		{
		}

		protected void SetState(LoginState newState)
		{
		}

		public abstract void LoginAsync(LoginOptions options, Action<LoginResult> onComplete);

		public virtual void LoginWithCoherence(Action<LoginOperation> coherenceLoginOperation)
		{
		}

		protected void TriggerUserPresenceChanged()
		{
		}

		public abstract void GetAvailableDlc(Action<List<DlcType>> onComplete);

		public abstract void GetLicensedDlc(Action<List<DlcType>> onComplete);

		public abstract void UpdateInstalledDlc(Action onComplete);

		public abstract void MountDlc(DlcType dlcType, Action<string> onComplete);

		public abstract void UnmountDlc(DlcType dlcType, Action onComplete);

		public virtual AssetBundle GetAssetBundle(string path, string bundleName)
		{
			return null;
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
			return false;
		}

		public virtual void GetAuthToken(Action<PlatformAuthToken> onSuccess, Action<string> onError, Action<TokenAbortReason> onAbort, string url = "https://playfabapi.com/")
		{
		}

		public virtual string GetDefaultLanguage()
		{
			return null;
		}
	}
}
