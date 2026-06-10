using System.Collections;
using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("")]
	public class MMF_UIToolkitFloatBase : MMF_UIToolkit
	{
		public enum Modes
		{
			Instant = 0,
			Interpolate = 1,
			ToDestination = 2
		}

		[MMFInspectorGroup("Value", true, 16, false, false)]
		[Tooltip("the selected mode :Instant : the value will change instantly to the target one,Curve : the value will be interpolated along the curve,interpolate : lerps from the current value to the destination one ")]
		public Modes Mode = Modes.Interpolate;

		[Tooltip("whether or not the value should be applied relatively to the initial value")]
		[MMFEnumCondition("Mode", new int[] { 1, 0 })]
		public bool RelativeValue;

		[Tooltip("if this is true, calling that feedback will trigger it, even if it's in progress. If it's false, it'll prevent any new Play until the current one is over")]
		public bool AllowAdditivePlays;

		[Tooltip("how long the color of the text should change over time")]
		[MMFEnumCondition("Mode", new int[] { 1, 2 })]
		public float Duration = 0.2f;

		[Tooltip("the value to apply when in instant mode")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public float InstantValue = 1f;

		[Tooltip("the curve to use when interpolating towards the destination value")]
		public MMTweenType Curve = new MMTweenType(MMTween.MMTweenCurve.EaseInCubic, "", "Mode", 1, 2);

		[Tooltip("the value to which the curve's 0 should be remapped")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public float CurveRemapZero;

		[Tooltip("the value to which the curve's 1 should be remapped")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public float CurveRemapOne = 1f;

		[Tooltip("the value to aim towards when in ToDestination mode")]
		[MMFEnumCondition("Mode", new int[] { 2 })]
		public float DestinationValue = 1f;

		protected float _initialValue;

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
				Duration = value;
			}
		}

		public override bool HasCustomInspectors => true;

		protected override void CustomInitialization(MMF_Player owner)
		{
			base.CustomInitialization(owner);
			if (_visualElements != null && _visualElements.Count != 0)
			{
				_initialValue = GetInitialValue();
			}
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (!Active || !MMF_UIToolkit.FeedbackTypeAuthorized || _visualElements == null || _visualElements.Count == 0)
			{
				return;
			}
			if (RelativeValue)
			{
				_initialValue = GetInitialValue();
			}
			switch (Mode)
			{
			case Modes.Instant:
			{
				float value = (RelativeValue ? (InstantValue + _initialValue) : InstantValue);
				if (!NormalPlayDirection)
				{
					value = _initialValue;
				}
				SetValue(value);
				break;
			}
			case Modes.Interpolate:
				if (AllowAdditivePlays || _coroutine == null)
				{
					if (_coroutine != null)
					{
						Owner.StopCoroutine(_coroutine);
					}
					_coroutine = Owner.StartCoroutine(ChangeValue());
				}
				break;
			case Modes.ToDestination:
				if (AllowAdditivePlays || _coroutine == null)
				{
					_initialValue = GetInitialValue();
					if (_coroutine != null)
					{
						Owner.StopCoroutine(_coroutine);
					}
					_coroutine = Owner.StartCoroutine(ChangeValue());
				}
				break;
			}
		}

		protected virtual IEnumerator ChangeValue()
		{
			float journey = (NormalPlayDirection ? 0f : FeedbackDuration);
			IsPlaying = true;
			while (journey >= 0f && journey <= FeedbackDuration && FeedbackDuration > 0f)
			{
				float time = MMFeedbacksHelpers.Remap(journey, 0f, FeedbackDuration, 0f, 1f);
				ApplyTime(time);
				journey += (NormalPlayDirection ? FeedbackDeltaTime : (0f - FeedbackDeltaTime));
				yield return null;
			}
			ApplyTime(FinalNormalizedTime);
			_coroutine = null;
			IsPlaying = false;
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (Active && MMF_UIToolkit.FeedbackTypeAuthorized)
			{
				base.CustomStopFeedback(position, feedbacksIntensity);
				IsPlaying = false;
				if (_coroutine != null)
				{
					Owner.StopCoroutine(_coroutine);
					_coroutine = null;
				}
			}
		}

		protected virtual void ApplyTime(float time)
		{
			float value = 0f;
			if (Mode == Modes.Interpolate)
			{
				float startValue = (RelativeValue ? (CurveRemapZero + _initialValue) : CurveRemapZero);
				float endValue = (RelativeValue ? (CurveRemapOne + _initialValue) : CurveRemapOne);
				value = MMTween.Tween(time, 0f, 1f, startValue, endValue, Curve);
			}
			else if (Mode == Modes.ToDestination)
			{
				value = MMTween.Tween(time, 0f, 1f, _initialValue, DestinationValue, Curve);
			}
			SetValue(value);
		}

		protected virtual void SetValue(float newValue)
		{
		}

		protected virtual float GetInitialValue()
		{
			return 0f;
		}

		protected override void CustomRestoreInitialValues()
		{
			if (Active && MMF_UIToolkit.FeedbackTypeAuthorized)
			{
				SetValue(_initialValue);
			}
		}

		public override void OnValidate()
		{
			base.OnValidate();
			if (string.IsNullOrEmpty(Curve.EnumConditionPropertyName))
			{
				Curve.EnumConditionPropertyName = "Mode";
				Curve.EnumConditions = new bool[32];
				Curve.EnumConditions[1] = true;
				Curve.EnumConditions[2] = true;
			}
		}
	}
}
