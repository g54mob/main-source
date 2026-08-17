using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;

public class MathUtils
{
	public const float CONST_EPSILON = 1E-06f;

	public const float Rad2Deg = 57.29578f;

	public const float Deg2Rad = (float)Math.PI / 180f;

	[MethodImpl((MethodImplOptions)256)]
	public static float Clamp(float v, float min, float max)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		float num = default(float);
		object obj = num & -2147483649L;
		if ((nint)obj > 2139095040 || num > max)
		{
			num = max;
		}
		object obj2 = num & -2147483649L;
		if ((nint)obj2 > 2139095040 || min > num)
		{
			num = min;
		}
		return num;
	}

	[MethodImpl((MethodImplOptions)256)]
	public static float DistanceBetweenSqrd(float x1, float y1, float x2, float y2)
	{
		float num = y2 - y1;
		float num2 = x2 - x1;
		float num3 = num * num;
		float num4 = num2 * num2;
		return num3 + num4;
	}

	[MethodImpl((MethodImplOptions)256)]
	public static float DistanceBetween(float x1, float y1, float x2, float y2)
	{
		float num = y2 - y1;
		float num2 = x2 - x1;
		float num3 = num * num;
		float num4 = num2 * num2;
		float result = num3 + num4;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850045F0");
		return result;
	}

	[MethodImpl((MethodImplOptions)256)]
	public static float AngleBetweenPoints(float2 p1, float2 p2)
	{
		object obj = p2 - p1;
		object obj2 = default(object);
		object obj3 = default(object);
		float result = (float)obj2 - (float)obj3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003DD0");
		return result;
	}

	[MethodImpl((MethodImplOptions)256)]
	public static bool FuzzyEqual(float value, float target, float range = 0.0001f)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0029: Invalid comparison between F4 and O
		float num = value - target;
		object obj = num & -2147483649L;
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)range) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
		return !flag;
	}

	[MethodImpl((MethodImplOptions)256)]
	public static bool FuzzyGreaterThan(float value, float target, float range = 0.0001f)
	{
		//IL_0035: Invalid comparison between F4 and I4
		float num = target - range;
		bool flag = value < num;
		float num2 = value - num;
		bool flag2 = num2 == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		return flag4 & flag3;
	}

	[MethodImpl((MethodImplOptions)256)]
	public static bool FuzzyLessThan(float value, float target, float range = 0.0001f)
	{
		//IL_0035: Invalid comparison between F4 and I4
		float num = target + range;
		bool flag = num < value;
		float num2 = num - value;
		bool flag2 = num2 == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		return flag4 & flag3;
	}

	[MethodImpl((MethodImplOptions)256)]
	public static float Min(float a, float b, float c, float d)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		float num = default(float);
		object obj = num & -2147483649L;
		float num2 = default(float);
		if ((nint)obj > 2139095040 || !(num > a))
		{
			object obj2 = num2 & -2147483649L;
			if ((nint)obj2 > 2139095040)
			{
				goto IL_00b8;
			}
		}
		if (num2 > c)
		{
			goto IL_0063;
		}
		goto IL_00b8;
		IL_0084:
		return a;
		IL_0063:
		if (!(c > a))
		{
			return c;
		}
		goto IL_0084;
		IL_00b8:
		object obj3 = c & -2147483649L;
		if ((nint)obj3 <= 2139095040)
		{
			goto IL_0063;
		}
		goto IL_0084;
	}

	[MethodImpl((MethodImplOptions)256)]
	public static float Max(float a, float b, float c, float d)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		float num = default(float);
		object obj = num & -2147483649L;
		float num2 = default(float);
		if ((nint)obj > 2139095040 || !(a > num))
		{
			object obj2 = num2 & -2147483649L;
			if ((nint)obj2 > 2139095040)
			{
				goto IL_00b8;
			}
		}
		if (c > num2)
		{
			goto IL_0063;
		}
		goto IL_00b8;
		IL_0084:
		return a;
		IL_0063:
		if (!(a > c))
		{
			return c;
		}
		goto IL_0084;
		IL_00b8:
		object obj3 = c & -2147483649L;
		if ((nint)obj3 <= 2139095040)
		{
			goto IL_0063;
		}
		goto IL_0084;
	}

	[MethodImpl((MethodImplOptions)256)]
	public static int CeilToIntClamped(float v, int minValue = -2147483648, int maxValue = 2147483647)
	{
		//IL_0012: Invalid comparison between F4 and I4
		//IL_0031: Invalid comparison between I4 and F4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003E40");
		if (v < (float)maxValue)
		{
			if ((float)minValue < v)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
				int result = default(int);
				return result;
			}
			return minValue;
		}
		return maxValue;
	}

	[MethodImpl((MethodImplOptions)256)]
	public static int FloorToIntClamped(float v, int minValue = -2147483648, int maxValue = 2147483647)
	{
		//IL_0012: Invalid comparison between F4 and I4
		//IL_0031: Invalid comparison between I4 and F4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003EA0");
		if (v < (float)maxValue)
		{
			if ((float)minValue < v)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
				int result = default(int);
				return result;
			}
			return minValue;
		}
		return maxValue;
	}

	[MethodImpl((MethodImplOptions)256)]
	public static int RoundToIntClamped(float v, int minValue = -2147483648, int maxValue = 2147483647)
	{
		//IL_0012: Invalid comparison between F4 and I4
		//IL_0031: Invalid comparison between I4 and F4
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003890");
		if (v < (float)maxValue)
		{
			if ((float)minValue < v)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
				int result = default(int);
				return result;
			}
			return minValue;
		}
		return maxValue;
	}

	[MethodImpl((MethodImplOptions)256)]
	public static float SubtractValueCapped(float baseValue, float valueToSubtract)
	{
		//IL_0009: Invalid comparison between I4 and F4
		//IL_00bc: Expected F4, but got I4
		//IL_017c: Invalid comparison between I4 and F4
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_0160: Expected F4, but got I4
		//IL_01a8: Invalid comparison between I4 and F4
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Expected O, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_016e: Expected F4, but got I4
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		float num = default(float);
		if (!(0f > num))
		{
			object obj = num & -2147483649L;
			if ((nint)obj != 2139095040)
			{
				object obj2 = num & -2147483649L;
				if ((nint)obj2 <= 2139095040)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000184FF3485h\"");
					if (num != -1f / 0f)
					{
						goto IL_0173;
					}
				}
			}
			num = 3.4028235E+38f;
		}
		else
		{
			num = 0f;
		}
		goto IL_0173;
		IL_0190:
		float num3 = default(float);
		float num2 = num - num3;
		if (0f > num2)
		{
			num2 = 0f;
		}
		return num2;
		IL_0173:
		if (!(0f > num3))
		{
			object obj3 = num3 & -2147483649L;
			if ((nint)obj3 != 2139095040)
			{
				object obj4 = num3 & -2147483649L;
				if ((nint)obj4 <= 2139095040)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000184FF34B7h\"");
					if (num3 != -1f / 0f)
					{
						goto IL_0190;
					}
				}
			}
			num3 = 3.4028235E+38f;
		}
		else
		{
			num3 = 0f;
		}
		goto IL_0190;
	}

	[MethodImpl((MethodImplOptions)256)]
	public static float AddValueCapped(float baseValue, float valueToAdd)
	{
		//IL_0018: Invalid comparison between I4 and F4
		//IL_00c3: Expected F4, but got I4
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		float num = baseValue + valueToAdd;
		if (!(0f > num))
		{
			object obj = num & -2147483649L;
			if ((nint)obj != 2139095040)
			{
				object obj2 = num & -2147483649L;
				if ((nint)obj2 <= 2139095040)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018304DC81h\"");
					if (num != -1f / 0f)
					{
						goto IL_00c8;
					}
				}
			}
			return 3.4028235E+38f;
		}
		num = 0f;
		goto IL_00c8;
		IL_00c8:
		return num;
	}

	[MethodImpl((MethodImplOptions)256)]
	public static float FixFloatOverflowPositive(float value)
	{
		//IL_0009: Invalid comparison between I4 and F4
		//IL_00b1: Expected F4, but got I4
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		float num = default(float);
		if (!(0f > num))
		{
			object obj = num & -2147483649L;
			if ((nint)obj != 2139095040)
			{
				object obj2 = num & -2147483649L;
				if ((nint)obj2 <= 2139095040)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000184FF350Dh\"");
					if (num != -1f / 0f)
					{
						goto IL_00ab;
					}
				}
			}
			return 3.4028235E+38f;
		}
		goto IL_00ab;
		IL_00ab:
		return 0f;
	}

	[MethodImpl((MethodImplOptions)256)]
	public static float TryFixNegativeFloat(float value)
	{
		//IL_0009: Invalid comparison between F4 and I4
		//IL_0039: Invalid comparison between I4 and F4
		//IL_00e4: Expected F4, but got I4
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected O, but got Unknown
		float num = default(float);
		if (num < 0f)
		{
			num *= -1f;
			if (!(0f > num))
			{
				object obj = num & -2147483649L;
				if ((nint)obj != 2139095040)
				{
					object obj2 = num & -2147483649L;
					if ((nint)obj2 <= 2139095040)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000184FF355Ah\"");
						if (num != -1f / 0f)
						{
							goto IL_00e9;
						}
					}
				}
				return 3.4028235E+38f;
			}
			num = 0f;
		}
		goto IL_00e9;
		IL_00e9:
		return num;
	}

	[MethodImpl((MethodImplOptions)256)]
	public static int Pow(int num, int exp)
	{
		//IL_006f: Expected O, but got I4
		int num2 = default(int);
		bool flag = num2 <= 0;
		int result = 1;
		int num3 = 1;
		if (!flag)
		{
			int num5 = default(int);
			object obj;
			do
			{
				int num4 = num2 & 1;
				bool flag2 = num4 == 0;
				if (!flag2)
				{
					num3 *= num5;
				}
				num5 *= num5;
				num2 >>= 1;
				obj = !flag2;
				result = num3;
			}
			while (obj != null);
		}
		return result;
	}

	[MethodImpl((MethodImplOptions)256)]
	public static int DivideRoundingUp(int a, int b)
	{
		//IL_000e: Expected O, but got I4
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected I4, but got Unknown
		object obj = b - 1;
		object obj2 = obj + a;
		return obj2 / b;
	}

	public static bool LineToLineIntersection(float2 startA, float2 endA, float2 startB, float2 endB, out float2 intersection)
	{
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Expected O, but got Unknown
		//IL_0191: Invalid comparison between F4 and O
		//IL_01cb: Invalid comparison between F4 and O
		object obj = endA - startA;
		object obj2 = endB - startB;
		object obj3 = startA - startB;
		object obj5 = default(object);
		object obj6 = default(object);
		object obj4 = obj5 - obj6;
		object obj8 = default(object);
		object obj9 = default(object);
		object obj7 = obj8 - obj9;
		object obj10 = obj9 - obj6;
		object obj11 = obj2 ^ -0f;
		object obj12 = obj11 * obj7;
		object obj13 = obj7 ^ -0f;
		object obj14 = obj10 * obj;
		object obj15 = obj3 * obj13;
		object obj16 = obj4 * obj;
		object obj17 = obj15 + obj14;
		object obj18 = obj9 - obj6;
		object obj19 = obj12 + obj16;
		object obj20 = startA - startB;
		object obj21 = obj18 * obj2;
		object obj22 = obj2 ^ -0f;
		object obj23 = obj17 / obj19;
		object obj24 = obj20 * obj4;
		object obj25 = obj22 * obj7;
		object obj26 = obj21 - obj24;
		object obj27 = obj4 * obj;
		object obj28 = obj25 + obj27;
		object obj29 = obj26 / obj28;
		object obj30;
		if ((nint)obj23 >= 0)
		{
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj23) && (nint)obj29 >= 0)
			{
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj29))
				{
					obj30 = obj8;
					return true;
				}
			}
		}
		obj30 = endA;
		return false;
	}

	public static float2 RotateFloat2(float2 vector, float angleDegrees)
	{
		float num = angleDegrees * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
		float2 result = default(float2);
		return result;
	}

	public static int WrapInsideRange(int value, int range)
	{
		int num = value % range;
		int num2 = num + range;
		if (num < 0)
		{
			num = num2;
		}
		return num;
	}

	public static float2 RandomPointInAnnulus(float2 origin, float minRadius, float maxRadius)
	{
		UnityEngine.Random.GetRandomUnitCircle(out Vector2 _);
		object obj2 = default(object);
		object obj3 = default(object);
		object obj = obj2 * obj3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C244F0");
		float num = UnityEngine.Random.Range(minRadius, maxRadius);
		float2 result = default(float2);
		return result;
	}

	public static bool IsInsideCircle(float x, float y, float radius, float pointX, float pointY)
	{
		//IL_0080: Invalid comparison between F4 and I4
		float num = pointX - x;
		object obj = default(object);
		float num2 = (float)obj - y;
		float num3 = radius * radius;
		float num4 = num * num;
		float num5 = num2 * num2;
		float num6 = num5 + num4;
		bool flag = num3 < num6;
		float num7 = num3 - num6;
		bool flag2 = num7 == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		return flag4 & flag3;
	}

	public static float GetOverlapX(BaseBody body1, BaseBody body2, bool overlapOnly, float bias)
	{
		//IL_0053: Invalid comparison between F4 and I4
		//IL_0082: Invalid comparison between F4 and I4
		//IL_034d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0352: Expected O, but got Unknown
		//IL_038a: Expected O, but got I4
		//IL_0392: Unknown result type (might be due to invalid IL or missing references)
		//IL_0397: Expected O, but got Unknown
		//IL_010d: Expected F4, but got I4
		//IL_0491: Expected F4, but got I4
		//IL_00be: Expected F4, but got I4
		//IL_03b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b8: Expected O, but got Unknown
		//IL_03f0: Expected O, but got I4
		//IL_03f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fd: Expected O, but got Unknown
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		//IL_0163: Invalid comparison between O and F4
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Expected O, but got Unknown
		//IL_01de: Expected O, but got I4
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Expected O, but got Unknown
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Expected O, but got Unknown
		//IL_0244: Expected O, but got I4
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Expected O, but got Unknown
		//IL_044c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0451: Expected O, but got Unknown
		//IL_0471: Unknown result type (might be due to invalid IL or missing references)
		//IL_0476: Expected O, but got Unknown
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a5: Expected O, but got Unknown
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Expected O, but got Unknown
		float num = body1.deltaAbsX();
		float num2 = body2.deltaAbsX();
		object obj2 = default(object);
		object obj = obj2 + obj2;
		float num3 = (float)obj + bias;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000184FF39A6h\"");
		float num4;
		if (body1._dx == 0f)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000184FF39A6h\"");
			if (body2._dx == 0f)
			{
				body1._embedded = true;
				body2._embedded = true;
				num4 = 0f;
				goto IL_0496;
			}
		}
		if (!(body1._dx > body2._dx))
		{
			bool flag = !(body2._dx > body1._dx);
			num4 = 0f;
			if (flag)
			{
				goto IL_0496;
			}
			object obj3 = body1._position - body2._size;
			num4 = (float)obj3 - (float)body2._position;
			float num5 = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			object obj4 = num5 ^ 0;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num3) || overlapOnly)
			{
				object obj5 = body1._checkCollision & 4;
				bool flag2 = obj5 == null;
				bool flag3 = (nint)obj5 < 0;
				bool flag4 = !flag3;
				object obj6 = !flag4;
				object obj7 = obj6 | flag2;
				if (obj7 == null)
				{
					object obj8 = body2._checkCollision & 8;
					bool flag5 = obj8 == null;
					bool flag6 = (nint)obj8 < 0;
					bool flag7 = !flag6;
					object obj9 = !flag7;
					object obj10 = obj9 | flag5;
					if (obj10 == null)
					{
						if (!overlapOnly)
						{
							if (body2._physicsType == PhysicsType.STATIC_BODY)
							{
								ArcadeBodyCollision blocked = (ArcadeBodyCollision)(body1._blocked | 4);
								body1._blocked = blocked;
							}
							if (body1._physicsType == PhysicsType.STATIC_BODY)
							{
								ArcadeBodyCollision blocked2 = (ArcadeBodyCollision)(body2._blocked | 8);
								body2._blocked = blocked2;
							}
						}
						goto IL_0496;
					}
				}
			}
		}
		else
		{
			object obj11 = body1._size + body1._position;
			num4 = (float)obj11 - (float)body2._position;
			if (!(num4 > num3) || overlapOnly)
			{
				object obj12 = body1._checkCollision & 8;
				bool flag8 = obj12 == null;
				bool flag9 = (nint)obj12 < 0;
				bool flag10 = !flag9;
				object obj13 = !flag10;
				object obj14 = obj13 | flag8;
				if (obj14 == null)
				{
					object obj15 = body2._checkCollision & 4;
					bool flag11 = obj15 == null;
					bool flag12 = (nint)obj15 < 0;
					bool flag13 = !flag12;
					object obj16 = !flag13;
					object obj17 = obj16 | flag11;
					if (obj17 == null)
					{
						if (!overlapOnly)
						{
							if (body2._physicsType == PhysicsType.STATIC_BODY)
							{
								ArcadeBodyCollision blocked3 = (ArcadeBodyCollision)(body1._blocked | 8);
								body1._blocked = blocked3;
							}
							if (body1._physicsType == PhysicsType.STATIC_BODY)
							{
								ArcadeBodyCollision blocked4 = (ArcadeBodyCollision)(body2._blocked | 4);
								body2._blocked = blocked4;
							}
						}
						goto IL_0496;
					}
				}
			}
		}
		num4 = 0f;
		goto IL_0496;
		IL_0496:
		return num4;
	}

	public static float GetOverlapY(BaseBody body1, BaseBody body2, bool overlapOnly, float bias)
	{
		//IL_0053: Invalid comparison between F4 and I4
		//IL_0302: Expected O, but got I
		//IL_0082: Invalid comparison between F4 and I4
		//IL_035f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0364: Expected O, but got Unknown
		//IL_039c: Expected O, but got I4
		//IL_03a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a9: Expected O, but got Unknown
		//IL_010d: Expected F4, but got I4
		//IL_04a3: Expected F4, but got I4
		//IL_00be: Expected F4, but got I4
		//IL_03c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ca: Expected O, but got Unknown
		//IL_0402: Expected O, but got I4
		//IL_040a: Unknown result type (might be due to invalid IL or missing references)
		//IL_040f: Expected O, but got Unknown
		//IL_0138: Expected O, but got I
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		//IL_016c: Invalid comparison between O and F4
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Expected O, but got Unknown
		//IL_01e7: Expected O, but got I4
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Expected O, but got Unknown
		//IL_024d: Expected O, but got I4
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Expected O, but got Unknown
		//IL_045e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0463: Expected O, but got Unknown
		//IL_0483: Unknown result type (might be due to invalid IL or missing references)
		//IL_0488: Expected O, but got Unknown
		//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ae: Expected O, but got Unknown
		//IL_02ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d3: Expected O, but got Unknown
		float num = body1.deltaAbsY();
		float num2 = body2.deltaAbsY();
		object obj2 = default(object);
		object obj = obj2 + obj2;
		float num3 = (float)obj + bias;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000184FF3B76h\"");
		float num4;
		if (body1._dy == 0f)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000184FF3B76h\"");
			if (body2._dy == 0f)
			{
				body1._embedded = true;
				body2._embedded = true;
				num4 = 0f;
				goto IL_04a8;
			}
		}
		if (!(body1._dy > body2._dy))
		{
			bool flag = !(body2._dy > body1._dy);
			num4 = 0f;
			if (flag)
			{
				goto IL_04a8;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body2 @ rdx (BaseBody)+5C]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body2 @ rdx (BaseBody)+54]");
			object obj3 = num5 + 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body1 @ rcx (BaseBody)+54]");
			num4 = 0f - (float)obj3;
			float num6 = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			object obj4 = num6 ^ 0;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num3) || overlapOnly)
			{
				object obj5 = body1._checkCollision & 1;
				bool flag2 = obj5 == null;
				bool flag3 = (nint)obj5 < 0;
				bool flag4 = !flag3;
				object obj6 = !flag4;
				object obj7 = obj6 | flag2;
				if (obj7 == null)
				{
					object obj8 = body2._checkCollision & 2;
					bool flag5 = obj8 == null;
					bool flag6 = (nint)obj8 < 0;
					bool flag7 = !flag6;
					object obj9 = !flag7;
					object obj10 = obj9 | flag5;
					if (obj10 == null)
					{
						if (!overlapOnly)
						{
							if (body2._physicsType == PhysicsType.STATIC_BODY)
							{
								ArcadeBodyCollision blocked = (ArcadeBodyCollision)(body1._blocked | 1);
								body1._blocked = blocked;
							}
							if (body1._physicsType == PhysicsType.STATIC_BODY)
							{
								ArcadeBodyCollision blocked2 = (ArcadeBodyCollision)(body2._blocked | 2);
								body2._blocked = blocked2;
							}
						}
						goto IL_04a8;
					}
				}
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body1 @ rcx (BaseBody)+5C]");
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body1 @ rcx (BaseBody)+54]");
			object obj11 = num7 + 0;
			float num8 = (float)obj11;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body2 @ rdx (BaseBody)+54]");
			num4 = num8 - 0f;
			if (!(num4 > num3) || overlapOnly)
			{
				object obj12 = body1._checkCollision & 2;
				bool flag8 = obj12 == null;
				bool flag9 = (nint)obj12 < 0;
				bool flag10 = !flag9;
				object obj13 = !flag10;
				object obj14 = obj13 | flag8;
				if (obj14 == null)
				{
					object obj15 = body2._checkCollision & 1;
					bool flag11 = obj15 == null;
					bool flag12 = (nint)obj15 < 0;
					bool flag13 = !flag12;
					object obj16 = !flag13;
					object obj17 = obj16 | flag11;
					if (obj17 == null)
					{
						if (!overlapOnly)
						{
							if (body2._physicsType == PhysicsType.STATIC_BODY)
							{
								ArcadeBodyCollision blocked3 = (ArcadeBodyCollision)(body1._blocked | 2);
								body1._blocked = blocked3;
							}
							if (body1._physicsType == PhysicsType.STATIC_BODY)
							{
								ArcadeBodyCollision blocked4 = (ArcadeBodyCollision)(body2._blocked | 1);
								body2._blocked = blocked4;
							}
						}
						goto IL_04a8;
					}
				}
			}
		}
		num4 = 0f;
		goto IL_04a8;
		IL_04a8:
		return num4;
	}

	public static bool SeparateX(BaseBody body1, BaseBody body2, bool overlapOnly, float bias)
	{
		//IL_01eb: Expected I4, but got O
		//IL_0181: Invalid comparison between F4 and I4
		//IL_006a: Invalid comparison between F4 and I4
		//IL_009f: Expected O, but got I4
		//IL_00b9: Expected O, but got I4
		float overlapX = GetOverlapX(body1, body2, overlapOnly, bias);
		if (body1 != null && body2 != null)
		{
			if (!overlapOnly)
			{
				bool flag = overlapX == 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000184FF3CE4h\"");
				if (flag)
				{
					goto IL_0198;
				}
				object obj = body1._immovable & body2._immovable;
				bool flag2 = obj == null;
				object obj2 = !flag2;
				if (obj2 == null)
				{
					int num = ProcessX.Set(body1, body2, overlapX);
					if (!body1._immovable)
					{
						if (~(body2._immovable ? 1u : 0u) == 0)
						{
							ProcessX.RunImmovableBody2(num);
							return true;
						}
						if (num <= 0)
						{
							return ProcessX.Check();
						}
					}
					else
					{
						ProcessX.RunImmovableBody1(num);
					}
					goto IL_0160;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000184FF3D41h\"");
			if (overlapX != 0f)
			{
				goto IL_0160;
			}
			goto IL_0198;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0198:
		if (!body1._embedded)
		{
			return false;
		}
		return body2._embedded;
		IL_0160:
		return true;
	}

	public static bool SeparateY(BaseBody body1, BaseBody body2, bool overlapOnly, float bias)
	{
		//IL_01eb: Expected I4, but got O
		//IL_0181: Invalid comparison between F4 and I4
		//IL_006a: Invalid comparison between F4 and I4
		//IL_009f: Expected O, but got I4
		//IL_00b9: Expected O, but got I4
		float overlapY = GetOverlapY(body1, body2, overlapOnly, bias);
		if (body1 != null && body2 != null)
		{
			if (!overlapOnly)
			{
				bool flag = overlapY == 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000184FF3DC4h\"");
				if (flag)
				{
					goto IL_0198;
				}
				object obj = body1._immovable & body2._immovable;
				bool flag2 = obj == null;
				object obj2 = !flag2;
				if (obj2 == null)
				{
					int num = ProcessY.Set(body1, body2, overlapY);
					if (!body1._immovable)
					{
						if (~(body2._immovable ? 1u : 0u) == 0)
						{
							ProcessY.RunImmovableBody2(num);
							return true;
						}
						if (num <= 0)
						{
							return ProcessY.Check();
						}
					}
					else
					{
						ProcessY.RunImmovableBody1(num);
					}
					goto IL_0160;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000184FF3E21h\"");
			if (overlapY != 0f)
			{
				goto IL_0160;
			}
			goto IL_0198;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0198:
		if (!body1._embedded)
		{
			return false;
		}
		return body2._embedded;
		IL_0160:
		return true;
	}

	public static float TileCheckX(Body body, PhaserTile tile, float tileLeft, float tileRight, float tileBias, bool isLayer)
	{
		//IL_009f: Invalid comparison between I4 and F4
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		//IL_00ea: Expected O, but got I4
		//IL_021c: Invalid comparison between F4 and I4
		//IL_0230: Invalid comparison between F4 and I4
		//IL_0259: Expected O, but got I4
		//IL_0271: Expected F4, but got I4
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected O, but got Unknown
		//IL_0152: Expected O, but got I4
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Expected O, but got Unknown
		//IL_02ca: Expected O, but got I4
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d7: Expected O, but got Unknown
		//IL_02e0: Expected F4, but got I4
		//IL_0185: Expected F4, but got I4
		//IL_0306: Expected F4, but got I4
		//IL_01a0: Invalid comparison between F4 and O
		//IL_01b2: Expected F4, but got I4
		//IL_0333: Invalid comparison between O and F4
		//IL_0345: Expected F4, but got I4
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Expected O, but got Unknown
		//IL_01f1: Invalid comparison between O and F4
		//IL_0381: Invalid comparison between F4 and O
		//IL_03a7: Invalid comparison between F4 and I4
		//IL_020e: Expected F4, but got I4
		//IL_039e: Expected F4, but got I4
		//IL_03ce: Invalid comparison between I4 and F4
		//IL_0447: Unknown result type (might be due to invalid IL or missing references)
		//IL_044c: Expected O, but got Unknown
		//IL_04ed: Expected O, but got F4
		//IL_03eb: Invalid comparison between F4 and I4
		//IL_048f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0494: Expected O, but got Unknown
		//IL_0475: Expected O, but got I4
		//IL_0419: Unknown result type (might be due to invalid IL or missing references)
		//IL_041e: Expected O, but got Unknown
		int num = tile._data & 4;
		bool flag = num == 0;
		bool flag2 = !flag;
		int num2 = tile._data & 8;
		bool flag3 = num2 == 0;
		bool flag4 = !flag3;
		object obj = default(object);
		if (obj == null)
		{
			flag4 = true;
			flag2 = true;
		}
		bool flag5 = 0f < body._dx;
		object obj2 = 0 - body._dx;
		bool flag6 = obj2 == null;
		bool flag7 = !flag5;
		bool flag8 = !flag6;
		object obj3 = flag8 & flag7;
		float num3;
		object obj8 = default(object);
		if (obj3 != null)
		{
			object obj4 = body._checkCollision & 4;
			bool flag9 = obj4 == null;
			bool flag10 = (nint)obj4 < 0;
			bool flag11 = !flag10;
			object obj5 = !flag11;
			object obj6 = obj5 | flag9;
			if (obj6 == null)
			{
				bool flag12 = !flag4;
				num3 = 0f;
				if (!flag12)
				{
					float2 position = body._position;
					bool flag13 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)tileRight) <= System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref position);
					num3 = 0f;
					if (!flag13)
					{
						num3 = (float)body._position - tileRight;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
						object obj7 = obj8 ^ 0;
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num3))
						{
							return 0f;
						}
						goto IL_039e;
					}
				}
				goto IL_04b8;
			}
		}
		bool flag14 = body._dx < 0f;
		bool flag15 = body._dx == 0f;
		bool flag16 = !flag14;
		bool flag17 = !flag15;
		object obj9 = flag17 & flag16;
		bool flag18 = obj9 == null;
		num3 = 0f;
		if (!flag18)
		{
			object obj10 = body._checkCollision & 8;
			bool flag19 = obj10 == null;
			bool flag20 = (nint)obj10 < 0;
			bool flag21 = !flag20;
			object obj11 = !flag21;
			object obj12 = obj11 | flag19;
			num3 = 0f;
			if (obj12 == null)
			{
				bool flag22 = !flag2;
				num3 = 0f;
				if (!flag22)
				{
					object obj13 = body._size + body._position;
					bool flag23 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj13) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)tileLeft);
					num3 = 0f;
					if (!flag23)
					{
						object obj14 = body._size + body._position;
						num3 = (float)obj14 - tileLeft;
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num3) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8))
						{
							return 0f;
						}
						goto IL_039e;
					}
				}
			}
		}
		goto IL_04b8;
		IL_04b8:
		return num3;
		IL_039e:
		bool flag24 = num3 == 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000184FF3F42h\"");
		if (!flag24)
		{
			float num4;
			if (!(0f > num3))
			{
				bool flag25 = !(num3 > 0f);
				num4 = 8E-06f;
				if (!flag25)
				{
					ArcadeBodyCollision blocked = (ArcadeBodyCollision)(body._blocked | 8);
					body._blocked = blocked;
					num4 = 8E-06f;
				}
			}
			else
			{
				ArcadeBodyCollision blocked2 = (ArcadeBodyCollision)(body._blocked | 4);
				body._blocked = blocked2;
				num4 = -8E-06f;
			}
			float num5 = num4 + num3;
			float num6 = (float)body._position - num5;
			body._position = (float2)num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000184FF3F9Ch\"");
			if ((object)body._bounce == null)
			{
				body._velocity = (float2)0;
				return num3;
			}
			float2 velocity = body._velocity;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			object obj15 = velocity ^ 0;
			float2 velocity2 = obj15 * (object)body._bounce;
			body._velocity = velocity2;
		}
		goto IL_04b8;
	}

	private static void ProcessTileSeparationX(Body body, float x)
	{
		//IL_0009: Invalid comparison between I4 and F4
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected O, but got Unknown
		//IL_0120: Expected O, but got F4
		//IL_0026: Invalid comparison between F4 and I4
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected O, but got Unknown
		//IL_00b5: Expected O, but got I4
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		float num;
		if (!(0f > x))
		{
			if (x > 0f)
			{
				ArcadeBodyCollision blocked = (ArcadeBodyCollision)(body._blocked | 8);
				body._blocked = blocked;
				num = 8E-06f;
			}
			else
			{
				num = 8E-06f;
			}
		}
		else
		{
			ArcadeBodyCollision blocked2 = (ArcadeBodyCollision)(body._blocked | 4);
			body._blocked = blocked2;
			num = -8E-06f;
		}
		float num2 = num + x;
		float num3 = (float)body._position - num2;
		body._position = (float2)num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000184FF403Fh\"");
		if ((object)body._bounce == null)
		{
			body._velocity = (float2)0;
			return;
		}
		float2 velocity = body._velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj = velocity ^ 0;
		float2 velocity2 = obj * (object)body._bounce;
		body._velocity = velocity2;
	}

	public static float TileCheckY(Body body, PhaserTile tile, float tileTop, float tileBottom, float tileBias, bool isLayer)
	{
		//IL_009f: Invalid comparison between I4 and F4
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		//IL_00ea: Expected O, but got I4
		//IL_0222: Invalid comparison between F4 and I4
		//IL_0236: Invalid comparison between F4 and I4
		//IL_025f: Expected O, but got I4
		//IL_0277: Expected F4, but got I4
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected O, but got Unknown
		//IL_0152: Expected O, but got I4
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_0298: Expected O, but got Unknown
		//IL_02d0: Expected O, but got I4
		//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Expected O, but got Unknown
		//IL_02e6: Expected F4, but got I4
		//IL_0185: Expected F4, but got I4
		//IL_030c: Expected F4, but got I4
		//IL_01a3: Invalid comparison between F4 and I
		//IL_01b5: Expected F4, but got I4
		//IL_0337: Expected O, but got I
		//IL_033f: Invalid comparison between O and F4
		//IL_0351: Expected F4, but got I4
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_01f7: Invalid comparison between O and F4
		//IL_037c: Expected O, but got I
		//IL_0393: Invalid comparison between F4 and O
		//IL_03b9: Invalid comparison between F4 and I4
		//IL_0214: Expected F4, but got I4
		//IL_03b0: Expected F4, but got I4
		//IL_03e0: Invalid comparison between I4 and F4
		//IL_0459: Unknown result type (might be due to invalid IL or missing references)
		//IL_045e: Expected O, but got Unknown
		//IL_03fd: Invalid comparison between F4 and I4
		//IL_04a1: Expected O, but got I
		//IL_04b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b6: Expected O, but got Unknown
		//IL_042b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0430: Expected O, but got Unknown
		int num = tile._data & 1;
		bool flag = num == 0;
		bool flag2 = !flag;
		int num2 = tile._data & 2;
		bool flag3 = num2 == 0;
		bool flag4 = !flag3;
		object obj = default(object);
		if (obj == null)
		{
			flag4 = true;
			flag2 = true;
		}
		bool flag5 = 0f < body._dy;
		object obj2 = 0 - body._dy;
		bool flag6 = obj2 == null;
		bool flag7 = !flag5;
		bool flag8 = !flag6;
		object obj3 = flag8 & flag7;
		float num3;
		object obj8 = default(object);
		if (obj3 != null)
		{
			object obj4 = body._checkCollision & 1;
			bool flag9 = obj4 == null;
			bool flag10 = (nint)obj4 < 0;
			bool flag11 = !flag10;
			object obj5 = !flag11;
			object obj6 = obj5 | flag9;
			if (obj6 == null)
			{
				bool flag12 = !flag4;
				num3 = 0f;
				if (!flag12)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body @ rcx (Body)+54]");
					bool flag13 = !(tileBottom > 0f);
					num3 = 0f;
					if (!flag13)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body @ rcx (Body)+54]");
						num3 = 0f - tileBottom;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
						object obj7 = obj8 ^ 0;
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num3))
						{
							return 0f;
						}
						goto IL_03b0;
					}
				}
				goto IL_04c0;
			}
		}
		bool flag14 = body._dy < 0f;
		bool flag15 = body._dy == 0f;
		bool flag16 = !flag14;
		bool flag17 = !flag15;
		object obj9 = flag17 & flag16;
		bool flag18 = obj9 == null;
		num3 = 0f;
		if (!flag18)
		{
			object obj10 = body._checkCollision & 2;
			bool flag19 = obj10 == null;
			bool flag20 = (nint)obj10 < 0;
			bool flag21 = !flag20;
			object obj11 = !flag21;
			object obj12 = obj11 | flag19;
			num3 = 0f;
			if (obj12 == null)
			{
				bool flag22 = !flag2;
				num3 = 0f;
				if (!flag22)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body @ rcx (Body)+5C]");
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body @ rcx (Body)+54]");
					object obj13 = num4 + 0;
					bool flag23 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj13) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)tileTop);
					num3 = 0f;
					if (!flag23)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body @ rcx (Body)+5C]");
						nint num5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body @ rcx (Body)+54]");
						object obj14 = num5 + 0;
						num3 = (float)obj14 - tileTop;
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num3) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8))
						{
							return 0f;
						}
						goto IL_03b0;
					}
				}
			}
		}
		goto IL_04c0;
		IL_04c0:
		return num3;
		IL_03b0:
		bool flag24 = num3 == 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000184FF4152h\"");
		if (!flag24)
		{
			float num6;
			if (!(0f > num3))
			{
				bool flag25 = !(num3 > 0f);
				num6 = 8E-06f;
				if (!flag25)
				{
					ArcadeBodyCollision blocked = (ArcadeBodyCollision)(body._blocked | 2);
					body._blocked = blocked;
					num6 = 8E-06f;
				}
			}
			else
			{
				ArcadeBodyCollision blocked2 = (ArcadeBodyCollision)(body._blocked | 1);
				body._blocked = blocked2;
				num6 = -8E-06f;
			}
			float num7 = num6 + num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body @ rcx (Body)+54]");
			float num8 = 0f - num7;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000184FF41ACh\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body @ rcx (Body)+88]");
			if ((nint)0 == 0)
			{
				_ = 0;
				return num3;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body @ rcx (Body)+74]");
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			object obj15 = num9 ^ 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body @ rcx (Body)+88]");
			object obj16 = obj15 * 0;
		}
		goto IL_04c0;
	}

	private static void ProcessTileSeparationY(Body body, float y)
	{
		//IL_0009: Invalid comparison between I4 and F4
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected O, but got Unknown
		//IL_0026: Invalid comparison between F4 and I4
		//IL_00cb: Expected O, but got I
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		float num;
		if (!(0f > y))
		{
			if (y > 0f)
			{
				ArcadeBodyCollision blocked = (ArcadeBodyCollision)(body._blocked | 2);
				body._blocked = blocked;
				num = 8E-06f;
			}
			else
			{
				num = 8E-06f;
			}
		}
		else
		{
			ArcadeBodyCollision blocked2 = (ArcadeBodyCollision)(body._blocked | 1);
			body._blocked = blocked2;
			num = -8E-06f;
		}
		float num2 = num + y;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body @ rcx (Body)+54]");
		float num3 = 0f - num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000184FF424Fh\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body @ rcx (Body)+88]");
		if ((nint)0 == 0)
		{
			_ = 0;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body @ rcx (Body)+74]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj = num4 ^ 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [body @ rcx (Body)+88]");
		object obj2 = obj * 0;
	}
}
