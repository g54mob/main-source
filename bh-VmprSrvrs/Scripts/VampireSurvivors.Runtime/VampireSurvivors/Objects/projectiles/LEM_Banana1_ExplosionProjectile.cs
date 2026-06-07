using DG.Tweening;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class LEM_Banana1_ExplosionProjectile : Projectile
	{
		private const float Radius = 26f;

		private Tween _bodyTween;

		private PhaserSprite _explosionSprite;

		protected virtual float ExplosionTweenMillis => 0f;

		protected virtual int ExplosionFPS => 0;

		protected virtual float ExplosionAlpha => 0f;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void InitSprites()
		{
		}

		private void TweenBody()
		{
		}

		private void PlaySfx()
		{
		}

		private void StartDespawn()
		{
		}

		public override void Despawn()
		{
		}
	}
}
