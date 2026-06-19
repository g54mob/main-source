using System;
using System.Collections.Generic;

namespace TH20
{
	public class StateMachine : MustCallDestroy
	{
		private readonly StateMachineData _data;

		private readonly Stack<State> _stateStack = new Stack<State>();

		public State TopState
		{
			get
			{
				if (_stateStack.Count > 0)
				{
					return _stateStack.Peek();
				}
				return null;
			}
		}

		public StateMachine(StateMachineData data)
		{
			_data = data;
		}

		public override void Destroy()
		{
			foreach (State item in _stateStack)
			{
				item.Destroy();
			}
			_stateStack.Clear();
			base.Destroy();
		}

		public void PushState(State state)
		{
			state.SetOwner(this);
			if (TopState != null)
			{
				TopState.Suspend(state);
			}
			_stateStack.Push(state);
			if (TopState != null)
			{
				TopState.Enter();
			}
		}

		public void PopState(State state)
		{
			if (_stateStack.Count > 0)
			{
				_stateStack.Pop();
				State topState = TopState;
				state.Exit();
				state.Destroy();
				if (TopState != null && topState == TopState)
				{
					TopState.Resume(state);
				}
			}
		}

		public void Update()
		{
			if (TopState != null)
			{
				TopState.Update();
			}
		}

		public bool ContainsStateOfType(Type type)
		{
			foreach (State item in _stateStack)
			{
				if (item.GetType().IsAssignableFrom(type))
				{
					return true;
				}
			}
			return false;
		}

		public T GetStateInStateMachine<T>() where T : State
		{
			foreach (State item in _stateStack)
			{
				if (item is T result)
				{
					return result;
				}
			}
			return null;
		}

		public T GetStateMachineData<T>() where T : StateMachineData
		{
			return _data as T;
		}
	}
}
