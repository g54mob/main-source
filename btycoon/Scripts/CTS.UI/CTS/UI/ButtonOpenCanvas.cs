using System;
using CTS.Core;
using UnityEngine;

namespace CTS.UI
{
	public class ButtonOpenCanvas : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private CTSButton _button;

		[SerializeField]
		private StringKey _canvasToOpen;

		private LockToggle _buttonLocker = new LockToggle();

		private CanvasGroupController _canvas;

		public CanvasGroupController Canvas
		{
			get
			{
				if (_canvas != null)
				{
					return _canvas;
				}
				if (!MonoSingleton<CanvasGroupManager>.Instance.TryGet(_canvasToOpen, out var controller))
				{
					_canvas = null;
					return null;
				}
				_canvas = controller;
				return _canvas;
			}
		}

		protected override void OnAwake()
		{
			base.OnAwake();
			_buttonLocker.Add(_button);
		}

		private void Start()
		{
			UnregisterCanvas(Canvas);
			RegisterCanvas(Canvas);
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_button.onClick.AddListener(OnButtonClick);
			CTSButton button = _button;
			button.LockStateChanged = (Action<bool>)Delegate.Combine(button.LockStateChanged, new Action<bool>(OnButtonLocked));
			RegisterCanvas(Canvas);
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_button.onClick.RemoveListener(OnButtonClick);
			CTSButton button = _button;
			button.LockStateChanged = (Action<bool>)Delegate.Remove(button.LockStateChanged, new Action<bool>(OnButtonLocked));
			UnregisterCanvas(Canvas);
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

		private void RegisterCanvas(CanvasGroupController canvas)
		{
			if ((object)canvas != null)
			{
				canvas.LockStateChanged = (Action<bool>)Delegate.Combine(canvas.LockStateChanged, new Action<bool>(OnCanvasLockStateChanged));
				OnCanvasLockStateChanged(!canvas.ObjectLock.IsLocked());
			}
		}

		private void UnregisterCanvas(CanvasGroupController canvas)
		{
			if ((object)canvas != null)
			{
				canvas.LockStateChanged = (Action<bool>)Delegate.Remove(canvas.LockStateChanged, new Action<bool>(OnCanvasLockStateChanged));
				OnCanvasLockStateChanged(isUnlocked: true);
			}
		}

		private void OnButtonClick()
		{
			if (!_canvasToOpen.IsValid())
			{
				throw new Exception("Canvas key is invalid");
			}
			CanvasGroupController canvas = Canvas;
			if ((object)canvas != null)
			{
				if (canvas.IsShown)
				{
					canvas.QuickHide();
				}
				else
				{
					canvas.QuickShow();
				}
			}
		}
	}
}
