using System;
using Assets.Scripts.Flight.Combat;
using Assets.Scripts.Flight.Combat.Events;
using Assets.Scripts.Flight.Combat.Teams;
using Assets.Scripts.Flight.Combat.Teams.Events;
using Assets.Scripts.Flight.Damage;
using Assets.Scripts.Flight.Explosions;
using Assets.Scripts.Flight.StartLocations;
using Assets.Scripts.Multiplayer.FlightObjects;
using Assets.Scripts.Multiplayer.FlightObjects.Damage;
using Assets.Scripts.Multiplayer.FlightObjects.Damage.Events;
using Jundroo.Common.Extensions;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Vehicles.Sea
{
	public class SinkableShipScript : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("The damage threshold that must be exceeded for bullets damage to cause an explosion. Resets after every explosion.")]
		protected float _bulletDamageExplosionThreshold = 500f;

		private float _bulletDamageRemainingUntilExplosion;

		[SerializeField]
		[Tooltip("The angle (in degrees) of the listing or pitching ship at which the listing will begin to decelerate for a critically damaged ship.")]
		private float _criticalDamageListDecelerationStartAngle = 60f;

		[SerializeField]
		[Tooltip("The speed (in degrees per second) at which a critically damaged ship will list to one side or the other.")]
		private float _criticalDamageListSpeed = 0.75f;

		[SerializeField]
		[Tooltip("The angle (in degrees) of the listing or pitching ship at which the pitching will begin to decelerate for a critically damaged ship.")]
		private float _criticalDamagePitchDecelerationStartAngle = 10f;

		[SerializeField]
		[Tooltip("The speed (in degrees per second) at which a heavily damaged ship will pitch to the front or back.")]
		private float _criticalDamagePitchSpeed = 0.4f;

		[SerializeField]
		[Tooltip("The speed (in meters per second) at which a critically damaged ship will sink.")]
		private float _criticalDamageSinkSpeed = 0.25f;

		private float _currentListDecelerationStartAngle;

		private float _currentListSpeed;

		private float _currentPitchDecelerationStartAngle;

		private float _currentPitchSpeed;

		private float _currentSinkSpeed;

		[SerializeField]
		[Tooltip("The angle (in degrees) of the listing or pitching ship at which the listing will begin to decelerate for a heavily damaged ship.")]
		private float _heavyDamageListDecelerationStartAngle = 15f;

		[SerializeField]
		[Tooltip("The speed (in degrees per second) at which a heavily damaged ship will list to one side or the other.")]
		private float _heavyDamageListSpeed = 0.5f;

		[SerializeField]
		[Tooltip("The angle (in degrees) of the listing or pitching ship at which the pitching will begin to decelerate for a heavily damaged ship.")]
		private float _heavyDamagePitchDecelerationStartAngle = 5f;

		[SerializeField]
		[Tooltip("The speed (in degrees per second) at which a heavily damaged ship will pitch to the front or back.")]
		private float _heavyDamagePitchSpeed = 0.2f;

		[SerializeField]
		[Tooltip("The speed (in meters per second) at which a heavily damaged ship will sink.")]
		private float _heavyDamageSinkSpeed = 0.1f;

		[SerializeField]
		[Tooltip("The speed (in meters per second) at which a the listing speed decelerates (if it should be decelerating).")]
		private float _listDeceleration = 0.25f;

		[SerializeField]
		[Tooltip("The speed (in meters per second) at which a the pitching speed decelerates (if it should be decelerating).")]
		private float _pitchDeceleration = 0.1f;

		[SerializeField]
		[Tooltip("The estimated length of the ship.")]
		private float _shipLength;

		[SerializeField]
		[Tooltip("The estimated width of the ship.")]
		private float _shipWidth;

		[SerializeField]
		[Tooltip("The distance below sea level at which a ship's sinking begins to accelerate.")]
		private float _sinkAccelerationDistance;

		private float _sinkAutoRespawnTime = 120f;

		private Vector3 _sinkPoint;

		[Tooltip("The distance from which this ship can be targeted.")]
		[SerializeField]
		private float _targetableDistance = 8000f;

		[SerializeField]
		private string _targetName;

		[SerializeField]
		private Transform _targetPosition;

		private ushort _teamId = 2;

		private TeamObjectScript _teamObject;

		public NetworkFlightObjectDamageReceiverScript DamageReceiver { get; private set; }

		public DynamicStartLocationScript DynamicStartLocation { get; private set; }

		public bool EngineDisabled { get; protected set; }

		public bool IsCriticallyDamaged { get; private set; }

		public NetworkedShipScript NetworkedShip { get; private set; }

		public Rigidbody RigidBody { get; private set; }

		public bool Sinking { get; protected set; }

		public GroundTarget Target { get; private set; }

		public float TotalDistanceSunk { get; private set; }

		protected SmokeDamageParticleSystem SmokeDamage { get; private set; }

		public event EventHandler<EventArgs> StartedSinking;

		public void Sink(Vector3 sinkPosition, bool critical)
		{
			_sinkPoint = sinkPosition;
			EngineDisabled = true;
			RigidBody.linearDamping = 0.05f;
			bool sinking = Sinking;
			Sinking = true;
			if (!sinking)
			{
				this.StartedSinking?.Invoke(this, EventArgs.Empty);
				RegisterAsResettable(_sinkAutoRespawnTime * 2f);
			}
			float num = Mathf.Clamp01(Mathf.Abs(_sinkPoint.x * 2f / _shipWidth));
			float num2 = Mathf.Clamp01(Mathf.Abs(_sinkPoint.z * 2f / _shipLength));
			_currentListSpeed = (critical ? _criticalDamageListSpeed : _heavyDamageListSpeed) * num;
			_currentPitchSpeed = (critical ? _criticalDamagePitchSpeed : _heavyDamagePitchSpeed) * num2;
			_currentListDecelerationStartAngle = (critical ? _criticalDamageListDecelerationStartAngle : _heavyDamageListDecelerationStartAngle);
			_currentPitchDecelerationStartAngle = (critical ? _criticalDamagePitchDecelerationStartAngle : _heavyDamagePitchDecelerationStartAngle);
			_currentSinkSpeed = (critical ? _criticalDamageSinkSpeed : _heavyDamageSinkSpeed);
		}

		protected virtual void Awake()
		{
			RigidBody = GetComponent<Rigidbody>();
			NetworkedShip = GetComponent<NetworkedShipScript>();
			DamageReceiver = GetComponent<NetworkFlightObjectDamageReceiverScript>();
			DynamicStartLocation = (TryGetComponent<DynamicStartLocationScript>(out var component) ? component : null);
			if (DamageReceiver == null)
			{
				this.LogError("No damage receiver found for sinkable ship '{0}'", base.gameObject.name);
			}
			if (RigidBody == null)
			{
				this.LogError("No rigidbody found for sinkable ship '{0}'", base.gameObject.name);
			}
			_teamObject = GetComponent<TeamObjectScript>();
			if (_teamObject != null)
			{
				_teamObject.TeamChanged += OnTeamChanged;
			}
		}

		protected virtual void FixedUpdate()
		{
			if (!Sinking)
			{
				return;
			}
			Rigidbody rigidBody = RigidBody;
			rigidBody.angularVelocity = Vector3.zero;
			if (_currentListSpeed > 0f || _currentPitchSpeed > 0f)
			{
				float num = Vector3.Angle(base.transform.up, Vector3.up);
				if (num >= _currentListDecelerationStartAngle)
				{
					_currentListSpeed -= _listDeceleration * Time.deltaTime;
					if (_currentListSpeed < 0f)
					{
						_currentListSpeed = 0f;
					}
				}
				if (num >= _currentPitchDecelerationStartAngle)
				{
					_currentPitchSpeed -= _pitchDeceleration * Time.deltaTime;
					if (_currentPitchSpeed < 0f)
					{
						_currentPitchSpeed = 0f;
					}
				}
				if (_currentListSpeed > 0f || _currentPitchSpeed > 0f)
				{
					rigidBody.constraints &= (RigidbodyConstraints)(-65);
					rigidBody.constraints &= (RigidbodyConstraints)(-17);
					rigidBody.angularDamping = 0.05f;
					rigidBody.angularVelocity = base.transform.TransformDirection(new Vector3(_currentPitchSpeed * Mathf.Sign(_sinkPoint.z) * (MathF.PI / 180f), 0f, _currentListSpeed * Mathf.Sign(0f - _sinkPoint.x) * (MathF.PI / 180f)));
				}
			}
			if (!(_currentSinkSpeed > 0f))
			{
				return;
			}
			float num2 = GameWorld.Instance.FloatingOriginSeaLevel.Value - (base.transform.position.y + _sinkAccelerationDistance);
			if (num2 > 0f)
			{
				_currentSinkSpeed += num2 / 10f * Time.deltaTime;
				if (!Target.IsDead)
				{
					Target.MarkAsDead();
				}
			}
			rigidBody.constraints &= (RigidbodyConstraints)(-5);
			float num3 = _currentSinkSpeed * Time.deltaTime;
			TotalDistanceSunk += num3;
			rigidBody.MovePosition(rigidBody.position - new Vector3(0f, num3, 0f));
			if (num2 > 100f && NetworkedShip.IsOwner)
			{
				string text = ((!string.IsNullOrEmpty(DynamicStartLocation?.Id)) ? DynamicStartLocation.Id : null);
				if (text != null)
				{
					FlightSceneScript.Instance.StartLocationManager.SetDynamicLocationUnavailable(text, unavailable: true);
				}
				NetworkFlightObject networkFlightObject = NetworkedShip.NetworkFlightObject;
				networkFlightObject.RegisterResettableObject(base.name, _sinkAutoRespawnTime, text);
				networkFlightObject.SetObjectSpawnEnabledState(enabled: false);
				networkFlightObject.DespawnObject();
				networkFlightObject.gameObject.SetActive(value: false);
			}
		}

		protected virtual void InitializeDamageReceiver()
		{
			if (!(DamageReceiver == null))
			{
				DamageReceiver.DamageLevelChanged += OnDamageLevelChanged;
				DamageReceiver.LocalDamageReceived += OnLocalDamageReceived;
				DamageReceiver.NotableDamageReceived += OnNotableDamageReceived;
			}
		}

		protected virtual void OnCriticalDamageReceived()
		{
			IsCriticallyDamaged = true;
			Target.MarkAsDead();
			SmokeDamage.SetLifetimeScale(1f);
			if (NetworkedShip.IsOwner)
			{
				_sinkPoint = CalculateSinkPoint();
				NetworkedShip.Sink(_sinkPoint, critical: true);
				Sink(_sinkPoint, critical: true);
			}
		}

		protected virtual void OnDestroy()
		{
			if (Target != null)
			{
				FlightSceneScript.Instance.TargetRegistry.UnregisterTarget(Target);
			}
			if (DamageReceiver != null)
			{
				DamageReceiver.DamageLevelChanged -= OnDamageLevelChanged;
				DamageReceiver.LocalDamageReceived -= OnLocalDamageReceived;
				DamageReceiver.NotableDamageReceived -= OnNotableDamageReceived;
			}
			if (_teamObject != null)
			{
				_teamObject.TeamChanged -= OnTeamChanged;
			}
		}

		protected virtual void OnHeavyDamageReceived()
		{
			SmokeDamage.SetLifetimeScale(1f);
			if (NetworkedShip.IsOwner)
			{
				_sinkPoint = CalculateSinkPoint();
				NetworkedShip.Sink(_sinkPoint, critical: false);
				Sink(_sinkPoint, critical: false);
			}
		}

		protected virtual void OnLightDamageReceived()
		{
			SmokeDamage.SetLifetimeScale(0.6f);
		}

		protected virtual void OnModerateDamageReceived()
		{
			SmokeDamage.SetLifetimeScale(0.8f);
		}

		protected virtual void Start()
		{
			InitializeDamageReceiver();
			Target = new GroundTarget(_targetName, _targetPosition ?? base.transform, _targetableDistance, _teamId);
			Target.Locked += OnTargetLocked;
			FlightSceneScript.Instance.TargetRegistry.RegisterTarget(Target);
			SmokeDamage = GetComponentInChildren<SmokeDamageParticleSystem>();
			_bulletDamageRemainingUntilExplosion = _bulletDamageExplosionThreshold;
		}

		private Vector3 CalculateSinkPoint()
		{
			int num = 0;
			Vector3 zero = Vector3.zero;
			foreach (NotableDamage item in DamageReceiver.Damage.NotableDamage)
			{
				if (item.Position.HasValue)
				{
					num++;
					zero += item.Position.Value;
				}
			}
			if (num > 0)
			{
				return zero / num;
			}
			Vector3 insideUnitSphere = UnityEngine.Random.insideUnitSphere;
			return new Vector3(_shipWidth * insideUnitSphere.x, 0f, _shipLength * insideUnitSphere.z);
		}

		private void OnDamageLevelChanged(object sender, DamageLevelEventArgs e)
		{
			if (e.NewLevel.Level == 1)
			{
				OnLightDamageReceived();
			}
			else if (e.NewLevel.Level == 2)
			{
				OnModerateDamageReceived();
			}
			else if (e.NewLevel.Level == 3)
			{
				OnHeavyDamageReceived();
			}
			else if (e.NewLevel.Level == 4)
			{
				OnCriticalDamageReceived();
			}
			RegisterAsResettable(null);
		}

		private void OnLocalDamageReceived(object sender, LocalDamageReceivedEventArgs e)
		{
			if (e.Type != DamageType.Collision && e.PlayerId.HasValue)
			{
				_teamObject.SetAggressionLevelForPlayer(e.PlayerId.Value, AggressionLevel.Hostile);
			}
			if (e.Type == DamageType.StandardBullets)
			{
				_bulletDamageRemainingUntilExplosion -= e.DamageReceived;
				if (_bulletDamageRemainingUntilExplosion <= 0f && e.Position.HasValue && e.Normal.HasValue)
				{
					_bulletDamageRemainingUntilExplosion = _bulletDamageExplosionThreshold;
					Vector3 position = base.transform.TransformPoint(e.Position.Value) + e.Normal.Value * 1f;
					FlightSceneScript.Instance.CreateExplosion("ShipBulletDamageExplosion", position, 1f, null, e.PlayerId, null, ExplosiveWeaponImpactType.Boat);
				}
			}
		}

		private void OnNotableDamageReceived(object sender, NotableDamageReceivedEventArgs e)
		{
			if (e.Damage.Position.HasValue && e.Damage.Normal.HasValue)
			{
				int num = Mathf.Clamp(e.Damage.Damage / 200 * 2, 1, 16);
				int emitterCount = 2;
				SmokeDamage.AddDamagePosition(e.Damage.Position.Value, e.Damage.Normal.Value, num, emitterCount);
			}
		}

		private void OnTargetLocked(object sender, TargetLockEventArgs e)
		{
			if (e.Source?.Player != null)
			{
				_teamObject.SetAggressionLevelForTeam(e.Source.Player.TeamId, AggressionLevel.Hostile);
			}
		}

		private void OnTeamChanged(object sender, TeamChangedEventArgs e)
		{
			_teamId = e.NewTeamId;
			if (Target != null)
			{
				Target.TeamId = _teamId;
			}
		}

		private void RegisterAsResettable(float? resetTime)
		{
			if (NetworkedShip.IsOwner)
			{
				string dynamicStartLocationId = ((!string.IsNullOrEmpty(DynamicStartLocation?.Id)) ? DynamicStartLocation.Id : null);
				NetworkedShip.NetworkFlightObject.RegisterResettableObject(base.name, resetTime, dynamicStartLocationId);
			}
		}
	}
}
