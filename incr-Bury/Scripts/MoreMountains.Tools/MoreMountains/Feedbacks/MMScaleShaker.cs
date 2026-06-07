using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	public class MMScaleShaker : MMShaker
	{
		public enum Modes
		{
			Transform = 0,
			RectTransform = 1
		}

		[MMInspectorGroup("Target", true, 41, false)]
		[Tooltip("whether this shaker should target Transforms or RectTransforms")]
		public Modes Mode;

		[Tooltip("the transform to shake the scale of. If left blank, this component will target the transform it's put on.")]
		[MMEnumCondition("Mode", new int[] { 0 })]
		public Transform TargetTransform;

		[Tooltip("the rect transform to shake the scale of. If left blank, this component will target the transform it's put on.")]
		[MMEnumCondition("Mode", new int[] { 1 })]
		public RectTransform TargetRectTransform;

		[MMInspectorGroup("Shake Settings", true, 42, false)]
		[Tooltip("the speed at which the transform should shake")]
		public float ShakeSpeed = 20f;

		[Tooltip("the maximum distance from its initial scale the transform will move to during the shake")]
		public float ShakeRange = 0.5f;

		[MMInspectorGroup("Direction", true, 43, false)]
		[Tooltip("the direction along which to shake the transform's scale")]
		public Vector3 ShakeMainDirection = Vector3.up;

		[Tooltip("if this is true, instead of using ShakeMainDirection as the direction of the shake, a random vector3 will be generated, randomized between ShakeMainDirection and ShakeAltDirection")]
		public bool RandomizeDirection;

		[Tooltip("when in RandomizeDirection mode, a vector against which to randomize the main direction")]
		[MMCondition("RandomizeDirection", true)]
		public Vector3 ShakeAltDirection = Vector3.up;

		[Tooltip("if this is true, a new direction will be randomized every time a shake happens")]
		public bool RandomizeDirectionOnPlay;

		[MMInspectorGroup("Directional Noise", true, 47, false)]
		[Tooltip("whether or not to add noise to the main direction")]
		public bool AddDirectionalNoise = true;

		[Tooltip("when adding directional noise, noise strength will be randomized between this value and DirectionalNoiseStrengthMax")]
		[MMCondition("AddDirectionalNoise", true)]
		public Vector3 DirectionalNoiseStrengthMin = new Vector3(0.25f, 0.25f, 0.25f);

		[Tooltip("when adding directional noise, noise strength will be randomized between this value and DirectionalNoiseStrengthMin")]
		[MMCondition("AddDirectionalNoise", true)]
		public Vector3 DirectionalNoiseStrengthMax = new Vector3(0.25f, 0.25f, 0.25f);

		[MMInspectorGroup("Randomness", true, 44, false)]
		[Tooltip("a unique seed you can use to get different outcomes when shaking more than one transform at once")]
		public Vector3 RandomnessSeed;

		[Tooltip("whether or not to generate a unique seed automatically on every shake")]
		public bool RandomizeSeedOnShake = true;

		[MMInspectorGroup("One Time", true, 45, false)]
		[Tooltip("whether or not to use attenuation, which will impact the amplitude of the shake, along the defined curve")]
		public bool UseAttenuation = true;

		[Tooltip("the animation curve used to define attenuation, impacting the amplitude of the shake")]
		[MMCondition("UseAttenuation", true)]
		public AnimationCurve AttenuationCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.5f, 1f), new Keyframe(1f, 0f));

		[MMInspectorGroup("Test", true, 46, false)]
		[MMInspectorButton("StartShaking")]
		public bool StartShakingButton;

		protected float _attenuation = 1f;

		protected float _oscillation;

		protected Vector3 _initialScale;

		protected Vector3 _workDirection;

		protected Vector3 _noiseVector;

		protected Vector3 _newScale;

		protected Vector3 _randomNoiseStrength;

		protected Vector3 _noNoise = Vector3.zero;

		protected Vector3 _randomizedDirection;

		protected float _originalDuration;

		protected float _originalShakeSpeed;

		protected float _originalShakeRange;

		protected Vector3 _originalShakeMainDirection;

		protected bool _originalRandomizeDirection;

		protected Vector3 _originalShakeAltDirection;

		protected bool _originalRandomizeDirectionOnPlay;

		protected bool _originalAddDirectionalNoise;

		protected Vector3 _originalDirectionalNoiseStrengthMin;

		protected Vector3 _originalDirectionalNoiseStrengthMax;

		protected Vector3 _originalRandomnessSeed;

		protected bool _originalRandomizeSeedOnShake;

		protected bool _originalUseAttenuation;

		protected AnimationCurve _originalAttenuationCurve;

		public virtual float Randomness => RandomnessSeed.x + RandomnessSeed.y + RandomnessSeed.z;

		protected override void Initialization()
		{
			base.Initialization();
			if (TargetTransform == null)
			{
				TargetTransform = base.transform;
			}
			if (TargetRectTransform == null)
			{
				TargetRectTransform = GetComponent<RectTransform>();
			}
			GrabInitialScale();
		}

		public virtual void GrabInitialScale()
		{
			switch (Mode)
			{
			case Modes.Transform:
				_initialScale = TargetTransform.localScale;
				break;
			case Modes.RectTransform:
				_initialScale = TargetRectTransform.localScale;
				break;
			}
		}

		protected virtual void Reset()
		{
			ShakeDuration = 0.5f;
		}

		protected override void ShakeStarts()
		{
			GrabInitialScale();
			if (RandomizeSeedOnShake)
			{
				RandomnessSeed = Random.insideUnitSphere;
			}
			if (RandomizeDirectionOnPlay)
			{
				ShakeMainDirection = Random.insideUnitSphere;
				ShakeAltDirection = Random.insideUnitSphere;
			}
			_randomizedDirection = (RandomizeDirection ? MMMaths.RandomVector3(ShakeMainDirection, ShakeAltDirection) : ShakeMainDirection);
		}

		protected override void Shake()
		{
			_oscillation = Mathf.Sin(ShakeSpeed * (Randomness + _journey));
			float remappedTime = MMFeedbacksHelpers.Remap(_journey, 0f, ShakeDuration, 0f, 1f);
			_attenuation = ComputeAttenuation(remappedTime);
			_workDirection = ShakeMainDirection + ComputeNoise(_journey);
			_workDirection.Normalize();
			_newScale = ComputeNewScale();
			ApplyNewScale(_newScale);
		}

		protected override void ShakeComplete()
		{
			base.ShakeComplete();
			_attenuation = 0f;
			_newScale = ComputeNewScale();
			if (TargetTransform != null)
			{
				ApplyNewScale(_newScale);
			}
		}

		protected virtual void ApplyNewScale(Vector3 newScale)
		{
			switch (Mode)
			{
			case Modes.Transform:
				TargetTransform.localScale = newScale;
				break;
			case Modes.RectTransform:
				TargetRectTransform.localScale = newScale;
				break;
			}
		}

		protected virtual Vector3 ComputeNewScale()
		{
			return _initialScale + _workDirection * _oscillation * ShakeRange * _attenuation;
		}

		protected virtual float ComputeAttenuation(float remappedTime)
		{
			if (!UseAttenuation || PermanentShake)
			{
				return 1f;
			}
			return AttenuationCurve.Evaluate(remappedTime);
		}

		protected virtual Vector3 ComputeNoise(float time)
		{
			if (!AddDirectionalNoise)
			{
				return _noNoise;
			}
			_randomNoiseStrength = MMMaths.RandomVector3(DirectionalNoiseStrengthMin, DirectionalNoiseStrengthMax);
			_noiseVector.x = _randomNoiseStrength.x * (Mathf.PerlinNoise(RandomnessSeed.x, time) - 0.5f);
			_noiseVector.y = _randomNoiseStrength.y * (Mathf.PerlinNoise(RandomnessSeed.y, time) - 0.5f);
			_noiseVector.z = _randomNoiseStrength.z * (Mathf.PerlinNoise(RandomnessSeed.z, time) - 0.5f);
			return _noiseVector;
		}

		public virtual void OnMMScaleShakeEvent(float duration, float shakeSpeed, float shakeRange, Vector3 shakeMainDirection, bool randomizeDirection, Vector3 shakeAltDirection, bool randomizeDirectionOnPlay, bool addDirectionalNoise, Vector3 directionalNoiseStrengthMin, Vector3 directionalNoiseStrengthMax, Vector3 randomnessSeed, bool randomizeSeedOnShake, bool useAttenuation, AnimationCurve attenuationCurve, bool useRange = false, float rangeDistance = 0f, bool useRangeFalloff = false, AnimationCurve rangeFalloff = null, Vector2 remapRangeFalloff = default(Vector2), Vector3 rangePosition = default(Vector3), float feedbacksIntensity = 1f, MMChannelData channelData = null, bool resetShakerValuesAfterShake = true, bool resetTargetValuesAfterShake = true, bool forwardDirection = true, TimescaleModes timescaleMode = TimescaleModes.Scaled, bool stop = false, bool restore = false)
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
				_originalDuration = ShakeDuration;
				_originalShakeSpeed = ShakeSpeed;
				_originalShakeRange = ShakeRange;
				_originalShakeMainDirection = ShakeMainDirection;
				_originalRandomizeDirection = RandomizeDirection;
				_originalShakeAltDirection = ShakeAltDirection;
				_originalRandomizeDirectionOnPlay = RandomizeDirectionOnPlay;
				_originalAddDirectionalNoise = AddDirectionalNoise;
				_originalDirectionalNoiseStrengthMin = DirectionalNoiseStrengthMin;
				_originalDirectionalNoiseStrengthMax = DirectionalNoiseStrengthMax;
				_originalRandomnessSeed = RandomnessSeed;
				_originalRandomizeSeedOnShake = RandomizeSeedOnShake;
				_originalUseAttenuation = UseAttenuation;
				_originalAttenuationCurve = AttenuationCurve;
			}
			if (!OnlyUseShakerValues)
			{
				TimescaleMode = timescaleMode;
				ShakeDuration = duration;
				ShakeSpeed = shakeSpeed;
				ShakeRange = shakeRange * feedbacksIntensity * ComputeRangeIntensity(useRange, rangeDistance, useRangeFalloff, rangeFalloff, remapRangeFalloff, rangePosition);
				ShakeMainDirection = shakeMainDirection;
				RandomizeDirection = randomizeDirection;
				ShakeAltDirection = shakeAltDirection;
				RandomizeDirectionOnPlay = randomizeDirectionOnPlay;
				AddDirectionalNoise = addDirectionalNoise;
				DirectionalNoiseStrengthMin = directionalNoiseStrengthMin;
				DirectionalNoiseStrengthMax = directionalNoiseStrengthMax;
				RandomnessSeed = randomnessSeed;
				RandomizeSeedOnShake = randomizeSeedOnShake;
				UseAttenuation = useAttenuation;
				AttenuationCurve = attenuationCurve;
				ForwardDirection = forwardDirection;
			}
			Play();
		}

		protected override void ResetTargetValues()
		{
			base.ResetTargetValues();
			switch (Mode)
			{
			case Modes.Transform:
				TargetTransform.localScale = _initialScale;
				break;
			case Modes.RectTransform:
				TargetRectTransform.localScale = _initialScale;
				break;
			}
		}

		protected override void ResetShakerValues()
		{
			base.ResetShakerValues();
			ShakeDuration = _originalDuration;
			ShakeSpeed = _originalShakeSpeed;
			ShakeRange = _originalShakeRange;
			ShakeMainDirection = _originalShakeMainDirection;
			RandomizeDirection = _originalRandomizeDirection;
			ShakeAltDirection = _originalShakeAltDirection;
			RandomizeDirectionOnPlay = _originalRandomizeDirectionOnPlay;
			AddDirectionalNoise = _originalAddDirectionalNoise;
			DirectionalNoiseStrengthMin = _originalDirectionalNoiseStrengthMin;
			DirectionalNoiseStrengthMax = _originalDirectionalNoiseStrengthMax;
			RandomnessSeed = _originalRandomnessSeed;
			RandomizeSeedOnShake = _originalRandomizeSeedOnShake;
			UseAttenuation = _originalUseAttenuation;
			AttenuationCurve = _originalAttenuationCurve;
		}

		public override void StartListening()
		{
			base.StartListening();
			MMScaleShakeEvent.Register(OnMMScaleShakeEvent);
		}

		public override void StopListening()
		{
			base.StopListening();
			MMScaleShakeEvent.Unregister(OnMMScaleShakeEvent);
		}
	}
}
