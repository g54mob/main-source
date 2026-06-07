using System;

namespace VoxelBusters.EssentialKit.GameServicesCore
{
	internal sealed class NullAchievement : AchievementBase
	{
		public NullAchievement(string id, string platformId)
			: base(null, null)
		{
		}

		public static void SetCanShowBannerOnCompletion(bool value)
		{
		}

		public static void LoadAchievements(LoadAchievementsInternalCallback callback)
		{
		}

		public static void ShowAchievementView(ViewClosedInternalCallback callback)
		{
		}

		private static void LogNotSupported()
		{
		}

		protected override double GetPercentageCompletedInternal()
		{
			return 0.0;
		}

		protected override void SetPercentageCompletedInternal(double value)
		{
		}

		protected override bool GetIsCompletedInternal()
		{
			return false;
		}

		protected override DateTime GetLastReportedDateInternal()
		{
			return default(DateTime);
		}

		protected override void ReportProgressInternal(ReportAchievementProgressInternalCallback callback)
		{
		}
	}
}
