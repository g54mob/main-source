namespace TH20
{
	public interface IReward
	{
		void Apply(Objective objective, Level level);

		string Description(Objective objective);
	}
}
