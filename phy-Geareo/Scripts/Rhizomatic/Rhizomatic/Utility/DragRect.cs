using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Rhizomatic.Utility
{
	public class DragRect : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IPointerMoveHandler, IDragHandler
	{
		public class Pointer
		{
			public PointerEventData eventData;

			public Vector2 delta;

			public Vector2 lastPosition;

			public Vector2 dragPosition;

			public int pointerId => 0;

			public void Update()
			{
			}
		}

		public Vector2 delta;

		public float zoomDelta;

		public Vector2 deltaNormalized;

		public float zoomDeltaNormalized;

		public Action onPointerDown;

		public Action onPointerUp;

		public Action onDrag;

		public bool isDown => false;

		public List<Pointer> pointers { get; }

		private void Update()
		{
		}

		private Vector2 Normalize(Vector2 value)
		{
			return default(Vector2);
		}

		private float Normalize(float value)
		{
			return 0f;
		}

		private void OnDisable()
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
	}
}
