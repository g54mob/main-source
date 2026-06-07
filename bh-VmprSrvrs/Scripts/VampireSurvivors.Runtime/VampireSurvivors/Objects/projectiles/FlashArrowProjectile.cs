using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class FlashArrowProjectile : Projectile
	{
		private bool _hasHitFirstEnemy;

		private ParticleEmitterManager _pfxEmitter;

		private MultiTargetTween _lineTween;

		private MultiTargetTween _flashTween;

		private PhaserSprite _lineSprite;

		private PhaserSprite _flashSprite;

		private PhaserSprite _discSprite;

		private IMillionaire _trueWeapon;

		public bool _canMillionaire;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void Bounce(Body b, bool up, bool down, bool left, bool right)
		{
		}

		protected override void OnHasHitAnotherPlayerObject(IDamageable other)
		{
		}

		protected override void OnHasHitAnObject(IDamageable target)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void PlayUselessVfx()
		{
		}
	}
}
