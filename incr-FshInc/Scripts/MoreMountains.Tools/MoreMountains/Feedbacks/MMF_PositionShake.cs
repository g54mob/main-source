using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks", null)]
	[FeedbackPath("Transform/Position Shake")]
	[FeedbackHelp("This feedback lets you emit a PositionShake event. This will be caught by MMPositionShakers (on the specified channel). Position shakers, as the name suggests, are used to shake the position of a transform, along a direction, with optional noise and other fine control options.")]
	public class MMF_PositionShake : MMF_Feedback
	{
		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Optional Target", true, 33, false, false)]
		[Tooltip("a specific (and optional) shaker to target, regardless of its channel")]
		public MMPositionShaker TargetShaker;

		[MMFInspectorGroup("Position Shake", true, 28, false, false)]
		[Tooltip("the duration of the shake, in seconds")]
		public float Duration = 0.5f;

		[Tooltip("whether or not to reset shaker values after shake")]
		public bool ResetShakerValuesAfterShake = true;

		[Tooltip("whether or not to reset the target's values after shake")]
		public bool ResetTargetValuesAfterShake = true;

		[MMFInspectorGroup("Shake Settings", true, 42, false, false)]
		[Tooltip("the speed at which the transform should shake")]
		public float ShakeSpeed = 20f;

		[Tooltip("the maximum distance from its initial position the transform will move to during the shake")]
		public float ShakeRange = 0.5f;

		[MMFInspectorGroup("Direction", true, 43, false, false)]
		[Tooltip("the direction along which to shake the transform's position")]
		public Vector3 ShakeMainDirection = Vector3.up;

		[Tooltip("if this is true, instead of using ShakeMainDirection as the direction of the shake, a random vector3 will be generated, randomized between ShakeMainDirection and ShakeAltDirection")]
		public bool RandomizeDirection;

		[Tooltip("when in RandomizeDirection mode, a vector against which to randomize the main direction")]
		[MMFCondition("RandomizeDirection", true)]
		public Vector3 ShakeAltDirection = Vector3.up;

		[Tooltip("if this is true, a new direction will be randomized every time a shake happens")]
		public bool RandomizeDirectionOnPlay;

		[Tooltip("whether or not to randomize the x value of the main direction")]
		public bool RandomizeDirectionX = true;

		[Tooltip("whether or not to randomize the y value of the main direction")]
		public bool RandomizeDirectionY = true;

		[Tooltip("whether or not to randomize the z value of the main direction")]
		public bool RandomizeDirectionZ = true;

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

		public override bool HasRange => true;

		public override bool HasAutomatedTargetAcquisition => true;

		protected override void AutomateTargetAcquisition()
		{
			TargetShaker = FindAutomatedTarget<MMPositionShaker>();
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized)
			{
				float feedbacksIntensity2 = ComputeIntensity(feedbacksIntensity, position);
				if (TargetShaker == null)
				{
					MMPositionShakeEvent.Trigger(FeedbackDuration, ShakeSpeed, ShakeRange, ShakeMainDirection, RandomizeDirection, ShakeAltDirection, RandomizeDirectionOnPlay, RandomizeDirectionX, RandomizeDirectionY, RandomizeDirectionZ, AddDirectionalNoise, DirectionalNoiseStrengthMin, DirectionalNoiseStrengthMax, RandomnessSeed, RandomizeSeedOnShake, UseAttenuation, AttenuationCurve, UseRange, RangeDistance, UseRangeFalloff, RangeFalloff, RemapRangeFalloff, position, feedbacksIntensity2, ChannelData, ResetShakerValuesAfterShake, ResetTargetValuesAfterShake, NormalPlayDirection, ComputedTimescaleMode);
				}
				else
				{
					TargetShaker?.OnMMPositionShakeEvent(FeedbackDuration, ShakeSpeed, ShakeRange, ShakeMainDirection, RandomizeDirection, ShakeAltDirection, RandomizeDirectionOnPlay, RandomizeDirectionX, RandomizeDirectionY, RandomizeDirectionZ, AddDirectionalNoise, DirectionalNoiseStrengthMin, DirectionalNoiseStrengthMax, RandomnessSeed, RandomizeSeedOnShake, UseAttenuation, AttenuationCurve, UseRange, RangeDistance, UseRangeFalloff, RangeFalloff, RemapRangeFalloff, position, feedbacksIntensity2, TargetShaker.ChannelData, ResetShakerValuesAfterShake, ResetTargetValuesAfterShake, NormalPlayDirection, ComputedTimescaleMode);
				}
			}
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (!Active || !FeedbackTypeAuthorized)
			{
				return;
			}
			base.CustomStopFeedback(position, feedbacksIntensity);
			if (TargetShaker == null)
			{
				MMPositionShakeEvent.Trigger(FeedbackDuration, ShakeSpeed, ShakeRange, ShakeMainDirection, RandomizeDirection, ShakeAltDirection, RandomizeDirectionOnPlay, RandomizeDirectionX, RandomizeDirectionY, RandomizeDirectionZ, AddDirectionalNoise, DirectionalNoiseStrengthMin, DirectionalNoiseStrengthMax, RandomnessSeed, RandomizeSeedOnShake, UseAttenuation, AttenuationCurve, useRange: false, 0f, useRangeFalloff: false, null, default(Vector2), default(Vector3), 1f, null, resetShakerValuesAfterShake: true, resetTargetValuesAfterShake: true, forwardDirection: true, TimescaleModes.Scaled, stop: true);
				return;
			}
			MMPositionShaker targetShaker = TargetShaker;
			if ((object)targetShaker != null)
			{
				float feedbackDuration = FeedbackDuration;
				float shakeSpeed = ShakeSpeed;
				float shakeRange = ShakeRange;
				Vector3 shakeMainDirection = ShakeMainDirection;
				bool randomizeDirection = RandomizeDirection;
				Vector3 shakeAltDirection = ShakeAltDirection;
				bool randomizeDirectionOnPlay = RandomizeDirectionOnPlay;
				bool randomizeDirectionX = RandomizeDirectionX;
				bool randomizeDirectionY = RandomizeDirectionY;
				bool randomizeDirectionZ = RandomizeDirectionZ;
				bool addDirectionalNoise = AddDirectionalNoise;
				Vector3 directionalNoiseStrengthMin = DirectionalNoiseStrengthMin;
				Vector3 directionalNoiseStrengthMax = DirectionalNoiseStrengthMax;
				Vector3 randomnessSeed = RandomnessSeed;
				bool randomizeSeedOnShake = RandomizeSeedOnShake;
				bool useAttenuation = UseAttenuation;
				AnimationCurve attenuationCurve = AttenuationCurve;
				MMChannelData channelData = TargetShaker.ChannelData;
				targetShaker.OnMMPositionShakeEvent(feedbackDuration, shakeSpeed, shakeRange, shakeMainDirection, randomizeDirection, shakeAltDirection, randomizeDirectionOnPlay, randomizeDirectionX, randomizeDirectionY, randomizeDirectionZ, addDirectionalNoise, directionalNoiseStrengthMin, directionalNoiseStrengthMax, randomnessSeed, randomizeSeedOnShake, useAttenuation, attenuationCurve, useRange: false, 0f, useRangeFalloff: false, null, default(Vector2), default(Vector3), 1f, channelData, resetShakerValuesAfterShake: true, resetTargetValuesAfterShake: true, forwardDirection: true, TimescaleModes.Scaled, stop: true);
			}
		}

		protected override void CustomRestoreInitialValues()
		{
			if (!Active || !FeedbackTypeAuthorized)
			{
				return;
			}
			if (TargetShaker == null)
			{
				MMPositionShakeEvent.Trigger(FeedbackDuration, ShakeSpeed, ShakeRange, ShakeMainDirection, RandomizeDirection, ShakeAltDirection, RandomizeDirectionOnPlay, RandomizeDirectionX, RandomizeDirectionY, RandomizeDirectionZ, AddDirectionalNoise, DirectionalNoiseStrengthMin, DirectionalNoiseStrengthMax, RandomnessSeed, RandomizeSeedOnShake, UseAttenuation, AttenuationCurve, useRange: false, 0f, useRangeFalloff: false, null, default(Vector2), default(Vector3), 1f, null, resetShakerValuesAfterShake: true, resetTargetValuesAfterShake: true, forwardDirection: true, TimescaleModes.Scaled, stop: false, restore: true);
				return;
			}
			MMPositionShaker targetShaker = TargetShaker;
			if ((object)targetShaker != null)
			{
				float feedbackDuration = FeedbackDuration;
				float shakeSpeed = ShakeSpeed;
				float shakeRange = ShakeRange;
				Vector3 shakeMainDirection = ShakeMainDirection;
				bool randomizeDirection = RandomizeDirection;
				Vector3 shakeAltDirection = ShakeAltDirection;
				bool randomizeDirectionOnPlay = RandomizeDirectionOnPlay;
				bool randomizeDirectionX = RandomizeDirectionX;
				bool randomizeDirectionY = RandomizeDirectionY;
				bool randomizeDirectionZ = RandomizeDirectionZ;
				bool addDirectionalNoise = AddDirectionalNoise;
				Vector3 directionalNoiseStrengthMin = DirectionalNoiseStrengthMin;
				Vector3 directionalNoiseStrengthMax = DirectionalNoiseStrengthMax;
				Vector3 randomnessSeed = RandomnessSeed;
				bool randomizeSeedOnShake = RandomizeSeedOnShake;
				bool useAttenuation = UseAttenuation;
				AnimationCurve attenuationCurve = AttenuationCurve;
				MMChannelData channelData = TargetShaker.ChannelData;
				targetShaker.OnMMPositionShakeEvent(feedbackDuration, shakeSpeed, shakeRange, shakeMainDirection, randomizeDirection, shakeAltDirection, randomizeDirectionOnPlay, randomizeDirectionX, randomizeDirectionY, randomizeDirectionZ, addDirectionalNoise, directionalNoiseStrengthMin, directionalNoiseStrengthMax, randomnessSeed, randomizeSeedOnShake, useAttenuation, attenuationCurve, useRange: false, 0f, useRangeFalloff: false, null, default(Vector2), default(Vector3), 1f, channelData, resetShakerValuesAfterShake: true, resetTargetValuesAfterShake: true, forwardDirection: true, TimescaleModes.Scaled, stop: false, restore: true);
			}
		}
	}
}
