using ModApi;
using ModApi.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts
{
	public class PartFlightCollision : IPartFlightCollision
	{
		private float? _cachedNormalVelocity;

		public Collision Collision { get; private set; }

		public ContactPoint Contact { get; private set; }

		public float Impulse { get; private set; }

		public bool IsGroundCollision { get; private set; }

		public float NormalVelocity
		{
			get
			{
				if (!_cachedNormalVelocity.HasValue)
				{
					_cachedNormalVelocity = Vector3.Dot(Collision.relativeVelocity, Contact.normal);
				}
				return _cachedNormalVelocity.Value;
			}
		}

		public int OtherColliderLayer { get; private set; }

		public IPartScript OtherPartScript { get; private set; }

		public IPartScript PartScript { get; private set; }

		public Vector3 RelativeVelocity { get; private set; }

		public float RelativeVelocityMagnitude { get; private set; }

		public PartFlightCollision(Collision collision, ContactPoint contact, IPartScript partScript)
		{
			Collision = collision;
			Contact = contact;
			PartScript = partScript;
			Impulse = collision.impulse.magnitude;
			RelativeVelocity = collision.relativeVelocity;
			RelativeVelocityMagnitude = collision.relativeVelocity.magnitude;
			OtherColliderLayer = contact.otherCollider.gameObject.layer;
			IsGroundCollision = Masks.IsLayerInMask(OtherColliderLayer, 603979776);
			if (!IsGroundCollision)
			{
				OtherPartScript = contact.otherCollider.GetComponentInParent<PartScript>();
			}
			Impulse *= Mathf.Clamp01(RelativeVelocityMagnitude / 15f);
		}

		public PartFlightCollision(float impulse, float relativeVelocity, IPartScript partScript)
		{
			PartScript = partScript;
			Impulse = impulse;
			RelativeVelocityMagnitude = relativeVelocity;
			Impulse *= Mathf.Clamp01(RelativeVelocityMagnitude / 15f);
		}
	}
}
