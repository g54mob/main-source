using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public class ToLuaInputSource
{
	public uint moduleId;

	public string name;

	public int direction;

	public ToLuaInputSource()
	{
	}

	public ToLuaInputSource(InputSource value)
	{
	}
}
