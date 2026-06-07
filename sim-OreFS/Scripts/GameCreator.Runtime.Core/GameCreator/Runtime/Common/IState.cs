using System;

namespace GameCreator.Runtime.Common
{
	public interface IState
	{
		event Action<IStateMachine, IState> EventOnEnter;

		event Action<IStateMachine, IState> EventOnExit;

		void OnEnter(IStateMachine stateMachine);

		void OnExit(IStateMachine stateMachine);

		void OnUpdate(IStateMachine stateMachine);
	}
}
