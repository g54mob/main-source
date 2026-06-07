using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_GothMissile_Projectile : Projectile
	{
		private float _radius;

		private PhaserSprite _animatedSprite;

		private MultiTargetTween _scaleTween;

		private MultiTargetTween _alphaTween;

		private Vector2 _direction;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void SetDirection(Vector2 dir)
		{
		}

		private void OnShotFired()
		{
		}

		public override void Despawn()
		{
		}
	}
}
