using System;
using Restory.Infrastructure.StateMachine.States.Interfaces;
using UnityEngine;

namespace Restory.Infrastructure.StateMachine.States.Base
{
	public abstract class InitializationStateBase : IProgressiveState, IExitableState, IDisposable, IStateMachineUser
	{
		protected GlobalStateMachine GameStateMachine;

		protected float progress;

		public float Progress
		{
			get
			{
				return progress;
			}
			set
			{
				progress = Mathf.Clamp01(value);
				this.OnProgressChanged?.Invoke();
			}
		}

		public event Action OnProgressChanged;

		public virtual void Dispose()
		{
			GameStateMachine = null;
		}

		public abstract void Exit();

		public void SetGameStateMachine(GlobalStateMachine stateMachine)
		{
			GameStateMachine = stateMachine;
		}

		protected void LogDebug(string message)
		{
			Debug.Log("[" + GetType().Name + "] " + message);
		}

		public virtual void ResetProgress()
		{
			progress = 0f;
		}
	}
}
