using Lofelt.NiceVibrations;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("")]
	[FeedbackPath("Haptics/Haptic Clip")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks.NiceVibrations", null)]
	[FeedbackHelp("This feedback will let you play a haptic clip, and randomize its level and frequency.")]
	public class MMF_NVClip : MMF_Feedback
	{
		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Haptic Clip", true, 13, true, false)]
		[Tooltip("the haptic clip to play with this feedback")]
		public HapticClip Clip;

		[Tooltip("a preset to play should the device you're running your game on doesn't support playing haptic clips")]
		public HapticPatterns.PresetType FallbackPreset = HapticPatterns.PresetType.LightImpact;

		[Tooltip("whether or not this clip should play on a loop, until stopped (won't work on gamepads)")]
		public bool Loop;

		[Tooltip("at what timestamp this clip should start playing")]
		public float SeekTime;

		public MMF_Button TestHapticButton;

		[MMFInspectorGroup("Audio To Haptic", true, 14, false, false)]
		[Tooltip("the label of the MMSM Sound feedback you want to convert the audio clip from. If left empty, will find the first on this MMF Player")]
		[MMFInformation("While you can set a clip in the field above, this feedback also offers the option to automatically convert a MMSM Sound feedback's audio clip into a haptic clip. This is a great way to save time, while retaining fine control over amplitude and frequency.\n\n To do it, you'll need a MMSM Sound feedback with a clip on that same MMF Player. If you have more than one, you can specify the label of the feedback you're after in the field below. Then, press the convert button. You can then press the Test button below to try your haptic and audio together and see if you like them.\n\nYou can then normalize amplitude and/or frequency for gamepad to your liking. The first curve shows the haptic file for iOS/Android, the second curve shows rumble data.", MMFInformationAttribute.InformationType.Info, false)]
		public string MMSMSoundFeedbackLabel;

		[Tooltip("the sample count is the resolution at which the haptic clip will be computed")]
		public int SampleCount = 256;

		[Header("Amplitude")]
		[Tooltip("whether or not to normalize amplitude for the gamepad rumble")]
		public bool NormalizeAmplitude = true;

		[Tooltip("the factor to use when normalizing amplitude")]
		[MMFCondition("NormalizeAmplitude", true)]
		public float NormalizeAmplitudeFactor = 1f;

		[Header("Frequency")]
		[Tooltip("whether or not to normalize frequency for the gamepad rumble")]
		public bool NormalizeFrequency = true;

		[Tooltip("the factor to use when normalizing frequency")]
		[MMFCondition("NormalizeFrequency", true)]
		public float NormalizeFrequencyFactor = 1f;

		public MMF_Button ConvertButton;

		public MMF_Button TestHapticAudioButton;

		public NVHapticData HapticData;

		[MMFInspectorGroup("Level", true, 14, false, false)]
		[Tooltip("the minimum level at which this clip should play (level will be randomized between MinLevel and MaxLevel)")]
		[Range(0f, 5f)]
		public float MinLevel = 1f;

		[Tooltip("the maximum level at which this clip should play (level will be randomized between MinLevel and MaxLevel)")]
		[Range(0f, 5f)]
		public float MaxLevel = 1f;

		[MMFInspectorGroup("Frequency Shift", true, 15, false, false)]
		[Tooltip("the minimum frequency shift at which this clip should play (frequency shift will be randomized between MinFrequencyShift and MaxFrequencyShift)")]
		[Range(-1f, 1f)]
		public float MinFrequencyShift;

		[Tooltip("the maximum frequency shift at which this clip should play (frequency shift will be randomized between MinFrequencyShift and MaxFrequencyShift)")]
		[Range(-1f, 1f)]
		public float MaxFrequencyShift;

		[MMFInspectorGroup("Settings", true, 16, false, false)]
		[Tooltip("a set of settings you can tweak to specify how and when exactly this haptic should play")]
		public MMFeedbackNVSettings HapticSettings;

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized && HapticSettings != null && HapticSettings.CanPlay() && !(Clip == null))
			{
				PlayHapticClip();
			}
		}

		protected virtual void PlayHapticClip()
		{
			if (!(Clip == null))
			{
				HapticSettings.SetGamepad();
				HapticController.Load(Clip);
				HapticController.fallbackPreset = FallbackPreset;
				HapticController.Loop(Loop);
				HapticController.Seek(SeekTime);
				HapticController.clipLevel = Random.Range(MinLevel, MaxLevel);
				HapticController.clipFrequencyShift = Random.Range(MinFrequencyShift, MaxFrequencyShift);
				HapticController.Play();
			}
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (FeedbackTypeAuthorized)
			{
				base.CustomStopFeedback(position, feedbacksIntensity);
				IsPlaying = false;
				HapticController.Stop();
			}
		}

		public override void InitializeCustomAttributes()
		{
			base.InitializeCustomAttributes();
			ConvertButton = new MMF_Button("Convert MMSM Sound feedback Audio Clip to Haptic", Convert);
			TestHapticAudioButton = new MMF_Button("Test Haptic and Audio", TestHapticAndAudio);
			TestHapticButton = new MMF_Button("Test Haptic", PlayHapticClip);
		}

		protected virtual void TestHapticAndAudio()
		{
			Owner.GetFeedbackOfType<MMF_MMSoundManagerSound>(MMSMSoundFeedbackLabel)?.TestPlaySound();
			PlayHapticClip();
		}

		protected virtual void Convert()
		{
		}
	}
}
