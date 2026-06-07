using UnityEngine;
using UnityEngine.EventSystems;

namespace MoreMountains.Tools
{
	[AddComponentMenu("More Mountains/Tools/Controls/MM Touch Follower Joystick")]
	public class MMTouchFollowerJoystick : MMTouchJoystick
	{
		[MMInspectorGroup("Follower Joystick", true, 23, false)]
		[Tooltip("the canvas group to use as the joystick's knob - the part that moves under your thumb")]
		public CanvasGroup KnobCanvasGroup;

		[Tooltip("the canvas group to use as the joystick's background")]
		public CanvasGroup BackgroundCanvasGroup;

		[Tooltip("if this is true, the joystick will return back to its initial position when released")]
		public bool ResetPositionToInitialOnRelease;

		[Tooltip("if this is true, the background will follow its target with interpolation, otherwise it'll be instant movement")]
		public bool InterpolateFollowMovement;

		[Tooltip("if in interpolate mode, this defines the speed at which the backgrounds follows the knob")]
		[MMCondition("InterpolateFollowMovement", true)]
		public float InterpolateFollowMovementSpeed = 0.3f;

		[Tooltip("whether or not to add a spring to the interpolation of the background movement")]
		[MMCondition("InterpolateFollowMovement", true)]
		public bool SpringFollowInterpolation;

		[Tooltip("when in SpringFollowInterpolation mode, the amount of damping to apply to the spring")]
		[MMCondition("SpringFollowInterpolation", true)]
		public float SpringDamping = 0.6f;

		[Tooltip("when in SpringFollowInterpolation mode, the frequency to apply to the spring")]
		[MMCondition("SpringFollowInterpolation", true)]
		public float SpringFrequency = 4f;

		[MMInspectorGroup("Background Constraints", true, 24, false)]
		[Tooltip("if this is true, the joystick won't be able to travel beyond the bounds of the top level canvas")]
		public bool ShouldConstrainBackground = true;

		[Tooltip("the rect to consider as a background constraint zone, if left empty, will be auto created")]
		public RectTransform BackgroundConstraintRectTransform;

		[Tooltip("the left padding to apply to the background constraint")]
		public float BackgroundConstraintPaddingLeft;

		[Tooltip("the right padding to apply to the background constraint")]
		public float BackgroundConstraintPaddingRight;

		[Tooltip("the top padding to apply to the background constraint")]
		public float BackgroundConstraintPaddingTop;

		[Tooltip("the bottom padding to apply to the background constraint")]
		public float BackgroundConstraintPaddingBottom;

		protected Vector3 _initialPosition;

		protected Vector3 _newPosition;

		protected RectTransform _rectTransform;

		protected RectTransform _backgroundRectTransform;

		protected Vector3[] _innerRectCorners = new Vector3[4];

		protected Vector3 _newBackgroundPosition;

		protected Vector3 _backgroundPositionTarget;

		protected Vector3 _innerRectTransformBottomLeft;

		protected Vector3 _innerRectTransformTopLeft;

		protected Vector3 _innerRectTransformTopRight;

		protected Vector3 _innerRectTransformBottomRight;

		protected Vector3 _springVelocity;

		protected override void Start()
		{
			base.Start();
			_rectTransform = GetComponent<RectTransform>();
			_backgroundRectTransform = BackgroundCanvasGroup.GetComponent<RectTransform>();
			_initialPosition = _backgroundRectTransform.position;
			_backgroundPositionTarget = _initialPosition;
			CreateInnerRect();
		}

		public override void Initialize()
		{
			base.Initialize();
			SetKnobTransform(KnobCanvasGroup.transform);
			_canvasGroup = KnobCanvasGroup;
			_initialOpacity = _canvasGroup.alpha;
		}

		protected override void Update()
		{
			base.Update();
			HandleMovementInterpolation();
		}

		protected virtual void HandleMovementInterpolation()
		{
			if (!InterpolateFollowMovement)
			{
				BackgroundCanvasGroup.transform.position = _backgroundPositionTarget;
			}
			else if (SpringFollowInterpolation)
			{
				_newBackgroundPosition = BackgroundCanvasGroup.transform.position;
				MMMaths.Spring(ref _newBackgroundPosition, _backgroundPositionTarget, ref _springVelocity, SpringDamping, SpringFrequency, Time.unscaledDeltaTime);
				BackgroundCanvasGroup.transform.position = _newBackgroundPosition;
			}
			else
			{
				BackgroundCanvasGroup.transform.position = MMMaths.Lerp(BackgroundCanvasGroup.transform.position, _backgroundPositionTarget, InterpolateFollowMovementSpeed, Time.unscaledDeltaTime);
			}
		}

