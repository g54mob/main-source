using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public class FromLuaInputSource
{
	public uint moduleId;

	public IntPtr name;

	public int direction;

	public InputSource ToInputSource()
	{
		return default(InputSource);
	}
}
