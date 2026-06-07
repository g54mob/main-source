using System.Runtime.InteropServices;

public static class ApproxUtl
{
	[StructLayout((LayoutKind)2)]
	private struct Convert
	{
		[FieldOffset(0)]
		public float x;

		[FieldOffset(0)]
		public int i;
	}

	public static float LowSin(float x)
	{
		return 0f;
	}

	public static float HighSin(float x)
	{
		return 0f;
	}

	public static float LowCos(float x)
	{
		return 0f;
	}

	public static float HighCos(float x)
	{
		return 0f;
	}

	public static float TaylorSin(float x)
	{
		return 0f;
	}

	public static float InvSqrt(float x, int iterations = 0)
	{
		return 0f;
	}
}
