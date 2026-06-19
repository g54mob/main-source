namespace TH20
{
	public abstract class State : MustCallDestroy
	{
		public StateMachine Owner { get; protected set; }

		protected virtual void PushState(State state)
		{
			Owner.PushState(state);
		}

		protected void PopState()
		{
			Owner.PopState(this);
		}

		public void SetOwner(StateMachine owner)
		{
			Owner = owner;
		}

		public virtual void Enter()
		{
		}

		public virtual void Update()
		{
		}

		public virtual void Exit()
		{
		}

		public virtual void Suspend(State suspendedBy)
		{
		}

		public virtual void Resume(State resumingFrom)
		{
		}
	}
}
