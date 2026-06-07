using System;
using System.Runtime.InteropServices;

public class GameCenterShared
{
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void LogDelegate(string logMessage);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void GameCenterFocusChangedDelegate(bool gameCenterHasFocus);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void GameCenterAuthAttemptedDelegate(int status);

	[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl)]
	[return: MarshalAs(UnmanagedType.I1)]
	public static extern bool GCStart(IntPtr logDelegate, IntPtr gameCenterFocusChangedDelegate, IntPtr gameCenterAuthAttemptedDelegate);

	[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl)]
	[return: MarshalAs(UnmanagedType.I1)]
	public static extern bool GCIsAuthenticated();

	[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl)]
	[return: MarshalAs(UnmanagedType.I1)]
	public static extern bool GCAreAchievementsReady();

	[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl)]
	[return: MarshalAs(UnmanagedType.I1)]
	public static extern bool GCSetAchievement(string achievementId, bool showBanner);

	[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl)]
	[return: MarshalAs(UnmanagedType.I1)]
	public static extern bool GCIsAchievementComplete(string achievementId);

	[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl)]
	[return: MarshalAs(UnmanagedType.I1)]
	public static extern bool GCSupportsRecurringLeaderboards();

	[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl)]
	[return: MarshalAs(UnmanagedType.I1)]
	public static extern bool GCSetLeaderboardScore(string leaderboardId, int score, int scoreContext);

	[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl)]
	[return: MarshalAs(UnmanagedType.I1)]
	public static extern bool GCRequestTopLeaderboardEntries(string leaderboardId);

	[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl)]
	[return: MarshalAs(UnmanagedType.I1)]
	public static extern bool GCRequestPlayerCenteredLeaderboardEntries(string leaderboardId);

	[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl)]
	[return: MarshalAs(UnmanagedType.I1)]
	public static extern bool GCRequestLocalLeaderboardEntry(string leaderboardId);

	[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl)]
	[return: MarshalAs(UnmanagedType.I1)]
	public static extern bool GCRequestFriendLeaderboardEntries(string leaderboardId);

	[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl)]
	[return: MarshalAs(UnmanagedType.I1)]
	public static extern bool GCIsLeaderboardRequestFinished();

	[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl)]
	public static extern int GCGetDownloadedLeaderboardEntryCount();

	[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl)]
	public static extern long GCGetTotalLeaderboardEntryCount();

	[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl)]
	[return: MarshalAs(UnmanagedType.I1)]
	public static extern bool GCGetRetrievedLeaderboardEntry(int entryIndex, ref IntPtr id, ref IntPtr name, ref int score, ref long rank, ref int context, ref bool isLocal, ref bool isFriend);

	[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl)]
	public static extern void GCResetAchievements();

	[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl)]
	[return: MarshalAs(UnmanagedType.I1)]
	public static extern bool GCIsAccessPointAvailable();

	[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl)]
	public static extern void GCShowAccessPoint();

	[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl)]
	public static extern void GCHideAccessPoint();

	[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl)]
	public static extern void GCSelectAccessPoint();

	[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl)]
	public static extern float GCGetAccessPointOriginX();

	[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl)]
	public static extern float GCGetAccessPointOriginY();

	[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl)]
	public static extern float GCGetAccessPointSizeWidth();

	[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl)]
	public static extern float GCGetAccessPointSizeHeight();

	[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl)]
	[return: MarshalAs(UnmanagedType.I1)]
	public static extern bool GCOpenLeaderboardView(string leaderboardId);

	[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl)]
	[return: MarshalAs(UnmanagedType.I1)]
	public static extern bool GCIsUserUnderage();
}
