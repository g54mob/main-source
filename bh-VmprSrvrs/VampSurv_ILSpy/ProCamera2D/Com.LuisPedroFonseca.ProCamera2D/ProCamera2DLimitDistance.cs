using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D;

public class ProCamera2DLimitDistance : BasePC2D, IPositionDeltaChanger
{
	public static string ExtensionName = "Limit Distance";

	public bool UseTargetsPosition;

	public bool LimitTopCameraDistance;

	public float MaxTopTargetDistance;

	public bool LimitBottomCameraDistance;

	public float MaxBottomTargetDistance;

	public bool LimitLeftCameraDistance;

	public float MaxLeftTargetDistance;

	public bool LimitRightCameraDistance;

	public float MaxRightTargetDistance;

	private int _pdcOrder;

	public int PDCOrder
	{
		get
		{
			return _pdcOrder;
		}
		set
		{
			_pdcOrder = value;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		ProCamera2D proCamera2D = base.ProCamera2D;
		proCamera2D.AddPositionDeltaChanger(this);
	}

	protected override void OnDestroy()
	{
		Disable();
		ProCamera2D proCamera2D = base.ProCamera2D;
		if ((object)proCamera2D != null && ((UnityEngine.Object)proCamera2D).m_CachedPtr != (IntPtr)0)
		{
			ProCamera2D proCamera2D2 = base.ProCamera2D;
			bool flag = ((List<object>)(object)proCamera2D2._positionDeltaChangers).Remove((object)this);
		}
	}

	public unsafe Vector3 AdjustDelta(float deltaTime, Vector3 originalDelta)
	{
		//IL_0008: Expected O, but got Ref
		//IL_09c4: Expected O, but got I4
		//IL_09ab: Expected native int or pointer, but got O
		//IL_0b01: Expected native int or pointer, but got O
		//IL_004a: Expected O, but got Ref
		//IL_0085: Expected O, but got Ref
		//IL_016f: Expected O, but got Ref
		//IL_01c6: Expected O, but got I
		//IL_00e9: Expected O, but got Ref
		//IL_09ef: Expected O, but got Ref
		//IL_09ff: Expected O, but got I
		//IL_0a2d: Expected O, but got I4
		//IL_0140: Expected O, but got I
		//IL_0a96: Expected O, but got I4
		//IL_0249: Expected O, but got Ref
		//IL_0259: Expected O, but got I
		//IL_029d: Expected O, but got F4
		//IL_02b7: Expected O, but got I4
		//IL_03d9: Expected O, but got Ref
		//IL_03e9: Expected O, but got I
		//IL_0428: Expected O, but got F4
		//IL_054b: Expected O, but got Ref
		//IL_055b: Expected O, but got I
		//IL_059f: Expected O, but got F4
		//IL_05c6: Expected O, but got I4
		//IL_0810: Expected O, but got I
		//IL_081e: Expected O, but got Ref
		//IL_082b: Expected O, but got F4
		//IL_06d8: Expected O, but got Ref
		//IL_06e8: Expected O, but got I
		//IL_0727: Expected O, but got F4
		//IL_030b: Expected O, but got Ref
		//IL_031b: Expected O, but got I
		//IL_034b: Expected O, but got F4
		//IL_0363: Expected O, but got I4
		//IL_08b6: Expected O, but got I
		//IL_08c4: Expected O, but got Ref
		//IL_08d1: Expected O, but got F4
		//IL_0480: Expected O, but got Ref
		//IL_0490: Expected O, but got I
		//IL_04c0: Expected O, but got F4
		//IL_04d8: Expected O, but got I4
		//IL_0965: Expected O, but got Ref
		//IL_097f: Expected F4, but got I
		//IL_098c: Expected F4, but got O
		//IL_0987: Expected native int or pointer, but got O
		//IL_060d: Expected O, but got Ref
		//IL_061d: Expected O, but got I
		//IL_064d: Expected O, but got F4
		//IL_0665: Expected O, but got I4
		//IL_077f: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
		object obj3 = Behaviour.get_enabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
		object obj11;
		float num;
		float num8;
		float cameraTargetHorizontalPositionSmoothed;
		object obj10;
		Vector3 vector3;
		if (obj3 != null)
		{
			Func<Vector3, float> vector3H = Vector3H;
			object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
			_ = originalDelta.x;
			_ = originalDelta.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v259 @ rcx_v11 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
			Func<Vector3, float> vector3V = Vector3V;
			object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
			_ = originalDelta.x;
			_ = originalDelta.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v260 @ rcx_v13 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
			Func<Vector3, float> vector3H2 = Vector3H;
			Vector3 vector;
			Vector3 vector2;
			if (UseTargetsPosition)
			{
				ProCamera2D proCamera2D = base.ProCamera2D;
				object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
				_ = proCamera2D._003CTargetsMidPoint_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ rax_v80 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+7C]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v209 @ rdi_v7 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
				Func<Vector3, float> vector3V2 = Vector3V;
				ProCamera2D proCamera2D2 = base.ProCamera2D;
				vector = proCamera2D2._003CTargetsMidPoint_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rax_v83 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+7C]");
				object obj7 = 0;
				vector2 = proCamera2D._003CTargetsMidPoint_003Ek__BackingField;
			}
			else
			{
				ProCamera2D proCamera2D3 = base.ProCamera2D;
				object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
				_ = proCamera2D3._003CCameraTargetPosition_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rax_v75 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+88]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v209 @ rdi_v7 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
				Func<Vector3, float> vector3V2 = Vector3V;
				ProCamera2D proCamera2D4 = base.ProCamera2D;
				vector = proCamera2D4._003CCameraTargetPosition_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ rax_v78 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+88]");
				object obj7 = 0;
				vector2 = proCamera2D3._003CCameraTargetPosition_003Ek__BackingField;
			}
			object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ rdi_v8 (System.Func`2<UnityEngine.Vector3, System.Single>)+18]");
			obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v212 @ rdi_v8 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
			bool flag2 = !LimitTopCameraDistance;
			obj11 = 0;
			num = originalDelta.x;
			vector3 = vector;
			if (!flag2)
			{
				ProCamera2D proCamera2D5 = base.ProCamera2D;
				Func<Vector3, float> vector3V3 = Vector3V;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rax_v66 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
				float num2 = 0f * 0.5f;
				float num3 = num2 * MaxTopTargetDistance;
				ProCamera2D proCamera2D6 = base.ProCamera2D;
				Vector3 localPosition = proCamera2D6.LocalPosition;
				object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ rdi_v21 (System.Func`2<UnityEngine.Vector3, System.Single>)+18]");
				obj10 = 0;
				_ = localPosition.x;
				_ = localPosition.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v213 @ rdi_v21 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
				float num4 = localPosition.x + originalDelta.x;
				vector3 = (Vector3)(num4 + num3);
				bool flag3 = System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref vector) <= System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref vector3);
				obj11 = 0;
				num = originalDelta.x;
				if (!flag3)
				{
					Func<Vector3, float> vector3V4 = Vector3V;
					ProCamera2D proCamera2D7 = base.ProCamera2D;
					Vector3 localPosition2 = proCamera2D7.LocalPosition;
					object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ rdi_v22 (System.Func`2<UnityEngine.Vector3, System.Single>)+18]");
					obj10 = 0;
					_ = localPosition2.x;
					_ = localPosition2.z;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v214 @ rdi_v22 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
					vector3 = (Vector3)(localPosition2.x + num3);
					num = (float)vector - (float)vector3;
					obj11 = 1;
				}
			}
			if (LimitBottomCameraDistance)
			{
				ProCamera2D proCamera2D8 = base.ProCamera2D;
				Func<Vector3, float> vector3V5 = Vector3V;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ rax_v57 (Com.LuisPedroFonseca.ProCamera2D.ProCamera2D)+64]");
				float num5 = 0f * 0.5f;
				float num6 = num5 * MaxBottomTargetDistance;
				ProCamera2D proCamera2D9 = base.ProCamera2D;
				Vector3 localPosition3 = proCamera2D9.LocalPosition;
				object obj14 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ rdi_v19 (System.Func`2<UnityEngine.Vector3, System.Single>)+18]");
				obj10 = 0;
				_ = localPosition3.x;
				_ = localPosition3.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v216 @ rdi_v19 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
				float num7 = localPosition3.x + num;
				vector3 = (Vector3)(num7 - num6);
				if (System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref vector3) > System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref vector))
				{
					Func<Vector3, float> vector3V6 = Vector3V;
					ProCamera2D proCamera2D10 = base.ProCamera2D;
					Vector3 localPosition4 = proCamera2D10.LocalPosition;
					object obj15 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ rdi_v20 (System.Func`2<UnityEngine.Vector3, System.Single>)+18]");
					obj10 = 0;
					_ = localPosition4.x;
					_ = localPosition4.z;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v217 @ rdi_v20 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
					vector3 = (Vector3)(localPosition4.x - num6);
					num = (float)vector - (float)vector3;
					obj11 = 1;
				}
			}
			bool flag4 = !LimitLeftCameraDistance;
			num8 = originalDelta.x;
			object obj16 = 0;
			if (!flag4)
			{
				ProCamera2D proCamera2D11 = base.ProCamera2D;
				Func<Vector3, float> vector3H3 = Vector3H;
				float num9 = (float)proCamera2D11._003CScreenSizeInWorldCoordinates_003Ek__BackingField * 0.5f;
				float num10 = num9 * MaxLeftTargetDistance;
				ProCamera2D proCamera2D12 = base.ProCamera2D;
				Vector3 localPosition5 = proCamera2D12.LocalPosition;
				object obj17 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ rdi_v17 (System.Func`2<UnityEngine.Vector3, System.Single>)+18]");
				obj10 = 0;
				_ = localPosition5.x;
				_ = localPosition5.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v219 @ rdi_v17 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
				float num11 = localPosition5.x + originalDelta.x;
				vector3 = (Vector3)(num11 - num10);
				bool flag5 = System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref vector3) <= System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref vector2);
				num8 = originalDelta.x;
				obj16 = 0;
				if (!flag5)
				{
					Func<Vector3, float> vector3H4 = Vector3H;
					ProCamera2D proCamera2D13 = base.ProCamera2D;
					Vector3 localPosition6 = proCamera2D13.LocalPosition;
					object obj18 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rdi_v18 (System.Func`2<UnityEngine.Vector3, System.Single>)+18]");
					obj10 = 0;
					_ = localPosition6.x;
					_ = localPosition6.z;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v220 @ rdi_v18 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
					vector3 = (Vector3)(localPosition6.x - num10);
					num8 = (float)vector2 - (float)vector3;
					obj16 = 1;
				}
			}
			if (LimitRightCameraDistance)
			{
				ProCamera2D proCamera2D14 = base.ProCamera2D;
				Func<Vector3, float> vector3H5 = Vector3H;
				float num12 = (float)proCamera2D14._003CScreenSizeInWorldCoordinates_003Ek__BackingField * 0.5f;
				float num13 = num12 * MaxRightTargetDistance;
				ProCamera2D proCamera2D15 = base.ProCamera2D;
				Vector3 localPosition7 = proCamera2D15.LocalPosition;
				object obj19 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ rdi_v15 (System.Func`2<UnityEngine.Vector3, System.Single>)+18]");
				obj10 = 0;
				_ = localPosition7.x;
				_ = localPosition7.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v222 @ rdi_v15 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
				float num14 = localPosition7.x + num8;
				vector3 = (Vector3)(num14 + num13);
				if (System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref vector2) > System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref vector3))
				{
					Func<Vector3, float> vector3H6 = Vector3H;
					ProCamera2D proCamera2D16 = base.ProCamera2D;
					Vector3 localPosition8 = proCamera2D16.LocalPosition;
					object obj20 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
					_ = localPosition8.x;
					_ = localPosition8.z;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v223 @ rdi_v16 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
					float num15 = localPosition8.x + num13;
					num8 = (float)vector2 - num15;
					goto IL_07e2;
				}
			}
			if (obj16 != null)
			{
				goto IL_07e2;
			}
			ProCamera2D proCamera2D17 = base.ProCamera2D;
			cameraTargetHorizontalPositionSmoothed = proCamera2D17._cameraTargetHorizontalPositionSmoothed;
			goto IL_0ac3;
		}
		float z = originalDelta.z;
		Vector3 vector4 = default(Vector3);
		((Vector3*)(nint)vector4)->x = originalDelta.x;
		goto IL_0af9;
		IL_07e2:
		ProCamera2D proCamera2D18 = base.ProCamera2D;
		Func<Vector3, float> vector3H7 = Vector3H;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rcx_v30 (System.Func`2<UnityEngine.Vector3, System.Single>)+18]");
		obj10 = 0;
		object obj21 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
		vector3 = (Vector3)originalDelta.x;
		float num16 = proCamera2D18._cameraTargetHorizontalPositionSmoothed + num8;
		_ = originalDelta.x;
		_ = originalDelta.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v285 @ rcx_v30 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
		cameraTargetHorizontalPositionSmoothed = num16 - originalDelta.x;
		goto IL_0ac3;
		IL_0ac3:
		ProCamera2D proCamera2D19 = base.ProCamera2D;
		float cameraTargetVerticalPositionSmoothed;
		if (obj11 != null)
		{
			Func<Vector3, float> vector3V7 = Vector3V;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v288 @ rcx_v26 (System.Func`2<UnityEngine.Vector3, System.Single>)+18]");
			obj10 = 0;
			object obj22 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
			vector3 = (Vector3)originalDelta.x;
			float num17 = proCamera2D19._cameraTargetVerticalPositionSmoothed + num;
			_ = originalDelta.x;
			_ = originalDelta.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v288 @ rcx_v26 (System.Func`2<UnityEngine.Vector3, System.Single>)+18] (should have been resolved before IL gen)");
			cameraTargetVerticalPositionSmoothed = num17 - originalDelta.x;
		}
		else
		{
			cameraTargetVerticalPositionSmoothed = proCamera2D19._cameraTargetVerticalPositionSmoothed;
		}
		ProCamera2D proCamera2D20 = base.ProCamera2D;
		proCamera2D20._cameraTargetHorizontalPositionSmoothed = cameraTargetHorizontalPositionSmoothed;
		proCamera2D20._cameraTargetVerticalPositionSmoothed = cameraTargetVerticalPositionSmoothed;
		Func<float, float, Vector3> vectorHV = VectorHV;
		object obj23 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v190 @ rdx_v19 (System.Func`3<System.Single, System.Single, UnityEngine.Vector3>)+18] (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1231 @ rax_v29+8]");
		z = 0f;
		object obj24 = default(object);
		((Vector3*)(nint)vector4)->x = (float)obj24;
		goto IL_0af9;
		IL_0af9:
		((Vector3*)(nint)vector4)->z = z;
		return vector4;
	}

	public ProCamera2DLimitDistance()
	{
		//IL_0078: Expected I, but got O
		UseTargetsPosition = true;
		MaxTopTargetDistance = 0.8f;
		LimitBottomCameraDistance = true;
		MaxBottomTargetDistance = 0.8f;
		LimitLeftCameraDistance = true;
		MaxLeftTargetDistance = 0.8f;
		LimitRightCameraDistance = true;
		MaxRightTargetDistance = 0.8f;
		_pdcOrder = 2000;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
