using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GRP
{
	public class CollapsibleButton : MonoBehaviour, IDragHandler, IEventSystemHandler, IEndDragHandler, IBeginDragHandler, IPointerClickHandler
	{
		public Action onClick;

		public Action<Vector2> onEndDrag;

		public float smooth;

		public bool dragging;

		public Vector2 distance;

		private Vector2 delta;

		private Vector2 mousePos;

		private Vector2 startPos;

		private Vector2 mouseHelper;

		private void Update()
		{
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
		}

		public void OnDrag(PointerEventData eventData)
		{
		}

		public void OnEndDrag(PointerEventData eventData)
		{
		}

		public void OnPointerClick(PointerEventData eventData)
		{
		}
	}
}
