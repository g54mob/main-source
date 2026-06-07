using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	public class MMPositionShaker : MMShaker
	{
		public enum Modes
		{
			Transform = 0,
			RectTransform = 1
		}

		[MMInspectorGroup("Target", true, 41)]
		[Tooltip("whether this shaker should target Transforms or RectTransforms")]
		public Modes Mode;

		[Tooltip("the transform to shake the position of. If left blank, this component will target the transform it's put on.")]
		[MMEnumCondition("Mode", new int[] { 0 })]
		public Transform TargetTransform;

		[MMEnumCondition("Mode", new int[] { 1 })]
		[Tooltip("the rect transform to shake the position of. If left blank, this component will target the transform it's put on.")]
		public RectTransform TargetRectTransform;

		[Tooltip("the speed at which the transform should shake")]
		[MMInspectorGroup("Shake Settings", true, 42)]
		public float ShakeSpeed;

		[Tooltip("the maximum distance from its initial position the transform will move to during the shake")]
		public float ShakeRange;

		[Tooltip("an offset to apply to the oscillation")]
		public float OscillationOffset;

		[MMInspectorGroup("Direction", true, 43)]
		[Tooltip("the direction along which to shake the transform's position")]
		public Vector3 ShakeMainDirection;

		[Tooltip("if this is true, instead of using ShakeMainDirection as the direction of the shake, a random vector3 will be generated, randomized between ShakeMainDirection and ShakeAltDirection")]
		public bool RandomizeDirection;

		[MMCondition("RandomizeDirection", true)]
		[Tooltip("when in RandomizeDirection mode, a vector against which to randomize the main direction")]
		public Vector3 ShakeAltDirection;

		[Tooltip("if this is true, a new direction will be randomized every time a shake happens")]
		public bool RandomizeDirectionOnPlay;

		[Tooltip("whether or not to add noise to the main direction")]
		[MMInspectorGroup("Directional Noise", true, 47)]
		public bool AddDirectionalNoise;

		[Tooltip("when adding directional noise, noise strength will be randomized between this value and DirectionalNoiseStrengthMax")]
		[MMCondition("AddDirectionalNoise", true)]
		public Vector3 DirectionalNoiseStrengthMin;

		[MMCondition("AddDirectionalNoise", true)]
		[Tooltip("when adding directional noise, noise strength will be randomized between this value and DirectionalNoiseStrengthMin")]
		public Vector3 DirectionalNoiseStrengthMax;

		[Tooltip("a unique seed you can use to get different outcomes when shaking more than one transform at once")]
		[MMInspectorGroup("Randomness", true, 44)]
		public Vector3 RandomnessSeed;

		[Tooltip("whether or not to generate a unique seed automatically on every shake")]
		public bool RandomizeSeedOnShake;

		[MMInspectorGroup("One Time", true, 45)]
		[Tooltip("whether or not to use attenuation, which will impact the amplitude of the shake, along the defined curve")]
		public bool UseAttenuation;

		[Tooltip("the animation curve used to define attenuation, impacting the amplitude of the shake")]
		[MMCondition("UseAttenuation", true)]
		public AnimationCurve AttenuationCurve;

		[MMInspectorGroup("Test", true, 46)]
		[MMInspectorButton("StartShaking")]
		public bool StartShakingButton;

		protected float _attenuation;

		protected float _oscillation;

		protected Vector3 _initialPosition;

		protected Vector3 _workDirection;

		protected Vector3 _noiseVector;

		protected Vector3 _newPosition;

		protected Vector3 _randomNoiseStrength;

		protected Vector3 _noNoise;

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

		public virtual float Randomness => 0f;

		protected override void Initialization()
		{
		}

		protected virtual void GrabInitialPosition()
		{
		}

		protected virtual void Reset()
		{
		}

		protected override void ShakeStarts()
		{
		}

		protected override void Shake()
		{
		}

		protected override void ShakeComplete()
		{
		}

		protected virtual void ApplyNewPosition(Vector3 newPosition)
		{
		}

		protected virtual Vector3 ComputeNewPosition()
		{
			return default(Vector3);
		}

		protected virtual float ComputeAttenuation(float remappedTime)
		{
			return 0f;
		}

		protected virtual Vector3 ComputeNoise(float time)
		{
			return default(Vector3);
		}

		public virtual void OnMMPositionShakeEvent(float duration, float shakeSpeed, float shakeRange, Vector3 shakeMainDirection, bool randomizeDirection, Vector3 shakeAltDirection, bool randomizeDirectionOnPlay, bool addDirectionalNoise, Vector3 directionalNoiseStrengthMin, Vector3 directionalNoiseStrengthMax, Vector3 randomnessSeed, bool randomizeSeedOnShake, bool useAttenuation, AnimationCurve attenuationCurve, bool useRange = false, float rangeDistance = 0f, bool useRangeFalloff = false, AnimationCurve rangeFalloff = null, Vector2 remapRangeFalloff = default(Vector2), Vector3 rangePosition = default(Vector3), float feedbacksIntensity = 1f, MMChannelData channelData = null, bool resetShakerValuesAfterShake = true, bool resetTargetValuesAfterShake = true, bool forwardDirection = true, TimescaleModes timescaleMode = TimescaleModes.Scaled, bool stop = false, bool restore = false)
		{
		}

		protected override void ResetTargetValues()
		{
		}

		protected override void ResetShakerValues()
		{
		}

		public override void StartListening()
		{
		}

		public override void StopListening()
		{
		}
	}
}
