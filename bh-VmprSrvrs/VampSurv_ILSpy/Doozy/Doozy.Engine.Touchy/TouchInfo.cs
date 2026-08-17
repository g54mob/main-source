using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;

namespace Doozy.Engine.Touchy;

public struct TouchInfo
{
	public Touch Touch;

	public Swipe Direction;

	public Vector2 RawDirection;

	public Vector2 StartPosition;

	public Vector2 EndPosition;

	public Vector2 Velocity;

	public float StartTime;

	public float EndTime;

	public float Duration;

	public bool Tap;

	public bool LongTap;

	public float Distance;

	public float LongestDistance;

	public GameObject GameObject;

	public GameObject DraggedObject;

	public Vector2 CurrentTouchPosition;

	public Vector2 PreviousTouchPosition;

	public float TouchDeltaTime;

	public bool IsDragging
	{
		get
		{
			GameObject draggedObject = DraggedObject;
			if ((object)DraggedObject != null)
			{
				bool flag = ((UnityEngine.Object)draggedObject).m_CachedPtr == (IntPtr)0;
				return !flag;
			}
			return false;
		}
	}

	public Vector2 TouchVelocity
	{
		get
		{
			Vector2 result = default(Vector2);
			return result;
		}
	}

	public void Update(Touch touch, GameObject gameObject = null)
	{
		//IL_000f: Expected O, but got I4
		//IL_0091: Expected I, but got O
		//IL_00d3: Expected O, but got F4
		//IL_00de: Expected F4, but got O
		//IL_00e9: Expected F4, but got O
		Touch = (Touch)touch.m_FingerId;
		Direction = Swipe.None;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [touch @ rdx (UnityEngine.Touch)+10]");
		_ = 0;
		_ = touch.m_TapCount;
		_ = touch.m_maximumPossiblePressure;
		_ = touch.m_AzimuthAngle;
		StartPosition = touch.m_Position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [touch @ rdx (UnityEngine.Touch)+8]");
		_ = 0;
		EndPosition = touch.m_Position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [touch @ rdx (UnityEngine.Touch)+8]");
		_ = 0;
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rax_v3 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		Velocity = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
		object obj = Time.time;
		StartTime = (float)Vector2.zeroVector;
		EndTime = (float)Vector2.zeroVector;
		Duration = 0f;
		Tap = false;
		Distance = 0f;
		GameObject = gameObject;
		DraggedObject = null;
	}

	public unsafe override string ToString()
	{
		//IL_03eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f0: Expected O, but got Unknown
		//IL_040d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0412: Expected O, but got Unknown
		//IL_0431: Unknown result type (might be due to invalid IL or missing references)
		//IL_0436: Expected O, but got Unknown
		//IL_044e: Expected native int or pointer, but got O
		//IL_045c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0461: Expected O, but got Unknown
		//IL_0335: Unknown result type (might be due to invalid IL or missing references)
		//IL_033a: Expected O, but got Unknown
		//IL_0357: Unknown result type (might be due to invalid IL or missing references)
		//IL_035c: Expected O, but got Unknown
		//IL_037b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0380: Expected O, but got Unknown
		//IL_0398: Expected native int or pointer, but got O
		//IL_03a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ab: Expected O, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_0053: Expected I4, but got O
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected O, but got Unknown
		//IL_009e: Expected I, but got O
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_011b: Expected I, but got O
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Expected O, but got Unknown
		//IL_0198: Expected I, but got O
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Expected O, but got Unknown
		//IL_0215: Expected I, but got O
		//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ce: Expected O, but got Unknown
		//IL_02e2: Expected native int or pointer, but got O
		//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fa: Expected O, but got Unknown
		//IL_028f: Expected I, but got O
		object obj2 = default(object);
		if (!Tap)
		{
			if (!LongTap)
			{
				object[] array = new object[5];
				object obj = obj2 + 16;
				_ = Direction;
				object obj3 = (Swipe)obj;
				if (array != null)
				{
					if (obj3 != null)
					{
						nint num = (nint)array;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj4 = default(object);
						if (obj4 == null)
						{
							ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
							throw ex;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					object obj5 = obj2 + 16;
					_ = RawDirection;
					object obj6 = (Vector2)obj5;
					if (obj6 != null)
					{
						nint num2 = (nint)array;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj7 = default(object);
						if (obj7 == null)
						{
							ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
							throw ex2;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					object obj8 = obj2 + 16;
					_ = StartPosition;
					object obj9 = (Vector2)obj8;
					if (obj9 != null)
					{
						nint num3 = (nint)array;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj10 = default(object);
						if (obj10 == null)
						{
							ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
							throw ex3;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					object obj11 = obj2 + 16;
					_ = EndPosition;
					object obj12 = (Vector2)obj11;
					if (obj12 != null)
					{
						nint num4 = (nint)array;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj13 = default(object);
						if (obj13 == null)
						{
							ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
							throw ex4;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					object obj14 = obj2 + 16;
					_ = Duration;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
					object obj15 = default(object);
					if (obj15 != null)
					{
						nint num5 = (nint)array;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj16 = default(object);
						if (obj16 == null)
						{
							ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
							throw ex5;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					System.ParamsArray paramsArray = (System.ParamsArray)(obj2 - 64);
					_ = 0;
					_ = 0;
					System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)paramsArray, new System.ParamsArray(array));
					System.ParamsArray args = (System.ParamsArray)(obj2 - 32);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-40]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-30]");
					_ = 0;
					return string.FormatHelper((IFormatProvider)null, "[Swipe: {0}, From {1}, To {2}, Delta {3}, Time {4:0.00}s]", args);
				}
				return (string)(object)new NullReferenceException();
			}
			object obj17 = obj2 + 16;
			_ = StartPosition;
			object arg = (Vector2)obj17;
			object obj18 = obj2 + 16;
			_ = Duration;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			System.ParamsArray paramsArray2 = (System.ParamsArray)(obj2 - 64);
			_ = 0;
			_ = 0;
			object arg2 = default(object);
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)paramsArray2, new System.ParamsArray(arg, arg2));
			System.ParamsArray args2 = (System.ParamsArray)(obj2 - 32);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-40]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-30]");
			_ = 0;
			return string.FormatHelper((IFormatProvider)null, "[LongTap: At {0}, Time {1:0.00}s]", args2);
		}
		object obj19 = obj2 + 16;
		_ = StartPosition;
		object arg3 = (Vector2)obj19;
		object obj20 = obj2 + 16;
		_ = Duration;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		System.ParamsArray paramsArray3 = (System.ParamsArray)(obj2 - 64);
		_ = 0;
		_ = 0;
		object arg4 = default(object);
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)paramsArray3, new System.ParamsArray(arg3, arg4));
		System.ParamsArray args3 = (System.ParamsArray)(obj2 - 32);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-40]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rsp-30]");
		_ = 0;
		return string.FormatHelper((IFormatProvider)null, "[Tap: At {0}, Time {1:0.00}s]", args3);
	}
}
