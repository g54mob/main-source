using System;

namespace Ookii.Dialogs
{
	public class TimerEventArgs : EventArgs
	{
		private int _tickCount;

		private bool _resetTickCount;

		public bool ResetTickCount
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int TickCount => 0;

		public TimerEventArgs(int tickCount)
		{
		}
	}
}
