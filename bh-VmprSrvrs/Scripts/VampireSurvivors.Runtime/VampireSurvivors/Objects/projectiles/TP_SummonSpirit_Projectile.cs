using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_SummonSpirit_Projectile : Projectile
	{
		private Timer _expireTimer;

		private float _radius;

		private MultiTargetTween _scaleTween;

		private float _IndexOffsetScaleFactor;

		private MultiTargetTween _alphaTween;

		public float2 _targetPosition;

		public float _timeSinceChangedTarget;

		protected ParticleEmitterManager _pfxManager;

		private ParticleSystem _pfx;

		protected bool _emitParticles;

		private Timer _hitboxTimer;

		private bool _isDespawning;

		protected virtual uint[] Tints => null;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}

		private void StartDespawn()
		{
		}

		public override void Despawn()
		{
		}

		private void GenerateParticleSystem()
		{
		}

		public override void InternalUpdate()
		{
		}

		protected virtual void UpdatePfx()
		{
		}
	}
}
