using NSEipix.Base;
using NSMedieval.Sound;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NSEipix.View.UI
{
	public class DropdownItemExtension : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, ICancelHandler
	{
		public void OnPointerEnter(PointerEventData eventData)
		{
			MonoSingleton<AudioManager>.Instance.PlaySound("UI_ButtonHover");
		}

		public void OnCancel(BaseEventData eventData)
		{
			MonoSingleton<AudioManager>.Instance.PlaySound("UI_ButtonClick");
		}
	}
}
