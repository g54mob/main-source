using NSMedieval.StatsSystem;

namespace NSMedieval.Model
{
	public class HarvestParametars
	{
		private float harvestDuration;

		private AttributeType durationStat;

		private AttributeType amountStat;

		private AttributeType failStat;

		private SkillType rewardedSkill;

		private float rewardAmount;

		private string toolId;

		public float HarvestDuration => harvestDuration;

		public AttributeType DurationStat => durationStat;

		public AttributeType AmountStat => amountStat;

		public AttributeType FailStat => failStat;

		public SkillType RewardedSkill => rewardedSkill;

		public float RewardAmount => rewardAmount;

		public string ToolId => toolId;

		public HarvestParametars(float harvestDuration, AttributeType durationStat, AttributeType amountStat, AttributeType failStat, SkillType rewardedSkill, float rewardAmount, string toolId)
		{
			this.harvestDuration = harvestDuration;
			this.durationStat = durationStat;
			this.amountStat = amountStat;
			this.failStat = failStat;
			this.rewardedSkill = rewardedSkill;
			this.rewardAmount = rewardAmount;
			this.toolId = toolId;
		}
	}
}
