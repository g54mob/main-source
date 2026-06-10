using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace MoreMountains.Tools
{
	[RequireComponent(typeof(Rect))]
	[RequireComponent(typeof(CanvasGroup))]
	[AddComponentMenu("More Mountains/Tools/Controls/MM Touch Joystick")]
	public class MMTouchJoystick : MMMonoBehaviour, IDragHandler, IEventSystemHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
	{
		public enum MaxRangeModes
		{
			Distance = 0,
			DistanceToTransform = 1
		}

		[MMInspectorGroup("Camera", true, 16, false)]
		[Tooltip("The camera to use as the reference for any ScreenToWorldPoint computations")]
		public Camera TargetCamera;

		[MMInspectorGroup("Joystick Behaviour", true, 18, false)]
		[Tooltip("Determines whether the horizontal axis of this stick should be enabled. If not, the stick will only move vertically.")]
		public bool HorizontalAxisEnabled = true;

		[Tooltip("Determines whether the vertical axis of this stick should be enabled. If not, the stick will only move horizontally.")]
		public bool VerticalAxisEnabled = true;

		[Tooltip("the mode in which to compute the range. Distance will be a flat value, DistanceToTransform will be a distance to a transform you can move around and potentially resize as you wish for various resolutions")]
		public MaxRangeModes MaxRangeMode;

		[Tooltip("The MaxRange is the maximum distance from its initial center position you can drag the joystick to.")]
		[MMEnumCondition("MaxRangeMode", new int[] { 0 })]
		public float MaxRange = 1.5f;

		[Tooltip("in DistanceToTransform mode, the object whose distance to the center will be used to compute the max range. Note that this is computed once, at init. Call RefreshMaxRangeDistance() to recompute it.")]
		[MMEnumCondition("MaxRangeMode", new int[] { 1 })]
		public Transform MaxRangeTransform;

		[MMInspectorGroup("Value Events", true, 19, false)]
		[Tooltip("An event to use the raw value of the joystick")]
		public JoystickEvent JoystickValue;

		[Tooltip("An event to use the normalized value of the joystick")]
		public JoystickEvent JoystickNormalizedValue;

		[Tooltip("An event to use the joystick's amplitude (the magnitude of its Vector2 output)")]
		public JoystickFloatEvent JoystickMagnitudeValue;

		[MMInspectorGroup("Touch Events", true, 8, false)]
		[Tooltip("An event triggered when tapping the joystick for the first time")]
		public UnityEvent OnPointerDownEvent;

		[Tooltip("An event triggered when dragging the stick")]
		public UnityEvent OnDragEvent;

		[Tooltip("An event triggered when releasing the stick")]
		public UnityEvent OnPointerUpEvent;

		[MMInspectorGroup("Rotating Direction Indicator", true, 20, false)]
		[Tooltip("an object you can rotate to show the direction of the joystick. Will only be visible if the movement is above a threshold")]
		public Transform RotatingIndicator;

		[Tooltip("the threshold above which the rotating indicator will appear")]
		public float RotatingIndicatorThreshold = 0.1f;

		[MMInspectorGroup("Knob Opacity", true, 17, false)]
		[Tooltip("the new opacity to apply to the canvas group when the button is pressed")]
		public float PressedOpacity = 0.5f;

		[Tooltip("whether or not to interpolate opacity changes on the knob's canvas group")]
		public bool InterpolateOpacity = true;

		[Tooltip("the speed at which to interpolate opacity")]
		[MMCondition("InterpolateOpacity", true)]
		public float InterpolateOpacitySpeed = 1f;

		[MMInspectorGroup("Debug Output", true, 5, false)]
		[Tooltip("the raw value of the joystick, from 0 to 1 on each axis")]
		[MMReadOnly]
		public Vector2 RawValue;

		[Tooltip("the normalized value of the joystick")]
		[MMReadOnly]
		public Vector2 NormalizedValue;

		[Tooltip("the magnitude of the stick's vector")]
		[MMReadOnly]
		public float Magnitude;

		[Tooltip("whether or not to draw gizmos associated to this stick")]
		public bool DrawGizmos = true;

		protected Vector3 _neutralPosition;

		protected Vector3 _newTargetPosition;

		protected Vector3 _newJoystickPosition;

		protected float _initialZPosition;

		protected float _targetOpacity;

		protected CanvasGroup _canvasGroup;

		protected float _initialOpacity;

		protected Transform _knobTransform;

		protected bool _rotatingIndicatorIsNotNull;

		protected float _maxRangeTransformDistance;

		protected Canvas _parentCanvas;

		public float ComputedMaxRange
		{
			get
			{
				if (Application.isPlaying)
				{
					if (MaxRangeMode != MaxRangeModes.Distance)
					{
						return _maxRangeTransformDistance;
					}
					return MaxRange;
				}
				if (MaxRangeMode == MaxRangeModes.Distance)
				{
					return MaxRange;
				}
				if (MaxRangeTransform == null)
				{
					return -1f;
				}
				RefreshMaxRangeDistance();
				return _maxRangeTransformDistance;
			}
		}

		public virtual RenderMode ParentCanvasRenderMode { get; protected set; }

		protected virtual void Start()
		{
			Initialize();
		}

		public virtual void Initialize()
		{
			if (ParentCanvasRenderMode == RenderMode.ScreenSpaceCamera && TargetCamera == null)
			{
				throw new Exception("MMTouchJoystick : you have to set a target camera");
			}
			_canvasGroup = GetComponent<CanvasGroup>();
			_parentCanvas = GetComponentInParent<Canvas>();
			_rotatingIndicatorIsNotNull = RotatingIndicator != null;
			RefreshMaxRangeDistance();
			SetKnobTransform(base.transform);
			SetNeutralPosition();
			ParentCanvasRenderMode = GetComponentInParent<Canvas>().renderMode;
			_initialZPosition = _knobTransform.position.z;
			_initialOpacity = _canvasGroup.alpha;
		}

		public virtual void RefreshMaxRangeDistance()
		{
			if (MaxRangeMode == MaxRangeModes.DistanceToTransform)
			{
				_maxRangeTransformDistance = Vector2.Distance(base.transform.position, MaxRangeTransform.position);
			}
		}

		public virtual void SetKnobTransform(Transform newTransform)
		{
			_knobTransform = newTransform;
		}

		protected virtual void Update()
		{
			NormalizedValue = RawValue.normalized;
			Magnitude = RawValue.magnitude;
			if (HorizontalAxisEnabled || VerticalAxisEnabled)
			{
				JoystickValue.Invoke(RawValue);
				JoystickNormalizedValue.Invoke(NormalizedValue);
				JoystickMagnitudeValue.Invoke(Magnitude);
			}
			RotateIndicator();
			HandleOpacity();
		}

		protected virtual void HandleOpacity()
		{
			if (InterpolateOpacity)
			{
				_canvasGroup.alpha = MMMaths.Lerp(_canvasGroup.alpha, _targetOpacity, InterpolateOpacitySpeed, Time.unscaledDeltaTime);
			}
			else
			{
				_canvasGroup.alpha = _targetOpacity;
			}
		}

		protected virtual void RotateIndicator()
		{
			if (_rotatingIndicatorIsNotNull)
			{
				RotatingIndicator.gameObject.SetActive(RawValue.magnitude > RotatingIndicatorThreshold);
				float angle = Mathf.Atan2(RawValue.y, RawValue.x) * 57.29578f;
				RotatingIndicator.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
			}
		}

		public virtual void SetNeutralPosition()
		{
			_neutralPosition = _knobTransform.position;
		}

		public virtual void SetNeutralPosition(Vector3 newPosition)
		{
			_neutralPosition = newPosition;
		}

		public virtual void OnDrag(PointerEventData eventData)
		{
			OnDragEvent.Invoke();
			_newTargetPosition = ConvertToWorld(eventData.position);
			Vector3 vector = TransformToLocalSpace(_newTargetPosition - _neutralPosition);
			vector = Vector2.ClampMagnitude(vector, ComputedMaxRange);
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

		protected virtual Vector3 TransformToLocalSpace(Vector3 worldVector)
		{
			if (ParentCanvasRenderMode == RenderMode.ScreenSpaceCamera && TargetCamera != null)
			{
				return Quaternion.Inverse(TargetCamera.transform.rotation) * worldVector;
			}
			return worldVector;
		}

		protected virtual Vector3 TransformToWorldSpace(Vector3 localVector)
		{
			if (ParentCanvasRenderMode == RenderMode.ScreenSpaceCamera && TargetCamera != null)
			{
				return TargetCamera.transform.rotation * localVector;
			}
			return localVector;
		}

		protected virtual Vector3 ConvertToWorld(Vector3 position)
		{
			if (ParentCanvasRenderMode == RenderMode.ScreenSpaceCamera)
			{
				float z = ((_parentCanvas != null) ? _parentCanvas.planeDistance : 0f);
				position.z = z;
				return TargetCamera.ScreenToWorldPoint(position);
			}
			return position;
		}

		protected virtual void ClampToBounds()
		{
			_newTargetPosition = Vector2.ClampMagnitude(_newTargetPosition - _neutralPosition, ComputedMaxRange);
		}

		public virtual void ResetJoystick()
		{
			_newJoystickPosition = _neutralPosition;
			_newJoystickPosition.z = _initialZPosition;
			_knobTransform.position = _newJoystickPosition;
			RawValue.x = 0f;
			RawValue.y = 0f;
			_targetOpacity = _initialOpacity;
		}

		protected virtual float EvaluateInputValue(float vectorPosition)
		{
			return Mathf.InverseLerp(0f, ComputedMaxRange, Mathf.Abs(vectorPosition)) * Mathf.Sign(vectorPosition);
		}

		public virtual void OnEndDrag(PointerEventData eventData)
		{
		}

		public virtual void OnPointerUp(PointerEventData data)
		{
			ResetJoystick();
			OnPointerUpEvent.Invoke();
		}

		public virtual void OnPointerDown(PointerEventData data)
		{
			_targetOpacity = PressedOpacity;
			OnPointerDownEvent.Invoke();
		}

		protected virtual void OnEnable()
		{
			Initialize();
			_targetOpacity = _initialOpacity;
		}
	}
}
