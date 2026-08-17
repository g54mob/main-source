using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.Objects.VFX.Shatter;

public class ShatterMaths
{
	public static bool pointIn2DTriangle(float x1, float y1, float x2, float y2, float x3, float y3, float xPos, float yPos)
	{
		//IL_013c: Invalid comparison between F4 and I4
		//IL_01aa: Invalid comparison between I4 and F4
		//IL_015c: Invalid comparison between F4 and I4
		//IL_01ca: Invalid comparison between I4 and F4
		//IL_017c: Invalid comparison between F4 and I4
		//IL_01ea: Invalid comparison between I4 and F4
		//IL_020a: Invalid comparison between I4 and F4
		//IL_0229: Invalid comparison between F4 and I4
		object obj = default(object);
		float num = y1 - (float)obj;
		float num2 = y2 - (float)obj;
		float num3 = y2 - (float)obj;
		object obj2 = default(object);
		float num4 = x1 - (float)obj2;
		float num5 = y1 - (float)obj;
		float num6 = x1 - (float)obj2;
		float num7 = x2 - (float)obj2;
		float num8 = x2 - (float)obj2;
		object obj4 = default(object);
		object obj3 = obj4 - obj2;
		object obj5 = obj4 - obj2;
		float num9 = num6 * num2;
		float num10 = num7 * num;
		float num11 = (float)obj5 * num3;
		object obj7 = default(object);
		object obj6 = obj7 - obj;
		float num12 = num5 * (float)obj3;
		object obj8 = obj7 - obj;
		float num13 = num9 - num10;
		float num14 = num8 * (float)obj6;
		float num15 = num4 * (float)obj8;
		float num16 = num14 - num11;
		float num17 = num12 - num15;
		if (num13 > 0f && num16 > 0f)
		{
			if (num17 > 0f)
			{
				return true;
			}
		}
		else if (!(0f > num13) || !(0f > num16))
		{
			goto IL_0257;
		}
		if (0f > num16)
		{
			bool flag = 0f < num17;
			float num18 = 0f - num17;
			bool flag2 = num18 == 0f;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			return flag4 & flag3;
		}
		goto IL_0257;
		IL_0257:
		return false;
	}

	public static bool isAngleReflex(Vector2 vector1, Vector2 vector2, Vector2 origin)
	{
		object obj = vector1 - origin;
		object obj3 = default(object);
		object obj4 = default(object);
		object obj2 = obj3 - obj4;
		object obj5 = vector2 - origin;
		object obj7 = default(object);
		object obj6 = obj7 - obj4;
		object obj8 = obj6 * obj;
		object obj9 = obj5 * obj2;
		object obj10 = obj8 - obj9;
		bool flag = (nint)obj10 < 0;
		bool flag2 = obj10 == null;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		return flag4 & flag3;
	}

