using System;
using CTS.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CTS.UI
{
	public class ToggleOpenCanvas : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private CTSToggle _toggle;

		[SerializeField]
		private StringKey _canvasToOpen;

		[SerializeField]
		private InputActionReference _input;

		[Inject(false)]
		private CanvasGroupController _selfCanvas;

		private LockToggle _buttonLocker = new LockToggle();

		private CanvasGroupController _actualCanvas;

		public CanvasGroupController Canvas
		{
			get
			{
				if (_actualCanvas != null)
				{
					return _actualCanvas;
				}
				if (MonoSingleton<CanvasGroupManager>.Instance.TryGet(_canvasToOpen, out var controller))
				{
					_actualCanvas = controller;
					return controller;
				}
				_actualCanvas = controller;
				return null;
			}
		}

		protected override void OnAwake()
		{
			base.OnAwake();
			_buttonLocker.Add(_toggle);
			if ((bool)_input && _input.action != null)
			{
				_input.action.performed += OnInput;
			}
		}

		private void Start()
		{
			UnregisterCanvas(Canvas);
			RegisterCanvas(Canvas);
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_toggle.onValueChanged.AddListener(OnToggleChanged);
			CTSToggle toggle = _toggle;
			toggle.LockStateChanged = (Action<bool>)Delegate.Combine(toggle.LockStateChanged, new Action<bool>(OnButtonLocked));
			RegisterCanvas(Canvas);
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_toggle.onValueChanged.RemoveListener(OnToggleChanged);
			CTSToggle toggle = _toggle;
			toggle.LockStateChanged = (Action<bool>)Delegate.Remove(toggle.LockStateChanged, new Action<bool>(OnButtonLocked));
			UnregisterCanvas(Canvas);
		}

		private void OnDestroy()
		{
			if ((bool)_input && _input.action != null)
			{
				_input.action.performed -= OnInput;
			}
		}

		private void OnInput(InputAction.CallbackContext context)
		{
			if (!UIUtility.InInputField() && !_toggle.ObjectLock.IsLocked() && (!_selfCanvas || !_selfCanvas.ObjectLock.IsLocked()) && !ToggleInput.ObjectLock.IsLocked)
			{
				CanvasGroupController canvas = Canvas;
				if (!canvas || !canvas.ObjectLock.IsLocked())
				{
					_toggle.isOn = !_toggle.isOn;
				}
			}
		}

		private void RegisterCanvas(CanvasGroupController canvas)
		{
			if ((object)canvas != null)
			{
				canvas.LockStateChanged = (Action<bool>)Delegate.Combine(canvas.LockStateChanged, new Action<bool>(OnCanvasLockStateChanged));
				canvas.CanvasShowning += OnCanvasShowingChanged;
				CanvasGroupController.CanvasGroupState state = canvas.State;
				OnCanvasShowingChanged(state == CanvasGroupController.CanvasGroupState.Showing || state == CanvasGroupController.CanvasGroupState.Shown);
				OnCanvasLockStateChanged(!canvas.ObjectLock.IsLocked());
			}
		}

		private void UnregisterCanvas(CanvasGroupController canvas)
		{
			if ((object)canvas != null)
			{
				canvas.LockStateChanged = (Action<bool>)Delegate.Remove(canvas.LockStateChanged, new Action<bool>(OnCanvasLockStateChanged));
				canvas.CanvasShowning -= OnCanvasShowingChanged;
				OnCanvasLockStateChanged(isUnlocked: true);
			}
		}

		private void OnButtonLocked(bool isUnlocked)
		{
			CanvasGroupController canvas = Canvas;
			if ((object)canvas != null && !isUnlocked)
			{
				canvas.QuickHide();
			}
		}

		private void OnCanvasLockStateChanged(bool isUnlocked)
		{
			if (isUnlocked)
			{
				_buttonLocker.Unlock();
				return;
			}
			_buttonLocker.Lock();
			Canvas?.QuickHide();
		}

		private void OnCanvasShowingChanged(bool showing)
		{
			if (showing)
			{
				if (!_toggle.isOn)
				{
					_toggle.isOn = true;
				}
			}
			else if (_toggle.isOn)
			{
				_toggle.isOn = false;
			}
		}

		private void OnToggleChanged(bool isOn)
		{
			CanvasGroupController canvas = Canvas;
			if ((object)canvas != null)
			{
				if (isOn)
				{
					canvas.QuickShow();
				}
				else
				{
					canvas.QuickHide();
				}
			}
		}
	}
}
