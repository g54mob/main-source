using Epic.OnlineServices;
using Epic.OnlineServices.Achievements;
using Epic.OnlineServices.Auth;
using Epic.OnlineServices.Connect;
using Epic.OnlineServices.Ecom;
using Epic.OnlineServices.Friends;
using Epic.OnlineServices.Leaderboards;
using Epic.OnlineServices.Lobby;
using Epic.OnlineServices.Logging;
using Epic.OnlineServices.Metrics;
using Epic.OnlineServices.Mods;
using Epic.OnlineServices.P2P;
using Epic.OnlineServices.Platform;
using Epic.OnlineServices.PlayerDataStorage;
using Epic.OnlineServices.Presence;
using Epic.OnlineServices.Sessions;
using Epic.OnlineServices.TitleStorage;
using Epic.OnlineServices.UI;
using Epic.OnlineServices.UserInfo;
using UnityEngine;

namespace EpicTransport
{
	public class EOSSDKComponent : MonoBehaviour
	{
		public string epicProductName;

		public string epicProductVersion;

		public string epicProductId;

		public string epicSandboxId;

		public string epicDeploymentId;

		public string epicClientId;

		public string epicClientSecret;

		public bool autoLogoutInEditor;

		public bool authInterfaceLogin;

		public LoginCredentialType authInterfaceCredentialType;

		public uint devAuthToolPort;

		public string devAuthToolCredentialName;

		public ExternalCredentialType connectInterfaceCredentialType;

		public string deviceModel;

		[SerializeField]
		private string displayName;

		public LogLevel epicLoggerLevel;

		[SerializeField]
		private bool collectPlayerMetrics;

		public bool checkForEpicLauncherAndRestart;

		public bool delayedInitialization;

		public float platformTickIntervalInSeconds;

		private float platformTickTimer;

		public uint tickBudgetInMilliseconds;

		private string authInterfaceLoginCredentialId;

		private string authInterfaceCredentialToken;

		private string connectInterfaceCredentialToken;

		protected PlatformInterface EOS;

		protected EpicAccountId localUserAccountId;

		protected string localUserAccountIdString;

		protected ProductUserId localUserProductId;

		protected string localUserProductIdString;

		protected bool initialized;

		protected bool isConnecting;

		protected static EOSSDKComponent instance;

		public NATType NATType;

		private ulong authExpirationHandle;

		public static string DisplayName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static bool CollectPlayerMetrics => false;

		public static EpicAccountId LocalUserAccountId => null;

		public static string LocalUserAccountIdString => null;

		public static ProductUserId LocalUserProductId => null;

		public static string LocalUserProductIdString => null;

		public static bool Initialized => false;

		public static bool IsConnecting => false;

		public static EOSSDKComponent Instance => null;

		public static void SetAuthInterfaceLoginCredentialId(string credentialId)
		{
		}

		public static void SetAuthInterfaceCredentialToken(string credentialToken)
		{
		}

		public static void SetConnectInterfaceCredentialToken(string credentialToken)
		{
		}

		public static AchievementsInterface GetAchievementsInterface()
		{
			return null;
		}

		public static AuthInterface GetAuthInterface()
		{
			return null;
		}

		public static ConnectInterface GetConnectInterface()
		{
			return null;
		}

		public static EcomInterface GetEcomInterface()
		{
			return null;
		}

		public static FriendsInterface GetFriendsInterface()
		{
			return null;
		}

		public static LeaderboardsInterface GetLeaderboardsInterface()
		{
			return null;
		}

		public static LobbyInterface GetLobbyInterface()
		{
			return null;
		}

		public static MetricsInterface GetMetricsInterface()
		{
			return null;
		}

		public static ModsInterface GetModsInterface()
		{
			return null;
		}

		public static P2PInterface GetP2PInterface()
		{
			return null;
		}

		public static PlayerDataStorageInterface GetPlayerDataStorageInterface()
		{
			return null;
		}

		public static PresenceInterface GetPresenceInterface()
		{
			return null;
		}

		public static SessionsInterface GetSessionsInterface()
		{
			return null;
		}

		public static TitleStorageInterface GetTitleStorageInterface()
		{
			return null;
		}

		public static UIInterface GetUIInterface()
		{
			return null;
		}

		public static UserInfoInterface GetUserInfoInterface()
		{
			return null;
		}

		public static void Tick()
		{
		}

		private void Awake()
		{
		}

		protected void InitializeImplementation()
		{
		}

		public static void Initialize()
		{
		}

		private void OnAuthInterfaceLogin(Epic.OnlineServices.Auth.LoginCallbackInfo loginCallbackInfo)
		{
		}

		private void OnCreateDeviceId(CreateDeviceIdCallbackInfo createDeviceIdCallbackInfo)
		{
		}

		protected void ConnectInterfaceLogin()
		{
		}

		protected virtual void OnConnectInterfaceLogin(Epic.OnlineServices.Connect.LoginCallbackInfo loginCallbackInfo)
		{
		}

		private void OnQueryNATTypeCallback(OnQueryNATTypeCompleteInfo info)
		{
		}

		private void OnAuthExpiration(AuthExpirationCallbackInfo authExpirationCallbackInfo)
		{
		}

		private void OnAuthInterfaceLogout(LogoutCallbackInfo logoutCallbackInfo)
		{
		}

		private void LateUpdate()
		{
		}

		private void OnDestroy()
		{
		}
	}
}
