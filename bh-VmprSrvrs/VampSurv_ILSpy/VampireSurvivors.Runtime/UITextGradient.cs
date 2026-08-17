using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

public class UITextGradient : BaseMeshEffect
{
	public Color m_color1;

	public Color m_color2;

	public float m_angle;

	public unsafe override void ModifyMesh(VertexHelper vh)
	{
		//IL_0008: Expected O, but got Ref
		//IL_03f3: Expected O, but got I4
		//IL_0442: Expected O, but got Ref
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected O, but got Unknown
		//IL_012f: Expected O, but got I4
		//IL_0121: Expected O, but got I
		//IL_0145: Expected I4, but got O
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Expected O, but got Unknown
		//IL_0203: Expected O, but got I
		//IL_0228: Expected O, but got I
		//IL_024d: Expected O, but got I
		//IL_029e: Invalid comparison between I4 and F4
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Expected O, but got Unknown
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Expected O, but got Unknown
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Expected O, but got Unknown
		//IL_02e9: Expected F4, but got I4
		//IL_05b3: Invalid comparison between I4 and F4
		//IL_0325: Expected F4, but got I4
		//IL_05ea: Invalid comparison between I4 and F4
		//IL_0361: Expected F4, but got I4
		//IL_0621: Invalid comparison between I4 and F4
		//IL_039d: Expected F4, but got I4
		//IL_0658: Invalid comparison between I4 and F4
		//IL_03d9: Expected F4, but got I4
		//IL_06d1: Expected O, but got Ref
		//IL_06fe: Expected O, but got I
		//IL_0722: Expected I4, but got O
		//IL_0732: Expected F4, but got I
		//IL_073b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0740: Expected O, but got Unknown
		//IL_0495->IL03de: Incompatible stack heights: 2 vs 1
		//IL_074d->IL074d: Incompatible stack heights: 3 vs 2
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
		_ = 0;
		bool flag2 = ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0;
		object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
		RectTransform.get_rect_Injected(((UnityEngine.Object)rectTransform).m_CachedPtr, out *(Rect*)obj4);
		float num = m_angle * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		_ = 0;
		float num2 = num * 0.5f;
		_ = 0;
		float num3 = num * 0.5f;
		float num4 = num3 + num2;
		float num5 = num4 - 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj5 = num5 ^ 0;
		RectTransform rectTransform2 = null;
		float num6 = num;
		RectTransform rectTransform3 = null;
		UIVertex vertex = default(UIVertex);
		object obj15 = default(object);
		while (true)
		{
			object obj6;
			if (vh.m_Positions != null)
			{
				List<Vector3> positions = vh.m_Positions;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v778 @ rax_v60 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
				obj6 = 0;
			}
			else
			{
				obj6 = 0;
			}
			if (System.Runtime.CompilerServices.Unsafe.As<RectTransform, UIntPtr>(ref rectTransform2) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6))
			{
				break;
			}
			vh.PopulateUIVertex(ref vertex, (int)rectTransform3);
			Vector2[] ms_verticesPositions = UIGradientUtils.ms_verticesPositions;
			object obj7 = rectTransform3 & 0x80000003L;
			if ((nint)UIGradientUtils.ms_verticesPositions < 0)
			{
				object obj8 = obj7 - 1;
				object obj9 = obj8 | -4;
				obj7 = obj9 + 1;
			}
			bool flag3 = (nint)obj7 >= ms_verticesPositions.Length;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ rdx_v15 (UnityEngine.Vector2[])+24+v656 @ rax_v38*8]");
			float num7 = 0f * num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ rdx_v15 (UnityEngine.Vector2[])+20+v656 @ rax_v38*8]");
			float num8 = 0f * num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+D0]");
			object obj10 = (nint)0 >> 8;
			float num9 = num7 + num8;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+D0]");
			object obj11 = (nint)0 >> 16;
			float num10 = num9 + (float)obj5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+D0]");
			object obj12 = (nint)0 >> 24;
			float num11 = (float)obj11 / 255f;
			float num12 = (float)obj12 / 255f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+D0]");
			float num13 = 0f / 255f;
			float num14 = (float)obj10 / 255f;
			if (!(0f > num10))
			{
				if (num10 > 1f)
				{
					num10 = 1f;
				}
			}
			else
			{
				num10 = 0f;
			}
			object obj13 = m_color1 - m_color2;
			object obj14 = obj15 - obj15;
			float num15 = (float)obj13 * num10;
			float num16 = (float)obj14 * num10;
			float num17 = num15 + (float)m_color2;
			float num18 = num16 + (float)obj15;
			object obj16 = obj15 - obj15;
			object obj17 = obj15 - obj15;
			float num19 = (float)obj16 * num10;
			float num20 = (float)obj17 * num10;
			float num21 = num19 + (float)obj15;
			float num22 = num20 + (float)obj15;
			float num23 = num17 * num13;
			float num24 = num18 * num14;
			float num25 = num21 * num11;
			float num26 = num22 * num12;
			if (!(0f > num23))
			{
				if (num23 > 1f)
				{
					num23 = 1f;
				}
			}
			else
			{
				num23 = 0f;
			}
			float num27 = num23 * 255f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
			if (!(0f > num24))
			{
				if (num24 > 1f)
				{
					num24 = 1f;
				}
			}
			else
			{
				num24 = 0f;
			}
			float num28 = num24 * 255f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
			if (!(0f > num25))
			{
				if (num25 > 1f)
				{
					num25 = 1f;
				}
			}
			else
			{
				num25 = 0f;
			}
			float num29 = num25 * 255f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
			if (!(0f > num26))
			{
				if (num26 > 1f)
				{
					num26 = 1f;
				}
			}
			else
			{
				num26 = 0f;
			}
			float num30 = num26 * 255f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,xmm0\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm9\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,xmm11\"");
			_ = UIGradientUtils.ms_verticesPositions;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm13\"");
			UIVertex vertex2 = (UIVertex)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 96));
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
			obj = 0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-78]");
			_ = 0;
			vh.SetUIVertex(vertex2, (int)rectTransform3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+E8]");
			num6 = 0f;
			rectTransform3 = (RectTransform)(rectTransform3 + 1);
			rectTransform2 = rectTransform3;
		}
	}

	public UITextGradient()
	{
		//IL_0012: Expected O, but got I
		//IL_0024: Expected O, but got I
		//IL_0039: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		m_color1 = (Color)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		m_color2 = (Color)0;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
