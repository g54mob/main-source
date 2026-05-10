using System;
using CTS.Core;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class LockButtonWithSaveAvailability : CTSBehaviour
	{
		[SerializeField]
		private bool _invert;

		[SerializeField]
		[Inject(false)]
		private ISelectable _selectable;

		private readonly LockToggle _lock = new LockToggle();

		private void Start()
		{
			_lock.Add(_selectable);
			ProfileManager instance = CTSSingleton<ProfileManager>.Instance;
			instance.LockStateChanged = (Action<bool>)Delegate.Combine(instance.LockStateChanged, new Action<bool>(OnSaveLockChanged));
			OnSaveLockChanged(CTSSingleton<ProfileManager>.Instance.ObjectLock.IsUnlocked());
		}

		private void OnDestroy()
		{
			if (CTSSingleton<ProfileManager>.InstanceExists())
			{
				ProfileManager instance = CTSSingleton<ProfileManager>.Instance;
				instance.LockStateChanged = (Action<bool>)Delegate.Remove(instance.LockStateChanged, new Action<bool>(OnSaveLockChanged));
			}
		}

		private void OnSaveLockChanged(bool isUnlocked)
		{
			if (isUnlocked)
			{
				_lock.SetLock(_invert);
			}
			else
			{
				_lock.SetLock(!_invert);
			}
		}
	}
}
