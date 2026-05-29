using System;
using CTS.Core;
using UnityEngine;
using UnityEngine.UI;

namespace CTS.UI
{
	public class ImageLocker : CTSBehaviour, ILockable
	{
		[SerializeField]
		[Inject(false)]
		private Image _image;

		[SerializeField]
		private bool _invert;

		public Lock ObjectLock { get; set; }

		public Action<bool> LockStateChanged { get; set; }

		private void Start()
		{
			_image.enabled = (_invert ? ObjectLock.IsLocked() : ObjectLock.IsUnlocked());
		}

		void ILockable.OnLocked()
		{
			_image.enabled = _invert;
		}

		void ILockable.OnUnlocked()
		{
			_image.enabled = !_invert;
		}
	}
}
