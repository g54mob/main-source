using DV.Utils;
using UnityEngine;
using VRTK;

namespace DV.VRTK_Extensions
{
	public class VRTK_TouchTriggerDetector : MonoBehaviour
	{
		public bool pipaExclusive;

		private VRTK_InteractTouch_DV touch;

		private void Awake()
		{
			touch = GetComponentInParent<VRTK_InteractTouch_DV>();
			if (touch == null)
			{
				Debug.LogError("'VRTK_TouchTriggerDetector' requires a valid 'VRTK_InteractTouch_DV' reference. Destroying self.", base.gameObject);
				Object.Destroy(this);
			}
		}

		private void OnTriggerEnter(Collider collider)
		{
			ReliableOnTriggerExit.NotifyTriggerEnter(collider, base.gameObject, OnTriggerExit);
			UpdateOverlapCacheOnTrigger(collider, enteredOrStayed: true);
		}

		private void OnTriggerStay(Collider collider)
		{
			UpdateOverlapCacheOnTrigger(collider, enteredOrStayed: true);
		}

		private void OnTriggerExit(Collider collider)
		{
			ReliableOnTriggerExit.NotifyTriggerExit(collider, base.gameObject);
			UpdateOverlapCacheOnTrigger(collider, enteredOrStayed: false);
		}

		private void UpdateOverlapCacheOnTrigger(Collider collider, bool enteredOrStayed)
		{
			if (collider == null)
			{
				touch.touchedInteractables.RemoveWhere((VRTK_InteractableObject_DV t) => t == null);
				return;
			}
			var (flag, item) = OverlapCheck(collider);
			if (flag)
			{
				if (enteredOrStayed)
				{
					touch.touchedInteractables.Add(item);
				}
				else
				{
					touch.touchedInteractables.Remove(item);
				}
			}
		}

		private (bool validOverlap, VRTK_InteractableObject_DV interactable) OverlapCheck(Collider collider)
		{
			if (collider == null)
			{
				return (validOverlap: false, interactable: null);
			}
			VRTK_InteractableObject_DV componentInParentIncludingInactive = collider.transform.GetComponentInParentIncludingInactive<VRTK_InteractableObject_DV>();
			VRTK_SnapDropZone component;
			return (validOverlap: (object)componentInParentIncludingInactive != null && componentInParentIncludingInactive.InteractionAllowed && (!componentInParentIncludingInactive.pipaExclusiveInteraction || pipaExclusive == componentInParentIncludingInactive.pipaExclusiveInteraction) && !collider.TryGetComponent<VRTK_SnapDropZone>(out component), interactable: componentInParentIncludingInactive);
		}
	}
}
