using System;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_Frog2_Weapon : Weapon
	{
		[SerializeField]
		private Projectile _FrogProjectilePrefab;

		[SerializeField]
		private Projectile _TongueProjectilePrefab;

		[SerializeField]
		private Transform _SpriteContainer;

		private const float VortexTweenDurationMS = 1500f;

		private const float SpriteScale = 27f / 32f;

		private const float AlphaBG = 0.7f;

		private const float MorphRadiusMultiplier = 1.2f;

		private PhaserSprite _vortexBG;

		private PhaserSprite _vortexOverlay1;

		private PhaserSprite _vortexOverlay2;

		private PhaserSprite _vortexOverlay3;

		private MultiTargetTween _vortexTween1;

		private MultiTargetTween _vortexTween2;

		private MultiTargetTween _vortexTween3;

		private MultiTargetTween _tintTween;

		private Timer _vortex2DelayTimer;

		private Timer _vortex3DelayTimer;

		private Timer _morphTimer;

		private bool _morphQueued;

		private float _totalTimeCounterWeapon;

		private float _recoveredHP;

		private float _recoveredCalculated;

		private ParticleEmitterManager _particlesManager;

		private ParticleSystem _pfxEmitter;

		private GravityWell _well;

		private Circle _shape1;

		private EmitZone _emitZone;

		private float _mul;

		private bool _cooldownAffectedByMovement;

		private WeaponType _counterWeaponType;

		private Weapon _counterWeapon;

		private bool _hasCounterWeapon;

		private BulletPool _frogProjectilePool;

		private BulletPool _tongueProjectilePool;

		[NonSerialized]
		public static float PAreaMax;

		public BulletPool FrogProjectilePool => null;

		public float RecoveredHP => 0f;

		public float Radius => 0f;

		public int EnemiesEatenThisRun { get; set; }

		public override float PAmount()
		{
			return 0f;
		}

		public override float PArea()
		{
			return 0f;
		}

		public override float PPower()
		{
			return 0f;
		}

		protected override void OnStart()
		{
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		private void InitRecoveredHPBonus()
		{
		}

		private void InitSprites()
		{
		}

		private void MakeOverlay(ref PhaserSprite overlay, string objectName)
		{
		}

		private void InitParticles()
		{
		}

		private void StartTweens()
		{
		}

		private void DoVortexOverlayTween1()
		{
		}

		private void DoVortexOverlayTween2()
		{
		}

		private void DoVortexOverlayTween3()
		{
		}

		private void StartMorphTimer()
		{
		}

		public override void InternalUpdate()
		{
		}

		protected void VortexUpdate(float deltaTime)
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		private void MorphEnemyInRange()
		{
		}

		public override void ResetFiringTimer()
		{
		}

		public override void Cleanup()
		{
		}

		protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		public void MakeHeartPickup(float2 pos, float rnd = 0.5f)
		{
		}

		protected void Fire_FireCounter(bool skipTriggers = false)
		{
		}

		public override bool LevelUp()
		{
			return false;
		}

		public override void CheckArcanas()
		{
		}

		public override void SetVisible(bool visible)
		{
		}
	}
}
