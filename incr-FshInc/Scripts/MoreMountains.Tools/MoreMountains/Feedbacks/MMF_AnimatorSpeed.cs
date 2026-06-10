using System.Collections;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will let you change the speed of a target animator, either once, or instantly and then reset it, or interpolate it over time")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks", null)]
	[FeedbackPath("Animation/Animator Speed")]
	public class MMF_AnimatorSpeed : MMF_Feedback
	{
		public enum SpeedModes
		{
			Once = 0,
			InstantThenReset = 1,
			OverTime = 2
		}

		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Animation", true, 12, true, false)]
		[Tooltip("the animator whose parameters you want to update")]
		public Animator BoundAnimator;

		[MMFInspectorGroup("Speed", true, 14, true, false)]
		[Tooltip("whether to change the speed of the target animator once, instantly and reset it later, or have it change over time")]
		public SpeedModes Mode;

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

		public override bool HasRandomness => true;

		public override bool CanForceInitialValue => true;

		public override bool HasAutomatedTargetAcquisition => true;

		protected override void AutomateTargetAcquisition()
		{
			BoundAnimator = FindAutomatedTarget<Animator>();
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (!Active || !FeedbackTypeAuthorized)
			{
				return;
			}
			if (BoundAnimator == null)
			{
				Debug.LogWarning("[Animator Speed Feedback] The animator speed feedback on " + Owner.name + " doesn't have a BoundAnimator, it won't work. You need to specify one in its inspector.");
				return;
			}
			if (!IsPlaying)
			{
				_initialSpeed = BoundAnimator.speed;
			}
			if (Mode == SpeedModes.Once)
			{
				BoundAnimator.speed = ComputeIntensity(DetermineNewSpeed(), position);
				return;
			}
			if (_coroutine != null)
			{
				Owner.StopCoroutine(_coroutine);
			}
			_coroutine = Owner.StartCoroutine(ChangeSpeedCo());
		}

		protected virtual IEnumerator ChangeSpeedCo()
		{
			if (Mode == SpeedModes.InstantThenReset)
			{
				IsPlaying = true;
				BoundAnimator.speed = DetermineNewSpeed();
				yield return WaitFor(Duration);
				BoundAnimator.speed = _initialSpeed;
				IsPlaying = false;
			}
			else if (Mode == SpeedModes.OverTime)
			{
				IsPlaying = true;
				_startedAt = FeedbackTime;
				float newTargetSpeed = DetermineNewSpeed();
				while (FeedbackTime - _startedAt < Duration)
				{
					float time = MMFeedbacksHelpers.Remap(FeedbackTime - _startedAt, 0f, Duration, 0f, 1f);
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
					Owner.StopCoroutine(_coroutine);
				}
				BoundAnimator.speed = _initialSpeed;
			}
		}

		protected override void CustomRestoreInitialValues()
		{
			if (Active && FeedbackTypeAuthorized)
			{
				BoundAnimator.speed = _initialSpeed;
			}
		}
	}
}
