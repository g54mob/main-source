using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

namespace MoreMountains.FeedbacksForThirdParty
{
	[RequireComponent(typeof(Volume))]
	[AddComponentMenu("More Mountains/Feedbacks/Shakers/PostProcessing/MMVolumeBlendShaker_URP")]
	public class MMVolumeBlendShaker_URP : MMShaker
	{
		[MMInspectorGroup("Configuration", true, 50, false)]
		public bool RelativeValues = true;

		[FormerlySerializedAs("disableVolumeOnWeightZero")]
		public bool DisableVolumeOnWeightZero = true;

		[FormerlySerializedAs("disableVolumeOnStart")]
		public bool DisableVolumeOnStart = true;

		[MMInspectorGroup("Blend Shake Intensity", true, 51, false)]
		[Tooltip("the curve used to animate the amount of blend amount")]
		public AnimationCurve ShakeIntensity = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.5f, 1f), new Keyframe(1f, 0f));

		[Tooltip("the value to remap the curve's 0 to")]
		public float RemapIntensityZero;

		[Tooltip("the value to remap the curve's 1 to")]
		public float RemapIntensityOne = 1f;

		protected Volume _volume;

		protected float _initialIntensity;

		protected float _originalShakeDuration;

		protected bool _originalRelativeIntensity;

		protected AnimationCurve _originalShakeIntensity;

		protected float _originalRemapIntensityZero;

		protected float _originalRemapIntensityOne;

		protected override void Initialization()
		{
			base.Initialization();
			_volume = base.gameObject.GetComponent<Volume>();
			EvaluateEnableState();
			if (DisableVolumeOnStart)
			{
				_volume.enabled = false;
			}
		}

		protected override void Shake()
		{
			float weight = ShakeFloat(ShakeIntensity, RemapIntensityZero, RemapIntensityOne, RelativeValues, _initialIntensity);
			_volume.weight = weight;
			EvaluateEnableState();
		}

		private void EvaluateEnableState()
		{
			float weight = _volume.weight;
			if (DisableVolumeOnWeightZero)
			{
				_volume.enabled = weight > 0f;
			}
		}

		protected override void GrabInitialValues()
		{
			_initialIntensity = _volume.weight;
		}

		public virtual void OnVolumeBlendShakeEvent(AnimationCurve intensity, float duration, float remapMin, float remapMax, bool relativeIntensity = false, float attenuation = 1f, MMChannelData channelData = null, bool resetShakerValuesAfterShake = true, bool resetTargetValuesAfterShake = true, bool forwardDirection = true, TimescaleModes timescaleMode = TimescaleModes.Scaled, bool stop = false, bool restore = false)
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
				_originalRelativeIntensity = RelativeValues;
			}
			if (!OnlyUseShakerValues)
			{
				TimescaleMode = timescaleMode;
				ShakeDuration = duration;
				ShakeIntensity = intensity;
				RemapIntensityZero = remapMin * attenuation;
				RemapIntensityOne = remapMax * attenuation;
				RelativeValues = relativeIntensity;
				ForwardDirection = forwardDirection;
			}
			Play();
			EvaluateEnableState();
		}

		protected override void ResetTargetValues()
		{
			base.ResetTargetValues();
			_volume.weight = _initialIntensity;
		}

		protected override void ResetShakerValues()
		{
			base.ResetShakerValues();
			ShakeDuration = _originalShakeDuration;
			ShakeIntensity = _originalShakeIntensity;
			RemapIntensityZero = _originalRemapIntensityZero;
			RemapIntensityOne = _originalRemapIntensityOne;
			RelativeValues = _originalRelativeIntensity;
		}

		public override void StartListening()
		{
			base.StartListening();
			MMVolumeBlendShakeEvent_URP.Register(OnVolumeBlendShakeEvent);
		}

		public override void StopListening()
		{
			base.StopListening();
			MMVolumeBlendShakeEvent_URP.Unregister(OnVolumeBlendShakeEvent);
		}
	}
}
