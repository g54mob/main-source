using System;

namespace XGamingRuntime.Interop
{
	internal struct XblAchievement
	{
		internal readonly UTF8StringPtr id;

		internal readonly UTF8StringPtr serviceConfigurationId;

		internal readonly UTF8StringPtr name;

		private readonly IntPtr titleAssociations;

		private readonly SizeT titleAssociationsCount;

		internal readonly XblAchievementProgressState progressState;

		internal readonly XblAchievementProgression progression;

		private readonly IntPtr mediaAssets;

		private readonly SizeT mediaAssetsCount;

		private readonly IntPtr platformsAvailableOn;

		private readonly SizeT platformsAvailableOnCount;

		internal readonly bool isSecret;

		internal readonly UTF8StringPtr unlockedDescription;

		internal readonly UTF8StringPtr lockedDescription;

		internal readonly UTF8StringPtr productId;

		internal readonly XblAchievementType type;

		internal readonly XblAchievementParticipationType participationType;

		internal readonly XblAchievementTimeWindow available;

		private readonly IntPtr rewards;

		private readonly SizeT rewardsCount;

		internal readonly ulong estimatedUnlockTime;

		internal readonly UTF8StringPtr deepLink;

		internal readonly bool isRevoked;

		internal T[] GetTitleAssociations<T>(Func<XblAchievementTitleAssociation, T> ctor)
		{
			return null;
		}

		internal T[] GetMediaAssets<T>(Func<XblAchievementMediaAsset, T> ctor)
		{
			return null;
		}

		internal string[] GetPlatformsAvailableOn()
		{
			return null;
		}

		internal T[] GetRewards<T>(Func<XblAchievementReward, T> ctor)
		{
			return null;
		}
	}
}
