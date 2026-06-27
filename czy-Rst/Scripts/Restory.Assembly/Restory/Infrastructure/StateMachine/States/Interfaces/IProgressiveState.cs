using System;

namespace Restory.Infrastructure.StateMachine.States.Interfaces
{
	internal interface IProgressiveState : IExitableState, IDisposable
	{
		float Progress { get; }

		event Action OnProgressChanged;
	}
}