	public static bool _2DLinesIntersect(float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4)
	{
		//IL_00d0: Invalid comparison between F4 and I4
		//IL_00f9: Expected O, but got I4
		//IL_00a5: Expected O, but got I8
		//IL_0136: Invalid comparison between F4 and I4
		//IL_015f: Expected O, but got I4
		//IL_010b: Expected O, but got I8
		//IL_019c: Invalid comparison between F4 and I4
		//IL_01c5: Expected O, but got I4
		//IL_08d4: Expected O, but got I8
		//IL_0171: Expected O, but got I8
		//IL_01f0: Invalid comparison between F4 and I4
		//IL_0219: Expected O, but got I4
		//IL_0327: Invalid comparison between F4 and O
		//IL_0440: Invalid comparison between F4 and O
		//IL_0362: Invalid comparison between O and F4
		//IL_0559: Invalid comparison between O and F4
		//IL_047b: Invalid comparison between O and F4
		//IL_039d: Invalid comparison between F4 and O
		//IL_0346: Invalid comparison between F4 and O
		//IL_067d: Invalid comparison between O and F4
		//IL_0594: Invalid comparison between F4 and O
		//IL_04b6: Invalid comparison between F4 and O
		//IL_045f: Invalid comparison between F4 and O
		//IL_03d8: Invalid comparison between O and F4
		//IL_0381: Invalid comparison between O and F4
		//IL_06b8: Invalid comparison between F4 and O
		//IL_05cf: Invalid comparison between O and F4
		//IL_0578: Invalid comparison between O and F4
		//IL_04f1: Invalid comparison between O and F4
		//IL_049a: Invalid comparison between O and F4
		//IL_03bc: Invalid comparison between F4 and O
		//IL_06f3: Invalid comparison between O and F4
		//IL_069c: Invalid comparison between O and F4
		//IL_060a: Invalid comparison between F4 and O
		//IL_05b3: Invalid comparison between F4 and O
		//IL_04d5: Invalid comparison between F4 and O
		//IL_03f7: Invalid comparison between O and F4
		//IL_072e: Invalid comparison between F4 and O
		//IL_06d7: Invalid comparison between F4 and O
		//IL_05ee: Invalid comparison between O and F4
		//IL_0510: Invalid comparison between O and F4
		//IL_0712: Invalid comparison between O and F4
		//IL_0629: Invalid comparison between F4 and O
		//IL_074d: Invalid comparison between F4 and O
		object obj2 = default(object);
		object obj3 = default(object);
		object obj = obj2 - obj3;
		object obj4 = default(object);
		float num = x1 - (float)obj4;
		object obj6 = default(object);
		object obj5 = obj6 - obj4;
		float num2 = num * (float)obj;
		float num3 = y1 - (float)obj3;
		float num4 = num3 * (float)obj5;
		object obj7;
		if (num4 > num2)
		{
			obj7 = 4294967295L;
		}
		else
		{
			bool flag = num2 < num4;
			float num5 = num2 - num4;
			bool flag2 = num5 == 0f;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			obj7 = flag4 & flag3;
		}
		object obj8 = obj2 - obj3;
		float num6 = x2 - (float)obj4;
		float num7 = y2 - (float)obj3;
		float num8 = num6 * (float)obj8;
		object obj9 = obj6 - obj4;
		float num9 = num7 * (float)obj9;
		object obj10;
		if (num9 > num8)
		{
			obj10 = 4294967295L;
		}
		else
		{
			bool flag5 = num8 < num9;
			float num10 = num8 - num9;
			bool flag6 = num10 == 0f;
			bool flag7 = !flag5;
			bool flag8 = !flag6;
			obj10 = flag8 & flag7;
		}
		float num11 = y2 - y1;
		float num12 = (float)obj4 - x1;
		float num13 = x2 - x1;
		float num14 = num12 * num11;
		float num15 = (float)obj3 - y1;
		float num16 = num13 * num15;
		object obj11;
		if (num16 > num14)
		{
			obj11 = 4294967295L;
		}
		else
		{
			bool flag9 = num14 < num16;
			float num17 = num14 - num16;
			bool flag10 = num17 == 0f;
			bool flag11 = !flag9;
			bool flag12 = !flag10;
			obj11 = flag12 & flag11;
		}
		float num18 = (float)obj6 - x1;
		float num19 = y2 - y1;
		float num20 = x2 - x1;
		float num21 = num19 * num18;
		float num22 = (float)obj2 - y1;
		float num23 = num20 * num22;
		bool flag13 = num23 > num21;
		object obj12 = 4294967295L;
		if (!flag13)
		{
			bool flag14 = num21 < num23;
			float num24 = num21 - num23;
			bool flag15 = num24 == 0f;
			bool flag16 = !flag14;
			bool flag17 = !flag15;
			obj12 = flag17 & flag16;
		}
		if ((((nint)obj7 <= 0 || 0 <= (nint)obj10) && (0 <= (nint)obj7 || (nint)obj10 <= 0)) || (((nint)obj11 <= 0 || 0 <= (nint)obj12) && (0 <= (nint)obj11 || (nint)obj12 <= 0)))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186EBDAD7h\"");
			if (obj7 != null || (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)x1) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) && System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)x1) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6)) || (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)x1) && System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)x1)) || (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)y1) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) && System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)y1) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2)) || (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)y1) && System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)y1)))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186EBDB0Bh\"");
				if (obj10 != null || (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)x2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) && System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)x2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6)) || (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)x2) && System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)x2)) || (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)y2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) && System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)y2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2)) || (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)y2) && System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)y2)))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186EBDB43h\"");
					if (obj11 != null || (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)x1) && System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)x2)) || (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)x1) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) && System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)x2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4)) || (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)y1) && System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)y2)) || (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)y1) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) && System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)y2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3)))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186EBDB79h\"");
						if (obj12 != null || (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)x1) && System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)x2)) || (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)x1) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6) && System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)x2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6)) || (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)y1) && System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)y2)))
						{
							return false;
						}
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)y1) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
						{
							bool flag18 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)y2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2);
							return !flag18;
						}
					}
				}
			}
		}
		return true;
	}

	private static bool isOnSegment(float xi, float yi, float xj, float yj, float xk, float yk)
	{
		//IL_0008: Invalid comparison between O and F4
		//IL_0043: Invalid comparison between F4 and O
		//IL_007e: Invalid comparison between O and F4
		//IL_0027: Invalid comparison between O and F4
		//IL_00c2: Invalid comparison between F4 and O
		//IL_0062: Invalid comparison between F4 and O
		//IL_00e4: Invalid comparison between F4 and O
		//IL_009d: Invalid comparison between O and F4
		object obj = default(object);
		object obj2 = default(object);
		if ((System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)xi) && System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)xj)) || (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)xi) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) && System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)xj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj)) || (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)yi) && System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)yj)))
		{
			return false;
		}
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)yi) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
		{
			return true;
		}
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)yj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2);
		return !flag;
	}

	private static int computeDirection(float xi, float yi, float xj, float yj, float xk, float yk)
	{
		//IL_00a9: Invalid comparison between F4 and I4
		//IL_0083: Expected I4, but got I8
		float num = xj - xi;
		object obj = default(object);
		float num2 = (float)obj - xi;
		object obj2 = default(object);
		float num3 = (float)obj2 - yi;
		float num4 = yj - yi;
		float num5 = num * num3;
		float num6 = num2 * num4;
		if (num5 > num6)
		{
			return -1;
		}
		bool flag = num6 < num5;
		float num7 = num6 - num5;
		bool flag2 = num7 == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		return (flag4 & flag3) ? 1 : 0;
	}

	public static Vector2 _2DLineIntersectionPoint(float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4)
	{
		//IL_0078: Invalid comparison between F4 and I4
		float num = x2 - x1;
		float num2 = y2 - y1;
		object obj2 = default(object);
		object obj3 = default(object);
		object obj = obj2 - obj3;
		float num3 = num * (float)obj;
		object obj5 = default(object);
		object obj6 = default(object);
		object obj4 = obj5 - obj6;
		float num4 = num2 * (float)obj4;
		float num5 = num3 - num4;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186EBDCC1h\"");
		Vector2 result = default(Vector2);
		if (num5 == 0f)
		{
			return result;
		}
		return result;
	}

	public static Vector2 rotateVector(Vector2 input, float angle)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj = angle ^ 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj2 = angle ^ 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		Vector2 result = default(Vector2);
		return result;
	}
}
