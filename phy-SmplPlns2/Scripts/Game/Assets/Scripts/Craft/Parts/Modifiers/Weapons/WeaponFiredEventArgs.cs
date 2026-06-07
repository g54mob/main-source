using System;
using Assets.Scripts.Flight.Combat;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons
{
	public class WeaponFiredEventArgs : EventArgs
	{
		public TrackedTarget Target { get; }

		public IWeapon Weapon { get; set; }

		public WeaponFiredEventArgs(IWeapon weapon, TrackedTarget target)
		{
			Weapon = weapon;
			Target = target;
		}
	}
}
