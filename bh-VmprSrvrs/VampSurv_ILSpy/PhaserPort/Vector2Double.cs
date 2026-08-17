using System;
using Cpp2ILInjected;

[Serializable]
public struct Vector2Double(double x, double y)
{
	public double x = x;

	public double y = y;

	public unsafe static Vector2Double zero
	{
		get
		{
			//IL_000d: Expected native int or pointer, but got O
			Vector2Double vector2Double = default(Vector2Double);
			((Vector2Double*)(nint)vector2Double)->x = 0.0;
			return vector2Double;
		}
	}

	public unsafe static Vector2Double operator +(Vector2Double a, Vector2Double b)
	{
		//IL_0021: Expected native int or pointer, but got O
		//IL_0033: Expected native int or pointer, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm0,qword ptr [r8]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm1,qword ptr [r8+8]\"");
		Vector2Double vector2Double = default(Vector2Double);
		((Vector2Double*)(nint)vector2Double)->x = a.x;
		((Vector2Double*)(nint)vector2Double)->y = a.y;
		return vector2Double;
	}

	public unsafe static Vector2Double operator -(Vector2Double a, Vector2Double b)
	{
		//IL_0021: Expected native int or pointer, but got O
		//IL_0033: Expected native int or pointer, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm0,qword ptr [r8]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"subsd xmm1,qword ptr [r8+8]\"");
		Vector2Double vector2Double = default(Vector2Double);
		((Vector2Double*)(nint)vector2Double)->x = a.x;
		((Vector2Double*)(nint)vector2Double)->y = a.y;
		return vector2Double;
	}

	public unsafe static Vector2Double operator *(Vector2Double a, double scale)
	{
		//IL_0021: Expected native int or pointer, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"unpcklpd xmm2,xmm2\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulpd xmm0,xmm2\"");
		Vector2Double vector2Double = default(Vector2Double);
		((Vector2Double*)(nint)vector2Double)->x = a.x;
		return vector2Double;
	}

	public unsafe static Vector2Double operator /(Vector2Double a, double scale)
	{
		//IL_0021: Expected native int or pointer, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"unpcklpd xmm2,xmm2\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"divpd xmm0,xmm2\"");
		Vector2Double vector2Double = default(Vector2Double);
		((Vector2Double*)(nint)vector2Double)->x = a.x;
		return vector2Double;
	}

	public unsafe static Vector2Double operator *(Vector2Double a, Vector2Double b)
	{
		//IL_0021: Expected native int or pointer, but got O
		//IL_0033: Expected native int or pointer, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm0,qword ptr [r8]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm1,qword ptr [r8+8]\"");
		Vector2Double vector2Double = default(Vector2Double);
		((Vector2Double*)(nint)vector2Double)->x = a.x;
		((Vector2Double*)(nint)vector2Double)->y = a.y;
		return vector2Double;
	}

	public static bool operator ==(Vector2Double a, Vector2Double b)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,qword ptr [rdx]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000184FF435Dh\"");
		object obj2 = default(object);
		object obj = ~obj2;
		if (obj == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,qword ptr [rdx+8]\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000184FF435Dh\"");
			object obj3 = ~obj2;
			if (obj3 == null)
			{
				return true;
			}
		}
		return false;
	}

	public static bool operator !=(Vector2Double a, Vector2Double b)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,qword ptr [rdx]\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000184FF437Dh\"");
		object obj2 = default(object);
		object obj = ~obj2;
		if (obj == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,qword ptr [rdx+8]\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000184FF437Dh\"");
			object obj3 = ~obj2;
			if (obj3 == null)
			{
				return false;
			}
		}
		return true;
	}

	public void Set(double x, double y)
	{
		this.x = x;
		this.y = y;
	}

	public void Set(double value)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"unpcklpd xmm1,xmm1\"");
		x = value;
	}

	public unsafe Vector2Double setToPolar(double azimuth, double radius = 1.0)
	{
		//IL_0054: Expected native int or pointer, but got O
		double num = Math.Cos(azimuth);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm6,xmm7\"");
		double num2 = Math.Sin(azimuth);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm0,xmm7\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"unpcklpd xmm6,xmm0\"");
		x = num;
		Vector2Double vector2Double = default(Vector2Double);
		((Vector2Double*)(nint)vector2Double)->x = num;
		return vector2Double;
	}

	public unsafe Vector2Double normalize()
	{
		//IL_00f3: Expected native int or pointer, but got O
		//IL_0013: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm0,xmm0\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm6,xmm6\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"addsd xmm6,xmm0\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm6,xmm0\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998B204]");
		if ((nint)0 > (nint)0)
		{
			nint num = (nint)typeof(Math);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm6\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rcx_v3 (Il2CppClass<System.Math>)+E4]");
			if ((nint)0 <= (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm6\"");
			}
			else
			{
				double num2 = Math.Sqrt(x);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"divsd xmm1,xmm0\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"unpcklpd xmm1,xmm1\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulpd xmm0,xmm1\"");
			x = x;
		}
		Vector2Double vector2Double = default(Vector2Double);
		((Vector2Double*)(nint)vector2Double)->x = x;
		return vector2Double;
	}

	public unsafe Vector2Double scale(double scalar)
	{
		//IL_001e: Expected native int or pointer, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"unpcklpd xmm2,xmm2\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulpd xmm0,xmm2\"");
		Vector2Double vector2Double = default(Vector2Double);
		((Vector2Double*)(nint)vector2Double)->x = x;
		return vector2Double;
	}
}
