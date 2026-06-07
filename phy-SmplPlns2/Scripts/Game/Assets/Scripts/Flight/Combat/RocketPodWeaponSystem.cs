using Assets.Scripts.Craft.Parts.Modifiers.Weapons;

namespace Assets.Scripts.Flight.Combat
{
	public class RocketPodWeaponSystem : WeaponSystem
	{
		private float _fireTime;

		private WeaponPart _lastFiredRocketPod;

		public override WeaponFunction WeaponFunction => WeaponFunction.AirToSurface;

		public RocketPodWeaponSystem(WeaponPart weaponPart)
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
				_lastFiredRocketPod = GetNextActiveWeapon(_lastFiredRocketPod);
				if (_lastFiredRocketPod != null)
				{
					_lastFiredRocketPod.Weapon.Fire(trackedTarget);
					WeaponPart nextActiveWeapon = GetNextActiveWeapon(_lastFiredRocketPod);
					if (nextActiveWeapon == null)
					{
						return _lastFiredRocketPod;
					}
					RocketPodScript modifier = nextActiveWeapon.Part.GetModifier<RocketPodScript>();
					if (modifier != null)
					{
						_fireTime = _time + modifier.FireDelay;
					}
					return _lastFiredRocketPod;
				}
			}
			return null;
		}
	}
}
