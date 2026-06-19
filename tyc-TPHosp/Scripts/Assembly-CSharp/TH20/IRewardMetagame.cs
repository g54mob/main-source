namespace TH20
{
	public abstract class IRewardMetagame : IReward
	{
		public abstract void Apply(Metagame metagame);

		public void Apply(Objective objective, Level level)
		{
		}

		public virtual string Description(Objective objective)
		{
			return null;
		}
	}
}
