using System;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class PathLocker : CTSBehaviour
	{
		private bool _locked;

		private PathLockable _parent;

		public bool IsPathable => !_locked;

		public static event Action<PathLocker> ObjectBecameUnpathable;

		protected override void OnAwake()
		{
			base.OnAwake();
			SetParent(base.transform.parent.GetComponentInParent<PathLockable>(includeInactive: true));
		}

		public void SetUnpathable()
		{
			if (!_locked)
			{
				_locked = true;
				Debug.DrawRay(base.transform.position, Vector3.up, Color.magenta, 5f);
				RecalculateParent();
				PathLocker.ObjectBecameUnpathable?.Invoke(this);
			}
		}

		public void SetPathable()
		{
			if (_locked)
			{
				_locked = false;
				RecalculateParent();
			}
		}

		public void RecalculateParent()
		{
			if ((bool)_parent)
			{
				_parent.RecalculateLock();
			}
		}

		private void SetParent(PathLockable parent)
		{
			if (!(_parent == parent))
			{
				if ((bool)_parent)
				{
					_parent.RemoveLocker(this);
				}
				_parent = parent;
				if ((bool)_parent)
				{
					_parent.AddLocker(this);
				}
			}
		}
	}
}
