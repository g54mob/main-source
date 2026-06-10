using UnityEngine;

namespace Aura2API
{
	public struct VolumeData
	{
		public MatrixFloats transform;

		public int shape;

		public float falloffExponent;

		public float xPositiveFade;

		public float xNegativeFade;

		public float yPositiveFade;

		public float yNegativeFade;

		public float zPositiveFade;

		public float zNegativeFade;

		public int useAsLightProbesProxyVolume;

		public float lightProbesMultiplier;

		public TextureMaskData texture2DMaskData;

		public TextureMaskData texture3DMaskData;

		public VolumeDynamicNoiseData noiseData;

		public int injectDensity;

		public float densityValue;

		public LevelsData densityTexture2DMaskLevelsParameters;

		public LevelsData densityTexture3DMaskLevelsParameters;

		public LevelsData densityNoiseLevelsParameters;

		public int injectScattering;

		public float scatteringValue;

		public LevelsData scatteringTexture2DMaskLevelsParameters;

		public LevelsData scatteringTexture3DMaskLevelsParameters;

		public LevelsData scatteringNoiseLevelsParameters;

		public int injectColor;

		public Vector3 colorValue;

		public LevelsData colorTexture2DMaskLevelsParameters;

		public LevelsData colorTexture3DMaskLevelsParameters;

		public LevelsData colorNoiseLevelsParameters;

		public int injectTint;

		public Vector3 tintColor;

		public LevelsData tintTexture2DMaskLevelsParameters;

		public LevelsData tintTexture3DMaskLevelsParameters;

		public LevelsData tintNoiseLevelsParameters;

		public int injectAmbient;

		public float ambientLightingValue;

		public LevelsData ambientTexture2DMaskLevelsParameters;

		public LevelsData ambientTexture3DMaskLevelsParameters;

		public LevelsData ambientNoiseLevelsParameters;

		public int injectBoost;

		public float boostValue;

		public LevelsData boostTexture2DMaskLevelsParameters;

		public LevelsData boostTexture3DMaskLevelsParameters;

		public LevelsData boostNoiseLevelsParameters;

		private static int _byteSize;

		public static int Size
		{
			get
			{
				if (_byteSize == 0)
				{
					_byteSize += MatrixFloats.Size;
					_byteSize += 4;
					_byteSize += 4;
					_byteSize += 4;
					_byteSize += 4;
					_byteSize += 4;
					_byteSize += 4;
					_byteSize += 4;
					_byteSize += 4;
					_byteSize += 4;
					_byteSize += 4;
					_byteSize += TextureMaskData.Size;
					_byteSize += TextureMaskData.Size;
					_byteSize += VolumeDynamicNoiseData.Size;
					_byteSize += 4;
					_byteSize += 4;
					_byteSize += LevelsData.Size;
					_byteSize += LevelsData.Size;
					_byteSize += LevelsData.Size;
					_byteSize += 4;
					_byteSize += 4;
					_byteSize += LevelsData.Size;
					_byteSize += LevelsData.Size;
					_byteSize += LevelsData.Size;
					_byteSize += 4;
					_byteSize += 12;
					_byteSize += LevelsData.Size;
					_byteSize += LevelsData.Size;
					_byteSize += LevelsData.Size;
					_byteSize += 4;
					_byteSize += 12;
					_byteSize += LevelsData.Size;
					_byteSize += LevelsData.Size;
					_byteSize += LevelsData.Size;
					_byteSize += 4;
					_byteSize += 4;
					_byteSize += LevelsData.Size;
					_byteSize += LevelsData.Size;
					_byteSize += LevelsData.Size;
					_byteSize += 4;
					_byteSize += 4;
					_byteSize += LevelsData.Size;
					_byteSize += LevelsData.Size;
					_byteSize += LevelsData.Size;
				}
				return _byteSize;
			}
		}
	}
}
