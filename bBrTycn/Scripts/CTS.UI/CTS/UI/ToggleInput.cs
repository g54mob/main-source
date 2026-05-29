using System;
using CTS.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CTS.UI
{
	public class ToggleInput : CTSBehaviour
	{
		public class Lock : ILockable
		{
			public CTS.Core.Lock ObjectLock { get; set; }

			public Action<bool> LockStateChanged { get; set; }

			public bool IsLocked => ObjectLock.IsLocked();

			public bool IsUnlocked => ObjectLock.IsUnlocked();

			void ILockable.OnLocked()
			{
			}

			void ILockable.OnUnlocked()
			{
			}
		}

		[SerializeField]
		[Inject(false)]
		private CTSToggle _toggle;

		[SerializeField]
		private InputActionReference _input;

		[SerializeField]
		private CanvasGroupController _canvasLock;

		public static Lock ObjectLock { get; } = new Lock();

		protected override void OnEnabled()
		{
			base.OnEnabled();
			if ((bool)_input && _input.action != null)
			{
				_input.action.performed += OnInput;
			}
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			if ((bool)_input && _input.action != null)
			{
				_input.action.performed -= OnInput;
			}
		}

		private void OnInput(InputAction.CallbackContext context)
		{
			if (!UIUtility.InInputField() && !_toggle.ObjectLock.IsLocked() && !ObjectLock.IsLocked)
			{
				CanvasGroupController canvasLock = _canvasLock;
				if (!canvasLock || !canvasLock.ObjectLock.IsLocked())
				{
					_toggle.isOn = !_toggle.isOn;
				}
			}
		}
	}
}
