using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class Silf3Weapon : SilfWeapon
	{
		[SerializeField]
		private SpriteRenderer _TargetZone2;

		protected Circle _damageZone2;

		protected WeaponType _counterWeaponType1;

		protected WeaponType _counterWeaponType2;

		protected Weapon _counterWeapon1;

		protected Weapon _counterWeapon2;

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void CheckArcanas()
		{
		}

		public override bool LevelUp()
		{
			return false;
		}

		public override bool ApplyLimitBreak(WeightedLimitBreak weightedLimitBreak)
		{
			return false;
		}

		public override void SetVisible(bool visible)
		{
		}

		protected override void AddTargets()
		{
		}

		protected override void BlockFire()
		{
		}

		protected override void UnblockFire()
		{
		}
	}
}
