using System;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class PrismaticMissileProjectile : Projectile
	{
		[SerializeField]
		private TrailRenderer _trail;

		private Timer _expireTimer;

		private MultiTargetTween _fadeInTween;

		private MultiTargetTween _fadeOutTween;

		private Timer _despawnTimer;

		private MultiTargetTween _despawnTween;

		private float _defaultFallDuration;

		private float _fallDuration;

		private PrismaticMissileWeapon _trueWeapon;

		private MultiTargetTween _scaleTween;

		private Timer _explodeTimer;

		private string _frameNameBeam;

		private float _startingAlpha;

		private float _startingAngle;

		private float _startingX;

		private float _angleIncrement;

		private bool _showTrailOnSecondUpdate;

		private float _updateTicks;

		private PhaserSprite _groundFx;

		private ParticleEmitterManager _pfxManager;

		private ParticleSystem _pfxEmitter;

		private GravityWell _well;

		private Circle _explosionCircle;

		private float _exploRadius;

		private MultiTargetTween _groundFxTween;

		private float _angleUnit;

		private float2 _pfxLocation;

		private uint[] _colors;

		[NonSerialized]
		public float Radius;

		[NonSerialized]
		public float _startingY;

		private bool isHoming;

		protected override void Awake()
		{
		}

		private void MakeTrail()
		{
		}

		private void SetTrailTextureFromIndex()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void BeforeDespawn()
		{
		}

		public override void Despawn()
		{
		}

		public override void InternalUpdate()
		{
		}

		protected override void OnHasHitAnObject(IDamageable target)
		{
		}
	}
}
