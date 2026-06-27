using System;

namespace Restory.Infrastructure.StateMachine.States.Interfaces
{
	public interface IState : IExitableState, IDisposable
	{
		void Enter();
	}
}
