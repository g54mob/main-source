using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts.Modifiers.Weapons;

namespace Assets.Scripts.Flight.Combat.Events
{
	public class MissileFiredEventArgs : WeaponFiredEventArgs
	{
		public MissileScript Missile { get; private set; }

		public MissileFiredEventArgs(AircraftScript firedBy, ITarget currentTarget, MissileScript missile)
			: base(firedBy, currentTarget)
		{
			Missile = missile;
		}
	}
}
