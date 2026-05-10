using System;

namespace Animancer.FSM
{
	public struct StateChange<TState> : IDisposable where TState : class, IState
	{
		[ThreadStatic]
		private static StateChange<TState> _Current;

		private StateMachine<TState> _StateMachine;

		private TState _PreviousState;

		private TState _NextState;

		public static bool IsActive => _Current._StateMachine != null;

		public static StateMachine<TState> StateMachine => _Current._StateMachine;

		public static TState PreviousState => _Current._PreviousState;

		public static TState NextState => _Current._NextState;

		internal StateChange(StateMachine<TState> stateMachine, TState previousState, TState nextState)
		{
			this = _Current;
			_Current._StateMachine = stateMachine;
			_Current._PreviousState = previousState;
			_Current._NextState = nextState;
		}

		public void Dispose()
		{
			_Current = this;
		}

		public override string ToString()
		{
			if (!IsActive)
			{
				return "StateChange<" + typeof(TState).FullName + "(Not Currently Active)";
			}
			return "StateChange<" + typeof(TState).FullName + string.Format(">({0}='{1}'", "PreviousState", _PreviousState) + string.Format(", {0}='{1}')", "NextState", _NextState);
		}

		public static string CurrentToString()
		{
			return _Current.ToString();
		}
	}
}
