using System;
using System.Linq;
using ModApi;
using UI.Xml;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Flight.UI
{
	public class AnalogControlScript : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IDragHandler, IBeginDragHandler, IInitializePotentialDragHandler
	{
		public enum AnalogInputType
		{
			Throttle = 0,
			Pitch = 1,
			Yaw = 2,
			Roll = 3,
			EvaMoveFwdAft = 4,
			EvaStrafe = 5,
			EvaUpDown = 6
		}

		private RectTransform _analogStick;

		private RectTransform _clickArea;

		private XmlElement _element;

		private FlightControls _flightControls;

		private Vector2 _inputs;

		private DateTime _lastSoundTime;

		private float _radius;

		private Vector2 _touchStartPosition;

		private GameObject _translationModeIcon;

		public float DeadZone { get; set; } = 0.1f;

		public AnalogInputType HorizontalInputType { get; set; }

		public AnalogInputType VerticalInputType { get; set; }

		public bool Visible
		{
			get
			{
				return _element.Visible;
			}
			set
			{
				_element.SetActive(value);
				if (!value)
				{
					_inputs = Vector2.zero;
					ProcessInputs(0f);
				}
			}
		}

		public void Initialize(XmlElement element)
		{
			_element = element;
			_clickArea = GetComponent<RectTransform>();
			_radius = _clickArea.rect.width / 2f;
			_analogStick = element.GetChildElementsWithClass("analog-stick").First().GetComponent<RectTransform>();
			_translationModeIcon = element.GetChildElementsWithClass("translation-mode-icon").First().gameObject;
			_translationModeIcon.SetActive(value: false);
			_flightControls = FlightSceneScript.Instance.FlightControls;
		}

		void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
		{
			HandleInput(eventData.position);
		}

		void IDragHandler.OnDrag(PointerEventData eventData)
		{
			HandleInput(eventData.position);
		}

		void IInitializePotentialDragHandler.OnInitializePotentialDrag(PointerEventData eventData)
		{
			eventData.useDragThreshold = false;
		}

		void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
		{
			RectTransformUtility.ScreenPointToLocalPointInRectangle(_clickArea, eventData.position, null, out _touchStartPosition);
			HandleInput(eventData.position);
		}

		void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
		{
			_inputs = Vector2.zero;
			_analogStick.anchoredPosition = Vector3.zero;
			_touchStartPosition = Vector2.zero;
		}

		private float GetAxisInputFromPosition(float position)
		{
			float num = Mathf.Sign(position);
			float num2 = Mathf.Abs(position) / _radius;
			num2 = (num2 - DeadZone) / (1f - DeadZone);
			num2 = Mathf.Clamp01(num2);
			return num * num2 * num2;
		}

		private void HandleInput(Vector2 cursorPosition)
		{
			RectTransformUtility.ScreenPointToLocalPointInRectangle(_clickArea, cursorPosition, null, out var localPoint);
			Vector2 vector = localPoint - _touchStartPosition;
			_analogStick.anchoredPosition = Vector3.zero;
			_analogStick.localPosition += new Vector3(vector.x, vector.y, 0f);
			Vector2 anchoredPosition = _analogStick.anchoredPosition;
			_inputs.x = GetAxisInputFromPosition(anchoredPosition.x);
			_inputs.y = GetAxisInputFromPosition(anchoredPosition.y);
			if (anchoredPosition.magnitude > _radius)
			{
				anchoredPosition = anchoredPosition.normalized * _radius;
				_analogStick.anchoredPosition = anchoredPosition;
			}
		}

		private void ProcessInput(AnalogInputType inputType, float value, float responseSpeed)
		{
			switch (inputType)
			{
			case AnalogInputType.Pitch:
				_flightControls.AnalogPitch = StepInput(_flightControls.AnalogPitch, value, responseSpeed);
				break;
			case AnalogInputType.Roll:
				_flightControls.AnalogRoll = StepInput(_flightControls.AnalogRoll, value, responseSpeed);
				break;
			case AnalogInputType.Yaw:
				_flightControls.AnalogYaw = StepInput(_flightControls.AnalogYaw, value, responseSpeed);
				break;
			case AnalogInputType.Throttle:
			{
				_flightControls.AnalogThrottle = StepInput(_flightControls.AnalogThrottle, value, responseSpeed);
				_flightControls.AnalogThrottle = value;
				float targetValue = 0f;
				if (_flightControls.Controls.Throttle <= 0f)
				{
					targetValue = Mathf.Clamp01(0f - value);
				}
				_flightControls.AnalogBrake = StepInput(_flightControls.AnalogBrake, targetValue, responseSpeed);
				break;
			}
			case AnalogInputType.EvaMoveFwdAft:
				_flightControls.AnalogEvaMoveFwdAft = StepInput(_flightControls.AnalogEvaMoveFwdAft, value, responseSpeed);
				break;
			case AnalogInputType.EvaStrafe:
				_flightControls.AnalogEvaStrafe = StepInput(_flightControls.AnalogEvaStrafe, value, responseSpeed);
				break;
			case AnalogInputType.EvaUpDown:
				_flightControls.AnalogEvaUpDown = StepInput(_flightControls.AnalogEvaUpDown, value, responseSpeed);
				break;
			}
		}

		private void ProcessInputs(float responseSpeed = 5f)
		{
			ProcessInput(HorizontalInputType, _inputs.x, responseSpeed);
			ProcessInput(VerticalInputType, _inputs.y, responseSpeed);
		}

		private float StepInput(float currentValue, float targetValue, float responseSpeed)
		{
			if (responseSpeed == 0f)
			{
				return targetValue;
			}
			return Utilities.StepTowards(currentValue, responseSpeed * Time.unscaledDeltaTime, targetValue);
		}

		private void Update()
		{
			ProcessInputs();
			if (_flightControls.Controls.TranslationModeEnabled && !_translationModeIcon.activeSelf)
			{
				_translationModeIcon.SetActive(value: true);
			}
			else if (!_flightControls.Controls.TranslationModeEnabled && _translationModeIcon.activeSelf)
			{
				_translationModeIcon.SetActive(value: false);
			}
		}
	}
}
