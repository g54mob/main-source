using Lofelt.NiceVibrations;
using MoreMountains.Feedbacks;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[FeedbackHelp("Use this feedback to play a preset haptic, limited but super simple predifined haptic patterns")]
	[FeedbackPath("Haptics/Haptic Preset")]
	[AddComponentMenu(null)]
	public class MMFeedbackNVPreset : MMFeedback
	{
		public static bool FeedbackTypeAuthorized;

		[Header("Haptic Preset")]
		[Tooltip("the preset to play with this feedback")]
		public HapticPatterns.PresetType Preset;

		[Header("Settings")]
		[Tooltip("a set of settings you can tweak to specify how and when exactly this haptic should play")]
		public MMFeedbackNVSettings HapticSettings;

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}
	}
}
