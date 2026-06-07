using System.Collections;

namespace Animancer.FSM
{
	public interface IStateMachine
	{
		object CurrentState { get; }

		object PreviousState { get; }

		object NextState { get; }

		bool CanSetState(object state);

		object CanSetState(IList states);

		bool TrySetState(object state);

		bool TrySetState(IList states);

		bool TryResetState(object state);

		bool TryResetState(IList states);

		void ForceSetState(object state);

		void SetAllowNullStates(bool allow = true);
	}
}
