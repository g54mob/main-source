using System;
using UnityEngine;

namespace CTS.Core
{
	public abstract class FSM : CTSBehaviour
	{
		public event Action<object> StateChanged;

		internal void TriggerStateChange(object state)
		{
			this.StateChanged?.Invoke(state);
		}
	}
	public abstract class FSM<T> : FSM where T : MonoBehaviour
	{
		[SerializeField]
		private bool _resetStateOnDisable = true;

		protected T parent { get; }

		public State<T> CurrentState { get; private set; }

		public new event Action<State<T>> StateChanged;

		protected abstract State<T> GetInitState();

		protected override void OnEnabled()
		{
			if (CurrentState != null)
			{
				CurrentState.OnStateEnter();
			}
			else if (GetInitState() != null)
			{
				SetState(GetInitState());
			}
		}

		protected override void OnDisabled()
		{
			if (_resetStateOnDisable)
			{
				CurrentState?.OnStateExit();
				CurrentState = null;
			}
		}

		protected State<T> InitState(State<T> state)
		{
			state.Init(parent, this);
			return state;
		}

		protected virtual void OnDestroy()
		{
			SetState(null);
		}

		public void SetState<U>() where U : State<T>, new()
		{
			SetState(new U());
		}

		public void SetState(State<T> newState)
		{
			if (newState == CurrentState)
			{
				return;
			}
			CurrentState?.OnStateExit();
			CurrentState = null;
			CurrentState = newState;
			if (CurrentState != null)
			{
				CurrentState.Init(parent, this);
				this.StateChanged?.Invoke(CurrentState);
				TriggerStateChange(CurrentState);
				if (base.isActiveAndEnabled)
				{
					CurrentState.OnStateEnter();
				}
			}
		}
	}
}
