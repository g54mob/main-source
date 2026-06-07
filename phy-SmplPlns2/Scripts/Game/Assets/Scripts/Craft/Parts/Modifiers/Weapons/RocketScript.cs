using System;
using Assets.Scripts.Craft.Parts.Modifiers.Weapons.Events;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Combat;
using Assets.Scripts.Flight.Explosions;
using Jundroo.Common.Physics;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons
{
	public class RocketScript : MonoBehaviour
	{
		public const float ImpactDetonationForce = 5f;

		public const float RocketThrust = 5000f;

		public const float RocketWeight = 5f;

		private float _burnTime = 2f;

		[SerializeField]
		private GameObject _flameFX;

		private float _flyTime;

		private SimpleGuidanceSystem _guidanceSystem;

		private bool _hasExploded;

		private ParticleSystem _particleSystem;

		private Vector3 _previousFrameVelocity;

		private Rigidbody _rigidBody;

		public float BurnTime
		{
			get
			{
				return _burnTime;
			}
			set
			{
				_burnTime = value;
			}
		}

		public bool HasExploded => _hasExploded;

		public bool IsLaserGuided { get; set; }

		public bool IsLaunched { get; private set; }

		public bool IsRemoteRocket { get; private set; }

		public bool IsRocketPod { get; private set; }

		public AircraftScript Owner { get; set; }

		public Rigidbody Rigidbody => _rigidBody;

		public float SelfDestructTimer { get; set; }

		public PartScript SourcePart { get; private set; }

		public event EventHandler<RocketExplodedEventArgs> Exploded;

		public void Explode()
		{
			if (_hasExploded)
			{
				return;
			}
			_hasExploded = true;
			if (!IsRemoteRocket)
			{
				Vector3 normalized = _previousFrameVelocity.normalized;
				FlightSceneScript.Instance.CreateExplosion("RocketExplosion", base.transform.position, 4f, Vector3.up, Owner?.NetworkAircraft?.PlayerId, normalized, ExplosiveWeaponImpactType.Ground);
				this.Exploded?.Invoke(this, new RocketExplodedEventArgs(this, normalized));
			}
			if (_particleSystem != null)
			{
				ParticleSystem.EmissionModule emission = _particleSystem.emission;
				emission.rateOverTime = 0f;
				emission.rateOverDistance = 0f;
				_particleSystem.transform.parent = null;
				UnityEngine.Object.Destroy(_particleSystem.gameObject, 3f);
			}
			if (TryGetComponent<PartScript>(out var component))
			{
				component.Body.SilentlyDisconnectAndDisablePart(component);
				return;
			}
			MeshRenderer componentInChildren = GetComponentInChildren<MeshRenderer>(includeInactive: true);
			if (componentInChildren != null)
			{
				SourcePart.PartMaterialScript.RemoveRenderer(componentInChildren);
			}
			UnityEngine.Object.Destroy(base.gameObject);
		}

		public void Launch(Vector3 velocity, Vector3 angularVelocity, PartScript sourcePart, bool isRocketPod, TrackedTarget trackedTarget)
		{
			SourcePart = sourcePart;
			IsRocketPod = isRocketPod;
			IsRemoteRocket = sourcePart.Aircraft.RemoteAircraft;
			Collider component = GetComponent<Collider>();
			component.enabled = true;
			Collider[] array = Physics.OverlapSphere(component.bounds.center, component.bounds.extents.magnitude * 1.2f);
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].transform.GetComponentInParent<PartScript>() != null)
				{
					Physics.IgnoreCollision(component, array[i]);
				}
			}
			Physics.IgnoreCollision(component, sourcePart.PrimaryPartCollider);
			IsLaunched = true;
			_rigidBody = base.transform.parent.parent.GetComponent<Rigidbody>();
			if (_rigidBody == null)
			{
				_rigidBody = base.gameObject.AddComponent<Rigidbody>();
			}
			else
			{
				_rigidBody.gameObject.AddComponent<CollisionNotifier>().CollisionEnter.AddListener(OnCollisionEnter);
			}
			_rigidBody.mass = 0.049999997f;
			_rigidBody.angularVelocity = angularVelocity;
			_rigidBody.linearVelocity = velocity;
			_rigidBody.linearDamping = 0.05f;
			_rigidBody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
			GameObject gameObject = UnityEngine.Object.Instantiate(Resources.Load("Flight/Combat/RocketSmokeTrail")) as GameObject;
			gameObject.transform.SetParent(base.transform, worldPositionStays: false);
			gameObject.transform.localPosition = new Vector3(0f, 0f, -1.6f);
			_particleSystem = gameObject.GetComponent<ParticleSystem>();
			LaserTarget laserTarget = trackedTarget?.Target as LaserTarget;
			if (IsLaserGuided && laserTarget != null && laserTarget.IsActive)
			{
				_guidanceSystem = new SimpleGuidanceSystem(Rigidbody, laserTarget, new SimpleGuidanceSystem.SimpleGuidanceConfiguration
				{
					RotationSpeed = 45f,
					GuidanceDelay = 0.1f,
					MaxLift = 1000f,
					LiftScale = 0.01f
				});
			}
			_flameFX.SetActive(value: true);
		}

		protected virtual void Awake()
		{
			_previousFrameVelocity = Vector3.zero;
			SelfDestructTimer = 10f;
		}

		protected virtual void FixedUpdate()
		{
			if (IsLaunched && !PauseManager.Paused && !_hasExploded)
			{
				_previousFrameVelocity = _rigidBody.linearVelocity;
				_flyTime += Time.fixedDeltaTime;
				if (_flyTime < _burnTime)
				{
					_rigidBody.AddForce(base.transform.forward * 50f);
				}
				if (_flyTime > SelfDestructTimer)
				{
					Explode();
				}
				_guidanceSystem?.Update();
			}
		}

		protected virtual void OnCollisionEnter(Collision collision)
		{
			for (int i = 0; i < collision.contacts.Length; i++)
			{
				float num = Mathf.Abs(Vector3.Dot(collision.contacts[i].normal, collision.relativeVelocity));
				Rigidbody attachedRigidbody = collision.contacts[i].otherCollider.attachedRigidbody;
				float mass = _rigidBody.mass;
				if (attachedRigidbody != null && attachedRigidbody.mass < mass)
				{
					num *= attachedRigidbody.mass / mass;
				}
				if (num >= 5f)
				{
					Explode();
					break;
				}
			}
		}
	}
}
