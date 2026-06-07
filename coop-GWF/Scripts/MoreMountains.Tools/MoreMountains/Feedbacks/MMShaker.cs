using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	public class MMShaker : MMMonoBehaviour
	{
		[MMInspectorGroup("Shaker Settings", true, 3, false)]
		[Tooltip("whether to listen on a channel defined by an int or by a MMChannel scriptable object. Ints are simple to setup but can get messy and make it harder to remember what int corresponds to what. MMChannel scriptable objects require you to create them in advance, but come with a readable name and are more scalable")]
		public MMChannelModes ChannelMode;

		[Tooltip("the channel to listen to - has to match the one on the feedback")]
		[MMEnumCondition("ChannelMode", new int[] { 0 })]
		public int Channel;

		[Tooltip("the MMChannel definition asset to use to listen for events. The feedbacks targeting this shaker will have to reference that same MMChannel definition to receive events - to create a MMChannel, right click anywhere in your project (usually in a Data folder) and go MoreMountains > MMChannel, then name it with some unique name")]
		[MMEnumCondition("ChannelMode", new int[] { 1 })]
		public MMChannel MMChannelDefinition;

		[Tooltip("the duration of the shake, in seconds")]
		public float ShakeDuration = 0.2f;

		[Tooltip("if this is true this shaker will play on awake")]
		public bool PlayOnAwake;

		[Tooltip("if this is true, the shaker will shake permanently as long as its game object is active")]
		public bool PermanentShake;

		[Tooltip("if this is true, a new shake can happen while shaking")]
		public bool Interruptible = true;

		[Tooltip("if this is true, this shaker will always reset target values, regardless of how it was called")]
		public bool AlwaysResetTargetValuesAfterShake;

		[Tooltip("if this is true, this shaker will ignore any value passed in an event that triggered it, and will instead use the values set on its inspector")]
		public bool OnlyUseShakerValues;

		[Tooltip("a cooldown, in seconds, after a shake, during which no other shake can start")]
		public float CooldownBetweenShakes;

		[Tooltip("whether or not this shaker is shaking right now")]
		[MMFReadOnly]
		public bool Shaking;

		[HideInInspector]
		public bool ForwardDirection = true;

		[HideInInspector]
		public TimescaleModes TimescaleMode;

		[HideInInspector]
		internal bool _listeningToEvents;

		protected float _shakeStartedTimestamp = float.MinValue;

		protected float _remappedTimeSinceStart;

		protected bool _resetShakerValuesAfterShake;

		protected bool _resetTargetValuesAfterShake;

		protected float _journey;

		public virtual MMChannelData ChannelData => new MMChannelData(ChannelMode, Channel, MMChannelDefinition);

		public virtual bool ListeningToEvents => _listeningToEvents;

		public virtual float GetTime()
		{
			if (TimescaleMode != TimescaleModes.Scaled)
			{
				return Time.unscaledTime;
			}
			return Time.time;
		}

		public virtual float GetDeltaTime()
		{
			if (TimescaleMode != TimescaleModes.Scaled)
			{
				return Time.unscaledDeltaTime;
			}
			return Time.deltaTime;
		}

		protected virtual void Awake()
		{
			Initialization();
			if (!_listeningToEvents)
			{
				StartListening();
			}
			Shaking = PlayOnAwake;
			base.enabled = PlayOnAwake;
		}

		protected virtual void Initialization()
		{
		}

		public virtual void ForceInitialization()
		{
			Initialization();
		}

		public virtual void StartShaking()
		{
			_journey = (ForwardDirection ? 0f : ShakeDuration);
			if (!(GetTime() - _shakeStartedTimestamp < CooldownBetweenShakes) && !Shaking)
			{
				base.enabled = true;
				_shakeStartedTimestamp = GetTime();
				Shaking = true;
				GrabInitialValues();
				ShakeStarts();
			}
		}

		protected virtual void ShakeStarts()
		{
		}

		protected virtual void GrabInitialValues()
		{
		}

		protected virtual void Update()
		{
			if (Shaking || PermanentShake)
			{
				Shake();
				_journey += (ForwardDirection ? GetDeltaTime() : (0f - GetDeltaTime()));
			}
			if (Shaking && !PermanentShake && (_journey < 0f || _journey > ShakeDuration))
			{
				Shaking = false;
				ShakeComplete();
			}
			if (PermanentShake)
			{
				if (_journey < 0f)
				{
					_journey = ShakeDuration;
				}
				if (_journey > ShakeDuration)
				{
					_journey = 0f;
				}
			}
		}

		protected virtual void Shake()
		{
		}

		protected virtual float ShakeFloat(AnimationCurve curve, float remapMin, float remapMax, bool relativeIntensity, float initialValue)
		{
			float num = 0f;
			float time = MMFeedbacksHelpers.Remap(_journey, 0f, ShakeDuration, 0f, 1f);
			num = MMFeedbacksHelpers.Remap(curve.Evaluate(time), 0f, 1f, remapMin, remapMax);
			if (relativeIntensity)
			{
				num += initialValue;
			}
			return num;
		}

		protected virtual Color ShakeGradient(Gradient gradient)
		{
			float time = MMFeedbacksHelpers.Remap(_journey, 0f, ShakeDuration, 0f, 1f);
			return gradient.Evaluate(time);
		}

		protected virtual void ResetTargetValues()
		{
		}

		protected virtual void ResetShakerValues()
		{
		}

		protected virtual void ShakeComplete()
		{
			_journey = (ForwardDirection ? ShakeDuration : 0f);
			Shake();
			if (_resetTargetValuesAfterShake || AlwaysResetTargetValuesAfterShake)
			{
				ResetTargetValues();
			}
			if (_resetShakerValuesAfterShake)
			{
				ResetShakerValues();
			}
			base.enabled = false;
		}

		protected virtual void OnEnable()
		{
			StartShaking();
		}

		protected virtual void OnDestroy()
		{
			StopListening();
		}

		protected virtual void OnDisable()
		{
			if (Shaking)
			{
				ShakeComplete();
			}
		}

		public virtual void Play()
		{
			if (!(GetTime() - _shakeStartedTimestamp < CooldownBetweenShakes))
			{
				base.enabled = true;
			}
		}

		public virtual void Stop()
		{
			Shaking = false;
			ShakeComplete();
		}

		public virtual void StartListening()
		{
			_listeningToEvents = true;
		}

		public virtual void StopListening()
		{
			_listeningToEvents = false;
		}

		protected virtual bool CheckEventAllowed(MMChannelData channelData, bool useRange = false, float range = 0f, Vector3 eventOriginPosition = default(Vector3))
		{
			if (!MMChannel.Match(channelData, ChannelMode, Channel, MMChannelDefinition))
			{
				return false;
			}
			if (!base.gameObject.activeInHierarchy)
			{
				return false;
			}
			if (useRange && Vector3.Distance(base.transform.position, eventOriginPosition) > range)
			{
				return false;
			}
			return true;
		}

		public virtual float ComputeRangeIntensity(bool useRange, float rangeDistance, bool useRangeFalloff, AnimationCurve rangeFalloff, Vector2 remapRangeFalloff, Vector3 rangePosition)
		{
			if (!useRange)
			{
				return 1f;
			}
			float num = Vector3.Distance(rangePosition, base.transform.position);
			if (num > rangeDistance)
			{
				return 0f;
			}
			if (!useRangeFalloff)
			{
				return 1f;
			}
			float time = MMMaths.Remap(num, 0f, rangeDistance, 0f, 1f);
			return MMMaths.Remap(rangeFalloff.Evaluate(time), 0f, 1f, remapRangeFalloff.x, remapRangeFalloff.y);
		}
	}
}
