using System;

namespace GameCreator.Runtime.Common
{
	public abstract class TState : IState
	{
		[field: NonSerialized]
		public bool IsActive { get; private set; }

		public event Action<IStateMachine, IState> EventOnEnter;

		public event Action<IStateMachine, IState> EventOnExit;

		public event Action<IStateMachine, IState> EventOnBeforeUpdate;

		public void OnEnter(IStateMachine stateMachine)
		{
			IsActive = true;
			WhenEnter(stateMachine);
			this.EventOnEnter?.Invoke(stateMachine, this);
		}

		public void OnExit(IStateMachine stateMachine)
		{
			IsActive = false;
			WhenExit(stateMachine);
			this.EventOnExit?.Invoke(stateMachine, this);
		}

		public void OnUpdate(IStateMachine stateMachine)
		{
			WhenUpdate(stateMachine);
			this.EventOnBeforeUpdate?.Invoke(stateMachine, this);
		}

		protected virtual void WhenEnter(IStateMachine stateMachine)
		{
		}

		protected virtual void WhenExit(IStateMachine stateMachine)
		{
		}

		protected virtual void WhenUpdate(IStateMachine stateMachine)
		{
		}
	}
}
