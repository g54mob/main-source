using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackPath("Transform/Scale Shake")]
	[FeedbackHelp("This feedback lets you emit a ScaleShake event. This will be caught by MMScaleShakers (on the specified channel). Scale shakers, as the name suggests, are used to shake the scale of a transform, along a direction, with optional noise and other fine control options.")]
	public class MMF_ScaleShake : MMF_Feedback
	{
		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Optional Target", true, 33, false, false)]
		[Tooltip("a specific (and optional) shaker to target, regardless of its channel")]
		public MMScaleShaker TargetShaker;

		[MMFInspectorGroup("Scale Shake", true, 28, false, false)]
		[Tooltip("the duration of the shake, in seconds")]
		public float Duration = 0.5f;

		[Tooltip("whether or not to reset shaker values after shake")]
		public bool ResetShakerValuesAfterShake = true;

		[Tooltip("whether or not to reset the target's values after shake")]
		public bool ResetTargetValuesAfterShake = true;

		[MMFInspectorGroup("Shake Settings", true, 42, false, false)]
		[Tooltip("the speed at which the transform should shake")]
		public float ShakeSpeed = 20f;

		[Tooltip("the maximum distance from its initial scale the transform will move to during the shake")]
		public float ShakeRange = 0.5f;

		[MMFInspectorGroup("Direction", true, 43, false, false)]
		[Tooltip("the direction along which to shake the transform's scale")]
		public Vector3 ShakeMainDirection = Vector3.up;

		[Tooltip("if this is true, instead of using ShakeMainDirection as the direction of the shake, a random vector3 will be generated, randomized between ShakeMainDirection and ShakeAltDirection")]
		public bool RandomizeDirection;

		[Tooltip("when in RandomizeDirection mode, a vector against which to randomize the main direction")]
		[MMFCondition("RandomizeDirection", true)]
		public Vector3 ShakeAltDirection = Vector3.up;

		[Tooltip("if this is true, a new direction will be randomized every time a shake happens")]
		public bool RandomizeDirectionOnPlay;

		[MMFInspectorGroup("Directional Noise", true, 47, false, false)]
		[Tooltip("whether or not to add noise to the main direction")]
		public bool AddDirectionalNoise = true;

		[Tooltip("when adding directional noise, noise strength will be randomized between this value and DirectionalNoiseStrengthMax")]
		[MMFCondition("AddDirectionalNoise", true)]
		public Vector3 DirectionalNoiseStrengthMin = new Vector3(0.25f, 0.25f, 0.25f);

		[Tooltip("when adding directional noise, noise strength will be randomized between this value and DirectionalNoiseStrengthMin")]
		[MMFCondition("AddDirectionalNoise", true)]
		public Vector3 DirectionalNoiseStrengthMax = new Vector3(0.25f, 0.25f, 0.25f);

		[MMFInspectorGroup("Randomness", true, 44, false, false)]
		[Tooltip("a unique seed you can use to get different outcomes when shaking more than one transform at once")]
		public Vector3 RandomnessSeed;

		[Tooltip("whether or not to generate a unique seed automatically on every shake")]
		public bool RandomizeSeedOnShake = true;

		[MMFInspectorGroup("One Time", true, 45, false, false)]
		[Tooltip("whether or not to use attenuation, which will impact the amplitude of the shake, along the defined curve")]
		public bool UseAttenuation = true;

		[Tooltip("the animation curve used to define attenuation, impacting the amplitude of the shake")]
		[MMFCondition("UseAttenuation", true)]
		public AnimationCurve AttenuationCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.5f, 1f), new Keyframe(1f, 0f));

		public override float FeedbackDuration
		{
			get
			{
				return ApplyTimeMultiplier(Duration);
			}
			set
			{
				Duration = value;
			}
		}

		public override bool HasChannel => true;

		public override bool HasRandomness => true;

		protected override void CustomPlayFeedback(Vector3 scale, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized)
			{
				float feedbacksIntensity2 = ComputeIntensity(feedbacksIntensity);
				if (TargetShaker == null)
				{
					MMScaleShakeEvent.Trigger(Duration, ShakeSpeed, ShakeRange, ShakeMainDirection, RandomizeDirection, ShakeAltDirection, RandomizeDirectionOnPlay, AddDirectionalNoise, DirectionalNoiseStrengthMin, DirectionalNoiseStrengthMax, RandomnessSeed, RandomizeSeedOnShake, UseAttenuation, AttenuationCurve, feedbacksIntensity2, Channel, ResetShakerValuesAfterShake, ResetTargetValuesAfterShake, NormalPlayDirection, ComputedTimescaleMode);
				}
				else
				{
					TargetShaker?.OnMMScaleShakeEvent(Duration, ShakeSpeed, ShakeRange, ShakeMainDirection, RandomizeDirection, ShakeAltDirection, RandomizeDirectionOnPlay, AddDirectionalNoise, DirectionalNoiseStrengthMin, DirectionalNoiseStrengthMax, RandomnessSeed, RandomizeSeedOnShake, UseAttenuation, AttenuationCurve, feedbacksIntensity2, TargetShaker.Channel, ResetShakerValuesAfterShake, ResetTargetValuesAfterShake, NormalPlayDirection, ComputedTimescaleMode);
				}
			}
		}

		protected override void CustomStopFeedback(Vector3 scale, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized)
			{
				base.CustomStopFeedback(scale, feedbacksIntensity);
				if (TargetShaker == null)
				{
					MMScaleShakeEvent.Trigger(Duration, ShakeSpeed, ShakeRange, ShakeMainDirection, RandomizeDirection, ShakeAltDirection, RandomizeDirectionOnPlay, AddDirectionalNoise, DirectionalNoiseStrengthMin, DirectionalNoiseStrengthMax, RandomnessSeed, RandomizeSeedOnShake, UseAttenuation, AttenuationCurve, 1f, 0, resetShakerValuesAfterShake: true, resetTargetValuesAfterShake: true, forwardDirection: true, TimescaleModes.Scaled, stop: true);
				}
				else
				{
					TargetShaker?.OnMMScaleShakeEvent(Duration, ShakeSpeed, ShakeRange, ShakeMainDirection, RandomizeDirection, ShakeAltDirection, RandomizeDirectionOnPlay, AddDirectionalNoise, DirectionalNoiseStrengthMin, DirectionalNoiseStrengthMax, RandomnessSeed, RandomizeSeedOnShake, UseAttenuation, AttenuationCurve, 1f, TargetShaker.Channel, resetShakerValuesAfterShake: true, resetTargetValuesAfterShake: true, forwardDirection: true, TimescaleModes.Scaled, stop: true);
				}
			}
		}
	}
}
