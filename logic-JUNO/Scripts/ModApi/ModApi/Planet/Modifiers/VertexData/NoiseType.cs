using ModApi.Common.Attributes;

namespace ModApi.Planet.Modifiers.VertexData
{
	public enum NoiseType
	{
		[UiVisibility(UiVisibility.Hidden)]
		None = 0,
		Cellular = 1,
		Cubic = 2,
		CubicFractal = 3,
		Perlin = 4,
		PerlinFractal = 5,
		Value = 8,
		ValueFractal = 9,
		ValueFractalWithDerivative = 10,
		WhiteNoise = 11,
		[UiVisibility(UiVisibility.Hidden)]
		CellularLN = 12
	}
}
