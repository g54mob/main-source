using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_AlucardSpear2_Weapon : TP_AlucardSpear1_Weapon
	{
		[SerializeField]
		private Projectile _aeroSlicePrefab;

		private BulletPool _aeroSlicePool;

		protected int _fireCounter;

		protected int _specialCounter;

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}

		protected override void OnStart()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public virtual void OnSpecialCounter(bool skipTriggers = false)
		{
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		protected override void OnDestroy()
		{
		}

		public override void Cleanup()
		{
		}
	}
}
