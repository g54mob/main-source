using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PauseMenu_TabButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerClickHandler, IPointerExitHandler, ISelectHandler
{
	public PauseMenu_TabGroup tabGroup;

	public Image background;

	public Color tabIdle;

	public Color tabHover;

	public Color tabActive;

	void ISelectHandler.OnSelect(BaseEventData eventData)
	{
	}

	void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
	{
	}

	void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
	{
	}

	void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
	{
	}

	private void Start()
	{
	}
}
