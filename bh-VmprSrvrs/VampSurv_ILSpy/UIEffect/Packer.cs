using Cpp2ILInjected;
using UnityEngine;

public static class Packer
{
	public static float ToFloat(float x, float y, float z, float w)
	{
		//IL_0009: Invalid comparison between I4 and F4
		//IL_019d: Invalid comparison between I4 and F4
		//IL_0029: Expected F4, but got I4
		//IL_01bd: Invalid comparison between I4 and F4
		//IL_006d: Expected F4, but got I4
		//IL_01dd: Invalid comparison between I4 and F4
		//IL_01ec: Expected F4, but got I4
		//IL_00b1: Expected F4, but got I4
		float num;
		if (0f > x)
		{
			num = 0f;
		}
		else
		{
			bool flag = !(1f > x);
			num = 1f;
			if (!flag)
			{
				num = x;
			}
		}
		float num2;
		if (0f > y)
		{
			num2 = 0f;
		}
		else
		{
			bool flag2 = !(1f > y);
			num2 = 1f;
			if (!flag2)
			{
				num2 = y;
			}
		}
		float num3;
		if (0f > z)
		{
			num3 = 0f;
		}
		else
		{
			bool flag3 = !(1f > z);
			num3 = 1f;
			if (!flag3)
			{
				num3 = z;
			}
		}
		bool flag4 = 0f > w;
		float num4 = 0f;
		if (!flag4)
		{
			bool flag5 = !(1f > w);
			num4 = 1f;
			if (!flag5)
			{
				num4 = w;
			}
		}
		float num5 = num4 * 63f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
		float num6 = num3 * 63f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
		float num7 = num2 * 63f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
		float num8 = num * 63f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
		object obj2 = default(object);
		object obj = obj2 << 6;
		object obj4 = default(object);
		object obj3 = obj + obj4;
		object obj5 = obj3 << 6;
		object obj7 = default(object);
		object obj6 = obj5 + obj7;
		object obj8 = obj6 << 6;
		object obj9 = default(object);
		return (float)obj9 + (float)obj8;
	}

	public static float ToFloat(Vector4 factor)
	{
		//IL_001b: Invalid comparison between I4 and F4
		//IL_0066: Expected F4, but got I4
		//IL_02ae: Invalid comparison between I4 and F4
		//IL_00a2: Expected F4, but got I4
		//IL_02dd: Invalid comparison between I4 and F4
		//IL_00de: Expected F4, but got I4
		//IL_030c: Invalid comparison between I4 and F4
		//IL_011a: Expected F4, but got I4
		//IL_0329: Invalid comparison between I4 and F4
		//IL_0349: Invalid comparison between I4 and F4
		//IL_0128: Expected F4, but got I4
		//IL_0369: Invalid comparison between I4 and F4
		//IL_016c: Expected F4, but got I4
		//IL_0389: Invalid comparison between I4 and F4
		//IL_0398: Expected F4, but got I4
		//IL_01b0: Expected F4, but got I4
		float num = factor.x;
		if (!(0f > factor.x))
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
		float num2 = factor.y;
		if (!(0f > factor.y))
		{
			if (num2 > 1f)
			{
				num2 = 1f;
			}
		}
		else
		{
			num2 = 0f;
		}
		float num3 = factor.z;
		if (!(0f > factor.z))
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
		float num4 = factor.w;
		if (!(0f > factor.w))
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
		float num5;
		if (0f > num)
		{
			num5 = 0f;
		}
		else
		{
			bool flag = !(1f > num);
			num5 = 1f;
			if (!flag)
			{
				num5 = num;
			}
		}
		float num6;
		if (0f > num2)
		{
			num6 = 0f;
		}
		else
		{
			bool flag2 = !(1f > num2);
			num6 = 1f;
			if (!flag2)
			{
				num6 = num2;
			}
		}
		float num7;
		if (0f > num3)
		{
			num7 = 0f;
		}
		else
		{
			bool flag3 = !(1f > num3);
			num7 = 1f;
			if (!flag3)
			{
				num7 = num3;
			}
		}
		bool flag4 = 0f > num4;
		float num8 = 0f;
		if (!flag4)
		{
			bool flag5 = !(1f > num4);
			num8 = 1f;
			if (!flag5)
			{
				num8 = num4;
			}
		}
		float num9 = num8 * 63f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
		float num10 = num7 * 63f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
		float num11 = num6 * 63f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
		float num12 = num5 * 63f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
		object obj2 = default(object);
		object obj = obj2 << 6;
		object obj4 = default(object);
		object obj3 = obj + obj4;
		object obj5 = obj3 << 6;
		object obj7 = default(object);
		object obj6 = obj5 + obj7;
		object obj8 = obj6 << 6;
		object obj9 = default(object);
		return (float)obj9 + (float)obj8;
	}

	public static float ToFloat(float x, float y, float z)
	{
		//IL_0009: Invalid comparison between I4 and F4
		//IL_0124: Invalid comparison between I4 and F4
		//IL_0029: Expected F4, but got I4
		//IL_0144: Invalid comparison between I4 and F4
		//IL_0153: Expected F4, but got I4
		//IL_006d: Expected F4, but got I4
		float num;
		if (0f > x)
		{
			num = 0f;
		}
		else
		{
			bool flag = !(1f > x);
			num = 1f;
			if (!flag)
			{
				num = x;
			}
		}
		float num2;
		if (0f > y)
		{
			num2 = 0f;
		}
		else
		{
			bool flag2 = !(1f > y);
			num2 = 1f;
			if (!flag2)
			{
				num2 = y;
			}
		}
		bool flag3 = 0f > z;
		float num3 = 0f;
		if (!flag3)
		{
			bool flag4 = !(1f > z);
			num3 = 1f;
			if (!flag4)
			{
				num3 = z;
			}
		}
		float num4 = num3 * 255f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
		float num5 = num2 * 255f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
		float num6 = num * 255f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
		object obj2 = default(object);
		object obj = obj2 << 8;
		object obj4 = default(object);
		object obj3 = obj + obj4;
		object obj5 = obj3 << 8;
		object obj6 = default(object);
		return (float)obj6 + (float)obj5;
	}

	public static float ToFloat(float x, float y)
	{
		//IL_0009: Invalid comparison between I4 and F4
		//IL_00a3: Invalid comparison between I4 and F4
		//IL_00b2: Expected F4, but got I4
		//IL_0029: Expected F4, but got I4
		float num;
		if (0f > x)
		{
			num = 0f;
		}
		else
		{
			bool flag = !(1f > x);
			num = 1f;
			if (!flag)
			{
				num = x;
			}
		}
		bool flag2 = 0f > y;
		float num2 = 0f;
		if (!flag2)
		{
			bool flag3 = !(1f > y);
			num2 = 1f;
			if (!flag3)
			{
				num2 = y;
			}
		}
		float num3 = num2 * 4095f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
		float num4 = num * 4095f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
		object obj2 = default(object);
		object obj = obj2 << 12;
		object obj3 = default(object);
		return (float)obj3 + (float)obj;
	}
}
