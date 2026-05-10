namespace Animancer
{
	public interface ITransition : IHasKey, IPolymorphic
	{
		float FadeDuration { get; }

		FadeMode FadeMode { get; }

		AnimancerState CreateState();

		void Apply(AnimancerState state);
	}
	public interface ITransition<TState> : ITransition, IHasKey, IPolymorphic where TState : AnimancerState
	{
		TState State { get; }

		new TState CreateState();
	}
}
