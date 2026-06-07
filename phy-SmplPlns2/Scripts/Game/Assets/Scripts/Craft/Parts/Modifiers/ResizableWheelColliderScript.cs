using Assets.Scripts.Flight.Simulation.CustomWheelCollider;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class ResizableWheelColliderScript : MonoBehaviour
	{
		public Collider Collider { get; set; }

		public ResizableWheelCollider WheelCollider { get; set; }

		protected virtual void OnCollisionStay(Collision collision)
		{
			for (int i = 0; i < collision.contactCount; i++)
			{
				ContactPoint contact = collision.GetContact(i);
				if (contact.thisCollider == Collider)
				{
					WheelCollider.SetWheelStateGrounded(contact.otherCollider, contact.normal);
					break;
				}
			}
		}
	}
}
