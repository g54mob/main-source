using CTS.Core;
using CTS.UI;

namespace CTS
{
	public class PanicButtonLocker : CTSBehaviour
	{
		[Inject(false)]
		private ISelectable _selectable;

		private LockToggle _toggle = new LockToggle();

		protected override void OnAwake()
		{
			base.OnAwake();
			_toggle.Add(_selectable);
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			if (PanicCounter.IsPanicActive)
			{
				_toggle.Lock();
			}
			PanicCounter.PanicActive += OnPanicModeChanged;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			PanicCounter.PanicActive -= OnPanicModeChanged;
			_toggle.Unlock();
		}

		private void OnPanicModeChanged(bool isActive)
		{
			_toggle.SetLock(isActive);
		}
	}
}
