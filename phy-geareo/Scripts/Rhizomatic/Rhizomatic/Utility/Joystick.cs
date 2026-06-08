using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Rhizomatic.Utility
{
	public class Joystick : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IPointerMoveHandler, IDragHandler
	{
		public RectTransform rectTransform;

		public RectTransform container;

		public RectTransform handle;

		public Action onDown;

		public Action<Vector2> onUp;

		public Action<Vector2> onMove;

		private int currentPointer;

		public Vector2 value { get; private set; }

		public bool isDown { get; private set; }

		private void Awake()
		{
		}

		private void Update()
		{
		}

		private void OnDisable()
		{
		}

		private void CalculateValue(PointerEventData eventData)
		{
		}

		public void OnPointerMove(PointerEventData eventData)
		{
		}

		public void OnDrag(PointerEventData eventData)
		{
		}

		public void OnPointerDown(PointerEventData eventData)
		{
		}

		public void OnPointerUp(PointerEventData eventData)
		{
		}

		private void Reset()
		{
		}
	}
}
