using Polarith.AI.Move;
using UnityEngine;

namespace Polarith.AI.Package
{
	[AddComponentMenu("Polarith AI » Move » Package/Trigger Arrive Target")]
	public sealed class TriggerArriveTarget : MonoBehaviour
	{
		public string TriggerType = "VehiclePhysics";

		private GameObject previous;

		private void OnTriggerEnter(Collider collision)
		{
			Transform transform = collision.transform;
			if (!(transform.GetComponent(TriggerType) == null))
			{
				AIMArrive componentInChildren = transform.GetComponentInChildren<AIMArrive>();
				if (previous != null && componentInChildren != null)
				{
					componentInChildren.Target = previous;
				}
			}
		}

		private void OnTriggerExit(Collider collision)
		{
			Transform transform = collision.transform;
			if (!(transform.GetComponent(TriggerType) == null))
			{
				previous = transform.gameObject;
			}
		}
	}
}
