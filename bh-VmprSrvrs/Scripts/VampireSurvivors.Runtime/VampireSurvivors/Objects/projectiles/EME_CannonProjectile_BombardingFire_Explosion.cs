using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_CannonProjectile_BombardingFire_Explosion : Projectile
	{
		[SerializeField]
		private SpriteRenderer _GroundVFX;

		[SerializeField]
		private ParticleSystem _ExplosionFX;

		private const float Radius = 48f;

		private const float VFXScale = 0.8f;

		private Tween _tween;

		private MultiTargetTween _screenShakeTween;

		private Timer _expireTimer;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void LateUpdate()
		{
		}

		private void FadeOut()
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

		private void PlaySfx()
		{
		}

		private void DoScreenShake()
		{
		}
	}
}
