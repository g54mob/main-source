using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblAchievementReward
	{
		public string Name { get; }

		public string Description { get; }

		public string Value { get; }

		public XblAchievementRewardType RewardType { get; }

		public string ValueType { get; }

		public XblAchievementMediaAsset MediaAsset { get; }

		internal XblAchievementReward(XGamingRuntime.Interop.XblAchievementReward interopReward)
		{
			Name = interopReward.name.GetString();
			Description = interopReward.description.GetString();
			Value = interopReward.value.GetString();
			RewardType = interopReward.rewardType;
			ValueType = interopReward.valueType.GetString();
			MediaAsset = interopReward.GetMediaAsset((XGamingRuntime.Interop.XblAchievementMediaAsset ma) => new XblAchievementMediaAsset(ma));
		}
	}
}
