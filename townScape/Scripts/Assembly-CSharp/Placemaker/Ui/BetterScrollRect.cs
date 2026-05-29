using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Placemaker.Ui
{
	public class BetterScrollRect : UIBehaviour, UiMaster.IUiSetup, IDragHandler, IEventSystemHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
	{
		public enum Mode
		{
			None = 0,
			Horizontal = 1,
			Vertical = 2,
			Both = 3
		}

		private struct Context
		{
			public RectTransform contentRt;

			public RectTransform parentRt;

			public Rect contentRect;

			public Rect parentRect;

			public bool horizontalNow;

			public bool verticalNow;

			public Context(BetterScrollRect betterScrollRect)
			{
				contentRt = null;
				parentRt = null;
				contentRect = default(Rect);
				parentRect = default(Rect);
				horizontalNow = false;
				verticalNow = false;
			}
		}

		[SerializeField]
		private UiMaster master;

		public Mode mode;

		public bool snap;

		public Vector2 unclampedAnchor;

		public Vector2 normPosCurrent;

		public Vector2 normPosTarget;

		public Vector2 velocity;

		[NonSerialized]
		private List<Vector3> drags;

		private bool dragging;

		private bool hovered;

		private int dragPointerId;

		public Action onBeginDrag;

		public Action onEndDrag;

		public Action onScroll;

		public void OnStart(UiMaster master)
		{
		}

		public void OnSetup(UiMaster master)
		{
		}

		void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
		{
		}

		void IDragHandler.OnDrag(PointerEventData eventData)
		{
		}

		void IEndDragHandler.OnEndDrag(PointerEventData eventData)
		{
		}

		void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
		{
		}

		void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
		{
		}

		private void GetNormalizedPos(Vector3 worldPos, ref Vector2 normalizedPos, Context context)
		{
		}

		private void GetWorldPos(Vector2 normalizedPos, ref Vector3 worldPos, Context context)
		{
		}

		private void OnDrawGizmos()
		{
		}

		protected override void OnDisable()
		{
		}

		private void Update()
		{
		}

		private void LateUpdate()
		{
		}

		public Vector2 GetScrollableSize()
		{
			return default(Vector2);
		}
	}
}
