using System;
using System.Collections.Generic;
using Assets.Scripts.Audio;
using Assets.Scripts.Flight.Combat;
using Assets.Scripts.Flight.Combat.Events;
using Assets.Scripts.Flight.Events;
using Assets.Scripts.Flight.Explosions;
using Assets.Scripts.Flight.WorldObjects.Vehicles.Land.Convoy;
using Assets.Scripts.Multiplayer.FlightObjects.Damage;
using Assets.Scripts.Multiplayer.FlightObjects.Damage.Events;
using Assets.Scripts.Rendering;
using GPUInstancerPro;
using Jundroo.Common.Extensions;
using Jundroo.Common.Utils;
using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Vehicles.Land
{
	[SelectionBase]
	public class SimpleGroundVehicleScript : MonoBehaviour
	{
		private static class Profile
		{
			public static readonly ProfilerMarker CheckForObstructions = new ProfilerMarker("SimpleGroundVehicleScript.CheckForObstructions");

			public static readonly ProfilerMarker OnNavigationTargetReached = new ProfilerMarker("SimpleGroundVehicleScript.OnNavigationTargetReached");

			public static readonly ProfilerMarker Update = new ProfilerMarker("SimpleGroundVehicleScript.Update");

			public static readonly ProfilerMarker UpdateWheels = new ProfilerMarker("SimpleGroundVehicleScript.UpdateWheels");
		}

		[SerializeField]
		private bool _alwaysTargetable;

		private float _brake = 35f;

		private int _carLayer;

		private Vector3 _center;

		private List<GameObject> _colliderGameObjects = new List<GameObject>();

		[SerializeField]
		private bool _considerNavigationTargetPlane = true;

		private ParticleSystem _criticalDamageParticles;

		[SerializeField]
		private GameObject _criticalDamageParticlesPrefab;

		[SerializeField]
		private float _currentForwardVelocity;

		private float _damper = 10f;

		private ParticleSystem.EmissionModule _dustCloudParticleEmission;

		[SerializeField]
		private ParticleSystem _dustCloudParticles;

		[SerializeField]
		private float _dustParticlesMaxedVelocity = 10f;

		[SerializeField]
		private float _dustParticlesMaxEmissionRate = 12f;

		[SerializeField]
		private float _dustParticlesStartVelocity = 5f;

		private bool _enableWheelPhysics = true;

		private AudioSource _engineSound;

		[SerializeField]
		private string _groundTargetName;

		private float _honkTime = 3f;

		private bool _isDestroyed;

		private bool _isHostile;

		private bool _isOwner;

		private ParticleSystem _lightDamageParticles;

		[SerializeField]
		private GameObject _lightDamageParticlesPrefab;

		private LodScript _lodScript;

		[SerializeField]
		private float _mass;

		[SerializeField]
		private Transform _navigationTarget;

		[SerializeField]
		private float _navigationTargetDistanceThreshold = 10f;

		[SerializeField]
		private float _obstructionRaycastDistance = 2f;

		[SerializeField]
		private Rigidbody _rigidBody;

		private SimpleWheel[] _simpleWheels;

		private bool _simulatePhysics;

		private float _speed = 5f;

		[SerializeField]
		private float _speedFactor = 1f;

		private float _springForce = 50f;

		[SerializeField]
		private float _targetVelocity = 15f;

		private float _timeOffGround;

		[SerializeField]
		private float _timeOffGroundBeforeDeath = 10f;

		private Transform _transform;

		private SimpleGroundVehicleUpdaterScript _updater;

		[SerializeField]
		private Vector3 _wheelAxis = new Vector3(1f, 0f, 0f);

		[SerializeField]
		private Transform[] _wheels;

		public bool ConsiderNavigationTargetPlane
		{
			get
			{
				return _considerNavigationTargetPlane;
			}
			set
			{
				_considerNavigationTargetPlane = value;
			}
		}

		public Color DustParticlesColor
		{
			set
			{
				if (!(_dustCloudParticles == null))
				{
					ParticleSystem.MainModule main = _dustCloudParticles.main;
					main.startColor = value;
					Gradient gradient = new Gradient();
					gradient.alphaKeys = new GradientAlphaKey[3]
					{
						new GradientAlphaKey(0.23529412f, 0f),
						new GradientAlphaKey(0.11764706f, 0.9f),
						new GradientAlphaKey(0f, 1f)
					};
					gradient.colorKeys = new GradientColorKey[2]
					{
						new GradientColorKey(value, 0f),
						new GradientColorKey(value, 1f)
					};
					Gradient gradient2 = gradient;
					ParticleSystem.ColorOverLifetimeModule colorOverLifetime = _dustCloudParticles.colorOverLifetime;
					colorOverLifetime.color = new ParticleSystem.MinMaxGradient(gradient2);
				}
			}
		}

		public bool EnableWheelPhysics
		{
			get
			{
				return _enableWheelPhysics;
			}
			set
			{
				if (_enableWheelPhysics != value)
				{
					_enableWheelPhysics = value;
					UpdateSimulatePhysicsState();
				}
			}
		}

		public float ForwardVelocity => _currentForwardVelocity;

		public bool IsBlocked { get; private set; }

		public bool IsDestroyed
		{
			get
			{
				return _isDestroyed;
			}
			protected set
			{
				if (_isDestroyed != value)
				{
					_isDestroyed = value;
					UpdateSimulatePhysicsState();
				}
			}
		}

		public bool IsGrounded { get; private set; }

		public virtual bool IsHostile
		{
			get
			{
				return _isHostile;
			}
			set
			{
				_isHostile = value;
				if (_alwaysTargetable)
				{
					return;
				}
				if (value)
				{
					if (Target == null && !IsDestroyed)
					{
						AddPlayerTarget();
					}
				}
				else if (Target != null)
				{
					Target.MarkAsDead();
					Target = null;
				}
			}
		}

		public bool IsOnRoad { get; private set; }

		public bool IsOwner
		{
			get
			{
				return _isOwner;
			}
			set
			{
				if (_isOwner != value)
				{
					_isOwner = value;
					UpdateSimulatePhysicsState();
				}
			}
		}

		public Transform NavigationTarget
		{
			get
			{
				return _navigationTarget;
			}
			set
			{
				_navigationTarget = value;
				if (value != null)
				{
					NavigationTargetVehicle = value.GetComponent<SimpleGroundVehicleScript>();
				}
			}
		}

		public float NavigationTargetDistanceThreshold
		{
			get
			{
				return _navigationTargetDistanceThreshold;
			}
			set
			{
				_navigationTargetDistanceThreshold = value;
			}
		}

		public SimpleGroundVehicleScript NavigationTargetVehicle { get; private set; }

		public Func<RaycastHit, bool> ProcessObscrution { get; set; }

		public Rigidbody RigidBody
		{
			get
			{
				return _rigidBody;
			}
			set
			{
				_rigidBody = value;
			}
		}

		public IReadOnlyCollection<SimpleWheel> SimpleWheels => _simpleWheels;

		public float SpeedFactor
		{
			get
			{
				return _speedFactor;
			}
			set
			{
				_speedFactor = value;
			}
		}

		public GroundTarget Target { get; private set; }

		public float TargetVelocity
		{
			get
			{
				return _targetVelocity;
			}
			set
			{
				_targetVelocity = value;
			}
		}

		public bool UseGravityOnRemoteCrafts { get; set; } = true;

		public float VehicleNavigationTargetDistance { get; set; }

		public event EventHandler<ConvoyVehicleEventArgs> AttackedByPlayer;

		public event EventHandler<ConvoyVehicleEventArgs> CriticalDamageReceived;

		public event EventHandler<ConvoyVehicleEventArgs> LightDamageReceived;

		public event EventHandler<ConvoyNavigationTargetReachedEventArgs> NavigationTargetReached;

		public event Action<SimpleGroundVehicleScript> VehicleDestroyed;

		public void CheckForObstructions()
		{
			using (Profile.CheckForObstructions.Auto())
			{
				if (!IsGrounded || _speed == 0f)
				{
					IsBlocked = false;
					return;
				}
				float currentForwardVelocity = _currentForwardVelocity;
				bool isBlocked = false;
				if (_obstructionRaycastDistance > 0f)
				{
					float maxDistance = Mathf.Max(currentForwardVelocity * _obstructionRaycastDistance, 5f);
					int layerMask = 0x4200000 | (1 << _carLayer) | 0x20000;
					foreach (GameObject colliderGameObject in _colliderGameObjects)
					{
						colliderGameObject.layer = 2;
					}
					Vector3 forward = base.transform.forward;
					if (Physics.SphereCast(new Ray(base.transform.position + base.transform.up * 1f + forward * 2f, forward), 1f, out var hitInfo, maxDistance, layerMask))
					{
						isBlocked = ProcessObscrution(hitInfo);
					}
					foreach (GameObject colliderGameObject2 in _colliderGameObjects)
					{
						colliderGameObject2.layer = _carLayer;
					}
				}
				IsBlocked = isBlocked;
			}
		}

		public void Initialize(Rigidbody rigidbody, GameObject lightDamageParticlesPrefab, GameObject criticalDamageParticlesPrefab, float? mass = null, Transform[] wheels = null, float speedFactor = 1f)
		{
			if (lightDamageParticlesPrefab != null)
			{
				_lightDamageParticlesPrefab = lightDamageParticlesPrefab;
			}
			if (criticalDamageParticlesPrefab != null)
			{
				_criticalDamageParticlesPrefab = criticalDamageParticlesPrefab;
			}
			_transform = base.transform;
			_speedFactor = speedFactor;
			if (wheels != null)
			{
				_wheels = wheels;
			}
			if (mass.HasValue)
			{
				_mass = mass.Value;
			}
			if (_dustCloudParticles != null)
			{
				_dustCloudParticleEmission = _dustCloudParticles.emission;
				_dustCloudParticleEmission.rateOverTime = new ParticleSystem.MinMaxCurve(0f);
			}
			if (Game.Instance.Device.IsMobileBuild && _dustCloudParticles != null)
			{
				_dustCloudParticles.gameObject.SetActive(value: false);
			}
			_lodScript = GetComponent<LodScript>();
			_rigidBody = rigidbody;
			_rigidBody.centerOfMass = Vector3.zero;
			_engineSound = GetComponentInParent<AudioSource>();
			Physics.SyncTransforms();
			Bounds bounds = Utilities.CalculateColliderBounds(base.gameObject);
			_center = base.transform.InverseTransformPoint(bounds.center);
		}

		public NetworkFlightObjectDamageReceiverScript InitializeDamgeReceiver()
		{
			if (!_rigidBody.TryGetComponent<NetworkFlightObjectDamageReceiverScript>(out var component))
			{
				component = _rigidBody.gameObject.AddComponent<NetworkFlightObjectDamageReceiverScript>();
				component.SetDamageLevels(new DamageLevel[3]
				{
					new DamageLevel(0, "None"),
					new DamageLevel(100, "Light"),
					new DamageLevel(300, "Critical")
				});
				component.DamageHandlers.CollisionDamage.Configure(1f, 10f);
				component.DamageHandlers.ExplosionDamage.Configure(10f, 50f);
				component.DamageHandlers.StandardBulletsDamage.Configure(1f, 10f);
				component.DamageHandlers.CannonProjectileDamage.Configure(1f, 50f);
			}
			component.DamageLevelChanged += OnDamageThresholdReached;
			return component;
		}

		public virtual void OnFixedUpdate()
		{
			Vector3 position = _transform.position;
			Vector3? vector = ((NavigationTarget == null) ? ((Vector3?)null) : new Vector3?(NavigationTarget.position));
			if (vector.HasValue)
			{
				Vector3 vector2 = position;
				vector2.y = vector.Value.y;
				Vector3 vector3 = vector2 - vector.Value;
				if (vector3.sqrMagnitude < _navigationTargetDistanceThreshold * _navigationTargetDistanceThreshold)
				{
					OnNavigationTargetReached();
				}
				else if (_considerNavigationTargetPlane && Vector3.Dot(vector3.normalized, NavigationTarget.forward) > 0f)
				{
					OnNavigationTargetReached();
				}
			}
			UpdateWheels();
			Vector3 linearVelocity = _rigidBody.linearVelocity;
			Vector3 vector4 = _transform.InverseTransformVector(linearVelocity);
			float num = (_currentForwardVelocity = ((vector4.z > 0.1f) ? vector4.z : 0f));
			float num2 = _targetVelocity;
			float num3 = Mathf.Abs(vector4.x);
			float num4 = 0f;
			if (_speed > 0f && IsGrounded)
			{
				if (num > 1f && num3 < num && vector.HasValue)
				{
					Vector3 forward = _transform.forward;
					forward.y = 0f;
					forward.Normalize();
					Vector3 targetDirection = vector.Value - position;
					targetDirection.y = 0f;
					targetDirection.Normalize();
					float num5 = ApplyTorqueTowards(forward, targetDirection, num);
					float num6 = Mathf.Lerp(1f, 0.5f, num5 * num5 * 100f);
					num2 *= num6;
				}
				if (_brake > 0f && IsBlocked)
				{
					num4 = _brake;
					_honkTime -= Time.deltaTime;
					if (_honkTime < 0f)
					{
						_honkTime = UnityEngine.Random.Range(5f, 15f);
						AudioManager.PlaySound(AudioStore.CarHornHonk, position);
					}
				}
				else if (num > num2)
				{
					num4 = _brake * 0.5f;
				}
				if (num4 > 0f)
				{
					_rigidBody.AddRelativeForce(0f, 0f, (0f - Mathf.Clamp01(num)) * num4, ForceMode.Acceleration);
				}
				else if (num < num2 && vector.HasValue)
				{
					_rigidBody.AddRelativeForce(0f, 0f, _speed, ForceMode.Acceleration);
				}
				float num7 = 5f;
				_rigidBody.AddRelativeForce((0f - vector4.x) * num7, 0f, 0f, ForceMode.Acceleration);
				if (_dustCloudParticles != null)
				{
					if (_dustParticlesStartVelocity < num)
					{
						float num8 = Mathf.Clamp01((num - _dustParticlesStartVelocity) / (_dustParticlesMaxedVelocity - _dustParticlesStartVelocity));
						_dustCloudParticleEmission.rateOverTime = new ParticleSystem.MinMaxCurve(_dustParticlesMaxEmissionRate * num8);
					}
					else
					{
						_dustCloudParticleEmission.rateOverTime = new ParticleSystem.MinMaxCurve(0f);
					}
				}
			}
			if (_engineSound != null)
			{
				if (IsGrounded)
				{
					float b = ((num4 > 0.1f) ? 1f : (1f + Mathf.Pow(Mathf.Min(num, 39f), 1.3f) / 20f % 1f));
					_engineSound.pitch = Mathf.Lerp(_engineSound.pitch, b, 2f * Time.fixedDeltaTime);
					_engineSound.volume = 0.5f + 2f * Mathf.Max(0f, num2 - num) / Mathf.Max(1f, num2);
				}
				else
				{
					_engineSound.pitch = 1f;
					_engineSound.volume = 0.5f;
				}
			}
		}

		public virtual void OnNavigationTargetReached()
		{
			using (Profile.OnNavigationTargetReached.Auto())
			{
				Transform navigationTarget = NavigationTarget;
				NavigationTarget = null;
				this.NavigationTargetReached?.Invoke(this, new ConvoyNavigationTargetReachedEventArgs(this, navigationTarget));
			}
		}

		protected virtual void Die()
		{
			IsDestroyed = true;
			this.VehicleDestroyed?.Invoke(this);
			if (_dustCloudParticles != null)
			{
				_dustCloudParticleEmission.rateOverTime = new ParticleSystem.MinMaxCurve(0f);
			}
			if (Target != null)
			{
				Target.MarkAsDead();
				Target = null;
			}
		}

		protected virtual void OnAttackedByPlayer()
		{
			this.AttackedByPlayer?.Invoke(this, new ConvoyVehicleEventArgs(this));
		}

		protected virtual void OnCriticalDamageReceived()
		{
			Die();
			TriggerSmallExplosion();
			if (_criticalDamageParticlesPrefab != null)
			{
				if (_lightDamageParticles != null)
				{
					UnityEngine.Object.Destroy(_lightDamageParticles.gameObject);
					_lightDamageParticles = null;
				}
				GameObject gameObject = UnityEngine.Object.Instantiate(_criticalDamageParticlesPrefab, base.transform);
				gameObject.transform.localPosition = _center + Vector3.forward * 1f;
				_criticalDamageParticles = gameObject.GetComponent<ParticleSystem>();
				_criticalDamageParticles.Play();
			}
			this.CriticalDamageReceived?.Invoke(this, new ConvoyVehicleEventArgs(this));
		}

		protected virtual void OnDestroy()
		{
			FlightSceneScript instance = FlightSceneScript.Instance;
			if (instance != null)
			{
				instance.PlayerLoaded -= OnPlayerLoaded;
			}
			if (_simpleWheels != null)
			{
				SimpleWheel[] simpleWheels = _simpleWheels;
				for (int i = 0; i < simpleWheels.Length; i++)
				{
					simpleWheels[i].OnDestroy();
				}
			}
			if (_updater != null)
			{
				if (_simulatePhysics)
				{
					_updater.UnregisterForPhysicsSimulation(this);
				}
				_updater.Unregister(this);
				_updater = null;
			}
			if (Target != null)
			{
				Target.MarkAsDead();
				Target = null;
			}
		}

		protected virtual void OnDrawGizmos()
		{
			if (!(NavigationTarget == null) && !IsDestroyed)
			{
				Gizmos.color = Color.black;
				Gizmos.DrawLine(_transform.position, NavigationTarget.position);
			}
		}

		protected virtual void OnLightDamageReceived()
		{
			if (_lightDamageParticlesPrefab != null)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(_lightDamageParticlesPrefab, base.transform);
				gameObject.transform.localPosition = _center + Vector3.forward * 1f;
				_lightDamageParticles = gameObject.GetComponent<ParticleSystem>();
				_lightDamageParticles.Play();
			}
			this.LightDamageReceived?.Invoke(this, new ConvoyVehicleEventArgs(this));
		}

		protected virtual void Start()
		{
			if (_rigidBody == null)
			{
				this.LogError("The Rigidbody component could not be found.");
				base.gameObject.SetActive(value: false);
				return;
			}
			_rigidBody.maxDepenetrationVelocity = 3f;
			if (_mass > 0f)
			{
				_rigidBody.mass = _mass;
			}
			_carLayer = 13;
			Collider[] componentsInChildren = GetComponentsInChildren<Collider>();
			foreach (Collider collider in componentsInChildren)
			{
				if (collider.gameObject.layer == _carLayer)
				{
					_colliderGameObjects.Add(collider.gameObject);
				}
			}
			FlightSceneScript instance = FlightSceneScript.Instance;
			if (instance != null)
			{
				instance.PlayerLoaded += OnPlayerLoaded;
				FlightSceneScript.Instance.RaiseLocalPlayerLoaded(OnPlayerLoaded);
			}
			if (EnableWheelPhysics)
			{
				_rigidBody.angularDamping = 10f;
				_simpleWheels = new SimpleWheel[_wheels.Length];
				for (int j = 0; j < _wheels.Length; j++)
				{
					_simpleWheels[j] = new SimpleWheel(_wheels[j], _rigidBody, _springForce, _damper, _wheelAxis);
				}
			}
			else
			{
				Transform[] wheels = _wheels;
				foreach (Transform transform in wheels)
				{
					if (!transform.HasComponent<BoxCollider>() && transform.TryGetComponent<MeshRenderer>(out var component))
					{
						BoxCollider boxCollider = transform.gameObject.AddComponent<BoxCollider>();
						boxCollider.material = new PhysicsMaterial("High Friction Tire")
						{
							dynamicFriction = 1f,
							staticFriction = 1f
						};
						Bounds bounds = component.bounds;
						Vector3 center = transform.InverseTransformPoint(bounds.center);
						Vector3 size = bounds.size / transform.lossyScale.x;
						boxCollider.center = center;
						boxCollider.size = size;
					}
				}
			}
			_updater = FlightSceneScript.Instance.CarSpawner.SimpleGroundVehicleUpdater;
			_updater.Register(this);
			_obstructionRaycastDistance *= UnityEngine.Random.Range(0.25f, 1f);
			UpdateSimulatePhysicsState();
		}

		protected virtual void TriggerSmallExplosion()
		{
			Vector3 position = base.transform.TransformPoint(_center);
			FlightSceneScript.Instance.CreateExplosion("GeneralExplosion", position, 1f, null, null, null, ExplosiveWeaponImpactType.Structure);
			RigidBody.centerOfMass = _center;
			RigidBody.angularDamping = 0.05f;
			RigidBody.AddForce(Vector3.up * UnityEngine.Random.Range(5f, 10f), ForceMode.VelocityChange);
			RigidBody.AddTorque(UnityEngine.Random.insideUnitSphere * 25f, ForceMode.VelocityChange);
		}

		protected virtual void Update()
		{
			using (Profile.Update.Auto())
			{
				RigidBody.useGravity = IsOwner || IsDestroyed || !EnableWheelPhysics;
				if (!UseGravityOnRemoteCrafts && !IsOwner)
				{
					RigidBody.useGravity = false;
				}
				if (IsDestroyed)
				{
					if (_criticalDamageParticles != null)
					{
						_criticalDamageParticles.transform.up = Vector3.up;
					}
					return;
				}
				if (_lightDamageParticles != null)
				{
					_lightDamageParticles.transform.up = Vector3.up;
				}
				if (_timeOffGround >= _timeOffGroundBeforeDeath)
				{
					Die();
				}
				else
				{
					if (!EnableWheelPhysics)
					{
						return;
					}
					LodScript lodScript = _lodScript;
					if ((object)lodScript == null || lodScript.CurrentLevel == 0)
					{
						if (!_simulatePhysics)
						{
							Vector3 linearVelocity = _rigidBody.linearVelocity;
							Vector3 vector = _transform.InverseTransformVector(linearVelocity);
							float currentForwardVelocity = ((vector.z > 0.1f) ? vector.z : 0f);
							_currentForwardVelocity = currentForwardVelocity;
						}
						SimpleWheel[] simpleWheels = _simpleWheels;
						for (int i = 0; i < simpleWheels.Length; i++)
						{
							simpleWheels[i].RotateWheel(_currentForwardVelocity);
						}
					}
				}
			}
		}

		private static void AddTorqueAtLocalPosition(Rigidbody rb, Vector3 torque, Vector3 localPosition, ForceMode forceMode = ForceMode.Force)
		{
			Vector3 vector = rb.transform.TransformPoint(localPosition);
			Vector3 lhs = vector - rb.worldCenterOfMass;
			if ((double)lhs.sqrMagnitude < 1E-06)
			{
				rb.AddTorque(torque, forceMode);
				return;
			}
			Vector3 normalized = lhs.normalized;
			Vector3 vector2 = Vector3.Dot(torque, normalized) * normalized;
			Vector3 rhs = torque - vector2;
			Vector3 force = -Vector3.Cross(lhs, rhs) / lhs.sqrMagnitude;
			rb.AddForceAtPosition(force, vector, forceMode);
			rb.AddTorque(vector2, forceMode);
		}

		private void AddPlayerTarget()
		{
			FlightSceneScript instance = FlightSceneScript.Instance;
			if (!(instance == null))
			{
				Target = new GroundTarget(_groundTargetName, _transform, 5000f, 1);
				Target.Locked += OnTargetLocked;
				instance.TargetRegistry.RegisterTarget(Target);
			}
		}

		private float ApplyTorqueTowards(Vector3 currentDirection, Vector3 targetDirection, float scale)
		{
			float num = Mathf.Clamp(Vector3.SignedAngle(currentDirection, targetDirection, Vector3.up) * 0.025f * 0.5f, -0.5f, 0.5f);
			float num2 = 5f;
			AddTorqueAtLocalPosition(_rigidBody, scale * num * num2 * Vector3.up, new Vector3(0f, 0f, 1f), ForceMode.Acceleration);
			return num;
		}

		private void OnDamageThresholdReached(object sender, DamageLevelEventArgs e)
		{
			if (e.NewLevel.Level == 1)
			{
				OnLightDamageReceived();
			}
			else if (e.NewLevel.Level >= 2)
			{
				OnCriticalDamageReceived();
			}
		}

		private void OnPlayerLoaded(object sender, FlightScenePlayerEventArgs e)
		{
			if (_alwaysTargetable || _isHostile)
			{
				AddPlayerTarget();
			}
		}

		private void OnTargetLocked(object sender, TargetLockEventArgs e)
		{
			IsHostile = true;
			OnAttackedByPlayer();
		}

		private void UpdateSimulatePhysicsState()
		{
			bool flag = _updater != null && EnableWheelPhysics && IsOwner && !IsDestroyed;
			if (_simulatePhysics != flag)
			{
				_simulatePhysics = flag;
				if (flag)
				{
					_updater.RegisterForPhysicsSimulation(this);
					return;
				}
				_updater.UnregisterForPhysicsSimulation(this);
				_currentForwardVelocity = 0f;
			}
		}

		private void UpdateWheels()
		{
			using (Profile.UpdateWheels.Auto())
			{
				IsOnRoad = false;
				IsGrounded = false;
				SimpleWheel[] simpleWheels = _simpleWheels;
				foreach (SimpleWheel simpleWheel in simpleWheels)
				{
					IsGrounded = IsGrounded || simpleWheel.Grounded;
					IsOnRoad = IsOnRoad || simpleWheel.IsOnRoad;
				}
			}
		}
	}
}
