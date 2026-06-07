using System;
using Assets.Scripts.Flight.Damage;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.FlightObjects.Damage
{
	[Serializable]
	public class DamageHandlers
	{
		[SerializeField]
		[Tooltip("The damage handler used when cannon projectile damage is sustained.")]
		private DamageHandler _cannonProjectileDamage = new DamageHandler();

		[SerializeField]
		[Tooltip("The damage handler used when collision damage is sustained.")]
		private DamageHandler _collisionDamage = new DamageHandler();

		[SerializeField]
		[Tooltip("The damage handler used when explosive damage is sustained.")]
		private DamageHandler _explosionDamage = new DamageHandler();

		[SerializeField]
		[Tooltip("The damage handler used when standard bullet damage is sustained.")]
		private DamageHandler _standardBulletsDamage = new DamageHandler();

		[SerializeField]
		[Tooltip("The damage handler used when damage of an unknown type is sustained.")]
		private DamageHandler _unknownDamage = new DamageHandler();

		public DamageHandler CannonProjectileDamage
		{
			get
			{
				return _cannonProjectileDamage;
			}
			set
			{
				_cannonProjectileDamage = value;
			}
		}

		public DamageHandler CollisionDamage
		{
			get
			{
				return _collisionDamage;
			}
			set
			{
				_collisionDamage = value;
			}
		}

		public DamageHandler ExplosionDamage
		{
			get
			{
				return _explosionDamage;
			}
			set
			{
				_explosionDamage = value;
			}
		}

		public DamageHandler StandardBulletsDamage
		{
			get
			{
				return _standardBulletsDamage;
			}
			set
			{
				_standardBulletsDamage = value;
			}
		}

		public DamageHandler UnknownDamage
		{
			get
			{
				return _unknownDamage;
			}
			set
			{
				_unknownDamage = value;
			}
		}

		public DamageHandler this[DamageType damageType]
		{
			get
			{
				return damageType switch
				{
					DamageType.Unknown => _unknownDamage, 
					DamageType.Collision => _collisionDamage, 
					DamageType.Explosion => _explosionDamage, 
					DamageType.StandardBullets => _standardBulletsDamage, 
					DamageType.CannonProjectile => _cannonProjectileDamage, 
					_ => throw new NotSupportedException($"Unknown damage handler type: {damageType}"), 
				};
			}
			set
			{
				switch (damageType)
				{
				case DamageType.Unknown:
					_unknownDamage = value;
					break;
				case DamageType.Collision:
					_collisionDamage = value;
					break;
				case DamageType.Explosion:
					_explosionDamage = value;
					break;
				case DamageType.StandardBullets:
					_standardBulletsDamage = value;
					break;
				case DamageType.CannonProjectile:
					_cannonProjectileDamage = value;
					break;
				default:
					throw new NotSupportedException($"Unknown damage handler type: {damageType}");
				}
			}
		}
	}
}
