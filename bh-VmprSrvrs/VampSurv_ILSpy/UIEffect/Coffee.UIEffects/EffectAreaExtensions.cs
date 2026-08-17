using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UIEffects;

public static class EffectAreaExtensions
{
	private static readonly Rect rectForCharacter;

	private static readonly Vector2[] splitedCharacterPosition;

	public unsafe static Rect GetEffectArea(EffectArea area, VertexHelper vh, Rect rectangle, float aspectRatio = -1f)
	{
		//IL_0221: Expected native int or pointer, but got O
		//IL_02f7: Expected native int or pointer, but got O
		//IL_0013: Expected O, but got I4
		//IL_0200: Expected native int or pointer, but got O
		//IL_01da: Expected native int or pointer, but got O
		//IL_00c9: Expected O, but got I4
		//IL_024c: Expected F4, but got O
		//IL_00bb: Expected O, but got I
		//IL_0146: Expected native int or pointer, but got O
		//IL_0162: Expected native int or pointer, but got O
		//IL_016f: Expected native int or pointer, but got O
		//IL_017c: Expected native int or pointer, but got O
		//IL_00e7: Invalid comparison between O and F4
		//IL_0309: Invalid comparison between F4 and O
		//IL_0103: Expected F4, but got O
		//IL_011d: Expected F4, but got O
		Rect rect = default(Rect);
		((Rect*)(nint)rect)->m_XMin = 0f;
		bool flag = area == EffectArea.RectTransform;
		float xMin;
		if (!flag)
		{
			object obj = area - 1;
			if (flag)
			{
				bool flag2 = vh == null;
				float num = -3.4028235E+38f;
				float num2 = 3.4028235E+38f;
				float num3 = -3.4028235E+38f;
				float num4 = 3.4028235E+38f;
				int num5 = 0;
				int num6 = 0;
				if (flag2)
				{
					return (Rect)new NullReferenceException();
				}
				UIVertex vertex = default(UIVertex);
				float num7 = default(float);
				while (true)
				{
					object obj2;
					if (vh.m_Positions != null)
					{
						List<Vector3> positions = vh.m_Positions;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v332 @ rax_v11 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
						obj2 = 0;
					}
					else
					{
						obj2 = 0;
					}
					if (num5 >= (nint)obj2)
					{
						break;
					}
					vh.PopulateUIVertex(ref vertex, num6);
					if (System.Runtime.CompilerServices.Unsafe.As<UIVertex, UIntPtr>(ref vertex) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num4))
					{
						num4 = (float)vertex;
					}
					if (!(num7 > num2))
					{
						num2 = num7;
					}
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num3) <= System.Runtime.CompilerServices.Unsafe.As<UIVertex, UIntPtr>(ref vertex))
					{
						num3 = (float)vertex;
					}
					if (!(num > num7))
					{
						num = num7;
					}
					num6++;
					num5 = num6;
				}
				float width = num3 - num4;
				((Rect*)(nint)rect)->m_XMin = num4;
				float height = num - num2;
				((Rect*)(nint)rect)->m_YMin = num2;
				((Rect*)(nint)rect)->m_Width = width;
				((Rect*)(nint)rect)->m_Height = height;
				goto IL_02ca;
			}
			if ((nint)obj == 1)
			{
				xMin = (float)rectForCharacter;
				goto IL_02ef;
			}
		}
		xMin = rectangle.m_XMin;
		goto IL_02ef;
		IL_02ca:
		object obj3 = default(object);
		if ((nint)obj3 > 0)
		{
			if (!(rect.m_Height > rect.m_Width))
			{
				float height2 = rect.m_Width / (float)obj3;
				((Rect*)(nint)rect)->m_Height = height2;
			}
			else
			{
				float width2 = (float)obj3 * rect.m_Height;
				((Rect*)(nint)rect)->m_Width = width2;
			}
		}
		return rect;
		IL_02ef:
		((Rect*)(nint)rect)->m_XMin = xMin;
		goto IL_02ca;
	}

	public static void GetPositionFactor(EffectArea area, int index, Rect rect, Vector2 position, bool isText, bool isTMPro, out float x, out float y)
	{
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Expected O, but got Unknown
		//IL_0182: Invalid comparison between I4 and F4
		//IL_01cd: Expected F4, but got I4
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Expected O, but got Unknown
		//IL_0103: Invalid comparison between I4 and F4
		//IL_02a2: Expected O, but got F4
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b4: Expected O, but got Unknown
		//IL_014e: Expected F4, but got I4
		//IL_02e4: Invalid comparison between I4 and F4
		//IL_0273: Expected O, but got F4
		//IL_0280: Unknown result type (might be due to invalid IL or missing references)
		//IL_0285: Expected O, but got Unknown
		//IL_023d: Expected I4, but got I8
		//IL_0209: Expected F4, but got I4
		//IL_02d5: Expected O, but got F4
		//IL_006b: Expected O, but got I4
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected I4, but got Unknown
		//IL_009c: Expected O, but got I
		//IL_00ba: Expected O, but got I
		object obj = default(object);
		object obj6;
		if (obj != null && area == EffectArea.Character)
		{
			object obj2 = default(object);
			bool flag = obj2 == null;
			int num = index;
			if (!flag)
			{
				num = index + 3;
			}
			int num2 = (int)(num & 0x80000003L);
			if ((nint)obj2 < 0)
			{
				object obj3 = num2 - 1;
				object obj4 = obj3 | -4;
				num2 = obj4 + 1;
			}
			Vector2[] array = splitedCharacterPosition;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ rcx_v3 (UnityEngine.Vector2[])+20+v160 @ rbx_v5 (System.Int32)*8]");
			object obj5 = 0;
			Vector2[] array2 = splitedCharacterPosition;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ rcx_v8 (UnityEngine.Vector2[])+24+v160 @ rbx_v5 (System.Int32)*8]");
			obj6 = 0;
			return;
		}
		object obj9 = default(object);
		float num4;
		if (area != EffectArea.Fit)
		{
			object obj7 = position / rect.m_Width;
			float num3 = (float)obj7 + 0.5f;
			if (!(0f > num3))
			{
				if (num3 > 1f)
				{
					num3 = 1f;
				}
			}
			else
			{
				num3 = 0f;
			}
			object obj5 = num3;
			object obj8 = obj9 / rect.m_Height;
			num4 = (float)obj8 + 0.5f;
		}
		else
		{
			object obj10 = position - rect.m_XMin;
			float num5 = (float)obj10 / rect.m_Width;
			if (!(0f > num5))
			{
				if (num5 > 1f)
				{
					num5 = 1f;
				}
			}
			else
			{
				num5 = 0f;
			}
			object obj5 = num5;
			object obj11 = obj9 - rect.m_YMin;
			num4 = (float)obj11 / rect.m_Height;
		}
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
		obj6 = num4;
	}

	public static void GetNormalizedFactor(EffectArea area, int index, Matrix2x3 matrix, Vector2 position, bool isText, out Vector2 nomalizedPos)
	{
		//IL_0038: Expected O, but got I4
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected O, but got Unknown
		//IL_014f: Expected O, but got F4
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected O, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		object obj = default(object);
		object obj8 = default(object);
		if (obj != null && area == EffectArea.Character)
		{
			Vector2[] array = splitedCharacterPosition;
			object obj2 = index + 3;
			object obj3 = obj2 & 0x80000003L;
			if ((nint)splitedCharacterPosition < 0)
			{
				object obj4 = obj3 - 1;
				object obj5 = obj4 | -4;
				obj3 = obj5 + 1;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rcx_v4 (UnityEngine.Vector2[])+24+v256 @ rax_v11*8]");
			object obj6 = 0 * matrix.m01;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rcx_v4 (UnityEngine.Vector2[])+20+v256 @ rax_v11*8]");
			object obj7 = 0 * matrix.m10;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rcx_v4 (UnityEngine.Vector2[])+20+v256 @ rax_v11*8]");
			float num = 0f * matrix.m00;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rcx_v4 (UnityEngine.Vector2[])+24+v256 @ rax_v11*8]");
			float num2 = 0f * matrix.m11;
			float num3 = (float)obj6 + num;
			float num4 = num2 + (float)obj7;
			float num5 = num3 + matrix.m02;
			float num6 = num4 + (float)obj8;
			object obj9 = num5;
		}
		else
		{
			object obj9 = obj8;
		}
	}

	static EffectAreaExtensions()
	{
		//IL_0080: Expected O, but got I
		//IL_00a1: Expected I, but got O
		//IL_00c4: Expected I, but got O
		//IL_00e7: Expected I, but got O
		//IL_010a: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12400]");
		rectForCharacter = (Rect)0;
		Vector2[] array = new Vector2[4];
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rcx_v5 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		_ = Vector2.upVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rdx_v2 (Il2CppStaticFields<UnityEngine.Vector2>)+14]");
		_ = 0;
		nint num3 = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rax_v9 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num4 = 0;
		_ = Vector2.oneVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rcx_v8 (Il2CppStaticFields<UnityEngine.Vector2>)+C]");
		_ = 0;
		nint num5 = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rax_v11 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num6 = 0;
		_ = Vector2.rightVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rdx_v4 (Il2CppStaticFields<UnityEngine.Vector2>)+2C]");
		_ = 0;
		nint num7 = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rax_v13 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num8 = 0;
		_ = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rcx_v11 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
		splitedCharacterPosition = array;
	}
}
