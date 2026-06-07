using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_GreatswordProjectile_AbsetzenBeam : Projectile
	{
		[SerializeField]
		protected TrailRenderer _Trail;

		[SerializeField]
		private ParticleSystem _TrailHeadFX;

		private const float Radius = 18f;

		private const float DelayDuration = 50f;

		private readonly List<EME_GreatswordProjectile_Absetzen> _targets;

		private int _targetIndex;

		private MultiTargetTween _moveTween;

		private Timer _delayTimer;

		private Timer _despawnTimer;

		private float _finalAngle;

		public List<EME_GreatswordProjectile_Absetzen> Targets => null;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void SetupTrail()
		{
		}

		public void AddTarget(EME_GreatswordProjectile_Absetzen target)
		{
		}

		public void PrepareToFire()
		{
		}

		public void SetInitialTarget()
		{
		}

		private void SetNextTarget()
		{
		}

		private void MoveTo(Vector2 position)
		{
		}

		private void MoveAtFinalAngle()
		{
		}

		public float GetFinalAngle()
		{
			return 0f;
		}

		public float GetRandomAngle()
		{
			return 0f;
		}

		private void PlaySfx()
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
