using UnityEngine;

namespace Polarith.AI.Package
{
	[AddComponentMenu("Polarith AI » Move » Package/Trigger State Transition")]
	public sealed class TriggerStateTransition : MonoBehaviour
	{
		public string TriggerType = "VehiclePhysics";

		[Tooltip("Value to which the Change parameter is set in 'OnTriggerExit'.")]
		public int Change;

		[Range(0f, 1f)]
		[Tooltip("Probability that a state transition happens.")]
		public float Probability = 0.5f;

		[Tooltip("If true, a value of -1 is passed to the triggering object's animator instead of Change as long as the other object stays in this collider.")]
		public bool IsBrakingZone = true;

		private void OnTriggerEnter(Collider collider)
		{
			if (!(collider.GetComponent(TriggerType) == null))
			{
				Animator componentInChildren = collider.GetComponentInChildren<Animator>();
				float num = Random.Range(0f, 1f);
				if (componentInChildren != null && num < Probability && IsBrakingZone)
				{
					componentInChildren.SetInteger("Change", -1);
				}
			}
		}

		private void OnTriggerExit(Collider collider)
		{
			if (!(collider.GetComponent(TriggerType) == null))
			{
				Animator componentInChildren = collider.GetComponentInChildren<Animator>();
				float num = Random.Range(0f, 1f);
				if (componentInChildren != null && num < Probability)
				{
					componentInChildren.SetInteger("Change", Change);
				}
			}
		}
	}
}
