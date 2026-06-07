using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	public class MMFeedbacks : MonoBehaviour
	{
		public enum Directions
		{
			TopToBottom = 0,
			BottomToTop = 1
		}

		public enum SafeModes
		{
			Nope = 0,
			EditorOnly = 1,
			RuntimeOnly = 2,
			Full = 3
		}

		public enum InitializationModes
		{
			Script = 0,
			Awake = 1,
			Start = 2,
			OnEnable = 3
		}

		public List<MMFeedback> Feedbacks = new List<MMFeedback>();

		[Tooltip("the chosen initialization modes. If you use Script, you'll have to initialize manually by calling the Initialization method and passing it an owner. Otherwise, you can have this component initialize itself at Awake or Start, and in this case the owner will be the MMFeedbacks itself")]
		public InitializationModes InitializationMode = InitializationModes.Start;

		[Tooltip("if you set this to true, the system will make changes to ensure that initialization always happens before play")]
		public bool AutoInitialization = true;

		[Tooltip("the selected safe mode")]
		public SafeModes SafeMode = SafeModes.Full;

		[Tooltip("the selected direction these feedbacks should play in")]
		public Directions Direction;

		[Tooltip("whether or not this MMFeedbacks should invert its direction when all feedbacks have played")]
		public bool AutoChangeDirectionOnEnd;

		[Tooltip("whether or not to play this feedbacks automatically on Start")]
		public bool AutoPlayOnStart;

		[Tooltip("whether or not to play this feedbacks automatically on Enable")]
		public bool AutoPlayOnEnable;

		[Tooltip("if this is true, all feedbacks within that player will work on the specified ForcedTimescaleMode, regardless of their individual settings")]
		public bool ForceTimescaleMode;

		[Tooltip("the time scale mode all feedbacks on this player should work on, if ForceTimescaleMode is true")]
		[MMFCondition("ForceTimescaleMode", true)]
		public TimescaleModes ForcedTimescaleMode = TimescaleModes.Unscaled;

		[Tooltip("a time multiplier that will be applied to all feedback durations (initial delay, duration, delay between repeats...)")]
		public float DurationMultiplier = 1f;

		[Tooltip("a multiplier to apply to all timescale operations (1: normal, less than 1: slower operations, higher than 1: faster operations)")]
		public float TimescaleMultiplier = 1f;

		[Tooltip("if this is true, will expose a RandomDurationMultiplier. The final duration of each feedback will be : their base duration * DurationMultiplier * a random value between RandomDurationMultiplier.x and RandomDurationMultiplier.y")]
		public bool RandomizeDuration;

		[Tooltip("if RandomizeDuration is true, the min (x) and max (y) values for the random duration multiplier")]
		[MMCondition("RandomizeDuration", true)]
		public Vector2 RandomDurationMultiplier = new Vector2(0.5f, 1.5f);

		[Tooltip("if this is true, more editor-only, detailed info will be displayed per feedback in the duration slot")]
		public bool DisplayFullDurationDetails;

		[Tooltip("the timescale at which the player itself will operate. This notably impacts sequencing and pauses duration evaluation.")]
		public TimescaleModes PlayerTimescaleMode = TimescaleModes.Unscaled;

		[Tooltip("if this is true, this feedback will only play if its distance to RangeCenter is lower or equal to RangeDistance")]
		public bool OnlyPlayIfWithinRange;

		[Tooltip("when in OnlyPlayIfWithinRange mode, the transform to consider as the center of the range")]
		public Transform RangeCenter;

		[Tooltip("when in OnlyPlayIfWithinRange mode, the distance to the center within which the feedback will play")]
		public float RangeDistance = 5f;

		[Tooltip("when in OnlyPlayIfWithinRange mode, whether or not to modify the intensity of feedbacks based on the RangeFallOff curve")]
		public bool UseRangeFalloff;

		[Tooltip("the animation curve to use to define falloff (on the x 0 represents the range center, 1 represents the max distance to it)")]
		[MMFCondition("UseRangeFalloff", true)]
		public AnimationCurve RangeFalloff = new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(1f, 0f));

		[Tooltip("the values to remap the falloff curve's y axis' 0 and 1")]
		[MMFVector(new string[] { "Zero", "One" })]
		public Vector2 RemapRangeFalloff = new Vector2(0f, 1f);

		[Tooltip("whether or not to ignore MMSetFeedbackRangeCenterEvent, used to set the RangeCenter from anywhere")]
		public bool IgnoreRangeEvents;

		[Tooltip("a duration, in seconds, during which triggering a new play of this MMFeedbacks after it's been played once will be impossible")]
		public float CooldownDuration;

		[Tooltip("a duration, in seconds, to delay the start of this MMFeedbacks' contents play")]
		public float InitialDelay;

		[Tooltip("whether this player can be played or not, useful to temporarily prevent play from another class, for example")]
		public bool CanPlay = true;

		[Tooltip("if this is true, you'll be able to trigger a new Play while this feedback is already playing, otherwise you won't be able to")]
		public bool CanPlayWhileAlreadyPlaying = true;

		[Tooltip("the chance of this sequence happening (in percent : 100 : happens all the time, 0 : never happens, 50 : happens once every two calls, etc)")]
		[Range(0f, 100f)]
		public float ChanceToPlay = 100f;

		[Tooltip("the intensity at which to play this feedback. That value will be used by most feedbacks to tune their amplitude. 1 is normal, 0.5 is half power, 0 is no effect.Note that what this value controls depends from feedback to feedback, don't hesitate to check the code to see what it does exactly.")]
		public float FeedbacksIntensity = 1f;

		[Tooltip("a number of UnityEvents that can be triggered at the various stages of this MMFeedbacks")]
		public MMFeedbacksEvents Events;

		[Tooltip("a global switch used to turn all feedbacks on or off globally")]
		public static bool GlobalMMFeedbacksActive = true;

		[HideInInspector]
		public bool DebugActive;

		public bool InScriptDrivenPause;

		protected float _startTime;

		protected float _holdingMax;

		protected float _lastStartAt = float.MinValue;

		protected int _lastStartFrame = -1;

		protected bool _pauseFound;

		protected float _totalDuration;

		protected bool _shouldStop;

		protected const float _smallValue = 0.001f;

		protected float _randomDurationMultiplier = 1f;

		protected float _lastOnEnableFrame = -1f;

		public bool IsPlaying { get; protected set; }

		public virtual float ElapsedTime
		{
			get
			{
				if (!IsPlaying)
				{
					return 0f;
				}
				return GetTime() - _lastStartAt;
			}
		}

		public int TimesPlayed { get; protected set; }

		public bool ContainsLoop { get; set; }

		public bool ShouldChangeDirectionOnNextPlay { get; set; }

		public bool ForcingUnscaledTimescaleMode
		{
			get
			{
				if (ForceTimescaleMode)
				{
					return ForcedTimescaleMode == TimescaleModes.Unscaled;
				}
				return false;
			}
		}

		public virtual float TotalDuration
		{
			get
			{
				float num = 0f;
				foreach (MMFeedback feedback in Feedbacks)
				{
					if (feedback != null && feedback.Active && num < feedback.TotalDuration)
					{
						num = feedback.TotalDuration;
					}
				}
				return ComputedInitialDelay + num;
			}
		}

		public virtual float ComputedInitialDelay => ApplyTimeMultiplier(InitialDelay);

		public virtual float GetTime()
		{
			if (PlayerTimescaleMode != TimescaleModes.Scaled)
			{
				return Time.unscaledTime;
			}
			return Time.time;
		}

		public virtual float GetDeltaTime()
		{
			if (PlayerTimescaleMode != TimescaleModes.Scaled)
			{
				return Time.unscaledDeltaTime;
			}
			return Time.deltaTime;
		}

		protected virtual void Awake()
		{
			if (AutoPlayOnEnable)
			{
				MMFeedbacksEnabler mMFeedbacksEnabler = GetComponent<MMFeedbacksEnabler>();
				if (mMFeedbacksEnabler == null)
				{
					mMFeedbacksEnabler = base.gameObject.AddComponent<MMFeedbacksEnabler>();
				}
				mMFeedbacksEnabler.TargetMMFeedbacks = this;
			}
			if (InitializationMode == InitializationModes.Awake && Application.isPlaying)
			{
				Initialization(base.gameObject);
			}
			CheckForLoops();
		}

		protected virtual void Start()
		{
			if (InitializationMode == InitializationModes.Start && Application.isPlaying)
			{
				Initialization(base.gameObject);
			}
			if (AutoPlayOnStart && Application.isPlaying)
			{
				PlayFeedbacks();
			}
			CheckForLoops();
		}

		protected virtual void OnEnable()
		{
			if (AutoPlayOnEnable && Application.isPlaying)
			{
				PlayFeedbacks();
			}
		}

		public virtual void Initialization(bool forceInitIfPlaying = false)
		{
			Initialization(base.gameObject);
		}

		public virtual void Initialization(GameObject owner)
		{
			if (SafeMode == SafeModes.RuntimeOnly || SafeMode == SafeModes.Full)
			{
				AutoRepair();
			}
			IsPlaying = false;
			TimesPlayed = 0;
			_lastStartAt = float.MinValue;
			for (int i = 0; i < Feedbacks.Count; i++)
			{
				if (Feedbacks[i] != null)
				{
					Feedbacks[i].Initialization(owner);
				}
			}
		}

		public virtual void PlayFeedbacks()
		{
			PlayFeedbacksInternal(base.transform.position, FeedbacksIntensity);
		}

		public virtual async Task PlayFeedbacksTask(Vector3 position, float feedbacksIntensity = 1f, bool forceChangeDirection = false)
		{
			PlayFeedbacks(position, feedbacksIntensity, forceChangeDirection);
			while (IsPlaying)
			{
				await Task.Yield();
			}
		}

		public virtual async Task PlayFeedbacksTask()
		{
			PlayFeedbacks();
			while (IsPlaying)
			{
				await Task.Yield();
			}
		}

		public virtual void PlayFeedbacks(Vector3 position, float feedbacksIntensity = 1f, bool forceChangeDirection = false)
		{
			PlayFeedbacksInternal(position, feedbacksIntensity, forceChangeDirection);
		}

		public virtual void PlayFeedbacksInReverse()
		{
			PlayFeedbacksInternal(base.transform.position, FeedbacksIntensity, forceChangeDirection: true);
		}

		public virtual void PlayFeedbacksInReverse(Vector3 position, float feedbacksIntensity = 1f, bool forceChangeDirection = false)
		{
			PlayFeedbacksInternal(position, feedbacksIntensity, forceChangeDirection);
		}

		public virtual void PlayFeedbacksOnlyIfReversed()
		{
			if ((Direction == Directions.BottomToTop && !ShouldChangeDirectionOnNextPlay) || (Direction == Directions.TopToBottom && ShouldChangeDirectionOnNextPlay))
			{
				PlayFeedbacks();
			}
		}

		public virtual void PlayFeedbacksOnlyIfReversed(Vector3 position, float feedbacksIntensity = 1f, bool forceChangeDirection = false)
		{
			if ((Direction == Directions.BottomToTop && !ShouldChangeDirectionOnNextPlay) || (Direction == Directions.TopToBottom && ShouldChangeDirectionOnNextPlay))
			{
				PlayFeedbacks(position, feedbacksIntensity, forceChangeDirection);
			}
		}

		public virtual void PlayFeedbacksOnlyIfNormalDirection()
		{
			if (Direction == Directions.TopToBottom)
			{
				PlayFeedbacks();
			}
		}

		public virtual void PlayFeedbacksOnlyIfNormalDirection(Vector3 position, float feedbacksIntensity = 1f, bool forceChangeDirection = false)
		{
			if (Direction == Directions.TopToBottom)
			{
				PlayFeedbacks(position, feedbacksIntensity, forceChangeDirection);
			}
		}

		public virtual IEnumerator PlayFeedbacksCoroutine(Vector3 position, float feedbacksIntensity = 1f, bool forceChangeDirection = false)
		{
			PlayFeedbacks(position, feedbacksIntensity, forceChangeDirection);
			while (IsPlaying)
			{
				yield return null;
			}
		}

		protected virtual void PlayFeedbacksInternal(Vector3 position, float feedbacksIntensity, bool forceChangeDirection = false)
		{
			if (CanPlay && (!IsPlaying || CanPlayWhileAlreadyPlaying) && EvaluateChance() && (!(CooldownDuration > 0f) || !(GetTime() - _lastStartAt < CooldownDuration)) && GlobalMMFeedbacksActive && base.gameObject.activeInHierarchy)
			{
				if (ShouldChangeDirectionOnNextPlay)
				{
					ChangeDirection();
					ShouldChangeDirectionOnNextPlay = false;
				}
				if (forceChangeDirection)
				{
					Direction = ((Direction != Directions.BottomToTop) ? Directions.BottomToTop : Directions.TopToBottom);
				}
				ResetFeedbacks();
				base.enabled = true;
				TimesPlayed++;
				IsPlaying = true;
				_startTime = GetTime();
				_lastStartAt = _startTime;
				_totalDuration = TotalDuration;
				CheckForPauses();
				if (ComputedInitialDelay > 0f)
				{
					StartCoroutine(HandleInitialDelayCo(position, feedbacksIntensity, forceChangeDirection));
				}
				else
				{
					PreparePlay(position, feedbacksIntensity, forceChangeDirection);
				}
			}
		}

		protected virtual void PreparePlay(Vector3 position, float feedbacksIntensity, bool forceChangeDirection = false)
		{
			Events.TriggerOnPlay(this);
			_holdingMax = 0f;
			CheckForPauses();
			if (!_pauseFound)
			{
				PlayAllFeedbacks(position, feedbacksIntensity, forceChangeDirection);
			}
			else
			{
				StartCoroutine(PausedFeedbacksCo(position, feedbacksIntensity));
			}
		}

		protected virtual void CheckForPauses()
		{
			_pauseFound = false;
			for (int i = 0; i < Feedbacks.Count; i++)
			{
				if (Feedbacks[i] != null)
				{
					if (Feedbacks[i].Pause != null && Feedbacks[i].Active && Feedbacks[i].ShouldPlayInThisSequenceDirection)
					{
						_pauseFound = true;
					}
					if (Feedbacks[i].HoldingPause && Feedbacks[i].Active && Feedbacks[i].ShouldPlayInThisSequenceDirection)
					{
						_pauseFound = true;
					}
				}
			}
		}

		protected virtual void PlayAllFeedbacks(Vector3 position, float feedbacksIntensity, bool forceChangeDirection = false)
		{
			for (int i = 0; i < Feedbacks.Count; i++)
			{
				if (FeedbackCanPlay(Feedbacks[i]))
				{
					Feedbacks[i].Play(position, feedbacksIntensity);
				}
			}
		}

		protected virtual IEnumerator HandleInitialDelayCo(Vector3 position, float feedbacksIntensity, bool forceChangeDirection = false)
		{
			IsPlaying = true;
			yield return MMFeedbacksCoroutine.WaitFor(ComputedInitialDelay);
			PreparePlay(position, feedbacksIntensity, forceChangeDirection);
		}

		protected virtual void Update()
		{
			if (_shouldStop)
			{
				if (HasFeedbackStillPlaying())
				{
					return;
				}
				IsPlaying = false;
				Events.TriggerOnComplete(this);
				ApplyAutoChangeDirection();
				base.enabled = false;
				_shouldStop = false;
			}
			if (IsPlaying)
			{
				if (!_pauseFound && GetTime() - _startTime > _totalDuration)
				{
					_shouldStop = true;
				}
			}
			else
			{
				base.enabled = false;
			}
		}

		public virtual bool HasFeedbackStillPlaying()
		{
			int count = Feedbacks.Count;
			for (int i = 0; i < count; i++)
			{
				if (Feedbacks[i] != null && Feedbacks[i].IsPlaying)
				{
					return true;
				}
			}
			return false;
		}

		protected virtual IEnumerator PausedFeedbacksCo(Vector3 position, float feedbacksIntensity)
		{
			yield return null;
		}

		public virtual void StopFeedbacks()
		{
			StopFeedbacks(true);
		}

		public virtual void StopFeedbacks(bool stopAllFeedbacks = true)
		{
			StopFeedbacks(base.transform.position, 1f, stopAllFeedbacks);
		}

		public virtual void StopFeedbacks(Vector3 position, float feedbacksIntensity = 1f, bool stopAllFeedbacks = true)
		{
			if (stopAllFeedbacks)
			{
				for (int i = 0; i < Feedbacks.Count; i++)
				{
					if (Feedbacks[i] != null)
					{
						Feedbacks[i].Stop(position, feedbacksIntensity);
					}
				}
			}
			IsPlaying = false;
			StopAllCoroutines();
		}

		public virtual void ResetFeedbacks()
		{
			for (int i = 0; i < Feedbacks.Count; i++)
			{
				if (Feedbacks[i] != null && Feedbacks[i].Active)
				{
					Feedbacks[i].ResetFeedback();
				}
			}
			IsPlaying = false;
		}

		public virtual void ChangeDirection()
		{
			Events.TriggerOnChangeDirection(this);
			Direction = ((Direction != Directions.BottomToTop) ? Directions.BottomToTop : Directions.TopToBottom);
		}

		public virtual void SetCanPlay(bool newState)
		{
			CanPlay = newState;
		}

		public virtual void PauseFeedbacks()
		{
			Events.TriggerOnPause(this);
			InScriptDrivenPause = true;
		}

		public virtual void ResumeFeedbacks()
		{
			Events.TriggerOnResume(this);
			InScriptDrivenPause = false;
		}

		public virtual MMFeedback AddFeedback(Type feedbackType, bool add = true)
		{
			MMFeedback obj = base.gameObject.AddComponent(feedbackType) as MMFeedback;
			obj.hideFlags = HideFlags.HideInInspector;
			obj.Label = FeedbackPathAttribute.GetFeedbackDefaultName(feedbackType);
			AutoRepair();
			return obj;
		}

		public virtual void RemoveFeedback(int id)
		{
			UnityEngine.Object.DestroyImmediate(Feedbacks[id]);
			Feedbacks.RemoveAt(id);
			AutoRepair();
		}

		protected virtual bool EvaluateChance()
		{
			if (ChanceToPlay == 0f)
			{
				return false;
			}
			if (ChanceToPlay != 100f && UnityEngine.Random.Range(0f, 100f) > ChanceToPlay)
			{
				return false;
			}
			return true;
		}

		protected virtual void CheckForLoops()
		{
			ContainsLoop = false;
			for (int i = 0; i < Feedbacks.Count; i++)
			{
				if (Feedbacks[i] != null && Feedbacks[i].LooperPause && Feedbacks[i].Active)
				{
					ContainsLoop = true;
					break;
				}
			}
		}

		protected bool FeedbackCanPlay(MMFeedback feedback)
		{
			if (feedback == null)
			{
				return false;
			}
			if (feedback.Timing == null)
			{
				return false;
			}
			if (feedback.Timing.MMFeedbacksDirectionCondition == MMFeedbackTiming.MMFeedbacksDirectionConditions.Always)
			{
				return true;
			}
			if ((Direction == Directions.TopToBottom && feedback.Timing.MMFeedbacksDirectionCondition == MMFeedbackTiming.MMFeedbacksDirectionConditions.OnlyWhenForwards) || (Direction == Directions.BottomToTop && feedback.Timing.MMFeedbacksDirectionCondition == MMFeedbackTiming.MMFeedbacksDirectionConditions.OnlyWhenBackwards))
			{
				return true;
			}
			return false;
		}

		protected virtual void ApplyAutoChangeDirection()
		{
			if (AutoChangeDirectionOnEnd)
			{
				ShouldChangeDirectionOnNextPlay = true;
			}
		}

		public virtual float ApplyTimeMultiplier(float duration)
		{
			return duration * Mathf.Clamp(DurationMultiplier, 0.001f, float.MaxValue);
		}

		public virtual void AutoRepair()
		{
			new List<Component>();
			foreach (Component item in base.gameObject.GetComponents<Component>().ToList())
			{
				if (!(item is MMFeedback))
				{
					continue;
				}
				bool flag = false;
				for (int i = 0; i < Feedbacks.Count; i++)
				{
					if (Feedbacks[i] == (MMFeedback)item)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					Feedbacks.Add((MMFeedback)item);
				}
			}
		}

		protected virtual void OnDisable()
		{
		}

		protected virtual void OnValidate()
		{
			DurationMultiplier = Mathf.Clamp(DurationMultiplier, 0.001f, float.MaxValue);
		}

		protected virtual void OnDestroy()
		{
			IsPlaying = false;
		}
	}
}
