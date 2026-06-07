using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_IronBall_Projectile : Projectile
	{
		protected const float Radius = 12f;

		protected const float Grav = 6.25f;

		protected Vector2 _velocity;

		protected float _startingAngle;

		protected float _saveVelX;

		protected float _saveVelY;

		protected bool _hasHitScreenBottom;

		protected Tween _angleTween;

		protected MultiTargetTween _scaleTween;

		public override float ProjectileSpeed => 0f;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		public virtual void OnHittingScreenBottom()
		{
		}

		public override void OnHasHitWallPhaser(PhaserTile tile)
		{
		}

		public override void Despawn()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}

		protected override void OnHasHitAnotherPlayerObject(IDamageable other)
		{
		}

		private void OnHasHitAnObjectLogic(IDamageable other, bool triggerHit)
		{
		}

		protected void ScreenShake()
		{
		}

		protected void PlayHitSFX()
		{
		}
	}
}
