using CTS.Core;
using CTS.UI;

namespace CTS
{
	public class ConstructionSystemSelectableLocker : ConstructionSystemStatusUpdate
	{
		[Inject(false)]
		private ISelectable _timeButton;

		private LockToggle _lock;

		protected override void OnAwake()
		{
			_lock = new LockToggle(_timeButton);
			base.OnAwake();
		}

		protected override void OnConstructionOpened()
		{
			_lock.Lock();
		}

		protected override void OnConstructionClosed()
		{
			_lock.Unlock();
		}
	}
}
