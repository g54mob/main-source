using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_SpearProjectile_Stardust : Projectile
	{
		[SerializeField]
		protected SpriteRenderer _SpearSprite;

		[SerializeField]
		private TrailRenderer _LineTrail;

		[SerializeField]
		private TrailRenderer _vfxTrail;

		private const float Radius = 90f;

		private const float ScaleMultiplier = 0.15f;

		private string _spearSpriteName;

		private float _area;

		private MultiTargetTween _fadeTween;

		private Timer _expireTimer;

		private PhaserSprite _portalSprite;

		private MultiTargetTween _portalTween;

		private ParticleEmitterManager _pfxManager;

		private ParticleSystem _pfx;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void UpdateParticles()
		{
		}

		private void SetupTrail()
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

		private void GenerateParticleSystem()
		{
		}

		private void PlaySfx()
		{
		}

		public void PlaySfxLong()
		{
		}

		private void StartDespawn()
		{
		}

		private void WaitBeforeDespawn()
		{
		}

		public override void Despawn()
		{
		}
	}
}
