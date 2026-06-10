using System;
using NSEipix.Base;

namespace NSEipix.State
{
	public class StateMachine<T>
	{
		private T owner;

		public IState<T> CurrentState { get; private set; }

		public IState<T> PreviousState { get; private set; }

		public IState<T> NextState { get; private set; }

		public IState<T> GlobalState { get; private set; }

		public StateMachine(T owner)
		{
			this.owner = owner;
		}

		public bool IsInState(string type)
		{
			return IsInState(Type.GetType(type));
		}

		public bool IsInState(IState<T> state)
		{
			return IsInState(state.GetType());
		}

		public bool IsInState(Type type)
		{
			if (CurrentState != null)
			{
				return CurrentState.GetType() == type;
			}
			return false;
		}

		public bool IsInGlobalState(string type)
		{
			return IsInGlobalState(Type.GetType(type));
		}

		public bool IsInGlobalState(IState<T> state)
		{
			return IsInGlobalState(state.GetType());
		}

		public bool IsInGlobalState(Type type)
		{
			if (GlobalState != null)
			{
				return GlobalState.GetType() == type;
			}
			return false;
		}

		public void ChangeState(IState<T> newState)
		{
			if (!CanChangeState(CurrentState, newState))
			{
				return;
			}
			NextState = newState;
			PreviousState = CurrentState;
			if (CurrentState != null)
			{
				CurrentState.Exit(owner);
			}
			CurrentState = newState;
			NextState = null;
			CurrentState.Enter(owner);
			MonoSingleton<TaskController>.Instance.WaitUntil(delegate
			{
				if (CurrentState != newState)
				{
					return true;
				}
				CurrentState.Update(owner);
				return false;
			});
		}

		public void RevertToPreviousState()
		{
			ChangeState(PreviousState);
		}

		public void ChangeGlobalState(IState<T> newGlobalState)
		{
			if (!CanChangeState(GlobalState, newGlobalState))
			{
				return;
			}
			if (GlobalState != null)
			{
				GlobalState.Exit(owner);
			}
			GlobalState = newGlobalState;
			GlobalState.Enter(owner);
			MonoSingleton<TaskController>.Instance.WaitUntil(delegate
			{
				if (GlobalState != newGlobalState)
				{
					return true;
				}
				GlobalState.Update(owner);
				return false;
			});
		}

		private bool CanChangeState(IState<T> current, IState<T> next)
		{
			if (next == null)
			{
				return false;
			}
			if (current != null && (current.TransitionIn() != null || current.GetType().Equals(next.GetType())) && (current.TransitionIn() == null || !current.TransitionIn().Contains(next.GetType())))
			{
				return false;
			}
			return true;
		}
	}
}
