using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Dominus2_Projectile : Projectile
	{
		private float _radius;

		private PhaserSprite _animatedSprite;

		private bool _isDespawning;

		private bool _hasHitBottom;

		private string idle;

		private string burst;

		private string idleInverse;

		private string burstInverse;

		private bool inverted;

		private TP_Dominus2_Weapon _trueWeapon;

		protected override void Awake()
		{
		}

		public void Invert(bool value)
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void LateUpdate()
		{
		}

		private void OnHittingScreenBottom()
		{
		}

		public override void Despawn()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}
	}
}
