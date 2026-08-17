using System;
using Cpp2ILInjected;
using UnityEngine;

namespace Crystal;

public class SafeArea : MonoBehaviour
{
	public enum SimDevice
	{
		None,
		iPhoneX,
		iPhoneXsMax,
		Pixel3XL_LSL,
		Pixel3XL_LSR
	}

	public static SimDevice Sim;

	private Rect[] NSA_iPhoneX;

	private Rect[] NSA_iPhoneXsMax;

	private Rect[] NSA_Pixel3XL_LSL;

	private Rect[] NSA_Pixel3XL_LSR;

	private RectTransform Panel;

	private Rect LastSafeArea;

	private Vector2Int LastScreenSize;

	private ScreenOrientation LastOrientation;

	private bool ConformX;

	private bool ConformY;

	private bool Logging;

	private void Awake()
	{
		RectTransform component = GetComponent<RectTransform>();
		Panel = component;
		RectTransform panel = Panel;
		if ((object)Panel == null || ((UnityEngine.Object)panel).m_CachedPtr == (IntPtr)0)
		{
			string text = GetName();
			string message = "Cannot apply safe area - no RectTransform found on " + text;
			Debug.LogError(message);
			GameObject obj = base.gameObject;
			UnityEngine.Object.Destroy(obj, 0f);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 258 Invalid \"Jump target not found in method: 0x180B879E0\"");
	}

	private void Update()
	{
		Refresh();
	}

