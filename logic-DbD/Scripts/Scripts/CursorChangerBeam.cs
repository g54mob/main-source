using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorChangerBeam : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public void OnPointerEnter(PointerEventData pointerEventData)
	{
		TMP_InputField component = GetComponent<TMP_InputField>();
		if ((component != null && component.interactable) || component == null)
		{
			CursorManager.SetCursorIBeam();
		}
	}

	public void OnPointerExit(PointerEventData pointerEventData)
	{
		CursorManager.SetCursorNormal();
	}
}
