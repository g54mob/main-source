using System;

namespace GameCreator.Runtime.Common
{
	public interface IStateMachine
	{
		event Action<IStateMachine, IState> EventStateEnter;

		event Action<IStateMachine, IState> EventStateExit;
	}
}
