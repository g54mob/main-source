using UnityEngine;

namespace Animancer.FSM
{
	[HelpURL("https://kybernetik.com.au/animancer/api/Animancer.FSM/StateExtensions")]
	public static class StateExtensions
	{
		public const string APIDocumentationURL = "https://kybernetik.com.au/animancer/api/Animancer.FSM/";

		public static TState GetPreviousState<TState>(this TState state) where TState : class, IState
		{
			return StateChange<TState>.PreviousState;
		}

		public static TState GetNextState<TState>(this TState state) where TState : class, IState
		{
			return StateChange<TState>.NextState;
		}

		public static bool IsCurrentState<TState>(this TState state) where TState : class, IOwnedState<TState>
		{
			return state.OwnerStateMachine.CurrentState == state;
		}

		public static bool TryEnterState<TState>(this TState state) where TState : class, IOwnedState<TState>
		{
			return state.OwnerStateMachine.TrySetState(state);
		}

		public static bool TryReEnterState<TState>(this TState state) where TState : class, IOwnedState<TState>
		{
			return state.OwnerStateMachine.TryResetState(state);
		}

		public static void ForceEnterState<TState>(this TState state) where TState : class, IOwnedState<TState>
		{
			state.OwnerStateMachine.ForceSetState(state);
		}
	}
}
