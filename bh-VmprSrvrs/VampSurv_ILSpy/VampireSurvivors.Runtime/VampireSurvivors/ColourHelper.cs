using System;
using System.Globalization;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;

namespace VampireSurvivors;

public static class ColourHelper
{
	public static string ColorToHex(Color32 color)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4900]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		byte b = default(byte);
		string text = b.ToString("X2");
		byte b2 = default(byte);
		string text2 = b2.ToString("X2");
		byte b3 = default(byte);
		string text3 = b3.ToString("X2");
		return text + text2 + text3;
	}

	public unsafe static Color HexToColor(string hex)
	{
		//IL_05d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05dc: Expected O, but got Unknown
		//IL_0603: Unknown result type (might be due to invalid IL or missing references)
		//IL_0608: Expected O, but got Unknown
		//IL_0132: Expected O, but got I4
		//IL_03ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f4: Expected O, but got Unknown
		//IL_041b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0420: Expected O, but got Unknown
		//IL_019b: Expected O, but got I4
		//IL_049e: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a3: Expected O, but got Unknown
		//IL_04ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cf: Expected O, but got Unknown
		//IL_0542: Expected native int or pointer, but got O
		//IL_0204: Expected O, but got I4
		//IL_056d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0572: Expected O, but got Unknown
		//IL_0599: Unknown result type (might be due to invalid IL or missing references)
		//IL_059e: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A4901]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string text = hex.Replace("0x", "");
		string text2 = text.Replace("#", "");
		if (text2._stringLength >= 0)
		{
			bool flag = text2._stringLength < 2;
			bool flag2 = text2._stringLength == 2;
			if (!flag)
			{
				string text4;
				if (!flag2)
				{
					string text3 = text2.InternalSubString(0, 2);
					if (text3 == null)
					{
						goto IL_03a1;
					}
					text4 = text3;
				}
				else
				{
					text4 = text2;
				}
				object obj = text4 + 20;
				_ = text4._stringLength;
				_ = 0;
				NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
				object obj2 = default(object);
				ReadOnlySpan<char> s = (ReadOnlySpan<char>)(obj2 - 32);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-20]");
				_ = 0;
				byte b = byte.Parse(s, NumberStyles.HexNumber, currentInfo);
				if (text2._stringLength >= 2)
				{
					object obj3 = text2._stringLength - 2;
					if ((nint)obj3 >= 2)
					{
						string text5 = text2.InternalSubString(2, 2);
						if (text5 != null)
						{
							object obj4 = text5 + 20;
							_ = 0;
							_ = text5._stringLength;
							NumberFormatInfo currentInfo2 = NumberFormatInfo.CurrentInfo;
							ReadOnlySpan<char> s2 = (ReadOnlySpan<char>)(obj2 - 32);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-20]");
							_ = 0;
							byte b2 = byte.Parse(s2, NumberStyles.HexNumber, currentInfo2);
							if (text2._stringLength < 4)
							{
								ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("startIndex", "startIndex cannot be larger than length of string.");
								ex._002Ector("startIndex", "startIndex cannot be larger than length of string.");
								throw ex;
							}
							object obj5 = text2._stringLength - 2;
							if ((nint)obj5 < 4)
							{
								ArgumentOutOfRangeException ex2 = new ArgumentOutOfRangeException("length", "Index and length must refer to a location within the string.");
								ex2._002Ector("length", "Index and length must refer to a location within the string.");
								throw ex2;
							}
							string text6 = text2.InternalSubString(4, 2);
							if (text6 != null)
							{
								object obj6 = text6 + 20;
								_ = 0;
								_ = text6._stringLength;
								NumberFormatInfo currentInfo3 = NumberFormatInfo.CurrentInfo;
								ReadOnlySpan<char> s3 = (ReadOnlySpan<char>)(obj2 - 32);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-20]");
								_ = 0;
								byte b3 = byte.Parse(s3, NumberStyles.HexNumber, currentInfo3);
								bool flag3 = text2._stringLength != 8;
								byte b4 = 255;
								if (!flag3)
								{
									object obj7 = text2._stringLength - 2;
									if ((nint)obj7 < 6)
									{
										goto IL_054c;
									}
									string text7 = text2.InternalSubString(6, 2);
									if (text7 == null)
									{
										goto IL_03a1;
									}
									object obj8 = text7 + 20;
									_ = 0;
									_ = text7._stringLength;
									NumberFormatInfo currentInfo4 = NumberFormatInfo.CurrentInfo;
									ReadOnlySpan<char> s4 = (ReadOnlySpan<char>)(obj2 - 32);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-20]");
									_ = 0;
									byte b5 = byte.Parse(s4, NumberStyles.HexNumber, currentInfo4);
									b4 = b5;
								}
								_ = 0;
								Color color = default(Color);
								float r = default(float);
								((Color*)(nint)color)->r = r;
								return color;
							}
						}
						goto IL_03a1;
					}
					ArgumentOutOfRangeException ex3 = new ArgumentOutOfRangeException("length", "Index and length must refer to a location within the string.");
					ex3._002Ector("length", "Index and length must refer to a location within the string.");
					throw ex3;
				}
				ArgumentOutOfRangeException ex4 = new ArgumentOutOfRangeException("startIndex", "startIndex cannot be larger than length of string.");
				ex4._002Ector("startIndex", "startIndex cannot be larger than length of string.");
				throw ex4;
			}
			ArgumentOutOfRangeException ex5 = new ArgumentOutOfRangeException("length", "Index and length must refer to a location within the string.");
			ex5._002Ector("length", "Index and length must refer to a location within the string.");
			throw ex5;
		}
		ArgumentOutOfRangeException ex6 = new ArgumentOutOfRangeException("startIndex", "startIndex cannot be larger than length of string.");
		ex6._002Ector("startIndex", "startIndex cannot be larger than length of string.");
		throw ex6;
		IL_03a1:
		System.ThrowHelper.ThrowArgumentNullException(System.ExceptionArgument.s);
		goto IL_054c;
		IL_054c:
		ArgumentOutOfRangeException ex7 = new ArgumentOutOfRangeException("length", "Index and length must refer to a location within the string.");
		ex7._002Ector("length", "Index and length must refer to a location within the string.");
		throw ex7;
	}

	public unsafe static Color Hex24ToColor(uint hexInt)
	{
		//IL_0017: Expected native int or pointer, but got O
		//IL_0042: Expected native int or pointer, but got O
		//IL_006f: Expected native int or pointer, but got O
		//IL_007c: Expected native int or pointer, but got O
		int num = (int)hexInt >> 16;
		Color color = default(Color);
		((Color*)(nint)color)->a = 1f;
		int num2 = (int)hexInt >> 8;
		float r = (float)num / 255f;
		((Color*)(nint)color)->r = r;
		float g = (float)num2 / 255f;
		float b = (float)(int)hexInt / 255f;
		((Color*)(nint)color)->g = g;
		((Color*)(nint)color)->b = b;
		return color;
	}

	private static float step(float threshold, float value)
	{
		//IL_0028: Expected F4, but got I4
		if (!(threshold > value))
		{
			return 1f;
		}
		return 0f;
	}

	private unsafe static float3 frac(float3 value)
	{
		//IL_005d: Expected native int or pointer, but got O
		//IL_0083: Expected native int or pointer, but got O
		//IL_0090: Expected native int or pointer, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003EA0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003EA0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003EA0");
		float x = value.x - value.x;
		float y = value.y - value.y;
		float3 float5 = default(float3);
		((float3*)(nint)float5)->x = x;
		float z = value.z - value.z;
		((float3*)(nint)float5)->y = y;
		((float3*)(nint)float5)->z = z;
		return float5;
	}

	public unsafe static float3 rgb2hsv(float3 c)
	{
		//IL_003d: Expected F4, but got I4
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f9: Expected O, but got Unknown
		//IL_004b: Expected F4, but got I4
		//IL_0182: Expected native int or pointer, but got O
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Expected F4, but got Unknown
		//IL_01fe: Expected native int or pointer, but got O
		//IL_021a: Expected native int or pointer, but got O
		float num = ((c.z > c.y) ? 0f : 1f);
		float num2 = c.z - c.y;
		float num3 = c.y - c.z;
		float num4 = 1f * num;
		float num5 = num2 * num;
		float num6 = num3 * num;
		float num7 = num4 + -1f;
		float num8 = num5 + c.y;
		float num9 = -1f * num;
		float num10 = num6 + c.z;
		float num11 = num9 + 2f / 3f;
		bool flag = !(num10 > c.x);
		float num12 = 1f;
		if (!flag)
		{
			num12 = 0f;
		}
		float num13 = c.x - num10;
		float num14 = num8 - num8;
		float num15 = num10 - c.x;
		float num16 = num7 - num11;
		float num17 = num13 * num12;
		float num18 = num14 * num12;
		float num19 = num16 * num12;
		float num20 = num17 + num10;
		float num21 = num18 + num8;
		float num22 = num15 * num12;
		float num23 = num19 + num11;
		float num24 = num22 + c.x;
		object obj = num21 & -2147483649L;
		float num25 = (((nint)obj > 2139095040 || num21 > num24) ? num24 : num21);
		float num26 = num24 - num21;
		float3 float5 = default(float3);
		((float3*)(nint)float5)->z = num20;
		float num27 = num20 - num25;
		float num28 = num27 * 6f;
		float num29 = num28 + 1E-10f;
		float num30 = num26 / num29;
		float num31 = num30 + num23;
		float num32 = num20 + 1E-10f;
		float x = num31 & -2147483649L;
		((float3*)(nint)float5)->x = x;
		float y = num27 / num32;
		((float3*)(nint)float5)->y = y;
		return float5;
	}

	public unsafe static float3 hsv2rgb(float3 c)
	{
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected O, but got Unknown
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected O, but got Unknown
		//IL_00f2: Expected O, but got F4
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected O, but got Unknown
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected O, but got Unknown
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Expected O, but got Unknown
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Expected O, but got Unknown
		//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Expected O, but got Unknown
		//IL_02eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f0: Expected O, but got Unknown
		//IL_031a: Unknown result type (might be due to invalid IL or missing references)
		//IL_031f: Expected O, but got Unknown
		//IL_01f6: Invalid comparison between I4 and F4
		//IL_024c: Expected F4, but got I4
		//IL_0211: Invalid comparison between I4 and F4
		//IL_038c: Expected native int or pointer, but got O
		//IL_0399: Expected native int or pointer, but got O
		//IL_022c: Invalid comparison between I4 and F4
		float num = c.x + 2f / 3f;
		float num2 = c.x + 1f / 3f;
		float num3 = c.x + 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003EA0");
		float num4 = num3 - num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003EA0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003EA0");
		float num5 = num2 - num2;
		float num6 = num4 * 6f;
		float num7 = num5 * 6f;
		float num8 = num6 - 3f;
		float num9 = num7 - 3f;
		object obj = num8 & -2147483649L;
		object obj2 = num9 & -2147483649L;
		object obj3 = num8 >> 32;
		object obj4 = obj3 & -2147483649L;
		float num10 = (float)obj - 1f;
		float num11 = (float)obj2 - 1f;
		float num12 = (float)obj4 - 1f;
		object obj5 = num10 & -2147483649L;
		if ((nint)obj5 > 2139095040 || num10 > 1f)
		{
			num10 = 1f;
		}
		object obj6 = num12 & -2147483649L;
		if ((nint)obj6 > 2139095040 || num12 > 1f)
		{
			num12 = 1f;
		}
		object obj7 = num11 & -2147483649L;
		if ((nint)obj7 > 2139095040 || num11 > 1f)
		{
			num11 = 1f;
		}
		object obj8 = num10 & -2147483649L;
		if ((nint)obj8 > 2139095040 || !(0f > num10))
		{
			object obj9 = num12 & -2147483649L;
			if ((nint)obj9 > 2139095040)
			{
				goto IL_030d;
			}
		}
		if (0f > num12)
		{
			goto IL_0223;
		}
		goto IL_030d;
		IL_030d:
		object obj10 = num11 & -2147483649L;
		if ((nint)obj10 <= 2139095040)
		{
			goto IL_0223;
		}
		goto IL_0243;
		IL_0223:
		if (0f > num11)
		{
			goto IL_0243;
		}
		goto IL_033c;
		IL_0243:
		num11 = 0f;
		goto IL_033c;
		IL_033c:
		float num13 = num11 - 1f;
		float num14 = num13 * c.y;
		float num15 = num14 + 1f;
		float z = num15 * c.z;
		float3 float5 = default(float3);
		float x = default(float);
		((float3*)(nint)float5)->x = x;
		((float3*)(nint)float5)->z = z;
		return float5;
	}
}
