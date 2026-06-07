using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_DarkRift_Projetile : Projectile
	{
		private float pxWidth;

		private float pxHeight;

		private MultiTargetTween _scaleTween;

		private MultiTargetTween _scale2Tween;

		private PhaserSprite _displaySprite;

		private PhaserSprite _animatedSprite;

		private MultiTargetTween _alphaTween;

		private float _currentScale;

		private MultiTargetTween _durationTween;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void ShootWave()
		{
		}

		private void LateUpdate()
		{
		}

		private void StartDespawn()
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
