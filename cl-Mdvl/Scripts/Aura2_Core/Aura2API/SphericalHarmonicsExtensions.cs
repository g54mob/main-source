using UnityEngine.Rendering;

namespace Aura2API
{
	public static class SphericalHarmonicsExtensions
	{
		public static SphericalHarmonicsFirstBandCoefficients RepackFirstBandForShaders(this SphericalHarmonicsL2 rawCoefficients)
		{
			return new SphericalHarmonicsFirstBandCoefficients
			{
				shAr = 
				{
					x = rawCoefficients[0, 3],
					y = rawCoefficients[0, 1],
					z = rawCoefficients[0, 2],
					w = rawCoefficients[0, 0] - rawCoefficients[0, 6]
				},
				shAg = 
				{
					x = rawCoefficients[1, 3],
					y = rawCoefficients[1, 1],
					z = rawCoefficients[1, 2],
					w = rawCoefficients[1, 0] - rawCoefficients[1, 6]
				},
				shAb = 
				{
					x = rawCoefficients[2, 3],
					y = rawCoefficients[2, 1],
					z = rawCoefficients[2, 2],
					w = rawCoefficients[2, 0] - rawCoefficients[2, 6]
				}
			};
		}

		public static SphericalHarmonicsCoefficients RepackForShaders(this SphericalHarmonicsL2 rawCoefficients)
		{
			return new SphericalHarmonicsCoefficients
			{
				firstBandCoefficients = rawCoefficients.RepackFirstBandForShaders(),
				shBr = 
				{
					x = rawCoefficients[0, 4],
					y = rawCoefficients[0, 5],
					z = rawCoefficients[0, 6] * 3f,
					w = rawCoefficients[0, 7]
				},
				shBg = 
				{
					x = rawCoefficients[1, 4],
					y = rawCoefficients[1, 5],
					z = rawCoefficients[1, 6] * 3f,
					w = rawCoefficients[1, 7]
				},
				shBb = 
				{
					x = rawCoefficients[2, 4],
					y = rawCoefficients[2, 5],
					z = rawCoefficients[2, 6] * 3f,
					w = rawCoefficients[2, 7]
				},
				shC = 
				{
					x = rawCoefficients[0, 8],
					y = rawCoefficients[1, 8],
					z = rawCoefficients[2, 8],
					w = 1f
				}
			};
		}
	}
}
