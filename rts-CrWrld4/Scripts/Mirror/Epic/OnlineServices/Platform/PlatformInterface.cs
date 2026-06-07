using System;
using System.Runtime.InteropServices;
using Epic.OnlineServices.Achievements;
using Epic.OnlineServices.Auth;
using Epic.OnlineServices.Connect;
using Epic.OnlineServices.Ecom;
using Epic.OnlineServices.Friends;
using Epic.OnlineServices.Leaderboards;
using Epic.OnlineServices.Lobby;
using Epic.OnlineServices.Metrics;
using Epic.OnlineServices.Mods;
using Epic.OnlineServices.P2P;
using Epic.OnlineServices.PlayerDataStorage;
using Epic.OnlineServices.Presence;
using Epic.OnlineServices.Reports;
using Epic.OnlineServices.Sanctions;
using Epic.OnlineServices.Sessions;
using Epic.OnlineServices.Stats;
using Epic.OnlineServices.TitleStorage;
using Epic.OnlineServices.UI;
using Epic.OnlineServices.UserInfo;

namespace Epic.OnlineServices.Platform
{
	public sealed class PlatformInterface : Handle
	{
		public const int AndroidinitializeoptionssysteminitializeoptionsApiLatest = 2;

		public const int CountrycodeMaxBufferLen = 5;

		public const int CountrycodeMaxLength = 4;

		public const int InitializeApiLatest = 4;

		public const int InitializeThreadaffinityApiLatest = 1;

		public const int LocalecodeMaxBufferLen = 10;

		public const int LocalecodeMaxLength = 9;

		public const int OptionsApiLatest = 10;

		public static Result Initialize(AndroidInitializeOptions options)
		{
			return default(Result);
		}

		public PlatformInterface()
		{
		}

		public PlatformInterface(IntPtr innerHandle)
		{
		}

		public Result CheckForLauncherAndRestart()
		{
			return default(Result);
		}

		public static PlatformInterface Create(Options options)
		{
			return null;
		}

		public AchievementsInterface GetAchievementsInterface()
		{
			return null;
		}

		public Result GetActiveCountryCode(EpicAccountId localUserId, out string outBuffer)
		{
			outBuffer = null;
			return default(Result);
		}

		public Result GetActiveLocaleCode(EpicAccountId localUserId, out string outBuffer)
		{
			outBuffer = null;
			return default(Result);
		}

		public AuthInterface GetAuthInterface()
		{
			return null;
		}

		public ConnectInterface GetConnectInterface()
		{
			return null;
		}

		public EcomInterface GetEcomInterface()
		{
			return null;
		}

		public FriendsInterface GetFriendsInterface()
		{
			return null;
		}

		public LeaderboardsInterface GetLeaderboardsInterface()
		{
			return null;
		}

		public LobbyInterface GetLobbyInterface()
		{
			return null;
		}

		public MetricsInterface GetMetricsInterface()
		{
			return null;
		}

		public ModsInterface GetModsInterface()
		{
			return null;
		}

		public Result GetOverrideCountryCode(out string outBuffer)
		{
			outBuffer = null;
			return default(Result);
		}

		public Result GetOverrideLocaleCode(out string outBuffer)
		{
			outBuffer = null;
			return default(Result);
		}

		public P2PInterface GetP2PInterface()
		{
			return null;
		}

		public PlayerDataStorageInterface GetPlayerDataStorageInterface()
		{
			return null;
		}

		public PresenceInterface GetPresenceInterface()
		{
			return null;
		}

		public ReportsInterface GetReportsInterface()
		{
			return null;
		}

		public SanctionsInterface GetSanctionsInterface()
		{
			return null;
		}

		public SessionsInterface GetSessionsInterface()
		{
			return null;
		}

		public StatsInterface GetStatsInterface()
		{
			return null;
		}

		public TitleStorageInterface GetTitleStorageInterface()
		{
			return null;
		}

		public UIInterface GetUIInterface()
		{
			return null;
		}

		public UserInfoInterface GetUserInfoInterface()
		{
			return null;
		}

		public static Result Initialize(InitializeOptions options)
		{
			return default(Result);
		}

		public void Release()
		{
		}

