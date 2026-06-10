using UnityEngine;

namespace Aura2API
{
	public struct DirectionalLightParameters
	{
		public Vector3 color;

		public int useDefaultScattering;

		public float scatteringOverride;

		public Vector3 lightPosition;

		public Vector3 lightDirection;

		public MatrixFloats worldToLightMatrix;

		public MatrixFloats lightToWorldMatrix;

		public int shadowMapIndex;

		public int cookieMapIndex;

		public Vector2 cookieParameters;

		public int enableOutOfPhaseColor;

		public Vector3 outOfPhaseColor;

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
					_byteSize += MatrixFloats.Size;
					_byteSize += MatrixFloats.Size;
					_byteSize += 4;
					_byteSize += 4;
					_byteSize += 8;
					_byteSize += 4;
					_byteSize += 12;
				}
				return _byteSize;
			}
		}
	}
}
