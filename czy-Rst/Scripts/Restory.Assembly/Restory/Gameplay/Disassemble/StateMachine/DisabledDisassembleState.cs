using System;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Zenject;

namespace Restory.Gameplay.Disassemble.StateMachine
{
	public class DisabledDisassembleState : IState, IExitableState, IDisposable
	{
		public class Factory : PlaceholderFactory<DisabledDisassembleState>
		{
		}

		[Inject]
		public DisabledDisassembleState()
		{
		}

		public void Enter()
		{
		}

		public void Exit()
		{
		}

		public void Dispose()
		{
		}
	}
}
