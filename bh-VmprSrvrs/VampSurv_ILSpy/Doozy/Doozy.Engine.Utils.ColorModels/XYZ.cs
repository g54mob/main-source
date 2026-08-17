using System;
using Cpp2ILInjected;
using UnityEngine;

namespace Doozy.Engine.Utils.ColorModels;

[Serializable]
public class XYZ(float X, float Y, float Z)
{
	public class X
	{
		public const float MIN = 0f;

		public const float MAX = 0.95047f;

		public const int F = 100;
	}

	public class Y
	{
		public const float MIN = 0f;

		public const float MAX = 1f;

		public const int F = 100;
	}

	public class Z
	{
		public const float MIN = 0f;

		public const float MAX = 1.08883f;

		public const int F = 100;
	}

	public float x = X;

	public float y = Y;

	public float z = Z;

	public XYZ Copy()
	{
		XYZ xYZ = null;
		xYZ.x = x;
		xYZ.y = y;
		xYZ.z = z;
		return xYZ;
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
		RGB rGB = ColorUtils.XYZtoRGB(this);
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
		return ColorUtils.XYZtoRGB(this);
	}

	public XYZ Validate()
	{
		//IL_0088: Invalid comparison between I4 and F4
		//IL_009a: Expected F4, but got I4
		//IL_00b1: Invalid comparison between I4 and F4
		//IL_00c3: Expected F4, but got I4
		//IL_00da: Invalid comparison between I4 and F4
		//IL_00ec: Expected F4, but got I4
		bool flag = !(0.95047f > x);
		float num = 0.95047f;
		if (!flag)
		{
			num = x;
		}
		bool flag2 = !(0f < num);
		float num2 = 0f;
		if (!flag2)
		{
			num2 = num;
		}
		x = num2;
		bool flag3 = !(1f > y);
		float num3 = 1f;
		if (!flag3)
		{
			num3 = y;
		}
		bool flag4 = !(0f < num3);
		float num4 = 0f;
		if (!flag4)
		{
			num4 = num3;
		}
		y = num4;
		bool flag5 = !(1.08883f > z);
		float num5 = 1.08883f;
		if (!flag5)
		{
			num5 = z;
		}
		bool flag6 = !(0f < num5);
		float num6 = 0f;
		if (!flag6)
		{
			num6 = num5;
		}
		z = num6;
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
		//IL_0017: Expected native int or pointer, but got O
		//IL_009e: Invalid comparison between I4 and F4
		//IL_0106: Expected native int or pointer, but got O
		//IL_00b9: Invalid comparison between I4 and F4
		//IL_00cb: Expected F4, but got I4
		//IL_0162: Expected native int or pointer, but got O
		//IL_00e2: Invalid comparison between I4 and F4
		//IL_01be: Expected native int or pointer, but got O
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = 0f;
		((Vector3*)(nint)vector)->z = 0f;
		float num = x * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
		bool flag = !(95.047f > num);
		float num2 = 95.047f;
		if (!flag)
		{
			num2 = num;
		}
		if (0f < num2)
		{
			goto IL_00b0;
		}
		goto IL_00f4;
		IL_00f4:
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		float num3 = default(float);
		((Vector3*)(nint)vector)->x = num3;
		float num4 = y * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
		bool flag2 = !(100f > num4);
		float num5 = 100f;
		if (!flag2)
		{
			num5 = num4;
		}
		goto IL_00b0;
		IL_00b0:
		bool flag3 = !(0f < num5);
		float num6 = 0f;
		if (!flag3)
		{
			num6 = num5;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm1\"");
		float num7 = default(float);
		((Vector3*)(nint)vector)->y = num7;
		float num8 = z * 100f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049A960");
		bool flag4 = !(108.882996f > num8);
		float num9 = 108.882996f;
		if (!flag4)
		{
			num9 = num8;
		}
		if (!(0f < num9))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm7\"");
			float num10 = default(float);
			((Vector3*)(nint)vector)->z = num10;
			return vector;
		}
		goto IL_00f4;
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
}
