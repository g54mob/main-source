using UnityEngine;

namespace DarkTonic.MasterAudio
{
	public static class SpatializerHelper
	{
		private const string OculusSpatializer = "OculusSpatializer";

		private const string ResonanceAudioSpatializer = "Resonance Audio";

		public static bool IsSupportedSpatializer => false;

		public static bool IsOculusAudioSpatializer => false;

		public static bool IsResonanceAudioSpatializer => false;

		public static string SelectedSpatializer => null;

		public static bool SpatializerOptionExists => false;

		public static void TurnOnSpatializerIfEnabled(AudioSource source)
		{
		}

		private static void SetSpatializerToggleOnSource(AudioSource source, bool enabled)
		{
		}
	}
}
