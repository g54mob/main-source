using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using UnityEngine;

public class StandalonePlatform : PlatformInterface, IPlatformUserManager
{
	public string Name => "Standalone";

	public Platform Platform { get; }

	public string SavePrefix => null;

	public bool IsLoggedOn => true;

	public bool HasNetwork => true;

	public List<PlatformUserID> PlatformFriends => new List<PlatformUserID>
	{
		new PlatformUserID(1uL),
		new PlatformUserID(2uL),
		new PlatformUserID(3uL),
		new PlatformUserID(4uL),
		new PlatformUserID(5uL)
	};

	public event Action<string> JoinRequest;

	public event Action<bool> PlatformOverlayStateChanged;

	public event Action<ApplicationFocusChange> ApplicationFocusChanged;

	public event Action<NetworkConnectionStatus> NetworkConnectionStatusChanged;

	public event Action<UserSignInCompleteVO> UserSignInComplete;

	public async Task<bool> HasNetworkCheck()
	{
		return HasNetwork;
	}

	public bool Init()
	{
		return true;
	}

	public void RegisterSuspendHandler(Action suspendHandler)
	{
	}

	public bool IsPlatformOverlayActive()
	{
		return false;
	}

	public void SetPresence(Dictionary<string, string> presence)
	{
	}

	public void ClearPresence()
	{
	}

	public bool IsUserPremium(bool showPrompt, Action<bool> premiumStatusCallback)
	{
		return true;
	}

	public void CheckUserPrivileges(PlatformInterface.UserPrivileges privilegesToCheck, bool showUI, Action<PlatformInterface.PrivilegesResult> callback)
	{
		callback?.Invoke(new PlatformInterface.PrivilegesResult
		{
			CheckStatus = PlatformInterface.PrivilegeCheckStatus.Completed,
			isAllowedToPlayMultiplayer = true
		});
	}

	public void RefreshBlockedUsers(List<PlatformUserID> platformUserIds, Action<bool> callback)
	{
		callback?.Invoke(obj: true);
	}

	public void IsUserBlocked(List<PlatformUserID> platformUserIds, Action<bool> callback)
	{
		callback?.Invoke(obj: false);
	}

	public bool RefreshJoinableSessions(Action<PlatformInterface.SessionFetchStatus, List<PlatformSession>> callback)
	{
		List<PlatformSession> dummySessions = new List<PlatformSession>
		{
			new PlatformSession
			{
				Host = new PlatformUserID(1uL),
				FriendInSession = new PlatformUserID(1uL),
				CurrentPlayers = (uint)UnityEngine.Random.Range(1, 8),
				SessionId = Guid.NewGuid().ToString(),
				JoinString = Guid.NewGuid().ToString(),
				SessionParams = new PlatformSessionParams
				{
					MaxPlayers = 8u,
					WorldName = "TestWorld1",
					IconIndex = 0,
					WorldMode = WorldMode.Normal
				}
			},
			new PlatformSession
			{
				Host = new PlatformUserID(2uL),
				FriendInSession = new PlatformUserID(2uL),
				CurrentPlayers = (uint)UnityEngine.Random.Range(1, 8),
				SessionId = Guid.NewGuid().ToString(),
				JoinString = Guid.NewGuid().ToString(),
				SessionParams = new PlatformSessionParams
				{
					MaxPlayers = 8u,
					WorldName = "TestWorld2",
					IconIndex = 1,
					WorldMode = WorldMode.Casual
				}
			},
			new PlatformSession
			{
				Host = new PlatformUserID(3uL),
				FriendInSession = new PlatformUserID(3uL),
				CurrentPlayers = (uint)UnityEngine.Random.Range(1, 8),
				SessionId = Guid.NewGuid().ToString(),
				JoinString = Guid.NewGuid().ToString(),
				SessionParams = new PlatformSessionParams
				{
					MaxPlayers = 8u,
					WorldName = "TestWorld3",
					IconIndex = 2,
					WorldMode = WorldMode.Creative
				}
			}
		};
		Manager.RunAfterInitComplete(RefreshJoinableSessionsCallback(dummySessions, callback));
		return true;
	}

