using UnityEngine;
using UnityEngine.EventSystems;

namespace MoreMountains.Tools
{
	[AddComponentMenu("More Mountains/Tools/Controls/MM Touch Repositionable Joystick")]
	public class MMTouchRepositionableJoystick : MMTouchJoystick, IPointerDownHandler, IEventSystemHandler
	{
		[MMInspectorGroup("Repositionable Joystick", true, 22, false)]
		[Tooltip("the canvas group to use as the joystick's knob")]
		public CanvasGroup KnobCanvasGroup;

		[Tooltip("the canvas group to use as the joystick's background")]
		public CanvasGroup BackgroundCanvasGroup;

		[Tooltip("if this is true, the joystick won't be able to travel beyond the bounds of the top level canvas")]
		public bool ConstrainToInitialRectangle = true;

		[Tooltip("if this is true, the joystick will return back to its initial position when released")]
		public bool ResetPositionToInitialOnRelease;

		protected Vector3 _initialPosition;

		protected Vector3 _newPosition;

		protected CanvasGroup _knobCanvasGroup;

		protected RectTransform _rectTransform;

		protected override void Start()
		{
			base.Start();
			_rectTransform = GetComponent<RectTransform>();
			_initialPosition = BackgroundCanvasGroup.GetComponent<RectTransform>().position;
		}

		public override void Initialize()
		{
			base.Initialize();
			SetKnobTransform(KnobCanvasGroup.transform);
			_canvasGroup = KnobCanvasGroup;
			_initialOpacity = _canvasGroup.alpha;
		}

		public override void OnPointerDown(PointerEventData data)
		{
			_targetOpacity = PressedOpacity;
			OnPointerDownEvent.Invoke();
			_newPosition = ConvertToWorld(data.position);
			if (WithinBounds())
			{
				BackgroundCanvasGroup.transform.position = _newPosition;
				SetNeutralPosition(_newPosition);
				_knobTransform.position = _newPosition;
				_initialZPosition = _newPosition.z;
			}
		}

		public override void OnDrag(PointerEventData eventData)
		{
			OnDragEvent.Invoke();
			_newTargetPosition = ConvertToWorld(eventData.position);
			Vector3 vector = TransformToLocalSpace(_newTargetPosition - _neutralPosition);
			vector = Vector2.ClampMagnitude(vector, base.ComputedMaxRange);
			if (!HorizontalAxisEnabled)
			{
				vector.x = 0f;
			}
			if (!VerticalAxisEnabled)
			{
				vector.y = 0f;
			}
			RawValue.x = EvaluateInputValue(vector.x);
			RawValue.y = EvaluateInputValue(vector.y);
			_newTargetPosition = _neutralPosition + TransformToWorldSpace(vector);
			_newJoystickPosition = _newTargetPosition;
			_newJoystickPosition.z = _initialZPosition;
			_knobTransform.position = _newJoystickPosition;
		}

		protected virtual bool WithinBounds()
		{
			if (!ConstrainToInitialRectangle)
			{
				return true;
			}
			Vector2 screenPoint = _newPosition;
			if (ParentCanvasRenderMode == RenderMode.ScreenSpaceCamera && TargetCamera != null)
			{
				screenPoint = TargetCamera.WorldToScreenPoint(_newPosition);
			}
			return RectTransformUtility.RectangleContainsScreenPoint(_rectTransform, screenPoint, TargetCamera);
		}

		public override void OnPointerUp(PointerEventData eventData)
		{
			base.OnPointerUp(eventData);
			if (ResetPositionToInitialOnRelease)
			{
				BackgroundCanvasGroup.transform.position = _initialPosition;
				_knobTransform.position = _initialPosition;
			}
		}
	}
}
