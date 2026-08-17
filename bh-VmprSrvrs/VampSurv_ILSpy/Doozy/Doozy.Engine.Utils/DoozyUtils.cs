using System;
using Cpp2ILInjected;
using Doozy.Engine.Extensions;
using Doozy.Engine.Settings;
using UnityEngine;
using UnityEngine.UI;

namespace Doozy.Engine.Utils;

public static class DoozyUtils
{
	public const string BACKGROUND = "Background";

	public const string OVERLAY = "Overlay";

	public static Color BackgroundColor;

	public static Color CheckmarkColor;

	public static Color OverlayColor;

	public static Color TextColor;

	public const int TEXT_FONT_SIZE = 14;

	public unsafe static Image AddImageToGameObject(GameObject target)
	{
		//IL_0061: Expected O, but got Ref
		if ((object)target != null)
		{
			Image component = target.GetComponent<Image>();
			bool flag = (object)component != null;
			Image image = component;
			if (!flag)
			{
				Image image2 = target.AddComponent<Image>();
				image = image2;
			}
			if ((object)image != null)
			{
				object obj = default(object);
				image.color = (Color)(&obj);
				return image;
			}
		}
		return (Image)(object)new NullReferenceException();
	}

	public unsafe static GameObject CreateGameObjectWithAnImageComponent(string objectName, Color color, GameObject parent = null)
	{
		//IL_019c: Expected I, but got O
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0063: Expected I, but got O
		//IL_0169: Expected O, but got Ref
		//IL_0176: Expected O, but got Ref
		Type[] array = new Type[1];
		nint num = (nint)typeof(RectTransform);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		IntPtr intPtr = default(IntPtr);
		num = intPtr;
		if (num != 0)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj3 = default(object);
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		GameObject gameObject = new GameObject(objectName, array);
		if ((object)parent != null && ((UnityEngine.Object)parent).m_CachedPtr != (IntPtr)0)
		{
			Transform transform = gameObject.transform;
			Transform transform2 = parent.transform;
			transform.SetParent(transform2, worldPositionStays: true);
		}
		RectTransform component = gameObject.GetComponent<RectTransform>();
		RectTransformExtensions.FullScreen(component, resetScaleToOne: true);
		Image component2 = gameObject.GetComponent<Image>();
		bool flag = (object)component2 != null;
		Image image = component2;
		if (!flag)
		{
			Image image2 = gameObject.AddComponent<Image>();
			image = image2;
		}
		Color color2 = default(Color);
		image.color = (Color)(&color2);
		image.color = (Color)(&color2);
		return gameObject;
	}

	public unsafe static GameObject CreateBackgroundImage(GameObject parent)
	{
		//IL_001c: Expected O, but got Ref
		object obj = default(object);
		return CreateGameObjectWithAnImageComponent("Background", (Color)(&obj), parent);
	}

	public unsafe static GameObject CreateOverlayImage(GameObject parent)
	{
		//IL_001c: Expected O, but got Ref
		object obj = default(object);
		return CreateGameObjectWithAnImageComponent("Overlay", (Color)(&obj), parent);
	}

	public static T AddToScene<T>(string gameObjectName, bool isSingleton, bool selectGameObjectAfterCreation = false) where T : MonoBehaviour
	{
		//IL_01f0: Expected O, but got I4
		//IL_020a: Expected O, but got I4
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00f0: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ r9 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		T val = UnityEngine.Object.FindObjectOfType<T>();
		bool flag2;
		if ((object)val != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal2 @ rax_v23 (T)+10]");
			bool flag = (nint)0 == 0;
			flag2 = !flag;
		}
		else
		{
			flag2 = false;
		}
		object obj = isSingleton & flag2;
		bool flag3 = obj == null;
		object obj2 = !flag3;
		if (obj2 == null)
		{
			Type[] array = new Type[1];
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj4 = default(object);
			object obj3 = obj4 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			if (num != 0)
			{
				nint num2 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj5 = default(object);
				if (obj5 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			GameObject gameObject = new GameObject(gameObjectName, array);
			val = gameObject.GetComponent<T>();
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj7 = default(object);
			object obj6 = obj7 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			object obj9 = default(object);
			object obj8 = obj9;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v430 @ rdx_v5+1B8] (should have been resolved before IL gen)");
			string text = default(string);
			string message = "Cannot add another " + text + " to this Scene because you don't need more than one.";
			DDebug.Log(message);
		}
		return val;
	}

	public static void AddObjectToAsset(UnityEngine.Object objectToAdd, UnityEngine.Object assetObject)
	{
	}

	public static bool DisplayDialog(string title, string message, string ok)
	{
		return false;
	}

	public static bool DisplayDialog(string title, string message, string ok, string cancel)
	{
		return false;
	}

	public static void DisplayProgressBar(string title, string info, float progress)
	{
	}

	public static bool DisplayCancelableProgressBar(string title, string info, float progress)
	{
		return false;
	}

	public static void ClearProgressBar()
	{
	}

	public static bool MoveAssetToTrash(string path)
	{
		return false;
	}

	public static void SaveAssets()
	{
	}

	public static void SetDirty(UnityEngine.Object target)
	{
		if ((object)target == null)
		{
		}
	}

	public static void SetDirty(UnityEngine.Object target, bool saveAssets)
	{
		if ((object)target != null && target.m_CachedPtr != (IntPtr)0 && !saveAssets)
		{
			DoozySettings instance = DoozySettings.Instance;
			instance.AssetDatabaseSaveAssetsNeeded = true;
		}
	}

	public static void UndoRecordObject(UnityEngine.Object objectToUndo, string undoMessage)
	{
		if ((object)objectToUndo == null)
		{
		}
	}

	public static void UndoRecordObject(UnityEngine.Object objectToUndo, string undoMessage, bool saveAssets)
	{
		if ((object)objectToUndo != null && objectToUndo.m_CachedPtr != (IntPtr)0)
		{
			UndoRecordObject(objectToUndo, undoMessage);
			if (!saveAssets)
			{
			}
		}
	}

	public static void UndoRecordObjects(UnityEngine.Object[] objectsToUndo, string undoMessage)
	{
	}

	public static void UndoRecordObjects(UnityEngine.Object[] objectsToUndo, string undoMessage, bool saveAssets)
	{
		if (objectsToUndo != null && !saveAssets)
		{
		}
	}

	static DoozyUtils()
	{
		//IL_0016: Expected O, but got I
		//IL_0027: Expected O, but got I
		//IL_0038: Expected O, but got I
		//IL_0049: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12320]");
		BackgroundColor = (Color)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A121D0]");
		CheckmarkColor = (Color)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11EA0]");
		OverlayColor = (Color)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12050]");
		TextColor = (Color)0;
	}
}
