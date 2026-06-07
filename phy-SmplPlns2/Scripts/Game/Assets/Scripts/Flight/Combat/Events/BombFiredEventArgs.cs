using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts.Modifiers.Weapons;

namespace Assets.Scripts.Flight.Combat.Events
{
	public class BombFiredEventArgs : WeaponFiredEventArgs
	{
		public BombScript Bomb { get; private set; }

		public BombFiredEventArgs(AircraftScript firedBy, ITarget currentTarget, BombScript bomb)
			: base(firedBy, currentTarget)
		{
			Bomb = bomb;
		}
	}
}
