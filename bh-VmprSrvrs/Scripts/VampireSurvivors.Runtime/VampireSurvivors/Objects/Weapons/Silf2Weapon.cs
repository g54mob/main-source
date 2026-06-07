using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class Silf2Weapon : SilfWeapon
	{
		protected override float OffsetX()
		{
			return 0f;
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		protected override void UpdateTargetZonePos(SpriteRenderer targetZone, float angle)
		{
		}

		protected override void UpdateDamageZonePos(Circle damageZone, float angle)
		{
		}
	}
}
