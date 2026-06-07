using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UIScripts.UIPanels
{
	public class AncestralLineageScroll : ScrollRect, IPointerClickHandler, IEventSystemHandler
	{
		protected override void Awake()
		{
			base.Awake();
			if (base.verticalScrollbar != null)
			{
				base.verticalScrollbar.onValueChanged.AddListener(delegate
				{
					TellPanelToUpdate();
				});
			}
			if (base.horizontalScrollbar != null)
			{
				base.horizontalScrollbar.onValueChanged.AddListener(delegate
				{
					TellPanelToUpdate();
				});
			}
		}

		public override void OnScroll(PointerEventData data)
		{
			if (!Input.GetKey(KeyCode.RightControl) && !Input.GetKey(KeyCode.LeftControl))
			{
				if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
				{
					data.scrollDelta = new Vector2(data.scrollDelta.y, data.scrollDelta.x);
				}
				base.OnScroll(data);
				TellPanelToUpdate();
			}
		}

		public override void OnDrag(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Right)
			{
				eventData.button = PointerEventData.InputButton.Left;
				base.OnDrag(eventData);
				TellPanelToUpdate();
			}
		}

		public override void OnBeginDrag(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Right)
			{
				eventData.button = PointerEventData.InputButton.Left;
				base.OnBeginDrag(eventData);
				TellPanelToUpdate();
			}
		}

		public override void OnEndDrag(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Right)
			{
				eventData.button = PointerEventData.InputButton.Left;
				base.OnEndDrag(eventData);
				TellPanelToUpdate();
			}
		}

		public override void OnInitializePotentialDrag(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Right)
			{
				eventData.button = PointerEventData.InputButton.Left;
				base.OnInitializePotentialDrag(eventData);
				TellPanelToUpdate();
			}
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			_ = eventData.button;
		}

		private void TellPanelToUpdate()
		{
		}
	}
}
