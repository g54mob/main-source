using DG.Tweening;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_AuraBig_Projectile : Projectile
	{
		private float _radius;

		private Tween _radiusTween;

		private MultiTargetTween _scaleTween;

		private PhaserSprite _animatedSprite;

		private PhaserSprite _animatedSprite2;

		private PhaserSprite _animatedSprite3;

		private MultiTargetTween _enterTween;

		private MultiTargetTween _alphaTween;

		private MultiTargetTween _alphaTween2;

		private MultiTargetTween _alphaTween3;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void Despawn()
		{
		}

		private void StartDespawn()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}
	}
}
