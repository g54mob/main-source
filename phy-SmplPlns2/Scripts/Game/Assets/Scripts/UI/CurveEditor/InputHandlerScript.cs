using System;
using System.Collections.Generic;
using Jundroo.Common.Platform;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.UI.CurveEditor
{
	public class InputHandlerScript : MonoBehaviour, IDragHandler, IEventSystemHandler, IBeginDragHandler, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IDropHandler, IEndDragHandler, IDeselectHandler, ISelectHandler, IScrollHandler, IInitializePotentialDragHandler
	{
		private IInputResponder _capturedInputResponder;

		private List<IInputResponder> _fullScreenInputResponders = new List<IInputResponder>();

		private bool _pinching;

		private float _pinchLastAngle;

		private float _pinchLastDistance;

		private Vector2 _pinchLastMidpoint;

		private float _pinchStartDistance;

		private Vector2 _pinchStartMidpoint;

		private int _touchCount;

		public void AddInputResponder(IInputResponder inputResponder)
		{
			for (int i = 0; i < _fullScreenInputResponders.Count; i++)
			{
				if (_fullScreenInputResponders[i].Priority >= inputResponder.Priority)
				{
					_fullScreenInputResponders.Insert(i, inputResponder);
					return;
				}
			}
			_fullScreenInputResponders.Add(inputResponder);
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			if (_touchCount == 2)
			{
				if (!_pinching)
				{
					_pinching = true;
					PinchEventData pinchEventData = CreatePinchEventData();
					_pinchStartDistance = pinchEventData.Distance;
					_pinchStartMidpoint = pinchEventData.StartMidpoint;
					_pinchLastDistance = pinchEventData.Distance;
					pinchEventData.StartDistance = _pinchStartDistance;
					pinchEventData.StartMidpoint = _pinchStartMidpoint;
					pinchEventData.DistanceDelta = 0f;
					pinchEventData.MidpointDelta = Vector2.zero;
					pinchEventData.AngleDelta = 0f;
					PerformPointerEventAction(_fullScreenInputResponders, (IInputResponder x) => x.OnBeginPinch(pinchEventData));
				}
			}
			else
			{
				PerformPointerEventAction(_fullScreenInputResponders, (IInputResponder x) => x.OnBeginDrag(eventData));
			}
		}

		public void OnDeselect(BaseEventData eventData)
		{
			PerformPointerEventAction(_fullScreenInputResponders, (IInputResponder x) => x.OnDeselect(eventData));
		}

		public void OnDrag(PointerEventData eventData)
		{
			if (_touchCount == 2 && _pinching)
			{
				PinchEventData pinchEventData = CreatePinchEventData();
				PerformPointerEventAction(_fullScreenInputResponders, (IInputResponder x) => x.OnPinch(pinchEventData));
			}
			else
			{
				PerformPointerEventAction(_fullScreenInputResponders, (IInputResponder x) => x.OnDrag(eventData));
			}
		}

		public void OnDrop(PointerEventData eventData)
		{
			PerformPointerEventAction(_fullScreenInputResponders, (IInputResponder x) => x.OnDrop(eventData));
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			if (_pinching)
			{
				_pinching = false;
				PinchEventData pinchEventData = CreatePinchEventData();
				PerformPointerEventAction(_fullScreenInputResponders, (IInputResponder x) => x.OnEndPinch(pinchEventData));
			}
			else
			{
				PerformPointerEventAction(_fullScreenInputResponders, (IInputResponder x) => x.OnEndDrag(eventData));
			}
		}

		public void OnInitializePotentialDrag(PointerEventData eventData)
		{
			PerformPointerEventAction(_fullScreenInputResponders, (IInputResponder x) => x.OnInitializePotentialDrag(eventData));
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			PerformPointerEventAction(_fullScreenInputResponders, (IInputResponder x) => x.OnPointerClick(eventData));
			ReleaseCapture();
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			if (Device.IsTouchEnabled)
			{
				_touchCount++;
			}
			ReleaseCapture();
			PerformPointerEventAction(_fullScreenInputResponders, (IInputResponder x) => x.OnPointerDown(eventData));
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			if (Device.IsTouchEnabled && _touchCount > 0)
			{
				_touchCount--;
			}
			PerformPointerEventAction(_fullScreenInputResponders, (IInputResponder x) => x.OnPointerUp(eventData));
		}

		public void OnScroll(PointerEventData eventData)
		{
			PerformPointerEventAction(_fullScreenInputResponders, (IInputResponder x) => x.OnScroll(eventData));
		}

		public void OnSelect(BaseEventData eventData)
		{
			PerformPointerEventAction(_fullScreenInputResponders, (IInputResponder x) => x.OnSelect(eventData));
		}

		public void RemoveInputResponder(InputResponder inputResponder)
		{
			_fullScreenInputResponders.Remove(inputResponder);
		}

		public void StartInputCapture(IInputResponder inputResponder)
		{
			_capturedInputResponder = inputResponder;
		}

		protected virtual void Awake()
		{
		}

		private PinchEventData CreatePinchEventData()
		{
			Vector2 position = UnityEngine.Input.GetTouch(0).position;
			Vector2 vector = ((_touchCount < 2) ? Vector2.zero : UnityEngine.Input.GetTouch(1).position);
			Vector2 vector2 = position - vector;
			float magnitude = vector2.magnitude;
			Vector2 vector3 = (position + vector) * 0.5f;
			float num = Mathf.Atan2(vector2.y, vector2.x) * 57.29578f;
			PinchEventData result = new PinchEventData
			{
				Distance = magnitude,
				Midpoint = vector3,
				StartMidpoint = _pinchStartMidpoint,
				StartDistance = _pinchStartDistance,
				DistanceDelta = magnitude - _pinchLastDistance,
				MidpointDelta = vector3 - _pinchLastMidpoint,
				AngleDelta = num - _pinchLastAngle
			};
			_pinchLastDistance = magnitude;
			_pinchLastMidpoint = vector3;
			_pinchLastAngle = num;
			return result;
		}

		private void OnApplicationFocus(bool focus)
		{
			_touchCount = 0;
		}

		private IInputResponder PerformPointerEventAction(List<IInputResponder> inputResponders, Func<IInputResponder, bool> action)
		{
			IInputResponder inputResponder = null;
			if (_capturedInputResponder != null)
			{
				if (_capturedInputResponder.IsResponding() && action(_capturedInputResponder))
				{
					inputResponder = _capturedInputResponder;
				}
			}
			else
			{
				for (int num = inputResponders.Count - 1; num >= 0; num--)
				{
					IInputResponder inputResponder2 = inputResponders[num];
					if (inputResponder2.IsResponding() && action(inputResponder2))
					{
						inputResponder = inputResponder2;
						break;
					}
				}
			}
			if (inputResponder != null && _capturedInputResponder == null)
			{
				StartInputCapture(inputResponder);
			}
			return inputResponder;
		}

		private void ReleaseCapture()
		{
			_capturedInputResponder = null;
		}
	}
}
