using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ClickCatchUI : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public UnityEvent onClick;

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left && onClick != null)
		{
			onClick.Invoke();
		}
	}
}
