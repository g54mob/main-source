using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeCursorState : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	[Tooltip("Cursor to display when hovering over this UI object")]
	private CursorState _cursorState = CursorState.TextInput;

	public void OnPointerEnter(PointerEventData eventData)
	{
		CursorManager.SetCursorState(_cursorState);
		CursorManager.LockCursorState();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		CursorManager.UnlockCursorState();
		CursorManager.SetCursorState(CursorState.Normal);
	}

	private void OnDisable()
	{
		CursorManager.UnlockCursorState();
		CursorManager.SetCursorState(CursorState.Normal);
	}
}
