using UnityEngine;
using UnityEngine.EventSystems;

public class UIHoverCursor : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public void OnPointerEnter(PointerEventData eventData)
	{
		if (CursorManager.Instance != null)
		{
			CursorManager.Instance.SetOverUI(over: true);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (CursorManager.Instance != null)
		{
			CursorManager.Instance.SetOverUI(over: false);
		}
	}

	private void OnDisable()
	{
		if (CursorManager.Instance != null)
		{
			CursorManager.Instance.SetOverUI(over: false);
		}
	}
}
