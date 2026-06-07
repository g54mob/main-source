using System;

namespace GameCreator.Runtime.Common
{
	public abstract class TStateMachine : IStateMachine
	{
		[field: NonSerialized]
		protected IState Current { get; private set; }

		public event Action<IStateMachine, IState> EventStateEnter;

		public event Action<IStateMachine, IState> EventStateExit;

		protected TStateMachine()
		{
		}

		protected TStateMachine(IState state)
			: this()
		{
			Change(state);
		}

		protected void OnUpdate()
		{
			Current?.OnUpdate(this);
		}

		protected void Change(IState state)
		{
			if (Current != null)
			{
				Current.OnExit(this);
				Current.EventOnEnter -= OnEnterCallback;
				Current.EventOnExit -= OnExitCallback;
			}
			Current = state;
			if (Current != null)
			{
				Current.EventOnEnter += OnEnterCallback;
				Current.EventOnExit += OnExitCallback;
				Current.OnEnter(this);
			}
		}

		private void OnEnterCallback(IStateMachine stateMachine, IState state)
		{
			this.EventStateEnter?.Invoke(stateMachine, state);
		}

		private void OnExitCallback(IStateMachine stateMachine, IState state)
		{
			this.EventStateExit?.Invoke(stateMachine, state);
		}
	}
}
