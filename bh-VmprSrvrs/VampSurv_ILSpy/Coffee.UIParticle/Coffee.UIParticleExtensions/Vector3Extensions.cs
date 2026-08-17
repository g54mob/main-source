using Cpp2ILInjected;
using UnityEngine;

namespace Coffee.UIParticleExtensions;

public static class Vector3Extensions
{
	public unsafe static Vector3 Inverse(Vector3 self)
	{
		//IL_0089: Expected native int or pointer, but got O
		//IL_00c9: Expected native int or pointer, but got O
		//IL_0109: Expected native int or pointer, but got O
		//IL_011b: Expected native int or pointer, but got O
		//IL_012d: Expected native int or pointer, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
		object obj = default(object);
		bool flag = obj != null;
		float x = 1f;
		if (!flag)
		{
			x = 1f / self.x;
		}
		((Vector3*)(nint)self)->x = x;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
		object obj2 = default(object);
		bool flag2 = obj2 != null;
		float y = 1f;
		if (!flag2)
		{
			y = 1f / self.y;
		}
		((Vector3*)(nint)self)->y = y;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA2CD0");
		object obj3 = default(object);
		bool flag3 = obj3 != null;
		float z = 1f;
		if (!flag3)
		{
			z = 1f / self.z;
		}
		((Vector3*)(nint)self)->z = z;
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = self.x;
		((Vector3*)(nint)vector)->z = self.z;
		return vector;
	}

	public unsafe static Vector3 GetScaled(Vector3 self, Vector3 other1)
	{
		//IL_0021: Expected native int or pointer, but got O
		//IL_002e: Expected native int or pointer, but got O
		//IL_003b: Expected native int or pointer, but got O
		//IL_004d: Expected native int or pointer, but got O
		float z = other1.z * self.z;
		((Vector3*)(nint)self)->z = z;
		float x = default(float);
		((Vector3*)(nint)self)->x = x;
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = x;
		((Vector3*)(nint)vector)->z = self.z;
		return vector;
	}

	public unsafe static Vector3 GetScaled(Vector3 self, Vector3 other1, Vector3 other2)
	{
		//IL_0035: Expected native int or pointer, but got O
		//IL_0042: Expected native int or pointer, but got O
		//IL_004f: Expected native int or pointer, but got O
		//IL_0061: Expected native int or pointer, but got O
		float num = other1.z * self.z;
		float z = num * other2.z;
		((Vector3*)(nint)self)->z = z;
		float x = default(float);
		((Vector3*)(nint)self)->x = x;
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = x;
		((Vector3*)(nint)vector)->z = self.z;
		return vector;
	}

	public unsafe static Vector3 GetScaled(Vector3 self, Vector3 other1, Vector3 other2, Vector3 other3)
	{
		//IL_004c: Expected native int or pointer, but got O
		//IL_0059: Expected native int or pointer, but got O
		//IL_0066: Expected native int or pointer, but got O
		//IL_0078: Expected native int or pointer, but got O
		float num = other1.z * self.z;
		float num2 = num * other2.z;
		float num3 = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ stack_28+8]");
		float z = num3 * 0f;
		((Vector3*)(nint)self)->z = z;
		float x = default(float);
		((Vector3*)(nint)self)->x = x;
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = x;
		((Vector3*)(nint)vector)->z = self.z;
		return vector;
	}

	public static bool IsVisible(Vector3 self)
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		float num = self.y * self.x;
		float num2 = num * self.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj = num2 & 0;
		bool flag = (nint)obj < 0;
		bool flag2 = obj == null;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		return flag4 & flag3;
	}
}
