using System;

namespace CTS.Core.StateMachines
{
	public interface IState<TAgent>
	{
		bool CanEnterState(BaseStateMachine<TAgent> machine, TAgent agent);

		internal void OnStateEnter(BaseStateMachine<TAgent> machine, TAgent agent);

		internal void OnStateUpdate(BaseStateMachine<TAgent> machine, TAgent agent);

		internal void OnStateExit(BaseStateMachine<TAgent> machine, TAgent agent);
	}
	public interface IState<TEnum, TAgent> : IState<TAgent> where TEnum : Enum
	{
		bool IState<TAgent>.CanEnterState(BaseStateMachine<TAgent> machine, TAgent agent)
		{
			if (machine is FiniteMultiStateMachine<TEnum, TAgent> machine2)
			{
				return CanEnterState(machine2, agent);
			}
			return false;
		}

		void IState<TAgent>.OnStateEnter(BaseStateMachine<TAgent> machine, TAgent agent)
		{
			OnStateEnter((FiniteMultiStateMachine<TEnum, TAgent>)machine, agent);
		}

		void IState<TAgent>.OnStateUpdate(BaseStateMachine<TAgent> machine, TAgent agent)
		{
			OnStateUpdate((FiniteMultiStateMachine<TEnum, TAgent>)machine, agent);
		}

		void IState<TAgent>.OnStateExit(BaseStateMachine<TAgent> machine, TAgent agent)
		{
			OnStateExit((FiniteMultiStateMachine<TEnum, TAgent>)machine, agent);
		}

		bool CanEnterState(FiniteMultiStateMachine<TEnum, TAgent> machine, TAgent agent);

		internal void OnStateEnter(FiniteMultiStateMachine<TEnum, TAgent> machine, TAgent agent);

		internal void OnStateUpdate(FiniteMultiStateMachine<TEnum, TAgent> machine, TAgent agent);

		internal void OnStateExit(FiniteMultiStateMachine<TEnum, TAgent> machine, TAgent agent);
	}
}
