using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenHyperlinks : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public void OnPointerClick(PointerEventData eventData)
	{
		TMP_Text component = GetComponent<TMP_Text>();
		int num = TMP_TextUtilities.FindIntersectingLink(component, Input.mousePosition, null);
		if (num != -1)
		{
			TMP_LinkInfo tMP_LinkInfo = component.textInfo.linkInfo[num];
			Application.OpenURL(tMP_LinkInfo.GetLinkID());
		}
	}
}
