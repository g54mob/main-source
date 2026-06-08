using UnityEngine.EventSystems;

public class CursorChangerExit : CursorChanger, IPointerClickHandler, IEventSystemHandler
{
	public void OnPointerClick(PointerEventData pointerEventData)
	{
		CursorManager.SetCursorNormal();
	}
}
