namespace Animancer
{
	public interface ITransitionDetailed : ITransition, IHasKey, IPolymorphic
	{
		bool IsValid { get; }

		bool IsLooping { get; }

		float NormalizedStartTime { get; set; }

		float MaximumDuration { get; }

		float Speed { get; set; }
	}
}
