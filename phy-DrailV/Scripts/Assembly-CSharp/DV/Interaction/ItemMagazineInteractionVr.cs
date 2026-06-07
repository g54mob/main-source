using System;
using System.Collections;
using DV.InventorySystem;
using DV.Items;
using DV.Utils;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;
using VRTK.GrabAttachMechanics;

namespace DV.Interaction
{
	public class ItemMagazineInteractionVr : MonoBehaviour
	{
		private Action UnloadMethod;

		private VRTK_InteractableObject_DV interactableObject;

		private ItemMagazine magazine;

		private GameObject interactionPoint;

		private Coroutine delayedGrabVRCoro;

		private bool unloadSpentOnly;

		private bool initialized;

		public void Initialize(ItemMagazine magazine, GameObject interactionPoint, Action unloadMethod, bool unloadSpentOnly)
		{
			if (initialized)
			{
				return;
			}
			this.magazine = magazine;
			if (this.magazine == null)
			{
				Debug.LogError("ItemMagazineInteractionVr: Missing ItemMagazine. Destroying self.", base.gameObject);
				UnityEngine.Object.Destroy(this);
				return;
			}
			this.interactionPoint = interactionPoint;
			if (this.interactionPoint == null)
			{
				Debug.LogError("ItemMagazineInteractionVr: Missing interaction point. Destroying self.", base.gameObject);
				UnityEngine.Object.Destroy(this);
				return;
			}
			UnloadMethod = unloadMethod;
			if (UnloadMethod == null)
			{
				Debug.LogError("ItemMagazineInteractionVr: Missing unload method. Destroying self.", base.gameObject);
				UnityEngine.Object.Destroy(this);
				return;
			}
			this.unloadSpentOnly = unloadSpentOnly;
			Rigidbody rigidbody = interactionPoint.AddComponent<Rigidbody>();
			interactableObject = interactionPoint.AddComponent<VRTK_InteractableObject_DV>();
			rigidbody.isKinematic = true;
			interactableObject.interactionHandPoses = new InteractionHandPoses
			{
				grabPose = HandPose.Grab,
				nearTouchPose = HandPose.PreGrab,
				touchPose = HandPose.PreGrab
			};
			interactionPoint.AddComponent<SphereCollider>().radius = 0.06f;
			interactableObject.grabAttachMechanicScript = base.gameObject.AddComponent<VRTK_TrackObjectGrabAttach>();
			interactableObject.isGrabbable = true;
			SetupListeners(on: true);
			base.gameObject.SetActive(value: false);
			initialized = true;
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading)
			{
				if (delayedGrabVRCoro != null)
				{
					SingletonBehaviour<CoroutineManager>.Instance.Stop(delayedGrabVRCoro);
				}
				SetupListeners(on: false);
			}
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				interactableObject.InteractableObjectGrabbed += UnloadVR;
				magazine.ItemContainerDataChanged += MagazineDataChanged;
				return;
			}
			if (interactableObject != null)
			{
				interactableObject.InteractableObjectGrabbed -= UnloadVR;
			}
			if (magazine != null)
			{
				magazine.ItemContainerDataChanged -= MagazineDataChanged;
			}
		}

		private void MagazineDataChanged(AItemContainer container, int sourceIndex, int destinationIndex)
		{
			GameObject gameObject = magazine[0];
			MagazineAmmo magazineAmmo = ((gameObject != null) ? gameObject.GetComponent<MagazineAmmo>() : null);
			bool active = magazineAmmo != null && (!unloadSpentOnly || magazineAmmo.isSpent);
			base.gameObject.SetActive(active);
		}

		private void UnloadVR(object _, InteractableObjectEventArgs __)
		{
			if (!(magazine[0] == null))
			{
				if (delayedGrabVRCoro != null)
				{
					SingletonBehaviour<CoroutineManager>.Instance.Stop(delayedGrabVRCoro);
				}
				delayedGrabVRCoro = SingletonBehaviour<CoroutineManager>.Instance.StartCoroutine(DelayedUnload());
			}
		}

		private IEnumerator DelayedUnload()
		{
			VRTK_InteractGrab_DV grab = interactableObject.GetGrabbingObject().GetComponent<VRTK_InteractGrab_DV>();
			yield return WaitFor.EndOfFrame;
			interactableObject.ForceStopAllInteractions_Public();
			yield return null;
			GameObject gameObject = magazine[0].gameObject;
			if (gameObject == null)
			{
				delayedGrabVRCoro = null;
				yield break;
			}
			UnloadMethod();
			HapticUtils.DoHapticPulse(VRTK_ControllerReference.GetControllerReference(grab.gameObject), HapticIntensityType.Strong);
			grab.ForceGrabInteractable(gameObject, usingGrabButton: true);
			delayedGrabVRCoro = null;
		}
	}
}
