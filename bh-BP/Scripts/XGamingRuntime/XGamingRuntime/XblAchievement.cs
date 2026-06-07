using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblAchievement
	{
		public string Id { get; private set; }

		public string ServiceConfigurationId { get; private set; }

		public string Name { get; private set; }

		public XblAchievementTitleAssociation[] TitleAssociations { get; private set; }

		public XblAchievementProgressState ProgressState { get; private set; }

		public XblAchievementProgression Progression { get; private set; }

		public XblAchievementMediaAsset[] MediaAssets { get; private set; }

		public string[] PlatformsAvailableOn { get; private set; }

		public bool IsSecret { get; private set; }

		public string UnlockedDescription { get; private set; }

		public string LockedDescription { get; private set; }

		public string ProductId { get; private set; }

		public XblAchievementType Type { get; private set; }

		public XblAchievementParticipationType ParticipationType { get; private set; }

		public XblAchievementTimeWindow Available { get; private set; }

		public XblAchievementReward[] Rewards { get; private set; }

		public ulong EstimatedUnlockTime { get; private set; }

		public string DeepLink { get; private set; }

		public bool IsRevoked { get; private set; }

		internal XblAchievement(XGamingRuntime.Interop.XblAchievement interopAchievement)
		{
		}
	}
}
