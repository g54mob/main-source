using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.UI.Dialogs
{
	public class ColorPickerInputHandlerScript : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IInitializePotentialDragHandler, IDragHandler, IPointerUpHandler
	{
		public class InputData
		{
			public float Angle { get; set; }

			public bool Cancelled { get; set; }

			public bool IsDragging { get; set; }

			public Vector2 Position { get; set; }

			public float Radius { get; set; }
		}

		private bool _captured;

		public Action<InputData> OnInput { get; set; }

		public RectTransform Target { get; set; }

		void IDragHandler.OnDrag(PointerEventData eventData)
		{
			if (_captured)
			{
				SendInputEvent(eventData);
			}
		}

		void IInitializePotentialDragHandler.OnInitializePotentialDrag(PointerEventData eventData)
		{
			eventData.useDragThreshold = false;
		}

		void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
		{
			_captured = true;
			SendInputEvent(eventData);
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			_captured = false;
		}

		private void SendInputEvent(PointerEventData eventData)
		{
			RectTransform rectTransform = ((Target != null) ? Target : GetComponent<RectTransform>());
			RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, null, out var localPoint);
			InputData inputData = new InputData();
			float x = rectTransform.sizeDelta.x;
			Vector2 vector = (localPoint + rectTransform.sizeDelta * 0.5f) / x;
			inputData.Position = new Vector2(Mathf.Clamp01(vector.x), Mathf.Clamp01(vector.y));
			inputData.Radius = localPoint.magnitude;
			inputData.Angle = Mathf.Atan2(localPoint.y, localPoint.x) * 57.29578f;
			if (inputData.Angle < 0f)
			{
				inputData.Angle += 360f;
			}
			inputData.IsDragging = eventData.dragging;
			OnInput?.Invoke(inputData);
			if (inputData.Cancelled)
			{
				_captured = false;
			}
		}
	}
}
