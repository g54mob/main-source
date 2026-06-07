using System.Collections.Generic;

namespace Gh
{
	public static class SoundEngineControls
	{
		private static List<SoundEngineParameterControl<int>> _intParameters;

		private static List<SoundEngineParameterControl<float>> _floatParameters;

		public static List<SoundEngineStateControl> StateControls;

		public static SoundEngineParameterControl<int> GetGlobalParameterReference(string name, int defaultValue)
		{
			return null;
		}

		public static SoundEngineParameterControl<float> GetGlobalParameterReference(string name, float defaultValue)
		{
			return null;
		}

		public static SoundEngineStateControl GetGlobalStateReference(string name, string defaultValue)
		{
			return null;
		}
	}
}
