using UnityEngine;

namespace Gh.Tk
{
	public class MusicManagerConfig
	{
		public AnimationCurve intensityBasedDelay;

		public float intensityChangeFadeInTime;

		public float intensityChangeFadeOutTime;

		public float minSongDurationBeforeIntensityChange;

		public float intensityTrackChangeBuffer;

		public int minPatronsForMaxIntensity;

		public int minPatronsForForeignTracks;

		public float quickChangeFadeTime;

		public float GetDelayTime(float currentIntensity)
		{
			return 0f;
		}
	}
}
