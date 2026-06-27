using System;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.StateMachine
{
	public class GlobalStateMachineTimeLogger : IInitializable, IDisposable
	{
		private readonly GlobalStateMachine globalStateMachine;

		private IExitableState activeState;

		private float activeStateEnterTime;

		private float activeStateExitTime;

		[Inject]
		public GlobalStateMachineTimeLogger(GlobalStateMachine globalStateMachine)
		{
			this.globalStateMachine = globalStateMachine;
		}

		public void Initialize()
		{
			globalStateMachine.OnStateEntered += ResolveOnStateEntered;
			globalStateMachine.OnStateExited += ResolveOnStateExited;
			ResolveOnStateEntered();
		}

		public void Dispose()
		{
			globalStateMachine.OnStateEntered -= ResolveOnStateEntered;
			globalStateMachine.OnStateExited -= ResolveOnStateExited;
			activeState = null;
		}

		private void ResolveOnStateEntered()
		{
			activeState = globalStateMachine.ActiveState;
			activeStateEnterTime = Time.unscaledTime;
		}

		private void ResolveOnStateExited()
		{
			if (activeState != null && activeState == globalStateMachine.ActiveState)
			{
				activeStateExitTime = Time.unscaledTime;
				float num = activeStateExitTime - activeStateEnterTime;
				Debug.Log("[GlobalStateMachineTimeLogger] State " + activeState.GetType().Name + $" execution time: {num} sec");
			}
		}
	}
}
