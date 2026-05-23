using System.Collections;
using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will let you change the speed of a target animator, either once, or instantly and then reset it, or interpolate it over time")]
	[FeedbackPath("GameObject/Animator Speed")]
	public class MMFeedbackAnimatorSpeed : MMFeedback
	{
		public enum Modes
		{
			Once = 0,
			InstantThenReset = 1,
			OverTime = 2
		}

		public static bool FeedbackTypeAuthorized = true;

		[Header("Animation")]
		[Tooltip("the animator whose parameters you want to update")]
		public Animator BoundAnimator;

		[Header("Speed")]
		[Tooltip("whether to change the speed of the target animator once, instantly and reset it later, or have it change over time")]
		public Modes Mode;

		[Tooltip("the new minimum speed at which to set the animator - value will be randomized between min and max")]
		public float NewSpeedMin;

		[Tooltip("the new maximum speed at which to set the animator - value will be randomized between min and max")]
		public float NewSpeedMax;

		[Tooltip("when in instant then reset or over time modes, the duration of the effect")]
		[MMFEnumCondition("Mode", new int[] { 1, 2 })]
		public float Duration = 1f;

		[Tooltip("when in over time mode, the curve against which to evaluate the new speed")]
		[MMFEnumCondition("Mode", new int[] { 2 })]
		public AnimationCurve Curve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.5f, 1f), new Keyframe(1f, 0f));

		protected Coroutine _coroutine;

		protected float _initialSpeed;

		protected float _startedAt;

		public virtual float GetTime()
		{
			if (Timing.TimescaleMode != TimescaleModes.Scaled)
			{
				return Time.unscaledTime;
			}
			return Time.time;
		}

		public virtual float GetDeltaTime()
		{
			if (Timing.TimescaleMode != TimescaleModes.Scaled)
			{
				return Time.unscaledDeltaTime;
			}
			return Time.deltaTime;
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (!Active || !FeedbackTypeAuthorized)
			{
				return;
			}
			if (BoundAnimator == null)
			{
				Debug.LogWarning("No animator was set for " + base.name);
				return;
			}
			if (!IsPlaying)
			{
				_initialSpeed = BoundAnimator.speed;
			}
			if (Mode == Modes.Once)
			{
				BoundAnimator.speed = DetermineNewSpeed();
			}
			else
			{
				_coroutine = StartCoroutine(ChangeSpeedCo());
			}
		}

		protected virtual IEnumerator ChangeSpeedCo()
		{
			if (Mode == Modes.InstantThenReset)
			{
				IsPlaying = true;
				BoundAnimator.speed = DetermineNewSpeed();
				yield return MMCoroutine.WaitFor(Duration);
				BoundAnimator.speed = _initialSpeed;
				IsPlaying = false;
			}
			else if (Mode == Modes.OverTime)
			{
				IsPlaying = true;
				_startedAt = GetTime();
				float newTargetSpeed = DetermineNewSpeed();
				while (GetTime() - _startedAt < Duration)
				{
					float time = MMFeedbacksHelpers.Remap(GetTime() - _startedAt, 0f, Duration, 0f, 1f);
					float x = Curve.Evaluate(time);
					BoundAnimator.speed = Mathf.Max(0f, MMFeedbacksHelpers.Remap(x, 0f, 1f, _initialSpeed, newTargetSpeed));
					yield return null;
				}
				BoundAnimator.speed = _initialSpeed;
				IsPlaying = false;
			}
		}

		protected virtual float DetermineNewSpeed()
		{
			return Mathf.Abs(Random.Range(NewSpeedMin, NewSpeedMax));
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && FeedbackTypeAuthorized)
			{
				if (_coroutine != null)
				{
					StopCoroutine(_coroutine);
				}
				BoundAnimator.speed = _initialSpeed;
			}
		}
	}
}
