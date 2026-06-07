using System;
using CTS.Core;
using UnityEngine.InputSystem;

namespace CTS
{
	public class InputProxy : ILockable
	{
		public delegate void Down(InputAction.CallbackContext ctx);

		public delegate void Hold(InputAction.CallbackContext ctx);

		public delegate void Up(InputAction.CallbackContext ctx);

		private readonly InputAction _action;

		public Lock ObjectLock { get; set; }

		public Action<bool> LockStateChanged { get; set; }

		public bool Enabled => _action.enabled;

		public event Down onDown;

		public event Hold onComplete;

		public event Up onUp;

		public InputProxy(InputAction ac)
		{
			_action = ac;
		}

		public void Invoke(InputAction.CallbackContext ctx)
		{
			if (ctx.canceled)
			{
				this.onUp?.Invoke(ctx);
				return;
			}
			if (ctx.started)
			{
				this.onDown?.Invoke(ctx);
			}
			if (ctx.performed)
			{
				this.onComplete?.Invoke(ctx);
			}
		}

		public bool InProgress()
		{
			return _action.inProgress;
		}

		public bool IsPressed()
		{
			return _action.IsPressed();
		}

		void ILockable.OnLocked()
		{
			_action.Disable();
		}

		void ILockable.OnUnlocked()
		{
			_action.Enable();
		}
	}
}
