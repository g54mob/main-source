using System;
using UnityEngine;
using UnityEngine.XR;

namespace VRTK
{
	public static class VRTK_DeviceFinder
	{
		public enum Devices
		{
			Headset = 0,
			LeftController = 1,
			RightController = 2
		}

		[Obsolete("`VRTK_DeviceFinder.Headsets` has been deprecated and has been replaced with a manufacturer string. This enum will be removed in a future version of VRTK.")]
		public enum Headsets
		{
			Unknown = 0,
			OculusRift = 1,
			OculusRiftCV1 = 2,
			Vive = 3,
			ViveMV = 4,
			ViveDVT = 5,
			OculusRiftES07 = 6
		}

		private static string cachedHeadsetType = "";

		public static SDK_BaseController.ControllerType GetCurrentControllerType(VRTK_ControllerReference controllerReference = null)
		{
			return VRTK_SDK_Bridge.GetCurrentControllerType(controllerReference);
		}

		public static uint GetControllerIndex(GameObject controller)
		{
			return VRTK_SDK_Bridge.GetControllerIndex(controller);
		}

		public static GameObject GetControllerByIndex(uint index, bool getActual)
		{
			return VRTK_SDK_Bridge.GetControllerByIndex(index, getActual);
		}

		public static Transform GetControllerOrigin(VRTK_ControllerReference controllerReference)
		{
			return VRTK_SDK_Bridge.GetControllerOrigin(controllerReference);
		}

		public static Transform DeviceTransform(Devices device)
		{
			switch (device)
			{
			case Devices.Headset:
				return HeadsetTransform();
			case Devices.LeftController:
				return GetControllerLeftHand().transform;
			case Devices.RightController:
				return GetControllerRightHand().transform;
			default:
				return null;
			}
		}

		public static SDK_BaseController.ControllerHand GetControllerHandType(string hand)
		{
			string text = hand.ToLower();
			if (!(text == "left"))
			{
				if (text == "right")
				{
					return SDK_BaseController.ControllerHand.Right;
				}
				return SDK_BaseController.ControllerHand.None;
			}
			return SDK_BaseController.ControllerHand.Left;
		}

		public static SDK_BaseController.ControllerHand GetControllerHand(GameObject controller)
		{
			if (VRTK_SDK_Bridge.IsControllerLeftHand(controller))
			{
				return SDK_BaseController.ControllerHand.Left;
			}
			if (VRTK_SDK_Bridge.IsControllerRightHand(controller))
			{
				return SDK_BaseController.ControllerHand.Right;
			}
			return SDK_BaseController.ControllerHand.None;
		}

		public static GameObject GetControllerLeftHand(bool getActual = false)
		{
			return VRTK_SDK_Bridge.GetControllerLeftHand(getActual);
		}

		public static GameObject GetControllerRightHand(bool getActual = false)
		{
			return VRTK_SDK_Bridge.GetControllerRightHand(getActual);
		}

		public static VRTK_ControllerReference GetControllerReferenceLeftHand()
		{
			return VRTK_ControllerReference.GetControllerReference(SDK_BaseController.ControllerHand.Left);
		}

		public static VRTK_ControllerReference GetControllerReferenceRightHand()
		{
			return VRTK_ControllerReference.GetControllerReference(SDK_BaseController.ControllerHand.Right);
		}

		public static VRTK_ControllerReference GetControllerReferenceForHand(SDK_BaseController.ControllerHand hand)
		{
			return VRTK_ControllerReference.GetControllerReference(hand);
		}

		public static bool IsControllerOfHand(GameObject checkController, SDK_BaseController.ControllerHand hand)
		{
			switch (hand)
			{
			case SDK_BaseController.ControllerHand.Left:
				return IsControllerLeftHand(checkController);
			case SDK_BaseController.ControllerHand.Right:
				return IsControllerRightHand(checkController);
			default:
				return false;
			}
		}

		public static bool IsControllerLeftHand(GameObject checkController)
		{
			return VRTK_SDK_Bridge.IsControllerLeftHand(checkController);
		}

		public static bool IsControllerRightHand(GameObject checkController)
		{
			return VRTK_SDK_Bridge.IsControllerRightHand(checkController);
		}

		public static SDK_BaseController.ControllerHand GetOppositeHand(SDK_BaseController.ControllerHand currentHand)
		{
			switch (currentHand)
			{
			case SDK_BaseController.ControllerHand.Left:
				return SDK_BaseController.ControllerHand.Right;
			case SDK_BaseController.ControllerHand.Right:
				return SDK_BaseController.ControllerHand.Left;
			default:
				return currentHand;
			}
		}

		public static GameObject GetActualController(GameObject givenController)
		{
			if (VRTK_SDK_Bridge.IsControllerLeftHand(givenController, actual: true) || VRTK_SDK_Bridge.IsControllerRightHand(givenController, actual: true))
			{
				return givenController;
			}
			if (VRTK_SDK_Bridge.IsControllerLeftHand(givenController, actual: false))
			{
				return VRTK_SDK_Bridge.GetControllerLeftHand(actual: true);
			}
			if (VRTK_SDK_Bridge.IsControllerRightHand(givenController, actual: false))
			{
				return VRTK_SDK_Bridge.GetControllerRightHand(actual: true);
			}
			return null;
		}

