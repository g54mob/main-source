using System.Collections.Generic;
using UnityEngine;

namespace VRTK
{
	public class VRTK_InteractNearTouchCollider : MonoBehaviour
	{
		protected VRTK_InteractNearTouch interactNearTouch;

		protected List<GameObject> nearTouchedObjects = new List<GameObject>();

		public virtual void SetInteractNearTouch(VRTK_InteractNearTouch givenInteractNearTouch)
		{
			interactNearTouch = givenInteractNearTouch;
		}

		public virtual List<GameObject> GetNearTouchedObjects()
		{
			return nearTouchedObjects;
		}

		public virtual void StartNearTouch(Collider collider)
		{
			VRTK_InteractableObject componentInParent = collider.gameObject.GetComponentInParent<VRTK_InteractableObject>();
			if (!VRTK_PlayerObject.IsPlayerObject(collider.gameObject) && validObject(componentInParent))
			{
				if (componentInParent != null)
				{
					componentInParent.StartNearTouching(interactNearTouch);
				}
				interactNearTouch.OnControllerNearTouchInteractableObject(interactNearTouch.interactTouch.SetControllerInteractEvent(collider.gameObject));
			}
		}

		public virtual void EndNearTouch(Collider collider)
		{
			VRTK_InteractableObject componentInParent = collider.gameObject.GetComponentInParent<VRTK_InteractableObject>();
			if (!VRTK_PlayerObject.IsPlayerObject(collider.gameObject) && validObject(componentInParent))
			{
				if (componentInParent != null)
				{
					componentInParent.StopNearTouching(interactNearTouch);
				}
				interactNearTouch.OnControllerNearUntouchInteractableObject(interactNearTouch.interactTouch.SetControllerInteractEvent(collider.gameObject));
			}
		}

		protected virtual void OnTriggerEnter(Collider collider)
		{
			StartNearTouch(collider);
			VRTK_SharedMethods.AddListValue(nearTouchedObjects, collider.gameObject, preventDuplicates: true);
		}

		protected virtual void OnTriggerExit(Collider collider)
		{
			EndNearTouch(collider);
			nearTouchedObjects.Remove(collider.gameObject);
		}

		protected virtual void OnEnable()
		{
			nearTouchedObjects.Clear();
		}

		protected virtual bool validObject(VRTK_InteractableObject checkObject)
		{
			if (!(checkObject == null))
			{
				return checkObject.IsValidInteractableController(interactNearTouch.interactTouch.gameObject, checkObject.allowedNearTouchControllers);
			}
			return true;
		}
	}
}
