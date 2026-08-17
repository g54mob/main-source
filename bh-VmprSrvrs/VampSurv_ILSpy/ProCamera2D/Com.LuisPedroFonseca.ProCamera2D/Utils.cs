using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D;

public static class Utils
{
	public static float EaseFromTo(float start, float end, float value, EaseType type = EaseType.EaseInOut)
	{
		//IL_0009: Invalid comparison between I4 and F4
		//IL_0054: Expected F4, but got I4
		//IL_02bc: Invalid comparison between I4 and F4
		//IL_0067: Expected O, but got I4
		//IL_025a: Expected F4, but got I4
		//IL_0173: Invalid comparison between I4 and F4
		//IL_01dc: Expected F4, but got I4
		//IL_009b: Invalid comparison between I4 and F4
		//IL_00fc: Expected F4, but got I4
		float num = default(float);
		if (!(0f > num))
		{
			if (num > 1f)
			{
				num = 1f;
			}
		}
		else
		{
			num = 0f;
		}
		bool flag = type == EaseType.EaseInOut;
		float num4;
		float num6;
		if (!flag)
		{
			object obj = type - 1;
			if (!flag)
			{
				if ((nint)obj == 1)
				{
					float num2 = num * (float)Math.PI;
					float num3 = num2 * 0.5f;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
					num4 = 1f - num3;
					goto IL_02b3;
				}
				if (!(0f > num))
				{
					if (num > 1f)
					{
						float num5 = end - start;
						num6 = num5 * 1f;
						goto IL_029f;
					}
				}
				else
				{
					num = 0f;
				}
				float num7 = end - start;
				num6 = num7 * num;
			}
			else
			{
				float num8 = num * (float)Math.PI;
				float num9 = num8 * 0.5f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				float num10;
				if (!(0f > num9))
				{
					bool flag2 = !(num9 > 1f);
					num10 = num9;
					if (!flag2)
					{
						float num11 = end - start;
						num6 = num11 * 1f;
						goto IL_029f;
					}
				}
				else
				{
					num10 = 0f;
				}
				float num12 = end - start;
				num6 = num12 * num10;
			}
			goto IL_029f;
		}
		float num13 = num + num;
		float num14 = num * num;
		float num15 = 3f - num13;
		num4 = num15 * num14;
		goto IL_02b3;
		IL_02b3:
		if (!(0f > num4))
		{
			if (num4 > 1f)
			{
				num4 = 1f;
			}
		}
		else
		{
			num4 = 0f;
		}
		float num16 = end - start;
		num6 = num16 * num4;
		goto IL_029f;
		IL_029f:
		return num6 + start;
	}