		public static GameObject GetScriptAliasController(GameObject givenController)
		{
			if (VRTK_SDK_Bridge.IsControllerLeftHand(givenController, actual: false) || VRTK_SDK_Bridge.IsControllerRightHand(givenController, actual: false))
			{
				return givenController;
			}
			if (VRTK_SDK_Bridge.IsControllerLeftHand(givenController, actual: true))
			{
				return VRTK_SDK_Bridge.GetControllerLeftHand(actual: false);
			}
			if (VRTK_SDK_Bridge.IsControllerRightHand(givenController, actual: true))
			{
				return VRTK_SDK_Bridge.GetControllerRightHand(actual: false);
			}
			return null;
		}

		public static GameObject GetModelAliasController(GameObject givenController)
		{
			return VRTK_SDK_Bridge.GetControllerModel(givenController);
		}

		public static SDK_BaseController.ControllerHand GetModelAliasControllerHand(GameObject givenObject)
		{
			if (GetModelAliasController(GetControllerLeftHand()) == givenObject)
			{
				return SDK_BaseController.ControllerHand.Left;
			}
			if (GetModelAliasController(GetControllerRightHand()) == givenObject)
			{
				return SDK_BaseController.ControllerHand.Right;
			}
			return SDK_BaseController.ControllerHand.None;
		}

		public static Vector3 GetControllerVelocity(VRTK_ControllerReference controllerReference)
		{
			return VRTK_SDK_Bridge.GetControllerVelocity(controllerReference);
		}

		public static Vector3 GetControllerAngularVelocity(VRTK_ControllerReference controllerReference)
		{
			return VRTK_SDK_Bridge.GetControllerAngularVelocity(controllerReference);
		}

		public static Vector3 GetHeadsetVelocity()
		{
			return VRTK_SDK_Bridge.GetHeadsetVelocity();
		}

		public static Vector3 GetHeadsetAngularVelocity()
		{
			return VRTK_SDK_Bridge.GetHeadsetAngularVelocity();
		}

		public static Transform HeadsetTransform()
		{
			return VRTK_SDK_Bridge.GetHeadset();
		}

		public static Transform HeadsetCamera()
		{
			return VRTK_SDK_Bridge.GetHeadsetCamera();
		}

		[Obsolete("`VRTK_DeviceFinder.ResetHeadsetTypeCache()` has been deprecated. This method will be removed in a future version of VRTK.")]
		public static void ResetHeadsetTypeCache()
		{
			cachedHeadsetType = "";
		}

		[Obsolete("`VRTK_DeviceFinder.GetHeadsetType(summary) -> VRTK_DeviceFinder.Headsets` has been replaced with `VRTK_DeviceFinder.GetHeadsetType() -> SDK_BaseHeadset.HeadsetType`. This method will be removed in a future version of VRTK.")]
		public static Headsets GetHeadsetType(bool summary = false)
		{
			Headsets headsets = Headsets.Unknown;
			cachedHeadsetType = ((cachedHeadsetType == "") ? XRDevice.model.Replace(" ", "").Replace(".", "").ToLowerInvariant() : cachedHeadsetType);
			switch (cachedHeadsetType)
			{
			case "oculusriftcv1":
				headsets = (summary ? Headsets.OculusRift : Headsets.OculusRiftCV1);
				break;
			case "oculusriftes07":
				headsets = (summary ? Headsets.OculusRift : Headsets.OculusRiftES07);
				break;
			case "vivemv":
				headsets = (summary ? Headsets.Vive : Headsets.ViveMV);
				break;
			case "vivedvt":
				headsets = (summary ? Headsets.Vive : Headsets.ViveDVT);
				break;
			}
			if (headsets == Headsets.Unknown)
			{
				VRTK_Logger.Warn(string.Format("Your headset is of type '{0}' which VRTK doesn't know about yet. Please report this headset type to the maintainers of VRTK." + (summary ? " Falling back to a slower check to summarize the headset type now." : ""), cachedHeadsetType));
				if (summary)
				{
					if (cachedHeadsetType.Contains("rift"))
					{
						return Headsets.OculusRift;
					}
					if (cachedHeadsetType.Contains("vive"))
					{
						return Headsets.Vive;
					}
				}
			}
			return headsets;
		}

		public static string GetHeadsetTypeAsString()
		{
			return VRTK_SDK_Bridge.GetHeadsetType();
		}

		public static SDK_BaseHeadset.HeadsetType GetHeadsetType()
		{
			switch (GetHeadsetTypeAsString())
			{
			case "simulator":
				return SDK_BaseHeadset.HeadsetType.Simulator;
			case "htcvive":
				return SDK_BaseHeadset.HeadsetType.HTCVive;
			case "oculusrift":
			case "oculusquest":
			case "oculusquest2":
				return SDK_BaseHeadset.HeadsetType.OculusRift;
			case "oculusgearvr":
				return SDK_BaseHeadset.HeadsetType.OculusGearVR;
			case "googledaydream":
				return SDK_BaseHeadset.HeadsetType.GoogleDaydream;
			case "googlecardboard":
				return SDK_BaseHeadset.HeadsetType.GoogleCardboard;
			case "hyperealvr":
				return SDK_BaseHeadset.HeadsetType.HyperealVR;
			case "oculusriftdk1":
				return SDK_BaseHeadset.HeadsetType.OculusRiftDK1;
			case "oculusriftdk2":
				return SDK_BaseHeadset.HeadsetType.OculusRiftDK2;
			case "windowsmixedreality":
				return SDK_BaseHeadset.HeadsetType.WindowsMixedReality;
			default:
				return SDK_BaseHeadset.HeadsetType.Undefined;
			}
		}

		public static Transform PlayAreaTransform()
		{
			return VRTK_SDK_Bridge.GetPlayArea();
		}
	}
}
