using System;
using Cpp2ILInjected;
using UnityEngine;

namespace Doozy.Engine.Utils.ColorModels;

[Serializable]
public class RGB(float R, float G, float B)
{
	public class R
	{
		public const float MIN = 0f;

		public const float MAX = 1f;

		public const int F = 255;
	}

	public class G
	{
		public const float MIN = 0f;

		public const float MAX = 1f;

		public const int F = 255;
	}

	public class B
	{
		public const float MIN = 0f;

		public const float MAX = 1f;

		public const int F = 255;
	}

	public float r = R;

	public float g = G;

	public float b = B;

	public RGB Copy()
	{
		RGB rGB = null;
		rGB.r = r;
		rGB.g = g;
		rGB.b = b;
		return rGB;
	}

	public unsafe Color Color(float alpha = 1f)
	{
		//IL_0009: Invalid comparison between I4 and F4
		//IL_0054: Expected F4, but got I4
		//IL_0063: Expected native int or pointer, but got O
		//IL_0072: Expected native int or pointer, but got O
		//IL_0081: Expected native int or pointer, but got O
		//IL_008e: Expected native int or pointer, but got O
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
		Color color = default(Color);
		((Color*)(nint)color)->r = r;
		((Color*)(nint)color)->g = g;
		((Color*)(nint)color)->b = b;
		((Color*)(nint)color)->a = num;
		return color;
	}

	public HSL ToHSL()
	{
		return ColorUtils.RGBtoHSL(this);
	}

	public HSV ToHSV()
	{
		return ColorUtils.RGBtoHSV(this);
	}

	public CMY ToCMY()
	{
		return ColorUtils.RGBtoCMY(this);
	}

	public CMYK ToCMYK()
	{
		return ColorUtils.RGBtoCMYK(this);
	}

	public XYZ ToXYZ()
	{
		//IL_0108: Invalid comparison between I4 and F4
		//IL_011a: Expected F4, but got I4
		//IL_0131: Invalid comparison between I4 and F4
		//IL_0143: Expected F4, but got I4
		//IL_015a: Invalid comparison between I4 and F4
		//IL_016c: Expected F4, but got I4
		//IL_0183: Invalid comparison between I4 and F4
		//IL_0195: Expected F4, but got I4
		//IL_01ac: Invalid comparison between I4 and F4
		//IL_01be: Expected F4, but got I4
		//IL_01d5: Invalid comparison between I4 and F4
		//IL_01e7: Expected F4, but got I4
		if (this != null)
		{
			RGB rGB = null;
			bool flag = !(1f > r);
			float num = 1f;
			if (!flag)
			{
				num = r;
			}
			bool flag2 = !(0f < num);
			float num2 = 0f;
			if (!flag2)
			{
				num2 = num;
			}
			rGB.r = num2;
			bool flag3 = !(1f > g);
			float num3 = 1f;
			if (!flag3)
			{
				num3 = g;
			}
			bool flag4 = !(0f < num3);
			float num4 = 0f;
			if (!flag4)
			{
				num4 = num3;
			}
			rGB.g = num4;
			bool flag5 = !(1f > b);
			float num5 = 1f;
			if (!flag5)
			{
				num5 = b;
			}
			bool flag6 = !(0f < num5);
			float num6 = 0f;
			if (!flag6)
			{
				num6 = num5;
			}
			rGB.b = num6;
			float num7 = num4 * 0.1192f;
			float num8 = num2 * 0.0193f;
			float num9 = num6 * 0.0722f;
			float num10 = num4 * 0.7152f;
			float num11 = num2 * 0.2126f;
			float num12 = num7 + num8;
			float num13 = num6 * 0.9505f;
			XYZ xYZ = null;
			float num14 = num4 * 0.3576f;
			float num15 = num2 * 0.4124f;
			float num16 = num6 * 0.1805f;
			float num17 = num14 + num15;
			float num18 = num17 + num16;
			bool flag7 = !(0.95047f > num18);
			float num19 = 0.95047f;
			if (!flag7)
			{
				num19 = num18;
			}
			bool flag8 = !(0f < num19);
			float x = 0f;
			if (!flag8)
			{
				x = num19;
			}
			xYZ.x = x;
			float num20 = num11 + num10;
			float num21 = num20 + num9;
			bool flag9 = !(1f > num21);
			float num22 = 1f;
			if (!flag9)
			{
				num22 = num21;
			}
			bool flag10 = !(0f < num22);
			float y = 0f;
			if (!flag10)
			{
				y = num22;
			}
			xYZ.y = y;
			float num23 = num12 + num13;
			bool flag11 = !(1.08883f > num23);
			float num24 = 1.08883f;
			if (!flag11)
			{
				num24 = num23;
			}
			bool flag12 = !(0f < num24);
			float z = 0f;
			if (!flag12)
			{
				z = num24;
			}
			xYZ.z = z;
			return xYZ;
		}
		return (XYZ)(object)new NullReferenceException();
	}

