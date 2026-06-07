using Assets.Scripts.Multiplayer;
using FishNet.Object;
using UnityEngine;

namespace Assets.Scripts.Flight.Damage
{
	public class DamageableBody : DamageableObject
	{
		private Rigidbody _rigidBody;

		public override Rigidbody RigidBody => _rigidBody;

		protected virtual void Awake()
		{
			_rigidBody = GetComponent<Rigidbody>();
		}

		protected virtual void OnCollisionEnter(Collision collision)
		{
			if (base.DamageHandlers?.CollisionDamage == null || base.DamageHandlers.CollisionDamage.IgnoreDamage() || collision.contactCount <= 0)
			{
				return;
			}
			float num = 0f;
			ContactPoint contactPoint = collision.GetContact(0);
			for (int i = 0; i < collision.contactCount; i++)
			{
				ContactPoint contact = collision.GetContact(i);
				float num2 = Mathf.Abs(Vector3.Dot(contact.normal, collision.relativeVelocity));
				if (num2 > num)
				{
					num = num2;
					contactPoint = contact;
				}
			}
			DamageModifierScript component = contactPoint.otherCollider.GetComponent<DamageModifierScript>();
			float num3 = ((component == null) ? 1f : component.CollisionDamageMultiplier);
			float damage = num * num3;
			int? playerId = (collision.gameObject.GetComponentInParent<NetworkBehaviour>() as NetworkPlayerScript)?.PlayerId;
			OnDamageReceived(DamageType.Collision, damage, playerId, contactPoint.point, contactPoint.normal);
		}
	}
}
