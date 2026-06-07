using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Assets.Scripts.Flight.Damage
{
	[Serializable]
	public class DamageHandlers
	{
		[SerializeField]
		[Tooltip("The damage handler used when collision damage is sustained.")]
		private CollisionDamageHandler _collisionDamage = new CollisionDamageHandler();

		[SerializeField]
		[FormerlySerializedAs("_exposionDamage")]
		[Tooltip("The damage handler used when explosive damage is sustained.")]
		private ExplosionDamageHandler _explosionDamage = new ExplosionDamageHandler();

		[SerializeField]
		[Tooltip("The damage handler used when standard bullet damage is sustained.")]
		private StandardBulletsDamageHandler _standardBulletsDamage = new StandardBulletsDamageHandler();

		[SerializeField]
		[Tooltip("The damage handler used when damage of an unknown type is sustained.")]
		private UnknownDamageHandler _unknownDamage = new UnknownDamageHandler();

		public CollisionDamageHandler CollisionDamage => _collisionDamage;

		public ExplosionDamageHandler ExplosionDamage => _explosionDamage;

		public StandardBulletsDamageHandler StandardBulletsDamage => _standardBulletsDamage;

		public UnknownDamageHandler UnknownDamage => _unknownDamage;
	}
}
