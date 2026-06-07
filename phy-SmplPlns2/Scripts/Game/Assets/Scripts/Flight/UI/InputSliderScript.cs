using System;
using Assets.Scripts.Craft;
using Assets.Scripts.Flight.Cameras;
using Assets.Scripts.Input;
using Jundroo.Common.Utils;
using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Flight.UI
{
	public class InputSliderScript : WidgetScript, IDragHandler, IEventSystemHandler, IInitializePotentialDragHandler
	{
		private Func<AircraftControls, float> _axisGetter;

		private IGameInput _axisInput;

		private Action<AircraftControls, float> _axisSetter;

		private float _basePosition;

		private Widget _handle;

		private TextWidget _handlePercentage;

		private float _initialTouchPosition;

		private float _maxRange = 205f;

		public void OnDrag(PointerEventData eventData)
		{
			if (eventData.button != PointerEventData.InputButton.Right)
			{
				float y = GetLocalPosition(eventData).y;
				UpdatePosition(y);
			}
		}

		public void OnInitializePotentialDrag(PointerEventData eventData)
		{
			eventData.useDragThreshold = false;
		}

		public void OnPointerDown(Widget widget)
		{
			PointerEventData pointerEventData = widget.PointerEventData;
			CameraManagerScript.PreventZoom = true;
			_initialTouchPosition = GetLocalPosition(pointerEventData).y;
			_basePosition = _handle.Position.y;
		}

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_handle = widget.FindWidget("handle");
			_handlePercentage = widget.FindWidget<TextWidget>("handle-percentage");
			_maxRange = (widget.Height ?? 50f) / 2f - (_handle.Height ?? 50f) / 2f;
			_handle.PointerUp += OnPointerUp;
			_handle.PointerDown += OnPointerDown;
			ConfigureAxis(widget.Data);
			UpdateHandle(null, 0f);
		}

		protected virtual void Update()
		{
			AircraftControls aircraftControls = FlightSceneScript.Instance.LocalPlayer?.Aircraft?.Controls;
			float num = 0f;
			if (aircraftControls != null)
			{
				num = _axisGetter(aircraftControls);
			}
			Vector2 position = _handle.Position;
			float num2 = num * _maxRange;
			if (num2 != position.y)
			{
				UpdateHandle(new Vector2(position.x, num2), num);
			}
		}

		private void ConfigureAxis(string axisName)
		{
			switch (axisName)
			{
			case "Trim":
				_axisGetter = (AircraftControls c) => c.Trim;
				_axisSetter = delegate(AircraftControls c, float x)
				{
					c.Trim = x;
				};
				_axisInput = GameInputs.Instance.Trim;
				break;
			case "VTOL":
				_axisGetter = (AircraftControls c) => c.Vtol;
				_axisSetter = delegate(AircraftControls c, float x)
				{
					c.Vtol = x;
				};
				_axisInput = GameInputs.Instance.Vtol;
				break;
			case "Flaps":
				_axisGetter = (AircraftControls c) => c.Flaps;
				_axisSetter = delegate(AircraftControls c, float x)
				{
					c.Flaps = x;
				};
				_axisInput = GameInputs.Instance.Flaps;
				break;
			default:
				throw new NotSupportedException("Axis '" + axisName + "' not supported for input slider");
			}
		}

		private Vector2 GetLocalPosition(PointerEventData eventData)
		{
			RectTransformUtility.ScreenPointToLocalPointInRectangle(base.Widget.Rect, eventData.position, eventData.pressEventCamera, out var localPoint);
			return localPoint;
		}

		private void OnPointerUp(Widget widget)
		{
			PointerEventData pointerEventData = widget.PointerEventData;
			if (pointerEventData.button == PointerEventData.InputButton.Right || pointerEventData.clickCount == 2)
			{
				SetAxisValue(0f);
			}
			CameraManagerScript.PreventZoom = false;
		}

		private void SetAxisValue(float value)
		{
			AircraftControls aircraftControls = FlightSceneScript.Instance.LocalPlayer?.Aircraft?.Controls;
			if (aircraftControls != null)
			{
				_axisSetter(aircraftControls, value);
				InputWrapper.SetLastInput(_axisInput, wasAxis: false);
			}
		}

		private void UpdateHandle(Vector2? position, float value)
		{
			if (position.HasValue)
			{
				_handle.Position = position.Value;
			}
			_handlePercentage.Text = Utilities.FormatPercentage(value);
		}

		private void UpdatePosition(float position)
		{
			float num = position - _initialTouchPosition;
			float value = Mathf.Clamp(_basePosition + num, 0f - _maxRange, _maxRange) / _maxRange;
			value = Mathf.Clamp(value, -1f, 1f);
			SetAxisValue(value);
		}
	}
}
