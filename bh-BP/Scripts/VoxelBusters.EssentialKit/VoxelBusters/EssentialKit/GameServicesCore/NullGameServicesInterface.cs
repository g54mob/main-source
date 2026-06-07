using System.Collections.Generic;

namespace VoxelBusters.EssentialKit.GameServicesCore
{
	internal sealed class NullGameServicesInterface : NativeGameServicesInterfaceBase
	{
		public NullGameServicesInterface()
			: base(isAvailable: false)
		{
		}

		public override void LoadLeaderboards(LeaderboardDefinition[] leaderboardDefinitions, LoadLeaderboardsInternalCallback callback)
		{
		}

		public override void ShowLeaderboard(string leaderboardId, string leaderboardPlatformId, LeaderboardTimeScope timeScope, ViewClosedInternalCallback callback)
		{
		}

		public override ILeaderboard CreateLeaderboard(string id, string platformId)
		{
			return null;
		}

		public override void LoadAchievementDescriptions(LoadAchievementDescriptionsInternalCallback callback)
		{
		}

		public override void LoadAchievements(LoadAchievementsInternalCallback callback)
		{
		}

		public override void ShowAchievements(ViewClosedInternalCallback callback)
		{
		}

		public override IAchievement CreateAchievement(string id, string platformId)
		{
			return null;
		}

		public override void LoadPlayers(string[] playerIds, LoadPlayersInternalCallback callback)
		{
		}

		public override void SetAuthChangeCallback(AuthChangeInternalCallback callback)
		{
		}

		public override void Authenticate(bool interactive)
		{
		}

		public override void Signout()
		{
		}

		public override ILocalPlayer GetLocalPlayer()
		{
			return null;
		}

		public override void SetCanShowAchievementCompletionBanner(bool value)
		{
		}

		public override void LoadServerCredentials(List<ServerCredentialAdditionalScope> additionalScopes, LoadServerCredentialsInternalCallback callback)
		{
		}
	}
}
