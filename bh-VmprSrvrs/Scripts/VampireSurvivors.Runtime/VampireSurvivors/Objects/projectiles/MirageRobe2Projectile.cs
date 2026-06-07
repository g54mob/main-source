using UnityEngine;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class MirageRobe2Projectile : MirageRobeProjectile
	{
		private SpriteAnimation _spriteAnimation;

		private Color[][] _tints;

		public override float ProjectileSpeed => 0f;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}
	}
}
