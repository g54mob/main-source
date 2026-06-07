using System;
using System.Collections.Generic;
using FuryStudios.FurySDK.Settings;
using UnityEngine;

namespace FuryStudios.FurySDK
{
	public interface IPlatformSDK
	{
		SystemIdentifier systemId { get; }

		PlatformIdentifier platformId { get; }

		bool IsInitialized { get; }

		Rect SafeArea { get; }

		IUser User { get; }

		bool IsUserSigningIn { get; }

		bool IsSuspended { get; }

		bool IsConstrained { get; }

		event Action OnSuspended;

		event Action OnResumed;

		event Action OnConstrained;

		event Action OnUnconstrained;

		void Init(PlatformSettings settings);

		Language GetSystemLanguage();

		bool AreFeaturesSupported(PlatformFeature features);

		IAsyncRequest SignIn(SignInOptions options);

		IAsyncRequest SignOut();

		IStorageContainer Storage(ContainerID container);

		IAsyncRequest SetAchievementProgress(AchievementID achievement, float progress);

		IAsyncRequest LockAchievement(AchievementID achievement);

		IAsyncRequest<bool> IsAchievementUnlocked(AchievementID achievement);

		IAsyncRequest<bool> AreAchievementsUnlocked(IEnumerable<AchievementID> achievements);

		IAsyncRequest ShowAchievementsUI();

		IAsyncRequest ShowWishlistUI();

		IAsyncRequest SetRichPresence(RichPresenceID richPresence, params string[] tokens);

		IAsyncRequest SetStat(StatID stat, float value, int[] metadata = null);

		IAsyncRequest<ILeaderboard> GetLeaderboard(StatID stat);

		IAsyncRequest<bool> IsDlcUnlocked(DlcID dlc);

		IAsyncRequest OpenURL(string url);
	}
}
