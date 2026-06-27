using System;

namespace Restory.Infrastructure.StateMachine.States.Interfaces
{
	public interface IExitableState : IDisposable
	{
		void Exit();
	}
}
