using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

public class UICornersGradient : BaseMeshEffect
{
	public Color m_topLeftColor;

	public Color m_topRightColor;

	public Color m_bottomRightColor;

	public Color m_bottomLeftColor;

	public unsafe override void ModifyMesh(VertexHelper vh)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0418: Expected O, but got I4
		//IL_0888: Expected I, but got O
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Expected O, but got Unknown
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Expected O, but got Unknown
		//IL_01f8: Expected O, but got I4
		//IL_01ea: Expected O, but got I
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Expected O, but got Unknown
		//IL_0287: Expected O, but got I
		//IL_02aa: Expected O, but got I
		//IL_02c0: Expected O, but got I
		//IL_06d0: Invalid comparison between I4 and F4
		//IL_034b: Expected F4, but got I4
		//IL_0707: Invalid comparison between I4 and F4
		//IL_0387: Expected F4, but got I4
		//IL_073e: Invalid comparison between I4 and F4
		//IL_03c3: Expected F4, but got I4
		//IL_0775: Invalid comparison between I4 and F4
		//IL_03ff: Expected F4, but got I4
		//IL_07f3: Expected O, but got Ref
		//IL_0821: Expected O, but got I
		//IL_04a6->IL0879: Incompatible stack heights: 2 vs 1
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
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v594 @ rax_v23 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		object obj5 = default(object);
		object obj4 = (object)ret / obj5;
		_ = 0;
		_ = 0;
		object obj7 = default(object);
		object obj8 = default(object);
		object obj6 = obj7 / obj8;
		float num3 = (float)obj4 + 0.5f;
		float num4 = (float)obj6 + 0.5f;
		object obj9 = (object)Vector2.rightVector / obj5;
		float num5 = num3 * (float)Vector2.rightVector;
		float num6 = num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v595 @ rcx_v20 (Il2CppStaticFields<UnityEngine.Vector2>)+2C]");
		float num7 = num6 * 0f;
		float num8 = num4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v595 @ rcx_v20 (Il2CppStaticFields<UnityEngine.Vector2>)+2C]");
		float num9 = num8 * 0f;
		float num10 = num4 * (float)Vector2.rightVector;
		float num11 = num5 - num9;
		float num12 = num7 + num10;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v595 @ rcx_v20 (Il2CppStaticFields<UnityEngine.Vector2>)+2C]");
		object obj10 = 0 / obj5;
		float num13 = num11 - 0.5f;
		float num14 = num12 - 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v595 @ rcx_v20 (Il2CppStaticFields<UnityEngine.Vector2>)+2C]");
		object obj11 = 0 / obj8;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj12 = num13 ^ 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj13 = num14 ^ 0;
		object obj14 = (object)Vector2.rightVector / obj8;
		_ = 0;
		_ = 0;
		_ = 0;
		int num15 = 0;
		int num16 = 0;
		UIVertex vertex = default(UIVertex);
		object obj17 = default(object);
		object obj30 = default(object);
		while (true)
		{
			object obj15;
			if (vh.m_Positions != null)
			{
				List<Vector3> positions = vh.m_Positions;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v715 @ rax_v46 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
				obj15 = 0;
			}
			else
			{
				obj15 = 0;
			}
			if (num15 >= (nint)obj15)
			{
				break;
			}
			vh.PopulateUIVertex(ref vertex, num16);
			object obj16 = obj11 * obj17;
			object obj18 = obj10 * (object)vertex;
			object obj19 = obj9 * (object)vertex;
			object obj20 = obj19 - obj16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+118]");
			object obj21 = 0 * obj17;
			object obj22 = obj21 + obj18;
			object obj23 = obj20 + obj12;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+100]");
			object obj24 = (nint)0 >> 8;
			object obj25 = obj22 + obj13;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+100]");
			object obj26 = (nint)0 >> 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+100]");
			object obj27 = (nint)0 >> 24;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+100]");
			float num17 = 0f / 255f;
			float num18 = (float)obj24 / 255f;
			float num19 = (float)obj26 / 255f;
			float num20 = (float)obj27 / 255f;
			_ = m_bottomRightColor;
			object obj28 = m_bottomRightColor - m_bottomLeftColor;
			object obj29 = obj30 - obj30;
			object obj31 = obj28 * obj23;
			object obj32 = obj29 * obj23;
			object obj33 = obj31 + (object)m_bottomLeftColor;
			object obj34 = obj32 + obj30;
			object obj35 = obj30 - obj30;
			object obj36 = obj30 - obj30;
			object obj37 = obj35 * obj23;
			object obj38 = obj36 * obj23;
			object obj39 = obj37 + obj30;
			object obj40 = obj38 + obj30;
			object obj41 = m_topRightColor - m_topLeftColor;
			object obj42 = obj30 - obj30;
			object obj43 = obj41 * obj23;
			object obj44 = obj42 * obj23;
			object obj45 = obj43 + (object)m_topLeftColor;
			object obj46 = obj30 - obj5;
			object obj47 = obj44 + obj30;
			object obj48 = obj30 - obj8;
			object obj49 = obj46 * obj23;
			object obj50 = obj48 * obj23;
			object obj51 = obj49 + obj5;
			object obj52 = obj50 + obj8;
			object obj53 = obj45 - obj33;
			object obj54 = obj47 - obj34;
			object obj55 = obj51 - obj39;
			object obj56 = obj52 - obj40;
			object obj57 = obj53 * obj25;
			object obj58 = obj54 * obj25;
			object obj59 = obj55 * obj25;
			object obj60 = obj57 + obj33;
			object obj61 = obj56 * obj25;
			object obj62 = obj58 + obj34;
			object obj63 = obj59 + obj39;
			object obj64 = obj61 + obj40;
			float num21 = (float)obj62 * num18;
			float num22 = (float)obj63 * num19;
			float num23 = (float)obj64 * num20;
			float num24 = (float)obj60 * num17;
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
			float num25 = num24 * 255f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
			if (!(0f > num21))
			{
				if (num21 > 1f)
				{
					num21 = 1f;
				}
			}
			else
			{
				num21 = 0f;
			}
			float num26 = num21 * 255f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
			if (!(0f > num22))
			{
				if (num22 > 1f)
				{
					num22 = 1f;
				}
			}
			else
			{
				num22 = 0f;
			}
			float num27 = num22 * 255f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
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
			float num28 = num23 * 255f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,xmm0\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm8\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,xmm12\"");
			_ = ref vertex;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm13\"");
			_ = typeof(UIGradientUtils);
			UIVertex vertex2 = (UIVertex)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 48));
			_ = 0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-70]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
			obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-60]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-48]");
			_ = 0;
			vh.SetUIVertex(vertex2, num16);
			num16++;
			num15 = num16;
		}
	}

	public UICornersGradient()
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
