using UnityEngine;
using UnityEngine.EventSystems;

public class PreventPanelOpen : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public void OnPointerEnter(PointerEventData eventData)
	{
		Sign.PreventEvent = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		Sign.PreventEvent = false;
	}
}
