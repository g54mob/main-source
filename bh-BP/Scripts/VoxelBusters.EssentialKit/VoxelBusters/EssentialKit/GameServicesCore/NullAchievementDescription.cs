namespace VoxelBusters.EssentialKit.GameServicesCore
{
	internal sealed class NullAchievementDescription : AchievementDescriptionBase
	{
		public NullAchievementDescription(string id, string platformId, int numOfStepsToUnlock)
			: base(null, null, 0)
		{
		}

		public static void LoadAchievementDescriptions(LoadAchievementDescriptionsInternalCallback callback)
		{
		}

		private static void LogNotSupported()
		{
		}

		protected override string GetTitleInternal()
		{
			return null;
		}

		protected override string GetUnachievedDescriptionInternal()
		{
			return null;
		}

		protected override string GetAchievedDescriptionInternal()
		{
			return null;
		}

		protected override long GetMaximumPointsInternal()
		{
			return 0L;
		}

		protected override bool GetIsHiddenInternal()
		{
			return false;
		}

		protected override bool GetIsReplayableInternal()
		{
			return false;
		}

		protected override void LoadIncompleteAchievementImageInternal(LoadImageInternalCallback callback)
		{
		}

		protected override void LoadImageInternal(LoadImageInternalCallback callback)
		{
		}
	}
}
