using Cpp2ILInjected;
using UnityEngine;

namespace ProGrids;

public static class pg_Enum
{
	public unsafe static Vector3 InverseAxisMask(Vector3 v, Axis axis)
	{
		//IL_0091: Expected O, but got I4
		//IL_0130: Expected native int or pointer, but got O
		//IL_0152: Expected native int or pointer, but got O
		//IL_0164: Expected native int or pointer, but got O
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected O, but got Unknown
		//IL_01c6: Expected native int or pointer, but got O
		//IL_01e8: Expected native int or pointer, but got O
		//IL_01fa: Expected native int or pointer, but got O
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		//IL_017b: Expected native int or pointer, but got O
		//IL_01a2: Expected native int or pointer, but got O
		//IL_01af: Expected native int or pointer, but got O
		//IL_0067: Expected native int or pointer, but got O
		//IL_0079: Expected native int or pointer, but got O
		if (axis > Axis.NegX)
		{
			if (axis != Axis.NegY)
			{
				if (axis != Axis.NegZ)
				{
					goto IL_005a;
				}
				goto IL_016e;
			}
		}
		else
		{
			object obj = axis - 1;
			bool flag = axis == Axis.X;
			if (flag)
			{
				goto IL_0123;
			}
			object obj2 = obj - 1;
			if (!flag)
			{
				object obj3 = obj2 - 1;
				if (!flag)
				{
					if ((nint)obj3 == 1)
					{
						goto IL_016e;
					}
					if (axis == Axis.NegX)
					{
						goto IL_0123;
					}
				}
				goto IL_005a;
			}
		}
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = v.x;
		float y = v.y * 0f;
		((Vector3*)(nint)vector)->y = y;
		((Vector3*)(nint)vector)->z = v.z;
		return vector;
		IL_0123:
		((Vector3*)(nint)vector)->y = v.y;
		float x = v.x * 0f;
		((Vector3*)(nint)vector)->x = x;
		((Vector3*)(nint)vector)->z = v.z;
		return vector;
		IL_016e:
		((Vector3*)(nint)vector)->x = v.x;
		float z = v.z * 0f;
		((Vector3*)(nint)vector)->y = v.y;
		((Vector3*)(nint)vector)->z = z;
		return vector;
		IL_005a:
		((Vector3*)(nint)vector)->x = v.x;
		((Vector3*)(nint)vector)->z = v.z;
		return vector;
	}

	public unsafe static Vector3 AxisMask(Vector3 v, Axis axis)
	{
		//IL_0091: Expected O, but got I4
		//IL_0145: Expected native int or pointer, but got O
		//IL_0152: Expected native int or pointer, but got O
		//IL_0174: Expected native int or pointer, but got O
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected O, but got Unknown
		//IL_01fb: Expected native int or pointer, but got O
		//IL_0208: Expected native int or pointer, but got O
		//IL_022a: Expected native int or pointer, but got O
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		//IL_01a0: Expected native int or pointer, but got O
		//IL_01ad: Expected native int or pointer, but got O
		//IL_01cf: Expected native int or pointer, but got O
		//IL_0067: Expected native int or pointer, but got O
		//IL_0079: Expected native int or pointer, but got O
		if (axis > Axis.NegX)
		{
			if (axis != Axis.NegY)
			{
				if (axis != Axis.NegZ)
				{
					goto IL_005a;
				}
				goto IL_017e;
			}
		}
		else
		{
			object obj = axis - 1;
			bool flag = axis == Axis.X;
			if (flag)
			{
				goto IL_0123;
			}
			object obj2 = obj - 1;
			if (!flag)
			{
				object obj3 = obj2 - 1;
				if (!flag)
				{
					if ((nint)obj3 == 1)
					{
						goto IL_017e;
					}
					if (axis == Axis.NegX)
					{
						goto IL_0123;
					}
				}
				goto IL_005a;
			}
		}
		float x = v.x * 0f;
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->y = v.y;
		((Vector3*)(nint)vector)->x = x;
		float z = v.z * 0f;
		((Vector3*)(nint)vector)->z = z;
		return vector;
		IL_0123:
		float y = v.y * 0f;
		((Vector3*)(nint)vector)->x = v.x;
		((Vector3*)(nint)vector)->y = y;
		float z2 = v.z * 0f;
		((Vector3*)(nint)vector)->z = z2;
		return vector;
		IL_017e:
		float x2 = v.x * 0f;
		((Vector3*)(nint)vector)->z = v.z;
		((Vector3*)(nint)vector)->x = x2;
		float y2 = v.y * 0f;
		((Vector3*)(nint)vector)->y = y2;
		return vector;
		IL_005a:
		((Vector3*)(nint)vector)->x = v.x;
		((Vector3*)(nint)vector)->z = v.z;
		return vector;
	}

	public static float SnapUnitValue(SnapUnit su)
	{
		//IL_002a: Expected O, but got I8
		//IL_0044: Expected O, but got I8
		if (su <= SnapUnit.Parsec)
		{
			object obj = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ rdx_v1+3D45BC+su @ rcx (ProGrids.SnapUnit)*4]");
			object obj2 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v17 @ rcx_v2 (should have been resolved before IL gen)");
		}
		return 1f;
	}
}
