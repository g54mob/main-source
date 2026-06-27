using System;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using Zenject;

namespace Restory.Gameplay.Work.StateMachine
{
	public class HackingWorkState : IState, IExitableState, IDisposable
	{
		public class Factory : PlaceholderFactory<HackingWorkState>
		{
		}

		[Inject]
		public HackingWorkState()
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
