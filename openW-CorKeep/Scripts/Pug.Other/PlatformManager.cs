using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PimDeWitte.UnityMainThreadDispatcher;
using PugPlatform;
using Unity.Profiling;
using UnityEngine;

public class PlatformManager : ManagerBase
{
	public delegate void JoinRequestCallback(string value);

	private const int FRIEND_REFRESH_INTERVAL_S = 10;

	private const int SESSION_REFRESH_INTERVAL_S = 12;

	private const string PC = "PC";

	private const string PLAYSTATION = "Playstation";

	private const string XBOX = "Xbox";

	private const string SWITCH = "Switch";

	public const string PLATFORM = "PC";

	public bool forcePresenceJoinStringUpdate;

	private JoinRequestCallback joinRequestCallback;

	public PlatformInterface platformImpl;

	private DiscordPlatform discordPlatform;

	public IPlatformUserManager platformUserImpl;

	private float _lastFriendRefreshTimeStamp;

	private float _lastSessionRefreshTimeStamp;

	private static readonly ProfilerMarker InitMarker = new ProfilerMarker("PlatformManager.Init");

	public string platformIdentifier => Environment.MachineName;

	public string platformName => platformImpl.Name;

	public Platform Platform => platformImpl.Platform;

	public bool hasNetwork
	{
		get
		{
			if (!platformImpl.HasNetwork)
			{
				return Manager.networking.SupportsDirectConnection;
			}
			return true;
		}
	}

	public string accountId => platformImpl.GetAccountId();

	public string language => platformImpl.GetSystemLanguage();

	public string joinString
	{
		set
		{
			platformImpl?.SetJoinString(value);
		}
	}

	public bool CanSetFullscreen => platformImpl.CanSetFullscreen();

	public bool IsLoggedOn => platformImpl.IsLoggedOn;

	public ParentalControlManager parentalControlManager { get; private set; }

	public List<PlatformUserID> PlatformFriends => platformUserImpl?.PlatformFriends;

	public string OnlineName { get; private set; }

	public event Action<bool> PlatformOverlayStateChanged;

	public event Action<ApplicationFocusChange> ApplicationFocusChanged;

	public async Task<bool> HasNetworkCheck()
	{
		return await platformImpl.HasNetworkCheck();
	}

	public void OpenLink(string url)
	{
		platformImpl.OpenLink(url);
	}

	public bool HasApp(App app)
	{
		return platformImpl.HasApp(app);
	}

	public bool HasDlc(Dlc dlc)
	{
		return platformImpl.HasDlc(dlc);
	}

	public void CloudSyncDown()
	{
		platformImpl.CloudSyncDown();
	}

	public void CloudSyncUp()
	{
		platformImpl.CloudSyncUp();
	}

	public void Restart()
	{
		Restart(new Dictionary<string, string>());
	}

	public void Restart(Dictionary<string, string> args)
	{
		platformImpl.Restart(args);
	}

	public override bool Init()
	{
		using (InitMarker.Auto())
		{
			if (platformImpl == null)
			{
				return false;
			}
			platformUserImpl = platformImpl as IPlatformUserManager;
			platformUserImpl.GetLocalUserName(delegate(string name)
			{
				OnlineName = name;
			});
			platformImpl.JoinRequest += GotJoinRequest;
			parentalControlManager = new ParentalControlManager();
			_lastFriendRefreshTimeStamp = (_lastSessionRefreshTimeStamp = Time.realtimeSinceStartup);
			Task.Run(delegate
			{
				if (HasNetworkCheck().Result)
				{
					UnityMainThreadDispatcher.Instance().Enqueue(delegate
					{
						discordPlatform = new DiscordPlatform();
						discordPlatform.Init();
						discordPlatform.JoinRequest += GotJoinRequest;
					});
				}
			});
			return true;
		}
	}

	private void Platform_PlatformOverlayStateChanged(bool overlayEnabled)
	{
		this.PlatformOverlayStateChanged?.Invoke(overlayEnabled);
	}

	private void Platform_ApplicationFocusChanged(ApplicationFocusChange change)
	{
		this.ApplicationFocusChanged?.Invoke(change);
	}

	public bool IsPlatformOverlayActive()
	{
		if (platformImpl == null)
		{
			Debug.LogError("Can't check if overlay active because Platform is not initialized!");
			return false;
		}
		return platformImpl.IsPlatformOverlayActive();
	}

	public override void Deinit()
	{
		platformImpl?.Deinit();
		discordPlatform?.Deinit();
	}

	private void Update()
	{
		platformImpl?.Update();
		discordPlatform?.Update();
	}

	public void AddJoinRequestHandler(JoinRequestCallback callback)
	{
		if (CommandLineArgs.GetArgCount() > 1 && !CommandLineArgs.GetArg(1).StartsWith("-"))
		{
			callback?.Invoke(CommandLineArgs.GetArg(1));
		}
		joinRequestCallback = (JoinRequestCallback)Delegate.Combine(joinRequestCallback, callback);
	}

	private void GotJoinRequest(string value)
	{
		joinRequestCallback?.Invoke(value);
	}

	public bool TriggerAchievement(AchievementData data)
	{
		return platformImpl.TriggerAchievement(data);
	}

	public void ClearAllAchievements()
	{
		platformImpl.ClearAllAchievements();
	}

	public void RefreshPlatformFriends(bool getProfiles = false)
	{
		float num = Time.realtimeSinceStartup - _lastFriendRefreshTimeStamp;
		if (num < 10f)
		{
			Debug.Log(string.Format("{0}.{1}: skipping refresh as there's not been long enough since the last refresh ({2} seconds).", "PlatformManager", "RefreshPlatformFriends", num));
			return;
		}
		_lastFriendRefreshTimeStamp = Time.realtimeSinceStartup;
		platformUserImpl.RefreshPlatformFriends(getProfiles);
	}

	private void OnDestroy()
	{
		Debug.Log("PlatformManager was destroyed");
	}

	public bool RefreshJoinableSessions(Action<PlatformInterface.SessionFetchStatus, List<PlatformSession>> onJoinableSessionsRefreshed)
	{
		float num = Time.realtimeSinceStartup - _lastSessionRefreshTimeStamp;
		if (num < 12f)
		{
			Debug.Log(string.Format("{0}.{1}: skipping refresh as there's not been long enough since the last refresh ({2} seconds).", "PlatformManager", "RefreshJoinableSessions", num));
			return false;
		}
		_lastSessionRefreshTimeStamp = Time.realtimeSinceStartup;
		return platformImpl.RefreshJoinableSessions(onJoinableSessionsRefreshed);
	}
}
