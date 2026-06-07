using Assets.Scripts.Flight.Explosions;
using Assets.Scripts.Multiplayer.FlightObjects;
using Assets.Scripts.Multiplayer.FlightObjects.Damage;
using Assets.Scripts.Multiplayer.FlightObjects.Damage.Events;
using FishNet.Serializing;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Vehicles.Air
{
	public class BlimpScript : NetworkedAreaItemScript
	{
		[Tooltip("How strongly the blimp corrects its altitude relative to its parent. Higher values mean faster correction.")]
		[SerializeField]
		private float _altitudeCorrectionForce = 50f;

		private NetworkedAreaBodyScript _body;

		private NetworkFlightObjectDamageReceiverScript _damageReceiver;

		[Tooltip("The strength of the torque used to align the blimp with its direction of travel.")]
		[SerializeField]
		private float _headingCorrectionTorque = 10f;

		[Tooltip("The central transform that this object will orbit around.")]
		[SerializeField]
		private Transform _orbitCenter;

		private float _orbitRadius;

		[Tooltip("The speed at which the blimp orbits the central point.")]
		[SerializeField]
		private float _orbitSpeed = 10f;

		private Rigidbody _rigidBody;

		[Tooltip("Dampens angular rotation to prevent overshooting the target heading.")]
		[SerializeField]
		private float _rotationalDamping = 2f;

		private float _targetLocalAltitudeY;

		[Tooltip("Dampens vertical movement to prevent bouncing around the target altitude.")]
		[SerializeField]
		private float _verticalDamping = 5f;

		public bool IsDestroyed { get; private set; }

		public override void InitializeArea(INetworkedArea area, byte itemID)
		{
			base.InitializeArea(area, itemID);
			_body = GetComponent<NetworkedAreaBodyScript>();
			area.FlightObjectLoaded += OnAreaFlightObjectLoaded;
			area.FlightObjectUnloaded += OnAreaFlightObjectUnloaded;
		}

		public override void ReadState(PooledReader reader, float timeDelta)
		{
			base.ReadState(reader, timeDelta);
		}

		public override void WriteState(PooledWriter writer)
		{
			base.WriteState(writer);
		}

		protected override void Awake()
		{
			base.Awake();
			LayerUtility.SetLayerRecursive(base.gameObject, base.gameObject.layer);
			_rigidBody = GetComponent<Rigidbody>();
			if (_rigidBody == null)
			{
				Debug.LogError("The Rigidbody component could not be found.", base.gameObject);
				base.gameObject.SetActive(value: false);
			}
			else
			{
				_damageReceiver = InitializeDamgeReceiver();
			}
		}

		protected void FixedUpdate()
		{
			if (base.Area != null && base.Area.IsOwner && !_rigidBody.isKinematic)
			{
				MaintainAltitude();
				if (_orbitCenter != null)
				{
					MaintainOrbit();
				}
			}
		}

		protected virtual void OnCriticalDamageReceived()
		{
			Die();
			Vector3 worldCenterOfMass = _rigidBody.worldCenterOfMass;
			FlightSceneScript.Instance.CreateExplosion("GeneralExplosion", worldCenterOfMass, 5f, null, null, null, ExplosiveWeaponImpactType.Structure);
		}

		protected virtual void Start()
		{
			_targetLocalAltitudeY = base.transform.localPosition.y;
			if (_orbitCenter != null)
			{
				Vector3 vector = base.transform.position - _orbitCenter.position;
				vector.y = 0f;
				_orbitRadius = vector.magnitude;
			}
		}

		protected virtual void Update()
		{
			if (!(_body == null))
			{
				_ = base.Area.IsOwner;
			}
		}

		private void Die()
		{
			IsDestroyed = true;
			base.gameObject.SetActive(value: false);
		}

		private NetworkFlightObjectDamageReceiverScript InitializeDamgeReceiver()
		{
			if (!_rigidBody.TryGetComponent<NetworkFlightObjectDamageReceiverScript>(out var component))
			{
				component = _rigidBody.gameObject.AddComponent<NetworkFlightObjectDamageReceiverScript>();
				component.DamageHandlers.CollisionDamage.Configure(1f, 10f);
				component.DamageHandlers.ExplosionDamage.Configure(20f, 50f);
				component.DamageHandlers.StandardBulletsDamage.Configure(2f, 10f);
				component.DamageHandlers.CannonProjectileDamage.Configure(2f, 50f);
			}
			component.DamageReceived += OnDamageReceived;
			return component;
		}

		private void MaintainAltitude()
		{
			float y = base.transform.localPosition.y;
			Vector3 vector = (_targetLocalAltitudeY - y) * _altitudeCorrectionForce * Vector3.up;
			float y2 = _rigidBody.linearVelocity.y;
			Vector3 vector2 = _verticalDamping * y2 * -Vector3.up;
			_rigidBody.AddForce(vector + vector2);
		}

		private void MaintainOrbit()
		{
			Vector3 position = _orbitCenter.position;
			Vector3 position2 = base.transform.position;
			position.y = (position2.y = 0f);
			Vector3 vector = position2 - position;
			Vector3 vector2 = _orbitSpeed * _orbitSpeed * _rigidBody.mass * -vector.normalized / _orbitRadius;
			Vector3 linearVelocity = _rigidBody.linearVelocity;
			linearVelocity.y = 0f;
			Vector3 vector3 = Vector3.Cross(vector.normalized, Vector3.up).normalized * _orbitSpeed;
			Vector3 vector4 = (vector3 - linearVelocity) * _rigidBody.mass;
			_rigidBody.AddForce(vector2 + vector4);
			Vector3 normalized = vector3.normalized;
			if (!(normalized == Vector3.zero))
			{
				Vector3 vector5 = Vector3.Cross(base.transform.forward, normalized) * _headingCorrectionTorque;
				_rigidBody.AddTorque(vector5 - _rigidBody.angularVelocity * _rotationalDamping);
			}
		}

		private void OnAreaFlightObjectLoaded(NetworkFlightObject obj)
		{
			NetworkFlightObjectDamageScript component = obj.GetComponent<NetworkFlightObjectDamageScript>();
			if (base.DamageReceiverId.HasValue)
			{
				_damageReceiver.Initialize(base.DamageReceiverId.Value, component);
			}
			else
			{
				Debug.LogError("NetworkedAreaItem was not configured to request a damage receiver ID", base.gameObject);
			}
		}

		private void OnAreaFlightObjectUnloaded(NetworkFlightObject obj)
		{
			if (_damageReceiver.IsInitialized)
			{
				_damageReceiver.Uninitialize();
			}
		}

		private void OnDamageReceived(object sender, DamageReceivedEventArgs e)
		{
			if ((float)e.TotalDamage > 250f && !IsDestroyed)
			{
				OnCriticalDamageReceived();
			}
		}
	}
}
