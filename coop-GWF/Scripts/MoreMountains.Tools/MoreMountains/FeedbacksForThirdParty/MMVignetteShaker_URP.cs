using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace MoreMountains.FeedbacksForThirdParty
{
	[RequireComponent(typeof(Volume))]
	[AddComponentMenu("More Mountains/Feedbacks/Shakers/PostProcessing/MMVignetteShaker_URP")]
	public class MMVignetteShaker_URP : MMShaker
	{
		[MMInspectorGroup("Vignette Intensity", true, 63, false)]
		[Tooltip("whether or not to add to the initial value")]
		public bool RelativeIntensity;

		[Tooltip("the curve used to animate the intensity value on")]
		public AnimationCurve ShakeIntensity = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.5f, 1f), new Keyframe(1f, 0f));

		[Tooltip("the value to remap the curve's 0 to")]
		[Range(0f, 1f)]
		public float RemapIntensityZero;

		[Tooltip("the value to remap the curve's 1 to")]
		[Range(0f, 1f)]
		public float RemapIntensityOne = 1f;

		[MMFInspectorGroup("Vignette Color", true, 60, false, false)]
		[Tooltip("whether or not to also animate the vignette's color")]
		public bool InterpolateColor;

		[Tooltip("the curve to animate the color on")]
		public AnimationCurve ColorCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.05f, 1f), new Keyframe(0.95f, 1f), new Keyframe(1f, 0f));

		[Tooltip("the value to remap the curve's 0 to")]
		[Range(0f, 1f)]
		public float RemapColorZero;

		[Tooltip("the value to remap the curve's 1 to")]
		[Range(0f, 1f)]
		public float RemapColorOne = 1f;

		[Tooltip("the color to lerp towards")]
		public Color TargetColor = Color.red;

		protected Volume _volume;

		protected Vignette _vignette;

		protected float _initialIntensity;

		protected float _originalShakeDuration;

		protected AnimationCurve _originalShakeIntensity;

		protected float _originalRemapIntensityZero;

		protected float _originalRemapIntensityOne;

		protected bool _originalRelativeIntensity;

		protected bool _originalInterpolateColor;

		protected AnimationCurve _originalColorCurve;

		protected float _originalRemapColorZero;

		protected float _originalRemapColorOne;

		protected Color _originalTargetColor;

		protected Color _initialColor;

		protected override void Initialization()
		{
			base.Initialization();
			_volume = base.gameObject.GetComponent<Volume>();
			_volume.profile.TryGet<Vignette>(out _vignette);
		}

		protected override void Shake()
		{
			float x = ShakeFloat(ShakeIntensity, RemapIntensityZero, RemapIntensityOne, RelativeIntensity, _initialIntensity);
			_vignette.intensity.Override(x);
			if (InterpolateColor)
			{
				float t = ShakeFloat(ColorCurve, RemapColorZero, RemapColorOne, RelativeIntensity, 0f);
				_vignette.color.Override(Color.Lerp(_initialColor, TargetColor, t));
			}
		}

		protected override void GrabInitialValues()
		{
			_initialIntensity = _vignette.intensity.value;
		}

		public virtual void OnVignetteShakeEvent(AnimationCurve intensity, float duration, float remapMin, float remapMax, bool relativeIntensity = false, float attenuation = 1f, MMChannelData channelData = null, bool resetShakerValuesAfterShake = true, bool resetTargetValuesAfterShake = true, bool forwardDirection = true, TimescaleModes timescaleMode = TimescaleModes.Scaled, bool stop = false, bool restore = false, bool interpolateColor = false, AnimationCurve colorCurve = null, float remapColorZero = 0f, float remapColorOne = 1f, Color targetColor = default(Color))
		{
			if (!CheckEventAllowed(channelData) || (!Interruptible && Shaking))
			{
				return;
			}
			if (stop)
			{
				Stop();
				return;
			}
			if (restore)
			{
				ResetTargetValues();
				return;
			}
			_resetShakerValuesAfterShake = resetShakerValuesAfterShake;
			_resetTargetValuesAfterShake = resetTargetValuesAfterShake;
			if (resetShakerValuesAfterShake)
			{
				_originalShakeDuration = ShakeDuration;
				_originalShakeIntensity = ShakeIntensity;
				_originalRemapIntensityZero = RemapIntensityZero;
				_originalRemapIntensityOne = RemapIntensityOne;
				_originalRelativeIntensity = RelativeIntensity;
				_originalInterpolateColor = InterpolateColor;
				_originalColorCurve = ColorCurve;
				_originalRemapColorZero = RemapColorZero;
				_originalRemapColorOne = RemapColorOne;
				_originalTargetColor = TargetColor;
			}
			if (!OnlyUseShakerValues)
			{
				TimescaleMode = timescaleMode;
				ShakeDuration = duration;
				ShakeIntensity = intensity;
				RemapIntensityZero = remapMin * attenuation;
				RemapIntensityOne = remapMax * attenuation;
				RelativeIntensity = relativeIntensity;
				ForwardDirection = forwardDirection;
				InterpolateColor = interpolateColor;
				ColorCurve = colorCurve;
				RemapColorZero = remapColorZero;
				RemapColorOne = remapColorOne;
				TargetColor = targetColor;
			}
			Play();
		}

		protected override void ResetTargetValues()
		{
			base.ResetTargetValues();
			_vignette.intensity.Override(_initialIntensity);
		}

		protected override void ResetShakerValues()
		{
			base.ResetShakerValues();
			ShakeDuration = _originalShakeDuration;
			ShakeIntensity = _originalShakeIntensity;
			RemapIntensityZero = _originalRemapIntensityZero;
			RemapIntensityOne = _originalRemapIntensityOne;
			RelativeIntensity = _originalRelativeIntensity;
			InterpolateColor = _originalInterpolateColor;
			ColorCurve = _originalColorCurve;
			RemapColorZero = _originalRemapColorZero;
			RemapColorOne = _originalRemapColorOne;
			TargetColor = _originalTargetColor;
		}

		public override void StartListening()
		{
			base.StartListening();
			MMVignetteShakeEvent_URP.Register(OnVignetteShakeEvent);
		}

		public override void StopListening()
		{
			base.StopListening();
			MMVignetteShakeEvent_URP.Unregister(OnVignetteShakeEvent);
		}
	}
}
