using UnityEngine;
using UnityEngine.EventSystems;

public class ViewportMouseOver : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public bool isOver;

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	public void ForceMouseOver(bool val)
	{
	}
}
