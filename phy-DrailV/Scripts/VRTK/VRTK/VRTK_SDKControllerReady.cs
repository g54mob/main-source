using System;
using UnityEngine;

namespace VRTK
{
	public abstract class VRTK_SDKControllerReady : MonoBehaviour
	{
		protected SDK_BaseController previousControllerSDK;

		protected virtual void OnEnable()
		{
			VRTK_SDKManager.SubscribeLoadedSetupChanged(LoadedSetupChanged);
			CheckControllersReady();
		}

		protected virtual void OnDisable()
		{
			if (VRTK_SDKManager.UnsubscribeLoadedSetupChanged(LoadedSetupChanged))
			{
				UnregisterPreviousLeftController();
				UnregisterPreviousRightController();
			}
		}

		protected virtual void LoadedSetupChanged(VRTK_SDKManager sender, VRTK_SDKManager.LoadedSetupChangeEventArgs e)
		{
			CheckControllersReady();
			previousControllerSDK = VRTK_SDK_Bridge.GetControllerSDK();
		}

		protected virtual void CheckControllersReady()
		{
			RegisterLeftControllerReady();
			RegisterRightControllerReady();
			VRTK_ControllerReference controllerReferenceLeftHand = VRTK_DeviceFinder.GetControllerReferenceLeftHand();
			VRTK_ControllerReference controllerReferenceRightHand = VRTK_DeviceFinder.GetControllerReferenceRightHand();
			if (VRTK_ControllerReference.IsValid(controllerReferenceLeftHand))
			{
				ControllerReady(controllerReferenceLeftHand);
			}
			if (VRTK_ControllerReference.IsValid(controllerReferenceRightHand))
			{
				ControllerReady(controllerReferenceRightHand);
			}
		}

		protected virtual void UnregisterPreviousLeftController()
		{
			try
			{
				previousControllerSDK.LeftControllerReady -= LeftControllerReady;
			}
			catch (Exception)
			{
			}
		}

		protected virtual void UnregisterPreviousRightController()
		{
			try
			{
				previousControllerSDK.RightControllerReady -= RightControllerReady;
			}
			catch (Exception)
			{
			}
		}

		protected virtual void RegisterLeftControllerReady()
		{
			UnregisterPreviousLeftController();
			try
			{
				VRTK_SDK_Bridge.GetControllerSDK().LeftControllerReady -= LeftControllerReady;
				VRTK_SDK_Bridge.GetControllerSDK().LeftControllerReady += LeftControllerReady;
			}
			catch (Exception)
			{
				VRTK_SDK_Bridge.GetControllerSDK().LeftControllerReady += LeftControllerReady;
			}
		}

		protected virtual void RegisterRightControllerReady()
		{
			UnregisterPreviousRightController();
			try
			{
				VRTK_SDK_Bridge.GetControllerSDK().RightControllerReady -= RightControllerReady;
				VRTK_SDK_Bridge.GetControllerSDK().RightControllerReady += RightControllerReady;
			}
			catch (Exception)
			{
				VRTK_SDK_Bridge.GetControllerSDK().RightControllerReady += RightControllerReady;
			}
		}

		protected virtual void RightControllerReady(object sender, VRTKSDKBaseControllerEventArgs e)
		{
			ControllerReady(e.controllerReference);
		}

		protected virtual void LeftControllerReady(object sender, VRTKSDKBaseControllerEventArgs e)
		{
			ControllerReady(e.controllerReference);
		}

		protected virtual void ControllerReady(VRTK_ControllerReference controllerReference)
		{
		}
	}
}
