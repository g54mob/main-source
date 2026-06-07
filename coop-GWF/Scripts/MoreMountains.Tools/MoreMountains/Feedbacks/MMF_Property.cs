using System.Collections;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback will let you target (almost) any property, on any object in your scene. It also works on scriptable objects. Drag an object, select a property, and setup your feedback to update that property over time.")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks.MMTools", null)]
	[FeedbackPath("GameObject/Property")]
	public class MMF_Property : MMF_Feedback
	{
		public enum Modes
		{
			OverTime = 0,
			Instant = 1,
			ToDestination = 2
		}

		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Target Property", true, 12, false, false)]
		[Tooltip("the receiver to write the level to")]
		public MMPropertyReceiver Target;

		[MMFInspectorGroup("Mode", true, 29, false, false)]
		[Tooltip("whether the feedback should affect the target property instantly or over a period of time")]
		public Modes Mode;

		[Tooltip("how long the target property should change over time")]
		[MMFEnumCondition("Mode", new int[] { 0, 2 })]
		public float Duration = 0.2f;

		[Tooltip("whether or not that target property should be turned off on start")]
		public bool StartsOff;

		[Tooltip("whether or not the values should be relative or not")]
		public bool RelativeValues = true;

		[Tooltip("if this is true, calling that feedback will trigger it, even if it's in progress. If it's false, it'll prevent any new Play until the current one is over")]
		public bool AllowAdditivePlays;

		[Tooltip("if this is true, initial value will be computed for every play, otherwise only once, on initialization")]
		public bool DetermineInitialValueOnPlay;

		[MMFInspectorGroup("Level", true, 30, false, false)]
		[Tooltip("the curve to tween the intensity on")]
		[MMFEnumCondition("Mode", new int[] { 0, 2 })]
		public MMTweenType LevelCurve = new MMTweenType(new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.3f, 1f), new Keyframe(1f, 0f)));

		[Tooltip("the value to remap the intensity curve's 0 to")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float RemapLevelZero;

		[Tooltip("the value to remap the intensity curve's 1 to")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float RemapLevelOne = 1f;

		[Tooltip("the value to move the intensity to in instant mode")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public float InstantLevel;

		[Tooltip("the value towards which to animate when in ToDestination mode")]
		[MMFEnumCondition("Mode", new int[] { 2 })]
		public float ToDestinationLevel = 5f;

		protected float _initialIntensity;

		protected Coroutine _coroutine;

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
				if (Mode != Modes.Instant)
				{
					Duration = value;
				}
			}
		}

		public override bool HasRandomness => true;

		public override bool CanForceInitialValue => true;

		public override bool ForceInitialValueDelayed => true;

		public override bool HasCustomInspectors => true;

		protected override void CustomInitialization(MMF_Player owner)
		{
			base.CustomInitialization(owner);
			Target.Initialization(Owner.gameObject);
			GetInitialIntensity();
			if (Active && StartsOff)
			{
				Turn(status: false);
			}
		}

		protected virtual void GetInitialIntensity()
		{
			_initialIntensity = Target.Level;
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (!Active || !FeedbackTypeAuthorized)
			{
				return;
			}
			if (DetermineInitialValueOnPlay)
			{
				GetInitialIntensity();
			}
			Turn(status: true);
			float intensityMultiplier = ComputeIntensity(feedbacksIntensity, position);
			switch (Mode)
			{
			case Modes.Instant:
				Target.SetLevel(InstantLevel);
				break;
			case Modes.OverTime:
				if (AllowAdditivePlays || _coroutine == null)
				{
					if (_coroutine != null)
					{
						Owner.StopCoroutine(_coroutine);
					}
					_coroutine = Owner.StartCoroutine(UpdateValueSequence(intensityMultiplier));
				}
				break;
			case Modes.ToDestination:
				if (_coroutine != null)
				{
					Owner.StopCoroutine(_coroutine);
				}
				_coroutine = Owner.StartCoroutine(ToDestinationSequence(intensityMultiplier));
				break;
			}
		}

		protected virtual IEnumerator ToDestinationSequence(float intensityMultiplier)
		{
			float journey = (NormalPlayDirection ? 0f : FeedbackDuration);
			float initialValue = Target.Level;
			float destinationValue = ToDestinationLevel;
			if (RelativeValues)
			{
				destinationValue += _initialIntensity;
			}
			while (journey >= 0f && journey <= FeedbackDuration && FeedbackDuration > 0f)
			{
				float time = MMFeedbacksHelpers.Remap(journey, 0f, FeedbackDuration, 0f, 1f);
				SetValues(time, intensityMultiplier, initialValue, destinationValue, applyRelative: false);
				journey += (NormalPlayDirection ? FeedbackDeltaTime : (0f - FeedbackDeltaTime));
				yield return null;
			}
			SetValues(FinalNormalizedTime, intensityMultiplier, initialValue, destinationValue, applyRelative: false);
			if (StartsOff)
			{
				Turn(status: false);
			}
			_coroutine = null;
			yield return null;
		}

		protected virtual IEnumerator UpdateValueSequence(float intensityMultiplier)
		{
			float journey = (NormalPlayDirection ? 0f : FeedbackDuration);
			while (journey >= 0f && journey <= FeedbackDuration && FeedbackDuration > 0f)
			{
				float time = MMFeedbacksHelpers.Remap(journey, 0f, FeedbackDuration, 0f, 1f);
				SetValues(time, intensityMultiplier, RemapLevelZero, RemapLevelOne, applyRelative: true);
				journey += (NormalPlayDirection ? FeedbackDeltaTime : (0f - FeedbackDeltaTime));
				yield return null;
			}
			SetValues(FinalNormalizedTime, intensityMultiplier, RemapLevelZero, RemapLevelOne, applyRelative: true);
			if (StartsOff)
			{
				Turn(status: false);
			}
			_coroutine = null;
			yield return null;
		}

		protected virtual void SetValues(float time, float intensityMultiplier, float remapZero, float remapOne, bool applyRelative)
		{
			float num = MMTween.Tween(time, 0f, 1f, remapZero, remapOne, LevelCurve);
			num *= intensityMultiplier;
			if (applyRelative && RelativeValues)
			{
				num += _initialIntensity;
			}
			Target.SetLevel(num);
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			base.CustomStopFeedback(position, feedbacksIntensity);
			if (Active)
			{
				if (_coroutine != null)
				{
					Owner.StopCoroutine(_coroutine);
					_coroutine = null;
					Target.SetLevel(_initialIntensity);
				}
				if (StartsOff)
				{
					Turn(status: false);
				}
			}
		}

		protected virtual void Turn(bool status)
		{
			if (Target.TargetComponent.gameObject != null)
			{
				Target.TargetComponent.gameObject.SetActive(status);
			}
		}

		protected override void CustomRestoreInitialValues()
		{
			if (Active && FeedbackTypeAuthorized)
			{
				if (StartsOff)
				{
					Turn(status: false);
				}
				Target.SetLevel(_initialIntensity);
			}
		}
	}
}
