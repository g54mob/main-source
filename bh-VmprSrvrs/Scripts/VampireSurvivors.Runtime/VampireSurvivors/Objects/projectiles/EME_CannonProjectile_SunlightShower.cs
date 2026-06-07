using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_CannonProjectile_SunlightShower : Projectile
	{
		[SerializeField]
		private TrailRenderer _TrailBlue;

		[SerializeField]
		private TrailRenderer _TrailOrange;

		private const float Radius = 16f;

		private const float FallDurationMS = 500f;

		private Tween _positionTween;

		private Timer _despawnTimer;

		private Timer _sfxTimer;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void MoveToTarget(float2 targetPos)
		{
		}

		private void Explode()
		{
		}

		private void PlaySfx()
		{
		}

		public override void Despawn()
		{
		}

		private void SetupTrails()
		{
		}
	}
}
