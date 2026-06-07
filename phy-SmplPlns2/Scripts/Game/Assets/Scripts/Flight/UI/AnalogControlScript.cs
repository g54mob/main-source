using System.Text.RegularExpressions;
using Assets.Scripts.Flight.Cameras;
using Assets.Scripts.Input;
using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;
using Rewired;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Flight.UI
{
	public class AnalogControlScript : WidgetScript, IDragHandler, IEventSystemHandler, IPointerDownHandler, IPointerUpHandler
	{
		private CustomController _customController;

		private bool _gyroAutoDisabled;

		private string _horizontalAxis = string.Empty;

		private float _horizontalDeadZone = 25f;

		private float _horizontalRate = 3f;

		private bool _invertPitch;

		private bool _isFingerControlled;

		private float _radius;

		private bool _rightStick = true;

		private Widget _stick;

		private Vector2 _value;

		private string _verticalAxis = string.Empty;

		private float _verticalDeadZone = 25f;

		private float _verticalRate = 3f;

		public void OnDrag(PointerEventData eventData)
		{
			UpdatePosition(GetLocalPosition(eventData));
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			_isFingerControlled = true;
			CameraManagerScript.PreventZoom = true;
			Vector2 localPosition = GetLocalPosition(eventData);
			UpdatePosition(localPosition);
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			_isFingerControlled = false;
			CameraManagerScript.PreventZoom = false;
			_stick.Position = Vector2.zero;
		}

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_stick = widget.FindWidget("analog-stick");
			_radius = ParseDataFloat("radius", base.Widget.Data, 100f);
			_horizontalDeadZone = ParseDataFloat("deadZoneHorizontal", base.Widget.Data, 25f);
			_verticalDeadZone = ParseDataFloat("deadZoneVertical", base.Widget.Data, 25f);
			_rightStick = IsRightStick(base.Widget.Data);
		}

		protected virtual void Start()
		{
			if (ReInput.controllers.CustomControllers.Count == 0)
			{
				Debug.LogError("The custom controller could not be found");
			}
			else
			{
				ConfigureAxes();
			}
		}

		protected virtual void Update()
		{
			Vector2 zero = Vector2.zero;
			zero.x = GetAxisValue(_stick.Position.x, _horizontalDeadZone);
			zero.y = GetAxisValue(_stick.Position.y, _verticalDeadZone);
			if (_verticalAxis == "Pitch" && _invertPitch)
			{
				zero.y = 0f - zero.y;
			}
			_value.x = UpdateValue(_value.x, zero.x, _horizontalRate, Time.unscaledDeltaTime);
			UpdateOnScreenInput(_horizontalAxis, _value.x);
			_value.y = UpdateValue(_value.y, zero.y, _verticalRate, Time.unscaledDeltaTime);
			UpdateOnScreenInput(_verticalAxis, _value.y);
			_ = PauseManager.Paused;
		}

		private static bool IsRightStick(string input)
		{
			Match match = Regex.Match(input, "stick:([\\w]+)");
			if (match.Success)
			{
				return match.Groups[1].Value == "Right";
			}
			return false;
		}

		private static float ParseDataFloat(string name, string input, float defaultValue)
		{
			Match match = Regex.Match(input, name + ":(\\d+)");
			if (match.Success)
			{
				return float.Parse(match.Groups[1].Value);
			}
			return defaultValue;
		}

		private static float UpdateValue(float current, float target, float axisRate, float time)
		{
			if (axisRate != 0f)
			{
				float num = axisRate * time;
				if (current < target)
				{
					current += num;
					if (current > target)
					{
						current = target;
					}
				}
				else if (current > target)
				{
					current -= num;
					if (current < target)
					{
						current = target;
					}
				}
			}
			else
			{
				current = target;
			}
			return current;
		}

		private void ConfigureAxes()
		{
			_customController = ReInput.controllers.CustomControllers[0];
			_horizontalAxis = (_rightStick ? "Roll" : "Yaw");
			if (Game.Instance.Settings.Gameplay.General.TouchControlsType.Value == TouchControlsType.Mode1)
			{
				_verticalAxis = (_rightStick ? "Throttle" : "Pitch");
			}
			else
			{
				_verticalAxis = (_rightStick ? "Pitch" : "Throttle");
			}
			_invertPitch = Game.Instance.Settings.Gameplay.General.InvertTouchControlsPitch.Value;
		}

		private float GetAxisValue(float offset, float deadZone)
		{
			float value = (Mathf.Abs(offset) - deadZone) / (_radius - deadZone);
			value = Mathf.Clamp(value, 0f, 1f);
			if (offset < 0f)
			{
				value = 0f - value;
			}
			return value;
		}

		private Vector2 GetLocalPosition(PointerEventData eventData)
		{
			RectTransformUtility.ScreenPointToLocalPointInRectangle(base.Widget.Rect, eventData.position, eventData.pressEventCamera, out var localPoint);
			return localPoint;
		}

		private void UpdateGyro()
		{
			if (_gyroAutoDisabled)
			{
				_ = _isFingerControlled;
			}
		}

		private void UpdateOnScreenInput(string axisName, float value)
		{
			if (_customController != null)
			{
				_customController.SetAxisValue(axisName, value);
			}
		}

		private void UpdatePosition(Vector2 pos)
		{
			if (pos.magnitude > _radius)
			{
				pos = pos.normalized * _radius;
			}
			_stick.Position = pos;
		}
	}
}
