using UnityEngine;

namespace Assets.Scripts.Flight.Damage
{
	public interface IDamageableObject
	{
		Rigidbody RigidBody { get; }

		void OnDamageReceived(DamageType type, float damage, int? playerId, Vector3? position = null, Vector3? normal = null);

		void OnExplosiveForce(float force, int? playerId, Vector3 position, Vector3? normal);

		void OnStandardBulletHit(float damage, int? playerId, Vector3 hitLocation, Vector3 hitNormal);
	}
}
