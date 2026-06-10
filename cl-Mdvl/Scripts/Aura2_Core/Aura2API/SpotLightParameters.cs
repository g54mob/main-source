using UnityEngine;

namespace Aura2API
{
	public struct SpotLightParameters
	{
		public Vector3 color;

		public int useDefaultScattering;

		public float scatteringOverride;

		public Vector3 lightPosition;

		public Vector3 lightDirection;

		public float lightRange;

		public float lightCosHalfAngle;

		public Vector2 angularFalloffParameters;

		public Vector2 distanceFalloffParameters;

		public MatrixFloats worldToShadowMatrix;

		public int shadowMapIndex;

		public float shadowStrength;

		public int cookieMapIndex;

		public Vector3 cookieParameters;

		private static int _byteSize;

		public static int Size
		{
			get
			{
				if (_byteSize == 0)
				{
					_byteSize += 12;
					_byteSize += 4;
					_byteSize += 4;
					_byteSize += 12;
					_byteSize += 12;
					_byteSize += 4;
					_byteSize += 4;
					_byteSize += 8;
					_byteSize += 8;
					_byteSize += MatrixFloats.Size;
					_byteSize += 4;
					_byteSize += 4;
					_byteSize += 4;
					_byteSize += 12;
				}
				return _byteSize;
			}
		}
	}
}
