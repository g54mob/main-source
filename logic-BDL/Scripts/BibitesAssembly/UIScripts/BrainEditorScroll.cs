using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UIScripts
{
	public class BrainEditorScroll : ScrollRect, IPointerClickHandler, IEventSystemHandler
	{
		public UnityEvent onPointerClick = new UnityEvent();

		public override void OnDrag(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Right)
			{
				eventData.button = PointerEventData.InputButton.Left;
				base.OnDrag(eventData);
			}
		}

		public override void OnBeginDrag(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Right)
			{
				eventData.button = PointerEventData.InputButton.Left;
				base.OnBeginDrag(eventData);
			}
		}

		public override void OnEndDrag(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Right)
			{
				eventData.button = PointerEventData.InputButton.Left;
				base.OnEndDrag(eventData);
			}
		}

		public override void OnInitializePotentialDrag(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Right)
			{
				eventData.button = PointerEventData.InputButton.Left;
				base.OnInitializePotentialDrag(eventData);
			}
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Left)
			{
				onPointerClick.Invoke();
			}
		}
	}
}
