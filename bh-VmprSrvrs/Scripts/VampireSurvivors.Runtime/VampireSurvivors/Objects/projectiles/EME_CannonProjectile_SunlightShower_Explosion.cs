using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_CannonProjectile_SunlightShower_Explosion : Projectile
	{
		[SerializeField]
		private ParticleSystem _ExplosionBlueVFX;

		[SerializeField]
		private ParticleSystem _ExplosionOrangeVFX;

		private const float Radius = 36f;

		private const float VFXScale = 1f;

		private const float VFXDurationMS = 700f;

		private const float TimeBetweenExplosionsMS = 200f;

		private const float BodyDuration = 600f;

		private List<ParticleSystem> _vfxList;

		private Timer _vfxTimer;

		private Timer _bodyTimer;

		private MultiTargetTween _screenShakeTween;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void LateUpdate()
		{
		}

		private void PlayVFX(ParticleSystem vfx)
		{
		}

		private void DoFirstVFX()
		{
		}

		private void DoSecondVFX()
		{
		}

		private void PlaySfx()
		{
		}

		public override void Despawn()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}

		private void DoScreenShake()
		{
		}
	}
}
