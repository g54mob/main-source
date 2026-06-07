using System;
using System.Collections.Generic;
using System.IO;
using DV.CabControls;
using DV.CabControls.VRTK;
using DV.Common;
using DV.ControllerAnchors;
using DV.UserManagement;
using DV.Utils;
using DV.VRTK_Extensions;
using UnityEngine;
using VRTK;

public static class PipaUtils
{
	public enum PipaHand
	{
		None = 0,
		Right = 1,
		Left = 2
	}

	public struct AnchorData
	{
		public Vector3 pipaOffset;

		public Quaternion pipaRotation;

		public Vector3 telegrabOffset;

		public Quaternion telegrabRotation;

		public Vector3 handOffset;

		public Quaternion handRotation;
	}

	public const string PIPA_GO_NAME = "[pipa]";

	public const string PIPA_ATTACH_POINT_NAME = "[pipa attach point]";

	public const string PIPA_PREFAB_NAME = "[controller_pipa]";

	private const string PIPA_L = "[pipa L]";

	private const string PIPA_R = "[pipa R]";

	private const string TELEGRAB_L = "[telegrab L]";

	private const string TELEGRAB_R = "[telegrab R]";

	private const string ATTACH_L = "[attach L]";

	private const string ATTACH_R = "[attach R]";

	private static Dictionary<GameObject, Transform> objectToPipaCache = new Dictionary<GameObject, Transform>();

	private static Transform pipaLeft = null;

	private static Transform pipaRight = null;

	private const string CONFIG_FOLDER = "config";

	private const string ANCHORS_FILE_NAME = "ControllerAnchors.json";

	private static IUserProfile userProfile = null;

	private static ControllerAnchorsSpec anchorsSpec;

	public static void InitializePipaObjectCache(GameObject controller, Transform pipa, bool isRight)
	{
		objectToPipaCache[controller] = pipa;
		if (isRight)
		{
			pipaRight = pipa;
		}
		else
		{
			pipaLeft = pipa;
		}
	}

	public static Transform PipaTransform(GameObject controllerGameObject)
	{
		if (controllerGameObject == null)
		{
			Debug.LogError("Pipa transform cannot be obtained from a null object. Returning null.");
			return null;
		}
		if (!objectToPipaCache.TryGetValue(controllerGameObject, out var value))
		{
			VRTK_InteractGrab componentInChildren = controllerGameObject.GetComponentInChildren<VRTK_InteractGrab>();
			if (componentInChildren == null)
			{
				Debug.LogError("Given object doesn't have a 'VRTK_InteractGrab' component in any of its children. Pipa transform cannot be found.", controllerGameObject);
				return null;
			}
			value = componentInChildren.transform.Find("[pipa]").transform;
			objectToPipaCache.Add(controllerGameObject, value);
		}
		return value;
	}

	public static Transform PipaTransform(PipaHand hand)
	{
		switch (hand)
		{
		case PipaHand.Left:
			return pipaLeft;
		case PipaHand.Right:
			return pipaRight;
		default:
			return null;
		}
	}

	public static Transform PipaTransform(SDK_BaseController.ControllerHand hand)
	{
		switch (hand)
		{
		case SDK_BaseController.ControllerHand.Left:
			return pipaLeft;
		case SDK_BaseController.ControllerHand.Right:
			return pipaRight;
		default:
			return null;
		}
	}

	public static bool IsPipa(Transform potentialPipaTransform)
	{
		if (!(pipaRight == potentialPipaTransform))
		{
			return pipaLeft == potentialPipaTransform;
		}
		return true;
	}

	public static PipaHand GetPipaHand(Transform potentialPipa)
	{
		if (potentialPipa != null)
		{
			if (potentialPipa == pipaRight)
			{
				return PipaHand.Right;
			}
			if (potentialPipa == pipaLeft)
			{
				return PipaHand.Left;
			}
		}
		return PipaHand.None;
	}

	public static Vector3 PipaPosition(GameObject controllerGameObject)
	{
		Transform transform = PipaTransform(controllerGameObject);
		if (transform == null)
		{
			Debug.LogError("Could not get pipa reference from `" + controllerGameObject.name + "'. Returning Vector3.zero.", controllerGameObject);
			return Vector3.zero;
		}
		return transform.position;
	}

