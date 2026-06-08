using System;
using Rhizomatic.Pooling;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Rhizomatic
{
	public class CurvePoint : PoolObject, IPointerClickHandler, IEventSystemHandler, IPointerDownHandler, IPointerUpHandler
	{
		public RectTransform rectTransform;

		public GameObject selected;

		public CurvePointHandle outHandle;

		public CurvePointHandle inHandle;

		[NonSerialized]
		public CurveKeyframe key;

		[NonSerialized]
		public Vector2 offset;

		[NonSerialized]
		public CurveFieldPopup popup;

		private bool isDown;

		private bool isDrag;

		private float downTime;

		private Vector2 downPosition;

		private bool preventClick;

		protected override void OnCreated()
		{
		}

		protected override void OnPooled()
		{
		}

		public void _Select()
		{
		}

		public void _Deselect()
		{
		}

		public void OnPointerClick(PointerEventData eventData)
		{
		}

		protected override void Update()
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
