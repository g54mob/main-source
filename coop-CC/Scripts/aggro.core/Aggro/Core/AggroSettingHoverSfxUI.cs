using FMODUnity;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Aggro.Core
{
	internal sealed class AggroSettingHoverSfxUI : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, ISelectHandler
	{
		public EventReference sfx;

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (AggroSettings.inputMode == InputMode.KBM)
			{
				AggroUtil.PlaySfxIfValid(sfx);
			}
		}

		public void OnSelect(BaseEventData eventData)
		{
			if (AggroSettings.inputMode == InputMode.Gamepad)
			{
				AggroUtil.PlaySfxIfValid(sfx);
			}
		}
	}
}
