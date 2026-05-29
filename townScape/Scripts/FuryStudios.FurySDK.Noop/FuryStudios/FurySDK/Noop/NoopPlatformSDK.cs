using System.Collections.Generic;
using FuryStudios.FurySDK.Internal;
using UnityEngine;

namespace FuryStudios.FurySDK.Noop
{
	internal class NoopPlatformSDK : BasePlatformSDK
	{
		public override SystemIdentifier systemId => default(SystemIdentifier);

		public override PlatformIdentifier platformId => default(PlatformIdentifier);

		protected override PlatformFeature supportedFeatures => default(PlatformFeature);

		public override IUser User => null;

		public override bool IsUserSigningIn => false;

		[RuntimeInitializeOnLoadMethod]
		private static void RegisterSelf()
		{
		}

		public override IAsyncRequest SignIn(SignInOptions options)
		{
			return null;
		}

		public override IAsyncRequest SignOut()
		{
			return null;
		}

		protected override BaseStorageContainer CreateContainer(ContainerID containerID)
		{
			return null;
		}

		public override IAsyncRequest<bool> AreAchievementsUnlocked(IEnumerable<AchievementID> achievements)
		{
			return null;
		}

		public override IAsyncRequest<bool> IsAchievementUnlocked(AchievementID achievement)
		{
			return null;
		}

		public override IAsyncRequest SetAchievementProgress(AchievementID achievement, float progress)
		{
			return null;
		}

		public override IAsyncRequest LockAchievement(AchievementID achievement)
		{
			return null;
		}

		public override IAsyncRequest ShowAchievementsUI()
		{
			return null;
		}

		public override IAsyncRequest ShowWishlistUI()
		{
			return null;
		}

		public override IAsyncRequest SetRichPresence(RichPresenceID richPresence, params string[] tokens)
		{
			return null;
		}

		public override IAsyncRequest SetStat(StatID stat, float value, int[] metadata = null)
		{
			return null;
		}

		public override IAsyncRequest<ILeaderboard> GetLeaderboard(StatID stat)
		{
			return null;
		}

		public override IAsyncRequest<bool> IsDlcUnlocked(DlcID dlc)
		{
			return null;
		}
	}
}
