using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

public class UITextCornersGradient : BaseMeshEffect
{
	public Color m_topLeftColor;

	public Color m_topRightColor;

	public Color m_bottomRightColor;

	public Color m_bottomLeftColor;

	public unsafe override void ModifyMesh(VertexHelper vh)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0556: Expected O, but got I4
		//IL_009b: Expected O, but got I4
		//IL_008d: Expected O, but got I
		//IL_00b1: Expected I4, but got O
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_0165: Expected O, but got I
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Expected O, but got Unknown
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_023e: Expected O, but got Unknown
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Expected O, but got Unknown
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Expected O, but got Unknown
		//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Expected O, but got Unknown
		//IL_0300: Unknown result type (might be due to invalid IL or missing references)
		//IL_0305: Expected O, but got Unknown
		//IL_0315: Unknown result type (might be due to invalid IL or missing references)
		//IL_031a: Expected O, but got Unknown
		//IL_0351: Unknown result type (might be due to invalid IL or missing references)
		//IL_0356: Expected O, but got Unknown
		//IL_0380: Unknown result type (might be due to invalid IL or missing references)
		//IL_0385: Expected O, but got Unknown
		//IL_0395: Unknown result type (might be due to invalid IL or missing references)
		//IL_039a: Expected O, but got Unknown
		//IL_03aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_03af: Expected O, but got Unknown
		//IL_03cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d1: Expected O, but got Unknown
		//IL_043d: Invalid comparison between I4 and F4
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Expected O, but got Unknown
		//IL_0488: Expected F4, but got I4
		//IL_0640: Invalid comparison between I4 and F4
		//IL_04c4: Expected F4, but got I4
		//IL_0677: Invalid comparison between I4 and F4
		//IL_0500: Expected F4, but got I4
		//IL_06ae: Invalid comparison between I4 and F4
		//IL_053c: Expected F4, but got I4
		//IL_0727: Expected O, but got Ref
		//IL_0754: Expected O, but got I
		//IL_077f: Expected I4, but got O
		//IL_0788: Unknown result type (might be due to invalid IL or missing references)
		//IL_078d: Expected O, but got Unknown
		//IL_05f6->IL0541: Incompatible stack heights: 2 vs 1
		//IL_07a3->IL07a3: Incompatible stack heights: 3 vs 2
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
		RectTransform.get_rect_Injected(((UnityEngine.Object)rectTransform).m_CachedPtr, out Rect _);
		_ = 0;
		_ = 0;
		_ = 0;
		RectTransform rectTransform2 = null;
		float num = 255f;
		RectTransform rectTransform3 = null;
		UIVertex vertex = default(UIVertex);
		object obj10 = default(object);
		while (true)
		{
			object obj4;
			if (vh.m_Positions != null)
			{
				List<Vector3> positions = vh.m_Positions;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v758 @ rax_v57 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
				obj4 = 0;
			}
			else
			{
				obj4 = 0;
			}
			if (System.Runtime.CompilerServices.Unsafe.As<RectTransform, UIntPtr>(ref rectTransform2) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4))
			{
				break;
			}
			vh.PopulateUIVertex(ref vertex, (int)rectTransform3);
			Vector2[] ms_verticesPositions = UIGradientUtils.ms_verticesPositions;
			object obj5 = rectTransform3 & 0x80000003L;
			if ((nint)UIGradientUtils.ms_verticesPositions < 0)
			{
				object obj6 = obj5 - 1;
				object obj7 = obj6 | -4;
				obj5 = obj7 + 1;
			}
			bool flag3 = (nint)obj5 >= ms_verticesPositions.Length;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm11,eax\"");
			float num2 = 0f / num;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm10,eax\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+D0]");
			object obj8 = (nint)0 >> 24;
			float num3 = 0f / num;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm8,eax\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm7,ecx\"");
			float num4 = 0f / 255f;
			float num5 = 0f / 255f;
			object obj9 = obj10 - obj10;
			object obj11 = m_bottomRightColor - m_bottomLeftColor;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rdx_v15 (UnityEngine.Vector2[])+20+v653 @ rax_v35*8]");
			object obj12 = obj9 * 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rdx_v15 (UnityEngine.Vector2[])+20+v653 @ rax_v35*8]");
			object obj13 = obj11 * 0;
			object obj14 = obj12 + obj10;
			object obj15 = obj10 - obj10;
			object obj16 = obj13 + (object)m_bottomLeftColor;
			object obj17 = obj10 - obj10;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rdx_v15 (UnityEngine.Vector2[])+20+v653 @ rax_v35*8]");
			object obj18 = obj15 * 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rdx_v15 (UnityEngine.Vector2[])+20+v653 @ rax_v35*8]");
			object obj19 = obj17 * 0;
			object obj20 = obj18 + obj10;
			object obj21 = obj19 + obj10;
			object obj22 = m_topRightColor - m_topLeftColor;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rdx_v15 (UnityEngine.Vector2[])+20+v653 @ rax_v35*8]");
			object obj23 = obj22 * 0;
			object obj24 = obj23 + (object)m_topLeftColor;
			object obj25 = obj10 - obj10;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rdx_v15 (UnityEngine.Vector2[])+20+v653 @ rax_v35*8]");
			object obj26 = obj25 * 0;
			object obj27 = obj26 + obj10;
			object obj28 = obj10 - obj10;
			object obj29 = obj10 - obj10;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rdx_v15 (UnityEngine.Vector2[])+20+v653 @ rax_v35*8]");
			object obj30 = obj28 * 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rdx_v15 (UnityEngine.Vector2[])+20+v653 @ rax_v35*8]");
			object obj31 = obj29 * 0;
			object obj32 = obj30 + obj10;
			object obj33 = obj31 + obj10;
			object obj34 = obj27 - obj14;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+E8]");
			object obj35 = 0 - obj16;
			object obj36 = obj32 - obj20;
			object obj37 = obj33 - obj21;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rdx_v15 (UnityEngine.Vector2[])+24+v653 @ rax_v35*8]");
			object obj38 = obj34 * 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rdx_v15 (UnityEngine.Vector2[])+24+v653 @ rax_v35*8]");
			object obj39 = obj35 * 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rdx_v15 (UnityEngine.Vector2[])+24+v653 @ rax_v35*8]");
			object obj40 = obj36 * 0;
			object obj41 = obj38 + obj14;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rdx_v15 (UnityEngine.Vector2[])+24+v653 @ rax_v35*8]");
			object obj42 = obj37 * 0;
			object obj43 = obj39 + obj16;
			object obj44 = obj40 + obj20;
			object obj45 = obj42 + obj21;
			float num6 = (float)obj44 * num4;
			float num7 = (float)obj43 * num2;
			float num8 = (float)obj41 * num3;
			float num9 = (float)obj45 * num5;
			if (!(0f > num7))
			{
				if (num7 > 1f)
				{
					num7 = 1f;
				}
			}
			else
			{
				num7 = 0f;
			}
			float num10 = num7 * 255f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
			if (!(0f > num8))
			{
				if (num8 > 1f)
				{
					num8 = 1f;
				}
			}
			else
			{
				num8 = 0f;
			}
			float num11 = num8 * 255f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
			if (!(0f > num6))
			{
				if (num6 > 1f)
				{
					num6 = 1f;
				}
			}
			else
			{
				num6 = 0f;
			}
			float num12 = num6 * 255f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
			if (!(0f > num9))
			{
				if (num9 > 1f)
				{
					num9 = 1f;
				}
			}
			else
			{
				num9 = 0f;
			}
			float num13 = num9 * 255f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,xmm0\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm6\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,xmm7\"");
			_ = UIGradientUtils.ms_verticesPositions;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm9\"");
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
			vh.SetUIVertex(vertex2, (int)rectTransform3);
			rectTransform3 = (RectTransform)(rectTransform3 + 1);
			rectTransform2 = rectTransform3;
			num = 255f;
		}
	}

	public UITextCornersGradient()
	{
		//IL_0012: Expected O, but got I
		//IL_0024: Expected O, but got I
		//IL_0036: Expected O, but got I
		//IL_0048: Expected O, but got I
		//IL_005d: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		m_topLeftColor = (Color)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		m_topRightColor = (Color)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		m_bottomRightColor = (Color)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		m_bottomLeftColor = (Color)0;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
