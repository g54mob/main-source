using Assets.Scripts.Craft.Parts.Modifiers.Weapons;

namespace Assets.Scripts.Flight.Combat
{
	public class BombWeaponSystem : WeaponSystem
	{
		private float _fireTime;

		public override WeaponFunction WeaponFunction => WeaponFunction.AirToSurface;

		public BombWeaponSystem(WeaponPart weaponPart)
			: base(weaponPart)
		{
		}

		public override bool CanFire(TrackedTarget trackedTarget)
		{
			return base.Ammo > 0;
		}

		public override WeaponPart Fire(TrackedTarget trackedTarget)
		{
			if (_time >= _fireTime)
			{
				WeaponPart firstActiveWeapon = GetFirstActiveWeapon();
				if (firstActiveWeapon != null)
				{
					firstActiveWeapon.Weapon.Fire(trackedTarget);
					if (GetNextActiveWeapon(firstActiveWeapon) == null)
					{
						return firstActiveWeapon;
					}
					BombScript modifier = firstActiveWeapon.Part.GetModifier<BombScript>();
					if (modifier != null)
					{
						_fireTime = _time + modifier.FireDelay;
					}
					return firstActiveWeapon;
				}
			}
			return null;
		}
	}
}
