using System;
using System.Collections.Generic;

namespace CTS.Core.StateMachines
{
	public abstract class BaseStateMachine<TAgent> : CTSBehaviour
	{
		private readonly SafeEnumerable<IState<TAgent>> _currentStates = new SafeEnumerable<IState<TAgent>>();

		private static readonly Action<IState<TAgent>, BaseStateMachine<TAgent>, TAgent> _updateFunction = UpdateState;

		private static List<IState<TAgent>> _tempList = new List<IState<TAgent>>();

		public TAgent Agent { get; private set; }

		private void Update()
		{
			_currentStates.Enumerate(_updateFunction, this, Agent);
		}

		private static void UpdateState(IState<TAgent> state, BaseStateMachine<TAgent> machine, TAgent agent)
		{
			state.OnStateUpdate(machine, agent);
		}

		public void SetAgent(TAgent agent)
		{
			Agent = agent;
		}

		public bool HasState(IState<TAgent> state)
		{
			return _currentStates.Contains(state);
		}

		protected virtual void EnterState(IState<TAgent> state)
		{
			if (!HasState(state) && state.CanEnterState(this, Agent))
			{
				_currentStates.Add(state);
				state.OnStateEnter(this, Agent);
			}
		}

		protected virtual void ExitState(IState<TAgent> state)
		{
			if (HasState(state))
			{
				state.OnStateExit(this, Agent);
				_currentStates.Remove(state);
			}
		}

		public void ExitAllStates()
		{
			_tempList.Clear();
			for (int i = 0; i < _currentStates.Count; i++)
			{
				_tempList.Add(_currentStates[i]);
			}
			foreach (IState<TAgent> temp in _tempList)
			{
				ExitState(temp);
			}
		}
	}
}
