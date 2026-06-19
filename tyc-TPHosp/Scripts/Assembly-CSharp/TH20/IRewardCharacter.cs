namespace TH20
{
	public abstract class IRewardCharacter : IReward
	{
		public abstract void Apply(Character character);

		public void Apply(Objective objective, Level level)
		{
		}

		public virtual string Description(Objective objective)
		{
			return null;
		}
	}
}
