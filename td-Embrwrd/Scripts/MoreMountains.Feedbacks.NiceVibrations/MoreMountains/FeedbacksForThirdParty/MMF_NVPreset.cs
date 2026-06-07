using Lofelt.NiceVibrations;
using MoreMountains.Feedbacks;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[FeedbackHelp("Use this feedback to play a preset haptic, limited but super simple predifined haptic patterns")]
	[FeedbackPath("Haptics/Haptic Preset")]
	[AddComponentMenu(null)]
	public class MMF_NVPreset : MMF_Feedback
	{
		public static bool FeedbackTypeAuthorized;

		[Tooltip("the preset to play with this feedback")]
		[MMFInspectorGroup("Haptic Preset", true, 21, false, false)]
		public HapticPatterns.PresetType Preset;

		[Tooltip("a set of settings you can tweak to specify how and when exactly this haptic should play")]
		[MMFInspectorGroup("Settings", true, 16, false, false)]
		public MMFeedbackNVSettings HapticSettings;

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}
	}
}
