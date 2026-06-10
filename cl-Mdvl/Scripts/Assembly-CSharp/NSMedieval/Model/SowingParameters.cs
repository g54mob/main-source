using NSMedieval.StatsSystem;

namespace NSMedieval.Model
{
	public class SowingParameters
	{
		private float sowDuration;

		private AttributeType durationAttribute;

		private SkillType rewardedSkill;

		private float rewardAmount;

		private string toolId;

		public float HarvestDuration => sowDuration;

		public AttributeType DurationAttribute => durationAttribute;

		public SkillType RewardedSkill => rewardedSkill;

		public float RewardAmount => rewardAmount;

		public string ToolId => toolId;

		public SowingParameters(float sowDuration, AttributeType durationStat, SkillType rewardedSkill, float rewardAmount, string toolId)
		{
			this.sowDuration = sowDuration;
			durationAttribute = durationStat;
			this.rewardedSkill = rewardedSkill;
			this.rewardAmount = rewardAmount;
			this.toolId = toolId;
		}
	}
}