	public static float SmoothApproach(float pastPosition, float pastTargetPosition, float targetPosition, float speed, float deltaTime)
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		object obj = default(object);
		float num = speed * (float)obj;
		float num2 = targetPosition - pastTargetPosition;
		float num3 = num2 / num;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj2 = num ^ 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6F490");
		float num4 = pastPosition - pastTargetPosition;
		float num5 = targetPosition - num3;
		float num6 = num4 + num3;
		float num7 = (float)obj2 * num6;
		return num7 + num5;
	}

	public static float Remap(float value, float from1, float to1, float from2, float to2)
	{
		float num = to1 - from1;
		float num2 = value - from1;
		float num4 = default(float);
		float num3 = num4 - from2;
		float num5 = num2 / num;
		float num6 = num5 * num3;
		float num7 = num6 + from2;
		if (!(from2 > num7))
		{
			if (num7 > num4)
			{
				return num4;
			}
			return num7;
		}
		return from2;
	}

	public unsafe static void DrawArrowForGizmo(Vector3 pos, Vector3 direction, float arrowHeadLength = 0.25f, float arrowHeadAngle = 20f)
	{
		//IL_008f: Expected O, but got Ref
		//IL_008f: Expected O, but got Ref
		//IL_008f: Expected O, but got Ref
		_ = direction.x;
		_ = pos.x;
		float num = direction.z + pos.z;
		_ = pos.x;
		Vector3 from = default(Vector3);
		Vector3 to = default(Vector3);
		Gizmos.DrawLine_Injected(ref from, ref to);
		Gizmos.get_color_Injected(out Color ret);
		float arrowHeadLength2 = default(float);
		float arrowHeadAngle2 = default(float);
		DrawArrowEnd(gizmos: true, (Vector3)(&to), (Vector3)(&from), (Color)(&ret), arrowHeadLength2, arrowHeadAngle2);
	}

	public unsafe static void DrawArrowForGizmo(Vector3 pos, Vector3 direction, Color color, float arrowHeadLength = 0.25f, float arrowHeadAngle = 20f)
	{
		//IL_0081: Expected O, but got Ref
		//IL_0081: Expected O, but got Ref
		//IL_0081: Expected O, but got Ref
		_ = direction.x;
		_ = pos.x;
		float num = direction.z + pos.z;
		_ = pos.x;
		Vector3 from = default(Vector3);
		Vector3 to = default(Vector3);
		Gizmos.DrawLine_Injected(ref from, ref to);
		object obj = default(object);
		float arrowHeadLength2 = default(float);
		float arrowHeadAngle2 = default(float);
		DrawArrowEnd(gizmos: true, (Vector3)(&to), (Vector3)(&from), (Color)(&obj), arrowHeadLength2, arrowHeadAngle2);
	}

	public unsafe static void DrawArrowForDebug(Vector3 pos, Vector3 direction, float arrowHeadLength = 0.25f, float arrowHeadAngle = 20f)
	{
		//IL_0038: Expected O, but got Ref
		//IL_0038: Expected O, but got Ref
		//IL_0038: Expected O, but got Ref
		//IL_006e: Expected F4, but got I4
		//IL_006e: Expected O, but got Ref
		//IL_006e: Expected O, but got Ref
		//IL_006e: Expected O, but got Ref
		Color ret = default(Color);
		float num = default(float);
		object obj = default(object);
		bool flag = default(bool);
		Debug.DrawRay((Vector3)(&ret), (Vector3)(&num), (Color)(&obj), 0f, flag);
		Gizmos.get_color_Injected(out ret);
		float arrowHeadAngle2 = default(float);
		DrawArrowEnd(gizmos: false, (Vector3)(&num), (Vector3)(&ret), (Color)(&obj), flag ? 1 : 0, arrowHeadAngle2);
	}

	public unsafe static void DrawArrowForDebug(Vector3 pos, Vector3 direction, Color color, float arrowHeadLength = 0.25f, float arrowHeadAngle = 20f)
	{
		//IL_0027: Expected O, but got Ref
		//IL_0027: Expected O, but got Ref
		//IL_0027: Expected O, but got Ref
		//IL_0045: Expected F4, but got I4
		//IL_0045: Expected O, but got Ref
		//IL_0045: Expected O, but got Ref
		//IL_0045: Expected O, but got Ref
		float num = default(float);
		float num2 = default(float);
		float num3 = default(float);
		bool flag = default(bool);
		Debug.DrawRay((Vector3)(&num), (Vector3)(&num2), (Color)(&num3), 0f, flag);
		float arrowHeadAngle2 = default(float);
		DrawArrowEnd(gizmos: false, (Vector3)(&num2), (Vector3)(&num), (Color)(&num3), flag ? 1 : 0, arrowHeadAngle2);
	}

	private unsafe static void DrawArrowEnd(bool gizmos, Vector3 pos, Vector3 direction, Color color, float arrowHeadLength = 0.25f, float arrowHeadAngle = 20f)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0728: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_07ea: Expected O, but got Ref
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected O, but got Unknown
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Expected O, but got Unknown
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Expected O, but got Unknown
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Expected O, but got Unknown
		//IL_080e: Expected I, but got O
		//IL_0838: Expected O, but got I
		//IL_087f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0884: Expected O, but got Unknown
		//IL_0894: Unknown result type (might be due to invalid IL or missing references)
		//IL_0899: Expected O, but got Unknown
		//IL_08a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ae: Expected O, but got Unknown
		//IL_08be: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c3: Expected O, but got Unknown
		//IL_08e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e5: Expected O, but got Unknown
		//IL_094b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0950: Expected O, but got Unknown
		//IL_09cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d0: Expected O, but got Unknown
		//IL_09fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a03: Expected O, but got Unknown
		//IL_0a2a: Expected O, but got Ref
		//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Expected O, but got Unknown
		//IL_0324: Unknown result type (might be due to invalid IL or missing references)
		//IL_0329: Expected O, but got Unknown
		//IL_03cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d2: Expected O, but got Unknown
		//IL_03da: Unknown result type (might be due to invalid IL or missing references)
		//IL_03df: Expected O, but got Unknown
		//IL_0a4e: Expected I, but got O
		//IL_0b8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b91: Expected O, but got Unknown
		//IL_0baf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb4: Expected O, but got Unknown
		//IL_0c29: Expected O, but got Ref
		//IL_046d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0472: Expected O, but got Unknown
		//IL_04bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c0: Expected O, but got Unknown
		//IL_0564: Unknown result type (might be due to invalid IL or missing references)
		//IL_0569: Expected O, but got Unknown
		//IL_0571: Unknown result type (might be due to invalid IL or missing references)
		//IL_0576: Expected O, but got Unknown
		//IL_0c4e: Expected I, but got O
		//IL_0d9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0da1: Expected O, but got Unknown
		//IL_0db2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0db7: Expected O, but got Unknown
		//IL_0e0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e12: Expected O, but got Unknown
		//IL_0e23: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e28: Expected O, but got Unknown
		//IL_0e44: Expected O, but got Ref
		//IL_0604: Unknown result type (might be due to invalid IL or missing references)
		//IL_0609: Expected O, but got Unknown
		//IL_0680: Unknown result type (might be due to invalid IL or missing references)
		//IL_0685: Expected O, but got Unknown
		//IL_06c6: Expected O, but got Ref
		//IL_06e5: Expected O, but got Ref
		//IL_0044: Expected O, but got Ref
		//IL_0044: Expected O, but got Ref
		//IL_0044: Expected O, but got Ref
		//IL_0708: Expected O, but got Ref
		//IL_0063: Expected O, but got Ref
		//IL_0063: Expected O, but got Ref
		//IL_0063: Expected O, but got Ref
		//IL_00a0: Expected O, but got Ref
		//IL_00a0: Expected O, but got Ref
		//IL_00a0: Expected O, but got Ref
		//IL_00bf: Expected O, but got Ref
		//IL_00bf: Expected O, but got Ref
		//IL_00bf: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rcx_v3 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		float num3 = direction.x - (float)Vector3.zeroVector;
		object obj4 = default(object);
		object obj3 = obj4 - obj4;
		float num4 = direction.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rax_v3 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		float num5 = num4 - 0f;
		object obj5 = obj3 * obj3;
		float num6 = num3 * num3;
		float num7 = num5 * num5;
		float num8 = (float)obj5 + num6;
		float num9 = num8 + num7;
		if (!(9.9999994E-11f > num9))
		{
			nint num10 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rcx_v5 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num11 = 0;
			_ = Vector3.upVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rax_v6 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
			_ = 0;
			object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
			float from = default(float);
			Quaternion.LookRotation_Injected(ref *(Vector3*)(&from), ref *(Vector3*)obj6, out Quaternion ret);
			Vector3 to = default(Vector3);
			float ret2;
			Quaternion.Internal_FromEulerRad_Injected(ref to, out *(Quaternion*)(&ret2));
			object obj8 = default(object);
			object obj7 = obj8 * (object)ret;
			object obj10 = default(object);
			object obj11 = default(object);
			object obj9 = obj10 * obj11;
			object obj13 = default(object);
			object obj12 = ret2 * obj13;
			object obj15 = default(object);
			object obj14 = obj15 * obj13;
			object obj16 = obj12 + obj7;
			object obj17 = obj10 * obj13;
			object obj19 = default(object);
			object obj18 = obj15 * obj19;
			object obj20 = obj16 + obj9;
			object obj21 = ret2 * obj19;
			object obj22 = obj20 - obj18;
			object obj23 = obj8 * obj11;
			object obj24 = obj14 + obj23;
			object obj25 = obj10 * obj19;
			object obj26 = obj10 * (object)ret;
			object obj27 = obj24 + obj21;
			object obj28 = obj15 * (object)ret;
			object obj29 = obj15 * obj11;
			object obj30 = obj27 - obj26;
			object obj31 = obj8 * obj19;
			object obj32 = obj8 * obj13;
			object obj33 = obj17 + obj31;
			object obj34 = ret2 * ret;
			object obj35 = ret2 * obj11;
			object obj36 = obj32 - obj34;
			object obj37 = obj33 + obj28;
			object obj38 = obj36 - obj29;
			object obj39 = obj37 - obj35;
			object obj40 = obj38 - obj25;
			nint num12 = (nint)typeof(Vector3);
			object obj41 = obj22 + obj22;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+80]");
			nint num13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+80]");
			object obj42 = num13 + 0;
			object obj43 = obj30 + obj30;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v590 @ rcx_v11 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num14 = 0;
			object obj44 = obj41 * obj40;
			object obj45 = obj41 * obj22;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-78]");
			object obj46 = obj42 * 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-78]");
			object obj47 = obj43 * 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-74]");
			object obj48 = obj43 * 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-74]");
			object obj49 = obj42 * 0;
			object obj50 = obj42 * obj40;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+80]");
			object obj51 = obj42 * 0;
			object obj52 = obj43 * obj40;
			object obj53 = obj51 + obj48;
			object obj54 = obj52 + obj46;
			object obj55 = obj51 + obj45;
			float num15 = 1f - (float)obj53;
			object obj56 = obj47 - obj50;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v596 @ rax_v16 (Il2CppStaticFields<UnityEngine.Vector3>)+5C]");
			object obj57 = obj54 * 0;
			object obj58 = obj50 + obj47;
			object obj59 = obj56 * obj11;
			float num16 = num15 * (float)Vector3.backVector;
			object obj60 = obj58 * (object)Vector3.backVector;
			float num17 = num16 + (float)obj59;
			float num18 = num17 + (float)obj57;
			float num19 = 1f - (float)obj55;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+80]");
			object obj61 = obj49 - 0;
			float num20 = num19 * (float)obj11;
			float num21 = num20 + (float)obj60;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v596 @ rax_v16 (Il2CppStaticFields<UnityEngine.Vector3>)+5C]");
			object obj62 = obj61 * 0;
			float num22 = num21 + (float)obj62;
			_ = direction.z;
			_ = direction.x;
			object obj63 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
			Vector3 upwards = default(Vector3);
			Quaternion.LookRotation_Injected(ref *(Vector3*)obj63, ref upwards, out ret);
			Quaternion.Internal_FromEulerRad_Injected(ref to, out *(Quaternion*)(&ret2));
			object obj64 = obj8 * (object)ret;
			object obj65 = obj10 * obj11;
			object obj66 = ret2 * obj13;
			object obj67 = obj15 * obj13;
			object obj68 = obj66 + obj64;
			object obj69 = obj10 * obj13;
			object obj70 = obj15 * obj19;
			object obj71 = obj68 + obj65;
			object obj72 = ret2 * obj19;
			object obj73 = obj71 - obj70;
			object obj74 = obj8 * obj11;
			object obj75 = obj67 + obj74;
			object obj76 = obj10 * (object)ret;
			object obj77 = obj10 * obj19;
			object obj78 = obj75 + obj72;
			object obj79 = obj15 * (object)ret;
			object obj80 = obj15 * obj11;
			object obj81 = obj78 - obj76;
			object obj82 = obj8 * obj19;
			object obj83 = obj8 * obj13;
			object obj84 = obj69 + obj82;
			object obj85 = ret2 * ret;
			object obj86 = ret2 * obj11;
			object obj87 = obj83 - obj85;
			object obj88 = obj84 + obj79;
			object obj89 = obj87 - obj80;
			object obj90 = obj88 - obj86;
			object obj91 = obj89 - obj77;
			nint num23 = (nint)typeof(Vector3);
			object obj92 = obj73 + obj73;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v926 @ rcx_v18 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num24 = 0;
			object obj93 = obj90 + obj90;
			object obj94 = obj81 + obj81;
			object obj95 = obj73 * obj92;
			object obj96 = obj91 * obj92;
			object obj97 = obj73 * obj94;
			object obj98 = obj81 * obj94;
			object obj99 = obj91 * obj94;
			object obj100 = obj91 * obj93;
			object obj101 = obj73 * obj93;
			object obj102 = obj90 * obj93;
			object obj103 = obj81 * obj93;
			object obj104 = obj102 + obj98;
			object obj105 = obj98 + obj95;
			float num25 = 1f - (float)obj104;
			object obj106 = obj97 - obj100;
			float num26 = num25 * (float)Vector3.backVector;
			object obj107 = obj106 * obj11;
			float num27 = num26 + (float)obj107;
			object obj108 = obj99 + obj101;
			object obj109 = obj101 - obj99;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v934 @ rax_v28 (Il2CppStaticFields<UnityEngine.Vector3>)+5C]");
			object obj110 = obj108 * 0;
			object obj111 = obj109 * (object)Vector3.backVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+80]");
			object obj112 = 0 + obj110;
			object obj113 = obj96 + obj103;
			object obj114 = obj113 * obj11;
			float num28 = 1f - (float)obj105;
			object obj115 = obj114 + obj111;
			float num29 = num28;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v934 @ rax_v28 (Il2CppStaticFields<UnityEngine.Vector3>)+5C]");
			float num30 = num29 * 0f;
			float num31 = (float)obj115 + num30;
			_ = direction.z;
			_ = direction.x;
			object obj116 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
			Vector3 upwards2 = default(Vector3);
			Quaternion.LookRotation_Injected(ref *(Vector3*)obj116, ref upwards2, out ret);
			Quaternion.Internal_FromEulerRad_Injected(ref to, out *(Quaternion*)(&ret2));
			object obj117 = obj8 * (object)ret;
			object obj118 = obj10 * obj11;
			object obj119 = ret2 * obj13;
			object obj120 = obj15 * obj13;
			object obj121 = obj119 + obj117;
			object obj122 = obj10 * obj13;
			object obj123 = obj15 * obj19;
			object obj124 = obj121 + obj118;
			object obj125 = ret2 * obj19;
			object obj126 = obj124 - obj123;
			object obj127 = obj8 * obj11;
			object obj128 = obj120 + obj127;
			object obj129 = obj10 * obj19;
			object obj130 = obj10 * (object)ret;
			object obj131 = obj128 + obj125;
			object obj132 = obj15 * (object)ret;
			object obj133 = obj15 * obj11;
			object obj134 = obj131 - obj130;
			object obj135 = obj8 * obj19;
			object obj136 = obj8 * obj13;
			object obj137 = obj122 + obj135;
			object obj138 = ret2 * ret;
			object obj139 = ret2 * obj11;
			object obj140 = obj136 - obj138;
			object obj141 = obj137 + obj132;
			object obj142 = obj140 - obj133;
			object obj143 = obj141 - obj139;
			object obj144 = obj142 - obj129;
			nint num32 = (nint)typeof(Vector3);
			object obj145 = obj134 + obj134;
			object obj146 = obj126 + obj126;
			object obj147 = obj143 + obj143;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1297 @ rcx_v25 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num33 = 0;
			object obj148 = obj134 * obj145;
			object obj149 = obj144 * obj145;
			object obj150 = obj145 * obj126;
			object obj151 = obj147 * obj126;
			object obj152 = obj146 * obj126;
			object obj153 = obj144 * obj146;
			object obj154 = obj144 * obj147;
			object obj155 = obj134 * obj147;
			object obj156 = obj143 * obj147;
			object obj157 = obj156 + obj148;
			object obj158 = obj156 + obj152;
			float num34 = 1f - (float)obj157;
			object obj159 = obj150 - obj154;
			object obj160 = obj154 + obj150;
			float num35 = num34 * (float)Vector3.backVector;
			object obj161 = obj159 * obj11;
			object obj162 = obj160 * (object)Vector3.backVector;
			float num36 = num35 + (float)obj161;
			object obj163 = obj149 + obj151;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1305 @ rax_v40 (Il2CppStaticFields<UnityEngine.Vector3>)+5C]");
			object obj164 = obj163 * 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-80]");
			object obj165 = 0 + obj164;
			float num37 = 1f - (float)obj158;
			float num38 = num37 * (float)obj11;
			float num39 = num38 + (float)obj162;
			object obj166 = obj155 - obj153;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1305 @ rax_v40 (Il2CppStaticFields<UnityEngine.Vector3>)+5C]");
			object obj167 = obj166 * 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-7C]");
			object obj168 = 0 + obj167;
			_ = direction.z;
			_ = direction.x;
			object obj169 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
			Vector3 upwards3 = default(Vector3);
			Quaternion.LookRotation_Injected(ref *(Vector3*)obj169, ref upwards3, out ret);
			Quaternion.Internal_FromEulerRad_Injected(ref to, out *(Quaternion*)(&ret2));
			object obj170 = obj8 * (object)ret;
			object obj171 = obj10 * obj11;
			object obj172 = ret2 * obj13;
			object obj173 = obj172 + obj170;
			object obj174 = obj10 * obj13;
			object obj175 = obj15 * obj19;
			object obj176 = obj173 + obj171;
			object obj177 = obj176 - obj175;
			object obj178 = obj15 * (object)ret;
			object obj179 = obj8 * obj19;
			object obj180 = obj174 + obj179;
			object obj181 = ret2 * obj11;
			object obj182 = obj180 + obj178;
			object obj183 = obj182 - obj181;
			object obj184 = obj183 + obj183;
			object obj185 = obj177 + obj177;
			object obj186 = obj177 * obj185;
			object obj187 = obj183 * obj184;
			object obj188 = obj187 + obj186;
			if (!gizmos)
			{
				bool depthTest = default(bool);
				Debug.DrawRay((Vector3)(&upwards3), (Vector3)(&to), (Color)(&ret2), 0f, depthTest);
				Debug.DrawRay((Vector3)(&from), (Vector3)(&to), (Color)(&ret2), 0f, depthTest);
				float num40 = direction.z + pos.z;
				Debug.DrawRay((Vector3)(&from), (Vector3)(&to), (Color)(&ret2), 0f, depthTest);
				Debug.DrawRay((Vector3)(&from), (Vector3)(&to), (Color)(&ret2), 0f, depthTest);
				return;
			}
			_ = color.r;
			object obj189 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
			Gizmos.set_color_Injected(ref *(Color*)obj189);
			Gizmos.DrawLine_Injected(ref *(Vector3*)(&from), ref to);
			float num41 = direction.z + pos.z;
			float num42 = num31;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+90]");
			float num43 = num42 * 0f;
			float num44 = num43 + num41;
			object obj190 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
			Gizmos.DrawLine_Injected(ref *(Vector3*)(&ret), ref *(Vector3*)obj190);
			Gizmos.DrawLine_Injected(ref *(Vector3*)(&from), ref to);
			float num45 = direction.z + pos.z;
			object obj191 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
			Gizmos.DrawLine_Injected(ref *(Vector3*)obj191, ref *(Vector3*)(&ret));
		}
	}

	public static bool AreNearlyEqual(float a, float b, float tolerance = 0.02f)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		//IL_002c: Invalid comparison between F4 and O
		//IL_004a: Invalid comparison between F4 and I4
		float num = a - b;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj = num & 0;
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)tolerance) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
		float num2 = tolerance - (float)obj;
		bool flag2 = num2 == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		return flag4 & flag3;
	}

	public unsafe static Vector2 GetScreenSizeInWorldCoords(Camera gameCamera, float distance = 10f)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_0111: Expected O, but got I4
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Expected O, but got Unknown
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Expected O, but got Unknown
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Expected O, but got Unknown
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Expected O, but got Unknown
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Expected O, but got Unknown
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Expected O, but got Unknown
		//IL_02b6: Expected O, but got I
		//IL_02d3: Expected O, but got I
		//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e1: Expected O, but got Unknown
		//IL_0312: Expected O, but got I
		//IL_032f: Expected O, but got I
		//IL_0338: Unknown result type (might be due to invalid IL or missing references)
		//IL_033d: Expected O, but got Unknown
		//IL_0356->IL0131: Incompatible stack heights: 4 vs 1
		object obj2 = default(object);
		object obj = obj2 - 95;
		bool flag = ((UnityEngine.Object)gameCamera).m_CachedPtr == (IntPtr)0;
		object obj3 = Camera.get_orthographic_Injected(((UnityEngine.Object)gameCamera).m_CachedPtr);
		if (obj3 == null)
		{
			float fieldOfView = gameCamera.fieldOfView;
			float num = fieldOfView * 0.5f;
			float num2 = num * ((float)Math.PI / 180f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B745E0");
			float aspect = gameCamera.aspect;
		}
		else
		{
			float orthographicSize = gameCamera.orthographicSize;
			if (!(0.001f < orthographicSize))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07BB0");
				Vector2 result = default(Vector2);
				return result;
			}
			float nearClipPlane = gameCamera.nearClipPlane;
			_ = 0;
			_ = 0;
			bool flag2 = ((UnityEngine.Object)gameCamera).m_CachedPtr == (IntPtr)0;
			object obj4 = obj - 9;
			object obj5 = obj + 7;
			Camera.ViewportToWorldPoint_Injected(((UnityEngine.Object)gameCamera).m_CachedPtr, ref *(Vector3*)obj5, Camera.MonoOrStereoscopicEye.Mono, out *(Vector3*)obj4);
			float nearClipPlane2 = gameCamera.nearClipPlane;
			_ = 0;
			_ = 0;
			bool flag3 = ((UnityEngine.Object)gameCamera).m_CachedPtr == (IntPtr)0;
			object obj6 = obj - 25;
			object obj7 = obj + 7;
			Camera.ViewportToWorldPoint_Injected(((UnityEngine.Object)gameCamera).m_CachedPtr, ref *(Vector3*)obj7, Camera.MonoOrStereoscopicEye.Mono, out *(Vector3*)obj6);
			float nearClipPlane3 = gameCamera.nearClipPlane;
			_ = 0;
			_ = 0;
			bool flag4 = ((UnityEngine.Object)gameCamera).m_CachedPtr == (IntPtr)0;
			object obj8 = obj + 7;
			object obj9 = obj + 23;
			Camera.ViewportToWorldPoint_Injected(((UnityEngine.Object)gameCamera).m_CachedPtr, ref *(Vector3*)obj9, Camera.MonoOrStereoscopicEye.Mono, out *(Vector3*)obj8);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-15]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-5]");
			object obj10 = num3 - 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-11]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-1]");
			object obj11 = num4 - 0;
			object obj12 = obj - 9;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A8670");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1+B]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-15]");
			object obj13 = num5 - 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1+F]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ rbp_v1-11]");
			object obj14 = num6 - 0;
			object obj15 = obj - 9;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A8670");
		}
		Vector2 result2 = default(Vector2);
		return result2;
	}

	public unsafe static Vector3 GetVectorsSum(IList<Vector3> input)
	{
		//IL_00b1: Expected native int or pointer, but got O
		//IL_00bf: Expected native int or pointer, but got O
		//IL_00dc: Expected I, but got O
		//IL_00fa: Expected F4, but got O
		//IL_00f5: Expected native int or pointer, but got O
		//IL_010f: Expected F4, but got I
		//IL_010a: Expected native int or pointer, but got O
		//IL_0076: Expected native int or pointer, but got O
		//IL_0083: Expected native int or pointer, but got O
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = 0f;
		((Vector3*)(nint)vector)->z = 0f;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rax_v4 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		((Vector3*)(nint)vector)->x = (float)Vector3.zeroVector;
		Vector3 vector2 = vector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rax_v5 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		((Vector3*)(nint)vector2)->z = 0f;
		bool flag = input == null;
		int num3 = 0;
		int num4 = 0;
		if (!flag)
		{
			float x = default(float);
			while (true)
			{
				int count = input.Count;
				if (num4 >= count)
				{
					break;
				}
				Vector3 vector3 = input.get_Item(num3);
				float z = vector.z + vector3.z;
				num3++;
				((Vector3*)(nint)vector)->x = x;
				((Vector3*)(nint)vector)->z = z;
				num4 = num3;
			}
			return vector;
		}
		return (Vector3)new NullReferenceException();
	}

	public static float AlignToGrid(float input, float gridSize)
	{
		float num = input / gridSize;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
		float num2 = num * gridSize;
		float num3 = num2 / gridSize;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
		return num3 * gridSize;
	}

	public static bool IsInsideRectangle(float x, float y, float width, float height, float pointX, float pointY)
	{
		//IL_0027: Invalid comparison between O and F4
		//IL_0062: Invalid comparison between F4 and O
		//IL_009d: Invalid comparison between O and F4
		//IL_00d8: Invalid comparison between F4 and O
		float num = width * 0.5f;
		float num2 = x - num;
		object obj = default(object);
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2))
		{
			float num3 = width * 0.5f;
			float num4 = num3 + x;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num4) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
			{
				float num5 = height * 0.5f;
				float num6 = y - num5;
				object obj2 = default(object);
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num6))
				{
					float num7 = height * 0.5f;
					float num8 = num7 + y;
					bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num8) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2);
					return !flag;
				}
			}
		}
		return false;
	}

	public static bool IsInsideCircle(float x, float y, float radius, float pointX, float pointY)
	{
		//IL_0080: Invalid comparison between F4 and I4
		float num = pointX - x;
		object obj = default(object);
		float num2 = (float)obj - y;
		float num3 = radius * radius;
		float num4 = num * num;
		float num5 = num2 * num2;
		float num6 = num5 + num4;
		bool flag = num3 < num6;
		float num7 = num3 - num6;
		bool flag2 = num7 == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		return flag4 & flag3;
	}
}
