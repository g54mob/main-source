using System;
using Assets.Scripts.Craft;

namespace Assets.Scripts.Flight.Combat.Events
{
	public class WeaponFiredEventArgs : EventArgs
	{
		public ITarget CurrentTarget { get; private set; }

		public AircraftScript FiredBy { get; private set; }

		public WeaponFiredEventArgs(AircraftScript firedBy, ITarget currentTarget)
		{
			FiredBy = firedBy;
			CurrentTarget = currentTarget;
		}
	}
}
