using NSMedieval.StatsSystem;

namespace NSMedieval.Construction
{
	public class ConstructionParameters
	{
		private float constructionDuration;

		private AttributeType durationStat;

		private AttributeType failStat;

		private SkillType rewardedSkill;

		private float rewardAmount;

		private string toolId;

		public float ConstructionDuration => constructionDuration;

		public AttributeType DurationStat => durationStat;

		public AttributeType FailStat => failStat;

		public SkillType RewardedSkill => rewardedSkill;

		public float RewardAmount => rewardAmount;

		public string ToolId => toolId;

		public ConstructionParameters(float constructionDuration, AttributeType durationStat, AttributeType failStat, SkillType rewardedSkill, float rewardAmount, string toolId)
		{
			this.constructionDuration = constructionDuration;
			this.durationStat = durationStat;
			this.failStat = failStat;
			this.rewardedSkill = rewardedSkill;
			this.rewardAmount = rewardAmount;
			this.toolId = toolId;
		}
	}
}
