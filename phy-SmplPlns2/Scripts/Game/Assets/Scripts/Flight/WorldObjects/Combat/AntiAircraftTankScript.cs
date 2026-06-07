using System.Collections.Generic;
using Assets.Scripts.Flight.Combat;
using Assets.Scripts.Flight.Combat.Bullets;
using Assets.Scripts.Flight.Damage;
using Assets.Scripts.Flight.Explosions;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Combat
{
	public class AntiAircraftTankScript : MonoBehaviour, ITargetLockSource
	{
		private enum WeaponType
		{
			Guns = 0,
			Missile = 1,
			None = 2
		}

		private const float BulletSpeed = 1000f;

		private const float GunFireDelay = 0.4f;

		private const float MaxRange = 8000f;

		private const float MaxRangeGun = 3500f;

		private const float MissileFireDelay = 10f;

		private BulletPool _bulletPool;

		[SerializeField]
		private float _bulletSpread = 1f;

		private int _bulletStartIndex;

		[SerializeField]
		private Transform[] _bulletStartPoints;

		private float _currentTurretAngle;

		private float _currentWeaponAngle;

		private float _fireDelay = 10f;

		private GroundTarget _groundTarget;

		private float _gunMissPercentage = 1f;

		private bool _hasNoticedPlayer;

		[SerializeField]
		private bool _isHostile = true;

		[SerializeField]
		[Tooltip("A value indicating whether this tank a is training target (unmanned, does not shoot back).")]
		private bool _isTrainingTarget;

		private float _lastTargetBreakChance;

		private float _lastTargetEvadeChance;

		private List<AntiAircraftPlaceholderMissileScript> _missiles = new List<AntiAircraftPlaceholderMissileScript>();

		private AntiAircraftPlaceholderMissileScript _nextMissile;

		private Transform _orphanedParticleEffectsParent;

		private RigidBodyPlaceholder[] _rigidBodyPlaceholders;

		[SerializeField]
		private SignatureType _signatureType = SignatureType.Radar;

		private WeaponType _selectedWeapon = WeaponType.None;

		private Vector3 _targetPosition;

		[SerializeField]
		private Transform _turretTransform;

		[SerializeField]
		private Transform _weaponTransform;

		public DamageableBody DamageableBody { get; private set; }

		public bool HasNoticedPlayer
		{
			get
			{
				return _hasNoticedPlayer;
			}
			private set
			{
				if (_hasNoticedPlayer != value)
				{
					_hasNoticedPlayer = value;
					if (value)
					{
						Debug.Log("AA Tank noticed player");
					}
				}
			}
		}

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

		public bool IsTrainingTarget
		{
			get
			{
				return _isTrainingTarget;
			}
			set
			{
				_isTrainingTarget = value;
			}
		}

		FlightScenePlayer ITargetLockSource.Player => null;

		public NpcTargetingSystem TargetingSystem { get; private set; }

		ushort ITargetLockSource.TeamId => 0;

		protected virtual void Awake()
		{
			DamageableBody = GetComponent<DamageableBody>();
		}

		protected virtual void FixedUpdate()
		{
			if (PauseManager.Paused || IsDead || IsTrainingTarget || !IsHostile)
			{
				return;
			}
			TrackedTarget currentTarget = TargetingSystem.CurrentTarget;
			if (currentTarget != null && !currentTarget.Occluded)
			{
				Target target = currentTarget.Target;
				if (target != null)
				{
					float num = 1f;
					float num2 = 0f;
					float breakLockProbability = target.GetBreakLockProbability(_signatureType);
					float evadeLockProbability = target.GetEvadeLockProbability(_signatureType);
					if (evadeLockProbability > _lastTargetEvadeChance || (breakLockProbability > _lastTargetBreakChance && _fireDelay < 5f))
					{
						num = ((!(_fireDelay <= 0f)) ? (num - evadeLockProbability) : (num - breakLockProbability));
						num2 = Random.Range(0.1f, 1f);
					}
					if (num < num2)
					{
						_fireDelay = 10f + Random.Range(-2.5f, 2.5f);
						_fireDelay += 1.5f;
					}
					else
					{
						_lastTargetEvadeChance = evadeLockProbability;
						_lastTargetBreakChance = breakLockProbability;
					}
				}
				_fireDelay -= Time.deltaTime;
				if (_selectedWeapon == WeaponType.Guns)
				{
					if (_fireDelay <= 0f)
					{
						HasNoticedPlayer = true;
						FireGuns();
					}
				}
				else if (_selectedWeapon == WeaponType.Missile)
				{
					if (_fireDelay <= 0f)
					{
						HasNoticedPlayer = true;
						FireMissile();
					}
					else if (_fireDelay < 5f)
					{
						HasNoticedPlayer = true;
						currentTarget.Target.Alert(locked: false, this, currentTarget);
					}
				}
			}
			else
			{
				_fireDelay = 10f + Random.Range(-2.5f, 2.5f);
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
			if (!IsTrainingTarget)
			{
				_bulletPool = BulletPoolManager.Instance.CreatePool(new BulletData());
				GetComponentsInChildren(includeInactive: true, _missiles);
				GetNextMissile();
				_orphanedParticleEffectsParent = new GameObject("OrphanedParticleEffects").transform;
				_orphanedParticleEffectsParent.SetParent(base.transform, worldPositionStays: false);
			}
			ParticleSystem.EmissionModule emission = GetComponent<ParticleSystem>().emission;
			emission.enabled = false;
			DamageableBody.DamageReceived += DamageableBody_DamageReceived;
			DamageableBody.DamageThresholdReached += DamageableBody_DamageThresholdReached;
			_rigidBodyPlaceholders = GetComponentsInChildren<RigidBodyPlaceholder>();
			if (!IsTrainingTarget)
			{
				_groundTarget = new GroundTarget("AA Tank", base.transform, 1);
				FlightSceneScript.Instance.TargetRegistry.RegisterTarget(_groundTarget);
			}
		}

		protected virtual void Update()
		{
			if (IsTrainingTarget || !IsHostile || PauseManager.Paused || IsDead)
			{
				return;
			}
			TargetingSystem.Update(base.transform.position);
			TrackedTarget currentTarget = TargetingSystem.CurrentTarget;
			if (currentTarget == null)
			{
				return;
			}
			Vector3 vector = currentTarget.Target.Position - base.transform.position;
			float y = vector.y;
			float magnitude = vector.magnitude;
			if (magnitude < 3500f)
			{
				_selectedWeapon = WeaponType.Guns;
			}
			else if (magnitude < 8000f && y >= 250f)
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
					_fireDelay = Mathf.Min(10f, _fireDelay);
				}
			}
			Vector3 vector2 = base.transform.InverseTransformPoint(_targetPosition);
			float to = Mathf.Atan2(vector2.x, vector2.z) * 57.29578f;
			_currentTurretAngle = TransitionAngle(_currentTurretAngle, to);
			_turretTransform.localRotation = Quaternion.Euler(0f, _currentTurretAngle, 0f);
			float x = Mathf.Sqrt(vector2.x * vector2.x + vector2.z * vector2.z);
			float value = (0f - Mathf.Atan2(vector2.y, x)) * 57.29578f;
			value = Mathf.Clamp(value, -180f, 10f);
			_currentWeaponAngle = TransitionAngle(_currentWeaponAngle, value);
			_weaponTransform.localRotation = Quaternion.Euler(_currentWeaponAngle, 0f, 0f);
		}

		private static void ApplyRandomVelocities(Vector3 explosionSource, Vector3 position, Rigidbody rb, float velocityScale, float angularVelocityScale)
		{
			Vector3 linearVelocity = (position - explosionSource).normalized * (Random.Range(2f, 15f) * velocityScale);
			Vector3 vector = Random.onUnitSphere * (Random.Range(20f, 75f) * angularVelocityScale);
			vector = new Vector3(vector.x, vector.y * 0.25f, vector.z);
			rb.linearVelocity = linearVelocity;
			rb.angularVelocity = vector;
		}

		private void DamageableBody_DamageReceived(object sender, DamageEventArgs e)
		{
			Debug.Log("Total Damage: " + e.TotalDamage);
		}

		private void DamageableBody_DamageThresholdReached(object sender, DamageThresholdEventArgs e)
		{
			Die();
		}

		private void Die()
		{
			if (!IsDead)
			{
				if (!IsTrainingTarget)
				{
					FlightSceneScript.Instance.FlightUI.ShowLogMessage(_groundTarget.Name + " destroyed");
					_groundTarget.MarkAsDead();
				}
				IsDead = true;
				ParticleSystem.EmissionModule emission = GetComponent<ParticleSystem>().emission;
				emission.enabled = true;
				Vector3 explosionSource = base.transform.position + Vector3.down * 10f;
				RigidBodyPlaceholder[] rigidBodyPlaceholders = _rigidBodyPlaceholders;
				foreach (RigidBodyPlaceholder rigidBodyPlaceholder in rigidBodyPlaceholders)
				{
					Rigidbody rb = rigidBodyPlaceholder.CreateRigidBody();
					ApplyRandomVelocities(explosionSource, rigidBodyPlaceholder.transform.position, rb, 0.5f, 1f);
				}
				Rigidbody component = GetComponent<Rigidbody>();
				ApplyRandomVelocities(explosionSource, base.transform.position, component, 0.25f, 0.1f);
				ExplosionScript.CreateExplosion(null, base.transform.position, Vector3.zero, 10f);
			}
		}

		private void FireGuns()
		{
			_fireDelay = 0.4f;
			_bulletStartIndex++;
			if (_bulletStartIndex >= _bulletStartPoints.Length)
			{
				_bulletStartIndex = 0;
			}
			Transform transform = _bulletStartPoints[_bulletStartIndex];
			_targetPosition = TargetingSystem.CurrentTarget.Target.Position;
			_gunMissPercentage *= 0.9f;
			_gunMissPercentage = Mathf.Clamp(_gunMissPercentage, 0.05f, 1f);
			for (int i = 0; i < 3; i++)
			{
				float num = (_targetPosition - transform.position).magnitude / 1000f;
				_targetPosition = TargetingSystem.CurrentTarget.Target.Position + TargetingSystem.CurrentTarget.Target.Velocity * (num * (1f - _gunMissPercentage));
			}
			Vector3 velocity = (_targetPosition - transform.position).normalized * 1000f;
			velocity += Random.insideUnitSphere * (10f * _bulletSpread);
			_bulletPool.CreateBullet(transform.position, velocity, velocity.normalized);
		}

		private void FireMissile()
		{
			_fireDelay = 10f;
			if (_nextMissile != null)
			{
				_nextMissile.Fire(TargetingSystem.CurrentTarget, _orphanedParticleEffectsParent);
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
