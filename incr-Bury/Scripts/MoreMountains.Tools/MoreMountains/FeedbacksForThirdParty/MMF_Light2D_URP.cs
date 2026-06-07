using System.Collections;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will let you control a 2D light's intensity, color, falloff, shadow strength and volumetric intensity over time, or instantly.")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks", null)]
	[FeedbackPath("Lights/Light2D_URP")]
	public class MMF_Light2D_URP : MMF_Feedback
	{
		public enum Modes
		{
			OverTime = 0,
			Instant = 1,
			ShakerEvent = 2,
			ToDestination = 3
		}

		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Light", true, 37, true, false)]
		[Tooltip("the light to affect when playing the feedback")]
		public Light2D BoundLight;

		[Tooltip("whether the feedback should affect the light instantly or over a period of time")]
		public Modes Mode;

		[Tooltip("how long the light should change over time")]
		[MMFEnumCondition("Mode", new int[] { 0, 2, 3 })]
		public float Duration = 0.2f;

		[Tooltip("whether or not that light should be turned off on start")]
		public bool StartsOff = true;

		[Tooltip("if this is true, the light will be disabled when this feedbacks is stopped")]
		public bool DisableOnStop;

		[Tooltip("whether or not the values should be relative or not")]
		[MMFEnumCondition("Mode", new int[] { 0, 2, 1 })]
		public bool RelativeValues = true;

		[Tooltip("whether or not to reset shaker values after shake")]
		[MMFEnumCondition("Mode", new int[] { 2 })]
		public bool ResetShakerValuesAfterShake = true;

		[Tooltip("whether or not to reset the target's values after shake")]
		[MMFEnumCondition("Mode", new int[] { 2 })]
		public bool ResetTargetValuesAfterShake = true;

		[Tooltip("whether or not to broadcast a range to only affect certain shakers")]
		[MMFEnumCondition("Mode", new int[] { 2 })]
		public bool OnlyBroadcastInRange;

		[Tooltip("the range of the event, in units")]
		[MMFEnumCondition("Mode", new int[] { 2 })]
		public float EventRange = 100f;

		[Tooltip("the transform to use to broadcast the event as origin point")]
		[MMFEnumCondition("Mode", new int[] { 2 })]
		public Transform EventOriginTransform;

		[Tooltip("if this is true, calling that feedback will trigger it, even if it's in progress. If it's false, it'll prevent any new Play until the current one is over")]
		public bool AllowAdditivePlays;

		[MMFInspectorGroup("Color", true, 38, true, false)]
		[Tooltip("whether or not to modify the color of the light")]
		public bool ModifyColor = true;

		[Tooltip("the colors to apply to the light over time")]
		[MMFEnumCondition("Mode", new int[] { 0, 2 })]
		public Gradient ColorOverTime;

		[Tooltip("the color to move to in instant mode")]
		[MMFEnumCondition("Mode", new int[] { 1, 2 })]
		public Color InstantColor = Color.red;

		[Tooltip("the color to move to in destination mode")]
		[MMFEnumCondition("Mode", new int[] { 3 })]
		public Color ToDestinationColor = Color.red;

		[MMFInspectorGroup("Intensity", true, 39, true, false)]
		[Tooltip("whether or not to modify the intensity of the light")]
		public bool ModifyIntensity = true;

		[Tooltip("the curve to tween the intensity on")]
		[MMFEnumCondition("Mode", new int[] { 0, 2, 3 })]
		public AnimationCurve IntensityCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.3f, 1f), new Keyframe(1f, 0f));

		[Tooltip("the value to remap the intensity curve's 0 to")]
		[MMFEnumCondition("Mode", new int[] { 0, 2 })]
		public float RemapIntensityZero;

		[Tooltip("the value to remap the intensity curve's 1 to")]
		[MMFEnumCondition("Mode", new int[] { 0, 2 })]
		public float RemapIntensityOne = 1f;

		[Tooltip("the value to move the intensity to in instant mode")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public float InstantIntensity = 1f;

		[Tooltip("the value to move the intensity to in ToDestination mode")]
		[MMFEnumCondition("Mode", new int[] { 3 })]
		public float ToDestinationIntensity = 1f;

		[MMFInspectorGroup("Falloff", true, 40, true, false)]
		[Tooltip("whether or not to modify the falloff of the light")]
		public bool ModifyFalloff = true;

		[Tooltip("the falloff to apply to the light over time")]
		[MMFEnumCondition("Mode", new int[] { 0, 2, 3 })]
		public AnimationCurve FalloffCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.3f, 1f), new Keyframe(1f, 0f));

		[Tooltip("the value to remap the falloff curve's 0 to")]
		[MMFEnumCondition("Mode", new int[] { 0, 2 })]
		public float RemapFalloffZero;

		[Tooltip("the value to remap the falloff curve's 0 to")]
		[MMFEnumCondition("Mode", new int[] { 0, 2 })]
		public float RemapFalloffOne = 10f;

		[Tooltip("the value to move the intensity to in instant mode")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public float InstantFalloff = 10f;

		[Tooltip("the value to move the intensity to in ToDestination mode")]
		[MMFEnumCondition("Mode", new int[] { 3 })]
		public float ToDestinationFalloff = 10f;

		[MMFInspectorGroup("Shadow Strength", true, 41, true, false)]
		[Tooltip("whether or not to modify the shadow strength of the light")]
		public bool ModifyShadowStrength = true;

		[Tooltip("the shadow strength to apply to the light over time")]
		[MMFEnumCondition("Mode", new int[] { 0, 2, 3 })]
		public AnimationCurve ShadowStrengthCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.3f, 1f), new Keyframe(1f, 0f));

		[Tooltip("the value to remap the shadow strength's curve's 0 to")]
		[MMFEnumCondition("Mode", new int[] { 0, 2 })]
		public float RemapShadowStrengthZero;

		[Tooltip("the value to remap the shadow strength's curve's 1 to")]
		[MMFEnumCondition("Mode", new int[] { 0, 2 })]
		public float RemapShadowStrengthOne = 1f;

		[Tooltip("the value to move the shadow strength to in instant mode")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public float InstantShadowStrength = 1f;

		[Tooltip("the value to move the shadow strength to in ToDestination mode")]
		[MMFEnumCondition("Mode", new int[] { 3 })]
		public float ToDestinationShadowStrength = 1f;

		[MMFInspectorGroup("Volumetric Intensity", true, 39, true, false)]
		[Tooltip("whether or not to modify the volumetric intensity of the light")]
		public bool ModifyVolumetricIntensity = true;

		[Tooltip("the curve to tween the volumetric intensity on")]
		[MMFEnumCondition("Mode", new int[] { 0, 2, 3 })]
		public AnimationCurve VolumetricIntensityCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.3f, 1f), new Keyframe(1f, 0f));

		[Tooltip("the value to remap the volumetric intensity curve's 0 to")]
		[MMFEnumCondition("Mode", new int[] { 0, 2 })]
		public float RemapVolumetricIntensityZero;

		[Tooltip("the value to remap the volumetric intensity curve's 1 to")]
		[MMFEnumCondition("Mode", new int[] { 0, 2 })]
		public float RemapVolumetricIntensityOne = 1f;

		[Tooltip("the value to move the volumetric intensity to in instant mode")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public float InstantVolumetricIntensity = 1f;

		[Tooltip("the value to move the volumetric intensity to in ToDestination mode")]
		[MMFEnumCondition("Mode", new int[] { 3 })]
		public float ToDestinationVolumetricIntensity = 1f;

		protected float _initialFalloff;

		protected float _initialShadowStrength;

		protected float _initialIntensity;

		protected float _initialVolumetricIntensity;

		protected Coroutine _coroutine;

		protected Color _initialColor;

		protected Color _targetColor;

		public override float FeedbackDuration
		{
			get
			{
				if (Mode != Modes.Instant)
				{
					return ApplyTimeMultiplier(Duration);
				}
				return 0f;
			}
			set
			{
				Duration = value;
			}
		}

		public override bool HasChannel => true;

		public override bool HasRandomness => true;

		public override bool HasAutomatedTargetAcquisition => true;

		protected override void AutomateTargetAcquisition()
		{
			BoundLight = FindAutomatedTarget<Light2D>();
		}

		protected override void CustomInitialization(MMF_Player owner)
		{
			base.CustomInitialization(owner);
			if (!(BoundLight == null))
			{
				if (ColorOverTime == null)
				{
					ColorOverTime = new Gradient();
				}
				_initialFalloff = BoundLight.shapeLightFalloffSize;
				_initialShadowStrength = BoundLight.shadowIntensity;
				_initialIntensity = BoundLight.intensity;
				_initialVolumetricIntensity = BoundLight.volumeIntensity;
				_initialColor = BoundLight.color;
				if (EventOriginTransform == null)
				{
					EventOriginTransform = owner.transform;
				}
				if (Active && StartsOff)
				{
					Turn(status: false);
				}
			}
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (!Active || !FeedbackTypeAuthorized || BoundLight == null)
			{
				return;
			}
			if (Mode == Modes.ToDestination)
			{
				_initialFalloff = BoundLight.shapeLightFalloffSize;
				_initialShadowStrength = BoundLight.shadowIntensity;
				_initialIntensity = BoundLight.intensity;
				_initialIntensity = BoundLight.volumeIntensity;
				_initialColor = BoundLight.color;
			}
			float num = ComputeIntensity(feedbacksIntensity, position);
			Turn(status: true);
			switch (Mode)
			{
			case Modes.Instant:
				BoundLight.intensity = InstantIntensity * num;
				BoundLight.intensity = InstantVolumetricIntensity * num;
				BoundLight.shadowIntensity = InstantShadowStrength;
				BoundLight.shapeLightFalloffSize = InstantFalloff;
				if (ModifyColor)
				{
					BoundLight.color = InstantColor;
				}
				break;
			case Modes.OverTime:
			case Modes.ToDestination:
				if (AllowAdditivePlays || _coroutine == null)
				{
					if (_coroutine != null)
					{
						Owner.StopCoroutine(_coroutine);
					}
					_coroutine = Owner.StartCoroutine(LightSequence(num));
				}
				break;
			case Modes.ShakerEvent:
				if (EventOriginTransform == null)
				{
					EventOriginTransform = Owner.transform;
				}
				MMLight2DShakeEvent.Trigger(FeedbackDuration, RelativeValues, ModifyColor, ColorOverTime, IntensityCurve, RemapIntensityZero, RemapIntensityOne, FalloffCurve, RemapFalloffZero * num, RemapFalloffOne * num, ShadowStrengthCurve, RemapShadowStrengthZero, RemapShadowStrengthOne, feedbacksIntensity, ChannelData, ResetShakerValuesAfterShake, ResetTargetValuesAfterShake, OnlyBroadcastInRange, EventRange, EventOriginTransform.position);
				break;
			}
		}

		protected virtual IEnumerator LightSequence(float intensityMultiplier)
		{
			IsPlaying = true;
			float journey = (NormalPlayDirection ? 0f : FeedbackDuration);
			while (journey >= 0f && journey <= FeedbackDuration && FeedbackDuration > 0f)
			{
				float time = MMFeedbacksHelpers.Remap(journey, 0f, FeedbackDuration, 0f, 1f);
				SetLightValues(time, intensityMultiplier);
				journey += (NormalPlayDirection ? FeedbackDeltaTime : (0f - FeedbackDeltaTime));
				yield return null;
			}
			SetLightValues(FinalNormalizedTime, intensityMultiplier);
			if (DisableOnStop)
			{
				Turn(status: false);
			}
			IsPlaying = false;
			_coroutine = null;
			yield return null;
		}

		protected virtual void SetLightValues(float time, float intensityMultiplier)
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			switch (Mode)
			{
			case Modes.OverTime:
				num = MMFeedbacksHelpers.Remap(IntensityCurve.Evaluate(time), 0f, 1f, RemapIntensityZero, RemapIntensityOne);
				num2 = MMFeedbacksHelpers.Remap(VolumetricIntensityCurve.Evaluate(time), 0f, 1f, RemapVolumetricIntensityZero, RemapVolumetricIntensityOne);
				num3 = MMFeedbacksHelpers.Remap(FalloffCurve.Evaluate(time), 0f, 1f, RemapFalloffZero, RemapFalloffOne);
				num4 = MMFeedbacksHelpers.Remap(ShadowStrengthCurve.Evaluate(time), 0f, 1f, RemapShadowStrengthZero, RemapShadowStrengthOne);
				_targetColor = ColorOverTime.Evaluate(time);
				break;
			case Modes.ToDestination:
				num = Mathf.Lerp(_initialIntensity, ToDestinationIntensity, IntensityCurve.Evaluate(time));
				num2 = Mathf.Lerp(_initialVolumetricIntensity, ToDestinationVolumetricIntensity, VolumetricIntensityCurve.Evaluate(time));
				num3 = Mathf.Lerp(_initialFalloff, ToDestinationFalloff, FalloffCurve.Evaluate(time));
				num4 = Mathf.Lerp(_initialShadowStrength, ToDestinationShadowStrength, ShadowStrengthCurve.Evaluate(time));
				_targetColor = Color.Lerp(_initialColor, ToDestinationColor, time);
				break;
			}
			if (RelativeValues && Mode != Modes.ToDestination)
			{
				num += _initialIntensity;
				num2 += _initialVolumetricIntensity;
				num4 += _initialShadowStrength;
				num3 += _initialFalloff;
			}
			if (ModifyIntensity)
			{
				BoundLight.intensity = num * intensityMultiplier;
			}
			if (ModifyVolumetricIntensity)
			{
				BoundLight.volumeIntensity = num2 * intensityMultiplier;
			}
			if (ModifyFalloff)
			{
				BoundLight.shapeLightFalloffSize = num3;
			}
			if (ModifyShadowStrength)
			{
				BoundLight.shadowIntensity = Mathf.Clamp01(num4);
			}
			if (ModifyColor)
			{
				BoundLight.color = _targetColor;
			}
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (FeedbackTypeAuthorized)
			{
				base.CustomStopFeedback(position, feedbacksIntensity);
				IsPlaying = false;
				if (Active && _coroutine != null)
				{
					Owner.StopCoroutine(_coroutine);
					_coroutine = null;
				}
				if (Active && DisableOnStop)
				{
					Turn(status: false);
				}
			}
		}

		protected virtual void Turn(bool status)
		{
			if (!(BoundLight == null))
			{
				BoundLight.enabled = status;
			}
		}

		protected override void CustomRestoreInitialValues()
		{
			if (Active && FeedbackTypeAuthorized)
			{
				BoundLight.shapeLightFalloffSize = _initialFalloff;
				BoundLight.shadowIntensity = _initialShadowStrength;
				BoundLight.intensity = _initialIntensity;
				BoundLight.volumeIntensity = _initialVolumetricIntensity;
				BoundLight.color = _initialColor;
				if (StartsOff)
				{
					Turn(status: false);
				}
			}
		}
	}
}
