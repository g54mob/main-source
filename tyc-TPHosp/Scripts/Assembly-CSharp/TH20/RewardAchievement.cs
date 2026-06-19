using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RewardAchievement : IReward
	{
		[SerializeField]
		private AchievementId _achievement;

		public void Apply(Objective objective, Level level)
		{
			PlatformStatsAndAchievements.TriggerAchievement(_achievement);
		}

		public string Description(Objective objective)
		{
			return string.Empty;
		}
	}
}