	public RGB Validate()
	{
		//IL_0088: Invalid comparison between I4 and F4
		//IL_009a: Expected F4, but got I4
		//IL_00b1: Invalid comparison between I4 and F4
		//IL_00c3: Expected F4, but got I4
		//IL_00da: Invalid comparison between I4 and F4
		//IL_00ec: Expected F4, but got I4
		bool flag = !(1f > r);
		float num = 1f;
		if (!flag)
		{
			num = r;
		}
		bool flag2 = !(0f < num);
		float num2 = 0f;
		if (!flag2)
		{
			num2 = num;
		}
		r = num2;
		bool flag3 = !(1f > g);
		float num3 = 1f;
		if (!flag3)
		{
			num3 = g;
		}
		bool flag4 = !(0f < num3);
		float num4 = 0f;
		if (!flag4)
		{
			num4 = num3;
		}
		g = num4;
		bool flag5 = !(1f > b);
		float num5 = 1f;
		if (!flag5)
		{
			num5 = b;
		}
		bool flag6 = !(0f < num5);
		float num6 = 0f;
		if (!flag6)
		{
			num6 = num5;
		}
		b = num6;
		return this;
	}

	private float ValidateColor(float value, float min, float max)
	{
		float num = default(float);
		if (num > value)
		{
		}
		float num2 = default(float);
		if (num2 < value)
		{
		}
		return value;
	}

	public unsafe Vector3 Factorize()
	{
		//IL_0009: Expected native int or pointer, but got O
		//IL_0029: Expected native int or pointer, but got O
		//IL_00ab: Invalid comparison between I4 and F4
		//IL_00bd: Expected F4, but got I4
		//IL_0121: Expected native int or pointer, but got O
		//IL_00d4: Invalid comparison between I4 and F4
		//IL_00e6: Expected F4, but got I4
		//IL_017d: Expected native int or pointer, but got O
		//IL_00fd: Invalid comparison between I4 and F4
		//IL_01d9: Expected native int or pointer, but got O
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = 0f;
		float num = r * 255f;
		((Vector3*)(nint)vector)->z = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
		bool flag = !(255f > num);
		float num2 = 255f;
		if (!flag)
		{
			num2 = num;
		}
		bool flag2 = !(0f < num2);
		float num3 = 0f;
		if (!flag2)
		{
			num3 = num2;
		}
		float x = default(float);
		float y = default(float);
		float num8;
		do
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm1\"");
			((Vector3*)(nint)vector)->x = x;
			float num4 = g * 255f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
			bool flag3 = !(255f > num4);
			float num5 = 255f;
			if (!flag3)
			{
				num5 = num4;
			}
			bool flag4 = !(0f < num5);
			float num6 = 0f;
			if (!flag4)
			{
				num6 = num5;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm1\"");
			((Vector3*)(nint)vector)->y = y;
			float num7 = b * 255f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
			bool flag5 = !(255f > num7);
			num8 = 255f;
			if (!flag5)
			{
				num8 = num7;
			}
		}
		while (0f < num8);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm6\"");
		float z = default(float);
		((Vector3*)(nint)vector)->z = z;
		return vector;
	}

	private int FactorizeColor(float value, float min, float max, float f)
	{
		object obj = default(object);
		float num = value * (float)obj;
		float num2 = min * (float)obj;
		float num3 = max * (float)obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
		if (num3 > num)
		{
			num3 = num;
		}
		if (num2 < num3)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm7\"");
		int result = default(int);
		return result;
	}

	public unsafe string ToString(bool factorize = false)
	{
		//IL_00f0: Expected Ref, but got F4
		//IL_0128: Expected Ref, but got F4
		//IL_01a7: Expected Ref, but got F4
		//IL_00ae: Expected F4, but got Ref
		string[] array = new string[7];
		float num3;
		if (factorize)
		{
			if (array == null)
			{
				goto IL_0169;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Vector3 vector = Factorize();
			float num = default(float);
			string text = num.ToString();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Vector3 vector2 = Factorize();
			float num2 = default(float);
			string text2 = num2.ToString();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Vector3 vector3 = Factorize();
			float num4 = default(float);
			num3 = (nint)(&num4);
		}
		else
		{
			if (array == null)
			{
				goto IL_0169;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			float num5 = (float)this + 16f;
			string text3 = ((float*)num5)->ToString();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			float num6 = (float)this + 20f;
			string text4 = ((float*)num6)->ToString();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			num3 = (float)this + 24f;
		}
		string text5 = ((float*)num3)->ToString();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		return string.Concat(array);
		IL_0169:
		return (string)(object)new NullReferenceException();
	}

	public unsafe string ToHEX(bool addHashTag = true)
	{
		//IL_006d: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980636]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag = !addHashTag;
		string text = "";
		if (!flag)
		{
			text = "#";
		}
		float num = default(float);
		string text2 = ColorUtility.ToHtmlStringRGB((Color)(&num));
		return text + text2;
	}
}
