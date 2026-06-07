using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Serialization;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class Projectile : ArcadeSprite, IDamageable
	{
		[FormerlySerializedAs("_bounceOffWalls")]
		[SerializeField]
		private bool _BounceOffWalls;

		protected Transform _cachedTransform;

		protected Weapon _weapon;

		protected int _indexInWeapon;

		protected Transform _targetTransform;

		protected SpriteRenderer _renderer;

		protected GameSessionData _gameSessionData;

		protected Camera _mainCamera;

		protected SpriteTrail _spriteTrail;

		private float _pauseWallChecksTimer;

		[NonSerialized]
		public float _speed;

		protected int _penetrating;

		protected int _bounces;

		protected bool _isCullable;

		protected bool _bounceActivated;

		protected ArcadeSprite _sprite;

		protected BulletPool _pool;

		protected readonly HashSet<IDamageable> _objectsHit;

		private static readonly ProfilerMarker _markerInitProjectile;

		public HashSet<IDamageable> ObjectsHit => null;

		public virtual float ProjectileSpeed => 0f;

		public int IndexInWeapon => 0;

		public Weapon Weapon => null;

		protected Vector2 Velocity
		{
			get
			{
				return default(Vector2);
			}
			private set
			{
			}
		}

		protected virtual void Awake()
		{
		}

		protected override void OnUpdate()
		{
		}

		public virtual void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public virtual void SetNullTarget()
		{
		}

		public virtual void SetTarget(Transform target)
		{
		}

		public void SetVelocity(Vector2 velocity)
		{
		}

		public virtual void InternalUpdate()
		{
		}

		public bool HasAlreadyHitPickUpObject(IDamageable damageable)
		{
			return false;
		}

		public bool HasAlreadyHitObject(IDamageable damageable)
		{
			return false;
		}

		public bool HasAlreadyHitPlayerObject(IDamageable damageable)
		{
			return false;
		}

		public void AddObjectHit(IDamageable obj)
		{
		}

		public float AngleFromTargetRadians(Transform target, Transform playerTransform)
		{
			return 0f;
		}

		public void ApplyPlayerFacingVelocity(Vector3 playerDirection, bool rotate = true)
		{
		}

		public void ApplyInversePlayerFacingVelocity(Vector3 playerDirection, bool rotate = true)
		{
		}

		public virtual void OnHasHitWallPhaser(PhaserTile tile)
		{
		}

		public virtual bool CanExplode()
		{
			return false;
		}

		public virtual void Explode(Vector2? position = null)
		{
		}

		private void CheckIfVisibleOnScreen()
		{
		}

		public virtual void Despawn()
		{
		}

		protected void SetScaleToArea(float multiplier = 1f)
		{
		}

		protected Vector2 SetVelocityFromRotation(float rotation, float speed)
		{
			return default(Vector2);
		}

		public bool TryFreeze(IDamageable target)
		{
			return false;
		}

		public bool TryDefang(IDamageable target)
		{
			return false;
		}

		protected virtual void OnHasHitAnObject(IDamageable other)
		{
		}

		protected virtual void OnHasHitAnotherPlayerObject(IDamageable other)
		{
		}

		public float AngleFromVelocity(Vector2 velocity)
		{
			return 0f;
		}

		protected float AngleFromVelocityRadians(Vector2 velocity)
		{
			return 0f;
		}

		protected Transform SetForNearestEnemy(ref Vector2 v)
		{
			return null;
		}

		public virtual Transform AimForNearestEnemyToPlayer(bool rotate = true)
		{
			return null;
		}

		public virtual Transform AimForNearestEnemy(bool rotate = true)
		{
			return null;
		}

		public virtual Transform AimForNearestEnemyFrom(Transform targetT, bool rotate = true, Vector3? customFromPosition = null)
		{
			return null;
		}

		protected virtual Transform AimForRandomEnemy(bool rotate = true)
		{
			return null;
		}

		protected virtual Transform GetNearestEnemyTransform()
		{
			return null;
		}

		protected virtual Transform AimForRandomEnemyInScreen([CanBeNull] Rectangle _rect = null)
		{
			return null;
		}

		public virtual void AimForRandomDirection(bool rotate = false)
		{
		}

		public virtual void ApplyInitialVelocity(Transform target, Transform playerTransform, bool rotate = true, Vector3? customFromPosition = null)
		{
		}

		public virtual void ApplyAngleVelocity(float angleAim, bool rotate = true)
		{
		}

		protected virtual float RotateTowardsEnemy()
		{
			return 0f;
		}

		public void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKnockBack = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		public void OnGetDamaged(HitVfxType hitVfxType, bool hasKb = true)
		{
		}

		public bool IsUnitDead()
		{
			return false;
		}

		public float MaxHp()
		{
			return 0f;
		}

		public float CurrentHealth()
		{
			return 0f;
		}

		public GameObject GetGameObject()
		{
			return null;
		}

		public void GiveReward(Action<Pickup> onRewardGiven = null)
		{
		}

		public float AlphaFromScale(float weaponArea, float maxScale, float minAlpha)
		{
			return 0f;
		}
	}
}
