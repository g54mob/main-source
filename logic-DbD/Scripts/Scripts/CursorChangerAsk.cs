using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CursorChangerAsk : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler
{
	public void OnPointerEnter(PointerEventData pointerEventData)
	{
		Button component = GetComponent<Button>();
		if ((component != null && component.interactable) || component == null)
		{
			CursorManager.SetCursorAsk();
		}
	}

	public void OnPointerExit(PointerEventData pointerEventData)
	{
		CursorManager.SetCursorNormal();
	}

	public void OnPointerClick(PointerEventData pointerEventData)
	{
		CursorManager.SetCursorNormal();
	}
}
