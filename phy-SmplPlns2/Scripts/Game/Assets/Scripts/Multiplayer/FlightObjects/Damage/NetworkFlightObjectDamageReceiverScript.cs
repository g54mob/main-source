using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Damage;
using Assets.Scripts.Multiplayer.FlightObjects.Damage.Events;
using Jundroo.Common.Extensions;
using Jundroo.Common.Pool;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.FlightObjects.Damage
{
	public class NetworkFlightObjectDamageReceiverScript : MonoBehaviour, IDamageableObject
	{
		[Flags]
		public enum DamageTypeReplicationFlags
		{
			None = 0,
			Collision = 1,
			Explosion = 2,
			StandardBullets = 4,
			CannonProjectile = 8,
			Unknown = 0x10
		}

		[Flags]
		protected enum DebugLogFlags
		{
			None = 0,
			LocalDamageReceived = 1,
			SynchronizedDamageReceived = 2,
			LocalNotableDamageReceived = 4,
			NotableDamageReceived = 8,
			All = 0xF
		}

		private Func<Collision, bool> _collisionIgnoreCallback;

		[SerializeField]
		[Tooltip("The damage handlers that contain special rules for the different types of damage that can be sustained.")]
		private DamageHandlers _damageHandlers;

		[SerializeField]
		[Tooltip("The different 'stages' of damage and the associated amount of damage that must be sustained to reach them.")]
		private List<DamageLevel> _damageLevels;

		[SerializeField]
		private bool _damageReceptionEnabled = true;

		[SerializeField]
		[Tooltip("The flags that indicate which damage types, if any, will be replicated upward to the next damage receiver in the ancestor hierarchy.")]
		private DamageTypeReplicationFlags _damageReplicationFlags;

		[SerializeField]
		[Tooltip("If enabled, instances of damage considered notable (surpassing damage handler thresholds) will be recorded, synced, and appropriate events raised.")]
		private bool _enableNotableDamage;

		private byte _id;

		[SerializeField]
		[Tooltip("If enabled and enough synced damage has been incurred that the damage level is at its max value, additional damage will be ignored.")]
		private bool _ignoreExcessDamage = true;

		private bool _initialized;

		[SerializeField]
		private DebugLogFlags _logFlags;

		[SerializeField]
		[Tooltip("A generic game object reference that may be used by damage receivers to provide additional context for damage event receivers.")]
		private GameObject _referenceObject;

		private NetworkFlightObjectDamageReceiverScript _replicatedDamageTarget;

		private Rigidbody _rigidBody;

		[SerializeField]
		[Space(10f)]
		[Tooltip("A value used for debugging via inspector serialization representing the total synchronized damage for this receiver after the last damage sync.")]
		private short _syncedDamage;

		private Transform _transform;

		public INetworkedDamage Damage { get; private set; }

		public DamageHandlers DamageHandlers => _damageHandlers ?? (_damageHandlers = new DamageHandlers());

		public DamageLevel DamageLevel { get; private set; }

		public IReadOnlyList<DamageLevel> DamageLevels => _damageLevels;

		public bool DamageReceptionEnabled
		{
			get
			{
				return _damageReceptionEnabled;
			}
			set
			{
				_damageReceptionEnabled = value;
			}
		}

		public DamageTypeReplicationFlags DamageReplicationFlags
		{
			get
			{
				return _damageReplicationFlags;
			}
			set
			{
				_damageReplicationFlags = value;
			}
		}

		public NetworkFlightObjectDamageScript DamageScript { get; private set; }

		public bool EnableNotableDamage => _enableNotableDamage;

		public byte Id => _id;

		public bool IgnoreExcessDamage { get; set; }

		public bool IsInitialized => _initialized;

		public Vector3? LocalLastKnownDamagedNormal { get; private set; }

		public Vector3? LocalLastKnownDamagedPosition { get; private set; }

		public GameObject ReferenceObject
		{
			get
			{
				if (!(_referenceObject == null))
				{
					return _referenceObject;
				}
				return null;
			}
		}

		public Rigidbody RigidBody => _rigidBody;

		public Transform Transform => _transform;

		public event EventHandler<DamageLevelEventArgs> DamageLevelChanged;

		public event EventHandler<DamageReceivedEventArgs> DamageReceived;

		public event EventHandler<LocalDamageReceivedEventArgs> LocalDamageReceived;

		public event EventHandler<NotableDamageReceivedEventArgs> LocalNotableDamageReceived;

		public event EventHandler<NotableDamageReceivedEventArgs> NotableDamageReceived;

		public void HealDamage(short? damage, int? clientId)
		{
			if (!clientId.HasValue || DamageScript.NetworkFlightObject.LocalConnection.ClientId == clientId)
			{
				short num = (Damage.Damage + Damage.UnsyncedDamage).ClampToInt16(0);
				short valueOrDefault = damage.GetValueOrDefault();
				if (!damage.HasValue)
				{
					valueOrDefault = num;
					damage = valueOrDefault;
				}
				if (damage >= num)
				{
					damage = num;
					LocalLastKnownDamagedPosition = null;
					LocalLastKnownDamagedNormal = null;
				}
				damage = (short)(-damage).Value;
				num = (num + damage.Value).ClampToInt16(0);
				this.LocalDamageReceived?.Invoke(null, new LocalDamageReceivedEventArgs(this, damage.Value, num, null, clientId));
				if (_logFlags.HasFlag(DebugLogFlags.LocalDamageReceived))
				{
					Debug.Log($"{Time.frameCount}: {base.name}: Local Damage Healed: {damage} (Total: {num + damage}) [{Damage.Damage}][{Damage.UnsyncedDamage}]");
				}
			}
		}

		public void Initialize(byte id, NetworkFlightObjectDamageScript damageScript, Func<Collision, bool> collisionIgnoreCallback = null)
		{
			if (_initialized)
			{
				Debug.LogError(GetType().FullName + " on game object '" + base.name + "' cannot be initialized because it has already been initialized");
				return;
			}
			_initialized = true;
			_id = id;
			_collisionIgnoreCallback = collisionIgnoreCallback;
			DamageScript = damageScript;
			Damage = damageScript.RegisterDamageReceiver(this);
		}

		public void OnDamageReceived(DamageType type, float damage, int? playerId, Vector3? position = null, Vector3? normal = null)
		{
			if (!DamageReceptionEnabled || Damage == null || (playerId.HasValue && !Game.Instance.NetworkGameManager.IsLocalPlayer(playerId.Value)))
			{
				return;
			}
			ReplicateDamageIfNeeded(type, damage, playerId, position, normal);
			if (_ignoreExcessDamage && _damageLevels.Count > 1)
			{
				DamageLevel damageLevel = DamageLevel;
				List<DamageLevel> damageLevels = _damageLevels;
				if (damageLevel == damageLevels[damageLevels.Count - 1])
				{
					return;
				}
			}
			DamageHandler damageHandler = _damageHandlers[type];
			if (damageHandler != null)
			{
				damage = damageHandler.GetFinalDamage(damage);
			}
			if (damage == 0f)
			{
				return;
			}
			if (position.HasValue)
			{
				position = _transform.InverseTransformPoint(position.Value);
				LocalLastKnownDamagedPosition = position.Value;
			}
			if (normal.HasValue)
			{
				normal = _transform.InverseTransformDirection(normal.Value);
				LocalLastKnownDamagedNormal = normal.Value;
			}
			short num = ((float)(Damage.Damage + Damage.UnsyncedDamage) + damage).ClampToInt16(0);
			this.LocalDamageReceived?.Invoke(this, new LocalDamageReceivedEventArgs(this, damage.ClampToInt16(), num, type, playerId, position, normal));
			if (_logFlags.HasFlag(DebugLogFlags.LocalDamageReceived))
			{
				Debug.Log($"{Time.frameCount}: {base.name}: Local Damage: {damage} (Total: {num}) [{Damage.Damage}][{Damage.UnsyncedDamage}] ({type})");
			}
			if (_enableNotableDamage && damageHandler != null && damageHandler.IsNotable(damage))
			{
				float physicsTime = FlightSceneScript.Instance.FlightSceneNetwork.PhysicsTime;
				NotableDamage damage2 = new NotableDamage(damage.ClampToInt16(), type, playerId, position, normal, physicsTime);
				this.LocalNotableDamageReceived?.Invoke(this, new NotableDamageReceivedEventArgs(this, damage2));
				if (_logFlags.HasFlag(DebugLogFlags.NotableDamageReceived))
				{
					Debug.Log($"{Time.frameCount}: {base.name}: Local Notable Damage: {damage2.Damage} ({damage2.Type})");
				}
			}
		}

		public void OnDamageSynced(short syncedDamage, short totalDamage)
		{
			this.DamageReceived?.Invoke(this, new DamageReceivedEventArgs(this, syncedDamage, totalDamage));
			UpdateDamageLevel();
			if (_syncedDamage != totalDamage)
			{
				_syncedDamage = totalDamage;
			}
			if (_logFlags.HasFlag(DebugLogFlags.SynchronizedDamageReceived))
			{
				Debug.Log($"{Time.frameCount}: {base.name}: Synced Damage: {syncedDamage} (Total: {totalDamage})");
			}
		}

		public void OnExplosiveForce(float force, int? playerId, Vector3 position, Vector3? normal)
		{
			OnDamageReceived(DamageType.Explosion, force, playerId, position, normal);
		}

		public void OnNotableDamageSynced(NotableDamage damage)
		{
			this.NotableDamageReceived?.Invoke(this, new NotableDamageReceivedEventArgs(this, damage));
			if (_logFlags.HasFlag(DebugLogFlags.NotableDamageReceived))
			{
				Debug.Log($"{Time.frameCount}: {base.name}: Synced Notable Damage: {damage.Damage} ({damage.Type})");
			}
		}

		public void OnStandardBulletHit(float damage, int? playerId, Vector3 hitLocation, Vector3 hitNormal)
		{
			OnDamageReceived(DamageType.StandardBullets, damage, playerId, hitLocation, hitNormal);
		}

		public void SetDamageLevels(IEnumerable<DamageLevel> damageLevels)
		{
			if (_damageLevels == null)
			{
				_damageLevels = new List<DamageLevel>();
			}
			_damageLevels.Clear();
			DamageLevel = null;
			_damageLevels.AddRange(damageLevels);
			InitializeDamageLevels();
			UpdateDamageLevel();
		}

		public void Uninitialize()
		{
			if (_initialized)
			{
				DamageScript.UnregisterDamageReceiver(this);
				_initialized = false;
				_collisionIgnoreCallback = null;
				_id = 0;
				Damage = null;
				DamageScript = null;
			}
			else
			{
				Debug.LogError(GetType().FullName + " on game object '" + base.name + "' cannot be uninitialized because it is not currently initialized");
			}
		}

		protected virtual void Awake()
		{
			_transform = GetComponent<Transform>();
			_rigidBody = GetComponentInParent<Rigidbody>();
			if (_damageHandlers == null)
			{
				_damageHandlers = new DamageHandlers();
			}
			InitializeDamageLevels();
		}

		protected virtual void OnCollisionEnter(Collision collision)
		{
			if (collision.contactCount == 0 || FlightSceneScript.IsPeacefulMode)
			{
				return;
			}
			NetworkFlightObjectDamageScript damageScript = DamageScript;
			if ((object)damageScript == null || !damageScript.IsOwner)
			{
				return;
			}
			Dictionary<NetworkFlightObjectDamageReceiverScript, (ContactPoint, float)> value;
			using (CollectionPool<Dictionary<NetworkFlightObjectDamageReceiverScript, (ContactPoint, float)>, KeyValuePair<NetworkFlightObjectDamageReceiverScript, (ContactPoint, float)>>.Get(out value))
			{
				for (int i = 0; i < collision.contactCount; i++)
				{
					ContactPoint contact = collision.GetContact(i);
					NetworkFlightObjectDamageReceiverScript componentInParent = contact.thisCollider.GetComponentInParent<NetworkFlightObjectDamageReceiverScript>();
					if (componentInParent != null)
					{
						float num = float.MinValue;
						if (value.TryGetValue(componentInParent, out var value2))
						{
							num = value2.Item2;
						}
						float num2 = Mathf.Abs(Vector3.Dot(contact.normal, collision.relativeVelocity));
						if (num2 > num)
						{
							value[componentInParent] = (contact, num2);
						}
					}
				}
				foreach (KeyValuePair<NetworkFlightObjectDamageReceiverScript, (ContactPoint, float)> item in value)
				{
					NetworkFlightObjectDamageReceiverScript key = item.Key;
					(ContactPoint, float) value3 = item.Value;
					if ((!(key.DamageHandlers?.CollisionDamage?.IgnoreDamage())) ?? false)
					{
						Func<Collision, bool> collisionIgnoreCallback = key._collisionIgnoreCallback;
						if (collisionIgnoreCallback != null && collisionIgnoreCallback(collision))
						{
							break;
						}
						key.OnDamageReceived(DamageType.Collision, value3.Item2, null, value3.Item1.point, value3.Item1.normal);
					}
				}
			}
		}

		protected virtual void OnDestroy()
		{
			if (_initialized)
			{
				Uninitialize();
			}
		}

		private void InitializeDamageLevels()
		{
			if (_damageLevels == null)
			{
				_damageLevels = new List<DamageLevel>();
			}
			if (_damageLevels.Count > 1)
			{
				_damageLevels = _damageLevels.OrderBy((DamageLevel x) => x.Damage).ToList();
			}
			if (_damageLevels.Count > 0 && (float)_damageLevels[0].Damage < 0f)
			{
				Debug.LogError("Negative damage levels are not supported.");
			}
			if (_damageLevels.Count == 0 || (float)_damageLevels[0].Damage > 0f)
			{
				_damageLevels.Insert(0, new DamageLevel(0, "None"));
			}
			for (int num = 0; num < _damageLevels.Count; num++)
			{
				_damageLevels[num].Initialize(num);
			}
			DamageLevel = _damageLevels[0];
		}

		private void ReplicateDamageIfNeeded(DamageType type, float damage, int? playerId, Vector3? position, Vector3? normal)
		{
			if (type switch
			{
				DamageType.Unknown => _damageReplicationFlags.HasFlag(DamageTypeReplicationFlags.Unknown) ? 1 : 0, 
				DamageType.Collision => _damageReplicationFlags.HasFlag(DamageTypeReplicationFlags.Collision) ? 1 : 0, 
				DamageType.Explosion => _damageReplicationFlags.HasFlag(DamageTypeReplicationFlags.Explosion) ? 1 : 0, 
				DamageType.StandardBullets => _damageReplicationFlags.HasFlag(DamageTypeReplicationFlags.StandardBullets) ? 1 : 0, 
				DamageType.CannonProjectile => _damageReplicationFlags.HasFlag(DamageTypeReplicationFlags.CannonProjectile) ? 1 : 0, 
				_ => 0, 
			} == 0)
			{
				return;
			}
			try
			{
				if (_replicatedDamageTarget == null)
				{
					_replicatedDamageTarget = _transform.parent?.GetComponentInParent<NetworkFlightObjectDamageReceiverScript>(includeInactive: true);
				}
				_replicatedDamageTarget?.OnDamageReceived(type, damage, playerId, position, normal);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		private void UpdateDamageLevel()
		{
			if (Damage == null)
			{
				return;
			}
			short damage = Damage.Damage;
			int level = DamageLevel.Level;
			if (DamageLevel.Damage > damage)
			{
				for (int num = level - 1; num >= 0; num--)
				{
					if (_damageLevels[num].Damage <= damage)
					{
						DamageLevel = _damageLevels[num];
						break;
					}
				}
			}
			else
			{
				for (int i = level + 1; i < _damageLevels.Count && _damageLevels[i].Damage <= damage; i++)
				{
					DamageLevel = _damageLevels[i];
				}
			}
			int level2 = DamageLevel.Level;
			if (level == level2)
			{
				return;
			}
			if (level2 > level)
			{
				for (int j = level + 1; j <= level2; j++)
				{
					this.DamageLevelChanged?.Invoke(this, new DamageLevelEventArgs(this, _damageLevels[j - 1], _damageLevels[j]));
				}
				return;
			}
			for (int num2 = level - 1; num2 >= level2; num2--)
			{
				this.DamageLevelChanged?.Invoke(this, new DamageLevelEventArgs(this, _damageLevels[num2 + 1], _damageLevels[num2]));
			}
		}
	}
}
