using System;

namespace NSMedieval
{
	public class EventContainer
	{
		public event Action Event;

		public void InvokeEvent()
		{
			this.Event?.Invoke();
		}

		public void ClearEvent()
		{
			this.Event = null;
		}
	}
}
