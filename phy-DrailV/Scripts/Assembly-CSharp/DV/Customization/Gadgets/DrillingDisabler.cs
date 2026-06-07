using UnityEngine;

namespace DV.Customization.Gadgets
{
	public class DrillingDisabler : MonoBehaviour
	{
		[Tooltip("Whether or not to allow drilling for all child colliders. Overrides parent.")]
		public bool allowDrilling;

		public static bool IsDrillable(Collider collider)
		{
			DrillingDisabler componentInParent = collider.GetComponentInParent<DrillingDisabler>();
			if (!(componentInParent != null))
			{
				return true;
			}
			return componentInParent.allowDrilling;
		}
	}
}
