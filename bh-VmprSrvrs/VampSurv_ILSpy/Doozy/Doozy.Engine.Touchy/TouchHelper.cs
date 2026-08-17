using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;

namespace Doozy.Engine.Touchy;

public static class TouchHelper
{
	private static SimulatedTouch s_lastSimulatedTouch;

	private static List<Touch> s_touches;

	public unsafe static List<Touch> GetTouches()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0051: Expected I, but got O
		//IL_0078: Expected I, but got O
		//IL_0016: Expected I, but got O
		//IL_04a5: Expected O, but got I4
		//IL_04c0: Expected O, but got I4
		//IL_0557: Expected O, but got I4
		//IL_04de: Expected O, but got Ref
		//IL_04eb: Expected I4, but got O
		//IL_01df: Expected O, but got I4
		//IL_0585: Expected O, but got I4
		//IL_0127: Expected O, but got I
		//IL_0147: Expected O, but got I
		//IL_00f3: Expected O, but got Ref
		//IL_0103: Expected O, but got I
		//IL_04f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fe: Expected O, but got Unknown
		//IL_05b3: Expected O, but got I4
		//IL_063c: Expected I, but got O
		//IL_02e3: Expected I, but got O
		//IL_05fc: Expected I, but got O
		//IL_0241: Expected I, but got O
		//IL_0670: Expected I, but got O
		//IL_040b: Expected I, but got O
		//IL_0451: Expected O, but got Ref
		//IL_0343->IL0601: Incompatible stack heights: 1 vs 0
		//IL_02a1->IL0601: Incompatible stack heights: 1 vs 0
		//IL_0472->IL064f: Incompatible stack heights: 1 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		if (s_touches != null)
		{
			nint num = (nint)s_touches;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rcx_v44 (Il2CppClass<Doozy.Engine.Touchy.TouchHelper>)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
		}
		else
		{
			List<Touch> list = new List<Touch>();
			nint num2 = (nint)typeof(TouchHelper);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rcx_v141 (Il2CppClass<Doozy.Engine.Touchy.TouchHelper>)+B8]");
			nint num3 = 0;
			s_touches = list;
			nint num = (nint)typeof(TouchHelper);
		}
		object obj3 = Input.touchCount;
		bool flag = (nint)obj3 <= 0;
		object obj4 = 0;
		object obj6 = default(object);
		if (!flag)
		{
			do
			{
				_ = 0;
				_ = 0;
				_ = 0;
				List<Touch> list2 = s_touches;
				_ = 0;
				_ = 0;
				object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
				Input.GetTouch_Injected((int)obj4, out *(Touch*)obj5);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rbx_v18 (System.Collections.Generic.List`1<UnityEngine.Touch>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rbx_v18 (System.Collections.Generic.List`1<UnityEngine.Touch>)+10]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rbx_v18 (System.Collections.Generic.List`1<UnityEngine.Touch>)+18]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v390 @ rdx_v36 (Il2CppStaticFields<Doozy.Engine.Touchy.TouchHelper>)+18]");
				if (num4 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-30]");
					_ = 0;
					list2.AddWithResize((Touch)(&obj6));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-70]");
					obj6 = 0;
					num3 = (nint)(&obj6);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rbx_v18 (System.Collections.Generic.List`1<UnityEngine.Touch>)+18]");
					object obj7 = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rbx_v18 (System.Collections.Generic.List`1<UnityEngine.Touch>)+18]");
					object obj8 = (nint)0 * (nint)68;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-70]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-60]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-50]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-40]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-30]");
					_ = 0;
				}
				obj4++;
			}
			while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3));
		}
		if (s_lastSimulatedTouch == null)
		{
			SimulatedTouch simulatedTouch = new SimulatedTouch();
			_ = 0;
			object touch = (Touch)obj6;
			simulatedTouch.m_touch = touch;
			nint num3 = (nint)(&obj6);
			simulatedTouch._003CWasModified_003Ek__BackingField = false;
			s_lastSimulatedTouch = simulatedTouch;
			obj6 = 0;
		}
		object obj9 = Input.GetMouseButtonDown(0);
		Vector2 vector = default(Vector2);
		Vector3 ret;
		Vector3 ret2;
		Vector2 position;
		SimulatedTouch simulatedTouch3;
		if (obj9 != null)
		{
			SimulatedTouch simulatedTouch2 = s_lastSimulatedTouch;
			simulatedTouch2._003CWasModified_003Ek__BackingField = true;
			s_lastSimulatedTouch.Phase = TouchPhase.Began;
			s_lastSimulatedTouch.DeltaPosition = vector;
			Input.get_mousePosition_Injected(out ret);
			Input.get_mousePosition_Injected(out ret2);
			position = vector;
			simulatedTouch3 = s_lastSimulatedTouch;
		}
		else
		{
			object obj10 = Input.GetMouseButtonUp(0);
			if (obj10 != null)
			{
				SimulatedTouch simulatedTouch4 = s_lastSimulatedTouch;
				simulatedTouch4._003CWasModified_003Ek__BackingField = true;
				s_lastSimulatedTouch.Phase = TouchPhase.Ended;
				Input.get_mousePosition_Injected(out ret2);
				Input.get_mousePosition_Injected(out ret);
				SimulatedTouch simulatedTouch5 = s_lastSimulatedTouch;
				object touch2 = simulatedTouch5.m_touch;
				nint num5 = (nint)typeof(Touch);
				nint num6 = (nint)touch2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2255 @ rcx_v94 (Il2CppClass<System.Object>)+40]");
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v690 @ rdx_v48 (Il2CppClass<UnityEngine.Touch>)+40]");
				bool flag2 = num7 != 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v676 @ r8_v37 (System.Object)+50]");
				_ = 0;
				simulatedTouch5.DeltaPosition = vector;
				simulatedTouch3 = s_lastSimulatedTouch;
				position = vector;
			}
			else
			{
				object obj11 = Input.GetMouseButton(0);
				if (obj11 == null)
				{
					s_lastSimulatedTouch = null;
					goto IL_03b5;
				}
				SimulatedTouch simulatedTouch6 = s_lastSimulatedTouch;
				simulatedTouch6._003CWasModified_003Ek__BackingField = true;
				s_lastSimulatedTouch.Phase = TouchPhase.Moved;
				Input.get_mousePosition_Injected(out ret);
				Input.get_mousePosition_Injected(out ret2);
				SimulatedTouch simulatedTouch7 = s_lastSimulatedTouch;
				object touch3 = simulatedTouch7.m_touch;
				nint num8 = (nint)typeof(Touch);
				nint num9 = (nint)touch3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2348 @ rcx_v112 (Il2CppClass<System.Object>)+40]");
				nint num10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v689 @ rdx_v51 (Il2CppClass<UnityEngine.Touch>)+40]");
				bool flag3 = num10 != 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v675 @ r8_v40 (System.Object)+50]");
				_ = 0;
				simulatedTouch7.DeltaPosition = vector;
				simulatedTouch3 = s_lastSimulatedTouch;
				position = vector;
			}
		}
		simulatedTouch3.Position = position;
		s_lastSimulatedTouch.FingerId = 0;
		goto IL_03b5;
		IL_03b5:
		if (s_lastSimulatedTouch != null)
		{
			SimulatedTouch simulatedTouch8 = s_lastSimulatedTouch;
			if (simulatedTouch8._003CWasModified_003Ek__BackingField)
			{
				object touch4 = simulatedTouch8.m_touch;
				nint num11 = (nint)typeof(Touch);
				nint num12 = (nint)touch4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v727 @ rcx_v66 (Il2CppClass<System.Object>)+40]");
				nint num13 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v687 @ rdx_v43 (Il2CppClass<UnityEngine.Touch>)+40]");
				bool flag4 = num13 != 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v673 @ r8_v31 (System.Object)+50]");
				_ = 0;
				s_touches.Add((Touch)(&obj6));
				SimulatedTouch simulatedTouch9 = s_lastSimulatedTouch;
				simulatedTouch9._003CWasModified_003Ek__BackingField = false;
			}
		}
		return s_touches;
	}
}
