using System;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class EX_Rune2_Weapon : Weapon
	{
		private ParticleEmitterManager _pfxManager;

		private ParticleSystem _emitter1;

		private ParticleSystem _emitter2;

		private Circle _emitZone;

		private GravityWell _well1;

		private GravityWell _well2;

		private ParticleSystem.MainModule _mainModule1;

		private ParticleSystem.MainModule _mainModule2;

		private float _angleValue;

		private ParticleEmitterManager _fixedCircleManager;

		private ParticleSystem _fixedCircleEmitter;

		private Circle _circleEmitCircle;

		private EmitZone _circleEmitZone;

		private MultiTargetTween _singularityTween;

		private float _singularityTime;

		private bool _doingSingularity;

		private MultiTargetTween _restoreTween;

		private float _singularityTimes;

		private bool _skipEmitUpdate;

		private bool _hasBullets;

		private MultiTargetTween _singularityExplosionTween;

		private MultiTargetTween _screenShakeTween;

		private EX_Rune2_SpinningProjectile _bulletA;

		private EX_Rune2_SpinningProjectile _bulletB;

		[NonSerialized]
		public float radius;

		[NonSerialized]
		public float SingularityExplosionValue;

		public int AccumulatedProjectiles;

		private int activations;

		private ParticleSystem.Particle[] _activeParticles1;

		private ParticleSystem.Particle[] _activeParticles2;

		private float Lifetime1_Min;

		private float Lifetime1_Max;

		private float Lifetime2_Min;

		private float Lifetime2_Max;

		[SerializeField]
		private Projectile _SpinningPrefab;

		private BulletPool _spinningPool;

		[SerializeField]
		private Projectile InvisProjectilePrefab;

		private BulletPool InvisProjectilesPool;

		private bool _playerControlled;

		protected override void Awake()
		{
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Cleanup()
		{
		}

		protected virtual float SingularityPower()
		{
			return 0f;
		}

		protected virtual float SingularityDelay()
		{
			return 0f;
		}

		private void InitBullets()
		{
		}

		private void DoSingularity()
		{
		}

		private void ExplodeSingularity()
		{
		}

		protected override void OnStart()
		{
		}

		private void ScreenShake()
		{
		}

		public override void SetVisible(bool visible)
		{
		}

		protected float StripLength()
		{
			return 0f;
		}

		private void FireStripAtEnemy(EnemyController enemy, int index, Vector2 startPosition, bool flipMyY = false)
		{
		}

		protected virtual bool OnBulletOverlapsEnemy_AllDamage(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}
	}
}
