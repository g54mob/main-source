using CTS.Core;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class UIPanicImageLocker : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private ImageLocker _locker;

		private readonly LockToggle _lockToggle = new LockToggle();

		protected override void OnAwake()
		{
			base.OnAwake();
			_lockToggle.Add(_locker);
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			PanicCounter.PanicActive += OnPanicChanged;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			PanicCounter.PanicActive -= OnPanicChanged;
		}

		private void OnPanicChanged(bool active)
		{
			_lockToggle.SetLock(active);
		}
	}
}
