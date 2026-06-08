namespace Shapes
{
	public static class ShapeFillExtensions
	{
		internal static int GetShaderFillModeInt(this ShapeFill fill)
		{
			return (int)(fill?.type ?? ((FillType)(-1)));
		}
	}
}
