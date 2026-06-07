using UnityEngine;

namespace DarkTonic.MasterAudio
{
	public static class AudioUtil
	{
		public const float DefaultMinOcclusionCutoffFrequency = 22000f;

		public const float DefaultMaxOcclusionCutoffFrequency = 0f;

		private const float SemitonePitchChangeAmt = 1.0594635f;

		public static float FixedDeltaTime => 0f;

		public static float FrameTime => 0f;

		public static float Time => 0f;

		public static int FrameCount => 0;

		private static float CutoffRange(SoundGroupVariationUpdater updater)
		{
			return 0f;
		}

		private static float MaxCutoffFreq(SoundGroupVariationUpdater updater)
		{
			return 0f;
		}

		public static float MinCutoffFreq(SoundGroupVariationUpdater updater)
		{
			return 0f;
		}

		public static float GetOcclusionCutoffFrequencyByDistanceRatio(float distRatio, SoundGroupVariationUpdater updater)
		{
			return 0f;
		}

		public static float GetSemitonesFromPitch(float pitch)
		{
			return 0f;
		}

		public static float GetPitchFromSemitones(float semitones)
		{
			return 0f;
		}

		public static float GetDbFromFloatVolume(float vol)
		{
			return 0f;
		}

		public static float GetFloatVolumeFromDb(float db)
		{
			return 0f;
		}

		public static float GetAudioPlayedPercentage(AudioSource source)
		{
			return 0f;
		}

		public static bool IsClipPaused(AudioSource source)
		{
			return false;
		}

		public static void ClipPlayed(AudioClip clip, GameObject actor)
		{
		}

		public static void UnloadNonPreloadedAudioData(AudioClip clip, GameObject actor)
		{
		}

		public static bool AudioClipWillPreload(AudioClip clip)
		{
			return false;
		}

		public static bool IsClipReadyToPlay(this AudioClip clip)
		{
			return false;
		}

		private static float GetPositiveUsablePitch(AudioSource source)
		{
			return 0f;
		}

		private static float GetPositiveUsablePitch(float pitch)
		{
			return 0f;
		}

		public static float AdjustAudioClipDurationForPitch(float duration, AudioSource sourceWithPitch)
		{
			return 0f;
		}

		public static float AdjustAudioClipDurationForPitch(float duration, float pitch)
		{
			return 0f;
		}

		public static float AdjustEndLeadTimeForPitch(float duration, AudioSource sourceWithPitch)
		{
			return 0f;
		}
	}
}
