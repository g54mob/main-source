using System;

namespace Animancer.FSM
{
	public class DelegateState : IState
	{
		public Func<bool> canEnter;

		public Func<bool> canExit;

		public Action onEnter;

		public Action onExit;

		public virtual bool CanEnterState
		{
			get
			{
				if (canEnter != null)
				{
					return canEnter();
				}
				return true;
			}
		}

		public virtual bool CanExitState
		{
			get
			{
				if (canExit != null)
				{
					return canExit();
				}
				return true;
			}
		}

		public virtual void OnEnterState()
		{
			onEnter?.Invoke();
		}

		public virtual void OnExitState()
		{
			onExit?.Invoke();
		}
	}
}
