using UnityEngine;
using UnityEngine.EventSystems;

public class CursorObject : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	public CursorManager.CursorType cursorType;

	public void OnPointerEnter(PointerEventData eventData)
	{
		CursorManager.Instance.SetActiveCursorType(cursorType);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		CursorManager.Instance.SetActiveCursorType(CursorManager.CursorType.Arrow);
	}
}