		protected virtual void CreateInnerRect()
		{
			if (ShouldConstrainBackground)
			{
				if (BackgroundConstraintRectTransform == null)
				{
					GameObject gameObject = new GameObject();
					gameObject.transform.SetParent(base.transform);
					gameObject.name = "BackgroundConstraintRectTransform";
					BackgroundConstraintRectTransform = gameObject.AddComponent<RectTransform>();
					BackgroundConstraintRectTransform.anchorMin = _rectTransform.anchorMin;
					BackgroundConstraintRectTransform.anchorMax = _rectTransform.anchorMax;
					BackgroundConstraintRectTransform.position = _rectTransform.position;
					BackgroundConstraintRectTransform.localScale = _rectTransform.localScale;
					BackgroundConstraintRectTransform.sizeDelta = new Vector2(_rectTransform.sizeDelta.x - _backgroundRectTransform.sizeDelta.y, _rectTransform.sizeDelta.y - _backgroundRectTransform.sizeDelta.y);
				}
				BackgroundConstraintRectTransform.offsetMin += new Vector2(BackgroundConstraintPaddingLeft, BackgroundConstraintPaddingBottom);
				BackgroundConstraintRectTransform.offsetMax -= new Vector2(BackgroundConstraintPaddingRight, BackgroundConstraintPaddingTop);
				BackgroundConstraintRectTransform.GetWorldCorners(_innerRectCorners);
				_innerRectTransformBottomLeft = _innerRectCorners[0];
				_innerRectTransformTopLeft = _innerRectCorners[1];
				_innerRectTransformTopRight = _innerRectCorners[2];
				_innerRectTransformBottomRight = _innerRectCorners[3];
			}
		}

		public override void OnPointerDown(PointerEventData data)
		{
			base.OnPointerDown(data);
			_newPosition = ConvertToWorld(data.position);
			_newPosition.z = base.transform.position.z;
			_backgroundPositionTarget = _newPosition;
			ConstrainBackground();
			SetNeutralPosition(BackgroundCanvasGroup.transform.position);
			_knobTransform.position = _newPosition;
			ComputeJoystickValue();
		}

		public override void OnDrag(PointerEventData eventData)
		{
			base.OnDrag(eventData);
			float num = Vector2.Distance(_knobTransform.position, BackgroundCanvasGroup.transform.position);
			if (num >= base.ComputedMaxRange)
			{
				_backgroundPositionTarget = BackgroundCanvasGroup.transform.position + (_knobTransform.position - BackgroundCanvasGroup.transform.position).normalized * (num - base.ComputedMaxRange);
			}
			ConstrainBackground();
			ComputeJoystickValue();
		}

		protected virtual void ComputeJoystickValue()
		{
			float num = Vector2.Distance(_knobTransform.position, BackgroundCanvasGroup.transform.position);
			if (num <= base.ComputedMaxRange)
			{
				RawValue.x = EvaluateInputValue(_knobTransform.position.x - BackgroundCanvasGroup.transform.position.x);
				RawValue.y = EvaluateInputValue(_knobTransform.position.y - BackgroundCanvasGroup.transform.position.y);
				return;
			}
			float f = _knobTransform.position.x - BackgroundCanvasGroup.transform.position.x;
			RawValue.x = Mathf.InverseLerp(0f, num, Mathf.Abs(f)) * Mathf.Sign(f);
			f = _knobTransform.position.y - BackgroundCanvasGroup.transform.position.y;
			RawValue.y = Mathf.InverseLerp(0f, num, Mathf.Abs(f)) * Mathf.Sign(f);
		}

		protected virtual void ConstrainBackground()
		{
			if (ShouldConstrainBackground)
			{
				_newBackgroundPosition = _backgroundPositionTarget;
				_newBackgroundPosition.x = Mathf.Clamp(_newBackgroundPosition.x, _innerRectTransformTopLeft.x, _innerRectTransformTopRight.x);
				_newBackgroundPosition.y = Mathf.Clamp(_newBackgroundPosition.y, _innerRectTransformBottomLeft.y, _innerRectTransformTopLeft.y);
				_backgroundPositionTarget = _newBackgroundPosition;
			}
		}

		public override void OnPointerUp(PointerEventData data)
		{
			base.OnPointerUp(data);
			ResetJoystick();
			_knobTransform.position = _backgroundPositionTarget;
			if (ResetPositionToInitialOnRelease)
			{
				_backgroundPositionTarget = _initialPosition;
				_knobTransform.position = _initialPosition;
			}
		}

		protected override void ClampToBounds()
		{
			_newTargetPosition -= _neutralPosition;
		}
	}
}
