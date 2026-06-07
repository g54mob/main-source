using UnityEngine;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_DarkRift2_Weapon : Weapon
	{
		[SerializeField]
		private Projectile _SkullProjectilePrefab;

		private BulletPool _skullProjectilePool;

		public float SkullProjectileScale => 0f;

		private float SkullDamageMultiplier => 0f;

		public int NumSkulls => 0;

		public override float PArea()
		{
			return 0f;
		}

		protected override void OnStart()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		private void SpawnSkulls()
		{
		}

		public override void CheckArcanas()
		{
		}

		private bool OnBulletOverlapsEnemy_Skull(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}
	}
}
