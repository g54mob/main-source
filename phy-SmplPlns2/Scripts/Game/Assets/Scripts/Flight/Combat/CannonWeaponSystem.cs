using Assets.Scripts.Craft.Parts.Modifiers.Weapons;

namespace Assets.Scripts.Flight.Combat
{
	public class CannonWeaponSystem : WeaponSystem
	{
		private float _fireTime;

		private WeaponPart _lastFiredCannon;

		private CannonScript _lastFiredCannonScript;

		private WeaponFunction _mode = WeaponFunction.AirToSurface;

		public override WeaponFunction WeaponFunction => _mode;

		public WeaponPart NextToFire => GetNextActiveWeapon(_lastFiredCannon);

		public CannonWeaponSystem(WeaponPart weaponPart)
			: base(weaponPart)
		{
			_mode = weaponPart.Weapon.Function;
		}

		public override bool CanFire(TrackedTarget trackedTarget)
		{
			bool flag = base.Ammo > 0;
			if (_lastFiredCannonScript != null)
			{
				flag = flag && _lastFiredCannonScript.CanFire;
			}
			return flag;
		}

		public override WeaponPart Fire(TrackedTarget trackedTarget)
		{
			if (_time >= _fireTime)
			{
				_lastFiredCannon = GetNextActiveWeapon(_lastFiredCannon);
				if (_lastFiredCannon != null)
				{
					_lastFiredCannon.Weapon.Fire(trackedTarget);
					WeaponPart nextActiveWeapon = GetNextActiveWeapon(_lastFiredCannon);
					if (nextActiveWeapon == null)
					{
						return _lastFiredCannon;
					}
					CannonScript modifier = nextActiveWeapon.Part.GetModifier<CannonScript>();
					if (modifier != null)
					{
						_lastFiredCannonScript = modifier;
						_fireTime = _time + modifier.FiringDelay;
					}
					return _lastFiredCannon;
				}
			}
			return null;
		}
	}
}
