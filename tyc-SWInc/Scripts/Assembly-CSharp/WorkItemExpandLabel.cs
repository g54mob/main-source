using UnityEngine;
using UnityEngine.EventSystems;

public class WorkItemExpandLabel : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerDownHandler
{
	public GUIWorkItem Parent;

	public void OnPointerClick(PointerEventData eventData)
	{
		Parent.Expand();
	}

	public void OnPointerDown(PointerEventData eventData)
	{
	}
}
