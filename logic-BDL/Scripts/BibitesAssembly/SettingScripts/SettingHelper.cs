using UnityEngine;
using UnityEngine.EventSystems;

namespace SettingScripts
{
	public class SettingHelper : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		public GameObject HelperPanel;

		public string WikiLink;

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (HelperPanel != null)
			{
				HelperPanel.SetActive(value: true);
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (HelperPanel != null)
			{
				HelperPanel.SetActive(value: false);
			}
		}

		public void OpenWikiLink()
		{
			if (WikiLink != "")
			{
				Application.OpenURL("https://the-bibites.fandom.com/wiki/" + WikiLink);
			}
		}
	}
}
