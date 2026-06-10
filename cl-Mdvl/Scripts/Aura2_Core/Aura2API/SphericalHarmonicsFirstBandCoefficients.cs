using UnityEngine;

namespace Aura2API
{
	public struct SphericalHarmonicsFirstBandCoefficients
	{
		public Vector4 shAr;

		public Vector4 shAg;

		public Vector4 shAb;

		private static int _byteSize;

		public static int Size
		{
			get
			{
				if (_byteSize == 0)
				{
					_byteSize += 16;
					_byteSize += 16;
					_byteSize += 16;
				}
				return _byteSize;
			}
		}
	}
}
