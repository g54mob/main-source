using System;

namespace Restory.Infrastructure.StateMachine.States.Interfaces
{
	public interface IPayloadedState<TPayload> : IExitableState, IDisposable
	{
		void Enter(TPayload payload);
	}
}
