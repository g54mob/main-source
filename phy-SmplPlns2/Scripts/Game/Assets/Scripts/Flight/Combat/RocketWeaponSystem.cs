using Assets.Scripts.Craft.Parts.Modifiers.Weapons;

namespace Assets.Scripts.Flight.Combat
{
	public class RocketWeaponSystem : WeaponSystem
	{
		private float _fireTime;

		private WeaponPart _lastFiredRocket;

		public override WeaponFunction WeaponFunction => WeaponFunction.AirToSurface;

		public RocketWeaponSystem(WeaponPart weaponPart)
			: base(weaponPart)
		{
			base.ShowGunReticule = true;
		}

		public override bool CanFire(TrackedTarget trackedTarget)
		{
			return base.Ammo > 0;
		}

		public override WeaponPart Fire(TrackedTarget trackedTarget)
		{
			if (_time >= _fireTime)
			{
				_lastFiredRocket = GetNextActiveWeapon(_lastFiredRocket);
				if (_lastFiredRocket != null)
				{
					_lastFiredRocket.Weapon.Fire(trackedTarget);
					WeaponPart nextActiveWeapon = GetNextActiveWeapon(_lastFiredRocket);
					if (nextActiveWeapon == null)
					{
						return _lastFiredRocket;
					}
					RocketWeaponScript modifier = nextActiveWeapon.Part.GetModifier<RocketWeaponScript>();
					if (modifier != null)
					{
						_fireTime = _time + modifier.FireDelay;
					}
					return _lastFiredRocket;
				}
			}
			return null;
		}
	}
}
