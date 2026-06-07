using System.Collections.Generic;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class LEM_Fibonacci1_Projectile : Projectile
	{
		private const float Radius = 16f;

		private const float FibOffsetModifier = 0.01f;

		private const float SeltzerSpriteScale = 0.4f;

		private LEM_Fibonacci1_Weapon _trueWeapon;

		private PhaserSprite _seltzerSprite;

		private Transform _seltzerNozzle;

		private int _fibIndex;

		private List<int> _fibSequence;

		private List<float2> _fibOffsets;

		private float2 _landedPos;

		private float2 _offset;

		private float _angle;

		private float _angleForNextOffset;

		private bool _isSpiralling;

		private bool _isDespawning;

		private float _cachedArea;

		private Tween _moveTween;

		private Tween _rotateTween;

		private Tween _scaleTween;

		private Timer _hitBoxTimer;

		private Timer _despawnTimer;

		private Timer _sfxTimer;

		private ParticleEmitterManager _pfxManager;

		private ParticleSystem _pfx;

		private float SpeedModifier => 0f;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void TweenIn()
		{
		}

		private void StartSpinning()
		{
		}

		private void PlayThrowSfx()
		{
		}

		private void PlaySpinningSfx()
		{
		}

		public override void InternalUpdate()
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
