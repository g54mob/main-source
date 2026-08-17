using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

public class UIGradient : BaseMeshEffect
{
	public Color m_color1;

	public Color m_color2;

	public float m_angle;

	public bool m_ignoreRatio;

	public unsafe override void ModifyMesh(VertexHelper vh)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0406: Expected O, but got I4
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Expected O, but got Unknown
		//IL_0070: Expected O, but got Ref
		//IL_00b0: Expected F4, but got I
		//IL_00c0: Expected F4, but got I
		//IL_01cd: Expected O, but got I4
		//IL_01bf: Expected O, but got I
		//IL_0208: Expected O, but got I
		//IL_022d: Expected O, but got I
		//IL_0252: Expected O, but got I
		//IL_02b2: Invalid comparison between I4 and F4
		//IL_02fd: Expected F4, but got I4
		//IL_0595: Invalid comparison between I4 and F4
		//IL_0339: Expected F4, but got I4
		//IL_05cc: Invalid comparison between I4 and F4
		//IL_0375: Expected F4, but got I4
		//IL_0603: Invalid comparison between I4 and F4
		//IL_03b1: Expected F4, but got I4
		//IL_063a: Invalid comparison between I4 and F4
		//IL_03ed: Expected F4, but got I4
		//IL_06b2: Expected O, but got Ref
		//IL_06df: Expected O, but got I
		//IL_071a: Expected F4, but got I
		//IL_0499->IL073a: Incompatible stack heights: 2 vs 1
		object obj2 = default(object);
		object obj = (object)(&obj2);
		bool flag = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
		object obj3 = Behaviour.get_enabled_Injected(((UnityEngine.Object)this).m_CachedPtr);
		if (obj3 == null)
		{
			return;
		}
		Graphic graphic = base.graphic;
		RectTransform rectTransform = graphic.rectTransform;
		bool flag2 = ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0;
		RectTransform.get_rect_Injected(((UnityEngine.Object)rectTransform).m_CachedPtr, out Rect ret);
		float num = m_angle * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		bool flag3 = m_ignoreRatio;
		float num2 = num;
		object obj6 = default(object);
		object obj7 = default(object);
		if (!flag3)
		{
			object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 208));
			object obj5 = obj6 / obj7;
			float num3 = (float)obj5 * num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C244F0");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+D0]");
			num2 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+D4]");
			num = 0f;
		}
		object obj8 = (object)ret / obj7;
		_ = 0;
		_ = 0;
		object obj10 = default(object);
		object obj9 = obj10 / obj6;
		float num4 = (float)obj8 + 0.5f;
		float num5 = (float)obj9 + 0.5f;
		float num6 = num / (float)obj7;
		float num7 = num * num4;
		float num8 = num2 * num5;
		float num9 = num2 / (float)obj6;
		float num10 = num8 + num7;
		float num11 = num10 - 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj11 = num11 ^ 0;
		_ = 0;
		int num12 = 0;
		int num13 = 0;
		UIVertex vertex = default(UIVertex);
		object obj13 = default(object);
		object obj19 = default(object);
		while (true)
		{
			object obj12;
			if (vh.m_Positions != null)
			{
				List<Vector3> positions = vh.m_Positions;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v733 @ rax_v46 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
				obj12 = 0;
			}
			else
			{
				obj12 = 0;
			}
			if (num13 >= (nint)obj12)
			{
				break;
			}
			vh.PopulateUIVertex(ref vertex, num12);
			float num14 = (float)obj13 * num9;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+D0]");
			object obj14 = (nint)0 >> 8;
			float num15 = (float)vertex * num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+D0]");
			object obj15 = (nint)0 >> 16;
			float num16 = num14 + num15;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+D0]");
			object obj16 = (nint)0 >> 24;
			float num17 = num16 + (float)obj11;
			float num18 = (float)obj15 / 255f;
			float num19 = (float)obj16 / 255f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+D0]");
			float num20 = 0f / 255f;
			float num21 = (float)obj14 / 255f;
			if (!(0f > num17))
			{
				if (num17 > 1f)
				{
					num17 = 1f;
				}
			}
			else
			{
				num17 = 0f;
			}
			object obj17 = m_color1 - m_color2;
			object obj18 = obj19 - obj19;
			float num22 = (float)obj17 * num17;
			float num23 = (float)obj18 * num17;
			float num24 = num22 + (float)m_color2;
			float num25 = num23 + (float)obj19;
			object obj20 = obj19 - obj19;
			object obj21 = obj19 - obj19;
			float num26 = (float)obj20 * num17;
			float num27 = (float)obj21 * num17;
			float num28 = num26 + (float)obj19;
			float num29 = num27 + (float)obj19;
			float num30 = num24 * num20;
			float num31 = num25 * num21;
			float num32 = num28 * num18;
			float num33 = num29 * num19;
			if (!(0f > num30))
			{
				if (num30 > 1f)
				{
					num30 = 1f;
				}
			}
			else
			{
				num30 = 0f;
			}
			float num34 = num30 * 255f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
			if (!(0f > num31))
			{
				if (num31 > 1f)
				{
					num31 = 1f;
				}
			}
			else
			{
				num31 = 0f;
			}
			float num35 = num31 * 255f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
			if (!(0f > num32))
			{
				if (num32 > 1f)
				{
					num32 = 1f;
				}
			}
			else
			{
				num32 = 0f;
			}
			float num36 = num32 * 255f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
			if (!(0f > num33))
			{
				if (num33 > 1f)
				{
					num33 = 1f;
				}
			}
			else
			{
				num33 = 0f;
			}
			float num37 = num33 * 255f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,xmm0\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm9\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,xmm12\"");
			_ = ref vertex;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm13\"");
			UIVertex vertex2 = (UIVertex)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 96));
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-70]");
			obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-68]");
			_ = 0;
			vh.SetUIVertex(vertex2, num12);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+E8]");
			num9 = 0f;
			num12++;
			num13 = num12;
		}
	}

	public UIGradient()
	{
		//IL_0012: Expected O, but got I
		//IL_0024: Expected O, but got I
		//IL_0044: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		m_color1 = (Color)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		m_color2 = (Color)0;
		m_ignoreRatio = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
