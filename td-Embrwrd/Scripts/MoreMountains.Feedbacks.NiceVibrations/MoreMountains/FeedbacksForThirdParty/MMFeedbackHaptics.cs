using MoreMountains.Feedbacks;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu(null)]
	[FeedbackHelp("This feedback has been deprecated, and is just here to avoid errors in case you were to update from an old version. Use the new haptic feedbacks instead.")]
	[FeedbackPath("Haptics/Haptics DEPRECATED!")]
	public class MMFeedbackHaptics : MMFeedback
	{
		public enum HapticTypes
		{
			Selection = 0,
			Success = 1,
			Warning = 2,
			Failure = 3,
			LightImpact = 4,
			MediumImpact = 5,
			HeavyImpact = 6,
			RigidImpact = 7,
			SoftImpact = 8,
			None = 9
		}

		public enum HapticMethods
		{
			NativePreset = 0,
			Transient = 1,
			Continuous = 2,
			AdvancedPattern = 3,
			Stop = 4,
			AdvancedTransient = 5,
			AdvancedContinuous = 6
		}

		public enum Timescales
		{
			ScaledTime = 0,
			UnscaledTime = 1
		}

		public static bool FeedbackTypeAuthorized;

		[Header("Haptics")]
		[Tooltip("the method to use when triggering this haptic feedback")]
		public HapticMethods HapticMethod;

		[Tooltip("the type of native preset to use")]
		[MMFEnumCondition("HapticMethod", new int[] { 0 })]
		public HapticTypes HapticType;

		[MMFEnumCondition("HapticMethod", new int[] { 1 })]
		[Tooltip("the intensity of the transient haptic")]
		public float TransientIntensity;

		[Tooltip("the sharpness of the transient haptic")]
		[MMFEnumCondition("HapticMethod", new int[] { 1 })]
		public float TransientSharpness;

		[Tooltip("whether or not to vibrate on iOS when in AdvancedTransient mode")]
		[MMFEnumCondition("HapticMethod", new int[] { 5 })]
		public bool ATVibrateIOS;

		[Tooltip("the intensity on iOS when in AdvancedTransient mode")]
		[MMFEnumCondition("HapticMethod", new int[] { 5 })]
		public float ATIOSIntensity;

		[Tooltip("the sharpness on iOS when in AdvancedTransient mode")]
		[MMFEnumCondition("HapticMethod", new int[] { 5 })]
		public float ATIOSSharpness;

		[MMFEnumCondition("HapticMethod", new int[] { 5 })]
		[Tooltip("whether or not to vibrate on android when in AdvancedTransient mode")]
		public bool ATVibrateAndroid;

		[MMFEnumCondition("HapticMethod", new int[] { 5 })]
		[Tooltip("whether or not to vibrate on android if no support for advanced vibrations when in AdvancedTransient mode")]
		public bool ATVibrateAndroidIfNoSupport;

		[MMFEnumCondition("HapticMethod", new int[] { 5 })]
		[Tooltip("the intensity on android when in AdvancedTransient mode")]
		public float ATAndroidIntensity;

		[Tooltip("the sharpness on android when in AdvancedTransient mode")]
		[MMFEnumCondition("HapticMethod", new int[] { 5 })]
		public float ATAndroidSharpness;

		[Tooltip("whether or not to rumble when in AdvancedTransient mode")]
		[MMFEnumCondition("HapticMethod", new int[] { 5 })]
		public bool ATRumble;

		[Tooltip("the rumble intensity when in AdvancedTransient mode")]
		[MMFEnumCondition("HapticMethod", new int[] { 5 })]
		public float ATRumbleIntensity;

		[Tooltip("the rumble sharpness when in AdvancedTransient mode")]
		[MMFEnumCondition("HapticMethod", new int[] { 5 })]
		public float ATRumbleSharpness;

		[Tooltip("the controllerID when in AdvancedTransient mode")]
		[MMFEnumCondition("HapticMethod", new int[] { 5 })]
		public int ATRumbleControllerID;

		[Tooltip("the intensity that should be used to initialize the continuous haptic")]
		[MMFEnumCondition("HapticMethod", new int[] { 2 })]
		public float InitialContinuousIntensity;

		[Tooltip("the curve used to tween the continuous intensity")]
		[MMFEnumCondition("HapticMethod", new int[] { 2 })]
		public AnimationCurve ContinuousIntensityCurve;

		[MMFEnumCondition("HapticMethod", new int[] { 2 })]
		[Tooltip("the sharpness that should be used to initialize the continuous haptic")]
		public float InitialContinuousSharpness;

		[MMFEnumCondition("HapticMethod", new int[] { 2 })]
		[Tooltip("the curve used to tween the continuous sharpness")]
		public AnimationCurve ContinuousSharpnessCurve;

		[MMFEnumCondition("HapticMethod", new int[] { 2 })]
		[Tooltip("the duration of the continuous haptic")]
		public float ContinuousDuration;

		[Tooltip("whether or not to trigger advanced patterns on iOS")]
		[MMFEnumCondition("HapticMethod", new int[] { 3 })]
		public bool APVibrateIOS;

		[MMFEnumCondition("HapticMethod", new int[] { 3 })]
		[Tooltip("the AHAP file to use to trigger a pattern on iOS")]
		public TextAsset AHAPFileForIOS;

		[Tooltip("whether or not to trigger advanced patterns on Android")]
		[MMFEnumCondition("HapticMethod", new int[] { 3 })]
		public bool APVibrateAndroid;

		[Tooltip("whether or not to vibrate if there's no haptics support")]
		[MMFEnumCondition("HapticMethod", new int[] { 3 })]
		public bool APVibrateAndroidIfNoSupport;

		[Tooltip("whether or not to trigger advanced patterns on rumble")]
		[MMFEnumCondition("HapticMethod", new int[] { 3 })]
		public bool APRumble;

		[Tooltip("the amount of times this should repeat on Android (-1 : zero, 0 : infinite, 1 : one time, 2 : twice, etc)")]
		[MMFEnumCondition("HapticMethod", new int[] { 3 })]
		public int AndroidRepeat;

		public int RumbleRepeat;

		[Tooltip("a haptic type to play on older iOS APIs (prior to iOS 13)")]
		[MMFEnumCondition("HapticMethod", new int[] { 3 })]
		public HapticTypes OldIOSFallback;

		[MMFEnumCondition("HapticMethod", new int[] { 3 })]
		[Tooltip("whether to run this on scaled or unscaled time")]
		public Timescales Timescale;

		[Tooltip("whether or not this feedback should trigger a rumble on gamepad")]
		[Header("Rumble")]
		public bool AllowRumble;

		[Tooltip("the ID of the controller to rumble (-1 : auto/current, 0 : first controller, 1 : second controller, etc)")]
		public int ControllerID;

		[Header("Deprecated Feedback")]
		public bool OutputDeprecationWarning;

		protected static bool _continuousPlaying;

		protected static float _continuousStartedAt;

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
		}
	}
}
