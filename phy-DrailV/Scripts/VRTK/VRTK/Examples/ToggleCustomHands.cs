using UnityEngine;

namespace VRTK.Examples
{
	public class ToggleCustomHands : MonoBehaviour
	{
		public VRTK_ControllerEvents leftController;

		public VRTK_ControllerEvents rightController;

		public GameObject leftHandAvatar;

		public GameObject rightHandAvatar;

		protected bool state;

		protected virtual void OnEnable()
		{
			state = false;
			if (leftController != null)
			{
				leftController.ButtonTwoPressed += ToggleHands;
			}
			if (rightController != null)
			{
				rightController.ButtonTwoPressed += ToggleHands;
			}
			ToggleVisibility();
		}

		protected virtual void OnDisable()
		{
			if (leftController != null)
			{
				leftController.ButtonTwoPressed -= ToggleHands;
			}
			if (rightController != null)
			{
				rightController.ButtonTwoPressed -= ToggleHands;
			}
		}

		protected virtual void ToggleHands(object sender, ControllerInteractionEventArgs e)
		{
			state = !state;
			ToggleVisibility();
		}

		protected virtual void ToggleVisibility()
		{
			ToggleAvatarVisibility();
			ToggleSDKVisibility();
			ToggleScriptAlias();
		}

		protected virtual void ToggleAvatarVisibility()
		{
			if (leftHandAvatar != null)
			{
				leftHandAvatar.SetActive(state);
			}
			if (rightHandAvatar != null)
			{
				rightHandAvatar.SetActive(state);
			}
		}

		protected virtual void ToggleSDKVisibility()
		{
			VRTK_SDKSetup loadedSDKSetup = VRTK_SDKManager.GetLoadedSDKSetup();
			if (loadedSDKSetup != null)
			{
				VRTK_ControllerReference controllerReference = VRTK_ControllerReference.GetControllerReference(VRTK_DeviceFinder.GetControllerLeftHand(getActual: true));
				VRTK_ControllerReference controllerReference2 = VRTK_ControllerReference.GetControllerReference(VRTK_DeviceFinder.GetControllerRightHand(getActual: true));
				switch (loadedSDKSetup.name)
				{
				case "SteamVR":
					ToggleControllerRenderer(controllerReference.actual, "Model");
					ToggleControllerRenderer(controllerReference2.actual, "Model");
					break;
				case "Oculus":
					ToggleControllerRenderer(controllerReference.model);
					ToggleControllerRenderer(controllerReference2.model);
					break;
				case "WindowsMR":
					ToggleControllerRenderer(controllerReference.model, "glTFController");
					ToggleControllerRenderer(controllerReference2.model, "glTFController");
					break;
				}
			}
		}

		protected virtual void ToggleControllerRenderer(GameObject controller, string findPath = "")
		{
			if (!(controller != null))
			{
				return;
			}
			if (findPath == "")
			{
				controller.SetActive(!state);
				return;
			}
			Transform transform = controller.transform.Find(findPath);
			if (transform != null)
			{
				transform.gameObject.SetActive(!state);
			}
		}

		protected virtual void ToggleScriptAlias()
		{
			GameObject controllerLeftHand = VRTK_DeviceFinder.GetControllerLeftHand();
			GameObject controllerRightHand = VRTK_DeviceFinder.GetControllerRightHand();
			CycleScriptAlias(controllerLeftHand, leftHandAvatar);
			CycleScriptAlias(controllerRightHand, rightHandAvatar);
		}

		protected virtual void CycleScriptAlias(GameObject controller, GameObject avatar)
		{
			if (controller != null)
			{
				VRTK_InteractTouch componentInChildren = controller.GetComponentInChildren<VRTK_InteractTouch>();
				VRTK_InteractGrab componentInChildren2 = controller.GetComponentInChildren<VRTK_InteractGrab>();
				componentInChildren.enabled = false;
				componentInChildren2.enabled = false;
				componentInChildren.customColliderContainer = null;
				componentInChildren2.ForceControllerAttachPoint(null);
				if (avatar != null && state)
				{
					componentInChildren.customColliderContainer = avatar.transform.Find("HandColliders").gameObject;
					componentInChildren2.ForceControllerAttachPoint(avatar.transform.Find("GrabAttachPoint").GetComponent<Rigidbody>());
				}
				componentInChildren.enabled = true;
				componentInChildren2.enabled = true;
			}
		}
	}
}
