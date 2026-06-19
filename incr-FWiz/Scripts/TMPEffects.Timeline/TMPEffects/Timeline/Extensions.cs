using TMPEffects.TMPAnimations;
using UnityEngine.Timeline;

namespace TMPEffects.Timeline
{
	internal static class Extensions
	{
		public static TimelineClip.ClipExtrapolation ConvertExtrapolation(this AnimationStep.ExtrapolationMode mode)
		{
			return default(TimelineClip.ClipExtrapolation);
		}

		public static AnimationStep.ExtrapolationMode ConvertExtrapolation(this TimelineClip.ClipExtrapolation mode)
		{
			return default(AnimationStep.ExtrapolationMode);
		}
	}
}
