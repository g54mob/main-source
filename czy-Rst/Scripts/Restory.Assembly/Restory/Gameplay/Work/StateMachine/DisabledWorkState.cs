using System;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Zenject;

namespace Restory.Gameplay.Work.StateMachine
{
	public class DisabledWorkState : IState, IExitableState, IDisposable
	{
		public class Factory : PlaceholderFactory<DisabledWorkState>
		{
		}

		[Inject]
		public DisabledWorkState()
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
