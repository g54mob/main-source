using Assets.Scripts.CustomWheelCollider;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class ResizableWheelColliderScript : MonoBehaviour
	{
		public Collider Collider { get; set; }

		public Collider EscaperCollider { get; set; }

		public ResizableWheelCollider WheelCollider { get; set; }

		private void OnCollisionEnter(Collision collision)
		{
			for (int i = 0; i < collision.contacts.Length; i++)
			{
				ContactPoint contactPoint = collision.contacts[i];
				if (contactPoint.otherCollider.gameObject.layer == 31 && contactPoint.thisCollider == Collider && contactPoint.separation < -0.05f)
				{
					Physics.IgnoreCollision(contactPoint.thisCollider, contactPoint.otherCollider);
					if (EscaperCollider != null)
					{
						Physics.IgnoreCollision(EscaperCollider, contactPoint.otherCollider);
					}
					break;
				}
			}
		}

		private void OnCollisionStay(Collision collision)
		{
			for (int i = 0; i < collision.contacts.Length; i++)
			{
				ContactPoint contactPoint = collision.contacts[i];
				if (contactPoint.thisCollider == Collider)
				{
					if (contactPoint.separation > -0.05f)
					{
						WheelCollider.SetWheelStateGrounded(contactPoint.otherCollider, contactPoint.normal, contactPoint.point, contactPoint.otherCollider.gameObject.layer == 31);
					}
					break;
				}
			}
		}
	}
}
