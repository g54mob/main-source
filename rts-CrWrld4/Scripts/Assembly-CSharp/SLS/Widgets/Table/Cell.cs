using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SLS.Widgets.Table
{
	public class Cell : VisibleComponent, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
	{
		public RectTransform crt;

		public Text text;

		public Image image;

		public Image background;

		protected bool isDown;

		protected Table table;

		private Action<Datum, Column> clickCallback;

		private Action<Datum, Column, PointerEventData> clickCallbackWithData;

		protected bool _isRefreshPending;

		protected bool _isSetColorPending;

		private Element _element;

		private bool doingDirtyLater;

		private float longPressWait;

		public Column column { get; protected set; }

		public Row row { get; protected set; }

		public Element element
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void SetContentSizeDelta(Vector2 size)
		{
		}

		public void SetContentLocalPosition(float x, float y)
		{
		}

		protected override void BecameVisible()
		{
		}

		private void OnEnable()
		{
		}

		public bool Initialize(Table table, Row row, Column column, int idx, RectTransform rt, RectTransform guts, Text text)
		{
			return false;
		}

		public bool Initialize(Table table, Row row, Column column, int idx, RectTransform rt, RectTransform guts, Image image)
		{
			return false;
		}

		private bool FinishInit(Table table, Row row, Column column, int idx, RectTransform rt, RectTransform guts)
		{
			return false;
		}

		private void AttachElement()
		{
		}

		private void DirtyLater()
		{
		}

		private IEnumerator DoDirtyLater()
		{
			return null;
		}

		public virtual void HandleClick(PointerEventData data)
		{
		}

		public virtual void SetColor()
		{
		}

		public void OnPointerEnter(PointerEventData data)
		{
		}

		public void OnPointerExit(PointerEventData data)
		{
		}

		public void OnPointerDown(PointerEventData data)
		{
		}

		public void OnPointerUp(PointerEventData data)
		{
		}

		private void TriggerLongPressEvent()
		{
		}

		public void OnPointerClick(PointerEventData data)
		{
		}
	}
}
