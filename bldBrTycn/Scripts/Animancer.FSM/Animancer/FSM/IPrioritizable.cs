namespace Animancer.FSM
{
	public interface IPrioritizable : IState
	{
		float Priority { get; }
	}
}
