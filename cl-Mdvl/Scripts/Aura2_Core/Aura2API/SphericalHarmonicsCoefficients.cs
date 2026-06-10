using UnityEngine;

namespace Aura2API
{
	public struct SphericalHarmonicsCoefficients
	{
		public SphericalHarmonicsFirstBandCoefficients firstBandCoefficients;

		public Vector4 shBr;

		public Vector4 shBg;

		public Vector4 shBb;

		public Vector4 shC;

		private static int _byteSize;

		public static int Size
		{
			get
			{
				if (_byteSize == 0)
				{
					_byteSize += SphericalHarmonicsFirstBandCoefficients.Size;
					_byteSize += 16;
					_byteSize += 16;
					_byteSize += 16;
					_byteSize += 16;
				}
				return _byteSize;
			}
		}
	}
}
