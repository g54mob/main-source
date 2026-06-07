using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts.Modifiers.Weapons;

namespace Assets.Scripts.Flight.Combat.Events
{
	public class RocketFiredEventArgs : WeaponFiredEventArgs
	{
		public RocketScript Rocket { get; private set; }

		public RocketFiredEventArgs(AircraftScript firedBy, ITarget currentTarget, RocketScript rocket)
			: base(firedBy, currentTarget)
		{
			Rocket = rocket;
		}
	}
}
