using DG.Tweening;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Acid1_Projectile : Projectile
	{
		private float _radius;

		private PhaserSprite _animatedSprite;

		private PhaserSprite _animatedSprite2;

		private Tween _radiusTween;

		private MultiTargetTween _scaleTween;

		private float __force;

		private Tween _forceTween;

		private float _saveVelX;

		private float _saveVelY;

		private bool _isDespawning;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void StartDespawn()
		{
		}

		private void Bounce(Body b, bool up, bool down, bool left, bool right)
		{
		}

		private void LateUpdate()
		{
		}

		public override void Despawn()
		{
		}
	}
}
