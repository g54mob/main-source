using MoreMountains.Feedbacks;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu(null)]
	[FeedbackPath("Haptics/Haptic Emphasis")]
	[FeedbackHelp("Use this feedback to play an Emphasis haptics, short haptic bursts whose amplitude and frequency can be controlled in real time, also called Transients in CoreHaptics/iOS")]
	public class MMF_NVEmphasis : MMF_Feedback
	{
		public static bool FeedbackTypeAuthorized;

		[MMFInspectorGroup("Haptic Amplitude", true, 23, false, false)]
		[Tooltip("the minimum amplitude at which this clip should play (amplitude will be randomized between MinAmplitude and MaxAmplitude)")]
		[Range(0f, 1f)]
		public float MinAmplitude;

		[Range(0f, 1f)]
		[Tooltip("the maximum amplitude at which this clip should play (amplitude will be randomized between MinAmplitude and MaxAmplitude)")]
		public float MaxAmplitude;

		[Range(0f, 1f)]
		[Tooltip("the minimum frequency at which this clip should play (frequency will be randomized between MinFrequency and MaxFrequency)")]
		[MMFInspectorGroup("Haptic Frequency", true, 22, false, false)]
		public float MinFrequency;

		[Range(0f, 1f)]
		[Tooltip("the maximum frequency at which this clip should play (frequency will be randomized between MinFrequency and MaxFrequency)")]
		public float MaxFrequency;

		[Tooltip("a set of settings you can tweak to specify how and when exactly this haptic should play")]
		[MMFInspectorGroup("Settings", true, 16, false, false)]
		public MMFeedbackNVSettings HapticSettings;

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}
	}
}
