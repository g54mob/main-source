using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class Ex_CoinToss1_Weapon : Weapon
	{
		protected BulletPool _coin010Pool;

		protected BulletPool _coin025Pool;

		protected BulletPool _coin100Pool;

		[SerializeField]
		protected Projectile _coin010Prefab;

		[SerializeField]
		protected Projectile _coin025Prefab;

		[SerializeField]
		protected Projectile _coin100Prefab;

		public float ProjectileYOffset;

		public bool IsAutoFiring { get; set; }

		public virtual bool HasGreedMult => false;

		public override float PInterval()
		{
			return 0f;
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
			return null;
		}

		protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		protected bool OnBulletOverlapsEnemy10(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		protected bool OnBulletOverlapsEnemy25(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		protected bool OnBulletOverlapsEnemy100(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}
	}
}
