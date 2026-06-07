using Simulator;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tabletop.GameWorld
{
	public class UI_WargameMiniature : UINavElement
	{
		[Header("Wargame Miniature")]
		[SerializeField]
		private Image m_image;

		[SerializeField]
		private UI_WargameMiniatureTooltip m_tooltip;

		public void SetContent(MiniatureData data)
		{
			m_tooltip.SetContent(data.Skill, showLifePoints: false);
		}

		public void SetState(bool active, bool alive)
		{
			if (alive)
			{
				m_image.color = (active ? Color.red : Color.white);
			}
			else
			{
				m_image.color = Color.grey;
			}
		}

		public override void OnPointerEnter(PointerEventData eventData)
		{
			base.OnPointerEnter(eventData);
			m_tooltip.SetActive(active: true);
		}

		public override void OnPointerExit(PointerEventData eventData)
		{
			base.OnPointerExit(eventData);
			m_tooltip.SetActive(active: false);
		}

		public override void OnSelect(BaseEventData eventData)
		{
			base.OnSelect(eventData);
			m_tooltip.SetActive(active: true);
		}

		public override void OnDeselect(BaseEventData eventData)
		{
			base.OnDeselect(eventData);
			m_tooltip.SetActive(active: false);
		}
	}
}
