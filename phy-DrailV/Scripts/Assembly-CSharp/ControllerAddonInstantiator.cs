using System.Collections.Generic;
using UnityEngine;
using VRTK;

public static class ControllerAddonInstantiator
{
	private static readonly string[] ANCHORS_WAND = new string[3] { "[anchor wand]", "[anchor wand right]", "[anchor wand left]" };

	private static readonly string[] ANCHORS_INDEX = new string[3] { "[anchor index]", "[anchor_index_right]", "[anchor index left]" };

	private static readonly string[] ANCHORS_WMR = new string[3] { "[anchor wmr]", "[anchor wmr right]", "[anchor wmr left]" };

	private static readonly string[] ANCHORS_OCULUS = new string[3] { "[anchor oculus touch]", "[anchor oculus left]", "[anchor oculus right]" };

	private const string CONTROLLER_ADDON_PREFIX = "[controller addon";

	private const string REPARENTED_ANCHOR_NAME = "{0}Anchor";

	private static Dictionary<SDK_BaseController.ControllerType, string[]> controlerTypeToAnchorNames = new Dictionary<SDK_BaseController.ControllerType, string[]>
	{
		{
			SDK_BaseController.ControllerType.SteamVR_ViveWand,
			ANCHORS_WAND
		},
		{
			SDK_BaseController.ControllerType.SteamVR_ValveKnuckles,
			ANCHORS_INDEX
		},
		{
			SDK_BaseController.ControllerType.SteamVR_WindowsMRController,
			ANCHORS_WMR
		},
		{
			SDK_BaseController.ControllerType.WindowsMR_MotionController,
			ANCHORS_WMR
		},
		{
			SDK_BaseController.ControllerType.SteamVR_OculusTouch,
			ANCHORS_OCULUS
		},
		{
			SDK_BaseController.ControllerType.Oculus_OculusTouch,
			ANCHORS_OCULUS
		},
		{
			SDK_BaseController.ControllerType.Oculus_OculusGamepad,
			ANCHORS_OCULUS
		},
		{
			SDK_BaseController.ControllerType.Oculus_OculusRemote,
			ANCHORS_OCULUS
		},
		{
			SDK_BaseController.ControllerType.Undefined,
			ANCHORS_WAND
		}
	};

	public static Transform InstantiateControllerAddon(GameObject prefab, VRTK_ControllerReference ctrlRef, Transform specificParent = null)
	{
		if (prefab == null)
		{
			Debug.LogError("'prefab' reference should never be null. Aborting.");
			return null;
		}
		if (ctrlRef == null)
		{
			Debug.LogError("'VRTK_ControllerReference' should never be null. Aborting.");
			return null;
		}
		int num = 0;
		switch (ctrlRef.hand)
		{
		case SDK_BaseController.ControllerHand.Right:
			num = 1;
			break;
		case SDK_BaseController.ControllerHand.Left:
			num = 2;
			break;
		default:
			Debug.LogError("Given controller reference has no hand assigned. Aborting.");
			return null;
		}
		SDK_BaseController.ControllerType currentControllerType = VRTK_DeviceFinder.GetCurrentControllerType(ctrlRef);
		if (controlerTypeToAnchorNames.TryGetValue(currentControllerType, out var value))
		{
			Transform transform = Object.Instantiate(prefab).transform;
			transform.name = transform.name.Substring(0, transform.name.Length - 7);
			Transform transform2 = transform.Find(value[num]);
			if (transform2 == null)
			{
				transform2 = transform.Find(value[0]);
			}
			Transform transform3 = null;
			for (int i = 0; i < transform.childCount; i++)
			{
				Transform child = transform.GetChild(i);
				if (child.name.StartsWith("[controller addon"))
				{
					transform3 = child;
					break;
				}
			}
			if (transform3 == null || transform2 == null)
			{
				Debug.Log("Given prefab '" + prefab.name + "' doesn't have a proper anchor or controller addon transform. Cleaning up and aborting.", prefab);
				Object.Destroy(transform.gameObject);
				return null;
			}
			transform3.SetParent(transform2);
			transform3.localPosition = transform2.localPosition;
			Transform parent = ((specificParent != null) ? specificParent : ctrlRef.actual.transform);
			transform2.SetParent(parent);
			transform2.name = $"{transform.name}Anchor";
			transform2.localRotation = Quaternion.identity;
			transform2.localPosition = Vector3.zero;
			Object.Destroy(transform.gameObject);
			return transform3;
		}
		Debug.LogError(string.Format("Unexpected '{0}' value: '{1}'. Aborting.", "ControllerType", currentControllerType));
		return null;
	}
}
