using UnityEngine;
using UnityEngine.EventSystems;

namespace MoreMountains.Tools
{
	[AddComponentMenu("More Mountains/Tools/Controls/MMTouchRepositionableJoystick")]
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
			base.OnPointerDown(data);
			if (ParentCanvasRenderMode == RenderMode.ScreenSpaceCamera)
			{
				_newPosition = TargetCamera.ScreenToWorldPoint(data.position);
			}
			else
			{
				_newPosition = data.position;
			}
			_newPosition.z = base.transform.position.z;
			if (WithinBounds())
			{
				BackgroundCanvasGroup.transform.position = _newPosition;
				SetNeutralPosition(_newPosition);
				_knobTransform.position = _newPosition;
			}
		}

		protected virtual bool WithinBounds()
		{
			if (!ConstrainToInitialRectangle)
			{
				return true;
			}
			return RectTransformUtility.RectangleContainsScreenPoint(_rectTransform, _newPosition);
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
