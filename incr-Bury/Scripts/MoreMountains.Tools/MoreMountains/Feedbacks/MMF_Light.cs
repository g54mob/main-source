using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback lets you control the color and intensity of a Light in your scene for a certain duration (or instantly).")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks", null)]
	[FeedbackPath("Lights/Light")]
	public class MMF_Light : MMF_Feedback
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
		public Light BoundLight;

		[Tooltip("a list of optional extra lights to also affect when playing the feedback")]
		public List<Light> ExtraLights;

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

		[MMFInspectorGroup("Range", true, 40, true, false)]
		[Tooltip("whether or not to modify the range of the light")]
		public bool ModifyRange = true;

		[Tooltip("the range to apply to the light over time")]
		[MMFEnumCondition("Mode", new int[] { 0, 2, 3 })]
		public AnimationCurve RangeCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.3f, 1f), new Keyframe(1f, 0f));

		[Tooltip("the value to remap the range curve's 0 to")]
		[MMFEnumCondition("Mode", new int[] { 0, 2 })]
		public float RemapRangeZero;

		[Tooltip("the value to remap the range curve's 0 to")]
		[MMFEnumCondition("Mode", new int[] { 0, 2 })]
		public float RemapRangeOne = 10f;

		[Tooltip("the value to move the intensity to in instant mode")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public float InstantRange = 10f;

		[Tooltip("the value to move the intensity to in ToDestination mode")]
		[MMFEnumCondition("Mode", new int[] { 3 })]
		public float ToDestinationRange = 10f;

		[MMFInspectorGroup("Shadow Strength", true, 41, true, false)]
		[Tooltip("whether or not to modify the shadow strength of the light")]
		public bool ModifyShadowStrength = true;

		[Tooltip("the range to apply to the light over time")]
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

		protected float _initialRange;

		protected float _initialShadowStrength;

		protected float _initialIntensity;

		protected Color _initialColor;

		protected Coroutine _coroutine;

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
			BoundLight = FindAutomatedTarget<Light>();
		}

		protected override void CustomInitialization(MMF_Player owner)
		{
			base.CustomInitialization(owner);
			if (ExtraLights == null)
			{
				ExtraLights = new List<Light>();
			}
			if (ColorOverTime == null)
			{
				ColorOverTime = new Gradient();
			}
			if (!(BoundLight == null))
			{
				_initialRange = BoundLight.range;
				_initialShadowStrength = BoundLight.shadowStrength;
				_initialIntensity = BoundLight.intensity;
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
			if (!Active || !FeedbackTypeAuthorized)
			{
				return;
			}
			if (Mode == Modes.ToDestination)
			{
				_initialRange = BoundLight.range;
				_initialShadowStrength = BoundLight.shadowStrength;
				_initialIntensity = BoundLight.intensity;
				_initialColor = BoundLight.color;
			}
			float num = ComputeIntensity(feedbacksIntensity, position);
			Turn(status: true);
			switch (Mode)
			{
			case Modes.Instant:
				BoundLight.intensity = (NormalPlayDirection ? (InstantIntensity * num) : _initialIntensity);
				BoundLight.shadowStrength = (NormalPlayDirection ? InstantShadowStrength : _initialShadowStrength);
				BoundLight.range = (NormalPlayDirection ? InstantRange : _initialRange);
				if (ModifyColor)
				{
					BoundLight.color = (NormalPlayDirection ? InstantColor : _initialColor);
				}
				{
					foreach (Light extraLight in ExtraLights)
					{
						extraLight.intensity = BoundLight.intensity;
						extraLight.shadowStrength = BoundLight.shadowStrength;
						extraLight.range = BoundLight.range;
						if (ModifyColor)
						{
							extraLight.color = BoundLight.color;
						}
					}
					break;
				}
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
				MMLightShakeEvent.Trigger(FeedbackDuration, RelativeValues, ModifyColor, ColorOverTime, IntensityCurve, RemapIntensityZero, RemapIntensityOne, RangeCurve, RemapRangeZero * num, RemapRangeOne * num, ShadowStrengthCurve, RemapShadowStrengthZero, RemapShadowStrengthOne, feedbacksIntensity, ChannelData, ResetShakerValuesAfterShake, ResetTargetValuesAfterShake, OnlyBroadcastInRange, EventRange, EventOriginTransform.position);
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
			switch (Mode)
			{
			case Modes.OverTime:
				num = MMFeedbacksHelpers.Remap(IntensityCurve.Evaluate(time), 0f, 1f, RemapIntensityZero, RemapIntensityOne);
				num2 = MMFeedbacksHelpers.Remap(RangeCurve.Evaluate(time), 0f, 1f, RemapRangeZero, RemapRangeOne);
				num3 = MMFeedbacksHelpers.Remap(ShadowStrengthCurve.Evaluate(time), 0f, 1f, RemapShadowStrengthZero, RemapShadowStrengthOne);
				_targetColor = ColorOverTime.Evaluate(time);
				break;
			case Modes.ToDestination:
				num = Mathf.Lerp(_initialIntensity, ToDestinationIntensity, IntensityCurve.Evaluate(time));
				num2 = Mathf.Lerp(_initialRange, ToDestinationRange, RangeCurve.Evaluate(time));
				num3 = Mathf.Lerp(_initialShadowStrength, ToDestinationShadowStrength, ShadowStrengthCurve.Evaluate(time));
				_targetColor = Color.Lerp(_initialColor, ToDestinationColor, time);
				break;
			}
			if (RelativeValues && Mode != Modes.ToDestination)
			{
				num += _initialIntensity;
				num3 += _initialShadowStrength;
				num2 += _initialRange;
			}
			if (ModifyIntensity)
			{
				if (BoundLight != null)
				{
					BoundLight.intensity = num * intensityMultiplier;
				}
				foreach (Light extraLight in ExtraLights)
				{
					extraLight.intensity = num * intensityMultiplier;
				}
			}
			if (ModifyRange)
			{
				if (BoundLight != null)
				{
					BoundLight.range = num2;
				}
				foreach (Light extraLight2 in ExtraLights)
				{
					extraLight2.range = num2;
				}
			}
			if (ModifyShadowStrength)
			{
				if (BoundLight != null)
				{
					BoundLight.shadowStrength = Mathf.Clamp01(num3);
				}
				foreach (Light extraLight3 in ExtraLights)
				{
					extraLight3.shadowStrength = Mathf.Clamp01(num3);
				}
			}
			if (!ModifyColor)
			{
				return;
			}
			if (BoundLight != null)
			{
				BoundLight.color = _targetColor;
			}
			foreach (Light extraLight4 in ExtraLights)
			{
				extraLight4.color = _targetColor;
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
			if (BoundLight != null)
			{
				BoundLight.enabled = status;
			}
			foreach (Light extraLight in ExtraLights)
			{
				extraLight.enabled = status;
			}
		}

		protected override void CustomRestoreInitialValues()
		{
			if (!Active || !FeedbackTypeAuthorized)
			{
				return;
			}
			BoundLight.range = _initialRange;
			BoundLight.shadowStrength = _initialShadowStrength;
			BoundLight.intensity = _initialIntensity;
			BoundLight.color = _initialColor;
			foreach (Light extraLight in ExtraLights)
			{
				extraLight.range = _initialRange;
				extraLight.shadowStrength = _initialShadowStrength;
				extraLight.intensity = _initialIntensity;
				extraLight.color = _initialColor;
			}
			if (StartsOff)
			{
				Turn(status: false);
			}
		}
	}
}
