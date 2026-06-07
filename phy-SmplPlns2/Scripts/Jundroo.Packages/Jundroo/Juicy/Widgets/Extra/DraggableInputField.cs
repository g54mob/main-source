using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Jundroo.Juicy.Widgets.Extra
{
	public class DraggableInputField : TMP_InputField
	{
		private const float DragThreshold = 0.5f;

		private readonly float _doubleClickDelay = 0.5f;

		[SerializeField]
		private HorizontalLayoutGroup _childLayout;

		private float _clickTime;

		public bool AllowDragEventToBubble { get; set; } = true;

		public HorizontalLayoutGroup ChildLayout => _childLayout;

		public override void OnBeginDrag(PointerEventData eventData)
		{
			if (!AllowDragEventToBubble || base.isFocused)
			{
				base.OnBeginDrag(eventData);
			}
			else
			{
				PassEventUpward(eventData, ExecuteEvents.beginDragHandler);
			}
		}

		public override void OnDrag(PointerEventData eventData)
		{
			if (!AllowDragEventToBubble || base.isFocused)
			{
				base.OnDrag(eventData);
			}
			else
			{
				PassEventUpward(eventData, ExecuteEvents.dragHandler);
			}
		}

		public override void OnEndDrag(PointerEventData eventData)
		{
			if (!AllowDragEventToBubble || base.isFocused)
			{
				base.OnEndDrag(eventData);
			}
			else
			{
				PassEventUpward(eventData, ExecuteEvents.endDragHandler);
			}
		}

		public override void OnPointerDown(PointerEventData eventData)
		{
			if (!AllowDragEventToBubble || base.isFocused)
			{
				base.OnPointerDown(eventData);
				if (base.contentType == ContentType.DecimalNumber && eventData.button == PointerEventData.InputButton.Left)
				{
					float unscaledTime = Time.unscaledTime;
					if (_clickTime + _doubleClickDelay > unscaledTime)
					{
						CaretPosition cursor;
						int num = TMP_TextUtilities.GetCursorIndexFromPosition(m_TextComponent, eventData.position, eventData.pressEventCamera, out cursor);
						if (cursor == CaretPosition.Right)
						{
							num++;
						}
						base.caretPosition = num;
						UpdateLabel();
					}
				}
			}
			_clickTime = Time.unscaledTime;
		}

		public override void OnPointerUp(PointerEventData eventData)
		{
			if (!base.isFocused && AllowDragEventToBubble && Time.time - _clickTime < 0.5f)
			{
				base.OnPointerDown(eventData);
			}
		}

		private void PassEventUpward<T>(PointerEventData data, ExecuteEvents.EventFunction<T> function) where T : IEventSystemHandler
		{
			GameObject gameObject = base.transform.parent.gameObject;
			while (gameObject != null && !ExecuteEvents.Execute(gameObject, data, function) && !(gameObject.transform.parent == null))
			{
				gameObject = gameObject.transform.parent.gameObject;
			}
		}
	}
}
