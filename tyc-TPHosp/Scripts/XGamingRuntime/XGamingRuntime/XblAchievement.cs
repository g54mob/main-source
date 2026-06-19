using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblAchievement
	{
		public string Id { get; }

		public string ServiceConfigurationId { get; }

		public string Name { get; }

		public XblAchievementTitleAssociation[] TitleAssociations { get; }

		public XblAchievementProgressState ProgressState { get; }

		public XblAchievementProgression Progression { get; }

		public XblAchievementMediaAsset[] MediaAssets { get; }

		public string[] PlatformsAvailableOn { get; }

		public bool IsSecret { get; }

		public string UnlockedDescription { get; }

		public string LockedDescription { get; }

		public string ProductId { get; }

		public XblAchievementType Type { get; }

		public XblAchievementParticipationType ParticipationType { get; }

		public XblAchievementTimeWindow Available { get; }

		public XblAchievementReward[] Rewards { get; }

		public ulong EstimatedUnlockTime { get; }

		public string DeepLink { get; }

		public bool IsRevoked { get; }

		internal XblAchievement(XGamingRuntime.Interop.XblAchievement interopAchievement)
		{
			Id = interopAchievement.id.GetString();
			ServiceConfigurationId = interopAchievement.serviceConfigurationId.GetString();
			Name = interopAchievement.name.GetString();
			TitleAssociations = interopAchievement.GetTitleAssociations((XGamingRuntime.Interop.XblAchievementTitleAssociation ta) => new XblAchievementTitleAssociation(ta));
			ProgressState = interopAchievement.progressState;
			Progression = new XblAchievementProgression(interopAchievement.progression);
			MediaAssets = interopAchievement.GetMediaAssets((XGamingRuntime.Interop.XblAchievementMediaAsset ma) => new XblAchievementMediaAsset(ma));
			PlatformsAvailableOn = interopAchievement.GetPlatformsAvailableOn();
			IsSecret = interopAchievement.isSecret;
			UnlockedDescription = interopAchievement.unlockedDescription.GetString();
			LockedDescription = interopAchievement.lockedDescription.GetString();
			ProductId = interopAchievement.productId.GetString();
			Type = interopAchievement.type;
			ParticipationType = interopAchievement.participationType;
			Available = new XblAchievementTimeWindow(interopAchievement.available);
			Rewards = interopAchievement.GetRewards((XGamingRuntime.Interop.XblAchievementReward reward) => new XblAchievementReward(reward));
			EstimatedUnlockTime = interopAchievement.estimatedUnlockTime;
			DeepLink = interopAchievement.deepLink.GetString();
			IsRevoked = interopAchievement.isRevoked;
		}
	}
}
