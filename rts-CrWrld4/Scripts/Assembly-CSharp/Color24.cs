using System.Runtime.InteropServices;

[StructLayout((LayoutKind)2)]
public struct Color24
{
	[FieldOffset(0)]
	public byte r;

	[FieldOffset(1)]
	public byte g;

	[FieldOffset(2)]
	public byte b;

	public Color24(byte red, byte blue, byte green)
	{
		r = 0;
		g = 0;
		b = 0;
	}
}
