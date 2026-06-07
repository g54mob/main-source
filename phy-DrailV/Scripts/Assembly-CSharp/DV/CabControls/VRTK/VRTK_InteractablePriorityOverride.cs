using UnityEngine;

namespace DV.CabControls.VRTK
{
	public class VRTK_InteractablePriorityOverride : MonoBehaviour
	{
		[SerializeField]
		private int priority;

		private void Start()
		{
			VRTK_ControlImplBaseInteractableObject component = GetComponent<VRTK_ControlImplBaseInteractableObject>();
			if (component != null)
			{
				component.priority = priority;
			}
			Object.Destroy(this);
		}
	}
}
