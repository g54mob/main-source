using DV.Localization;
using DV.UIFramework;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DV.UI
{
	[DisallowMultipleComponent]
	public class TooltipSource : NullCheckingMonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		public string value;

		public bool valueIsLocalizationKey;

		[NullCheck]
		public TextMeshProUGUI tooltipTMPro;

		protected bool hovering;

		public virtual void SetTooltipText(string text)
		{
			value = text;
			if (hovering)
			{
				OnPointerEnter(null);
			}
		}

		public virtual void OnPointerEnter(PointerEventData eventData)
		{
			hovering = true;
			if ((bool)tooltipTMPro)
			{
				tooltipTMPro.text = GetFinalValue();
			}
		}

		public virtual void OnPointerExit(PointerEventData eventData)
		{
			hovering = false;
			if ((bool)tooltipTMPro && tooltipTMPro.text == GetFinalValue())
			{
				tooltipTMPro.text = "";
			}
		}

		public string GetFinalValue()
		{
			if (!valueIsLocalizationKey)
			{
				return value;
			}
			return LocalizationAPI.L(value);
		}
	}
}
