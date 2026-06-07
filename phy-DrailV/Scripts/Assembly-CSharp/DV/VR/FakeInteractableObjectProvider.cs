using DV.Interaction;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK.GrabAttachMechanics;

namespace DV.VR
{
	public class FakeInteractableObjectProvider : MonoBehaviour
	{
		private VRTK_InteractableObject_DV fakeInteractable;

		private void Awake()
		{
			GameObject gameObject = new GameObject("[fake grab object]");
			gameObject.SetActive(value: false);
			fakeInteractable = gameObject.AddComponent<VRTK_InteractableObject_DV>();
			fakeInteractable.holdButtonToGrab = false;
			fakeInteractable.disableWhenIdle = false;
			fakeInteractable.isGrabbable = true;
			VRTK_ChildOfControllerGrabAttach vRTK_ChildOfControllerGrabAttach = gameObject.AddComponent<VRTK_ChildOfControllerGrabAttach>();
			vRTK_ChildOfControllerGrabAttach.rightSnapHandle = gameObject.transform;
			vRTK_ChildOfControllerGrabAttach.leftSnapHandle = gameObject.transform;
			fakeInteractable.grabAttachMechanicScript = vRTK_ChildOfControllerGrabAttach;
			BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
			boxCollider.enabled = false;
			boxCollider.size = Vector3.one * 0.1f;
		}

		public void GrabFakeObject(HandPose pose)
		{
			UngrabFakeObject();
			fakeInteractable.interactionHandPoses = new InteractionHandPoses(HandPose.Generic, HandPose.Generic, pose);
			VRTK_InteractGrab_DV component = GetComponent<VRTK_InteractGrab_DV>();
			fakeInteractable.gameObject.SetActive(value: true);
			component.ForceGrabInteractable(fakeInteractable);
		}

		public void UngrabFakeObject()
		{
			if ((bool)fakeInteractable)
			{
				fakeInteractable.ForceStopInteracting();
				fakeInteractable.gameObject.SetActive(value: false);
			}
		}
	}
}
