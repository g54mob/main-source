using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_SpearProjectile : Projectile
	{
		[SerializeField]
		protected SpriteRenderer _SpearSprite;

		[SerializeField]
		protected TrailRenderer _LineTrail;

		protected string _spearSpriteName;

		protected float _area;

		private Vector2 _velocity;

		private EME_Spear1Weapon _trueWeapon;

		private MultiTargetTween _fadeTween;

		private Timer _expireTimer;

		private PhaserSprite _portalSprite;

		private MultiTargetTween _portalTween;

		protected virtual float Radius => 0f;

		protected virtual float ScaleMultiplier => 0f;

		protected virtual float InitialSpeed => 0f;

		protected virtual float DecelRate => 0f;

		protected virtual bool UsesPortalVFX => false;

		protected virtual float PortalVFXScale => 0f;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		public void SetVelocityForTriumvirate(float rotation)
		{
		}

		private void UpdateVelocity()
		{
		}

		protected virtual void SetupTrail()
		{
		}

		private void SetupSpearSprite()
		{
		}

		protected virtual string GetSpearSpriteName(WeaponType weapon = WeaponType.VOID)
		{
			return null;
		}

		private void DoSpearFadeIn()
		{
		}

		private void DoPortalVfx()
		{
		}

		protected virtual void PlaySfx()
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
