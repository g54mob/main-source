using System.Collections.Generic;
using Assets.Scripts.Craft.Parts.Modifiers.Weapons;
using UnityEngine;

namespace Assets.Scripts.Flight.Combat
{
	public class GunWeaponSystem : WeaponSystem
	{
		public override WeaponFunction WeaponFunction => WeaponFunction.None;

		public GunWeaponSystem(WeaponPart weaponPart)
			: base(weaponPart)
		{
			base.WeaponPartName = "Guns";
		}

		public override bool CanFire(TrackedTarget trackedTarget)
		{
			return GetFirstActiveWeapon(mustHaveAmmo: false) != null;
		}

		public override WeaponPart Fire(TrackedTarget trackedTarget)
		{
			return null;
		}

		public void RecalculateFireDelays()
		{
			List<GunScript> list = new List<GunScript>();
			float num = float.MaxValue;
			foreach (WeaponPart weapon in base.Weapons)
			{
				if (weapon.IsActive)
				{
					GunScript gunScript = weapon.Weapon as GunScript;
					if (gunScript != null && gunScript.AdjustFireDelay)
					{
						num = Mathf.Min(gunScript.Gun.MinTimeBetweenRounds, num);
						list.Add(gunScript);
					}
				}
			}
			if (list.Count <= 0)
			{
				return;
			}
			float num2 = num / (float)list.Count;
			float num3 = 0f;
			foreach (GunScript item in list)
			{
				item.FireDelay = num3;
				num3 += num2;
			}
		}
	}
}
