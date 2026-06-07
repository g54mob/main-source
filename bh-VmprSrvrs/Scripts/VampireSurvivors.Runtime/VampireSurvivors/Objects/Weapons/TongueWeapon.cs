using System.Collections.Generic;
using Unity.Mathematics;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class TongueWeapon : Weapon
	{
		public float distanceMultiplier;

		private float _baseRange;

		protected Weapon _counterWeapon;

		private bool _readyToFire;

		private List<EnemyController> aimCache;

		public virtual float forwardFacing => 0f;

		protected virtual WeaponType _counterWeaponType => default(WeaponType);

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		public override float PPower()
		{
			return 0f;
		}

		protected virtual bool CanLickBackwards()
		{
			return false;
		}

		private List<EnemyController> ChooseEnemiesInRange(float2 position, float radius, bool facingLeft)
		{
			return null;
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void TryFiring()
		{
		}

		protected virtual bool SupportCounterWeapon()
		{
			return false;
		}

		public override void CheckArcanas()
		{
		}

		public override bool LevelUp()
		{
			return false;
		}

		public override void SetVisible(bool visible)
		{
		}
	}
}
