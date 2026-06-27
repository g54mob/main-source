using System;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.StateMachine.States
{
	public class GameLoopState : IState, IExitableState, IDisposable
	{
		public class Factory : PlaceholderFactory<GameLoopState>
		{
		}

		public void Dispose()
		{
		}

		public void Enter()
		{
			Debug.Log("GameLoopState Enter state");
		}

		public void Exit()
		{
			Debug.Log("GameLoopState Exit state");
		}
	}
}
