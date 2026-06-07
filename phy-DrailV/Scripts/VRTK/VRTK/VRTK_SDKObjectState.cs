using System.Collections;
using System.Reflection;
using UnityEngine;

namespace VRTK
{
	[AddComponentMenu("VRTK/Scripts/Utilities/VRTK_SDKObjectState")]
	public class VRTK_SDKObjectState : VRTK_SDKControllerReady
	{
		[Header("Target Settings")]
		[Tooltip("The GameObject or Component that is the target of the enable/disable action. If this is left blank then the GameObject that the script is attached to will be used as the `Target`.")]
		public Object target;

		[Tooltip("The state to set the `Target` to when this script is enabled. Checking this box will enable/activate the `Target`, unchecking will disable/deactivate the `Target`.")]
		public bool objectState;

		[Tooltip("If the currently loaded SDK Setup matches the one provided here then the `Target` state will be set to the desired `Object State`.")]
		public VRTK_SDKSetup loadedSDKSetup;

		[Tooltip("If the attached headset type matches the selected headset then the `Target` state will be set to the desired `Object State`.")]
		public SDK_BaseHeadset.HeadsetType headsetType;

		[Tooltip("If the current controller type matches the selected controller type then the `Target` state will be set to the desired `Object State`.")]
		public SDK_BaseController.ControllerType controllerType;

		protected Coroutine checkToggleRoutine;

		public virtual void SetStateByControllerReference(VRTK_ControllerReference controllerReference)
		{
			if (VRTK_ControllerReference.IsValid(controllerReference))
			{
				SDK_BaseController.ControllerType currentControllerType = VRTK_DeviceFinder.GetCurrentControllerType(controllerReference);
				if (currentControllerType != SDK_BaseController.ControllerType.Undefined && controllerType == currentControllerType)
				{
					ToggleObject();
				}
			}
		}

		protected override void OnEnable()
		{
			target = ((target != null) ? target : base.gameObject);
			base.OnEnable();
			checkToggleRoutine = StartCoroutine(CheckToggleAtEndOfFrame());
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			if (checkToggleRoutine != null)
			{
				StopCoroutine(checkToggleRoutine);
			}
		}

		protected override void ControllerReady(VRTK_ControllerReference controllerReference)
		{
			ToggleOnController(controllerReference);
		}

		protected virtual IEnumerator CheckToggleAtEndOfFrame()
		{
			yield return new WaitForEndOfFrame();
			CheckToggle();
		}

		protected virtual void CheckToggle()
		{
			ToggleOnSDK();
			ToggleOnHeadset();
		}

		protected virtual void ToggleOnSDK()
		{
			if (loadedSDKSetup != null && loadedSDKSetup == VRTK_SDKManager.GetLoadedSDKSetup())
			{
				ToggleObject();
			}
		}

		protected virtual void ToggleOnHeadset()
		{
			if (headsetType != SDK_BaseHeadset.HeadsetType.Undefined && headsetType == VRTK_DeviceFinder.GetHeadsetType())
			{
				ToggleObject();
			}
		}

		protected virtual void ToggleOnController(VRTK_ControllerReference controllerReference)
		{
			if (controllerType != SDK_BaseController.ControllerType.Undefined)
			{
				SDK_BaseController.ControllerType currentControllerType = VRTK_DeviceFinder.GetCurrentControllerType(controllerReference);
				if (currentControllerType != SDK_BaseController.ControllerType.Undefined && controllerType == currentControllerType)
				{
					ToggleObject();
				}
			}
		}

		protected virtual void ToggleObject()
		{
			if (target is GameObject)
			{
				ToggleGameObject();
			}
			else if (VRTK_SharedMethods.IsTypeSubclassOf(target.GetType(), typeof(Component)))
			{
				ToggleComponent();
			}
		}

		protected virtual void ToggleGameObject()
		{
			if (target != null)
			{
				((GameObject)target).SetActive(objectState);
			}
		}

		protected virtual void ToggleComponent()
		{
			if (target != null)
			{
				Component component = (Component)target;
				PropertyInfo property = component.GetType().GetProperty("enabled");
				if (property != null)
				{
					property.SetValue(component, objectState, null);
				}
			}
		}
	}
}
