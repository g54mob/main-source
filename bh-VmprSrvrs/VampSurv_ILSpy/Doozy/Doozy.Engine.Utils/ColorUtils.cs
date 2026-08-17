using System;
using Cpp2ILInjected;
using Doozy.Engine.Utils.ColorModels;
using UnityEngine;

namespace Doozy.Engine.Utils;

public static class ColorUtils
{
	public enum Conversions
	{
		RGB_TO_RGB,
		HEX_TO_RGB,
		RGB_TO_HEX,
		RGB_TO_FGC,
		HSL_TO_RGB,
		RGB_TO_HSL,
		HSV_TO_RGB,
		RGB_TO_HSV,
		CMY_TO_RGB,
		RGB_TO_CMY,
		CMYK_TO_RGB,
		RGB_TO_CMYK,
		XYZ_TO_RGB,
		RGB_TO_XYZ,
		Yxy_TO_RGB,
		RGB_TO_Yxy,
		LAB_TO_RGB,
		RGB_TO_LAB
	}

	public unsafe static Vector3 HUEtoRGB(float H)
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00b7: Expected native int or pointer, but got O
		//IL_00e4: Expected native int or pointer, but got O
		//IL_00f1: Expected native int or pointer, but got O
		float num = H * 6f;
		float num2 = H * 6f;
		float num3 = num - 3f;
		float num4 = H * 6f;
		float num5 = num2 - 2f;
		float num6 = num4 - 4f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj = num3 & 0;
		float x = (float)obj - 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj2 = num5 & 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj3 = num6 & 0;
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = x;
		float y = 2f - (float)obj2;
		float z = 2f - (float)obj3;
		((Vector3*)(nint)vector)->y = y;
		((Vector3*)(nint)vector)->z = z;
		return vector;
	}

	public static RGB HSLtoRGB(HSL values)
	{
		//IL_0379: Invalid comparison between I4 and F4
		//IL_038b: Expected F4, but got I4
		//IL_03a2: Invalid comparison between I4 and F4
		//IL_03b4: Expected F4, but got I4
		//IL_03cb: Invalid comparison between I4 and F4
		//IL_03dd: Expected F4, but got I4
		//IL_0579: Unknown result type (might be due to invalid IL or missing references)
		//IL_057e: Expected O, but got Unknown
		//IL_05e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e6: Expected O, but got Unknown
		//IL_0637: Invalid comparison between F4 and I4
		//IL_00c3: Expected F4, but got I4
		//IL_0281: Expected F4, but got I4
		//IL_028a: Expected F4, but got I4
		//IL_0293: Expected F4, but got I4
		//IL_0120: Expected F4, but got I4
		//IL_0195: Expected F4, but got I4
		//IL_043e: Invalid comparison between I4 and F4
		//IL_0450: Expected F4, but got I4
		//IL_02c1: Expected F4, but got I4
		//IL_02ca: Expected F4, but got I4
		//IL_02d3: Expected F4, but got I4
		//IL_01fa: Expected F4, but got I4
		//IL_0257: Expected F4, but got I4
		//IL_0467: Invalid comparison between I4 and F4
		//IL_0479: Expected F4, but got I4
		//IL_02f2: Expected F4, but got I4
		//IL_0490: Invalid comparison between I4 and F4
		//IL_04a2: Expected F4, but got I4
		float num8;
		float num12;
		float num14;
		float num15;
		float num16;
		if (values != null)
		{
			HSL hSL = null;
			bool flag = !(1f > values.h);
			float num = 1f;
			if (!flag)
			{
				num = values.h;
			}
			bool flag2 = !(0f < num);
			float h = 0f;
			if (!flag2)
			{
				h = num;
			}
			hSL.h = h;
			bool flag3 = !(1f > values.s);
			float num2 = 1f;
			if (!flag3)
			{
				num2 = values.s;
			}
			bool flag4 = !(0f < num2);
			float s = 0f;
			if (!flag4)
			{
				s = num2;
			}
			hSL.s = s;
			bool flag5 = !(1f > values.l);
			float num3 = 1f;
			if (!flag5)
			{
				num3 = values.l;
			}
			bool flag6 = !(0f < num3);
			float l = 0f;
			if (!flag6)
			{
				l = num3;
			}
			hSL.l = l;
			Vector3 vector = hSL.Factorize();
			float num4 = hSL.l + hSL.l;
			float num5 = num4 - 1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
			object obj = num5 & 0;
			float num6 = 1f - (float)obj;
			float num7 = vector.x / 60f;
			num8 = num6 * hSL.s;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
			float num9 = num7 - 1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
			object obj2 = num9 & 0;
			float num10 = 1f - (float)obj2;
			float num11 = num8 * 0.5f;
			num12 = hSL.l - num11;
			float num13 = num10 * num8;
			if (!(vector.x < 0f) && 60f > vector.x)
			{
				num14 = 0f;
				num15 = num13;
				goto IL_03eb;
			}
			if (!(vector.x < 60f) && 120f > vector.x)
			{
				num14 = 0f;
				num15 = num8;
				num16 = num13;
			}
			else if (!(vector.x < 120f) && 180f > vector.x)
			{
				num14 = num13;
				num15 = num8;
				num16 = 0f;
			}
			else if (!(vector.x < 180f) && 240f > vector.x)
			{
				num14 = num8;
				num15 = num13;
				num16 = 0f;
			}
			else if (!(vector.x < 240f) && 300f > vector.x)
			{
				num14 = num8;
				num15 = 0f;
				num16 = num13;
			}
			else
			{
				bool flag7 = vector.x < 300f;
				num14 = 0f;
				num15 = 0f;
				num16 = 0f;
				if (!flag7)
				{
					bool flag8 = !(360f > vector.x);
					num14 = 0f;
					num15 = 0f;
					num16 = 0f;
					if (!flag8)
					{
						num14 = num13;
						num15 = 0f;
						goto IL_03eb;
					}
				}
			}
			goto IL_03f8;
		}
		return (RGB)(object)new NullReferenceException();
		IL_03eb:
		num16 = num8;
		goto IL_03f8;
		IL_03f8:
		RGB rGB = null;
		float num17 = num16 + num12;
		bool flag9 = !(1f > num17);
		float num18 = 1f;
		if (!flag9)
		{
			num18 = num17;
		}
		bool flag10 = !(0f < num18);
		float r = 0f;
		if (!flag10)
		{
			r = num18;
		}
		rGB.r = r;
		float num19 = num15 + num12;
		bool flag11 = !(1f > num19);
		float num20 = 1f;
		if (!flag11)
		{
			num20 = num19;
		}
		bool flag12 = !(0f < num20);
		float g = 0f;
		if (!flag12)
		{
			g = num20;
		}
		rGB.g = g;
		float num21 = num14 + num12;
		bool flag13 = !(1f > num21);
		float num22 = 1f;
		if (!flag13)
		{
			num22 = num21;
		}
		bool flag14 = !(0f < num22);
		float b = 0f;
		if (!flag14)
		{
			b = num22;
		}
		rGB.b = b;
		return rGB;
	}

	public static HSL RGBtoHSL(RGB values)
	{
		//IL_0212: Expected F4, but got I4
		//IL_0114: Expected O, but got I4
		//IL_0124: Expected O, but got I4
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Expected O, but got Unknown
		//IL_0187: Expected O, but got I4
		//IL_0602: Unknown result type (might be due to invalid IL or missing references)
		//IL_0607: Expected O, but got Unknown
		//IL_0611: Unknown result type (might be due to invalid IL or missing references)
		//IL_0616: Expected O, but got Unknown
		//IL_0620: Unknown result type (might be due to invalid IL or missing references)
		//IL_0625: Expected O, but got Unknown
		//IL_0411: Expected F4, but got I4
		//IL_06a2: Invalid comparison between F4 and I4
		//IL_06cb: Expected F4, but got I4
		//IL_0792: Invalid comparison between F4 and I4
		//IL_07ab: Expected F4, but got I4
		//IL_043f: Expected F4, but got I4
		//IL_0313: Expected O, but got I4
		//IL_0323: Expected O, but got I4
		//IL_032c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0331: Expected O, but got Unknown
		//IL_0386: Expected O, but got I4
		//IL_07c2: Invalid comparison between I4 and F4
		//IL_055d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0562: Expected O, but got Unknown
		//IL_07e2: Invalid comparison between I4 and F4
		//IL_059d: Expected F4, but got I4
		//IL_0802: Invalid comparison between I4 and F4
		//IL_0811: Expected F4, but got I4
		//IL_05b9: Expected F4, but got I4
		//IL_06e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e7: Expected O, but got Unknown
		//IL_06f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f6: Expected O, but got Unknown
		//IL_0700: Unknown result type (might be due to invalid IL or missing references)
		//IL_0705: Expected O, but got Unknown
		float[] array = new float[3];
		float num;
		float num2;
		if (array.Length > 0)
		{
			array[0] = values.r;
			if (array.Length > 1)
			{
				array[1] = values.g;
				if (array.Length > 2)
				{
					array[2] = values.b;
					if (array.Length == 0)
					{
						num = 0f;
						goto IL_05e6;
					}
					if (array.Length > 0)
					{
						object obj = 1 - array.Length;
						object obj2 = 1 ^ array.Length;
						object obj3 = 1 ^ obj;
						object obj4 = obj2 & obj3;
						bool flag = (nint)obj4 < 0;
						bool flag2 = (nint)obj < 0;
						bool flag3 = 1 >= array.Length;
						num2 = values.r;
						object obj5 = 1;
						num = values.r;
						if (flag3)
						{
							goto IL_05e6;
						}
						while (flag2 != flag)
						{
							if (array[obj5] > num2)
							{
								num2 = array[obj5];
							}
							obj5++;
							object obj6 = obj5 - array.Length;
							object obj7 = obj5 ^ array.Length;
							object obj8 = obj5 ^ obj6;
							object obj9 = obj7 & obj8;
							flag = (nint)obj9 < 0;
							flag2 = (nint)obj6 < 0;
							if ((nint)obj5 < array.Length)
							{
								continue;
							}
							goto IL_01fc;
						}
					}
				}
			}
		}
		goto IL_05d8;
		IL_01fc:
		num = num2;
		goto IL_05e6;
		IL_05e6:
		float[] array2 = new float[3];
		float num3;
		float num4;
		if (array2.Length > 0)
		{
			array2[0] = values.r;
			if (array2.Length > 1)
			{
				array2[1] = values.g;
				if (array2.Length > 2)
				{
					array2[2] = values.b;
					if (array2.Length == 0)
					{
						num3 = 0f;
						goto IL_067b;
					}
					if (array2.Length > 0)
					{
						object obj10 = 1 - array2.Length;
						object obj11 = 1 ^ array2.Length;
						object obj12 = 1 ^ obj10;
						object obj13 = obj11 & obj12;
						bool flag4 = (nint)obj13 < 0;
						bool flag5 = (nint)obj10 < 0;
						bool flag6 = 1 >= array2.Length;
						num4 = values.r;
						object obj14 = 1;
						num3 = values.r;
						if (flag6)
						{
							goto IL_067b;
						}
						while (flag5 != flag4)
						{
							if (num4 > array2[obj14])
							{
								num4 = array2[obj14];
							}
							obj14++;
							object obj15 = obj14 - array2.Length;
							object obj16 = obj14 ^ array2.Length;
							object obj17 = obj14 ^ obj15;
							object obj18 = obj16 & obj17;
							flag4 = (nint)obj18 < 0;
							flag5 = (nint)obj15 < 0;
							if ((nint)obj14 < array2.Length)
							{
								continue;
							}
							goto IL_03fb;
						}
					}
				}
			}
		}
		goto IL_05d8;
		IL_05d8:
		return (HSL)(object)new IndexOutOfRangeException();
		IL_067b:
		float num5 = num - num3;
		float num6 = num3 + num;
		bool flag7 = num5 == 0f;
		float num7 = num6 * 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000182B86911h\"");
		float num8 = 0f;
		if (!flag7)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000182B86945h\"");
			bool flag8 = num != values.r;
			num8 = 0f;
			if (!flag8)
			{
				float num9 = values.g - values.b;
				float num10 = num9 / num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
				num8 = num10 * 60f;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000182B86968h\"");
			if (num == values.g)
			{
				float num11 = values.b - values.r;
				float num12 = num11 / num5;
				float num13 = num12 + 2f;
				num8 = num13 * 60f;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000182B8698Bh\"");
			if (num == values.b)
			{
				float num14 = values.r - values.g;
				float num15 = num14 / num5;
				float num16 = num15 + 4f;
				num8 = num16 * 60f;
			}
		}
		bool flag9 = num5 == 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000182B869A0h\"");
		float num17 = 0f;
		if (!flag9)
		{
			float num18 = num7 + num7;
			float num19 = num18 - 1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
			object obj19 = num19 & 0;
			float num20 = 1f - (float)obj19;
			num17 = num5 / num20;
		}
		HSL hSL = null;
		float num21 = num8 / 360f;
		if (num21 > 1f)
		{
			num21 = 1f;
		}
		if (0f > num21)
		{
			num21 = 0f;
		}
		hSL.h = num21;
		if (num17 > 1f)
		{
			num17 = 1f;
		}
		if (0f > num17)
		{
			num17 = 0f;
		}
		hSL.s = num17;
		bool flag10 = num7 > 1f;
		float num22 = 1f;
		if (!flag10)
		{
			num22 = num7;
		}
		bool flag11 = 0f > num22;
		float l = 0f;
		if (!flag11)
		{
			l = num22;
		}
		hSL.l = l;
		return hSL;
		IL_03fb:
		num3 = num4;
		goto IL_067b;
	}

	public static RGB HSVtoRGB(HSV values)
	{
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected O, but got Unknown
		//IL_00f0: Invalid comparison between F4 and I4
		//IL_013a: Expected F4, but got I4
		//IL_02f0: Expected F4, but got I4
		//IL_02f9: Expected F4, but got I4
		//IL_0302: Expected F4, but got I4
		//IL_019f: Expected F4, but got I4
		//IL_01fc: Expected F4, but got I4
		//IL_0330: Expected F4, but got I4
		//IL_0339: Expected F4, but got I4
		//IL_0342: Expected F4, but got I4
		//IL_0261: Expected F4, but got I4
		//IL_02be: Expected F4, but got I4
		//IL_0359: Expected F4, but got I4
		float num;
		float num3;
		float num7;
		float num8;
		float num9;
		if (values != null)
		{
			HSV hSV = null;
			hSV.h = values.h;
			hSV.s = values.s;
			hSV.v = values.v;
			Vector3 vector = hSV.Factorize();
			num = hSV.v * hSV.s;
			float num2 = vector.x / 60f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
			num3 = hSV.v - num;
			float num4 = num2 - 1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
			object obj = num4 & 0;
			float num5 = 1f - (float)obj;
			float num6 = num5 * num;
			if (!(vector.x < 0f) && 60f > vector.x)
			{
				num7 = num6;
				num8 = 0f;
				goto IL_0391;
			}
			if (!(vector.x < 60f) && 120f > vector.x)
			{
				num7 = num;
				num9 = num6;
				num8 = 0f;
			}
			else if (!(vector.x < 120f) && 180f > vector.x)
			{
				num7 = num;
				num9 = 0f;
				num8 = num6;
			}
			else if (!(vector.x < 180f) && 240f > vector.x)
			{
				num7 = num6;
				num9 = 0f;
				num8 = num;
			}
			else if (!(vector.x < 240f) && 300f > vector.x)
			{
				num7 = 0f;
				num9 = num6;
				num8 = num;
			}
			else
			{
				bool flag = vector.x < 300f;
				num7 = 0f;
				num9 = 0f;
				num8 = 0f;
				if (!flag)
				{
					bool flag2 = !(360f > vector.x);
					num7 = 0f;
					num9 = 0f;
					num8 = 0f;
					if (!flag2)
					{
						num7 = 0f;
						num8 = num6;
						goto IL_0391;
					}
				}
			}
			goto IL_039e;
		}
		return (RGB)(object)new NullReferenceException();
		IL_0391:
		num9 = num;
		goto IL_039e;
		IL_039e:
		RGB rGB = null;
		float r = num9 + num3;
		float g = num7 + num3;
		float b = num8 + num3;
		rGB.r = r;
		rGB.g = g;
		rGB.b = b;
		return rGB;
	}

	public static HSV RGBtoHSV(RGB values)
	{
		//IL_01f6: Expected F4, but got I4
		//IL_0114: Expected O, but got I4
		//IL_0124: Expected O, but got I4
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Expected O, but got Unknown
		//IL_0194: Expected O, but got I4
		//IL_05a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a7: Expected O, but got Unknown
		//IL_05b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b6: Expected O, but got Unknown
		//IL_05c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c5: Expected O, but got Unknown
		//IL_03f5: Expected F4, but got I4
		//IL_0633: Invalid comparison between F4 and I4
		//IL_064c: Expected F4, but got I4
		//IL_0713: Invalid comparison between F4 and I4
		//IL_072c: Expected F4, but got I4
		//IL_0423: Expected F4, but got I4
		//IL_02f7: Expected O, but got I4
		//IL_0307: Expected O, but got I4
		//IL_0310: Unknown result type (might be due to invalid IL or missing references)
		//IL_0315: Expected O, but got Unknown
		//IL_036a: Expected O, but got I4
		//IL_0743: Invalid comparison between I4 and F4
		//IL_0763: Invalid comparison between I4 and F4
		//IL_053d: Expected F4, but got I4
		//IL_0783: Invalid comparison between I4 and F4
		//IL_0792: Expected F4, but got I4
		//IL_0559: Expected F4, but got I4
		//IL_0663: Unknown result type (might be due to invalid IL or missing references)
		//IL_0668: Expected O, but got Unknown
		//IL_0672: Unknown result type (might be due to invalid IL or missing references)
		//IL_0677: Expected O, but got Unknown
		//IL_0681: Unknown result type (might be due to invalid IL or missing references)
		//IL_0686: Expected O, but got Unknown
		float[] array = new float[3];
		float num;
		float num2;
		if (array.Length > 0)
		{
			array[0] = values.r;
			if (array.Length > 1)
			{
				array[1] = values.g;
				if (array.Length > 2)
				{
					array[2] = values.b;
					if (array.Length == 0)
					{
						num = 0f;
						goto IL_0586;
					}
					if (array.Length > 0)
					{
						object obj = 1 - array.Length;
						object obj2 = 1 ^ array.Length;
						object obj3 = 1 ^ obj;
						object obj4 = obj2 & obj3;
						bool flag = (nint)obj4 < 0;
						bool flag2 = (nint)obj < 0;
						bool flag3 = 1 >= array.Length;
						num = values.r;
						num2 = values.r;
						object obj5 = 1;
						if (flag3)
						{
							goto IL_0586;
						}
						while (flag2 != flag)
						{
							if (array[obj5] > num2)
							{
								num2 = array[obj5];
							}
							obj5++;
							object obj6 = obj5 - array.Length;
							object obj7 = obj5 ^ array.Length;
							object obj8 = obj5 ^ obj6;
							object obj9 = obj7 & obj8;
							flag = (nint)obj9 < 0;
							flag2 = (nint)obj6 < 0;
							if ((nint)obj5 < array.Length)
							{
								continue;
							}
							goto IL_01e0;
						}
					}
				}
			}
		}
		goto IL_0578;
		IL_01e0:
		num = num2;
		goto IL_0586;
		IL_0586:
		float[] array2 = new float[3];
		float num3;
		float num4;
		if (array2.Length > 0)
		{
			array2[0] = values.r;
			if (array2.Length > 1)
			{
				array2[1] = values.g;
				if (array2.Length > 2)
				{
					array2[2] = values.b;
					if (array2.Length == 0)
					{
						num3 = 0f;
						goto IL_061b;
					}
					if (array2.Length > 0)
					{
						object obj10 = 1 - array2.Length;
						object obj11 = 1 ^ array2.Length;
						object obj12 = 1 ^ obj10;
						object obj13 = obj11 & obj12;
						bool flag4 = (nint)obj13 < 0;
						bool flag5 = (nint)obj10 < 0;
						bool flag6 = 1 >= array2.Length;
						num4 = values.r;
						object obj14 = 1;
						num3 = values.r;
						if (flag6)
						{
							goto IL_061b;
						}
						while (flag5 != flag4)
						{
							if (num4 > array2[obj14])
							{
								num4 = array2[obj14];
							}
							obj14++;
							object obj15 = obj14 - array2.Length;
							object obj16 = obj14 ^ array2.Length;
							object obj17 = obj14 ^ obj15;
							object obj18 = obj16 & obj17;
							flag4 = (nint)obj18 < 0;
							flag5 = (nint)obj15 < 0;
							if ((nint)obj14 < array2.Length)
							{
								continue;
							}
							goto IL_03df;
						}
					}
				}
			}
		}
		goto IL_0578;
		IL_0578:
		return (HSV)(object)new IndexOutOfRangeException();
		IL_061b:
		float num5 = num - num3;
		bool flag7 = num5 == 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000182B86E70h\"");
		float num6 = 0f;
		if (!flag7)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000182B86EA2h\"");
			bool flag8 = num != values.r;
			num6 = 0f;
			if (!flag8)
			{
				float num7 = values.g - values.b;
				float num8 = num7 / num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
				num6 = num8 * 60f;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000182B86EC4h\"");
			if (num == values.g)
			{
				float num9 = values.b - values.r;
				float num10 = num9 / num5;
				float num11 = num10 + 2f;
				num6 = num11 * 60f;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000182B86EE6h\"");
			if (num == values.b)
			{
				float num12 = values.r - values.g;
				float num13 = num12 / num5;
				float num14 = num13 + 4f;
				num6 = num14 * 60f;
			}
		}
		bool flag9 = num == 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000182B86EF2h\"");
		float num15 = 0f;
		if (!flag9)
		{
			num15 = num5 / num;
		}
		HSV hSV = null;
		float num16 = num6 / 360f;
		if (num16 > 1f)
		{
			num16 = 1f;
		}
		if (0f > num16)
		{
			num16 = 0f;
		}
		hSV.h = num16;
		if (num15 > 1f)
		{
			num15 = 1f;
		}
		if (0f > num15)
		{
			num15 = 0f;
		}
		hSV.s = num15;
		bool flag10 = num > 1f;
		float num17 = 1f;
		if (!flag10)
		{
			num17 = num;
		}
		bool flag11 = 0f > num17;
		float v = 0f;
		if (!flag11)
		{
			v = num17;
		}
		hSV.v = v;
		return hSV;
		IL_03df:
		num3 = num4;
		goto IL_061b;
	}

	public static RGB CMYtoRGB(CMY values)
	{
		//IL_0117: Invalid comparison between I4 and F4
		//IL_0129: Expected F4, but got I4
		//IL_0140: Invalid comparison between I4 and F4
		//IL_0152: Expected F4, but got I4
		//IL_0179: Invalid comparison between I4 and F4
		//IL_018b: Expected F4, but got I4
		//IL_01a2: Invalid comparison between I4 and F4
		//IL_01b4: Expected F4, but got I4
		//IL_01cb: Invalid comparison between I4 and F4
		//IL_01dd: Expected F4, but got I4
		//IL_01f4: Invalid comparison between I4 and F4
		//IL_0206: Expected F4, but got I4
		if (values != null)
		{
			CMY cMY = null;
			bool flag = !(1f > values.c);
			float num = 1f;
			if (!flag)
			{
				num = values.c;
			}
			bool flag2 = !(0f < num);
			float num2 = 0f;
			if (!flag2)
			{
				num2 = num;
			}
			cMY.c = num2;
			bool flag3 = !(1f > values.m);
			float num3 = 1f;
			if (!flag3)
			{
				num3 = values.m;
			}
			bool flag4 = !(0f < num3);
			float num4 = 0f;
			if (!flag4)
			{
				num4 = num3;
			}
			cMY.m = num4;
			bool flag5 = !(1f > values.y);
			float num5 = 1f;
			if (!flag5)
			{
				num5 = values.y;
			}
			float num6 = 1f - num4;
			bool flag6 = !(0f < num5);
			float num7 = 0f;
			if (!flag6)
			{
				num7 = num5;
			}
			cMY.y = num7;
			float num8 = 1f - num7;
			RGB rGB = null;
			float num9 = 1f - num2;
			bool flag7 = !(1f > num9);
			float num10 = 1f;
			if (!flag7)
			{
				num10 = num9;
			}
			bool flag8 = !(0f < num10);
			float r = 0f;
			if (!flag8)
			{
				r = num10;
			}
			rGB.r = r;
			bool flag9 = !(1f > num6);
			float num11 = 1f;
			if (!flag9)
			{
				num11 = num6;
			}
			bool flag10 = !(0f < num11);
			float g = 0f;
			if (!flag10)
			{
				g = num11;
			}
			rGB.g = g;
			bool flag11 = !(1f > num8);
			float num12 = 1f;
			if (!flag11)
			{
				num12 = num8;
			}
			bool flag12 = !(0f < num12);
			float b = 0f;
			if (!flag12)
			{
				b = num12;
			}
			rGB.b = b;
			return rGB;
		}
		return (RGB)(object)new NullReferenceException();
	}

	public static CMY RGBtoCMY(RGB values)
	{
		//IL_0117: Invalid comparison between I4 and F4
		//IL_0129: Expected F4, but got I4
		//IL_0140: Invalid comparison between I4 and F4
		//IL_0152: Expected F4, but got I4
		//IL_0179: Invalid comparison between I4 and F4
		//IL_018b: Expected F4, but got I4
		//IL_01a2: Invalid comparison between I4 and F4
		//IL_01b4: Expected F4, but got I4
		//IL_01cb: Invalid comparison between I4 and F4
		//IL_01dd: Expected F4, but got I4
		//IL_01f4: Invalid comparison between I4 and F4
		//IL_0206: Expected F4, but got I4
		if (values != null)
		{
			RGB rGB = null;
			bool flag = !(1f > values.r);
			float num = 1f;
			if (!flag)
			{
				num = values.r;
			}
			bool flag2 = !(0f < num);
			float num2 = 0f;
			if (!flag2)
			{
				num2 = num;
			}
			rGB.r = num2;
			bool flag3 = !(1f > values.g);
			float num3 = 1f;
			if (!flag3)
			{
				num3 = values.g;
			}
			bool flag4 = !(0f < num3);
			float num4 = 0f;
			if (!flag4)
			{
				num4 = num3;
			}
			rGB.g = num4;
			bool flag5 = !(1f > values.b);
			float num5 = 1f;
			if (!flag5)
			{
				num5 = values.b;
			}
			float num6 = 1f - num4;
			bool flag6 = !(0f < num5);
			float num7 = 0f;
			if (!flag6)
			{
				num7 = num5;
			}
			rGB.b = num7;
			float num8 = 1f - num7;
			CMY cMY = null;
			float num9 = 1f - num2;
			bool flag7 = !(1f > num9);
			float num10 = 1f;
			if (!flag7)
			{
				num10 = num9;
			}
			bool flag8 = !(0f < num10);
			float c = 0f;
			if (!flag8)
			{
				c = num10;
			}
			cMY.c = c;
			bool flag9 = !(1f > num6);
			float num11 = 1f;
			if (!flag9)
			{
				num11 = num6;
			}
			bool flag10 = !(0f < num11);
			float m = 0f;
			if (!flag10)
			{
				m = num11;
			}
			cMY.m = m;
			bool flag11 = !(1f > num8);
			float num12 = 1f;
			if (!flag11)
			{
				num12 = num8;
			}
			bool flag12 = !(0f < num12);
			float y = 0f;
			if (!flag12)
			{
				y = num12;
			}
			cMY.y = y;
			return cMY;
		}
		return (CMY)(object)new NullReferenceException();
	}

	public static RGB CMYKtoRGB(CMYK values)
	{
		//IL_01c1: Invalid comparison between I4 and F4
		//IL_01d3: Expected F4, but got I4
		//IL_01ea: Invalid comparison between I4 and F4
		//IL_01fc: Expected F4, but got I4
		//IL_0213: Invalid comparison between I4 and F4
		//IL_0225: Expected F4, but got I4
		//IL_023c: Invalid comparison between I4 and F4
		//IL_024e: Expected F4, but got I4
		//IL_0265: Invalid comparison between I4 and F4
		//IL_0277: Expected F4, but got I4
		//IL_028e: Invalid comparison between I4 and F4
		//IL_02a0: Expected F4, but got I4
		//IL_02b7: Invalid comparison between I4 and F4
		//IL_02c9: Expected F4, but got I4
		//IL_02e0: Invalid comparison between I4 and F4
		//IL_02f2: Expected F4, but got I4
		//IL_0309: Invalid comparison between I4 and F4
		//IL_031b: Expected F4, but got I4
		//IL_0332: Invalid comparison between I4 and F4
		//IL_0344: Expected F4, but got I4
		if (values != null)
		{
			CMYK cMYK = null;
			bool flag = !(1f > values.c);
			float num = 1f;
			if (!flag)
			{
				num = values.c;
			}
			bool flag2 = !(0f < num);
			float num2 = 0f;
			if (!flag2)
			{
				num2 = num;
			}
			cMYK.c = num2;
			bool flag3 = !(1f > values.m);
			float num3 = 1f;
			if (!flag3)
			{
				num3 = values.m;
			}
			bool flag4 = !(0f < num3);
			float num4 = 0f;
			if (!flag4)
			{
				num4 = num3;
			}
			cMYK.m = num4;
			bool flag5 = !(1f > values.y);
			float num5 = 1f;
			if (!flag5)
			{
				num5 = values.y;
			}
			bool flag6 = !(0f < num5);
			float num6 = 0f;
			if (!flag6)
			{
				num6 = num5;
			}
			cMYK.y = num6;
			bool flag7 = !(1f > values.k);
			float num7 = 1f;
			if (!flag7)
			{
				num7 = values.k;
			}
			bool flag8 = !(0f < num7);
			float num8 = 0f;
			if (!flag8)
			{
				num8 = num7;
			}
			float num9 = 1f - num8;
			cMYK.k = num8;
			float num10 = 1f - num8;
			float num11 = num9 * num4;
			float num12 = num10 * num6;
			float num13 = num11 + num8;
			float num14 = num12 + num8;
			CMY cMY = null;
			float num15 = 1f - num8;
			float num16 = num15 * num2;
			float num17 = num16 + num8;
			bool flag9 = !(1f > num17);
			float num18 = 1f;
			if (!flag9)
			{
				num18 = num17;
			}
			bool flag10 = !(0f < num18);
			float c = 0f;
			if (!flag10)
			{
				c = num18;
			}
			cMY.c = c;
			bool flag11 = !(1f > num13);
			float num19 = 1f;
			if (!flag11)
			{
				num19 = num13;
			}
			bool flag12 = !(0f < num19);
			float m = 0f;
			if (!flag12)
			{
				m = num19;
			}
			cMY.m = m;
			bool flag13 = !(1f > num14);
			float num20 = 1f;
			if (!flag13)
			{
				num20 = num14;
			}
			bool flag14 = !(0f < num20);
			float y = 0f;
			if (!flag14)
			{
				y = num20;
			}
			cMY.y = y;
			RGB rGB = CMYtoRGB(cMY);
			if (rGB != null)
			{
				bool flag15 = !(1f > rGB.r);
				float num21 = 1f;
				if (!flag15)
				{
					num21 = rGB.r;
				}
				bool flag16 = !(0f < num21);
				float r = 0f;
				if (!flag16)
				{
					r = num21;
				}
				rGB.r = r;
				bool flag17 = !(1f > rGB.g);
				float num22 = 1f;
				if (!flag17)
				{
					num22 = rGB.g;
				}
				bool flag18 = !(0f < num22);
				float g = 0f;
				if (!flag18)
				{
					g = num22;
				}
				rGB.g = g;
				bool flag19 = !(1f > rGB.b);
				float num23 = 1f;
				if (!flag19)
				{
					num23 = rGB.b;
				}
				bool flag20 = !(0f < num23);
				float b = 0f;
				if (!flag20)
				{
					b = num23;
				}
				rGB.b = b;
				return rGB;
			}
		}
		return (RGB)(object)new NullReferenceException();
	}

	public static CMYK RGBtoCMYK(RGB values)
	{
		//IL_0477: Invalid comparison between I4 and F4
		//IL_0497: Invalid comparison between I4 and F4
		//IL_004e: Expected F4, but got I4
		//IL_04b7: Invalid comparison between I4 and F4
		//IL_006a: Expected F4, but got I4
		//IL_0086: Expected F4, but got I4
		//IL_00c0: Expected F4, but got I4
		//IL_017c: Expected O, but got I4
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_0317: Expected F4, but got I4
		//IL_0530: Expected O, but got I4
		//IL_0538: Unknown result type (might be due to invalid IL or missing references)
		//IL_053d: Expected O, but got Unknown
		//IL_07e2: Expected O, but got I4
		//IL_07ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ef: Expected O, but got Unknown
		//IL_0609: Expected O, but got I4
		//IL_0611: Unknown result type (might be due to invalid IL or missing references)
		//IL_0616: Expected O, but got Unknown
		//IL_0325: Expected F4, but got I4
		//IL_020e: Expected O, but got I4
		//IL_021e: Expected O, but got I4
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected O, but got Unknown
		//IL_0295: Expected O, but got I4
		//IL_0846: Expected O, but got I4
		//IL_084e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0853: Expected O, but got Unknown
		//IL_0333: Expected F4, but got I4
		//IL_0651: Expected O, but got I4
		//IL_0659: Unknown result type (might be due to invalid IL or missing references)
		//IL_065e: Expected O, but got Unknown
		//IL_0341: Expected F4, but got I4
		//IL_088e: Expected O, but got I4
		//IL_0896: Unknown result type (might be due to invalid IL or missing references)
		//IL_089b: Expected O, but got Unknown
		//IL_069a: Invalid comparison between I4 and F4
		//IL_0554: Unknown result type (might be due to invalid IL or missing references)
		//IL_0559: Expected O, but got Unknown
		//IL_0563: Unknown result type (might be due to invalid IL or missing references)
		//IL_0568: Expected O, but got Unknown
		//IL_0572: Unknown result type (might be due to invalid IL or missing references)
		//IL_0577: Expected O, but got Unknown
		//IL_06ba: Invalid comparison between I4 and F4
		//IL_0405: Expected F4, but got I4
		//IL_06da: Invalid comparison between I4 and F4
		//IL_0421: Expected F4, but got I4
		//IL_06fa: Invalid comparison between I4 and F4
		//IL_0709: Expected F4, but got I4
		//IL_043d: Expected F4, but got I4
		CMY cMY = RGBtoCMY(values);
		float num = cMY.c;
		if (cMY.c > 1f)
		{
			num = 1f;
		}
		if (0f > num)
		{
			num = 0f;
		}
		float num2 = cMY.m;
		cMY.c = num;
		if (cMY.m > 1f)
		{
			num2 = 1f;
		}
		if (0f > num2)
		{
			num2 = 0f;
		}
		float num3 = cMY.y;
		cMY.m = num2;
		if (cMY.y > 1f)
		{
			num3 = 1f;
		}
		if (0f > num3)
		{
			num3 = 0f;
		}
		cMY.y = num3;
		float[] array = new float[4];
		bool flag;
		bool flag2;
		bool flag3;
		float num4;
		float num5;
		bool flag5;
		bool flag6;
		if (array.Length > 0)
		{
			array[0] = 1.0653532E+09f;
			if (array.Length > 1)
			{
				array[1] = cMY.c;
				if (array.Length > 2)
				{
					array[2] = cMY.m;
					if (array.Length > 3)
					{
						array[3] = cMY.y;
						object obj = array.Length ^ array.Length;
						object obj2 = array.Length & obj;
						flag = (nint)obj2 < 0;
						flag2 = array.Length < 0;
						flag3 = array.Length == 0;
						if (flag3)
						{
							num4 = 0f;
							goto IL_04dc;
						}
						if (array.Length > 0)
						{
							num4 = array[0];
							object obj3 = 1 - array.Length;
							object obj4 = 1 ^ array.Length;
							object obj5 = 1 ^ obj3;
							object obj6 = obj4 & obj5;
							flag = (nint)obj6 < 0;
							flag2 = (nint)obj3 < 0;
							flag3 = obj3 == null;
							bool flag4 = 1 >= array.Length;
							num5 = array[0];
							object obj7 = 1;
							flag5 = flag2;
							flag6 = flag;
							if (flag4)
							{
								goto IL_04dc;
							}
							while (flag5 != flag6)
							{
								if (num5 > array[obj7])
								{
									num5 = array[obj7];
								}
								obj7++;
								object obj8 = obj7 - array.Length;
								object obj9 = obj7 ^ array.Length;
								object obj10 = obj7 ^ obj8;
								object obj11 = obj9 & obj10;
								flag6 = (nint)obj11 < 0;
								flag5 = (nint)obj8 < 0;
								flag3 = obj8 == null;
								if ((nint)obj7 < array.Length)
								{
									continue;
								}
								goto IL_02f1;
							}
						}
					}
				}
			}
		}
		return (CMYK)(object)new IndexOutOfRangeException();
		IL_04dc:
		float num6 = cMY.y;
		float num7 = cMY.m;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm8\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm1\"");
		float num8 = cMY.c;
		bool flag7 = flag2 == flag;
		object obj12 = !flag7;
		object obj13 = obj12 | flag3;
		if (obj13 == null)
		{
			num8 = 0f;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm8\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm1\"");
		bool flag8 = flag2 == flag;
		object obj14 = !flag8;
		object obj15 = obj14 | flag3;
		if (obj15 == null)
		{
			num7 = 0f;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm8\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm1\"");
		bool flag9 = flag2 == flag;
		object obj16 = !flag9;
		object obj17 = obj16 | flag3;
		if (obj17 == null)
		{
			num6 = 0f;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm8\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm1\"");
		bool flag10 = flag2 == flag;
		object obj18 = !flag10;
		object obj19 = obj18 | flag3;
		if (obj19 == null)
		{
			float num9 = cMY.c - num4;
			float num10 = 1f - num4;
			num8 = num9 / num10;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm8\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm1\"");
		bool flag11 = flag2 == flag;
		object obj20 = !flag11;
		object obj21 = obj20 | flag3;
		if (obj21 == null)
		{
			float num11 = cMY.m - num4;
			float num12 = 1f - num4;
			num7 = num11 / num12;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm8\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm1\"");
		bool flag12 = flag2 == flag;
		object obj22 = !flag12;
		object obj23 = obj22 | flag3;
		if (obj23 == null)
		{
			float num13 = cMY.y - num4;
			float num14 = 1f - num4;
			num6 = num13 / num14;
		}
		CMYK cMYK = null;
		if (num8 > 1f)
		{
			num8 = 1f;
		}
		if (0f > num8)
		{
			num8 = 0f;
		}
		cMYK.c = num8;
		if (num7 > 1f)
		{
			num7 = 1f;
		}
		if (0f > num7)
		{
			num7 = 0f;
		}
		cMYK.m = num7;
		if (num6 > 1f)
		{
			num6 = 1f;
		}
		if (0f > num6)
		{
			num6 = 0f;
		}
		cMYK.y = num6;
		bool flag13 = num4 > 1f;
		float num15 = 1f;
		if (!flag13)
		{
			num15 = num4;
		}
		bool flag14 = 0f > num15;
		float k = 0f;
		if (!flag14)
		{
			k = num15;
		}
		cMYK.k = k;
		return cMYK;
		IL_02f1:
		num4 = num5;
		flag2 = flag5;
		flag = flag6;
		goto IL_04dc;
	}

	public static RGB XYZtoRGB(XYZ values)
	{
		//IL_01e3: Invalid comparison between I4 and F4
		//IL_01f5: Expected F4, but got I4
		//IL_020c: Invalid comparison between I4 and F4
		//IL_021e: Expected F4, but got I4
		//IL_0255: Invalid comparison between I4 and F4
		//IL_0267: Expected F4, but got I4
		//IL_02ec: Invalid comparison between I4 and F4
		//IL_02fe: Expected F4, but got I4
		//IL_0315: Invalid comparison between I4 and F4
		//IL_0327: Expected F4, but got I4
		//IL_033e: Invalid comparison between I4 and F4
		//IL_0350: Expected F4, but got I4
		if (values != null)
		{
			XYZ xYZ = null;
			bool flag = !(0.95047f > values.x);
			float num = 0.95047f;
			if (!flag)
			{
				num = values.x;
			}
			bool flag2 = !(0f < num);
			float num2 = 0f;
			if (!flag2)
			{
				num2 = num;
			}
			xYZ.x = num2;
			bool flag3 = !(1f > values.y);
			float num3 = 1f;
			if (!flag3)
			{
				num3 = values.y;
			}
			bool flag4 = !(0f < num3);
			float num4 = 0f;
			if (!flag4)
			{
				num4 = num3;
			}
			xYZ.y = num4;
			bool flag5 = !(1.08883f > values.z);
			float num5 = 1.08883f;
			if (!flag5)
			{
				num5 = values.z;
			}
			float num6 = num4 * 1.8758f;
			float num7 = num2 * 3.2406f;
			bool flag6 = !(0f < num5);
			float num8 = 0f;
			if (!flag6)
			{
				num8 = num5;
			}
			float num9 = num4 * -1.5372f;
			float num10 = num4 * -0.204f;
			xYZ.z = num8;
			float num11 = num8 * -0.4986f;
			float num12 = num7 + num9;
			float num13 = num2 * 0.0557f;
			float num14 = num2 * -0.9689f;
			float num15 = num12 + num11;
			float num16 = num8 * 0.0415f;
			float num17 = num13 + num10;
			float num18 = num8 * 1.057f;
			float num19 = num6 + num14;
			float num20 = num19 + num16;
			float num21 = num17 + num18;
			float num23;
			if (num15 > 0.0031308f)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B71D10");
				float num22 = num15 * 1.055f;
				num23 = num22 - 0.055f;
			}
			else
			{
				num23 = num15 * 12.92f;
			}
			float num25;
			if (num20 > 0.0031308f)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B71D10");
				float num24 = num20 * 1.055f;
				num25 = num24 - 0.055f;
			}
			else
			{
				num25 = num20 * 12.92f;
			}
			float num27;
			if (num21 > 0.0031308f)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B71D10");
				float num26 = num21 * 1.055f;
				num27 = num26 - 0.055f;
			}
			else
			{
				num27 = num21 * 12.92f;
			}
			RGB rGB = null;
			bool flag7 = !(1f > num23);
			float num28 = 1f;
			if (!flag7)
			{
				num28 = num23;
			}
			bool flag8 = !(0f < num28);
			float r = 0f;
			if (!flag8)
			{
				r = num28;
			}
			rGB.r = r;
			bool flag9 = !(1f > num25);
			float num29 = 1f;
			if (!flag9)
			{
				num29 = num25;
			}
			bool flag10 = !(0f < num29);
			float g = 0f;
			if (!flag10)
			{
				g = num29;
			}
			rGB.g = g;
			bool flag11 = !(1f > num27);
			float num30 = 1f;
			if (!flag11)
			{
				num30 = num27;
			}
			bool flag12 = !(0f < num30);
			float b = 0f;
			if (!flag12)
			{
				b = num30;
			}
			rGB.b = b;
			return rGB;
		}
		return (RGB)(object)new NullReferenceException();
	}

	public static XYZ RGBtoXYZ(RGB values)
	{
		//IL_0117: Invalid comparison between I4 and F4
		//IL_0129: Expected F4, but got I4
		//IL_0140: Invalid comparison between I4 and F4
		//IL_0152: Expected F4, but got I4
		//IL_0169: Invalid comparison between I4 and F4
		//IL_017b: Expected F4, but got I4
		//IL_0192: Invalid comparison between I4 and F4
		//IL_01a4: Expected F4, but got I4
		//IL_01bb: Invalid comparison between I4 and F4
		//IL_01cd: Expected F4, but got I4
		//IL_01e4: Invalid comparison between I4 and F4
		//IL_01f6: Expected F4, but got I4
		if (values != null)
		{
			RGB rGB = null;
			bool flag = !(1f > values.r);
			float num = 1f;
			if (!flag)
			{
				num = values.r;
			}
			bool flag2 = !(0f < num);
			float num2 = 0f;
			if (!flag2)
			{
				num2 = num;
			}
			rGB.r = num2;
			bool flag3 = !(1f > values.g);
			float num3 = 1f;
			if (!flag3)
			{
				num3 = values.g;
			}
			bool flag4 = !(0f < num3);
			float num4 = 0f;
			if (!flag4)
			{
				num4 = num3;
			}
			rGB.g = num4;
			bool flag5 = !(1f > values.b);
			float num5 = 1f;
			if (!flag5)
			{
				num5 = values.b;
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
}
