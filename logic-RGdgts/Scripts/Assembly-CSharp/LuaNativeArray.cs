using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public class LuaNativeArray
{
	public int length;

	public IntPtr data;

	public static LuaNativeArray Create<T>(T[] array) where T : struct
	{
		return null;
	}
}