	private unsafe void Refresh()
	{
		//IL_0150: Expected O, but got I4
		//IL_0198: Expected O, but got I4
		//IL_017c: Expected O, but got Ref
		//IL_00f6: Expected O, but got I4
		//IL_0120: Expected O, but got I4
		Screen.get_safeArea_Injected(out Rect ret);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 0000000180B87B33h\"");
		if ((object)ret == (object)LastSafeArea)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 0000000180B87B33h\"");
			object obj = default(object);
			Rect rect = default(Rect);
			if (obj == (object)rect)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 0000000180B87B33h\"");
				object obj2 = default(object);
				if (obj2 == (object)rect)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000180B87B33h\"");
					object obj3 = default(object);
					if (obj3 == (object)rect)
					{
						object obj4 = Screen.width;
						if (obj4 == (object)LastScreenSize)
						{
							object obj5 = Screen.height;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Crystal.SafeArea)+5C]");
							if (obj5 == null)
							{
								ScreenOrientation screenOrientation = Screen.GetScreenOrientation();
								if (screenOrientation == LastOrientation)
								{
									return;
								}
							}
						}
					}
				}
			}
		}
		Vector2Int lastScreenSize = (Vector2Int)Screen.width;
		LastScreenSize = lastScreenSize;
		object obj6 = Screen.height;
		ScreenOrientation screenOrientation2 = Screen.GetScreenOrientation();
		LastOrientation = screenOrientation2;
		ApplySafeArea((Rect)(&ret));
	}

	private unsafe Rect GetSafeArea()
	{
		//IL_0013: Expected native int or pointer, but got O
		//IL_002e: Expected native int or pointer, but got O
		Rect rect = default(Rect);
		((Rect*)(nint)rect)->m_XMin = 0f;
		float ret;
		Screen.get_safeArea_Injected(out *(Rect*)(&ret));
		((Rect*)(nint)rect)->m_XMin = ret;
		return rect;
	}

	private unsafe void ApplySafeArea(Rect r)
	{
		//IL_0406: Expected O, but got F4
		//IL_000e: Expected native int or pointer, but got O
		//IL_056a: Expected O, but got I4
		//IL_0584: Expected O, but got F4
		//IL_0022: Expected native int or pointer, but got O
		//IL_0432: Expected F4, but got I4
		//IL_043a: Expected native int or pointer, but got O
		//IL_0455: Expected F4, but got I4
		//IL_045d: Expected native int or pointer, but got O
		//IL_0478: Expected O, but got I4
		//IL_0492: Expected O, but got F4
		//IL_01ac: Expected I, but got O
		//IL_04a9: Expected O, but got I4
		//IL_059b: Expected O, but got I4
		//IL_020d: Expected I, but got O
		//IL_04cb: Expected O, but got I4
		//IL_05bd: Expected O, but got I4
		//IL_05d5: Invalid comparison between F4 and I4
		//IL_05e4: Expected O, but got I4
		//IL_026e: Expected I, but got O
		//IL_0071: Invalid comparison between F4 and I4
		//IL_0080: Expected O, but got I4
		//IL_02cf: Expected I, but got O
		//IL_00a7: Invalid comparison between F4 and I4
		//IL_00b6: Expected O, but got I4
		//IL_04e8: Expected O, but got I4
		//IL_0330: Expected I, but got O
		//IL_00dd: Invalid comparison between F4 and I4
		//IL_00ec: Expected O, but got I4
		//IL_0518: Expected O, but got I4
		//IL_036a: Expected I, but got O
		//IL_03a4: Expected I, but got O
		//IL_0136: Expected O, but got I4
		//IL_01cf->IL01cf: Incompatible stack heights: 1 vs 0
		//IL_0230->IL0230: Incompatible stack heights: 1 vs 0
		//IL_0291->IL0291: Incompatible stack heights: 1 vs 0
		//IL_02f2->IL02f2: Incompatible stack heights: 1 vs 0
		//IL_0353->IL0353: Incompatible stack heights: 1 vs 0
		//IL_038d->IL038d: Incompatible stack heights: 1 vs 0
		//IL_03c7->IL03c7: Incompatible stack heights: 1 vs 0
		float num = r.m_XMin;
		LastSafeArea = (Rect)r.m_XMin;
		if (!ConformX)
		{
			((Rect*)(nint)r)->m_XMin = 0f;
			num = (((Rect*)(nint)r)->m_Width = Screen.width);
		}
		if (!ConformY)
		{
			((Rect*)(nint)r)->m_YMin = 0f;
			num = (((Rect*)(nint)r)->m_Height = Screen.height);
		}
		object obj = Screen.width;
		bool flag = (nint)obj <= 0;
		Vector2 vector = (Vector2)num;
		if (!flag)
		{
			object obj2 = Screen.height;
			bool flag2 = (nint)obj2 <= 0;
			vector = (Vector2)num;
			if (!flag2)
			{
				float num2 = r.m_XMin + r.m_Width;
				float num3 = r.m_YMin + r.m_Height;
				object obj3 = Screen.width;
				float num4 = r.m_XMin / (float)obj3;
				object obj4 = Screen.height;
				float num5 = r.m_YMin / (float)obj4;
				object obj5 = Screen.width;
				float num6 = num2 / (float)obj5;
				Vector2 vector2 = (Vector2)Screen.height;
				float num7 = num3 / (float)vector2;
				bool flag3 = num4 < 0f;
				object obj6 = 0;
				vector = vector2;
				float num8 = num2;
				if (!flag3)
				{
					bool flag4 = num5 < 0f;
					obj6 = 0;
					vector = vector2;
					num8 = num2;
					if (!flag4)
					{
						bool flag5 = num6 < 0f;
						obj6 = 0;
						vector = vector2;
						num8 = num2;
						if (!flag5)
						{
							bool flag6 = num7 < 0f;
							obj6 = 0;
							vector = vector2;
							num8 = num2;
							if (!flag6)
							{
								Vector2 vector3 = default(Vector2);
								Panel.anchorMin = vector3;
								Panel.anchorMax = vector3;
								obj6 = 0;
								vector = vector3;
								num8 = num2;
							}
						}
					}
				}
			}
		}
		if (Logging)
		{
			object[] array = new object[7];
			string text = GetName();
			if (text != null)
			{
				nint num9 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj7 = default(object);
				bool flag7 = obj7 == null;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object obj8 = default(object);
			if (obj8 != null)
			{
				nint num10 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj9 = default(object);
				bool flag8 = obj9 == null;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object obj10 = default(object);
			if (obj10 != null)
			{
				nint num11 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj11 = default(object);
				bool flag9 = obj11 == null;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object obj12 = default(object);
			if (obj12 != null)
			{
				nint num12 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj13 = default(object);
				bool flag10 = obj13 == null;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object obj14 = default(object);
			if (obj14 != null)
			{
				nint num13 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj15 = default(object);
				bool flag11 = obj15 == null;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			object obj16 = Screen.width;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object obj17 = default(object);
			if (obj17 != null)
			{
				nint num14 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj18 = default(object);
				bool flag12 = obj18 == null;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			object obj19 = Screen.height;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object obj20 = default(object);
			if (obj20 != null)
			{
				nint num15 = (nint)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj21 = default(object);
				bool flag13 = obj21 == null;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Debug.LogFormat("New safe area applied to {0}: x={1}, y={2}, w={3}, h={4} on full extents w={5}, h={6}", array);
		}
	}

	public SafeArea()
	{
		//IL_010c: Expected O, but got I4
		//IL_0117: Expected O, but got I4
		Rect[] nSA_iPhoneX = new Rect[2];
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11EC0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F00]");
		_ = 0;
		NSA_iPhoneX = nSA_iPhoneX;
		Rect[] nSA_iPhoneXsMax = new Rect[2];
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11ED0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F10]");
		_ = 0;
		NSA_iPhoneXsMax = nSA_iPhoneXsMax;
		Rect[] nSA_Pixel3XL_LSL = new Rect[2];
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11EF0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A123C0]");
		_ = 0;
		NSA_Pixel3XL_LSL = nSA_Pixel3XL_LSL;
		Rect[] nSA_Pixel3XL_LSR = new Rect[2];
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11EF0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A123D0]");
		_ = 0;
		NSA_Pixel3XL_LSR = nSA_Pixel3XL_LSR;
		LastOrientation = ScreenOrientation.AutoRotation;
		LastSafeArea = (Rect)0;
		LastScreenSize = (Vector2Int)0;
		ConformX = true;
	}
}
