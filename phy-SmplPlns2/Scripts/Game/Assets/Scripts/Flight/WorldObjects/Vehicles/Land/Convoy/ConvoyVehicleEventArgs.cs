using System;

namespace Assets.Scripts.Flight.WorldObjects.Vehicles.Land.Convoy
{
	public class ConvoyVehicleEventArgs : EventArgs
	{
		public SimpleGroundVehicleScript Vehicle { get; private set; }

		public ConvoyVehicleEventArgs(SimpleGroundVehicleScript vehicle)
		{
			Vehicle = vehicle;
		}
	}
}
