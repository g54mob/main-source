using UnityEngine;

namespace Assets.Scripts.Flight.Damage
{
	public class DamageModifierScript : MonoBehaviour
	{
		[SerializeField]
		private float _bulletDamageMultiplier = 1f;

		[SerializeField]
		private float _collisionDamageMultiplier = 1f;

		[SerializeField]
		private float _explosionDamageMultiplier = 1f;

		public float BulletDamageMultiplier => _bulletDamageMultiplier;

		public float CollisionDamageMultiplier => _collisionDamageMultiplier;

		public float ExplosionDamageMultiplier => _explosionDamageMultiplier;
	}
}
