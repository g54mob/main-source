using System;

public struct ToLuaPixelData
{
	public int width;

	public int height;

	public IntPtr data;

	public ToLuaPixelData(PixelData pixelData)
	{
		width = 0;
		height = 0;
		data = (IntPtr)0;
	}

	public static implicit operator ToLuaPixelData(PixelData table)
	{
		return default(ToLuaPixelData);
	}
}
