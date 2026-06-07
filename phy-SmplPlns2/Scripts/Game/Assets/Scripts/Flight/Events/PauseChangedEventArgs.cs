using System;

namespace Assets.Scripts.Flight.Events
{
	public class PauseChangedEventArgs : EventArgs
	{
		public bool IsPaused { get; private set; }

		public bool IsUserInitiated { get; private set; }

		public PauseChangedEventArgs(bool isPaused, bool isUserInitiated)
		{
			IsPaused = isPaused;
			IsUserInitiated = isUserInitiated;
		}
	}
}
