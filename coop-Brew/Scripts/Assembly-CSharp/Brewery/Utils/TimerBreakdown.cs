namespace Brewery.Utils
{
	public struct TimerBreakdown
	{
		public float baseDuration;

		public float skillMultiplier;

		public float skillReduction;

		public float buffMultiplier;

		public float buffReduction;

		public float effectiveDuration;

		public bool HasSkillBonus => false;

		public bool HasBuffBonus => false;

		public float TotalSavings => 0f;
	}
}
