using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CursorChanger : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public void OnPointerEnter(PointerEventData pointerEventData)
	{
		Button component = GetComponent<Button>();
		if ((component != null && component.interactable) || component == null)
		{
			CursorManager.SetCursorPointer();
		}
	}

	public void OnPointerExit(PointerEventData pointerEventData)
	{
		CursorManager.SetCursorNormal();
	}
}
