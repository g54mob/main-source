using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_JetBlackWhip1_Weapon : TP_WhipCore1_Weapon
	{
		[SerializeField]
		private Projectile _impactProjectile;

		protected BulletPool _impactPool;

		protected override void Awake()
		{
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public void FireImpactProjectiles(Vector2 pos)
		{
		}

		protected override void OnDestroy()
		{
		}

		public override void Cleanup()
		{
		}

		public override void CheckArcanas()
		{
		}

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}
	}
}
