using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Presentation.UI
{
	public class ScrollRectWithMMB : ScrollRect
	{
		public bool IsDragging { get; private set; }

		public override void OnBeginDrag(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Middle)
			{
				eventData.button = PointerEventData.InputButton.Left;
			}
			IsDragging = true;
			base.OnBeginDrag(eventData);
		}

		public override void OnEndDrag(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Middle)
			{
				eventData.button = PointerEventData.InputButton.Left;
			}
			IsDragging = false;
			base.OnEndDrag(eventData);
		}

		public override void OnDrag(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Middle)
			{
				eventData.button = PointerEventData.InputButton.Left;
			}
			base.OnDrag(eventData);
		}
	}
}
