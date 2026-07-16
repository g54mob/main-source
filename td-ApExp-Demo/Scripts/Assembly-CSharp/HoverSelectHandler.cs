using UnityEngine;
using UnityEngine.EventSystems;

public class HoverSelectHandler : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler
{
	private Menu parentMenu;

	public void Initialize(Menu menu)
	{
		parentMenu = menu;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		parentMenu?.HandleHoverSelect(base.gameObject);
	}
}
