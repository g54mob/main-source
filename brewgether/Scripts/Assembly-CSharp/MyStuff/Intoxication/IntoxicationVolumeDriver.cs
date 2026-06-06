using UnityEngine.Rendering;

namespace MyStuff.Intoxication
{
	public static class IntoxicationVolumeDriver
	{
		private const float EFFECT_THRESHOLD = 0.001f;

		private static VolumeProfile GetBaseProfile()
		{
			return null;
		}

		public static void ApplyToProfile(VolumeProfile profile, AggregatedIntoxicationParams p)
		{
		}

		public static void ClearProfile(VolumeProfile profile)
		{
		}

		private static T GetOrAdd<T>(VolumeProfile profile) where T : VolumeComponent
		{
			return null;
		}

		private static bool TryGetBase<T>(VolumeProfile baseProfile, out T comp) where T : VolumeComponent
		{
			comp = null;
			return false;
		}

		private static void ApplyVignette(VolumeProfile profile, AggregatedIntoxicationParams p, VolumeProfile baseProfile)
		{
		}

		private static void ApplyChromaticAberration(VolumeProfile profile, AggregatedIntoxicationParams p, VolumeProfile baseProfile)
		{
		}

		private static void ApplyBloom(VolumeProfile profile, AggregatedIntoxicationParams p, VolumeProfile baseProfile)
		{
		}

		private static void ApplyColorAdjustments(VolumeProfile profile, AggregatedIntoxicationParams p, VolumeProfile baseProfile)
		{
		}

		private static void ApplyFilmGrain(VolumeProfile profile, AggregatedIntoxicationParams p, VolumeProfile baseProfile)
		{
		}

		private static void ApplyLensDistortion(VolumeProfile profile, AggregatedIntoxicationParams p, VolumeProfile baseProfile)
		{
		}

		private static void ApplyWhiteBalance(VolumeProfile profile, AggregatedIntoxicationParams p, VolumeProfile baseProfile)
		{
		}

		private static void ApplySplitToning(VolumeProfile profile, AggregatedIntoxicationParams p, VolumeProfile baseProfile)
		{
		}
	}
}
