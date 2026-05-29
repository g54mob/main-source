using System;
using UnityEngine.InputSystem;

namespace CTS.Core
{
	public abstract class InputProxy : CTSBehaviour
	{
		public event Action<InputAction.CallbackContext> Started;

		public event Action<InputAction.CallbackContext> Completed;

		public event Action<InputAction.CallbackContext> Cancelled;

		protected void SendStartedEvent(InputAction.CallbackContext ctx)
		{
			this.Started?.Invoke(ctx);
		}

		protected void SendCompletedEvent(InputAction.CallbackContext ctx)
		{
			this.Completed?.Invoke(ctx);
		}

		protected void SendCancelledEvent(InputAction.CallbackContext ctx)
		{
			this.Cancelled?.Invoke(ctx);
		}

		public abstract bool IsInProgress();
	}
}
