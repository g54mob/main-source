using System;

namespace Aura2API
{
	[Serializable]
	public struct LevelsParameters
	{
		public float levelLowThreshold;

		public float levelHiThreshold;

		public float outputLowValue;

		public float outputHiValue;

		public float contrast;

		public bool saturateOutputValues;

		private LevelsData _packedData;

		public LevelsData Data
		{
			get
			{
				_packedData.levelLowThreshold = levelLowThreshold;
				_packedData.levelHiThreshold = levelHiThreshold;
				_packedData.outputLowValue = outputLowValue;
				_packedData.outputHiValue = outputHiValue;
				_packedData.contrast = contrast;
				return _packedData;
			}
		}

		public static LevelsParameters Default => new LevelsParameters
		{
			levelLowThreshold = 0f,
			levelHiThreshold = 1f,
			outputLowValue = 0f,
			outputHiValue = 1f,
			contrast = 1f
		};

		public static LevelsParameters One => new LevelsParameters
		{
			levelLowThreshold = 1f,
			levelHiThreshold = 1f,
			outputLowValue = 1f,
			outputHiValue = 1f,
			contrast = 1f
		};

		public static LevelsParameters Zero => new LevelsParameters
		{
			levelLowThreshold = 0f,
			levelHiThreshold = 0f,
			outputLowValue = 0f,
			outputHiValue = 0f,
			contrast = 0f
		};

		public void SetDefaultValues()
		{
			this = Default;
		}
	}
}
