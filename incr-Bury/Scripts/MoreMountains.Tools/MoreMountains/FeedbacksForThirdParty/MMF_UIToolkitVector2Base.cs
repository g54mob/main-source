using System.Collections;
using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.FeedbacksForThirdParty
{
	[AddComponentMenu("")]
	public class MMF_UIToolkitVector2Base : MMF_UIToolkit
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
		public bool RelativeValues;

		[Tooltip("if this is true, calling that feedback will trigger it, even if it's in progress. If it's false, it'll prevent any new Play until the current one is over")]
		public bool AllowAdditivePlays;

		[Tooltip("how long the color of the text should change over time")]
		[MMFEnumCondition("Mode", new int[] { 1, 2 })]
		public float Duration = 0.2f;

		[Tooltip("the value to apply when in instant mode")]
		[MMFEnumCondition("Mode", new int[] { 0 })]
		public Vector2 InstantValue = new Vector2(1f, 1f);

		[Header("X")]
		[Tooltip("whether or not to animate the x value")]
		public bool AnimateX = true;

		[Tooltip("the curve to use when interpolating towards the destination value")]
		public MMTweenType CurveX = new MMTweenType(MMTween.MMTweenCurve.EaseInCubic, "", "Mode", 1, 2);

		[Tooltip("the value to which the curve's 0 should be remapped")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public float CurveRemapZeroX;

		[Tooltip("the value to which the curve's 1 should be remapped")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public float CurveRemapOneX = 1f;

		[Tooltip("the value to aim towards when in ToDestination mode")]
		[MMFEnumCondition("Mode", new int[] { 2 })]
		public float DestinationValueX = 1f;

		[Header("Y")]
		[Tooltip("whether or not to animate the y value")]
		public bool AnimateY = true;

		[Tooltip("the curve to use when interpolating towards the destination value")]
		public MMTweenType CurveY = new MMTweenType(MMTween.MMTweenCurve.EaseInCubic, "", "Mode", 1, 2);

		[Tooltip("the value to which the curve's 0 should be remapped")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public float CurveRemapZeroY;

		[Tooltip("the value to which the curve's 1 should be remapped")]
		[MMFEnumCondition("Mode", new int[] { 1 })]
		public float CurveRemapOneY = 1f;

		[Tooltip("the value to aim towards when in ToDestination mode")]
		[MMFEnumCondition("Mode", new int[] { 2 })]
		public float DestinationValueY = 1f;

		protected Vector2 _initialValue;

		protected Coroutine _coroutine;

		protected Vector2 _newValue;

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
			if (RelativeValues)
			{
				_initialValue = GetInitialValue();
			}
			switch (Mode)
			{
			case Modes.Instant:
			{
				Vector2 value = (RelativeValues ? (InstantValue + _initialValue) : InstantValue);
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
			_newValue.x = _initialValue.x;
			_newValue.y = _initialValue.y;
			if (Mode == Modes.Interpolate)
			{
				if (AnimateX)
				{
					float startValue = (RelativeValues ? (CurveRemapZeroX + _initialValue.x) : CurveRemapZeroX);
					float endValue = (RelativeValues ? (CurveRemapOneX + _initialValue.x) : CurveRemapOneX);
					_newValue.x = MMTween.Tween(time, 0f, 1f, startValue, endValue, CurveX);
				}
				if (AnimateY)
				{
					float startValue2 = (RelativeValues ? (CurveRemapZeroY + _initialValue.y) : CurveRemapZeroY);
					float endValue2 = (RelativeValues ? (CurveRemapOneY + _initialValue.y) : CurveRemapOneY);
					_newValue.y = MMTween.Tween(time, 0f, 1f, startValue2, endValue2, CurveY);
				}
			}
			else if (Mode == Modes.ToDestination)
			{
				if (AnimateX)
				{
					_newValue.x = MMTween.Tween(time, 0f, 1f, _initialValue.x, DestinationValueX, CurveX);
				}
				if (AnimateY)
				{
					_newValue.y = MMTween.Tween(time, 0f, 1f, _initialValue.y, DestinationValueY, CurveY);
				}
			}
			SetValue(_newValue);
		}

		protected virtual void SetValue(Vector2 newValue)
		{
		}

		protected virtual Vector2 GetInitialValue()
		{
			return Vector2.zero;
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
			if (string.IsNullOrEmpty(CurveX.EnumConditionPropertyName))
			{
				CurveX.EnumConditionPropertyName = "Mode";
				CurveX.EnumConditions = new bool[32];
				CurveX.EnumConditions[1] = true;
				CurveX.EnumConditions[2] = true;
				CurveY.EnumConditions = new bool[32];
				CurveY.EnumConditionPropertyName = "Mode";
				CurveY.EnumConditions[1] = true;
				CurveY.EnumConditions[2] = true;
			}
		}
	}
}
