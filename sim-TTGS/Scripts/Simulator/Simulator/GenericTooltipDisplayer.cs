using I2.Loc;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Simulator
{
	public class GenericTooltipDisplayer : MonoBehaviour, ITooltipDisplayer, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[Header("References")]
		[SerializeField]
		private Graphic m_graphic;

		[Header("Content")]
		[SerializeField]
		[TermsPopup("")]
		private string m_tooltipTerm;

		public Graphic Graphic => m_graphic;

		public RectTransform RectTransform
		{
			get
			{
				if (!m_graphic)
				{
					return null;
				}
				return m_graphic.rectTransform;
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			TooltipManager.PrepareTooltip(this);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			TooltipManager.CancelTooltip(this);
		}

		public bool TryGetTooltipTerm(out string tooltipTerm)
		{
			tooltipTerm = m_tooltipTerm;
			return base.enabled;
		}

		public void SetTerm(string term)
		{
			m_tooltipTerm = term;
		}
	}
}
