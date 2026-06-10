using System;

namespace Aura2API
{
	[Serializable]
	public struct VolumeInjectionCommonParameters
	{
		public bool enable;

		public float strength;

		public bool useNoiseMask;

		public bool useNoiseMaskLevels;

		public LevelsParameters noiseMaskLevelParameters;

		public bool useTexture2DMask;

		public bool useTexture2DMaskLevels;

		public LevelsParameters texture2DMaskLevelParameters;

		public bool useTexture3DMask;

		public bool useTexture3DMaskLevels;

		public LevelsParameters texture3DMaskLevelParameters;
	}
}
