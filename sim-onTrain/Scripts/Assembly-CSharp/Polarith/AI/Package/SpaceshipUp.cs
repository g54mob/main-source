using UnityEngine;

namespace Polarith.AI.Package
{
	[AddComponentMenu("Polarith AI » Move » Package/Spaceship Up")]
	public sealed class SpaceshipUp : MonoBehaviour
	{
		private void OnTriggerStay(Collider other)
		{
			SpaceshipController componentInParent = other.gameObject.GetComponentInParent<SpaceshipController>();
			if (componentInParent != null)
			{
				Vector3 upVector = other.transform.position - base.transform.position;
				componentInParent.UpVector = upVector;
			}
		}

		private void OnTriggerExit(Collider other)
		{
			SpaceshipController componentInParent = other.gameObject.GetComponentInParent<SpaceshipController>();
			if (componentInParent != null)
			{
				componentInParent.UpVector = Vector3.up;
			}
		}
	}
}
