using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tabletop.GameWorld
{
	public class WargameDiceAnchor : MonoBehaviour, IDropHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
	{
		[Header("References")]
		[SerializeField]
		private Outline m_outline;

		[Header("Parameters")]
		[SerializeField]
		private int m_index;

		private WargameDice m_dice;

		public bool HasDice => m_dice != null;

		public WargameDice Dice => m_dice;

		public event Action<int, int> DicePlaced;

		public void Init(WargameDice dice)
		{
			m_dice = dice;
		}

		public void Clear()
		{
			m_dice = null;
		}

		public void ParentDice()
		{
			if (m_dice != null)
			{
				m_dice.ParentToAnchor();
			}
		}

		public void OnLoseDice(WargameDice dice)
		{
			if (m_dice == dice)
			{
				m_dice = null;
				this.DicePlaced?.Invoke(m_index, 0);
			}
		}

		public void OnDrop(PointerEventData eventData)
		{
			if (eventData.pointerDrag.TryGetComponent<WargameDice>(out var component))
			{
				if (m_dice != null)
				{
					m_dice.RejectFor(component);
				}
				Drop(component);
			}
		}

		public void Drop(WargameDice dice)
		{
			m_dice = dice;
			m_dice.SetAnchor(this);
			this.DicePlaced?.Invoke(m_index, m_dice.Value);
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (m_outline != null && eventData.dragging && eventData.pointerDrag.TryGetComponent<WargameDice>(out var _))
			{
				m_outline.enabled = true;
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (m_outline != null)
			{
				m_outline.enabled = false;
			}
		}
	}
}
