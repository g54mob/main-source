using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tabletop.GameWorld
{
	public class UI_CollectionSquadMiniatureSlot : MonoBehaviour, IDropHandler, IEventSystemHandler
	{
		[Header("Parameters")]
		[SerializeField]
		private int m_index;

		private UI_CollectionSquadItem m_item;

		public int Index => m_index;

		public UI_CollectionSquadItem Item => m_item;

		public event Action WelcomedItem;

		public void WelcomeItem(UI_CollectionSquadItem item, bool callback)
		{
			m_item = item;
			m_item.Anchor(this);
			if (callback)
			{
				this.WelcomedItem?.Invoke();
			}
		}

		public void LostItem(UI_CollectionSquadItem item)
		{
			if (m_item == item)
			{
				m_item = null;
				this.WelcomedItem?.Invoke();
			}
		}

		public void Clear()
		{
			m_item = null;
		}

		public void OnDrop(PointerEventData eventData)
		{
			if (AcceptDrop(eventData, out var item))
			{
				WelcomeItem(item, callback: true);
			}
		}

		public bool AcceptDrop(PointerEventData eventData, out UI_CollectionSquadItem item)
		{
			return eventData.pointerDrag.TryGetComponent<UI_CollectionSquadItem>(out item);
		}

		public void OnItemDropped(UI_CollectionSquadItem item)
		{
			WelcomeItem(item, callback: true);
		}
	}
}