		public Result SetOverrideCountryCode(string newCountryCode)
		{
			return default(Result);
		}

		public Result SetOverrideLocaleCode(string newLocaleCode)
		{
			return default(Result);
		}

		public static Result Shutdown()
		{
			return default(Result);
		}

		public void Tick()
		{
		}

		[PreserveSig]
		internal static extern Result EOS_Platform_CheckForLauncherAndRestart(IntPtr handle);

		[PreserveSig]
		internal static extern IntPtr EOS_Platform_Create(IntPtr options);

		[PreserveSig]
		internal static extern IntPtr EOS_Platform_GetAchievementsInterface(IntPtr handle);

		[PreserveSig]
		internal static extern Result EOS_Platform_GetActiveCountryCode(IntPtr handle, IntPtr localUserId, IntPtr outBuffer, ref int inOutBufferLength);

		[PreserveSig]
		internal static extern Result EOS_Platform_GetActiveLocaleCode(IntPtr handle, IntPtr localUserId, IntPtr outBuffer, ref int inOutBufferLength);

		[PreserveSig]
		internal static extern IntPtr EOS_Platform_GetAuthInterface(IntPtr handle);

		[PreserveSig]
		internal static extern IntPtr EOS_Platform_GetConnectInterface(IntPtr handle);

		[PreserveSig]
		internal static extern IntPtr EOS_Platform_GetEcomInterface(IntPtr handle);

		[PreserveSig]
		internal static extern IntPtr EOS_Platform_GetFriendsInterface(IntPtr handle);

		[PreserveSig]
		internal static extern IntPtr EOS_Platform_GetLeaderboardsInterface(IntPtr handle);

		[PreserveSig]
		internal static extern IntPtr EOS_Platform_GetLobbyInterface(IntPtr handle);

		[PreserveSig]
		internal static extern IntPtr EOS_Platform_GetMetricsInterface(IntPtr handle);

		[PreserveSig]
		internal static extern IntPtr EOS_Platform_GetModsInterface(IntPtr handle);

		[PreserveSig]
		internal static extern Result EOS_Platform_GetOverrideCountryCode(IntPtr handle, IntPtr outBuffer, ref int inOutBufferLength);

		[PreserveSig]
		internal static extern Result EOS_Platform_GetOverrideLocaleCode(IntPtr handle, IntPtr outBuffer, ref int inOutBufferLength);

		[PreserveSig]
		internal static extern IntPtr EOS_Platform_GetP2PInterface(IntPtr handle);

		[PreserveSig]
		internal static extern IntPtr EOS_Platform_GetPlayerDataStorageInterface(IntPtr handle);

		[PreserveSig]
		internal static extern IntPtr EOS_Platform_GetPresenceInterface(IntPtr handle);

		[PreserveSig]
		internal static extern IntPtr EOS_Platform_GetReportsInterface(IntPtr handle);

		[PreserveSig]
		internal static extern IntPtr EOS_Platform_GetSanctionsInterface(IntPtr handle);

		[PreserveSig]
		internal static extern IntPtr EOS_Platform_GetSessionsInterface(IntPtr handle);

		[PreserveSig]
		internal static extern IntPtr EOS_Platform_GetStatsInterface(IntPtr handle);

		[PreserveSig]
		internal static extern IntPtr EOS_Platform_GetTitleStorageInterface(IntPtr handle);

		[PreserveSig]
		internal static extern IntPtr EOS_Platform_GetUIInterface(IntPtr handle);

		[PreserveSig]
		internal static extern IntPtr EOS_Platform_GetUserInfoInterface(IntPtr handle);

		[PreserveSig]
		internal static extern Result EOS_Initialize(IntPtr options);

		[PreserveSig]
		internal static extern void EOS_Platform_Release(IntPtr handle);

		[PreserveSig]
		internal static extern Result EOS_Platform_SetOverrideCountryCode(IntPtr handle, IntPtr newCountryCode);

		[PreserveSig]
		internal static extern Result EOS_Platform_SetOverrideLocaleCode(IntPtr handle, IntPtr newLocaleCode);

		[PreserveSig]
		internal static extern Result EOS_Shutdown();

		[PreserveSig]
		internal static extern void EOS_Platform_Tick(IntPtr handle);
	}
}
