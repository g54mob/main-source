using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Serialization;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons
{
	public class Weapon : Equipment
	{
		public enum FiringAnimation
		{
			None = 0,
			Melee = 1,
			Ranged = 2,
			Magic = 3,
			Bazooka = 4,
			GlyphAbs = 5,
			Axe = 6,
			ConeOfCold = 7
		}

		[FormerlySerializedAs("_projectilePrefab")]
		[SerializeField]
		private Projectile _ProjectilePrefab;

		protected GameManager _gameMan;

		protected PlayerOptions _playerOptions;

		protected GameSessionData _gameSessionData;

		protected WeaponData _currentWeaponData;

		protected bool _skipAddingEvolution;

		protected readonly List<Projectile> _spawnedProjectiles;

		protected Transform _cachedTransform;

		protected Timer _lastShotTimer;

		protected Timer _firingTimer;

		private Timer _firingAnimEvent;

		protected Transform _targetTransform;

		protected BulletPool _projectilePool;

		protected int _critIndex;

		protected List<float> _critChancesArray;

		protected int _bounces;

		protected int _bonusBounces;

		protected float _lastFiringInterval;

		protected bool _beginningArcana;

		protected int _beginningAmount;

		protected List<Collider> _wallsColliders;

		protected bool _isVisible;

		protected WeaponType _explosionType;

		[NonSerialized]
		public bool _explodeOnExpire;

		protected BulletPool _secondaryPool;

		protected ProjectileFactory _projectileFactory;

		protected WeaponType _secondaryOvarlapDamageType;

		[HideInInspector]
		public LimitBreakData accumulatedLimitBreaks;

		[NonSerialized]
		public bool IsHoming;

		[NonSerialized]
		public bool IsAdept;

		public bool HasCooldownSpeedBonus;

		private float _defangChance;

		private static readonly ProfilerMarker _markerCleanup;

		private static readonly ProfilerMarker _markerFireOneProjectile;

		protected virtual int ProjectilePoolSize => 0;

		public PhysicsGroup ProjectileGroup => null;

		public List<Projectile> SpawnedProjectiles => null;

		public GameManager GameMan => null;

		protected HitVfxType VfxType => default(HitVfxType);

		protected virtual bool UseOnlineTimer => false;

		public float StatsInflictedDamage { get; set; }

		public float StatsLifetime { get; private set; }

		public virtual float Chance => 0f;

		public int Penetrating
		{
			get
			{
				return 0;
			}
			protected set
			{
			}
		}

		public float Interval
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		protected float Duration => 0f;

		public float RepeatInterval => 0f;

		public WeaponData CurrentWeaponData => null;

		public float HitBoxDelay => 0f;

		public float Knockback => 0f;

		public PlayerOptions PlayerOptions => null;

		public bool CanCrit { get; protected set; }

		public List<float> CritChancesArray => null;

		public float FreezeChance { get; set; }

		public virtual float DefangChance
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public int CritIndex
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		protected Vector2 PlayerPos => default(Vector2);

		public float TotalTime { get; set; }

		public int LimitBreakLevel { get; private set; }

		public bool SkipAddingEvolution
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool SkipAddingNormalWeapon { get; set; }

		public bool IsVisible => false;

		public bool ShowAsDisabledOnEquipmentPanel { get; set; }

		public virtual float HeartOfFirePower => 0f;

		public override bool IsPowerup()
		{
			return false;
		}

		public virtual float StatsGetDps()
		{
			return 0f;
		}

		protected override void FakeConstruct()
		{
		}

		protected virtual void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		public virtual void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		public virtual void OnMirrorData(Vector2 position)
		{
		}

		public virtual void OnWeaponAdded()
		{
		}

		public virtual float CalculateTotalDamage()
		{
			return 0f;
		}

		protected virtual void OnStart()
		{
		}

		public virtual float2 GetFiringVector()
		{
			return default(float2);
		}

		protected virtual bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		protected virtual bool OnBulletOverlapsPlayer(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		protected virtual bool OnSecondaryBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		protected virtual bool OnSecondaryBulletOverlapsEnemyCurse(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		protected virtual bool OnBulletOverlapsEnemyRetaliation(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		protected virtual bool OnBulletOverlapsDestructible(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		protected virtual bool OnBulletOverlapsWall(CallbackContext context, ArcadeColliderType bullet, ArcadeColliderType tile)
		{
			return false;
		}

		public override void InternalUpdate()
		{
		}

		public virtual int ActiveProjectileCount()
		{
			return 0;
		}

		public void AddSpawnedProjectile(Projectile projectile)
		{
		}

		public void DespawnProjectile(Projectile projectile)
		{
		}

		public override void Cleanup()
		{
		}

		public Vector2 GetPlayerCurrentDirection()
		{
			return default(Vector2);
		}

		public virtual bool LevelUp()
		{
			return false;
		}

		public void EnableAdept()
		{
		}

		public override bool LevelUp(bool skipFire)
		{
			return false;
		}

		public virtual void HandlePlayerTeleport(float2 destinationPos)
		{
		}

		public virtual float PArea()
		{
			return 0f;
		}

		public virtual int PBounces()
		{
			return 0;
		}

		public virtual float PAmount()
		{
			return 0f;
		}

		public virtual float SecondaryPAmount()
		{
			return 0f;
		}

		public virtual float PPower()
		{
			return 0f;
		}

		public virtual float SecondaryPPower()
		{
			return 0f;
		}

		public virtual float SecondaryCursePPower()
		{
			return 0f;
		}

		public virtual float PSpeed()
		{
			return 0f;
		}

		public virtual float PHitBoxDelayOverSpeed()
		{
			return 0f;
		}

		public virtual float PSpeedRepeatInterval()
		{
			return 0f;
		}

		public virtual float PInterval()
		{
			return 0f;
		}

		public virtual float PDuration()
		{
			return 0f;
		}

		public virtual void ParadoxFire()
		{
		}

		public virtual void Fire()
		{
		}

		public virtual void Fire(bool skipTriggers = false)
		{
		}

		public virtual Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
			return null;
		}

		public virtual Projectile FireOneProjectileIgnoreDistanceToPlayer(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
		{
			return null;
		}

		public Projectile FireOneBullet(float x, float y, int index, Transform target)
		{
			return null;
		}

		public virtual void DealDamage(IDamageable other)
		{
		}

		public virtual void DealDamageRetaliation(IDamageable other)
		{
		}

		public virtual void DealDamage(IDamageable other, float damage)
		{
		}

		public void DamageAllEnemies(float value)
		{
		}

		public virtual void StandardCritical(ArcadeColliderType second, ArcadeColliderType first)
		{
		}

		public override void CheckArcanas()
		{
		}

		public void CheckBeginningArcana()
		{
		}

		public bool HasActiveArcanaOfType(ArcanaType arcanaType)
		{
			return false;
		}

		public bool CheckFreeze()
		{
			return false;
		}

		public bool CheckDefang()
		{
			return false;
		}

		public virtual void CopyAccumulatedLimitBreaks(Weapon from, Weapon to)
		{
		}

		public virtual bool ApplyLimitBreak(WeightedLimitBreak weightedLimitBreak)
		{
			return false;
		}

		public virtual Projectile SpawnExplosionAt(float2 pos, int enemiesHit = 0, int damage = 1, float area = 1f)
		{
			return null;
		}

		public virtual void ResetFiringTimer()
		{
		}

		protected void FireAndQueueAnimation()
		{
		}

		protected void PlayNextAttackAnim()
		{
		}

		protected virtual FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}

		public void RemoveFiringTimer()
		{
		}

		public virtual void SetVisible(bool visible)
		{
		}

		public static List<float> MakeChanceArray(int amount = 100)
		{
			return null;
		}

		protected virtual float CalcCritMul()
		{
			return 0f;
		}

		public virtual float GetChanceFromArray()
		{
			return 0f;
		}

		protected override void MakeLevelOne()
		{
		}

		public void ReloadCurrentData()
		{
		}

		protected override Dictionary<WeaponType, JArray> GetDataDictionary()
		{
			return null;
		}

		private void ApplyLimitBreakStatsToWeaponStats(LimitBreakData limitBreakData)
		{
		}
	}
}
