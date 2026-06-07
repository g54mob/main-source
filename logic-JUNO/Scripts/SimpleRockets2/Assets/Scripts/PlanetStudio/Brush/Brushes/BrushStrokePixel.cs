using ModApi.Common.SimpleTypes;

namespace Assets.Scripts.PlanetStudio.Brush.Brushes
{
	public class BrushStrokePixel
	{
		public ColorRGB24 Color;

		public float Strength;

		public BrushStrokePixel(float strength, ColorRGB24 color)
		{
			Strength = strength;
			Color = color;
		}
	}
}
