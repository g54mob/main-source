using Unity.Mathematics;

public static class SubMapCDExtensions
{
	public static int width(this SubMapCD sm)
	{
		return 64;
	}

	public static int height(this SubMapCD sm)
	{
		return 64;
	}

	public static int2 size(this SubMapCD sm)
	{
		return new int2(sm.width(), sm.height());
	}

	public static int2 position(this SubMapCD sm)
	{
		return sm.size() * sm.index;
	}

	public static float2 center(this SubMapCD sm)
	{
		return sm.position() + new float2(0.5f, 0.5f) * sm.size();
	}
}
