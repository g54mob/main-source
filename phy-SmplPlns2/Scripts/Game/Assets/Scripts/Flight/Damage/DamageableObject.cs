using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Flight.Damage
{
	public class DamageableObject : MonoBehaviour, IDamageableObject
	{
		[SerializeField]
		[Tooltip("The damage handlers that contain special rules for the different types of damage that can be sustained.")]
		private DamageHandlers _damageHandlers;

		[SerializeField]
		[Tooltip("The different 'stages' of damage and the associated amount of damage that must be sustained to reach them.")]
		private List<DamageThreshold> _damageThresholds;

		public DamageThreshold CurrentDamageThreshold => _damageThresholds[CurrentDamageThresholdLevel];

		public int CurrentDamageThresholdLevel { get; private set; }

		public List<DamageThreshold> DamageThresholds
		{
			get
			{
				return _damageThresholds;
			}
			set
			{
				_damageThresholds = value;
			}
		}

		public float InitialDamage { get; set; }

		public Vector3? LastKnownDamagedNormal { get; private set; }

		public Vector3? LastKnownDamagedPosition { get; private set; }

		public virtual Rigidbody RigidBody => null;

		public float TotalDamage { get; private set; }

		protected DamageHandlers DamageHandlers => _damageHandlers;

		public event EventHandler<DamageEventArgs> DamageHealed;

		public event EventHandler<DamageEventArgs> DamageReceived;

		public event EventHandler<DamageThresholdEventArgs> DamageThresholdReached;

		public event EventHandler<DamageThresholdEventArgs> DamageThresholdReduced;

		public DamageHandler GetDamageHandler(DamageType damage)
		{
			if (DamageHandlers != null)
			{
				switch (damage)
				{
				case DamageType.Collision:
					return DamageHandlers.CollisionDamage;
				case DamageType.Explosion:
					return DamageHandlers.ExplosionDamage;
				case DamageType.StandardBullets:
					return DamageHandlers.StandardBulletsDamage;
				case DamageType.Unknown:
					return DamageHandlers.UnknownDamage;
				}
			}
			return null;
		}

		public T GetDamageHandler<T>() where T : DamageHandler
		{
			if (DamageHandlers != null)
			{
				Type typeFromHandle = typeof(T);
				if (typeFromHandle == typeof(CollisionDamageHandler))
				{
					return DamageHandlers.CollisionDamage as T;
				}
				if (typeFromHandle == typeof(ExplosionDamageHandler))
				{
					return DamageHandlers.ExplosionDamage as T;
				}
				if (typeFromHandle == typeof(StandardBulletsDamageHandler))
				{
					return DamageHandlers.StandardBulletsDamage as T;
				}
				if (typeFromHandle == typeof(UnknownDamageHandler))
				{
					return DamageHandlers.UnknownDamage as T;
				}
			}
			return null;
		}

		public virtual void OnDamageHealed(float damage, int? playerId)
		{
			TotalDamage -= damage;
			if (TotalDamage < 0f)
			{
				TotalDamage = 0f;
			}
			OnDamageChanged(DamageType.Unknown, damage, playerId, healed: true, null, null);
		}

		public virtual void OnDamageReceived(DamageType type, float damage, int? playerId, Vector3? position = null, Vector3? normal = null)
		{
			Vector3? localPosition = (position.HasValue ? new Vector3?(base.transform.InverseTransformPoint(position.Value)) : ((Vector3?)null));
			Vector3? localNormal = (normal.HasValue ? new Vector3?(base.transform.InverseTransformDirection(normal.Value)) : ((Vector3?)null));
			if (localPosition.HasValue)
			{
				LastKnownDamagedPosition = localPosition.Value;
			}
			if (localNormal.HasValue)
			{
				LastKnownDamagedNormal = localNormal.Value;
			}
			DamageHandler damageHandler = GetDamageHandler(type);
			if (damageHandler != null)
			{
				damage = damageHandler.GetFinalDamage(damage);
			}
			TotalDamage += damage;
			OnDamageChanged(type, damage, playerId, healed: false, localPosition, localNormal);
		}

		public void OnExplosiveForce(float force, int? playerId, Vector3 position, Vector3? normal)
		{
			OnDamageReceived(DamageType.Explosion, force, playerId, position, normal);
		}

		public void OnStandardBulletHit(float damage, int? playerId, Vector3 hitLocation, Vector3 hitNormal)
		{
			OnDamageReceived(DamageType.StandardBullets, damage, playerId, hitLocation, hitNormal);
		}

		protected virtual void Start()
		{
			InitializeDamageThresholds();
			TotalDamage = InitialDamage;
			UpdateDamageThreshold();
		}

		private void InitializeDamageThresholds()
		{
			if (_damageThresholds == null)
			{
				_damageThresholds = new List<DamageThreshold>();
			}
			if (_damageThresholds.Count > 1)
			{
				_damageThresholds = _damageThresholds.OrderBy((DamageThreshold x) => x.Value).ToList();
			}
			if (_damageThresholds.Count > 0 && _damageThresholds[0].Value < 0f)
			{
				Debug.LogError("Negative damage thresholds are not supported.");
			}
			if (_damageThresholds.Count == 0 || _damageThresholds[0].Value > 0f)
			{
				_damageThresholds.Insert(0, new DamageThreshold(0f, "None"));
			}
		}

		private void OnDamageChanged(DamageType type, float damage, int? playerId, bool healed, Vector3? localPosition, Vector3? localNormal)
		{
			int currentDamageThresholdLevel = CurrentDamageThresholdLevel;
			UpdateDamageThreshold();
			RaiseDamageEvent(type, damage, playerId, healed, localPosition, localNormal);
			RaiseDamageThresholdEvents(currentDamageThresholdLevel, CurrentDamageThresholdLevel);
		}

		private void RaiseDamageEvent(DamageType type, float damage, int? playerId, bool healed, Vector3? position, Vector3? normal)
		{
			(healed ? this.DamageHealed : this.DamageReceived)?.Invoke(this, new DamageEventArgs(type, damage, TotalDamage, playerId, position, normal));
		}

		private void RaiseDamageThresholdEvent(int previousLevel, int newLevel)
		{
			((newLevel > previousLevel) ? this.DamageThresholdReached : this.DamageThresholdReduced)?.Invoke(this, new DamageThresholdEventArgs(newLevel, _damageThresholds[newLevel], previousLevel, _damageThresholds[previousLevel]));
		}

		private void RaiseDamageThresholdEvents(int originalThreshold, int newThreshold)
		{
			if (newThreshold > originalThreshold)
			{
				for (int i = originalThreshold + 1; i <= newThreshold; i++)
				{
					RaiseDamageThresholdEvent(i - 1, i);
				}
				return;
			}
			for (int num = originalThreshold - 1; num >= newThreshold; num--)
			{
				RaiseDamageThresholdEvent(num + 1, num);
			}
		}

		private void UpdateDamageThreshold()
		{
			if (CurrentDamageThreshold.Value > TotalDamage)
			{
				for (int num = CurrentDamageThresholdLevel - 1; num >= 0; num--)
				{
					if (_damageThresholds[num].Value <= TotalDamage)
					{
						CurrentDamageThresholdLevel = num;
						break;
					}
				}
			}
			else
			{
				for (int i = CurrentDamageThresholdLevel + 1; i < _damageThresholds.Count && _damageThresholds[i].Value <= TotalDamage; i++)
				{
					CurrentDamageThresholdLevel = i;
				}
			}
		}
	}
}
