using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	public class LockUIWithUnlockKey : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private SoftReference<ILockable> _lockable;

		[SerializeField]
		private EUnlockKey _key;

		private LockToggle _lock = new LockToggle();

		protected override void OnAwake()
		{
			base.OnAwake();
			_lock.Add(_lockable.Value);
		}

		private void Start()
		{
			Recalculate();
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			UnlockingManager.OnNewKeyAdded += OnNewKeyAdded;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			UnlockingManager.OnNewKeyAdded -= OnNewKeyAdded;
		}

		private void OnNewKeyAdded(EUnlockKey obj)
		{
			Recalculate();
		}

		private void Recalculate()
		{
			if (UnlockingManager.UnlockKey.HasFlagNonAlloc(_key))
			{
				_lock.Unlock();
			}
			else
			{
				_lock.Lock();
			}
		}
	}
}
