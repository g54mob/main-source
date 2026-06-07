using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("More Mountains/Feedbacks/Shakers/Lights/MMLight2DShaker_URP")]
	[RequireComponent(typeof(Light2D))]
	public class MMLight2DShaker_URP : MMShaker
	{
		[MMInspectorGroup("Light", true, 37, false)]
		[Tooltip("the light to affect when playing the feedback")]
		public Light2D BoundLight;

		[Tooltip("whether or not that light should be turned off on start")]
		public bool StartsOff = true;

		[Tooltip("whether or not the values should be relative or not")]
		public bool RelativeValues = true;

		[MMInspectorGroup("Color", true, 41, false)]
		[Tooltip("whether or not this shaker should modify color")]
		public bool ModifyColor = true;

		[Tooltip("the colors to apply to the light over time")]
		public Gradient ColorOverTime;

		[MMInspectorGroup("Intensity", true, 40, false)]
		[Tooltip("the intensity to apply to the light over time")]
		public AnimationCurve IntensityCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.3f, 1f), new Keyframe(1f, 0f));

		[Tooltip("the value to remap the intensity curve's 0 to")]
		public float RemapIntensityZero;

		[Tooltip("the value to remap the intensity curve's 1 to")]
		public float RemapIntensityOne = 1f;

		[MMInspectorGroup("Range", true, 39, false)]
		[Tooltip("the range to apply to the light over time")]
		public AnimationCurve FalloffCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.3f, 1f), new Keyframe(1f, 0f));

		[Tooltip("the value to remap the range curve's 0 to")]
		public float FalloffRangeZero;

		[Tooltip("the value to remap the range curve's 0 to")]
		public float RemapFalloffOne = 10f;

		[MMInspectorGroup("Shadow Strength", true, 38, false)]
		[Tooltip("the range to apply to the light over time")]
		public AnimationCurve ShadowStrengthCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.3f, 1f), new Keyframe(1f, 0f));

		[Tooltip("the value to remap the shadow strength's curve's 0 to")]
		public float RemapShadowStrengthZero;

		[Tooltip("the value to remap the shadow strength's curve's 1 to")]
		public float RemapShadowStrengthOne = 1f;

		protected Color _initialColor;

		protected float _initialRange;

		protected float _initialIntensity;

		protected float _initialShadowStrength;

		protected bool _originalRelativeValues;

		protected bool _originalModifyColor;

		protected float _originalShakeDuration;

		protected Gradient _originalColorOverTime;

		protected AnimationCurve _originalIntensityCurve;

		protected float _originalRemapIntensityZero;

		protected float _originalRemapIntensityOne;

		protected AnimationCurve _originalRangeCurve;

		protected float _originalRemapRangeZero;

		protected float _originalRemapRangeOne;

		protected AnimationCurve _originalShadowStrengthCurve;

		protected float _originalRemapShadowStrengthZero;

		protected float _originalRemapShadowStrengthOne;

		protected override void Initialization()
		{
			base.Initialization();
			if (BoundLight == null)
			{
				BoundLight = base.gameObject.GetComponent<Light2D>();
			}
		}

		protected virtual void Reset()
		{
			ShakeDuration = 1f;
		}

		protected override void Shake()
		{
			float shapeLightFalloffSize = ShakeFloat(FalloffCurve, FalloffRangeZero, RemapFalloffOne, RelativeValues, _initialRange);
			BoundLight.shapeLightFalloffSize = shapeLightFalloffSize;
			float intensity = ShakeFloat(IntensityCurve, RemapIntensityZero, RemapIntensityOne, RelativeValues, _initialIntensity);
			BoundLight.intensity = intensity;
			float value = ShakeFloat(ShadowStrengthCurve, RemapShadowStrengthZero, RemapShadowStrengthOne, RelativeValues, _initialShadowStrength);
			BoundLight.shadowIntensity = Mathf.Clamp01(value);
			if (ModifyColor)
			{
				BoundLight.color = ColorOverTime.Evaluate(_remappedTimeSinceStart);
			}
		}

		protected override void GrabInitialValues()
		{
			_initialColor = BoundLight.color;
			_initialRange = BoundLight.shapeLightFalloffSize;
			_initialIntensity = BoundLight.intensity;
			_initialShadowStrength = BoundLight.shadowIntensity;
		}

		protected override void ResetTargetValues()
		{
			base.ResetTargetValues();
			BoundLight.color = _initialColor;
			BoundLight.shapeLightFalloffSize = _initialRange;
			BoundLight.intensity = _initialIntensity;
			BoundLight.shadowIntensity = _initialShadowStrength;
		}

		protected override void ResetShakerValues()
		{
			base.ResetShakerValues();
			ModifyColor = _originalModifyColor;
			RelativeValues = _originalRelativeValues;
			ShakeDuration = _originalShakeDuration;
			ColorOverTime = _originalColorOverTime;
			IntensityCurve = _originalIntensityCurve;
			RemapIntensityZero = _originalRemapIntensityZero;
			RemapIntensityOne = _originalRemapIntensityOne;
			FalloffCurve = _originalRangeCurve;
			FalloffRangeZero = _originalRemapRangeZero;
			RemapFalloffOne = _originalRemapRangeOne;
			ShadowStrengthCurve = _originalShadowStrengthCurve;
			RemapShadowStrengthZero = _originalRemapShadowStrengthZero;
			RemapShadowStrengthOne = _originalRemapShadowStrengthOne;
		}

		public override void StartListening()
		{
			base.StartListening();
			MMLight2DShakeEvent.Register(OnMMLight2DShakeEvent);
		}

		public override void StopListening()
		{
			base.StopListening();
			MMLight2DShakeEvent.Unregister(OnMMLight2DShakeEvent);
		}

		public virtual void OnMMLight2DShakeEvent(float shakeDuration, bool relativeValues, bool modifyColor, Gradient colorOverTime, AnimationCurve intensityCurve, float remapIntensityZero, float remapIntensityOne, AnimationCurve rangeCurve, float remapRangeZero, float remapRangeOne, AnimationCurve shadowStrengthCurve, float remapShadowStrengthZero, float remapShadowStrengthOne, float feedbacksIntensity = 1f, MMChannelData channelData = null, bool resetShakerValuesAfterShake = true, bool resetTargetValuesAfterShake = true, bool useRange = false, float eventRange = 0f, Vector3 eventOriginPosition = default(Vector3))
		{
			if (CheckEventAllowed(channelData, useRange, eventRange, eventOriginPosition) && (Interruptible || !Shaking))
			{
				_resetShakerValuesAfterShake = resetShakerValuesAfterShake;
				_resetTargetValuesAfterShake = resetTargetValuesAfterShake;
				if (resetShakerValuesAfterShake)
				{
					_originalModifyColor = ModifyColor;
					_originalRelativeValues = RelativeValues;
					_originalShakeDuration = ShakeDuration;
					_originalColorOverTime = ColorOverTime;
					_originalIntensityCurve = IntensityCurve;
					_originalRemapIntensityZero = RemapIntensityZero;
					_originalRemapIntensityOne = RemapIntensityOne;
					_originalRangeCurve = FalloffCurve;
					_originalRemapRangeZero = FalloffRangeZero;
					_originalRemapRangeOne = RemapFalloffOne;
					_originalShadowStrengthCurve = ShadowStrengthCurve;
					_originalRemapShadowStrengthZero = RemapShadowStrengthZero;
					_originalRemapShadowStrengthOne = RemapShadowStrengthOne;
				}
				if (!OnlyUseShakerValues)
				{
					ModifyColor = modifyColor;
					RelativeValues = relativeValues;
					ShakeDuration = shakeDuration;
					ColorOverTime = colorOverTime;
					IntensityCurve = intensityCurve;
					RemapIntensityZero = remapIntensityZero;
					RemapIntensityOne = remapIntensityOne;
					FalloffCurve = rangeCurve;
					FalloffRangeZero = remapRangeZero;
					RemapFalloffOne = remapRangeOne;
					ShadowStrengthCurve = shadowStrengthCurve;
					RemapShadowStrengthZero = remapShadowStrengthZero;
					RemapShadowStrengthOne = remapShadowStrengthOne;
				}
				Play();
			}
		}
	}
}
