using NSEipix.Base;
using NSMedieval.Sound;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NSEipix.View.UI
{
	[RequireComponent(typeof(TMP_Dropdown))]
	public class DropdownExtension : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, ISubmitHandler
	{
		public void OnPointerClick(PointerEventData eventData)
		{
			MonoSingleton<AudioManager>.Instance.PlaySound("UI_Dropdown");
		}

		public void OnSubmit(BaseEventData eventData)
		{
			MonoSingleton<AudioManager>.Instance.PlaySound("UI_ButtonClick");
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			MonoSingleton<AudioManager>.Instance.PlaySound("UI_ButtonHover");
		}

		private void Start()
		{
			GetComponent<TMP_Dropdown>().onValueChanged.AddListener(delegate
			{
				MonoSingleton<AudioManager>.Instance.PlaySound("UI_ToggleOn");
			});
		}
	}
}
