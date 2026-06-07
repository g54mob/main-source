using UnityEngine;

namespace VRTK.Examples
{
	public class InteractableLamp : MonoBehaviour
	{
		public VRTK_InteractableObject linkedObject;

		protected Rigidbody[] lampRigidbodies = new Rigidbody[0];

		protected virtual void OnEnable()
		{
			linkedObject = ((linkedObject == null) ? GetComponent<VRTK_InteractableObject>() : linkedObject);
			if (linkedObject != null)
			{
				linkedObject.InteractableObjectGrabbed += InteractableObjectGrabbed;
				linkedObject.InteractableObjectUngrabbed += InteractableObjectUngrabbed;
			}
			lampRigidbodies = base.transform.parent.GetComponentsInChildren<Rigidbody>();
		}

		protected virtual void OnDisable()
		{
			if (linkedObject != null)
			{
				linkedObject.InteractableObjectGrabbed -= InteractableObjectGrabbed;
				linkedObject.InteractableObjectUngrabbed -= InteractableObjectUngrabbed;
			}
		}

		protected virtual void InteractableObjectUngrabbed(object sender, InteractableObjectEventArgs e)
		{
			ToggleKinematics(state: true);
		}

		protected virtual void InteractableObjectGrabbed(object sender, InteractableObjectEventArgs e)
		{
			ToggleKinematics(state: false);
		}

		protected virtual void ToggleKinematics(bool state)
		{
			Rigidbody[] array = lampRigidbodies;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].isKinematic = state;
			}
		}
	}
}
