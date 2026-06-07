using System;

namespace Assets.Scripts.Flight.Events
{
	public class AircraftViewChangedEventArgs : EventArgs
	{
		public string ViewName { get; private set; }

		public AircraftViewChangedEventArgs(string viewName)
		{
			ViewName = viewName;
		}
	}
}
