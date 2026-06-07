using UnityEngine;

namespace VRTK.Examples
{
	public class Lamp : VRTK_InteractableObject
	{
		public override void Grabbed(VRTK_InteractGrab grabbingObject)
		{
			base.Grabbed(grabbingObject);
			ToggleKinematics(state: false);
		}

		public override void Ungrabbed(VRTK_InteractGrab previousGrabbingObject)
		{
			base.Ungrabbed(previousGrabbingObject);
			ToggleKinematics(state: true);
		}

		private void ToggleKinematics(bool state)
		{
			Rigidbody[] componentsInChildren = base.transform.parent.GetComponentsInChildren<Rigidbody>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].isKinematic = state;
			}
		}
	}
}
