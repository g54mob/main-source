using UnityEngine;
using UnityEngine.EventSystems;

public class MouseSoundHandler : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
{
	public string enterSound;

	public string exitSound;

	public string clickSound;

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	public void OnPointerClick(PointerEventData eventData)
	{
	}
}