	private IEnumerator RefreshJoinableSessionsCallback(List<PlatformSession> dummySessions, Action<PlatformInterface.SessionFetchStatus, List<PlatformSession>> callback)
	{
		yield return new WaitForSeconds(1f);
		callback?.Invoke(PlatformInterface.SessionFetchStatus.Success, dummySessions);
	}

	public void Deinit()
	{
	}

	public string[] GetCommandLine()
	{
		return Environment.GetCommandLineArgs();
	}

	public string GetAccountId()
	{
		return null;
	}

	public void GetLocalUserName(Action<string> callback)
	{
		GetUserProfile(GetPlatformUserID(), UserImageSize.None, delegate(UserPlatformProfile profile)
		{
			callback?.Invoke(profile.UserName);
		});
	}

	public void GetUserProfile(PlatformUserID userId, UserImageSize size, Action<UserPlatformProfile> callback)
	{
		ulong platformOnlineId = userId.GetPlatformOnlineId();
		ulong num = platformOnlineId - 1;
		if (num > 4)
		{
			goto IL_00a5;
		}
		switch ((uint)num)
		{
		case 0u:
			break;
		case 1u:
			goto IL_0049;
		case 2u:
			goto IL_0060;
		case 3u:
			goto IL_0077;
		case 4u:
			goto IL_008e;
		default:
			goto IL_00a5;
		}
		UserPlatformProfile obj = new UserPlatformProfile("kumpi", "kumpi", "kumpi");
		goto IL_00ba;
		IL_00a5:
		obj = new UserPlatformProfile("empty", "empty", "empty");
		goto IL_00ba;
		IL_00ba:
		callback?.Invoke(obj);
		return;
		IL_0049:
		obj = new UserPlatformProfile("kampi", "kampi", "kampi");
		goto IL_00ba;
		IL_0060:
		obj = new UserPlatformProfile("hauki", "hauki", "hauki");
		goto IL_00ba;
		IL_0077:
		obj = new UserPlatformProfile("on", "on", "on");
		goto IL_00ba;
		IL_008e:
		obj = new UserPlatformProfile("kala", "kala", "kala");
		goto IL_00ba;
	}

	public void OpenUserProfile(PlatformUserID userId)
	{
		UnityEngine.Debug.LogError("Try Open User Profile but it's not implemented");
	}

	public void GetUserDisplayImage(PlatformUserID userId, UserImageSize size, Action<UserPlatformProfile> callback)
	{
	}

	public void SignInDefaultUser()
	{
	}

	public PlatformUserID GetPlatformUserID()
	{
		return new PlatformUserID(0uL);
	}

	public bool IsUserIdValid(PlatformUserID id)
	{
		return false;
	}

	public void RefreshPlatformFriends(bool getProfiles = false)
	{
	}

	public void SendInvitation(string sessionId, List<PlatformUserID> invitees, Action<bool> callback)
	{
		callback?.Invoke(obj: false);
	}

	public string GetSystemLanguage()
	{
		return "en";
	}

	public void Update()
	{
	}

	public void SetJoinString(string _)
	{
	}

	public bool HasDlc(Dlc value)
	{
		return false;
	}

	public bool HasApp(App value)
	{
		return false;
	}

	public void OpenLink(string url)
	{
		Application.OpenURL(url);
	}

	public bool CanSetFullscreen()
	{
		return true;
	}

	public void CloudSyncDown()
	{
	}

	public void CloudSyncUp()
	{
	}

	public bool GetControllerTextInput(string description, int maxChars, string currentText, PlatformInterface.GotControllerTextInput callback, bool hidden = false)
	{
		return false;
	}

	public void InitializeAchievements()
	{
	}

	public bool TriggerAchievement(AchievementData achievementData)
	{
		UnityEngine.Debug.Log("Dummy triggered achievement " + achievementData.AchievementID);
		return true;
	}

	public void ClearAllAchievements()
	{
	}

	public void Restart(Dictionary<string, string> args)
	{
		string exePath = Application.dataPath.Replace("_Data", ".exe");
		Manager.afterQuitHandlers += delegate
		{
			Process.Start(exePath);
		};
		Application.Quit();
	}
}