	public static void AlignItemToControllersPipa(ItemBase item, GameObject controller, bool forceTransformMove = true)
	{
		if (item == null || controller == null)
		{
			Debug.LogError("Both 'ItemBase' and 'controller' references must have a valid. Cannot align item to pipa.");
			return;
		}
		Transform transform = PipaTransform(controller);
		ItemVRTK itemVRTK = (ItemVRTK)item;
		Transform anchor = (VRTK_DeviceFinder.IsControllerRightHand(transform.parent.gameObject) ? itemVRTK.GrabAnchorRight : itemVRTK.GrabAnchorLeft);
		var (position, rotation) = TransformUtils.CalculateAlignmentTargets(item.transform, transform, anchor);
		if (item.gameObject.activeInHierarchy && !forceTransformMove)
		{
			Rigidbody component = item.GetComponent<Rigidbody>();
			if (component != null)
			{
				component.position = position;
				component.rotation = rotation;
				return;
			}
		}
		item.transform.SetPositionAndRotation(position, rotation);
	}

	public static void AlignTransformToPipa(Transform transform, Transform pipaTransform, Transform anchor)
	{
		if (transform == null || pipaTransform == null)
		{
			Debug.LogError("Both 'transform' and 'pipaTransform' references must have a valid. Cannot align transform to pipa.");
			return;
		}
		var (position, rotation) = TransformUtils.CalculateAlignmentTargets(transform, pipaTransform, anchor);
		transform.SetPositionAndRotation(position, rotation);
	}

	private static void CheckSpec()
	{
		if (anchorsSpec != null && SingletonBehaviour<UserManager>.Instance.CurrentUser == userProfile)
		{
			return;
		}
		anchorsSpec = new ControllerAnchorsSpec();
		userProfile = SingletonBehaviour<UserManager>.Instance.CurrentUser;
		string text = Path.Combine(SingletonBehaviour<UserManager>.Instance.Storage.GetFilesystemPath(userProfile.GameDataPath), "config");
		string text2 = Path.Combine(text, "ControllerAnchors.json");
		try
		{
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
		}
		catch (Exception ex)
		{
			Debug.LogError("Error creating game config folder: " + ex.Message);
			Debug.LogException(ex);
		}
		try
		{
			string text3 = Path.Combine(Application.dataPath, "SaveGameData", "ControllerAnchors.json");
			if (File.Exists(text3))
			{
				File.Copy(text3, text2, overwrite: true);
				File.Delete(text3);
			}
		}
		catch (Exception ex2)
		{
			Debug.LogError("Couldn't check and copy legacy VR anchor points: " + ex2.Message);
			Debug.LogException(ex2);
		}
		try
		{
			anchorsSpec.jsonFilePath = text2;
			if (!File.Exists(anchorsSpec.jsonFilePath))
			{
				anchorsSpec.LoadDefaults();
				anchorsSpec.Save();
			}
			else
			{
				anchorsSpec.Load();
			}
		}
		catch (Exception ex3)
		{
			Debug.LogError("Error occurred while loading VR controller anchor points: " + ex3.Message);
			Debug.LogException(ex3);
		}
	}

	public static AnchorData GetAnchorData(VRTK_ControllerReference ctrlRef)
	{
		string sdk = VRManager.GetCurrentSDK().ToString();
		string ctrlType = ctrlRef.GetControllerTypeDV().ToString();
		return GetAnchorData(sdk, ctrlType);
	}

	public static AnchorData GetAnchorData(string sdk, string ctrlType)
	{
		CheckSpec();
		return new AnchorData
		{
			pipaOffset = Pos("sphere"),
			pipaRotation = Rot("sphere"),
			handOffset = Pos("hand"),
			handRotation = Rot("hand")
		};
		Vector3 Pos(string what)
		{
			return anchorsSpec.Get(sdk, ctrlType, what + "Offset") / 100f;
		}
		Quaternion Rot(string what)
		{
			return Quaternion.Euler(anchorsSpec.Get(sdk, ctrlType, what + "Rotation"));
		}
	}

	public static void SetAnchorData(VRTK_ControllerReference ctrlRef, AnchorData anchorData)
	{
		CheckSpec();
		string sdk = VRManager.GetCurrentSDK().ToString();
		string ctrlType = ctrlRef.GetControllerTypeDV().ToString();
		SetPos("sphere", anchorData.pipaOffset);
		SetRot("sphere", anchorData.pipaRotation.eulerAngles);
		SetPos("hand", anchorData.handOffset);
		SetRot("hand", anchorData.handRotation.eulerAngles);
		void SetPos(string what, Vector3 value)
		{
			anchorsSpec.Set(sdk, ctrlType, what + "Offset", value * 100f);
		}
		void SetRot(string what, Vector3 value)
		{
			anchorsSpec.Set(sdk, ctrlType, what + "Rotation", value);
		}
	}

	public static void SaveAnchorData()
	{
		if (anchorsSpec != null)
		{
			anchorsSpec.Save();
		}
	}

	public static void LoadDefaultAnchorData()
	{
		CheckSpec();
		anchorsSpec.LoadDefaults();
		anchorsSpec.Save();
	}

	public static void LoadAnchorDataFromDisk()
	{
		CheckSpec();
		anchorsSpec.Load();
	}
}
