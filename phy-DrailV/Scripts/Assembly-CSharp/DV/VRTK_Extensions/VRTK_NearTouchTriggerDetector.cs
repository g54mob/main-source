using System;
using System.Linq;
using DV.Utils;
using UnityEngine;
using VRTK;

namespace DV.VRTK_Extensions
{
	public class VRTK_NearTouchTriggerDetector : MonoBehaviour
	{
		[NonSerialized]
		public VRTK_InteractNearTouch_DV nearTouch;

		private void Awake()
		{
			nearTouch = GetComponentInParent<VRTK_InteractNearTouch_DV>();
			if (nearTouch == null)
			{
				Debug.LogError("'VRTK_NearTouchTriggerDetector' requires a valid 'VRTK_InteractNearTouch_DV' reference. Destroying self.", base.gameObject);
				UnityEngine.Object.Destroy(this);
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
			var (flag, interactableObject) = OverlapCheck(collider);
			if (enteredOrStayed && flag)
			{
				nearTouch.UpdateNearTouchCollectionsExternal(add: true, interactableObject, collider);
			}
			else if (!enteredOrStayed)
			{
				nearTouch.UpdateNearTouchCollectionsExternal(add: false, interactableObject, collider);
			}
		}

		private (bool validOverlap, VRTK_InteractableObject_DV interactable) OverlapCheck(Collider collider)
		{
			if (collider == null)
			{
				return (validOverlap: false, interactable: null);
			}
			VRTK_InteractableObject_DV componentInParent = collider.GetComponentInParent<VRTK_InteractableObject_DV>();
			return (validOverlap: componentInParent != null && componentInParent.InteractionAllowed && collider.GetComponent<VRTK_SnapDropZone>() == null && (componentInParent.ignoredColliders == null || !componentInParent.ignoredColliders.Contains(collider)), interactable: componentInParent);
		}
	}
}
