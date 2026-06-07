using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Vehicles.Land.Convoy
{
	public class ConvoyNavigationTargetReachedEventArgs : ConvoyVehicleEventArgs
	{
		public Transform Target { get; private set; }

		public ConvoyNavigationTargetReachedEventArgs(SimpleGroundVehicleScript vehicle, Transform target)
			: base(vehicle)
		{
			Target = target;
		}
	}
}
