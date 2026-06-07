using UnityEngine;

namespace VRTK.Examples
{
	public class ModelVillage_TeleportLocation : VRTK_DestinationMarker
	{
		public Transform destination;

		private bool lastUsePressedState;

		private void OnTriggerStay(Collider collider)
		{
			VRTK_ControllerEvents vRTK_ControllerEvents = (collider.GetComponent<VRTK_ControllerEvents>() ? collider.GetComponent<VRTK_ControllerEvents>() : collider.GetComponentInParent<VRTK_ControllerEvents>());
			if (vRTK_ControllerEvents != null)
			{
				if (lastUsePressedState && !vRTK_ControllerEvents.triggerPressed)
				{
					float distance = Vector3.Distance(base.transform.position, destination.position);
					VRTK_ControllerReference controllerReference = VRTK_ControllerReference.GetControllerReference(vRTK_ControllerEvents.gameObject);
					OnDestinationMarkerSet(SetDestinationMarkerEvent(distance, destination, default(RaycastHit), destination.position, controllerReference));
				}
				lastUsePressedState = vRTK_ControllerEvents.triggerPressed;
			}
		}
	}
}
