using System.Collections.Generic;
using Assets.Scripts.Flight.Combat;
using Assets.Scripts.Flight.Combat.Bullets;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Combat
{
	public class ApcTurretScript : MonoBehaviour, ITargetLockSource
	{
		private enum WeaponType
		{
			Guns = 0,
			Missile = 1,
			None = 2
		}

		private BulletPool _bulletPool;

		[SerializeField]
		private float _bulletSpeed = 1000f;

		[SerializeField]
		private float _bulletSpread = 1f;

		private int _bulletStartIndex;

		[SerializeField]
		private Transform[] _bulletStartPoints;

		private float _currentTurretAngle;

		private float _currentWeaponAngle;

		private float _fireDelay = 10f;

		[SerializeField]
		private float _gunAccuracyIncreaseFactor = 0.9f;

		[SerializeField]
		private float _gunAccuracyMinValue = 0.05f;

		[SerializeField]
		private float _gunFireDelay = 0.4f;

		private float _gunMissPercentage = 1f;

		[SerializeField]
		private bool _isHostile;

		private Vector3 _leadTargetPosition;

		[SerializeField]
		private float _maxRange = 8000f;

		[SerializeField]
		private float _maxRangeGun = 3500f;

		[SerializeField]
		[Range(0f, 1f)]
		[Tooltip("The missile accuracy.")]
		private float _missileAccuracy = 0.7f;

		[SerializeField]
		[Tooltip("The amount of time in seconds at the beginning of the launch that the missile will try to gain extra altitude.")]
		private float _missileAltitudeGainTime;

		[SerializeField]
		private float _missileFireDelay = 10f;

		[SerializeField]
		[Tooltip("The maximum speed of missiles (in meters per second).")]
		private float _missileMaxSpeed = 500f;

		private List<AntiAircraftPlaceholderMissileScript> _missiles = new List<AntiAircraftPlaceholderMissileScript>();

		private AntiAircraftPlaceholderMissileScript _nextMissile;

		private Transform _orphanedParticleEffectsParent;

		private WeaponType _selectedWeapon = WeaponType.None;

		[SerializeField]
		private Transform _turretTransform;

		[SerializeField]
		private Transform _weaponTransform;

		public bool IsDead { get; private set; }

		public bool IsHostile
		{
			get
			{
				return _isHostile;
			}
			set
			{
				_isHostile = value;
			}
		}

		FlightScenePlayer ITargetLockSource.Player => null;

		public NpcTargetingSystem TargetingSystem { get; private set; }

		public List<Target> Targets { get; private set; }

		ushort ITargetLockSource.TeamId => 0;

		public ApcTurretScript()
		{
			Targets = new List<Target>();
		}

		public void Die()
		{
			if (!IsDead)
			{
				IsDead = true;
			}
		}

		protected virtual void FixedUpdate()
		{
			if (PauseManager.Paused || IsDead || !IsHostile || TargetingSystem.CurrentTarget == null || TargetingSystem.CurrentTarget.Occluded)
			{
				return;
			}
			_fireDelay -= Time.deltaTime;
			if (_selectedWeapon == WeaponType.Guns)
			{
				if (_fireDelay <= 0f)
				{
					FireGuns();
				}
			}
			else if (_selectedWeapon == WeaponType.Missile)
			{
				if (_fireDelay <= 0f)
				{
					FireMissile();
				}
				else if (_fireDelay < 5f)
				{
					TrackedTarget currentTarget = TargetingSystem.CurrentTarget;
					currentTarget.Target.Alert(locked: false, this, currentTarget);
				}
			}
		}

		protected virtual void OnDestroy()
		{
			TargetingSystem.OnDestroy();
			_bulletPool?.Dispose();
		}

		protected virtual void Start()
		{
			TargetingSystem = new NpcTargetingSystem(1);
			_bulletPool = BulletPoolManager.Instance.CreatePool(new BulletData());
			GetComponentsInChildren(includeInactive: true, _missiles);
			GetNextMissile();
			_orphanedParticleEffectsParent = new GameObject("OrphanedParticleEffects").transform;
			_orphanedParticleEffectsParent.SetParent(base.transform, worldPositionStays: false);
		}

		protected virtual void Update()
		{
			if (!IsHostile || PauseManager.Paused || IsDead)
			{
				return;
			}
			TargetingSystem.Update(base.transform.position);
			if (TargetingSystem.CurrentTarget == null)
			{
				return;
			}
			Vector3 vector = TargetingSystem.CurrentTarget.Target.Position - base.transform.position;
			float y = vector.y;
			float magnitude = vector.magnitude;
			if (magnitude < _maxRangeGun)
			{
				_selectedWeapon = WeaponType.Guns;
			}
			else if (magnitude < _maxRange && y >= 250f)
			{
				_gunMissPercentage = 1f;
				if (_nextMissile != null)
				{
					_selectedWeapon = WeaponType.Missile;
				}
				else
				{
					_selectedWeapon = WeaponType.None;
				}
			}
			else
			{
				_gunMissPercentage = 1f;
				_selectedWeapon = WeaponType.None;
			}
			if (TargetingSystem.CurrentTarget.Occluded)
			{
				if (_selectedWeapon == WeaponType.Guns)
				{
					_gunMissPercentage = 1f;
					_fireDelay += Time.deltaTime;
					_fireDelay = Mathf.Min(5f, _fireDelay);
				}
				else if (_selectedWeapon == WeaponType.Missile)
				{
					_fireDelay += Time.deltaTime;
					_fireDelay = Mathf.Min(_missileFireDelay, _fireDelay);
				}
			}
			Vector3 vector2 = base.transform.InverseTransformPoint(_leadTargetPosition);
			float to = Mathf.Atan2(vector2.x, vector2.z) * 57.29578f;
			_currentTurretAngle = TransitionAngle(_currentTurretAngle, to);
			_turretTransform.localRotation = Quaternion.Euler(0f, _currentTurretAngle, 0f);
			float x = Mathf.Sqrt(vector2.x * vector2.x + vector2.z * vector2.z);
			float value = (0f - Mathf.Atan2(vector2.y, x)) * 57.29578f;
			value = Mathf.Clamp(value, -180f, 10f);
			_currentWeaponAngle = TransitionAngle(_currentWeaponAngle, value);
			_weaponTransform.localRotation = Quaternion.Euler(0f, 0f, _currentWeaponAngle);
		}

		private void FireGuns()
		{
			_fireDelay = _gunFireDelay;
			_bulletStartIndex++;
			if (_bulletStartIndex >= _bulletStartPoints.Length)
			{
				_bulletStartIndex = 0;
			}
			Transform transform = _bulletStartPoints[_bulletStartIndex];
			_leadTargetPosition = TargetingSystem.CurrentTarget.Target.Position;
			_gunMissPercentage *= _gunAccuracyIncreaseFactor;
			_gunMissPercentage = Mathf.Clamp(_gunMissPercentage, _gunAccuracyMinValue, 1f);
			for (int i = 0; i < 3; i++)
			{
				float num = (_leadTargetPosition - transform.position).magnitude / _bulletSpeed;
				_leadTargetPosition = TargetingSystem.CurrentTarget.Target.Position + TargetingSystem.CurrentTarget.Target.Velocity * (num * (1f - _gunMissPercentage));
			}
			Vector3 velocity = (_leadTargetPosition - transform.position).normalized * _bulletSpeed;
			velocity += Random.insideUnitSphere * (10f * _bulletSpread);
			_bulletPool.CreateBullet(transform.position, velocity, velocity.normalized);
		}

		private void FireMissile()
		{
			_fireDelay = _missileFireDelay;
			if (_nextMissile != null)
			{
				AntiAircraftMissileScript antiAircraftMissileScript = _nextMissile.Fire(TargetingSystem.CurrentTarget, _orphanedParticleEffectsParent);
				antiAircraftMissileScript.AltitudeGainTime = _missileAltitudeGainTime;
				antiAircraftMissileScript.LeadAccuracy = _missileAccuracy;
				antiAircraftMissileScript.MaxSpeed = _missileMaxSpeed;
				GetNextMissile();
			}
		}

		private void GetNextMissile()
		{
			foreach (AntiAircraftPlaceholderMissileScript missile in _missiles)
			{
				if (missile.gameObject.activeSelf)
				{
					_nextMissile = missile;
					return;
				}
			}
			_nextMissile = null;
		}

		private float TransitionAngle(float from, float to)
		{
			return (to - from) * Time.deltaTime + from;
		}
	}
}
