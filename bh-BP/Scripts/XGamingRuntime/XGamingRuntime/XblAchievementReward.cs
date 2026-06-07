using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblAchievementReward
	{
		public string Name { get; private set; }

		public string Description { get; private set; }

		public string Value { get; private set; }

		public XblAchievementRewardType RewardType { get; private set; }

		public string ValueType { get; private set; }

		public XblAchievementMediaAsset MediaAsset { get; private set; }

		internal XblAchievementReward(XGamingRuntime.Interop.XblAchievementReward interopReward)
		{
		}
	}
}
