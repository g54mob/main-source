using System.Collections.Generic;
using UnityEngine;
using VRTK;
using Valve.VR;

namespace DV.VRTK_Extensions
{
	public static class VRTK_ControllerUtils_DV
	{
		private const string COSMOS_MODEL_KEYWORD = "cosmos";

		private const string QUEST_MODEL_KEYWORD = "quest";

		private static Dictionary<uint, ControllerType_DV> controllerTypeCache = new Dictionary<uint, ControllerType_DV>();

		private static readonly Dictionary<SDK_BaseController.ControllerType, ControllerType_DV> standardControllerTypes = new Dictionary<SDK_BaseController.ControllerType, ControllerType_DV>
		{
			{
				SDK_BaseController.ControllerType.SteamVR_OculusTouch,
				ControllerType_DV.RiftTouch
			},
			{
				SDK_BaseController.ControllerType.Oculus_OculusTouch,
				ControllerType_DV.RiftTouch
			},
			{
				SDK_BaseController.ControllerType.SteamVR_ViveWand,
				ControllerType_DV.ViveWand
			},
			{
				SDK_BaseController.ControllerType.SteamVR_ValveKnuckles,
				ControllerType_DV.ValveIndex
			},
			{
				SDK_BaseController.ControllerType.SteamVR_WindowsMRController,
				ControllerType_DV.WMR
			},
			{
				SDK_BaseController.ControllerType.WindowsMR_MotionController,
				ControllerType_DV.WMR
			}
		};

		public static ControllerTooltip ControllerTooltipLeft { get; set; }

		public static ControllerTooltip ControllerTooltipRight { get; set; }

		public static ControllerType_DV GetControllerTypeWithFallback(bool isRight)
		{
			VRTK_ControllerReference vRTK_ControllerReference = (isRight ? VRTK_DeviceFinder.GetControllerReferenceRightHand() : VRTK_DeviceFinder.GetControllerReferenceLeftHand());
			uint index = vRTK_ControllerReference.index;
			if (index == uint.MaxValue)
			{
				Debug.LogError($"Controller type cannot be determined due to invalid index value. Returning {ControllerType_DV.Undefined}.");
				return ControllerType_DV.Undefined;
			}
			SDK_BaseController.ControllerType currentControllerType = VRTK_DeviceFinder.GetCurrentControllerType(vRTK_ControllerReference);
			if (controllerTypeCache.TryGetValue(index, out var value))
			{
				return value;
			}
			if (standardControllerTypes.TryGetValue(currentControllerType, out value))
			{
				switch (value)
				{
				case ControllerType_DV.ViveWand:
					value = ResolveWandCosmosAmbiguity(index);
					break;
				case ControllerType_DV.WMR:
					value = ResolveWMRG2Ambiguity();
					break;
				case ControllerType_DV.RiftTouch:
					value = ResolveQuestRiftAmbiguity(index);
					break;
				}
				controllerTypeCache[index] = value;
				return value;
			}
			switch (HeadsetUtils.GetHeadsetTypeDV())
			{
			case HeadsetType_DV.HTCVive:
				value = ResolveWandCosmosAmbiguity(index);
				break;
			case HeadsetType_DV.OculusRift:
				value = ControllerType_DV.RiftTouch;
				break;
			case HeadsetType_DV.OculusQuest:
			case HeadsetType_DV.OculusQuest2:
				value = ControllerType_DV.QuestTouch;
				break;
			case HeadsetType_DV.WMR:
				value = ResolveWMRG2Ambiguity();
				break;
			default:
				value = ControllerType_DV.Undefined;
				break;
			}
			controllerTypeCache[index] = value;
			return value;
		}

		private static ControllerType_DV ResolveWMRG2Ambiguity()
		{
			if (HeadsetUtils.GetHeadsetTypeDV() != HeadsetType_DV.HPReverbG2)
			{
				return ControllerType_DV.WMR;
			}
			return ControllerType_DV.HPReverbG2;
		}

		public static ControllerType_DV GetControllerTypeDV(this VRTK_ControllerReference controllerReference)
		{
			if (controllerReference == null)
			{
				Debug.LogError("'GetControllerTypeDV' requires a non null 'VRTK_ControllerReference' reference.");
				return ControllerType_DV.Undefined;
			}
			if (controllerReference.hand == SDK_BaseController.ControllerHand.None)
			{
				Debug.LogError("'VRTK_ControllerReference' is not initialized properly. Controller type cannot be determined.");
				return ControllerType_DV.Undefined;
			}
			return GetControllerTypeWithFallback(controllerReference.hand == SDK_BaseController.ControllerHand.Right);
		}

		public static bool IsWandOrUndefined(this VRTK_ControllerReference controllerReference)
		{
			ControllerType_DV controllerTypeDV = controllerReference.GetControllerTypeDV();
			if (controllerTypeDV != ControllerType_DV.ViveWand)
			{
				return controllerTypeDV == ControllerType_DV.Undefined;
			}
			return true;
		}

		private static ControllerType_DV ResolveWandCosmosAmbiguity(uint controllerIndex)
		{
			string text = ((SteamVR.instance != null) ? SteamVR.instance.GetStringProperty(ETrackedDeviceProperty.Prop_ModelNumber_String, controllerIndex) : "").ToLowerInvariant();
			if (!string.IsNullOrWhiteSpace(text) && text.Contains("cosmos".ToLowerInvariant()))
			{
				return ControllerType_DV.Cosmos;
			}
			return ControllerType_DV.ViveWand;
		}

		private static ControllerType_DV ResolveQuestRiftAmbiguity(uint controllerIndex)
		{
			string text = ((SteamVR.instance != null) ? SteamVR.instance.GetStringProperty(ETrackedDeviceProperty.Prop_ModelNumber_String, controllerIndex) : "").ToLowerInvariant();
			if (!string.IsNullOrWhiteSpace(text) && text.Contains("quest".ToLowerInvariant()))
			{
				return ControllerType_DV.QuestTouch;
			}
			return ControllerType_DV.RiftTouch;
		}
	}
}
