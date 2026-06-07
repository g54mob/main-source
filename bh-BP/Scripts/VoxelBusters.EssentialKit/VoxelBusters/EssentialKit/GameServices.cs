using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using VoxelBusters.CoreLibrary;
using VoxelBusters.EssentialKit.GameServicesCore;

namespace VoxelBusters.EssentialKit
{
	public static class GameServices
	{
		[ClearOnReload]
		private static INativeGameServicesInterface s_nativeInterface;

		public static GameServicesUnitySettings UnitySettings { get; private set; }

		public static LeaderboardDefinition[] LeaderboardDefinitions { get; private set; }

		public static AchievementDefinition[] AchievementDefinitions { get; private set; }

		public static ILocalPlayer LocalPlayer => null;

		public static bool IsAuthenticated => false;

		public static ILeaderboard[] Leaderboards { get; private set; }

		public static IAchievementDescription[] AchievementDescriptions { get; private set; }

		public static IAchievement[] Achievements { get; private set; }

		public static event EventCallback<GameServicesAuthStatusChangeResult> OnAuthStatusChange
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

		public static bool IsAvailable()
		{
			return false;
		}

		public static void Initialize(GameServicesUnitySettings settings)
		{
		}

		internal static LeaderboardDefinition FindLeaderboardDefinitionWithId(string leaderboardId)
		{
			return null;
		}

		internal static LeaderboardDefinition FindLeaderboardDefinitionWithPlatformId(string leaderboardPlatformId)
		{
			return null;
		}

		internal static AchievementDefinition FindAchievementDefinitionWithId(string achievementId)
		{
			return null;
		}

		internal static AchievementDefinition FindAchievementDefinitionWithPlatformId(string achievementPlatformId)
		{
			return null;
		}

		public static ILeaderboard CreateLeaderboard(string leaderboardId)
		{
			return null;
		}

		public static void LoadLeaderboards(EventCallback<GameServicesLoadLeaderboardsResult> callback)
		{
		}

		public static IAchievement CreateAchievement(string achievementId)
		{
			return null;
		}

		public static void LoadAchievementDescriptions(EventCallback<GameServicesLoadAchievementDescriptionsResult> callback)
		{
		}

		public static void LoadAchievements(EventCallback<GameServicesLoadAchievementsResult> callback)
		{
		}

		public static void ReportAchievementProgress(string achievementId, double percentageCompleted, CompletionCallback callback)
		{
		}

		public static void ReportAchievementProgress(IAchievementDescription achievementDescription, double percentageCompleted, CompletionCallback callback)
		{
		}

		public static void ReportAchievementProgress(IAchievement achievement, double percentageCompleted, CompletionCallback callback)
		{
		}

		public static void LoadFriends(EventCallback<GameServicesLoadPlayerFriendsResult> callback)
		{
		}

		public static void AddFriend(string playerId, EventCallback<bool> callback)
		{
		}

		public static void Authenticate(bool interactive = true)
		{
		}

		public static void Signout()
		{
		}

		public static void ReportScore(string leaderboardId, long value, CompletionCallback callback, string tag = null)
		{
		}

		public static void ReportScore(ILeaderboard leaderboard, long value, CompletionCallback callback, string tag = null)
		{
		}

		public static void ShowLeaderboards(LeaderboardTimeScope timescope = LeaderboardTimeScope.AllTime, EventCallback<GameServicesViewResult> callback = null)
		{
		}

		public static void ShowLeaderboard(string leaderboardId, LeaderboardTimeScope timescope = LeaderboardTimeScope.AllTime, EventCallback<GameServicesViewResult> callback = null)
		{
		}

		public static void ShowLeaderboard(ILeaderboard leaderboard, LeaderboardTimeScope timescope = LeaderboardTimeScope.AllTime, EventCallback<GameServicesViewResult> callback = null)
		{
		}

		public static void ShowAchievements(EventCallback<GameServicesViewResult> callback = null)
		{
		}

		public static void LoadServerCredentials(EventCallback<GameServicesLoadServerCredentialsResult> callback)
		{
		}

		public static void LoadServerCredentials(List<ServerCredentialAdditionalScope> additionalScopes, EventCallback<GameServicesLoadServerCredentialsResult> callback)
		{
		}

		private static void HandleAuthChangeInternalCallback(LocalPlayerAuthStatus authStatus, Error error)
		{
		}

		private static void SendLoadLeaderboardsResult(EventCallback<GameServicesLoadLeaderboardsResult> callback, ILeaderboard[] leaderboards, Error error)
		{
		}

		private static void SendLoadAchievementDescriptionsResult(EventCallback<GameServicesLoadAchievementDescriptionsResult> callback, IAchievementDescription[] descriptions, Error error)
		{
		}

		private static void SendLoadAchievementsResult(EventCallback<GameServicesLoadAchievementsResult> callback, IAchievement[] achievements, Error error)
		{
		}

		private static void SendLoadPlayersResult(EventCallback<GameServicesLoadPlayersResult> callback, IPlayer[] players, Error error)
		{
		}

		private static void SendViewClosedResult(EventCallback<GameServicesViewResult> callback, Error error)
		{
		}

		private static void SendLoadServerCredentialsResult(EventCallback<GameServicesLoadServerCredentialsResult> callback, ServerCredentials serverCredentials, List<ServerCredentialAdditionalScope> additionalGrantedScopes, Error error)
		{
		}

		[Obsolete("This method is obsolete due to privacy restrictions on supported platforms.")]
		public static void LoadPlayers(string[] playerIds, EventCallback<GameServicesLoadPlayersResult> callback)
		{
		}

		[Obsolete("Use ReportScore(string, long, CompletionCallback, string) or ILeaderboard.ReportScore(long, CompletionCallback) instead for submitting scores.", true)]
		public static IScore CreateScore(string leaderboardId)
		{
			return null;
		}

		[Obsolete("Use ReportScore(string, long, CompletionCallback, string) instead for submitting scores.", true)]
		public static IScore CreateScore(ILeaderboard leaderboard)
		{
			return null;
		}
	}
}
