using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Flight.Combat
{
	public abstract class WeaponSystem
	{
		protected float _time;

		private List<WeaponPart> _weapons = new List<WeaponPart>();

		public int Ammo
		{
			get
			{
				int num = 0;
				foreach (WeaponPart weapon in _weapons)
				{
					if (weapon.IsActive)
					{
						num += weapon.Weapon.CurrentAmmo;
					}
				}
				return num;
			}
		}

		public virtual float MinRange => 0f;

		public bool ShowGunReticule { get; set; }

		public float TargetingAngle { get; protected set; }

		public TargetingSystem TargetingSystem { get; set; }

		public virtual Transform TargetingTransform => null;

		public abstract WeaponFunction WeaponFunction { get; }

		public string WeaponPartName { get; protected set; }

		public IEnumerable<WeaponPart> Weapons => _weapons;

		public WeaponSystem(WeaponPart weaponPart)
		{
			WeaponPartName = weaponPart.CustomName ?? weaponPart.Part.Part.PartType.Name;
		}

		public static WeaponSystem CreateWeaponSystem(WeaponPart weaponPart, TargetingSystem targetingSystem)
		{
			WeaponSystem weaponSystem = null;
			if (weaponPart.Weapon.Type == WeaponType.Bomb)
			{
				weaponSystem = new BombWeaponSystem(weaponPart);
			}
			else if (weaponPart.Weapon.Type == WeaponType.Missile)
			{
				if (!(weaponPart.Weapon is IMissile missile))
				{
					throw new NotImplementedException();
				}
				weaponSystem = new MissileWeaponSystem(weaponPart, missile);
			}
			else if (weaponPart.Weapon.Type == WeaponType.RocketPod)
			{
				weaponSystem = new RocketPodWeaponSystem(weaponPart);
			}
			else if (weaponPart.Weapon.Type == WeaponType.Rocket)
			{
				weaponSystem = new RocketWeaponSystem(weaponPart);
			}
			else if (weaponPart.Weapon.Type == WeaponType.Gun)
			{
				weaponSystem = new GunWeaponSystem(weaponPart);
			}
			else if (weaponPart.Weapon.Type == WeaponType.Cannon)
			{
				weaponSystem = new CannonWeaponSystem(weaponPart);
			}
			weaponSystem.TargetingSystem = targetingSystem;
			return weaponSystem;
		}

		public void AddWeapon(WeaponPart weaponPart)
		{
			for (int i = 0; i < _weapons.Count; i++)
			{
				if (weaponPart.Distance < _weapons[i].Distance)
				{
					_weapons.Insert(i, weaponPart);
					return;
				}
			}
			_weapons.Add(weaponPart);
		}

		public abstract bool CanFire(TrackedTarget trackedTarget);

		public abstract WeaponPart Fire(TrackedTarget trackedTarget);

		public virtual float GetSuitabilityForTarget(TrackedTarget trackedTarget)
		{
			return 0f;
		}

		public virtual void OnBeforeUpdateWeaponList()
		{
		}

		public virtual void OnDeselected()
		{
		}

		public virtual void OnSelected()
		{
		}

		public virtual void ProcessTarget(TrackedTarget trackedTarget, float deltaTime)
		{
		}

		public void ShowMessage(string message)
		{
			if (TargetingSystem != null && TargetingSystem.IsPlayerTargetingSystem)
			{
				FlightSceneScript.Instance.FlightUI.ShowLogMessage(message);
			}
		}

		public virtual void Update(float deltaTime)
		{
			_time += deltaTime;
		}

		protected WeaponPart GetFirstActiveWeapon(bool mustHaveAmmo = true)
		{
			foreach (WeaponPart weapon in _weapons)
			{
				if (weapon.IsActive && (weapon.Weapon.CurrentAmmo > 0 || !mustHaveAmmo))
				{
					return weapon;
				}
			}
			return null;
		}

		protected WeaponPart GetNextActiveWeapon(WeaponPart currentWeapon)
		{
			if (_weapons.Count > 0)
			{
				int num = 0;
				for (int i = 0; i < _weapons.Count; i++)
				{
					if (_weapons[i] == currentWeapon)
					{
						num = i;
						break;
					}
				}
				for (int j = 0; j < _weapons.Count; j++)
				{
					num++;
					if (num < 0)
					{
						num = _weapons.Count - 1;
					}
					else if (num >= _weapons.Count)
					{
						num = 0;
					}
					WeaponPart weaponPart = _weapons[num];
					if (weaponPart.IsActive && weaponPart.Weapon.CurrentAmmo > 0)
					{
						return weaponPart;
					}
				}
			}
			return null;
		}
	}
}
