using CTS.BBT;
using CTS.Core;

namespace CTS
{
	public class TimeControllerLocker : CTSBehaviour
	{
		private readonly LockToggle _lockToggle = new LockToggle();

		private TimeController _controller;

		private void GetTimeController()
		{
			if (!_controller)
			{
				_lockToggle.Clear();
				_controller = MonoSingleton<TimeController>.Instance;
				if ((bool)_controller)
				{
					_lockToggle.Add(_controller);
				}
			}
		}

		public void Lock()
		{
			GetTimeController();
			_lockToggle.Lock();
		}

		public void Unlock()
		{
			GetTimeController();
			_lockToggle.Unlock();
		}
	}
}
