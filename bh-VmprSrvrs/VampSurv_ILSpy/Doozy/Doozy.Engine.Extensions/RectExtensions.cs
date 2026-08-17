using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using UnityEngine;

namespace Doozy.Engine.Extensions;

public static class RectExtensions
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<Rect, float> _003C_003E9__37_0;

		public static Func<Rect, float> _003C_003E9__37_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal float _003CCover_003Eb__37_0(Rect t)
		{
			return t.m_XMin;
		}

		internal float _003CCover_003Eb__37_1(Rect t)
		{
			return t.m_YMin;
		}
	}

	private sealed class _003C_003Ec__DisplayClass37_0
	{
		public float x;

		public float y;

		internal float _003CCover_003Eb__2(Rect t)
		{
			float num = t.m_Width + t.m_XMin;
			return num - x;
		}

		internal float _003CCover_003Eb__3(Rect t)
		{
			float num = t.m_Height + t.m_YMin;
			return num - y;
		}
	}

	private static Vector2 s_tmpTopLeft;

	public static Vector2 TopLeft(Rect rect)
	{
		//IL_0013: Expected I, but got O
		//IL_0036: Expected O, but got F4
		nint num = (nint)typeof(RectExtensions);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v3 (Il2CppClass<Doozy.Engine.Extensions.RectExtensions>)+B8]");
		nint num2 = 0;
		s_tmpTopLeft = (Vector2)rect.m_XMin;
		_ = rect.m_YMin;
		Vector2 result = default(Vector2);
		return result;
	}

	public unsafe static Rect ScaleSizeBy(Rect rect, float scale)
	{
		//IL_000d: Expected native int or pointer, but got O
		Rect rect2 = default(Rect);
		float xMin = default(float);
		((Rect*)(nint)rect2)->m_XMin = xMin;
		return rect2;
	}

	public unsafe static Rect ScaleSizeBy(Rect rect, float scale, Vector2 pivotPoint)
	{
		//IL_004c: Expected native int or pointer, but got O
		//IL_0095: Expected native int or pointer, but got O
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00ff: Expected native int or pointer, but got O
		//IL_011b: Expected native int or pointer, but got O
		//IL_0137: Expected native int or pointer, but got O
		float num = rect.m_XMin - (float)pivotPoint;
		object obj2 = default(object);
		object obj3 = default(object);
		object obj = obj2 - obj3;
		float num2 = num + (float)obj2;
		float num3 = num * scale;
		Rect rect2 = default(Rect);
		((Rect*)(nint)rect2)->m_XMin = rect.m_XMin;
		float num4 = num2 - num3;
		float num5 = num4 + num3;
		float num6 = num5 * scale;
		float width = num6 - num3;
		((Rect*)(nint)rect2)->m_Width = width;
		float num7 = (float)obj * scale;
		object obj4 = obj + rect2.m_Height;
		float num8 = (float)obj4 - num7;
		float num9 = num8 + num7;
		float num10 = num9 * scale;
		float height = num10 - num7;
		((Rect*)(nint)rect2)->m_Height = height;
		float xMin = num3 + (float)pivotPoint;
		((Rect*)(nint)rect2)->m_XMin = xMin;
		float yMin = num7 + (float)obj3;
		((Rect*)(nint)rect2)->m_YMin = yMin;
		return rect2;
	}

	public unsafe static Rect ScaleSizeBy(Rect rect, Vector2 scale)
	{
		//IL_000d: Expected native int or pointer, but got O
		Rect rect2 = default(Rect);
		float xMin = default(float);
		((Rect*)(nint)rect2)->m_XMin = xMin;
		return rect2;
	}

	public unsafe static Rect ScaleSizeBy(Rect rect, Vector2 scale, Vector2 pivotPoint)
	{
		//IL_004c: Expected native int or pointer, but got O
		//IL_0095: Expected native int or pointer, but got O
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_00f7: Expected native int or pointer, but got O
		//IL_0113: Expected native int or pointer, but got O
		//IL_012f: Expected native int or pointer, but got O
		float num = rect.m_XMin - (float)pivotPoint;
		object obj2 = default(object);
		object obj3 = default(object);
		object obj = obj2 - obj3;
		float num2 = num * (float)scale;
		float num3 = num + (float)obj2;
		Rect rect2 = default(Rect);
		((Rect*)(nint)rect2)->m_XMin = rect.m_XMin;
		float num4 = num3 - num2;
		float num5 = num4 + num2;
		float num6 = num5 * (float)scale;
		float width = num6 - num2;
		((Rect*)(nint)rect2)->m_Width = width;
		object obj5 = default(object);
		object obj4 = obj * obj5;
		object obj6 = obj + rect2.m_Height;
		object obj7 = obj6 - obj4;
		object obj8 = obj7 + obj4;
		object obj9 = obj8 * obj5;
		float height = (float)obj9 - (float)obj4;
		((Rect*)(nint)rect2)->m_Height = height;
		float xMin = num2 + (float)pivotPoint;
		((Rect*)(nint)rect2)->m_XMin = xMin;
		float yMin = (float)obj4 + (float)obj3;
		((Rect*)(nint)rect2)->m_YMin = yMin;
		return rect2;
	}

	public unsafe static Rect Below(Rect source, Rect belowSource)
	{
		//IL_0026: Expected native int or pointer, but got O
		//IL_0038: Expected native int or pointer, but got O
		//IL_004a: Expected native int or pointer, but got O
		//IL_0057: Expected native int or pointer, but got O
		float yMin = belowSource.m_Height + belowSource.m_YMin;
		Rect rect = default(Rect);
		((Rect*)(nint)rect)->m_XMin = source.m_XMin;
		((Rect*)(nint)rect)->m_Width = source.m_Width;
		((Rect*)(nint)rect)->m_Height = source.m_Height;
		((Rect*)(nint)rect)->m_YMin = yMin;
		return rect;
	}

	public unsafe static Rect RightOf(Rect source, Rect target)
	{
		//IL_0026: Expected native int or pointer, but got O
		//IL_0038: Expected native int or pointer, but got O
		//IL_004a: Expected native int or pointer, but got O
		//IL_0057: Expected native int or pointer, but got O
		float xMin = target.m_Width + target.m_XMin;
		Rect rect = default(Rect);
		((Rect*)(nint)rect)->m_YMin = source.m_YMin;
		((Rect*)(nint)rect)->m_Width = source.m_Width;
		((Rect*)(nint)rect)->m_Height = source.m_Height;
		((Rect*)(nint)rect)->m_XMin = xMin;
		return rect;
	}

	public unsafe static Rect WithSize(Rect source, float width, float height)
	{
		//IL_000d: Expected native int or pointer, but got O
		//IL_001f: Expected native int or pointer, but got O
		//IL_002c: Expected native int or pointer, but got O
		//IL_0039: Expected native int or pointer, but got O
		Rect rect = default(Rect);
		((Rect*)(nint)rect)->m_XMin = source.m_XMin;
		((Rect*)(nint)rect)->m_YMin = source.m_YMin;
		((Rect*)(nint)rect)->m_Width = width;
		((Rect*)(nint)rect)->m_Height = height;
		return rect;
	}

	public unsafe static Rect WithWidth(Rect source, float width)
	{
		//IL_000d: Expected native int or pointer, but got O
		//IL_001f: Expected native int or pointer, but got O
		//IL_0031: Expected native int or pointer, but got O
		//IL_003e: Expected native int or pointer, but got O
		Rect rect = default(Rect);
		((Rect*)(nint)rect)->m_XMin = source.m_XMin;
		((Rect*)(nint)rect)->m_YMin = source.m_YMin;
		((Rect*)(nint)rect)->m_Height = source.m_Height;
		((Rect*)(nint)rect)->m_Width = width;
		return rect;
	}

	public unsafe static Rect WithHeight(Rect source, float height)
	{
		//IL_000d: Expected native int or pointer, but got O
		//IL_001f: Expected native int or pointer, but got O
		//IL_0031: Expected native int or pointer, but got O
		//IL_003e: Expected native int or pointer, but got O
		Rect rect = default(Rect);
		((Rect*)(nint)rect)->m_XMin = source.m_XMin;
		((Rect*)(nint)rect)->m_YMin = source.m_YMin;
		((Rect*)(nint)rect)->m_Width = source.m_Width;
		((Rect*)(nint)rect)->m_Height = height;
		return rect;
	}

	public unsafe static Rect Pad(Rect source, float left, float top, float right, float bottom)
	{
		//IL_0058: Expected native int or pointer, but got O
		//IL_0065: Expected native int or pointer, but got O
		//IL_0072: Expected native int or pointer, but got O
		//IL_007f: Expected native int or pointer, but got O
		object obj = default(object);
		float width = source.m_Width - (float)obj;
		object obj2 = default(object);
		float height = source.m_Height - (float)obj2;
		float xMin = left + source.m_XMin;
		float yMin = top + source.m_YMin;
		Rect rect = default(Rect);
		((Rect*)(nint)rect)->m_Width = width;
		((Rect*)(nint)rect)->m_Height = height;
		((Rect*)(nint)rect)->m_XMin = xMin;
		((Rect*)(nint)rect)->m_YMin = yMin;
		return rect;
	}

	public unsafe static Rect PadSides(Rect source, float padding)
	{
		//IL_004e: Expected native int or pointer, but got O
		//IL_006f: Expected native int or pointer, but got O
		//IL_007c: Expected native int or pointer, but got O
		//IL_009d: Expected native int or pointer, but got O
		float xMin = padding + source.m_XMin;
		float num = padding + padding;
		float yMin = padding + source.m_YMin;
		float num2 = padding + padding;
		Rect rect = default(Rect);
		((Rect*)(nint)rect)->m_XMin = xMin;
		float width = source.m_Width - num;
		((Rect*)(nint)rect)->m_YMin = yMin;
		((Rect*)(nint)rect)->m_Width = width;
		float height = source.m_Height - num2;
		((Rect*)(nint)rect)->m_Height = height;
		return rect;
	}

	public unsafe static Rect AlignTopRight(Rect source, Rect target)
	{
		//IL_0026: Expected native int or pointer, but got O
		//IL_0038: Expected native int or pointer, but got O
		//IL_005e: Expected native int or pointer, but got O
		//IL_006b: Expected native int or pointer, but got O
		float num = target.m_Width + target.m_XMin;
		Rect rect = default(Rect);
		((Rect*)(nint)rect)->m_YMin = target.m_YMin;
		((Rect*)(nint)rect)->m_Width = source.m_Width;
		float xMin = num - source.m_Width;
		((Rect*)(nint)rect)->m_Height = source.m_Height;
		((Rect*)(nint)rect)->m_XMin = xMin;
		return rect;
	}

	public unsafe static Rect AlignHorizontallyByCenter(Rect source, Rect target)
	{
		//IL_0026: Expected native int or pointer, but got O
		//IL_0038: Expected native int or pointer, but got O
		//IL_005a: Expected native int or pointer, but got O
		//IL_007b: Expected native int or pointer, but got O
		float num = target.m_Height - source.m_Height;
		Rect rect = default(Rect);
		((Rect*)(nint)rect)->m_XMin = source.m_XMin;
		((Rect*)(nint)rect)->m_Width = source.m_Width;
		float num2 = num * 0.5f;
		((Rect*)(nint)rect)->m_Height = source.m_Height;
		float yMin = num2 + target.m_YMin;
		((Rect*)(nint)rect)->m_YMin = yMin;
		return rect;
	}

	public unsafe static Rect AlignVerticallyByCenter(Rect source, Rect target)
	{
		//IL_0026: Expected native int or pointer, but got O
		//IL_0038: Expected native int or pointer, but got O
		//IL_005a: Expected native int or pointer, but got O
		//IL_007b: Expected native int or pointer, but got O
		float num = target.m_Width - source.m_Width;
		Rect rect = default(Rect);
		((Rect*)(nint)rect)->m_YMin = source.m_YMin;
		((Rect*)(nint)rect)->m_Width = source.m_Width;
		float num2 = num * 0.5f;
		((Rect*)(nint)rect)->m_Height = source.m_Height;
		float xMin = num2 + target.m_XMin;
		((Rect*)(nint)rect)->m_XMin = xMin;
		return rect;
	}

	public unsafe static Rect Translate(Rect source, float x, float y)
	{
		//IL_0035: Expected native int or pointer, but got O
		//IL_0047: Expected native int or pointer, but got O
		//IL_0054: Expected native int or pointer, but got O
		//IL_0061: Expected native int or pointer, but got O
		float xMin = x + source.m_XMin;
		float yMin = y + source.m_YMin;
		Rect rect = default(Rect);
		((Rect*)(nint)rect)->m_Width = source.m_Width;
		((Rect*)(nint)rect)->m_Height = source.m_Height;
		((Rect*)(nint)rect)->m_XMin = xMin;
		((Rect*)(nint)rect)->m_YMin = yMin;
		return rect;
	}

	public unsafe static Rect WithOrigin(Rect source, float x, float y)
	{
		//IL_000d: Expected native int or pointer, but got O
		//IL_001f: Expected native int or pointer, but got O
		//IL_002c: Expected native int or pointer, but got O
		//IL_0039: Expected native int or pointer, but got O
		Rect rect = default(Rect);
		((Rect*)(nint)rect)->m_Width = source.m_Width;
		((Rect*)(nint)rect)->m_Height = source.m_Height;
		((Rect*)(nint)rect)->m_XMin = x;
		((Rect*)(nint)rect)->m_YMin = y;
		return rect;
	}

	public unsafe static Rect Align(Rect source, Rect target)
	{
		//IL_000d: Expected native int or pointer, but got O
		//IL_001f: Expected native int or pointer, but got O
		//IL_0031: Expected native int or pointer, but got O
		//IL_0043: Expected native int or pointer, but got O
		Rect rect = default(Rect);
		((Rect*)(nint)rect)->m_XMin = target.m_XMin;
		((Rect*)(nint)rect)->m_YMin = target.m_YMin;
		((Rect*)(nint)rect)->m_Width = source.m_Width;
		((Rect*)(nint)rect)->m_Height = source.m_Height;
		return rect;
	}

	public unsafe static Rect AlignAndScale(Rect source, Rect target)
	{
		//IL_000d: Expected native int or pointer, but got O
		//IL_001f: Expected native int or pointer, but got O
		//IL_0031: Expected native int or pointer, but got O
		//IL_0043: Expected native int or pointer, but got O
		Rect rect = default(Rect);
		((Rect*)(nint)rect)->m_XMin = target.m_XMin;
		((Rect*)(nint)rect)->m_YMin = target.m_YMin;
		((Rect*)(nint)rect)->m_Width = target.m_Width;
		((Rect*)(nint)rect)->m_Height = target.m_Height;
		return rect;
	}

	public unsafe static Rect AlignHorizontally(Rect source, Rect target)
	{
		//IL_000d: Expected native int or pointer, but got O
		//IL_001f: Expected native int or pointer, but got O
		//IL_0031: Expected native int or pointer, but got O
		//IL_0043: Expected native int or pointer, but got O
		Rect rect = default(Rect);
		((Rect*)(nint)rect)->m_XMin = source.m_XMin;
		((Rect*)(nint)rect)->m_YMin = target.m_YMin;
		((Rect*)(nint)rect)->m_Width = source.m_Width;
		((Rect*)(nint)rect)->m_Height = source.m_Height;
		return rect;
	}

	public unsafe static Rect AlignVertically(Rect source, Rect target)
	{
		//IL_000d: Expected native int or pointer, but got O
		//IL_001f: Expected native int or pointer, but got O
		//IL_0031: Expected native int or pointer, but got O
		//IL_0043: Expected native int or pointer, but got O
		Rect rect = default(Rect);
		((Rect*)(nint)rect)->m_XMin = target.m_XMin;
		((Rect*)(nint)rect)->m_YMin = source.m_YMin;
		((Rect*)(nint)rect)->m_Width = source.m_Width;
		((Rect*)(nint)rect)->m_Height = source.m_Height;
		return rect;
	}

	public unsafe static Rect CenterInsideOf(Rect source, Rect target)
	{
		//IL_0026: Expected native int or pointer, but got O
		//IL_0038: Expected native int or pointer, but got O
		//IL_0069: Expected native int or pointer, but got O
		//IL_00b3: Expected native int or pointer, but got O
		float num = target.m_Width - source.m_Width;
		Rect rect = default(Rect);
		((Rect*)(nint)rect)->m_Width = source.m_Width;
		((Rect*)(nint)rect)->m_Height = source.m_Height;
		float num2 = num * 0.5f;
		float xMin = num2 + target.m_XMin;
		((Rect*)(nint)rect)->m_XMin = xMin;
		float num3 = target.m_Height - source.m_Height;
		float num4 = num3 * 0.5f;
		float yMin = num4 + target.m_YMin;
		((Rect*)(nint)rect)->m_YMin = yMin;
		return rect;
	}

	public unsafe static Rect LeftHalf(Rect source)
	{
		//IL_0022: Expected native int or pointer, but got O
		//IL_0034: Expected native int or pointer, but got O
		//IL_0046: Expected native int or pointer, but got O
		//IL_0053: Expected native int or pointer, but got O
		float width = source.m_Width * 0.5f;
		Rect rect = default(Rect);
		((Rect*)(nint)rect)->m_XMin = source.m_XMin;
		((Rect*)(nint)rect)->m_YMin = source.m_YMin;
		((Rect*)(nint)rect)->m_Height = source.m_Height;
		((Rect*)(nint)rect)->m_Width = width;
		return rect;
	}

	public unsafe static Rect RightHalf(Rect source)
	{
		//IL_0022: Expected native int or pointer, but got O
		//IL_0034: Expected native int or pointer, but got O
		//IL_0055: Expected native int or pointer, but got O
		//IL_0077: Expected native int or pointer, but got O
		float num = source.m_Width * 0.5f;
		Rect rect = default(Rect);
		((Rect*)(nint)rect)->m_YMin = source.m_YMin;
		((Rect*)(nint)rect)->m_Height = source.m_Height;
		float xMin = num + source.m_XMin;
		((Rect*)(nint)rect)->m_XMin = xMin;
		float width = source.m_Width * 0.5f;
		((Rect*)(nint)rect)->m_Width = width;
		return rect;
	}

	public unsafe static Rect TopHalf(Rect source)
	{
		//IL_0022: Expected native int or pointer, but got O
		//IL_0034: Expected native int or pointer, but got O
		//IL_0046: Expected native int or pointer, but got O
		//IL_0053: Expected native int or pointer, but got O
		float height = source.m_Height * 0.5f;
		Rect rect = default(Rect);
		((Rect*)(nint)rect)->m_XMin = source.m_XMin;
		((Rect*)(nint)rect)->m_YMin = source.m_YMin;
		((Rect*)(nint)rect)->m_Width = source.m_Width;
		((Rect*)(nint)rect)->m_Height = height;
		return rect;
	}

	public unsafe static Rect BottomHalf(Rect source)
	{
		//IL_0022: Expected native int or pointer, but got O
		//IL_0034: Expected native int or pointer, but got O
		//IL_0055: Expected native int or pointer, but got O
		//IL_0077: Expected native int or pointer, but got O
		float num = source.m_Height * 0.5f;
		Rect rect = default(Rect);
		((Rect*)(nint)rect)->m_XMin = source.m_XMin;
		((Rect*)(nint)rect)->m_Width = source.m_Width;
		float yMin = num + source.m_YMin;
		((Rect*)(nint)rect)->m_YMin = yMin;
		float height = source.m_Height * 0.5f;
		((Rect*)(nint)rect)->m_Height = height;
		return rect;
	}

	public unsafe static Rect Clip(Rect source, Rect target)
	{
		//IL_0264: Expected native int or pointer, but got O
		//IL_0271: Expected native int or pointer, but got O
		//IL_027e: Expected native int or pointer, but got O
		//IL_028b: Expected native int or pointer, but got O
		float num = source.m_XMin;
		if (target.m_XMin > source.m_XMin)
		{
			num = target.m_XMin;
		}
		float num2 = target.m_Width + target.m_XMin;
		if (source.m_XMin > num2)
		{
			num = target.m_Width + target.m_XMin;
		}
		float num3 = source.m_YMin;
		if (target.m_YMin > source.m_YMin)
		{
			num3 = target.m_YMin;
		}
		float num4 = target.m_Height + target.m_YMin;
		if (source.m_YMin > num4)
		{
			num3 = target.m_Height + target.m_YMin;
		}
		float width = source.m_Width;
		float num5 = target.m_Width + target.m_XMin;
		float num6 = num + source.m_Width;
		if (num6 > num5)
		{
			float num7 = target.m_Width + target.m_XMin;
			width = num7 - source.m_XMin;
		}
		float height = source.m_Height;
		float num8 = target.m_Height + target.m_YMin;
		float num9 = num3 + source.m_Height;
		if (num9 > num8)
		{
			float num10 = target.m_Height + target.m_YMin;
			height = num10 - source.m_YMin;
		}
		Rect rect = default(Rect);
		((Rect*)(nint)rect)->m_XMin = num;
		((Rect*)(nint)rect)->m_YMin = num3;
		((Rect*)(nint)rect)->m_Width = width;
		((Rect*)(nint)rect)->m_Height = height;
		return rect;
	}

	public unsafe static Rect InnerAlignWithBottomRight(Rect source, Rect target)
	{
		//IL_003f: Expected native int or pointer, but got O
		//IL_0051: Expected native int or pointer, but got O
		//IL_0086: Expected native int or pointer, but got O
		//IL_0093: Expected native int or pointer, but got O
		float num = target.m_Width + target.m_XMin;
		float num2 = target.m_Height + target.m_YMin;
		Rect rect = default(Rect);
		((Rect*)(nint)rect)->m_Width = source.m_Width;
		((Rect*)(nint)rect)->m_Height = source.m_Height;
		float xMin = num - source.m_Width;
		float yMin = num2 - source.m_Height;
		((Rect*)(nint)rect)->m_XMin = xMin;
		((Rect*)(nint)rect)->m_YMin = yMin;
		return rect;
	}

	public unsafe static Rect InnerAlignWithCenterRight(Rect source, Rect target)
	{
		//IL_000d: Expected native int or pointer, but got O
		Rect rect = default(Rect);
		float xMin = default(float);
		((Rect*)(nint)rect)->m_XMin = xMin;
		return rect;
	}

	public unsafe static Rect InnerAlignWithCenterLeft(Rect source, Rect target)
	{
		//IL_000d: Expected native int or pointer, but got O
		Rect rect = default(Rect);
		float xMin = default(float);
		((Rect*)(nint)rect)->m_XMin = xMin;
		return rect;
	}

	public unsafe static Rect InnerAlignWithBottomLeft(Rect source, Rect target)
	{
		//IL_0026: Expected native int or pointer, but got O
		//IL_0038: Expected native int or pointer, but got O
		//IL_005e: Expected native int or pointer, but got O
		//IL_006b: Expected native int or pointer, but got O
		float num = target.m_Height + target.m_YMin;
		Rect rect = default(Rect);
		((Rect*)(nint)rect)->m_XMin = target.m_XMin;
		((Rect*)(nint)rect)->m_Width = source.m_Width;
		float yMin = num - source.m_Height;
		((Rect*)(nint)rect)->m_Height = source.m_Height;
		((Rect*)(nint)rect)->m_YMin = yMin;
		return rect;
	}

	public unsafe static Rect InnerAlignWithUpperRight(Rect source, Rect target)
	{
		//IL_0026: Expected native int or pointer, but got O
		//IL_0038: Expected native int or pointer, but got O
		//IL_005e: Expected native int or pointer, but got O
		//IL_006b: Expected native int or pointer, but got O
		float num = target.m_Width + target.m_XMin;
		Rect rect = default(Rect);
		((Rect*)(nint)rect)->m_YMin = target.m_YMin;
		((Rect*)(nint)rect)->m_Width = source.m_Width;
		float xMin = num - source.m_Width;
		((Rect*)(nint)rect)->m_Height = source.m_Height;
		((Rect*)(nint)rect)->m_XMin = xMin;
		return rect;
	}

	public unsafe static Rect InnerAlignWithBottomCenter(Rect source, Rect target)
	{
		//IL_0055: Expected native int or pointer, but got O
		//IL_0026: Expected native int or pointer, but got O
		//IL_0042: Expected native int or pointer, but got O
		Rect rect = default(Rect);
		((Rect*)(nint)rect)->m_XMin = 0f;
		float num = target.m_Height + target.m_YMin;
		float num2 = default(float);
		((Rect*)(nint)rect)->m_XMin = num2;
		float yMin = num - num2;
		((Rect*)(nint)rect)->m_YMin = yMin;
		return rect;
	}

	public unsafe static Rect LeftOf(Rect source, Rect target)
	{
		//IL_0026: Expected native int or pointer, but got O
		//IL_0038: Expected native int or pointer, but got O
		//IL_004a: Expected native int or pointer, but got O
		//IL_0057: Expected native int or pointer, but got O
		float xMin = target.m_XMin - source.m_Width;
		Rect rect = default(Rect);
		((Rect*)(nint)rect)->m_YMin = source.m_YMin;
		((Rect*)(nint)rect)->m_Width = source.m_Width;
		((Rect*)(nint)rect)->m_Height = source.m_Height;
		((Rect*)(nint)rect)->m_XMin = xMin;
		return rect;
	}

	public unsafe static Rect Above(Rect source, Rect target)
	{
		//IL_0026: Expected native int or pointer, but got O
		//IL_0038: Expected native int or pointer, but got O
		//IL_004a: Expected native int or pointer, but got O
		//IL_0057: Expected native int or pointer, but got O
		float yMin = target.m_YMin - source.m_Height;
		Rect rect = default(Rect);
		((Rect*)(nint)rect)->m_XMin = source.m_XMin;
		((Rect*)(nint)rect)->m_Width = source.m_Width;
		((Rect*)(nint)rect)->m_Height = source.m_Height;
		((Rect*)(nint)rect)->m_YMin = yMin;
		return rect;
	}

	public unsafe static Rect AboveAll(Rect source, Rect target, int i)
	{
		//IL_000d: Expected native int or pointer, but got O
		//IL_001f: Expected native int or pointer, but got O
		//IL_0031: Expected native int or pointer, but got O
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		//IL_0064: Expected native int or pointer, but got O
		Rect rect = default(Rect);
		((Rect*)(nint)rect)->m_XMin = source.m_XMin;
		((Rect*)(nint)rect)->m_Width = source.m_Width;
		((Rect*)(nint)rect)->m_Height = source.m_Height;
		object obj = i * source.m_Height;
		float yMin = target.m_YMin - (float)obj;
		((Rect*)(nint)rect)->m_YMin = yMin;
		return rect;
	}

	public unsafe static Rect Cover(Rect source, Rect[] targets)
	{
		//IL_0120: Expected native int or pointer, but got O
		//IL_0132: Expected native int or pointer, but got O
		//IL_013f: Expected native int or pointer, but got O
		//IL_014c: Expected native int or pointer, but got O
		_003C_003Ec__DisplayClass37_0 obj = new _003C_003Ec__DisplayClass37_0();
		Func<Rect, float> selector = _003C_003Ec._003C_003E9__37_0;
		if (_003C_003Ec._003C_003E9__37_0 == null)
		{
			Func<Rect, float> func = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D7B0");
			_003C_003Ec._003C_003E9__37_0 = func;
			selector = func;
		}
		IEnumerable<float> source2 = Enumerable.Select(targets, selector);
		float x = Enumerable.Min(source2);
		if (obj != null)
		{
			obj.x = x;
			Func<Rect, float> selector2 = _003C_003Ec._003C_003E9__37_1;
			if (_003C_003Ec._003C_003E9__37_1 == null)
			{
				Func<Rect, float> func2 = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D7B0");
				_003C_003Ec._003C_003E9__37_1 = func2;
				selector2 = func2;
			}
			IEnumerable<float> source3 = Enumerable.Select(targets, selector2);
			float y = Enumerable.Min(source3);
			obj.y = y;
			Func<Rect, float> selector3 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D7B0");
			IEnumerable<float> source4 = Enumerable.Select(targets, selector3);
			float width = Enumerable.Max(source4);
			Func<Rect, float> selector4 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D7B0");
			IEnumerable<float> source5 = Enumerable.Select(targets, selector4);
			float height = Enumerable.Max(source5);
			Rect rect = default(Rect);
			((Rect*)(nint)rect)->m_XMin = obj.x;
			((Rect*)(nint)rect)->m_YMin = obj.y;
			((Rect*)(nint)rect)->m_Width = width;
			((Rect*)(nint)rect)->m_Height = height;
			return rect;
		}
		return (Rect)new NullReferenceException();
	}

	public unsafe static Rect StretchedVerticallyAlong(Rect source, Rect target)
	{
		//IL_0026: Expected native int or pointer, but got O
		//IL_0038: Expected native int or pointer, but got O
		//IL_005e: Expected native int or pointer, but got O
		//IL_006b: Expected native int or pointer, but got O
		float num = target.m_Height + target.m_YMin;
		Rect rect = default(Rect);
		((Rect*)(nint)rect)->m_XMin = source.m_XMin;
		((Rect*)(nint)rect)->m_YMin = source.m_YMin;
		float height = num - source.m_YMin;
		((Rect*)(nint)rect)->m_Width = source.m_Width;
		((Rect*)(nint)rect)->m_Height = height;
		return rect;
	}

	public unsafe static Rect AddHeight(Rect source, int height)
	{
		//IL_000d: Expected native int or pointer, but got O
		//IL_001f: Expected native int or pointer, but got O
		//IL_0031: Expected native int or pointer, but got O
		//IL_0052: Expected native int or pointer, but got O
		Rect rect = default(Rect);
		((Rect*)(nint)rect)->m_XMin = source.m_XMin;
		((Rect*)(nint)rect)->m_YMin = source.m_YMin;
		((Rect*)(nint)rect)->m_Width = source.m_Width;
		float height2 = (float)height + source.m_Height;
		((Rect*)(nint)rect)->m_Height = height2;
		return rect;
	}

	public unsafe static Rect AddWidth(Rect source, int width)
	{
		//IL_000d: Expected native int or pointer, but got O
		//IL_001f: Expected native int or pointer, but got O
		//IL_0031: Expected native int or pointer, but got O
		//IL_0052: Expected native int or pointer, but got O
		Rect rect = default(Rect);
		((Rect*)(nint)rect)->m_XMin = source.m_XMin;
		((Rect*)(nint)rect)->m_YMin = source.m_YMin;
		((Rect*)(nint)rect)->m_Height = source.m_Height;
		float width2 = (float)width + source.m_Width;
		((Rect*)(nint)rect)->m_Width = width2;
		return rect;
	}
}
