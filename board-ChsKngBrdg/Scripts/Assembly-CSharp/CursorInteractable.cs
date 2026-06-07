using UnityEngine;
using UnityEngine.EventSystems;

public class CursorInteractable : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public ReactiveCursor.CursorInteractableType type;

	public void OnMouseEnter()
	{
		ReactiveCursor.interactables.Add(type);
	}

	public void OnMouseExit()
	{
		ReactiveCursor.interactables.Remove(type);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		ReactiveCursor.interactables.Add(type);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		ReactiveCursor.interactables.Remove(type);
	}

	public void OnDisable()
	{
		ReactiveCursor.interactables.Remove(type);
	}

	public void OnDestroy()
	{
		ReactiveCursor.interactables.Remove(type);
	}
}
