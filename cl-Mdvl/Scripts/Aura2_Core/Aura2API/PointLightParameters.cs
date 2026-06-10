using UnityEngine;

namespace Aura2API
{
	public struct PointLightParameters
	{
		public Vector3 color;

		public int useDefaultScattering;

		public float scatteringOverride;

		public Vector3 lightPosition;

		public float lightRange;

		public Vector2 distanceFalloffParameters;

		public MatrixFloats worldToShadowMatrix;

		public Vector2 lightProjectionParameters;

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
					_byteSize += 4;
					_byteSize += 8;
					_byteSize += MatrixFloats.Size;
					_byteSize += 8;
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
