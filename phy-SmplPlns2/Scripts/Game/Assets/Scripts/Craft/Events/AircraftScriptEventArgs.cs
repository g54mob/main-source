using System;

namespace Assets.Scripts.Craft.Events
{
	public class AircraftScriptEventArgs : EventArgs
	{
		public AircraftScript Craft { get; }

		public AircraftScriptEventArgs(AircraftScript craft)
		{
			Craft = craft;
		}
	}
}
