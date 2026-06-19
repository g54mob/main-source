using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface PlatformInterface
{
	public delegate void GotControllerTextInput(bool success, string input);

	public struct PrivilegesResult
	{
		public PrivilegeCheckStatus CheckStatus;

		public bool isAllowedToPlayMultiplayer;
	}

	[Flags]
	public enum UserPrivileges
	{
		None = 0,
		Multiplayer = 1,
		UGC = 2,
		Communication = 4,
		PremiumSubscription = 8,
		CrossPlay = 0x10
	}

	public enum SessionFetchStatus
	{
		Success = 0,
		Failed = 1,
		Incomplete = 2,
		APILimitExceeded = 3
	}

	public enum PrivilegeCheckStatus
	{
		Completed = 0,
		Failed = 1
	}

	string Name { get; }

	Platform Platform { get; }

	string SavePrefix { get; }

	bool IsLoggedOn { get; }

	bool HasNetwork { get; }

	event Action<string> JoinRequest;

	event Action<bool> PlatformOverlayStateChanged;

	event Action<ApplicationFocusChange> ApplicationFocusChanged;

	event Action<NetworkConnectionStatus> NetworkConnectionStatusChanged;

	Task<bool> HasNetworkCheck();

	bool Init();

	bool BeforeSceneLoad()
	{
		return true;
	}

	void Deinit();

	string[] GetCommandLine();

	string GetAccountId();

	PlatformUserID GetPlatformUserID();

	string GetSystemLanguage();

	void Update();

	void SetJoinString(string value);

	bool HasDlc(Dlc value);

	bool HasApp(App value);

	void OpenLink(string url);

	bool CanSetFullscreen();

	void CloudSyncDown();

	void CloudSyncUp();

	bool GetControllerTextInput(string description, int maxChars, string currentText, GotControllerTextInput callback, bool hidden = false);

	void InitializeAchievements();

	bool TriggerAchievement(AchievementData achievementData);

	void ClearAllAchievements();

	void Restart(Dictionary<string, string> args);

	void RegisterSuspendHandler(Action suspendHandler);

	bool IsPlatformOverlayActive();

	void SetPresence(Dictionary<string, string> presence);

	void ClearPresence();

	void CheckUserPrivileges(UserPrivileges privilegesToCheck, bool showUI, Action<PrivilegesResult> callback);

	void RefreshBlockedUsers(Action<bool> callback)
	{
		RefreshBlockedUsers(Manager.platform.platformImpl.GetPlatformUserID(), callback);
	}

	void RefreshBlockedUsers(PlatformUserID platformUserID, Action<bool> callback)
	{
		RefreshBlockedUsers(new List<PlatformUserID> { platformUserID }, callback);
	}

	void RefreshBlockedUsers(List<PlatformUserID> platformUserIds, Action<bool> callback);

	void IsUserBlocked(PlatformUserID accountId, Action<bool> callback)
	{
		IsUserBlocked(new List<PlatformUserID> { accountId }, callback);
	}

	void IsUserBlocked(List<PlatformUserID> accountIds, Action<bool> callback);

	bool RefreshJoinableSessions(Action<SessionFetchStatus, List<PlatformSession>> callback);
}
