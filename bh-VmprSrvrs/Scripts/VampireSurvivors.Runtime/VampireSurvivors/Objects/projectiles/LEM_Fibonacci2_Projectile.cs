using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class LEM_Fibonacci2_Projectile : Projectile
	{
		private const float Radius = 16f;

		private const float FibOffsetModifier = 0.01f;

		private readonly List<string> SuitFrames;

		private LEM_Fibonacci2_Weapon _trueWeapon;

		private int _fibIndex;

		private List<int> _fibSequence;

		private List<float2> _fibOffsets;

		private Transform _container;

		private float2 _offset;

		private float _angle;

		private float _angleForNextOffset;

		private bool _isDespawning;

		private float _cachedArea;

		private bool _updateFlushVFX;

		private ParticleEmitterManager _pfxManager;

		private ParticleSystem _pfxFlush;

		private ParticleSystem _pfxSuit;

		private Timer _despawnTimer;

		private Timer _pfxFlushTimer;

		private Timer _pfxSuitTimer;

		private float SpeedModifier => 0f;

		private float ScaledAlpha => 0f;

		private bool ForceStopEmittingFlushParticles => false;

		private bool ForceStopEmittingSuitParticles => false;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void InitPfx()
		{
		}

		private void RotateContainer()
		{
		}

		private void PlaySpinningSfx()
		{
		}

		public override void InternalUpdate()
		{
		}

		public void UpdateAll()
		{
		}

		private void UpdateAngleAndOffset()
		{
		}

		private void UpdatePosition()
		{
		}

		private void UpdateRotation()
		{
		}

		private void UpdateVfx()
		{
		}

		private void PlaySuitPfx()
		{
		}

		private void GenerateParticleSystem()
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
