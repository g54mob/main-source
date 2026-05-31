using System;
using CTS.Core;
using UnityEngine;
using UnityEngine.Events;

namespace CTS.UI
{
	public class ToggleLockedEvent : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private CTSToggle _toggle;

		[SerializeField]
		private UnityEvent _lockedWhenOn;

		[SerializeField]
		private UnityEvent _lockedWhenOff;

		[SerializeField]
		private UnityEvent _unlockedWhenOn;

		[SerializeField]
		private UnityEvent _unlockedWhenOff;

		protected override void OnAwake()
		{
			base.OnAwake();
			CTSToggle toggle = _toggle;
			toggle.LockStateChanged = (Action<bool>)Delegate.Combine(toggle.LockStateChanged, new Action<bool>(OnLockChanged));
			if (_toggle.ObjectLock.IsLocked())
			{
				OnLockChanged(isUnlocked: false);
			}
		}

		private void OnDestroy()
		{
			CTSToggle toggle = _toggle;
			toggle.LockStateChanged = (Action<bool>)Delegate.Remove(toggle.LockStateChanged, new Action<bool>(OnLockChanged));
		}

		private void OnLockChanged(bool isUnlocked)
		{
			if (isUnlocked)
			{
				if (_toggle.isOn)
				{
					_unlockedWhenOn.Invoke();
				}
				else
				{
					_unlockedWhenOff.Invoke();
				}
			}
			else if (_toggle.isOn)
			{
				_lockedWhenOn.Invoke();
			}
			else
			{
				_lockedWhenOff.Invoke();
			}
		}
	}
}
