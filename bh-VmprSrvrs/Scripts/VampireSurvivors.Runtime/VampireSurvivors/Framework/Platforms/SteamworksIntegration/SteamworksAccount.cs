using System;
using System.Collections.Generic;
using Coherence.Cloud;
using Steamworks;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Platforms.Saves;

namespace VampireSurvivors.Framework.Platforms.SteamworksIntegration
{
	public class SteamworksAccount : IBaseAccount
	{
		private IPlatformSaveUtils m_Storage;

		private IPlatformAchievementsManager m_AchievementsManager;

		private AuthTicket _sessionTicket;

		private PlatformAuthToken _authToken;

		private string _steamID;

		private bool m_IsInitialised;

		public override string LocalID => null;

		public override string OnlineID => null;

		public override string UniqueAccountID => null;

		public override IPlatformSaveUtils Storage => null;

		public override IPlatformAchievementsManager AchievementsManager => null;

		public static uint GetAppID()
		{
			return 0u;
		}

		public bool IsSteamInitialised()
		{
			return false;
		}

		public SteamworksAccount(int rewiredPlayerId = 0)
			: base(0)
		{
		}

		private void OnDestroy()
		{
		}

		private void OnUpdate()
		{
		}

		public void CleanAuthToken()
		{
		}

		public override void GetAuthToken(Action<PlatformAuthToken> onSuccess, Action<string> onError, Action<TokenAbortReason> onAbort, string url = "https://playfabapi.com/")
		{
		}

		public override void LoginAsync(LoginOptions options, Action<LoginResult> onComplete)
		{
		}

		public override void LoginWithCoherence(Action<LoginOperation> onComplete)
		{
		}

		private void OnAuthTokenSuccess(PlatformAuthToken token, Action<LoginOperation> onComplete)
		{
		}

		private void InitBasicSteamCallbacks()
		{
		}

		private void OnSteamOverlayActivated(bool wasOverlayActivated)
		{
		}

		public override void GetAvailableDlc(Action<List<DlcType>> onComplete)
		{
		}

		public override void GetLicensedDlc(Action<List<DlcType>> onComplete)
		{
		}

		public override void UpdateInstalledDlc(Action onComplete)
		{
		}

		public override void MountDlc(DlcType dlcType, Action<string> onComplete)
		{
		}

		public override void UnmountDlc(DlcType dlcType, Action onComplete)
		{
		}

		private bool IsSteamRunningAndOnSteamDeck()
		{
			return false;
		}

		public override void DisplayOnscreenKeyboard()
		{
		}

		public override bool DoesSupportWindowModes()
		{
			return false;
		}

		public override bool DoesSupportVSync()
		{
			return false;
		}

		public override bool DoesPlayer1NeedController()
		{
			return false;
		}

		public override string GetDefaultLanguage()
		{
			return null;
		}
	}
}
