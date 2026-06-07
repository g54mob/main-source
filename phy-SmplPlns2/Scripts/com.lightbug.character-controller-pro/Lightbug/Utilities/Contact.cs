using UnityEngine;

namespace Lightbug.Utilities
{
	public readonly struct Contact
	{
		public readonly bool firstContact;

		public readonly Vector3 point;

		public readonly Vector3 normal;

		public readonly Collider2D collider2D;

		public readonly Collider collider3D;

		public readonly bool isRigidbody;

		public readonly bool isKinematicRigidbody;

		public readonly Vector3 relativeVelocity;

		public readonly Vector3 pointVelocity;

		public readonly GameObject gameObject;

		public Contact(bool firstContact, ContactPoint2D contact, Collision2D collision)
		{
			this = default(Contact);
			this.firstContact = firstContact;
			collider2D = contact.collider;
			point = contact.point;
			normal = contact.normal;
			gameObject = collider2D.gameObject;
			Rigidbody2D attachedRigidbody = collider2D.attachedRigidbody;
			relativeVelocity = collision.relativeVelocity;
			if (isRigidbody = attachedRigidbody != null)
			{
				isKinematicRigidbody = attachedRigidbody.bodyType == RigidbodyType2D.Kinematic;
				pointVelocity = attachedRigidbody.GetPointVelocity(point);
			}
		}

		public Contact(bool firstContact, ContactPoint contact, Collision collision)
		{
			this = default(Contact);
			this.firstContact = firstContact;
			collider3D = contact.otherCollider;
			point = contact.point;
			normal = contact.normal;
			gameObject = collider3D.gameObject;
			Rigidbody attachedRigidbody = collider3D.attachedRigidbody;
			relativeVelocity = collision.relativeVelocity;
			if (isRigidbody = attachedRigidbody != null)
			{
				isKinematicRigidbody = attachedRigidbody.isKinematic;
				pointVelocity = attachedRigidbody.GetPointVelocity(point);
			}
		}

		public Contact(Vector3 point, Vector3 normal, Vector3 pointVelocity, Vector3 relativeVelocity)
		{
			this = default(Contact);
			this.point = point;
			this.normal = normal;
			this.pointVelocity = pointVelocity;
			this.relativeVelocity = relativeVelocity;
		}
	}
}
