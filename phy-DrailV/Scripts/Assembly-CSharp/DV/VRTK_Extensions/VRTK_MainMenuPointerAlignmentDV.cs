using UnityEngine;
using VRTK;

namespace DV.VRTK_Extensions
{
	public class VRTK_MainMenuPointerAlignmentDV : MonoBehaviour
	{
		[SerializeField]
		private Transform pointerTransform;

		private void Awake()
		{
			if ((bool)VRTK_SDKManager.GetLoadedSDKSetup() && VRTK_SDKManager.GetLoadedSDKSetup().systemSDK.GetType() == typeof(SDK_OculusSystem))
			{
				Object.Destroy(this);
				return;
			}
			VRTK_SDKManager.SubscribeLoadedSetupChanged(SDKChanged);
			if (!(pointerTransform != null))
			{
				Debug.LogError("VRTK_MainMenuPointerAlignmentDV: Pointer transform is not set! Destroying self...", base.gameObject);
				Object.Destroy(this);
			}
		}

		private void SDKChanged(VRTK_SDKManager sender, VRTK_SDKManager.LoadedSetupChangeEventArgs e)
		{
			if ((bool)e.currentSetup && e.currentSetup.systemSDK.GetType() == typeof(SDK_OculusSystem))
			{
				Object.Destroy(this);
			}
		}

		private void Update()
		{
			VRTK_ControllerReference controllerReferenceForHand = VRTK_DeviceFinder.GetControllerReferenceForHand(VRTK_DeviceFinder.GetControllerHand(base.transform.parent.gameObject));
			if (controllerReferenceForHand != null && controllerReferenceForHand.IsValid())
			{
				Transform transform = controllerReferenceForHand.model.transform.Find(VRTK_SDK_Bridge.GetControllerElementPath(SDK_BaseController.ControllerElements.AttachPoint, controllerReferenceForHand.hand));
				if (!(transform == null))
				{
					pointerTransform.position = transform.position;
					pointerTransform.rotation = transform.rotation;
				}
			}
		}
	}
}
