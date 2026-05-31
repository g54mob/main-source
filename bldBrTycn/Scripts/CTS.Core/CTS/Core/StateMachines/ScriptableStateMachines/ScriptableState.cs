using System;
using System.Collections.Generic;
using UnityEngine;

namespace CTS.Core.StateMachines.ScriptableStateMachines
{
	public abstract class ScriptableState<TEnum, TAgent> : ScriptableObject, IState<TEnum, TAgent>, IState<TAgent> where TEnum : Enum
	{
		[SerializeField]
		private List<TEnum> _blockingStates = new List<TEnum>();

		public bool CanEnterState(FiniteMultiStateMachine<TEnum, TAgent> machine, TAgent agent)
		{
			foreach (TEnum blockingState in _blockingStates)
			{
				if (machine.HasState(blockingState))
				{
					return false;
				}
			}
			return true;
		}

		protected abstract void OnStateEnter(FiniteMultiStateMachine<TEnum, TAgent> machine, TAgent agent);

		protected abstract void OnStateUpdate(FiniteMultiStateMachine<TEnum, TAgent> machine, TAgent agent);

		protected abstract void OnStateExit(FiniteMultiStateMachine<TEnum, TAgent> machine, TAgent agent);

		void IState<TEnum, TAgent>.OnStateEnter(FiniteMultiStateMachine<TEnum, TAgent> machine, TAgent agent)
		{
			OnStateEnter(machine, agent);
		}

		void IState<TEnum, TAgent>.OnStateUpdate(FiniteMultiStateMachine<TEnum, TAgent> machine, TAgent agent)
		{
			OnStateUpdate(machine, agent);
		}

		void IState<TEnum, TAgent>.OnStateExit(FiniteMultiStateMachine<TEnum, TAgent> machine, TAgent agent)
		{
			OnStateExit(machine, agent);
		}
	}
}
