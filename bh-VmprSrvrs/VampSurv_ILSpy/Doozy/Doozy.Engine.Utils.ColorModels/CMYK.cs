using System;
using Cpp2ILInjected;
using UnityEngine;

namespace Doozy.Engine.Utils.ColorModels;

[Serializable]
public class CMYK
{
	public class C
	{
		public const float MIN = 0f;

		public const float MAX = 1f;

		public const int F = 100;
	}

	public class M
	{
		public const float MIN = 0f;

		public const float MAX = 1f;

		public const int F = 100;
	}

	public class Y
	{
		public const float MIN = 0f;

		public const float MAX = 1f;

		public const int F = 100;
	}

	public class K
	{
		public const float MIN = 0f;

		public const float MAX = 1f;

		public const int F = 100;
	}

	public float c;

	public float m;

	public float y;

	public float k;

	public CMYK(float C, float M, float Y, float K)
	{
		float num = default(float);
		k = num;
		c = C;
		m = M;
		y = Y;
	}

	public CMYK Copy()
	{
		CMYK cMYK = null;
		cMYK.c = c;
		return cMYK;
	}

	public unsafe Color Color(float alpha = 1f)
	{
		//IL_00c9: Invalid comparison between I4 and F4
		//IL_00db: Expected F4, but got I4
		//IL_00f2: Invalid comparison between I4 and F4
		//IL_0104: Expected F4, but got I4
		//IL_011b: Invalid comparison between I4 and F4
		//IL_012d: Expected F4, but got I4
		//IL_01c6: Expected native int or pointer, but got O
		RGB rGB = ColorUtils.CMYKtoRGB(this);
		if (rGB != null)
		{
			bool flag = !(1f > rGB.r);
			float num = 1f;
			if (!flag)
			{
				num = rGB.r;
			}
			bool flag2 = !(0f < num);
			float r = 0f;
			if (!flag2)
			{
				r = num;
			}
			rGB.r = r;
			bool flag3 = !(1f > rGB.g);
			float num2 = 1f;
			if (!flag3)
			{
				num2 = rGB.g;
			}
			bool flag4 = !(0f < num2);
			float g = 0f;
			if (!flag4)
			{
				g = num2;
			}
			rGB.g = g;
			bool flag5 = !(1f > rGB.b);
			float num3 = 1f;
			if (!flag5)
			{
				num3 = rGB.b;
			}
			bool flag6 = !(0f < num3);
			float b = 0f;
			if (!flag6)
			{
				b = num3;
			}
			rGB.b = b;
			Color color = default(Color);
			float r2 = default(float);
			((Color*)(nint)color)->r = r2;
			return color;
		}
		return (Color)new NullReferenceException();
	}

	public RGB ToRGB()
	{
		return ColorUtils.CMYKtoRGB(this);
	}

	public CMYK Validate()
	{
		//IL_00a4: Invalid comparison between I4 and F4
		//IL_00b6: Expected F4, but got I4
		//IL_00cd: Invalid comparison between I4 and F4
		//IL_00df: Expected F4, but got I4
		//IL_00f6: Invalid comparison between I4 and F4
		//IL_0108: Expected F4, but got I4
		//IL_011f: Invalid comparison between I4 and F4
		//IL_0131: Expected F4, but got I4
		bool flag = !(1f > c);
		float num = 1f;
		if (!flag)
		{
			num = c;
		}
		bool flag2 = !(0f < num);
		float num2 = 0f;
		if (!flag2)
		{
			num2 = num;
		}
		c = num2;
		bool flag3 = !(1f > m);
		float num3 = 1f;
		if (!flag3)
		{
			num3 = m;
		}
		bool flag4 = !(0f < num3);
		float num4 = 0f;
		if (!flag4)
		{
			num4 = num3;
		}
		m = num4;
		bool flag5 = !(1f > y);
		float num5 = 1f;
		if (!flag5)
		{
			num5 = y;
		}
		bool flag6 = !(0f < num5);
		float num6 = 0f;
		if (!flag6)
		{
			num6 = num5;
		}
		y = num6;
		bool flag7 = !(1f > k);
		float num7 = 1f;
		if (!flag7)
		{
			num7 = k;
		}
		bool flag8 = !(0f < num7);
		float num8 = 0f;
		if (!flag8)
		{
			num8 = num7;
		}
		k = num8;
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

	public unsafe Vector4 Factorize()
	{
		//IL_0009: Expected native int or pointer, but got O
		//IL_00b7: Invalid comparison between I4 and F4
		//IL_00c9: Expected F4, but got I4
		//IL_0156: Expected native int or pointer, but got O
		//IL_00e0: Invalid comparison between I4 and F4
		//IL_00f2: Expected F4, but got I4
		//IL_01b2: Expected native int or pointer, but got O
		//IL_0109: Invalid comparison between I4 and F4
		//IL_011b: Expected F4, but got I4
		//IL_020e: Expected native int or pointer, but got O
		//IL_0132: Invalid comparison between I4 and F4
		//IL_026a: Expected native int or pointer, but got O
		Vector4 vector = default(Vector4);
		((Vector4*)(nint)vector)->x = 0f;
		float num = c * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
		bool flag = !(100f > num);
		float num2 = 100f;
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
		float num7 = default(float);
		float z = default(float);
		float num12;
		do
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm1\"");
			((Vector4*)(nint)vector)->x = x;
			float num4 = m * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
			bool flag3 = !(100f > num4);
			float num5 = 100f;
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
			((Vector4*)(nint)vector)->y = num7;
			float num8 = y * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
			bool flag5 = !(100f > num8);
			float num9 = 100f;
			if (!flag5)
			{
				num9 = num8;
			}
			bool flag6 = !(0f < num9);
			float num10 = 0f;
			if (!flag6)
			{
				num10 = num9;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm1\"");
			((Vector4*)(nint)vector)->z = z;
			float num11 = k * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
			bool flag7 = !(100f > num11);
			num12 = 100f;
			if (!flag7)
			{
				num12 = num11;
			}
		}
		while (0f < num12);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm6\"");
		float w = default(float);
		((Vector4*)(nint)vector)->w = w;
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
		//IL_0124: Expected Ref, but got F4
		//IL_015c: Expected Ref, but got F4
		//IL_018f: Expected Ref, but got F4
		//IL_0213: Expected Ref, but got F4
		//IL_00e2: Expected F4, but got Ref
		string[] array = new string[9];
		float num4;
		if (factorize)
		{
			if (array == null)
			{
				goto IL_01d5;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Vector4 vector = Factorize();
			float num = default(float);
			string text = num.ToString();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Vector4 vector2 = Factorize();
			float num2 = default(float);
			string text2 = num2.ToString();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Vector4 vector3 = Factorize();
			float num3 = default(float);
			string text3 = num3.ToString();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Vector4 vector4 = Factorize();
			object obj = default(object);
			num4 = (nint)(&obj);
		}
		else
		{
			if (array == null)
			{
				goto IL_01d5;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			float num5 = (float)this + 16f;
			string text4 = ((float*)num5)->ToString();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			float num6 = (float)this + 20f;
			string text5 = ((float*)num6)->ToString();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			float num7 = (float)this + 24f;
			string text6 = ((float*)num7)->ToString();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			num4 = (float)this + 28f;
		}
		string text7 = ((float*)num4)->ToString();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		return string.Concat(array);
		IL_01d5:
		return (string)(object)new NullReferenceException();
	}
}
